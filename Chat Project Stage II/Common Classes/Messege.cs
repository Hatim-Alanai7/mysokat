
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
    public class Messege
    {
        protected User sender;
        DateTime dtMessege;

        public Messege()
        {
            this.dtMessege = DateTime.Now;
        }

        [Key]
        public int MessegeID { get; set; }

        public DateTime DtMessege { get { return dtMessege; } set { dtMessege = value; } }
    }
}
