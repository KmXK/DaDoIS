using AutoMapper;
using DaDoIS.Data;
using DaDoIS.Data.Entities;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DaDoIS.Api.Controllers
{
    /// <summary>
    /// Контролер для клиентов
    /// </summary>
    /// <param name="db"></param>
    /// <param name="mapper"></param>
    /// <param name="validator"></param>
    [ApiController]
    [Route("api/[controller]")]
    public class ClientsController(AppDbContext db, IMapper mapper, IValidator<CreateClientDto> validator) : Controller
    {
        /// <summary>
        /// Метод для получения всех клиентов
        /// </summary>
        /// <returns>Список клиентов</returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ClientDto>>> GetAllClients()
        {
            var clients = await db.Clients
                .Include(x => x.Citizenship)
                .Include(x => x.LivingCity)
                .Include(x => x.RegistrationCity)
                .ToListAsync();
            
            return Ok(mapper.Map<List<ClientDto>>(clients));
        }

        /// <summary>
        /// Метод для получения клиента по идентификатору
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Клиент</returns>
        [HttpGet("{id:guid}")]
        public async Task<ActionResult<ClientDto>> GetClientById(Guid id)
        {
            var client = await db.Clients
                .Include(x => x.Citizenship)
                .Include(x => x.LivingCity)
                .Include(x => x.RegistrationCity)
                .FirstOrDefaultAsync(x => x.Id == id);

            if (client == null) return NotFound();
            
            return Ok(mapper.Map<ClientDto>(client));
        }

        /// <summary>
        /// Метод для создания клиента
        /// </summary>
        /// <param name="clientDto"></param>
        /// <returns>Новый клиент</returns>
        [HttpPost]
        public async Task<ActionResult<ClientDto>> CreateClient([FromBody] CreateClientDto clientDto)
        {
            var result = await validator.ValidateAsync(clientDto);
            if (result.IsValid)
                return BadRequest(result.Errors);
            var client = db.Clients.Add(mapper.Map<Client>(clientDto));
            db.SaveChanges();
            return Ok(client.Entity);
        }

        /// <summary>
        /// Метод для обновления клиента
        /// </summary>
        /// <param name="clientDto"></param>
        /// <returns></returns>
        [HttpPut]
        public async Task<ActionResult> UpdateClient([FromBody] ClientDto clientDto)
        {
            var id = clientDto.Id;
            if (db.Clients.Find(id) != null)
            {
                var createClientDto = mapper.Map<CreateClientDto>(clientDto);
                var validationResult = await validator.ValidateAsync(createClientDto);
                if (!validationResult.IsValid)
                    return BadRequest(validationResult.Errors);

                var client = db.Clients.Update(mapper.Map<Client>(clientDto));
                db.SaveChanges();
                return Ok(mapper.Map<ClientDto>(client.Entity));
            }
            return NotFound();
        }

        /// <summary>
        /// Метод для удаления клиента
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id:guid}")]
        public ActionResult DeleteClient(Guid id)
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
