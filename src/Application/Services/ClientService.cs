using Application.Interfaces;
using Application.Models;
using Domain.Entities;
using Domain.Interfaces;
using System.Collections.Generic;

namespace Application.Services
{
    public class ClientService : IClientService
    {
        private readonly IClientRepository _clientRepository;

        public ClientService(IClientRepository clientRepository)
        {
            _clientRepository = clientRepository;
        }

        public List<ClientDTO> GetClients()
        {
            var clients = _clientRepository.GetAll();
            return ClientDTO.CreateList(clients);
        }

        public ClientDTO GetClientById(int id)
        {
            var client = _clientRepository.GetById(id);
            if (client == null)
            {
                return null;
            }
            return ClientDTO.Create(client);
        }

        public void AddClient(Client client)
        {
            _clientRepository.Add(client);
        }

        public void UpdateClient(Client client)
        {
            _clientRepository.Update(client);
        }

        public void DeleteClient(int id)
        {
            var client = _clientRepository.GetById(id);
            if (client != null)
            {
                _clientRepository.Delete(client);
            }
        }

        public void UpdateClient(int id, Client client)
        {
            throw new NotImplementedException();
        }
    }
}
