using Domain;
using Domain.Entities;
using System;

namespace Infrastructure.Data;

public class ItemRepository : EfRepository<Item>, IItemRepository
{
    public ItemRepository(ApplicationContext context) : base(context)
    {
    }
}

