using Domain;
using Domain.Entities;
using System;

namespace Infrastructure.Data;

public class ClientRepository : EfRepository<Client>, IClientRepository
{
    public ClientRepository(ApplicationContext context) : base(context)
    {
    }
}


