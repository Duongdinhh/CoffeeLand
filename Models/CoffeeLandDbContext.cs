using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoffeeLand.Models
{
    public class CoffeeLandDbContext : DbContext
    {
        public CoffeeLandDbContext(DbContextOptions<CoffeeLandDbContext>
       options)
        : base(options) { }
        public DbSet<Coffee> Coffees { get; set; }
        public DbSet<Order> Orders { get; set; }
    }
}
