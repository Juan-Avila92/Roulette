using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Roulette.Models;

namespace Roulette.RouletteBusiness
{
    public static class RouletteBusiness
    {
        public static Roulette GetRouletteById(RouletteDbContext context, int id)
        {
            return context.Roulettes.FirstOrDefault(roulette => roulette.Id == id);
        }
        public static NoContentResult UpdateRouletteStateIfExists(RouletteDbContext context, Roulette rouletteToBeUpdated)
        {
            if(rouletteToBeUpdated != null) {
                rouletteToBeUpdated.IsOpen = true;
                context.Roulettes.Update(rouletteToBeUpdated);
                context.SaveChanges();
                return new NoContentResult();
            }
            return null;
        }
    }
}
