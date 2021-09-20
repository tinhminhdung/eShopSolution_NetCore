using eShopSolution.ViewModels.Catalog.Menu;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using eShopSolution.Application.Catalog.Menus;
using eShopSolution.Utilities.Commond;
using eShopSolution.Data.Enums;

namespace eShopSolution.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class MenuNewsController : Controller
    {
        private readonly IMenusService _menuService;
        public MenuNewsController(IMenusService menuService)
        {
            _menuService = menuService;
        }
        public async Task<IActionResult> Index(string keyword, int pageIndex = 1, int pageSize = 10)
        {
            var languageId = "VIE";
            var request = new GetManageMenuPagingRequest()
            {
                Keyword = keyword,
                PageIndex = pageIndex,
                PageSize = pageSize,
                Lang = languageId,
            };
            var data = await _menuService.GetAllPaging(request);
            ViewBag.Keyword = keyword;
            if (TempData["result"] != null)
            {
                ViewBag.SuccessMsg = TempData["result"];
            }
            return View(data);
        }
        public async Task<IActionResult> Create(int id = 0)
        {
            if (id != 0)
            {
                var data = await _menuService.GetById(id);
                if (data != null)
                {
                    ViewBag.Level = data.Level;
                    ViewBag.Parent_ID = data.Id;
                }
            }
            else
            {
                ViewBag.Level = "";
                ViewBag.Parent_ID = "-1";
            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(MenuCreateVm request, string IsChecked)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var newID = await _menuService.Create(request, IsChecked);
            if (newID == 0)
                return BadRequest();
            TempData["Message"] = "Thêm mới thành công với ID=" + newID.ToString() + "";
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Edit(int id)
        {
            var news = await _menuService.GetById(id);
            var editVm = new MenuVm()
            {
                Id = news.Id,
                Details = news.Details,
                Name = news.Name,
                SeoDescription = news.SeoDescription,
                SeoTitle = news.SeoTitle,
                SeoKeyword = news.SeoKeyword,
                Status = news.Status,
                Orders = news.Orders,
            };
           // ViewBag.Details = editVm.Details;
            if (editVm.Status.ToString() == "Active")
            {
                ViewBag.checkbox = "true";
            }
            return View(editVm);

            // gọi trực tiếp cũng dc ko cần thông qua objec var editVm = new MenuVm() 
            // return View(news);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(MenuVm request, string IsChecked)
        {
            if (!ModelState.IsValid)
                return View(request);
            var result = await _menuService.Update(request, IsChecked);
            if (result != 0)
            {
                TempData["result"] = "Cập nhật Menu thành công";
                return RedirectToAction("Index");
            }
            ModelState.AddModelError("", "Cập nhật Menu thất bại");
            return View(request);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(MenuVm request)
        {
            if (!ModelState.IsValid)
                return View();

            var result = await _menuService.Delete(request.Id);
            if (result == 0)
            {
                TempData["result"] = "Xóa Menu  thành công";
                return RedirectToAction("Index");
            }
            ModelState.AddModelError("", "Xóa không thành công");
            return RedirectToAction("Index");
        }

    }
}
