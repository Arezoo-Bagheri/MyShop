using MyShop.Models.Entities;
using System.Collections.Generic;

namespace MyShop.Models
{
    public class DetailsViewModel
    {
        public Product Product { get; set; }

        public List<Category> Category { get; set; }
    }
}
