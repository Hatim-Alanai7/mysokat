using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Common_Classes
{
    public enum Operation { SingUp, LogIn };

    public enum Status { connected, disconnected };

    [Serializable]
    public class User
    {
        string userName;
        Color textColor;
        Status userStatus;
        DateTime lastSeen;
        Operation operation;

        public User()
        {  }

        public User(string name, Color textColor, Operation operation)
        {
            this.userName = name;
            this.textColor = textColor;
            this.UserStatus = Status.connected;
            this.lastSeen = DateTime.Now;
            this.operation = operation;
            this.Messeges = new HashSet<MsgUser>();
        }
        
        public int UserID { get; set; }

        [Index(IsUnique = true)]
        [StringLength(450)]
        public string UserName { get{ return this.userName; } set { this.userName = value; } }

        public Color TextColor { get { return this.textColor; } }

        public DateTime LastSeen { get; set; }

        public Operation GetOperation { get { return operation; } }

        public Status UserStatus
        {
            set
            {
                if (value == Status.connected)
                {
                    userStatus = value;
                    LastSeen = DateTime.Now;
                }
                else
                    userStatus = value;
            }
            get { return userStatus; }
        }

        public virtual ICollection<MsgUser> Messeges { get; set; }

        public override string ToString()
        {
            return string.Format("ID: {0} || UserName: {1} || User Status: {2}", UserID, UserName, UserStatus);
        }
    }
}
