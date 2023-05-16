using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyShop.Data;
using System.Linq;

namespace MyShop.Controllers
{
    public class ProductController : Controller
    {
        private readonly MyEshopContext _context;

        public ProductController(MyEshopContext context)
        {
            _context = context;
        }

        [Route("Group/{id}/{name}")]
        public IActionResult ShowProductByGroupId(int id, string name)
        {
            ViewData["GroupName"] = name;
            var products = _context.CategoryToProducts
                .Where(c => c.CategoryId == id)
                .Include(c => c.Product)
                .Select(c => c.Product)
                .ToList();

            return View(products);
        }
    }
}
