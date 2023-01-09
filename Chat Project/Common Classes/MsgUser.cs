using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common_Classes
{
    [Serializable]
    public class MsgUser : Messege
    {
        string txtMessege;

        public MsgUser(User sender) : base(sender) { }

        public string TxtMessege { set { this.txtMessege = value; } get { return string.Format(base.Sender.Name + " said:  " + txtMessege+"\n"); } }
    }
}
