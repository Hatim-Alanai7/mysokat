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
        public event EventHandler<ExistingAccountEventArgs> existingAccount;
        ExistingAccountEventArgs existingAccountEventArgs;
        bool serverError = false;
        bool singInFails = false;
        bool singUpFails = false;
        BinaryFormatter bf;
        object locker = "nothing";

        public HomeClient(string address, int port, string name, Color textColor, Operation operation)
        {
            user = new User(name, textColor, operation);
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
            existingAccountEventArgs = (ExistingAccountEventArgs)bf.Deserialize(tcpStream);
            ThreadPool.QueueUserWorkItem(o =>
            {
                if (existingAccountEventArgs.ErrorExists == true && existingAccountEventArgs.GetOperation == Operation.LogIn)
                    bf.Serialize(tcpStream, new AcceptDisposeServer(true));
                if (existingAccount != null && existingAccountEventArgs.ErrorExists)
                    existingAccount(this, existingAccountEventArgs);
                else
                    ReceiveMesseges();
            });
        }

        public User GetUser { get { return user; } }
        public Stream GetStream { get { return tcpStream; } }
        public bool ServerError { get { return serverError; } }
        public bool SingInFails { get { return singInFails; } }
        public bool SingUpFails { get { return singUpFails; } }
        public ExistingAccountEventArgs IsExist { get { return existingAccountEventArgs; } }

        public void SendMessege(Messege msg)
        {
            try
            {
                if (msg is MsgUser)
                    ((MsgUser)msg).TxtMessege = user.UserName + " said: " + ((MsgUser)msg).TxtMessege;
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
            while (user.UserStatus == Status.connected)
            {
                try
                {
                    Messege msg = (Messege)bf.Deserialize(tcpStream);
                    ThreadPool.QueueUserWorkItem(p =>
                    {
                        lock (locker)
                        {
                            try
                            {
                                ReceiveMessegeEventArgs newMessege = new ReceiveMessegeEventArgs(msg);
                                if (receiveMessege != null)
                                    receiveMessege(this, newMessege);
                            }
                            catch
                            {  }
                        }
                    });
                }
                catch
                {
                    tcpStream.Dispose();
                    return;
                }
            }
        }
    }
}
