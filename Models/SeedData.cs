using System.Linq;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
namespace CoffeeLand.Models
{
    public static class SeedData
    {
        public static void EnsurePopulated(IApplicationBuilder app)
        {
            CoffeeLandDbContext context =
           app.ApplicationServices.CreateScope().ServiceProvider.GetRequiredService <CoffeeLandDbContext> ();
            if (context.Database.GetPendingMigrations().Any())
            {
                context.Database.Migrate();
            }
            if (!context.Coffees.Any())
            {
                context.Coffees.AddRange(
                new Coffee
                {
                    Title = "Ca Cao Nóng ",
                    Size = "M, L, XL ",
                    Genre = "Coffee",
                    Price = 20m
                },
                new Coffee
                {
                    Title = "Capuchino",
                    Size = "M, L, XL",
                    Genre = "Coffee",
                    Price = 12m
                },
                new Coffee
                {
                    Title = "Chè Hạt Sen",
                    Size = "M, L, XL ",
                    Genre = "Chè",
                    Price = 5m
                },
                new Coffee
                {
                    Title = "Trà Sữa Trân Châu Đường Đen ",
                    Size = ":M, L, XL ",
                    Genre = "Trà",
                    Price = 3m
                },
                new Coffee
                {
                    Title = "Bánh Phô mai Cà Phê",
                    Size = "M, L, XL ",
                    Genre = "Bánh",
                    Price = 10m
                }
                );
                context.SaveChanges();
            }
        }
    }
}