using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Server.BL
{
    public class AcceptDisconnectedUserEventArgs :EventArgs
    {
        StatusUserEventArgs statusUser;

        public AcceptDisconnectedUserEventArgs(StatusUserEventArgs statusUser)
        {
            this.statusUser = statusUser;
        }

        public StatusUserEventArgs GetStatusUserEventArgs { get { return statusUser; } }
    }
}
