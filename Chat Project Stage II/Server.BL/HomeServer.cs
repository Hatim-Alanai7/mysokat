using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common_Classes;
using System.Runtime.Serialization.Formatters.Binary;
using System.Net.Sockets;
using System.Net;
using System.Threading;
using Server.DAL;


namespace Server.BL
{
    public class HomeServer
    {
        public event EventHandler<StatusUserEventArgs> activeUser;
        BinaryFormatter bf = new BinaryFormatter();
        UserManager userManager;
        bool dataError = false;
        object locker = "nothing";

        public UserManager GetUserManager { get { return userManager; } }
        public bool DataError { get { return dataError; } }

        public HomeServer(string address, int port)
        {
            try
            {
                using (ChatContext context = new ChatContext())
                {
                    context.Database.CreateIfNotExists();
                }
                TcpListener listener = new TcpListener(IPAddress.Parse(address), port);
                listener.Start();
                ThreadPool.QueueUserWorkItem(o => ClientHandler(listener));
            }
            catch
            {
                dataError = true;
                return;
            }
        }

        private void ClientHandler(TcpListener listener)
        {
            try
            {
                while (true)
                {
                    TcpClient client = listener.AcceptTcpClient();
                    ThreadPool.QueueUserWorkItem(o =>
                    {
                        lock (locker)
                        {
                            userManager = new UserManager(client, this);
                            if (activeUser != null && (userManager.LogInSuccceed || userManager.SingUpSucceed))
                            {
                                activeUser(this, userManager.GetStatusUserEventArgs);
                                ThreadPool.QueueUserWorkItem(s =>
                                {
                                    userManager.KeepListening();
                                });
                            }
                            Monitor.PulseAll(locker);
                        }
                    });
                }
            }
            finally
            {
                listener.Stop();
            }
        }

        public void UpdateUserStatus(object o, AcceptDisconnectedUserEventArgs e)
        {
            if (activeUser != null)
            {
                activeUser(o, e.GetStatusUserEventArgs);
            }
        }

        public IEnumerable<MsgUser> SearchMesseges(string txtMessege)
        {
            IEnumerable<MsgUser> result;
            using (ChatContext context = new ChatContext())
            {
                result = context.UserMesseges.Where(m => m.TxtMessege == txtMessege).ToList();
            }
            return result;
        }

        public IEnumerable<MsgUser> SearchMesseges(DateTime dtMessege)
        {
            IEnumerable<MsgUser> result;
            using (ChatContext context = new ChatContext())
            {
                result = context.UserMesseges.Where(m => m.DtMessege.Year == dtMessege.Year && m.DtMessege.Month==dtMessege.Month && m.DtMessege.Day==dtMessege.Day).Select(m => m).ToList();
            }
            return result;
        }

        public User SearchUser(int userId)
        {
            using (ChatContext context = new ChatContext())
            {
                return context.Users.FirstOrDefault(u => u.UserID == userId);
            }
        }

        public User SearchUser(string userName)
        {
            using (ChatContext context = new ChatContext())
            {
                return context.Users.FirstOrDefault(u => u.UserName == userName);
            }
        }

        public void RemoveUser(User userToRemove)
        {
            using (ChatContext context = new ChatContext())
            {
                context.Users.Attach(userToRemove);
                context.UserMesseges.RemoveRange(from m in context.UserMesseges
                                                 where m.Sender.UserID == userToRemove.UserID
                                                 select m);
                context.Users.Remove(userToRemove);
                context.SaveChanges();
            }
        }
    }
}
