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
    public class UserController : ControllerBase
    {
        private readonly RouletteDbContext contextDb;

        public UserController(RouletteDbContext context)
        {
            contextDb = context;
        }

        [HttpGet]
        [Route("game/users")]
        public List<User> Get()
        {
            try {
                return contextDb.Users.ToList();
            }
            catch (Exception e) {
                throw new ArgumentNullException("There are no users in database");
            }
        }

        [HttpPost]
        [Route("game/user")]
        public IActionResult Post([FromBody] User user)
        {
            int openRouleteId = Services.RouletteBusiness.FindOpenRouletteId(contextDb);
            bool createUser = Services.UserBusiness.CanCreateAnUser(openRouleteId);
            if(createUser)
            {
                if (!this.ModelState.IsValid) {
                    return BadRequest();
                }
                this.contextDb.Users.Add(user);
                this.contextDb.SaveChanges();
                return Created($"roulettes/{user.Id}", user);
            }
            return Created($"roulettes/{user.Id}", "There are no open roulettes to join");
        }


    }
}
