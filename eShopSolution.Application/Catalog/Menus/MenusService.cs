using eShopSolution.Application.Common;
using eShopSolution.Data.EF;
using eShopSolution.Data.Enums;
using eShopSolution.Utilities.Commond;
using eShopSolution.Utilities.Exceptions;
using eShopSolution.ViewModels.Catalog.Menu;
using eShopSolution.ViewModels.Common;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace eShopSolution.Application.Catalog.Menus
{
    public class MenusService : IMenusService
    {
        private readonly IStorageService _storageService;
        private const string USER_CONTENT_FOLDER_NAME = "Upload/Menu";
        private readonly EShopDbContext _context;
        public MenusService(EShopDbContext context, IStorageService storageService)
        {
            _context = context;
            _storageService = storageService;
        }

        public async Task<MenuVm> GetByIdFromSqlRaw(int Id)
        {
            var menus = _context.Menus.FromSqlRaw("SELECT * from Menus").ToList();
            //var menu = _context.Menus.FromSqlRaw("SELECT * FROM Books").Select(b => new { BookId = b.Id}).ToList();
            // var menu = await _context.Menus.FindAsync(Id);
            var menu = menus[0];
            var MenusViewModel = new MenuVm()
            {
                Id = menu.Id,
                Parent_ID = menu.Parent_ID,
                capp = menu.capp,
                Lang = menu.Lang,
                Name = menu.Name,
                SeoAlias = menu.SeoAlias,
                Images = menu.Images,
                Details = menu.Details,
                Create_Date = menu.Create_Date,
                Orders = menu.Orders,
                Level = menu.Level,
                SeoTitle = menu.SeoTitle,
                SeoDescription = menu.SeoDescription,
                SeoKeyword = menu.SeoKeyword,
                Status = menu.Status,
                Check_01 = menu.Check_01,
                Check_02 = menu.Check_02,
                Check_03 = menu.Check_03,
                Check_04 = menu.Check_04,
                Check_05 = menu.Check_05,
                Check_06 = menu.Check_05,
                Check_07 = menu.Check_06,
                Check_08 = menu.Check_08,
                Check_09 = menu.Check_09,
                Check_10 = menu.Check_10,
                Noidung1 = menu.Noidung1,
                Noidung2 = menu.Noidung2,
                Noidung3 = menu.Noidung3,
                Noidung4 = menu.Noidung4,
                Noidung5 = menu.Noidung5,
                Noidung6 = menu.Noidung6,
                Noidung7 = menu.Noidung7,
                Noidung8 = menu.Noidung8,
                Noidung9 = menu.Noidung9,
                Noidung10 = menu.Noidung10
            };
            return MenusViewModel;
        }
        public async Task<MenuVm> GetById(int Id)
        {
            // var books = _context.Menus.FromSqlRaw("SELECT BookId, Title, AuthorId, Isbn FROM Books").ToList();
            // var books = _context.Menus.FromSqlRaw("SELECT * FROM Books").Select(b => new { BookId = b.Id}).ToList();

            var menu = await _context.Menus.FindAsync(Id);
            var MenusViewModel = new MenuVm()
            {
                Id = menu.Id,
                Parent_ID = menu.Parent_ID,
                capp = menu.capp,
                Lang = menu.Lang,
                Name = menu.Name,
                SeoAlias = menu.SeoAlias,
                Images = menu.Images,
                Details = menu.Details,
                Create_Date = menu.Create_Date,
                Orders = menu.Orders,
                Level = menu.Level,
                SeoTitle = menu.SeoTitle,
                SeoDescription = menu.SeoDescription,
                SeoKeyword = menu.SeoKeyword,
                Status = menu.Status,
                Check_01 = menu.Check_01,
                Check_02 = menu.Check_02,
                Check_03 = menu.Check_03,
                Check_04 = menu.Check_04,
                Check_05 = menu.Check_05,
                Check_06 = menu.Check_05,
                Check_07 = menu.Check_06,
                Check_08 = menu.Check_08,
                Check_09 = menu.Check_09,
                Check_10 = menu.Check_10,
                Noidung1 = menu.Noidung1,
                Noidung2 = menu.Noidung2,
                Noidung3 = menu.Noidung3,
                Noidung4 = menu.Noidung4,
                Noidung5 = menu.Noidung5,
                Noidung6 = menu.Noidung6,
                Noidung7 = menu.Noidung7,
                Noidung8 = menu.Noidung8,
                Noidung9 = menu.Noidung9,
                Noidung10 = menu.Noidung10
            };
            return MenusViewModel;
        }
        public async Task<List<MenuVm>> GetAll()
        {
            var Data = await _context.Menus.OrderBy(x => x.Id)
                    .Select(menu => new MenuVm()
                    {
                        Id = menu.Id,
                        Parent_ID = menu.Parent_ID,
                        capp = menu.capp,
                        Lang = menu.Lang,
                        Name = menu.Name,
                        SeoAlias = menu.SeoAlias,
                        Images = menu.Images,
                        Details = menu.Details,
                        Create_Date = menu.Create_Date,
                        Orders = menu.Orders,
                        Level = menu.Level,
                        SeoTitle = menu.SeoTitle,
                        SeoDescription = menu.SeoDescription,
                        SeoKeyword = menu.SeoKeyword,
                        Status = menu.Status,
                        Check_01 = menu.Check_01,
                        Check_02 = menu.Check_02,
                        Check_03 = menu.Check_03,
                        Check_04 = menu.Check_04,
                        Check_05 = menu.Check_05,
                        Check_06 = menu.Check_05,
                        Check_07 = menu.Check_06,
                        Check_08 = menu.Check_08,
                        Check_09 = menu.Check_09,
                        Check_10 = menu.Check_10,
                        Noidung1 = menu.Noidung1,
                        Noidung2 = menu.Noidung2,
                        Noidung3 = menu.Noidung3,
                        Noidung4 = menu.Noidung4,
                        Noidung5 = menu.Noidung5,
                        Noidung6 = menu.Noidung6,
                        Noidung7 = menu.Noidung7,
                        Noidung8 = menu.Noidung8,
                        Noidung9 = menu.Noidung9,
                        Noidung10 = menu.Noidung10,
                    }).ToListAsync();

            return Data;
        }
        public async Task<PagedResult<MenuVm>> GetAllPaging(GetManageMenuPagingRequest request)
        {
            //1. Select join
            var query = from p in _context.Menus
                        where p.Lang == request.Lang
                        select p;
            query = query.OrderBy(s => s.Orders);
            //2. filter
            if (!string.IsNullOrEmpty(request.Keyword))
                query = query.Where(x => x.Name.Contains(request.Keyword));

            //if (request.CategoryId != null && request.CategoryId != 0)
            //{
            //    query = query.Where(p => p.pic.CategoryId == request.CategoryId);
            //}

            //3. Paging
            int totalRow = await query.CountAsync();

            //order by level,Orders asc
            var data = await query.OrderBy(s => s.Level)
                .Skip((request.PageIndex - 1) * request.PageSize)
               .Take(request.PageSize)
               .Select(x => new MenuVm()
               {
                   Id = x.Id,
                   Name = x.Name,
                   Level = x.Level,
                   Create_Date = x.Create_Date,
                   Details = x.Details,
                   Lang = x.Lang,
                   SeoAlias = x.SeoAlias,
                   SeoDescription = x.SeoDescription,
                   SeoTitle = x.SeoTitle,
                   Images = x.Images,
                   Status = x.Status,
                   Orders = x.Orders,
               }).ToListAsync();

            //4. Select and projection
            var pagedResult = new PagedResult<MenuVm>()
            {
                TotalRecords = totalRow,
                PageSize = request.PageSize,
                PageIndex = request.PageIndex,
                Items = data
            };
            return pagedResult;
        }
        public async Task<int> Create(MenuCreateVm request, string IsChecked)
        {
            var Menus = new Data.Entities.Menus();
            Menus.capp = "NS";
            if (request.Level != "")
            {
                Menus.Level = request.Level + "00000";
            }
            else
            {
                Menus.Level = "00000";
            }
            //if (request.Images != null)
            //    Menus.Images = request.Images;
            //else
            //    Menus.Images = "";

          
            if (request.Images != null)
            {
                Menus.Images = await this.SaveFile(request.Images);
                Menus.Noidung10 = request.Images.Length.ToString();
            }


            Menus.SeoAlias = RewriteURL.NameToTag(request.Name);
            Menus.Lang = "VIE";
            Menus.Name = request.Name;
            Menus.Create_Date = DateTime.Now;
            Menus.Check_01 = Status.InActive;
            Menus.Check_02 = Status.InActive;
            Menus.Check_03 = Status.InActive;
            Menus.Check_04 = Status.InActive;
            Menus.Check_05 = Status.InActive;
            Menus.Check_06 = Status.InActive;
            Menus.Check_07 = Status.InActive;
            Menus.Check_08 = Status.InActive;
            Menus.Check_09 = Status.InActive;
            Menus.Check_10 = Status.InActive;
            if (IsChecked == "true")
            {
                Menus.Status = Status.Active;
            }
            else
            {
                Menus.Status = Status.Active;
            }
            Menus.Details = request.Details;
            Menus.Orders = request.Orders;
            Menus.SeoTitle = request.SeoTitle;
            Menus.SeoDescription = request.SeoDescription;
            Menus.SeoKeyword = request.SeoKeyword;
            Menus.Noidung1 = request.Noidung1;
            Menus.Noidung2 = request.Noidung2;
            Menus.Noidung3 = request.Noidung3;
            Menus.Noidung4 = request.Noidung4;
            Menus.Noidung5 = request.Noidung5;
            Menus.Noidung6 = request.Noidung6;
            Menus.Noidung7 = request.Noidung7;
            Menus.Noidung8 = request.Noidung8;
            Menus.Noidung9 = request.Noidung9;
           // Menus.Noidung10 = request.Noidung10;

            _context.Menus.Add(Menus);
            await _context.SaveChangesAsync();
            return Menus.Id;
        }
        public async Task<int> Update(MenuVm request, string IsChecked)
        {
            var Menus = await _context.Menus.FindAsync(request.Id);
            if (Menus == null) throw new EShopException($"Cannot find a Menus with id: {request.Id}");
            Menus.Parent_ID = request.Parent_ID;
            Menus.capp = "NS";
            if (request.Level != "")
            {
                Menus.Level = request.Level + "00000";
            }
            else
            {
                Menus.Level = "00000";
            }
            if (request.Images != null)
                Menus.Images = request.Images;
            else
                Menus.Images = "";

            Menus.SeoAlias = RewriteURL.NameToTag(request.Name);
            Menus.Lang = "VIE";
            Menus.Name = request.Name;
           // Menus.Create_Date = DateTime.Now;
            Menus.Check_01 = Status.InActive;
            Menus.Check_02 = Status.InActive;
            Menus.Check_03 = Status.InActive;
            Menus.Check_04 = Status.InActive;
            Menus.Check_05 = Status.InActive;
            Menus.Check_06 = Status.InActive;
            Menus.Check_07 = Status.InActive;
            Menus.Check_08 = Status.InActive;
            Menus.Check_09 = Status.InActive;
            Menus.Check_10 = Status.InActive;
            if (IsChecked == "true")
            {
                Menus.Status = Status.Active;
            }
            else
            {
                Menus.Status = Status.Active;
            }
            Menus.Details = request.Details;
            Menus.Orders = request.Orders;
            Menus.SeoTitle = request.SeoTitle;
            Menus.SeoDescription = request.SeoDescription;
            Menus.SeoKeyword = request.SeoKeyword;
            Menus.Noidung1 = request.Noidung1;
            Menus.Noidung2 = request.Noidung2;
            Menus.Noidung3 = request.Noidung3;
            Menus.Noidung4 = request.Noidung4;
            Menus.Noidung5 = request.Noidung5;
            Menus.Noidung6 = request.Noidung6;
            Menus.Noidung7 = request.Noidung7;
            Menus.Noidung8 = request.Noidung8;
            Menus.Noidung9 = request.Noidung9;
            Menus.Noidung10 = request.Noidung10;

            return await _context.SaveChangesAsync();
        }
        public async Task<int> Delete(int Id)
        {
            var Menus = await _context.Menus.FindAsync(Id);
            if (Menus == null) throw new EShopException($"Cannot find a product: {Id}");
            _context.Menus.Remove(Menus);
            return await _context.SaveChangesAsync();
        }

        private async Task<string> SaveFile(IFormFile file)
        {
            var originalFileName = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');
            var fileName = $"{Guid.NewGuid()}{Path.GetExtension(originalFileName)}";
            await _storageService.SaveFileAsync(file.OpenReadStream(), fileName);
            return "/" + USER_CONTENT_FOLDER_NAME + "/" + fileName;
        }
    }
}
