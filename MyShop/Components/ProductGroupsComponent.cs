using Microsoft.AspNetCore.Mvc;
using MyShop.Data.Repositories;
using System.Threading.Tasks;

namespace MyShop.Components
{
    public class ProductGroupsComponent : ViewComponent
    {
        private readonly IGroupRepository _groupRepository;

        public ProductGroupsComponent(IGroupRepository groupRepository)
        {
            _groupRepository = groupRepository;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View("/Views/Cpmponents/ProductGroupsComponent.cshtml", _groupRepository.GetGroupForShow());
        }
    }
}
