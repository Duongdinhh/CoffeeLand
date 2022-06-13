using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CoffeeLand.Models
{
    public class Coffee
    {
        [Key]

        public long CoffeeID { get; set; }
        [Required(ErrorMessage = "Please enter a title")]
        [Display(Name = "Tên Hải Sản")]
        public string Title { get; set; }
        [Required(ErrorMessage = "Please enter a Size")]
        [Display(Name = "Kích cở ly")]
        public string Size { get; set; }
        [Required(ErrorMessage = "Please specify a genre")]
        [Display(Name = "Loại thức uống")]
        public string Genre { get; set; }
        [Required]
        [Range(0.01, double.MaxValue,
        ErrorMessage = "Please enter a positive price")]
        [Display(Name = "Giá")]
        [Column(TypeName = "decimal(8, 2)")]
        public decimal Price { get; set; }
        
    }
}
