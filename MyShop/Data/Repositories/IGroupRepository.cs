using MyShop.Models;
using MyShop.Models.Entities;
using System.Collections.Generic;

namespace MyShop.Data.Repositories
{
    public interface IGroupRepository
    {
        IEnumerable<Category> GetAllCategories();

        IEnumerable<ShowGroupViewModel> GetGroupForShow();

    }
}
