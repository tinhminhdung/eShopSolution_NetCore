using eShopSolution.Data.EF;
using eShopSolution.Data.Entities;
using eShopSolution.Data.Enums;
using eShopSolution.Utilities.Constants;
using eShopSolution.Utilities.Exceptions;
using eShopSolution.ViewModels.Catalog.News;
using eShopSolution.ViewModels.Common;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace eShopSolution.Application.Catalog.News
{
    public class NewsService : INewsService
    {
        private readonly EShopDbContext _context;
        private const string USER_CONTENT_FOLDER_NAME = "user-content";

        public NewsService(EShopDbContext context)
        {
            _context = context;
        }
        public async Task<NewsVm> GetById(int Id)
        {
            var news = await _context.News.FindAsync(Id);
            var NewsViewModel = new NewsVm()
            {
                Id = news.Id,
                Name = news.Name,
                Brief=news.Brief,
                Details = news.Details,
                SeoAlias = news.SeoAlias,
                SeoDescription = news.SeoDescription,
                SeoTitle = news.SeoTitle
            };
            return NewsViewModel;
        }
        public async Task<List<NewsVm>> GetAll()
        {
            var newall = await _context.News.OrderBy(x => x.Id)
                    .Select(x => new NewsVm()
                    {
                        Id = x.Id,
                        Name = x.Name,
                        Brief = x.Brief,
                    }).ToListAsync();

            return newall;
        }
        public async Task<PagedResult<NewsVm>> GetAllPaging(GetManageNewsPagingRequest request)
        {
            //1. Select join
            var query = from p in _context.News
                        where p.Lang == request.Lang 
                        select new { p};
            //2. filter
            if (!string.IsNullOrEmpty(request.Keyword))
                query = query.Where(x => x.p.Name.Contains(request.Keyword));

            //if (request.CategoryId != null && request.CategoryId != 0)
            //{
            //    query = query.Where(p => p.pic.CategoryId == request.CategoryId);
            //}

            //3. Paging
            int totalRow = await query.CountAsync();

            var data = await query.Skip((request.PageIndex - 1) * request.PageSize)
                .Take(request.PageSize)
                .Select(x => new NewsVm()
                {
                    Id = x.p.Id,
                    Name = x.p.Name,
                    Create_Date = x.p.Create_Date,
                    Brief = x.p.Brief,
                    Details = x.p.Details,
                    Lang = x.p.Lang,
                    SeoAlias = x.p.SeoAlias,
                    SeoDescription = x.p.SeoDescription,
                    SeoTitle = x.p.SeoTitle,
                    Views = x.p.Views,
                    ImagesSmall = x.p.ImagesSmall
                }).ToListAsync();

            //4. Select and projection
            var pagedResult = new PagedResult<NewsVm>()
            {
                TotalRecords = totalRow,
                PageSize = request.PageSize,
                PageIndex = request.PageIndex,
                Items = data
            };
            return pagedResult;
        }
        public async Task<int> Create(NewsCreateRequest request)
        {
            var news = new Data.Entities.News()
            {
                Name = request.Name,
                SeoAlias = request.SeoAlias,
                ImagesSmall = request.ImagesSmall,
                Images = request.Images,
                Alt = request.Alt,
                Brief = request.Brief,
                Details = request.Details,
                SeoTitle = request.SeoTitle,
                SeoKeyword = request.SeoKeyword,
                SeoDescription = request.SeoDescription,
                Create_Date = DateTime.Now,
                Lang = request.Lang,
                Views = 0,
                Status = Status.InActive 
            };
            _context.News.Add(news);
            await _context.SaveChangesAsync();
            return news.Id;
        }
        public async Task<int> Update(NewsEditRequest request)
        {
            var news = await _context.News.FindAsync(request.Id);
            if (news == null ) throw new EShopException($"Cannot find a News with id: {request.Id}");

            news.Name = request.Name;
            news.Brief = request.Brief;
            news.SeoDescription = request.SeoDescription;
            news.SeoTitle = request.SeoTitle;
            news.SeoDescription = request.SeoDescription;
            news.Details = request.Details;
            return await _context.SaveChangesAsync();
        }

        public async Task<int> Delete(int Id)
        {
            var news = await _context.News.FindAsync(Id);
            if (news == null) throw new EShopException($"Cannot find a product: {Id}");
            _context.News.Remove(news);
            return await _context.SaveChangesAsync();
        }

    }
}