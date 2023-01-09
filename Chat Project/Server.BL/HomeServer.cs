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

namespace Server.BL
{
    public class HomeServer
    {
        public event EventHandler<StatusUserEventArgs> activeUser;
        BinaryFormatter bf = new BinaryFormatter();
        UserManager userManager;
        bool dataError = false;
        object locker = "nothing";

        public HomeServer(string address, int port)
        {
            try
            {
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
                            if (activeUser != null)
                            {
                                activeUser(this, userManager.GetStatusUserEventArgs);
                            }
                            ThreadPool.QueueUserWorkItem(s =>
                            {
                                userManager.KeepListening();
                            });
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

        public UserManager GetUserManager { get { return userManager; } }
        public bool DataError { get { return dataError; } }

        public void UpdateUserStatus(object o, AcceptDisconnectedUserEventArgs e)
        {
            if (activeUser != null)
            {
                activeUser(o, e.GetStatusUserEventArgs);
            }
        }

    }
}
