using AutoMapper;
using DaDoIS.Data;
using DaDoIS.Data.Entities;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;

namespace DaDoIS.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CitiesController(AppDbContext db, IMapper mapper, IValidator<CreateCityDto> validator) : Controller
    {
        [HttpGet]
        public IActionResult GetAllCities()
        {
            return Ok(db.Cities.Select(c => mapper.Map<CityDto>(c)));
        }

        [HttpGet("{id:int}")]
        public IActionResult GetCityById(int id)
        {
            if (!db.Cities.Any(c => c.Id == id)) return NotFound();
            return Ok(mapper.Map<CityDto>(db.Cities.Find(id)));
        }

        [HttpPost]
        public async Task<IActionResult> CreateCity([FromBody] CreateCityDto cityDto)
        {
            var result = await validator.ValidateAsync(cityDto);
            if (result.IsValid)
            {
                var city = db.Cities.Add(mapper.Map<City>(cityDto));
                db.SaveChanges();
                return Ok(city);
            };
            return BadRequest(result.Errors);
        }

        [HttpDelete("{id:int}")]
        public IActionResult DeleteCity(int id)
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