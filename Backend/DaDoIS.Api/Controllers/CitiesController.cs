using System.Data.Common;
using AutoMapper;
using DaDoIS.Data;
using DaDoIS.Data.Entities;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;

namespace DaDoIS.Api.Controllers
{
    /// <summary>
    /// Контролер для городов
    /// </summary>
    /// <param name="db"></param>
    /// <param name="mapper"></param>
    /// <param name="validator"></param>
    [ApiController]
    [Route("api/[controller]")]
    public class CitiesController(AppDbContext db, IMapper mapper, IValidator<CreateCityDto> validator) : Controller
    {
        /// <summary>
        /// Метод для получения всех городов
        /// </summary>
        /// <returns>Список городов</returns>
        [HttpGet]
        public ActionResult<IEnumerable<CityDto>> GetAllCities()
        {
            return Ok(db.Cities.Select(c => mapper.Map<CityDto>(c)));
        }

        /// <summary>
        /// Метод для получения города по идентификатору
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Город</returns>
        [HttpGet("{id:int}")]
        public ActionResult<CityDto> GetCityById(int id)
        {
            if (!db.Cities.Any(c => c.Id == id)) return NotFound();
            return Ok(mapper.Map<CityDto>(db.Cities.Find(id)));
        }

        /// <summary>
        /// Метод для создания города
        /// </summary>
        /// <param name="cityDto"></param>
        /// <returns>Новый город</returns>
        [HttpPost]
        public async Task<ActionResult<CityDto>> CreateCity([FromBody] CreateCityDto cityDto)
        {
            var result = await validator.ValidateAsync(cityDto);
            if (!result.IsValid)
                return BadRequest(result.Errors);
            var city = db.Cities.Add(mapper.Map<City>(cityDto));
            db.SaveChanges();
            return Ok(mapper.Map<CityDto>(city.Entity));
        }

        /// <summary>
        /// Метод для удаления города
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id:int}")]
        public ActionResult DeleteCity(int id)
        {
            var city = db.Cities.Find(id);
            if (city != null)
            {
                db.Cities.Remove(city);
                db.SaveChanges();
                return Ok();
            }
            return NotFound();
        }
    }
}