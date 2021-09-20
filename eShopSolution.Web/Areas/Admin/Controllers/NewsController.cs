using eShopSolution.Application.Catalog.News;
using eShopSolution.ViewModels.Catalog.News;
using eShopSolution.ViewModels.System.News;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eShopSolution.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class NewsController : Controller
    {
        private readonly INewsService _newsService;
        public NewsController(INewsService newsService)
        {
            _newsService = newsService;
        }
        public async Task<IActionResult> Index(string keyword, int? categoryId, int pageIndex = 1, int pageSize = 10)
        {
            var languageId = "VIE";
            var request = new GetManageNewsPagingRequest()
            {
                Keyword = keyword,
                PageIndex = pageIndex,
                PageSize = pageSize,
                Lang = languageId,
                CategoryId = categoryId
            };
            var data = await _newsService.GetAllPaging(request);
            ViewBag.Keyword = keyword;
            //var categories = await _categoryApiClient.GetAll(languageId);
            //ViewBag.Categories = categories.Select(x => new SelectListItem()
            //{
            //    Text = x.Name,
            //    Value = x.Id.ToString(),
            //    Selected = categoryId.HasValue && categoryId.Value == x.Id
            //});
            var news = await _newsService.GetAll();
            if (TempData["result"] != null)
            {
                ViewBag.SuccessMsg = TempData["result"];
            }
            return View(data);
        }

        public async Task<IActionResult> Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(NewsCreateRequest request)
        {
            string lang = "VIE";
            request.Lang = lang;

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var newID = await _newsService.Create(request);
            if (newID == 0)
                return BadRequest();
            TempData["Message"] = "Thêm mới thành công với ID=" + newID.ToString() + "";
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Edit(int id)
        {
            var news = await _newsService.GetById(id);
            var editVm = new NewsEditRequest()
            {
                Id = news.Id,
                Brief = news.Brief,
                Details = news.Details,
                Name = news.Name,
                //SeoAlias = news.SeoAlias,
                SeoDescription = news.SeoDescription,
                SeoTitle = news.SeoTitle
            };
            return View(editVm);
        }

        [HttpPost]
       
        public async Task<IActionResult> Edit(NewsEditRequest request)
        {
            if (!ModelState.IsValid)
                return View(request);

            var result = await _newsService.Update(request);
            if (result != 0)
            {
                TempData["result"] = "Cập nhật tin tức thành công";
                return RedirectToAction("Index");
            }
            ModelState.AddModelError("", "Cập nhật sản phẩm thất bại");
            return View(request);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(NewsDeleteRequest request)
        {
            if (!ModelState.IsValid)
                return View();

            var result = await _newsService.Delete(request.Id);
            if (result == 0)
            {
                TempData["result"] = "Xóa tin tức thành công";
                return RedirectToAction("Index");
            }
            ModelState.AddModelError("", "Xóa không thành công");
            return RedirectToAction("Index");
        }

        //public async Task<IActionResult> Index()
        //{
        //    var news = await _newsService.GetAll();
        //    var product = await _productService.GetById(1);
        //    ViewBag.Hienthi = product.Name + "--" + product.Id;
        //    return View(news);
        //}
    }
}
