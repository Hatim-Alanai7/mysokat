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
using Server.DAL;

namespace Server.BL
{
    public delegate void ExistingAccountDelegate(User user);

    public class UserManager : IDisposable
    {
        static List<UserManager> ActiveUsers = new List<UserManager>();
        Stream tcpStream;
        User user;
        HomeServer homeServer;
        MessegesManager msgManager = new MessegesManager();
        StatusUserEventArgs statusUserEventArgs;
        AcceptDisconnectedUserEventArgs acceptDisconnectedUserEventArgs;
        public event EventHandler<AcceptDisconnectedUserEventArgs> acceptDisconnectedUser;
        ChatContext context;
        bool logInSucceed = false;
        bool singUpSucceed = false;
        BinaryFormatter bf = new BinaryFormatter();
        object locker = "nothing";

        public bool SingUpSucceed { get { return singUpSucceed; } }
        public bool LogInSuccceed { get { return logInSucceed; } }
        public StatusUserEventArgs GetStatusUserEventArgs { get { return statusUserEventArgs; } }
        public User GetUser { get { return this.user; } }
        public Stream GetTcpStream { get { return tcpStream; } }
        public IEnumerable<UserManager> GetActiveUsers { get { return ActiveUsers; } }
        public MessegesManager GetMessegesManager { get { return msgManager; } }

        public UserManager(TcpClient newClient, HomeServer homeServer)
        {
            this.homeServer = homeServer;
            tcpStream = newClient.GetStream();
            context = new ChatContext();
            try
            {
                this.user = (User)bf.Deserialize(tcpStream);
                if (this.user.GetOperation == Operation.LogIn)
                    LogInOperation();
                else
                    SingUpOperation();
            }
            catch
            {
                this.Dispose();
            }

        }

        private bool ThisUserFoundInDb(string userNameSearch)
        {
            if (userNameSearch == null) return false;
            User userSearch = context.Users.FirstOrDefault(u => u.UserName == userNameSearch);
            if (userSearch == null)
                return false;
            return true;
        }

        public User FindUserDb(string userNameSearch)
        {
            if (userNameSearch == null) return null;
            return context.Users.FirstOrDefault(u => u.UserName == userNameSearch);
        }

        public User FindUserDb(int userId)
        {
            return context.Users.FirstOrDefault(u => u.UserID == userId);
        }

        private bool AddUserDB()
        {
            if (ThisUserFoundInDb(this.user.UserName))
            {
                singUpSucceed = false;
                bf.Serialize(tcpStream, new ExistingAccountEventArgs(this.user, true, this.user.GetOperation));
                tcpStream.Dispose();
                return false;
            }
            context.Users.Attach(this.user);
            context.Users.Add(this.user);
            context.SaveChanges();
            bf.Serialize(tcpStream, new ExistingAccountEventArgs(this.user, false, this.user.GetOperation));
            return true;
        }

        private void LogInOperation()
        {
            if (!ThisUserFoundInDb(this.user.UserName))
            {
                logInSucceed = false;
                bf.Serialize(tcpStream, new ExistingAccountEventArgs(this.user, true, this.user.GetOperation));
                AcceptDisposeServer acceptDisposeServer = (AcceptDisposeServer)bf.Deserialize(tcpStream);
                if(acceptDisposeServer.Accept==true)
                    tcpStream.Dispose();
                return;
            }
            bf.Serialize(tcpStream, new ExistingAccountEventArgs(this.user, false, this.user.GetOperation));
            statusUserEventArgs = new StatusUserEventArgs(this.user);
            ActiveUsers.Add(this);
            logInSucceed = true;
        }

        private void SingUpOperation()
        {
            if (AddUserDB())
            {
                statusUserEventArgs = new StatusUserEventArgs(this.user);
                ActiveUsers.Add(this);
                singUpSucceed = true;
            }
        }

        public void KeepListening()
        {
            Messege msg;
            acceptDisconnectedUser += AcceptDisconnected;
            try
            {
                while (this.GetUser.UserStatus == Status.connected)
                {
                    msg = (Messege)bf.Deserialize(tcpStream);
                    ThreadPool.QueueUserWorkItem(o =>
                    {
                        lock (locker)
                        {
                            msgManager = new MessegesManager(this, msg, context);
                            if (msgManager.GetStatusUserEventArgs != null)
                            {
                                acceptDisconnectedUserEventArgs = new AcceptDisconnectedUserEventArgs(msgManager.GetStatusUserEventArgs);
                                if (acceptDisconnectedUser != null)
                                    acceptDisconnectedUser(this, acceptDisconnectedUserEventArgs);
                            }
                            Monitor.PulseAll(locker);
                        }
                    });
                }
                this.Dispose();
                ActiveUsers.Remove(this);
            }
            catch
            {
                ActiveUsers.Remove(this);
                this.Dispose();
            }
        }

        public void AcceptDisconnected(object o, AcceptDisconnectedUserEventArgs e)
        {
            homeServer.UpdateUserStatus(o, e);
            ActiveUsers.Remove(this);
        }

        public void Dispose()
        {
            this.tcpStream.Dispose();
        }
    }
}
