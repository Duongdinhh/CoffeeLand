using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoffeeLand.Models.ViewModels
{
    public class CoffeeListViewModel
    {
        public IEnumerable<Coffee> Coffees { get; set; }
        public PagingInfo PagingInfo { get; set; }
        public string CurrentGenre { get; set; }
    }
}
