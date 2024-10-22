using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data
{
    public class UserRepository :BaseRepository<User>, IUserRepository
    {
        public UserRepository(ApplicationContext context) : base (context) { }

        public User? GetUserByUserName(string userName)
        {
            return _context.Users.SingleOrDefault(p => p.Username == userName);
        }
    }


}
