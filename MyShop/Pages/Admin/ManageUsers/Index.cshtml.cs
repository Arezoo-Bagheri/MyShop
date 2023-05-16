using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MyShop.Data;
using MyShop.Models.Entities;

namespace MyShop.Pages.Admin.ManageUsers
{
    public class IndexModel : PageModel
    {
        private readonly MyShop.Data.MyEshopContext _context;

        public IndexModel(MyShop.Data.MyEshopContext context)
        {
            _context = context;
        }

        public IList<Users> Users { get;set; }

        public async Task OnGetAsync()
        {
            Users = await _context.Users.ToListAsync();
        }
    }
}
