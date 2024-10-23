using Domain;
using Domain.Entities;

namespace Infrastructure.Data;

public class AdminRepository : EfRepository<Admin>, IAdminRepository
{
    public AdminRepository(ApplicationContext context) : base(context)
    {
    }
}