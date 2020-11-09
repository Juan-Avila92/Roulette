using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Roulette.Models;

namespace Roulette.Controllers
{
    [ApiController]
    [Route("api/roulettes")]
    public class RouletteController : ControllerBase
    {
        private readonly RouletteDbContext _context;

        public RouletteController(RouletteDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public List<Roulette> Get()
        {
            return _context.Roulettes.ToList();
        }

        [HttpPost]
        public IActionResult PostRoulette([FromBody] Roulette roulette)
        {
            if (!this.ModelState.IsValid)
            {
                return BadRequest();
            }
            this._context.Roulettes.Add(roulette);
            this._context.SaveChanges();
            return Created($"roulettes/{roulette.Id}", roulette);
        }
    }
}