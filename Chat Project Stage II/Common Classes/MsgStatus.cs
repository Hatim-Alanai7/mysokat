using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common_Classes
{
    [Serializable]
    public class MsgStatus : Messege
    {
        Status statusUserForMessege;

        public MsgStatus(User sender, Status statusUserForMessege)
        { 
            this.statusUserForMessege = statusUserForMessege;
            this.sender = sender;
        }

        public string TxtMsgStatus
        {
            get
            {
                return string.Format("{0} || {1} is {2}.", DtMessege, this.sender.UserName, statusUserForMessege);
            }
        }

        public User GetSender { get { return this.sender; } set { this.sender = value; } }
        public Status GetStatusUserInMessege { get { return statusUserForMessege; } }

    }
}
