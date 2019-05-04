using HariFood.Models;
using Microsoft.EntityFrameworkCore;

namespace HariFood.Data
{
    public class HariFoodDbContext : DbContext
    {
        public HariFoodDbContext(DbContextOptions options)
            : base(options)
        {
            
        }
        public DbSet<Restaurant> Restaurants { get; set; }
    }
}