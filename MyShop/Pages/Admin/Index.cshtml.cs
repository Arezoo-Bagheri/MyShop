using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MyShop.Data;
using MyShop.Models.Entities;

namespace MyShop.Pages.Admin
{
    public class IndexModel : PageModel
    {
        private readonly MyEshopContext _context;

        public IndexModel(MyEshopContext context)
        {
            _context = context;
        }

        public IEnumerable<Product> Products { get; set; }

        public void OnGet()
        {
            Products = _context.Products.Include(p => p.Item);
        }

        public void OnPost()
        {
        }
    }
}
