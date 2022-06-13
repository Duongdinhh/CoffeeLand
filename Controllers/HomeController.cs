using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using CoffeeLand.Models;
using CoffeeLand.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace CoffeeLand.Controllers
{
    public class HomeController : Controller
    {
        private ICoffeeLandRepository repository;
        public int PageSize = 3;

        public HomeController(ICoffeeLandRepository repo)
        {
            repository = repo;
        }

        public IActionResult Index(string genre, int coffeePage = 1)
            => View(new CoffeeListViewModel
            {
                Coffees = repository.Coffees
                    .Where(p => genre == null || p.Genre == genre)
                    .OrderBy(p => p.CoffeeID)
                    .Skip((coffeePage - 1) * PageSize)
                    .Take(PageSize),
                PagingInfo = new PagingInfo
                {
                    CurrentPage = coffeePage,
                    ItemsPerPage = PageSize,
                    TotalItems = genre == null ?
                    repository.Coffees.Count() :
                    repository.Coffees.Where(e =>
                    e.Genre == genre).Count()
                },
                CurrentGenre = genre
            });

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
