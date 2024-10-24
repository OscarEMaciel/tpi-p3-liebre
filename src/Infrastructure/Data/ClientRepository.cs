using Domain.Entities;
using Domain.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace Infrastructure.Data
{
    public class ClientRepository : BaseRepository<Client>, IClientRepository
    {
        private readonly List<Client> _clients = new List<Client>(); // Simulamos una base de datos en memoria por ahora

        public override Client Add(Client entity)
        {
            _clients.Add(entity);
            return entity;
        }

        public override List<Client> GetAll()
        {
            return _clients;
        }

        public override Client GetById<TId>(TId id)
        {
            return _clients.FirstOrDefault(c => c.Id.Equals(id));
        }

        public override void Delete(Client entity)
        {
            _clients.Remove(entity);
        }

        public override Client Update(Client entity)
        {
            var client = _clients.FirstOrDefault(c => c.Id == entity.Id);
            if (client != null)
            {
                client.Name = entity.Name;
                client.Transactions = entity.Transactions;
            }
            return client;
        }
    }
}

