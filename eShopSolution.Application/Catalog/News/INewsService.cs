using eShopSolution.ViewModels.Catalog.News;
using eShopSolution.ViewModels.Common;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace eShopSolution.Application.Catalog.News
{
    public interface INewsService
    {
        Task<NewsVm> GetById(int Id);
        Task<int> Delete(int Id);
        Task<List<NewsVm>> GetAll();
        Task<int> Create(NewsCreateRequest request);
        Task<int> Update(NewsEditRequest request);
        Task<PagedResult<NewsVm>> GetAllPaging(GetManageNewsPagingRequest request);
    }
}