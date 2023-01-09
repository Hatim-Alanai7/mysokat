using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace Common_Classes
{
    [NotMapped]
    [Serializable]
    public class ExistingAccountEventArgs : EventArgs
    {
        User user;
        bool errorExists;
        Operation operation;

        public ExistingAccountEventArgs(User user, bool isExists, Operation operation)
        {
            this.user = user;
            this.errorExists = isExists;
            this.operation = operation;
        }

        public ExistingAccountEventArgs(bool isExists, Operation operation)
        {
            this.ErrorExists = ErrorExists;
            this.operation = operation;
        }

        public User GetUser
        {
            get { return user; }
            set { user = value; }
        }

        public bool ErrorExists
        {
            get { return errorExists; }
            set { errorExists = value; }
        }

        public Operation GetOperation { get { return operation; } set { this.operation = value; } }

    }
}
