using eShopSolution.ViewModels.Catalog.Menu;
using eShopSolution.ViewModels.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eShopSolution.Application.Catalog.Menus
{
    public interface IMenusService
    {
        Task<MenuVm> GetById(int Id);
        Task<int> Delete(int Id);
        Task<List<MenuVm>> GetAll();
        Task<int> Create(MenuCreateVm request,string IsChecked);
        Task<int> Update(MenuVm request, string IsChecked);
        Task<PagedResult<MenuVm>> GetAllPaging(GetManageMenuPagingRequest request);
    }
}
