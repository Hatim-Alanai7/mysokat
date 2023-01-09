using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using Common_Classes;
using System.Net.Sockets;
using System.Net;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Threading;

namespace Client.BL
{
    public class HomeClient
    {
        User user;
        TcpClient client = new TcpClient();
        Stream tcpStream;
        public event EventHandler<ReceiveMessegeEventArgs> receiveMessege;
        bool serverError = false;
        BinaryFormatter bf;
        object locker = "nothing";

        public HomeClient(string address, int port, string name, Color textColor)
        {
            user = new User(name, textColor);
            try
            {
                client.Connect(IPAddress.Parse(address), port);
            }
            catch
            {
                serverError = true;
                return;
            }
            tcpStream = client.GetStream();
            bf = new BinaryFormatter();
            bf.Serialize(tcpStream, user);
        }

        public User GetUser { get { return user; } }
        public Stream GetStream { get { return tcpStream; } }
        public bool ServerError { get { return serverError; } }

        public void SendMessege(Messege msg)
        {
            try
            {
                bf.Serialize(tcpStream, msg);
            }
            catch
            {
                serverError = true;
                return;
            }
        }

        public void ReceiveMesseges()
        {
            ThreadPool.QueueUserWorkItem(o =>
            {
                while (user.UserStatus == Status.connected)
                {
                    try
                    {
                        Messege msg = (Messege)bf.Deserialize(tcpStream);
                        ThreadPool.QueueUserWorkItem(p =>
                        {
                            lock (locker)
                            {
                                ReceiveMessegeEventArgs newMessege = new ReceiveMessegeEventArgs(msg);
                                if (receiveMessege != null)
                                    receiveMessege(this, newMessege);
                            }
                        });
                    }
                    catch
                    {
                        tcpStream.Dispose();
                        return;
                    }
                }

            });
        }
    }
}
