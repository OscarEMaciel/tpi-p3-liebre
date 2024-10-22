using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain;
using Domain.Entities;
using Domain.Interfaces;

namespace Infrastructure.Data
{
    public class SysAdminRepository : EfRepository<SysAdmin>, ISysAdminRepository
    {
        public SysAdminRepository(ApplicationContext context) : base(context)
        {
        }
    }
}

   
