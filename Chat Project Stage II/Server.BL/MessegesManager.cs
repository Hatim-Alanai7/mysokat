using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common_Classes;
using System.Runtime.Serialization.Formatters.Binary;
using System.Threading;
using Server.DAL;

namespace Server.BL
{
    public class MessegesManager:IDisposable
    {
        UserManager userManager;
        StatusUserEventArgs statusUser;
        BinaryFormatter bf = new BinaryFormatter();
        ChatContext context;
        object locker = "nothing";

        public StatusUserEventArgs GetStatusUserEventArgs { get { return statusUser; } }

        public MessegesManager()
        {
            this.context = new ChatContext();
        }

        internal MessegesManager(UserManager userManager, Messege newMsg, ChatContext context)
        {
            this.context = context;
            this.userManager = userManager;
            if (newMsg is MsgUser)
            {
                DistributionUserMessege((MsgUser)newMsg);
                AddUserMessegeToDb((MsgUser)newMsg);
            }
            else
                if (((MsgStatus)newMsg).GetStatusUserInMessege == Status.disconnected)
                {
                    DistributionStatusMessege(newMsg);
                    UpdateUserStatusAndLastSeenInDb((MsgStatus)newMsg);
                    userManager.GetUser
                        .UserStatus = Status.disconnected;
                    statusUser = new StatusUserEventArgs(userManager.GetUser);
                }
                else
                {
                    DistributionStatusMessege(newMsg);
                    if(((MsgStatus)newMsg).GetSender.GetOperation!=Operation.SingUp)
                    UpdateUserStatusAndLastSeenInDb((MsgStatus)newMsg);
                }
        }

        private void DistributionStatusMessege(Messege newMsg)
        {
            for (int i = 0; i < userManager.GetActiveUsers.Count(); i++)
            {
                try
                {
                    bf.Serialize(userManager.GetActiveUsers.ElementAt(i).GetTcpStream, (MsgStatus)newMsg);
                }
                catch { return; }
            }
        }

        private void DistributionUserMessege(MsgUser newMsg)
        {
            for (int i = 0; i < userManager.GetActiveUsers.Count(); i++)
            {
                bf.Serialize(userManager.GetActiveUsers.ElementAt(i).GetTcpStream, newMsg);
            }
        }

        public void UpdateUserStatusAndLastSeenInDb(MsgStatus newMessegeStatus)
        {
            if(newMessegeStatus!=null)
            {
                newMessegeStatus.GetSender = context.Users.FirstOrDefault(u => u.UserName == newMessegeStatus.GetSender.UserName);
                if(newMessegeStatus.GetSender!=null)
                {
                    newMessegeStatus.GetSender.UserStatus = newMessegeStatus.GetSender.UserStatus == Status.connected ? Status.disconnected : Status.connected;
                    newMessegeStatus.GetSender.LastSeen = DateTime.Now;
                    context.SaveChanges();
                }
                if (newMessegeStatus.GetSender.UserStatus == Status.disconnected) this.Dispose();
            }
        }

        private void AddUserMessegeToDb(MsgUser newMsg)
        {
            if (newMsg != null)
            {
                newMsg.Sender = context.Users.FirstOrDefault(u=>u.UserName==newMsg.Sender.UserName);
                if (newMsg.Sender != null)
                {
                    context.UserMesseges.Attach(newMsg);
                    context.UserMesseges.Add(newMsg);
                    context.SaveChanges();
                }
            }
        }

        public void Dispose()
        {
            this.context.Dispose();
            this.userManager.GetTcpStream.Dispose();
        }
    }
}
