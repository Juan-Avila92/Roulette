using Microsoft.AspNetCore.Mvc;
using Roulette.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Roulette.Services
{
    public static class UserBusiness
    {
        public static bool CanCreateAnUser(int IdRoulette)
        {
            if(IdRoulette != 0)
            {
                return true;
            }
            return false;
        }

        public static bool CanBet(User user)
        {
            if(double.Parse(user.Bet) <= double.Parse(user.Credit)) {
                return true;
            }
            return false;
        }

        public static bool IsNumberWithinRange(User user)
        {
            if(user.RouletteNumber >= 0 && user.RouletteNumber <= 36)
            {
                return true;
            }
            return false;
        }

        public static User FindUserByRouletteId(RouletteDbContext context, int id)
        {
            try {
                return context.Users.Where(user => user.IdRoulette == id).FirstOrDefault();
            }
            catch (Exception e) {
                return null;
            }
        }
    }
}
