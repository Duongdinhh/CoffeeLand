using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoffeeLand.Models
{
    public interface ICoffeeLandRepository
    {
        IQueryable<Coffee> Coffees { get; }
        void SaveBook(Coffee b);
        void CreateBook(Coffee b);
        void DeleteBook(Coffee b);
    }
}
