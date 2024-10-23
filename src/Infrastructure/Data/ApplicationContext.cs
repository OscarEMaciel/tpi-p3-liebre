using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace Infrastructure.Data
{
    public class ApplicationContext : DbContext
    {
        public DbSet<User>Users { get; set; }
        public DbSet<SysAdmin> SysAdmins { get; set; }
        public DbSet<Admin> Admin { get; set; }
        public DbSet<Transaction> Transaction { get; set; }
        
        public ApplicationContext(DbContextOptions<ApplicationContext>options): base (options) { }


    }

   


}
