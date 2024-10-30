using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Infrastructure.Data
{
    public class ApplicationContext : DbContext
    {
        public DbSet<User>Users { get; set; }
        public DbSet<SysAdmin> SysAdmins { get; set; }
        public DbSet<Admin> Admins { get; set; }
        public DbSet<Transaction> Transactions { get; set; }
        public DbSet<TransactionDetail> TransactionDetails { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Item> Items { get; set; }

        public ApplicationContext(DbContextOptions<ApplicationContext>options): base (options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder){
            modelBuilder.Entity<User>()
                .HasDiscriminator<string>("UserType")
                .HasValue<Client>("Client")
                .HasValue<Admin>("Admin")
                .HasValue<SysAdmin>("SysAdmin");
        }


    }

}
