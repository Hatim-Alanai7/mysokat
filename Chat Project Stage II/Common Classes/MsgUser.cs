using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Common_Classes
{
    [Serializable]
    public class MsgUser : Messege
    {
        string txtMessege;

        public MsgUser()
        {   }

        public MsgUser(User sender)
        {
            this.sender = sender;
        }

        public string TxtMessege { set { this.txtMessege = value; } get { return txtMessege; } }
        public virtual User Sender { get { return this.sender; } set { this.sender = value; } }
    }
}
