using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Application.Models
{
    public class SysAdminDTO
    {
        public int Id { get; set; }
        public string Username { get; set; } 
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }

     
        public static SysAdminDTO Create(SysAdmin sysadmin)
        {
            return new SysAdminDTO
            {
                Id = sysadmin.Id,
                Username = sysadmin.Username,
                Name = sysadmin.Name,
                LastName = sysadmin.LastName,
                Email = sysadmin.Email,
            };
        }

        
        public static IEnumerable<SysAdminDTO> CreateList(IEnumerable<SysAdmin> sysAdmins)
        {
            return sysAdmins.Select(Create).ToList(); 
        }
    }
}
