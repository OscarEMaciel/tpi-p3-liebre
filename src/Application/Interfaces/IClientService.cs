using Application.Models;
using Domain.Entities;
using System.Collections.Generic;

namespace Application.Interfaces
{
    public interface IClientService
    {
        public List<ClientDTO> GetClients();
        public ClientDTO GetClientById(int id);
        public void AddClient(Client client);
        public void UpdateClient(int id, Client client);
        public void DeleteClient(int id);
    }
}


