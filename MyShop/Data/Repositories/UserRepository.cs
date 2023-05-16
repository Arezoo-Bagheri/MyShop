using MyShop.Models.Entities;
using System;
using System.Linq;

namespace MyShop.Data.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly MyEshopContext _context;

        public UserRepository(MyEshopContext context)
        {
            _context = context;
        }

        public void AddUser(Users user)
        {
            _context.Add(user);
            _context.SaveChanges();
        }

        public Users GetUserForLogin(string email, string password)
        {
            return _context.Users
                .SingleOrDefault(u => u.Email == email && u.Password == password);
        }

        public bool IsExistsByEmail(string email)
        {
            return _context.Users.Any(u => u.Email == email);
        }
    }
}
