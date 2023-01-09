using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Common_Classes
{
    public enum Status { connected, disconnected };

    [Serializable]
    public class User
    {
        static int idCounter = 0;
        int id;
        string name;
        Color textColor;
        Status userStatus;
        List<Messege> conversation = new List<Messege>();

        public User(string name, Color textColor)
        {
            this.id = idCounter;
            idCounter++;
            this.name = name;
            this.textColor = textColor;
            this.UserStatus = Status.connected;
        }

        public int Id { get { return this.id; } }
        public string Name { get { return this.name; } }
        public Color TextColor { get { return this.textColor; } }
        public Status UserStatus
        {
            set { userStatus = value; }
            get { return userStatus; }
        }

        public void AddMessegeConversation(Messege msg)
        {
            conversation.Add(msg);
        }

        public List<Messege> GetConversation { get { return conversation; } }
    }
}
