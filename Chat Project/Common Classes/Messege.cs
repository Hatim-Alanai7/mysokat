using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common_Classes
{
    [Serializable]
    public class Messege
    {
        User sender;
        DateTime dtMessege;

        public Messege(User sender)
        {
            this.sender = sender;
            this.dtMessege = DateTime.Now;
        }

        public User Sender { get { return sender; } }
        public DateTime DtMessege { get { return dtMessege; } }
    }
}
