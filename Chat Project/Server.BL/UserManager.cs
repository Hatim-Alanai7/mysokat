using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Common_Classes;
using System.Runtime.Serialization.Formatters.Binary;
using System.Net.Sockets;
using System.Threading;

namespace Server.BL
{
    public class UserManager
    {
        static List<UserManager> ActiveUsers = new List<UserManager>();
        Stream tcpStream;
        User user;
        HomeServer homeServer;
        StatusUserEventArgs statusUserEventArgs;
        AcceptDisconnectedUserEventArgs acceptDisconnectedUser;
        public event EventHandler<AcceptDisconnectedUserEventArgs> acceptDisconnected;
        BinaryFormatter bf = new BinaryFormatter();
        object locker = "nothing";

        public UserManager(TcpClient newClient, HomeServer homeServer)
        {
            this.homeServer = homeServer;
            tcpStream = newClient.GetStream();
            try
            {
                user = (User)bf.Deserialize(tcpStream);
                statusUserEventArgs = new StatusUserEventArgs(user);
                ActiveUsers.Add(this);
            }
            catch
            {
                tcpStream.Dispose();
            }
        }

        public StatusUserEventArgs GetStatusUserEventArgs { get { return statusUserEventArgs; } }
        public User GetUser { get { return user; } }
        public Stream GetTcpStream { get { return tcpStream; } }
        public IEnumerable<UserManager> GetActiveUsers { get { return ActiveUsers; } }

        public void KeepListening()
        {
            MessegesManager msgManager;
            Messege msg;
            acceptDisconnected += AcceptDisconnected;

            try
            {
                while (this.GetUser.UserStatus == Status.connected)
                {
                    msg = (Messege)bf.Deserialize(tcpStream);
                    ThreadPool.QueueUserWorkItem(o =>
                    {
                        lock (locker)
                        {
                            msgManager = new MessegesManager(this, msg);
                            if (msgManager.GetStatusUserEventArgs != null)
                            {
                                acceptDisconnectedUser = new AcceptDisconnectedUserEventArgs(msgManager.GetStatusUserEventArgs);
                                if (acceptDisconnected != null)
                                {
                                    acceptDisconnected(this, acceptDisconnectedUser);
                                }
                            }
                            Monitor.PulseAll(locker);
                        }
                    });
                }
                tcpStream.Dispose();
                ActiveUsers.Remove(this);
            }
            catch
            {
                tcpStream.Dispose();
                ActiveUsers.Remove(this);
            }
        }

        public void AcceptDisconnected(object o, AcceptDisconnectedUserEventArgs e)
        {
            homeServer.UpdateUserStatus(o, e);
            ActiveUsers.Remove(this);
        }
    }
}
