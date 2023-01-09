using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common_Classes
{
    [Serializable]
    public class AcceptDisposeServer
    {
        private bool accept;
        public AcceptDisposeServer(bool accept)
        {
            this.accept = accept;
        }
        public bool Accept
        {
            get { return accept; }
            set { accept = value; }
        }

    }
}
