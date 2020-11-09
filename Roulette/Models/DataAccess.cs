using Microsoft.EntityFrameworkCore;

namespace Roulette.Models{
    public class RouletteDbContext : DbContext{
    public RouletteDbContext(DbContextOptions<RouletteDbContext> data)
        :base (data){}
    public DbSet<Roulette> Roulettes{get; set;}
    }
}