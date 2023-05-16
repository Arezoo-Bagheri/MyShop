using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MyShop.Data;
using MyShop.Models.Entities;
using System.IO;
using System.Linq;

namespace MyShop.Pages.Admin
{
    public class DeleteModel : PageModel
    {
        private readonly MyEshopContext _context;

        public DeleteModel(MyEshopContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Product Product { get; set; }
        public void OnGet(int id)
        {
            Product = _context.Products.FirstOrDefault(p => p.Id == id);
        }

        public IActionResult OnPost()
        {
            var product = _context.Products.Find(Product.Id);
            var item = _context.Items.First(p => p.Id == product.ItemId);
            _context.Items.Remove(item);
            _context.Products.Remove(product);

            _context.SaveChanges();
            string filePath = Path.Combine(Directory.GetCurrentDirectory(),
                "wwwroot",
                "images",
                product.Id + "jpg");

            if (System.IO.File.Exists(filePath))
                System.IO.File.Delete(filePath);

            return RedirectToPage("Index");
        }
    }
}
