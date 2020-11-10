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
            try {
                return contextDb.Roulettes.ToList();
            } catch(Exception e)
            {
                throw new ArgumentNullException("There are no roulettes in database");
            }
        }

        [HttpPost]
        [Route("game/roulette")]
        public IActionResult PostRoulette([FromBody] Roulette roulette)
        {
            roulette.IsOpen = false;
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
        public string OpenRoulette(int id)
        {
            Roulette rouletteToBeUpdated = Services.RouletteBusiness.GetRouletteById(contextDb, id);
            NoContentResult result = Services.RouletteBusiness.UpdateRouletteStateIfExists(contextDb, rouletteToBeUpdated);
            if (result != null) {
                return string.Format("Roulette with Id: {0} has been opened.", id);
            }
            else {
                return string.Format("There is no roulette with Id: {0} .", id); ;
            }
        }

        [HttpPut]
        [Route("game/openbet/roulette/{id}/play")]
        public string PlayRoulette(int id, [FromBody] Roulette roulette)
        {
            Roulette rouletteToPlayed = Services.RouletteBusiness.GetRouletteById(contextDb, id);
            Roulette playedRoulette = Services.RouletteBusiness.PlayRoulette(rouletteToPlayed);
            NoContentResult result = Services.RouletteBusiness.UpdateRouletteStateIfExists(contextDb, playedRoulette);
            if (result != null)
            {
                return string.Format("Roulette with Id: {0} has been played. Winner number is: {1}", playedRoulette.Id, playedRoulette.BetResult);
            }
            else
            {
                return string.Format("Roulette with Id: {0} is not opened .", id); ;
            }
        }
    }
}