using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Roulette.Models;

namespace Roulette.Controllers
{
    public class UserController
    {
        private readonly RouletteDbContext contextDb;

        public UserController(RouletteDbContext context)
        {
            contextDb = context;
        }

        [HttpGet]
        [Route("game/roulettes")]
        public List<Roulette> Get()
        {
            return contextDb.Roulettes.ToList();
        }
    }
}
