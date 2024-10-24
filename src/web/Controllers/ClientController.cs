using Application.Interfaces;
using Application.Models.Request;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientController : ControllerBase
    {
        private readonly IClientService _clientService;

        public ClientController(IClientService clientService)
        {
            _clientService = clientService;
        }

        [HttpGet("[action]")]
        public IActionResult GetAll()
        {
            var clients = _clientService.GetClients();
            return Ok(clients);
        }

        [HttpGet("[action]/{id}")]
        public IActionResult GetClientById(int id)
        {
            var client = _clientService.GetClientById(id);
            if (client == null)
            {
                return NotFound();
            }
            return Ok(client);
        }

        [HttpPost("[action]")]
        public IActionResult AddClient([FromBody] Client client)
        {
            _clientService.AddClient(client);
            return Ok();
        }

        [HttpPut("[action]/{id}")]
        public IActionResult UpdateClient(int id, [FromBody] ClientUpdateRequest request)
        {
            var existingClient = _clientService.GetClientById(id);
            if (existingClient == null)
            {
                return NotFound();
            }

            existingClient.Username = request.Username;
            existingClient.Name = request.Name;
            existingClient.LastName = request.LastName;
            existingClient.Email = request.Email;

            _clientService.UpdateClient(existingClient);
            return Ok();
        }

        [HttpDelete("[action]/{id}")]
        public IActionResult DeleteClient(int id)
        {
            var client = _clientService.GetClientById(id);
            if (client == null)
            {
                return NotFound();
            }

            _clientService.DeleteClient(id);
            return Ok();
        }
    }
}
