using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using MyShop.Data;
using MyShop.Models;
using MyShop.Models.Entities;
using System;
using System.Diagnostics;
using System.Linq;
using System.Security.Claims;

namespace MyShop.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly MyEshopContext _context;
      

        public HomeController(ILogger<HomeController> logger, MyEshopContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            var products = _context.Products
                .ToList();
            return View(products);
        }

        public IActionResult Detail(int id)
        {
            var product = _context.Products
                .Include(p => p.Item)
                .SingleOrDefault(p => p.Id == id);
            if (product == null)
            {
                return NotFound();
            }

            var categories = _context.Products
                .Where(p => p.Id == id)
                .SelectMany(p => p.CategoryToProducts)
                .Select(p => p.Category)
                .ToList();

            var vm = new DetailsViewModel
            {
                Product = product,
                Category = categories
            };
            return View(vm);
        }

        [Authorize]
        public IActionResult AddToCart(int itemId)
        {
            var product = _context.Products.Include(p => p.Item).SingleOrDefault(p => p.Item.Id == itemId);
            if (product != null)
            {
                int userID = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier).ToString());
                var order = _context.Orders.FirstOrDefault(o => o.UserId == userID && !o.IsFinaly);
                if (order != null)
                {
                    var orderDetail = _context.OrderDetails.FirstOrDefault(d => d.OrderId == order.OrderId
                    && d.ProductId == product.Id
                    );
                    if (orderDetail != null)
                    {
                        orderDetail.Count += 1;
                    }
                    else
                    {
                        _context.OrderDetails.Add(new OrderDetails
                        {
                            OrderId = order.OrderId,
                            ProductId = product.Id,
                            Price = product.Item.Price,
                            Count = 1
                        });
                    }
                }
                else
                {
                    order = new Order
                    {
                        IsFinaly = false,
                        CreateDate = DateTime.Now,
                        UserId = userID
                    };
                    _context.Orders.Add(order);
                    _context.SaveChanges();
                    _context.OrderDetails.Add(new OrderDetails
                    {
                        OrderId = order.OrderId,
                        ProductId = product.Id,
                        Price = product.Item.Price,
                        Count = 1
                    });
                }
                _context.SaveChanges();
            }
            return RedirectToAction("ShowCart");
        }

        [Authorize]
        public IActionResult ShowCart()
        {
            int userID = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier).ToString());
            var order = _context.Orders.Where(o => o.UserId == userID && !o.IsFinaly)
                .Include(o => o.orderDetails)
                .ThenInclude(c => c.Product).FirstOrDefault();

            return View(order);
        }

        public IActionResult RemoveCart(int detailId)
        {
            var orderDateil = _context.OrderDetails.Find(detailId);
            _context.Remove(orderDateil);
            _context.SaveChanges();

            return RedirectToAction("ShowCart");
        }

        [Route("ContactUs")]
        public IActionResult ContactUs()
        {
            return View();
        }


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
