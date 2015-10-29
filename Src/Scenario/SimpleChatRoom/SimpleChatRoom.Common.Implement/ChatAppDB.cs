using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SimpleChatRoom.Common.Interface;
using SimpleChatRoom.Common.Interface.Entities;

namespace SimpleChatRoom.Common.Implement
{
    public partial class ChatAppDB : DbContext
    {
        public ChatAppDB()
            : base("name=ChatAppDB")
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //throw new UnintentionalCodeFirstException();
        }

        public virtual DbSet<Messages> Messages { get; set; }
        public virtual DbSet<Sessions> Sessions { get; set; }
        public virtual DbSet<Users> Users { get; set; }
    }

}
