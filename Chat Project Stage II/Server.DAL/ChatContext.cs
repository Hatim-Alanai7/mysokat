using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using Common_Classes;

namespace Server.DAL
{
    public class ChatContext : DbContext
    {
        public DbSet<User> Users { set; get; }
        public DbSet<MsgUser> UserMesseges { set; get; }

        public ChatContext() 
            : base("name=ChatCn") { }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MsgUser>().ToTable("UserMesseges");
            modelBuilder.Entity<User>().ToTable("Users");
        }
    }
}
