using AutoMapper;
using DaDoIS.Data;
using DaDoIS.Data.Entities;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;

namespace DaDoIS.Api.Controllers
{
    /// <summary>
    /// Контролер для гражданства
    /// </summary>
    /// <param name="db"></param>
    /// <param name="mapper"></param>
    /// <param name="validator"></param>
    [ApiController]
    [Route("api/[controller]")]
    public class CitizenshipController(AppDbContext db, IMapper mapper, IValidator<CreateCitizenshipDto> validator) : ControllerBase
    {
        /// <summary>
        /// Метод для получения всех гражданств
        /// </summary>
        /// <returns>Список гражданств</returns>
        [HttpGet]
        public ActionResult<IEnumerable<CitizenshipDto>> GetAllCitizenship()
        {
            return Ok(db.Citizenship.Select(c => mapper.Map<CitizenshipDto>(c)));
        }

        /// <summary>
        /// Метод для получения гражданства по идентификатору
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Гражданство</returns>
        [HttpGet("{id:int}")]
        public ActionResult<CitizenshipDto> GetCitizenshipById(int id)
        {
            if (!db.Citizenship.Any(c => c.Id == id)) return NotFound();
            return Ok(mapper.Map<CitizenshipDto>(db.Citizenship.Find(id)));
        }

        /// <summary>
        /// Метод для создания гражданства
        /// </summary>
        /// <param name="citizenshipDto"></param>
        /// <returns>Новое гражданство</returns>
        [HttpPost]
        public async Task<ActionResult<CitizenshipDto>> CreateCitizenship([FromBody] CreateCitizenshipDto citizenshipDto)
        {
            var result = await validator.ValidateAsync(citizenshipDto);
            if (result.IsValid)
            {
                var citizenship = db.Citizenship.Add(mapper.Map<Citizenship>(citizenshipDto));
                db.SaveChanges();
                return Ok(citizenship);
            };
            return BadRequest(result.Errors);
        }

        /// <summary>
        /// Метод для удаления гражданства
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id:int}")]
        public ActionResult DeleteCitizenship(int id)
        {
            var citizenship = db.Citizenship.Find(id);
            if (citizenship != null)
            {
                db.Citizenship.Remove(citizenship);
                db.SaveChanges();
                return Ok();
            }
            return NotFound();
        }
    }
}