using MyShop.Models;
using MyShop.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MyShop.Data.Repositories
{
    public class GroupRepository : IGroupRepository
    {
        private readonly MyEshopContext _context;

        public GroupRepository(MyEshopContext context)
        {
            _context = context;
        }

        public IEnumerable<Category> GetAllCategories()
        {
            return _context.Categories;
        }

        public IEnumerable<ShowGroupViewModel> GetGroupForShow()
        {
           return _context.Categories
                .Select(c => new ShowGroupViewModel
                {
                    GroupId = c.Id,
                    Name = c.Name,
                    ProductCount = _context.CategoryToProducts.Count(g => g.CategoryId == c.Id)
                }).ToList();
        }
    }
}
