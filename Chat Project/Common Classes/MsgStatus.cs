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

        public MsgStatus(User sender, Status statusUserForMessege) : base(sender) { this.statusUserForMessege = statusUserForMessege; }

        public string TxtMsgStatus
        {
            get
            {
                return string.Format("{0} || {1} is {2}.", DtMessege, Sender.Name, statusUserForMessege);
            }
        }
        public Status GetStatusUserInMessege { get { return statusUserForMessege; } }
    }
}
