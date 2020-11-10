using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Roulette.Models
{
    public class User
    {
        public int Id { get; set; }
        public int IdRoulette { get; set; }
        public string Credit { get; set; }
        public string Bet { get; set; }
        public int RouletteNumber { get; set; }
        public int RouletteColor { get; set; }
    }
}
