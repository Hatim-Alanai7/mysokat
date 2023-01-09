using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Common_Classes;

namespace Server.BL
{
    public class StatusUserEventArgs : EventArgs
    {
        User user;

        public StatusUserEventArgs(User user)
        {
            this.user = user;
        }

        public User GetUser { get { return user; } }
        
    }
}
