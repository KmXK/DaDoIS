using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using DaDoIS.Data;
using DaDoIS.Data.Entities;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;

namespace DaDoIS.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CitizenshipController(AppDbContext db, IMapper mapper, IValidator<CreateCitizenshipDto> validator) : ControllerBase
    {
        [HttpGet]
        public IActionResult GetAllCitizenship()
        {
            return Ok(db.Citizenship.Select(c => mapper.Map<CitizenshipDto>(c)));
        }

        [HttpGet("{id:int}")]
        public IActionResult GetCitizenshipById(int id)
        {
            if (!db.Citizenship.Any(c => c.Id == id)) return NotFound();
            return Ok(mapper.Map<CitizenshipDto>(db.Citizenship.Find(id)));
        }

        [HttpPost]
        public async Task<IActionResult> CreateCitizenship([FromBody] CreateCitizenshipDto citizenshipDto)
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

        [HttpDelete("{id:int}")]
        public IActionResult DeleteCitizenship(int id)
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