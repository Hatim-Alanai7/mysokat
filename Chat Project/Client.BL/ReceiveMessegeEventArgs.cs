using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Common_Classes;

namespace Client.BL
{
    public class ReceiveMessegeEventArgs : EventArgs
    {
        Messege msg;

        public ReceiveMessegeEventArgs(Messege msg)
        {
            this.msg = msg;
        }

        public Messege GetMessege { get { return this.msg; } }
    }
}
