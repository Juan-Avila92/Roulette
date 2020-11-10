using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Roulette.Models;

namespace Roulette.Services
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
        public static int FindOpenRouletteId(RouletteDbContext context)
        {
            try {
                return context.Roulettes.ToList<Roulette>().Find(x => x.IsOpen == true).Id;
            } 
            catch(Exception e) {
                return 0;
            }
        }

        public static Roulette PlayRoulette(Roulette roulette)
        {
            if(IsRouletteOpen(roulette))
            {
                Random random = new Random();
                roulette.BetResult = random.Next(0, 36);
                return roulette;
            }
            return roulette;
        }

        public static bool IsRouletteOpen(Roulette roulette)
        {
            if(roulette.IsOpen) {
                return true;
            }
            return false;
        }

    }
}
