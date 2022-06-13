using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using CoffeeLand.MyTagHelper;
using CoffeeLand.Models;
using System.Linq;
namespace CoffeeLand.Pages
{
    public class MyCartModel : PageModel
    {
        private ICoffeeLandRepository repository;
        public MyCartModel(ICoffeeLandRepository repo, MyCart myCartService)
        {
            repository = repo;
            myCart = myCartService;
        }
        public MyCart myCart { get; set; }
        public string ReturnUrl { get; set; }
        public void OnGet(string returnUrl)
        {
            ReturnUrl = returnUrl ?? "/";
        }
        public IActionResult OnPost(long coffeeId, string returnUrl)
        {
            Coffee coffee = repository.Coffees
            .FirstOrDefault(b => b.CoffeeID == coffeeId);
            myCart.AddItem(coffee, 1);
            return RedirectToPage(new { returnUrl = returnUrl });
        }
        public IActionResult OnPostRemove(long coffeeId, string returnUrl)
        {
            myCart.RemoveLine(myCart.Lines.First(cl =>
            cl.Coffee.CoffeeID == coffeeId).Coffee);
            return RedirectToPage(new { returnUrl = returnUrl });
        }
    }
}