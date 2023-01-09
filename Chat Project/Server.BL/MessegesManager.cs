using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common_Classes;
using System.Runtime.Serialization.Formatters.Binary;
using System.Threading;

namespace Server.BL
{
    class MessegesManager
    {
        UserManager userManager;
        StatusUserEventArgs statusUser;
        BinaryFormatter bf = new BinaryFormatter();
        object locker = "nothing";

        internal MessegesManager(UserManager userManager, Messege newMsg)
        {
            this.userManager = userManager;
            if (newMsg is MsgUser)
            {
                DistributionUserMessege(newMsg);
            }
            else
                if (((MsgStatus)newMsg).GetStatusUserInMessege == Status.disconnected)
                {
                    DistributionStatusMessege(newMsg);
                    userManager.GetUser.UserStatus = Status.disconnected;
                    statusUser = new StatusUserEventArgs(userManager.GetUser);
                }
                else
                    DistributionStatusMessege(newMsg);
        }

        public StatusUserEventArgs GetStatusUserEventArgs { get { return statusUser; } }

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
        private void DistributionUserMessege(Messege newMsg)
        {
            for (int i = 0; i < userManager.GetActiveUsers.Count(); i++)
            {
                bf.Serialize(userManager.GetActiveUsers.ElementAt(i).GetTcpStream, (MsgUser)newMsg);
            }
        }
    }
}
