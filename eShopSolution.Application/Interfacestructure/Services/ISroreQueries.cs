using eShopSolution.ViewModels.Catalog.Menu;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eShopSolution.Application.Interfacestructure.Services
{
    public interface ISroreQueries
    {
        Task<List<MenuVm>> ListAlLMenu2();
        Task<List<dynamic>> ListAlLMenu();
        Task<MenuVm> Detail(int Id);
        Task<List<dynamic>> NameSql(string Sql);
    }
}
