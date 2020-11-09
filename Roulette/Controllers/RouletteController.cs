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
    
    public class RouletteController : ControllerBase
    {
        private readonly RouletteDbContext contextDb;

        public RouletteController(RouletteDbContext context)
        {
            contextDb = context;
        }

        [HttpGet]
        [Route("game/roulettes")]
        public List<Roulette> Get()
        {
            return contextDb.Roulettes.ToList();
        }

        [HttpPost]
        [Route("game/roulette")]
        public IActionResult PostRoulette([FromBody] Roulette roulette)
        {
            if (!this.ModelState.IsValid)
            {
                return BadRequest();
            }
            this.contextDb.Roulettes.Add(roulette);
            this.contextDb.SaveChanges();
            return Created($"roulettes/{roulette.Id}", roulette);
        }

        [HttpPut]
        [Route("game/openbet/roulette/{id}")]
        public string PutAuthors(int id)
        {
            Roulette rouletteToBeUpdated = RouletteBusiness.RouletteBusiness.GetRouletteById(contextDb, id);
            NoContentResult result = RouletteBusiness.RouletteBusiness.UpdateRouletteStateIfExists(contextDb, rouletteToBeUpdated);
            if (result != null) {
                return string.Format("Roulette with Id: {0} has been opened.", id);
            }
            else {
                return string.Format("There is no roulette with Id: {0} .", id); ;
            }
        }
    }
}