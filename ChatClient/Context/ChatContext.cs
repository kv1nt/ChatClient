using ChatClient.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChatClient.Context
{
    public class ChatContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Message> Messages { get; set; }

        public ChatContext(DbContextOptions<ChatContext> options)
            : base(options)
        {
            //Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
