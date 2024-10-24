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

        // Método para crear un solo SysAdminDTO desde un SysAdmin
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

        // Método para crear una lista de SysAdminDTO a partir de una colección de SysAdmin
        public static IEnumerable<SysAdminDTO> CreateList(IEnumerable<SysAdmin> sysAdmins)
        {
            return sysAdmins.Select(Create).ToList(); 
        }
    }
}
