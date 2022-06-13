using Microsoft.AspNetCore.Mvc;
using CoffeeLand.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoffeeLand.ViewComponents
{
    public class GenreNavigation : ViewComponent
    {
        private ICoffeeLandRepository repository;
        public GenreNavigation(ICoffeeLandRepository repo)
        {
            repository = repo;
        }
        public IViewComponentResult Invoke()
        {
            ViewBag.SelectedGenre = RouteData?.Values["genre"];
            return View(repository.Coffees
            .Select(x => x.Genre)
            .Distinct()
            .OrderBy(x => x));
        }
    }
}
