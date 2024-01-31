using AutoMapper;
using DaDoIS.Data;
using DaDoIS.Data.Entities;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;

namespace DaDoIS.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ClientsController(AppDbContext db, IMapper mapper, IValidator<CreateClientDto> validator) : Controller
    {
        [HttpGet]
        public IActionResult GetAllClients()
        {
            return Ok(db.Clients.Select(c => mapper.Map<ClientDto>(c)));
        }

        [HttpGet("{id:guid}")]
        public IActionResult GetClientById(Guid id)
        {
            if (!db.Clients.Any(c => c.Id == id)) return NotFound();
            return Ok(mapper.Map<ClientDto>(db.Clients.Find(id)));
        }

        [HttpPost]
        public async Task<IActionResult> CreateClient([FromBody] CreateClientDto clientDto)
        {
            var result = await validator.ValidateAsync(clientDto);
            if (result.IsValid)
            {
                var client = db.Clients.Add(mapper.Map<Client>(clientDto));
                db.SaveChanges();
                return Ok(client);
            };
            return BadRequest(result.Errors);
        }

        [HttpDelete("{id:guid}")]
        public IActionResult DeleteClient(Guid id)
        {
            var client = db.Clients.Find(id);
            if (client != null)
            {
                db.Clients.Remove(client);
                db.SaveChanges();
                return Ok();
            }
            return NotFound();
        }
    }
}