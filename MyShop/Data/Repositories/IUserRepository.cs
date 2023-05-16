using MyShop.Models.Entities;

namespace MyShop.Data.Repositories
{
    public interface IUserRepository
    {
        void AddUser(Users user);

        bool IsExistsByEmail(string email);

        Users GetUserForLogin(string email, string password);
    }
}
