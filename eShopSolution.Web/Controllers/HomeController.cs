using eShopSolution.Application.Catalog.News;
using eShopSolution.Application.Catalog.Products;
using eShopSolution.Application.Interfacestructure.Services;
using eShopSolution.Data.EF;
using eShopSolution.ViewModels.Catalog.News;
using eShopSolution.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace eShopSolution.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IProductService _productService;
        private readonly INewsService _newsService;
        private readonly EShopDbContext _context;

        private readonly ISroreQueries _sroreQueries;
        public HomeController(ILogger<HomeController> logger, IProductService productService, INewsService newsService, ISroreQueries sroreQueries, EShopDbContext context)
        {
            _logger = logger;
            _productService = productService;
            _newsService = newsService;
            _context = context;
            _sroreQueries = sroreQueries;
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
            return View();
        }

        public async Task<IActionResult> PageSanPham(string keyword, int? categoryId, int pageIndex = 1, int pageSize = 10)
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
        public async Task<IActionResult> Index()
        {
            // udapte 
            //try
            //{
            //    _context.Menus.FromSqlRaw("update  Menus set Name=N'Cập nhật bằng sql 555' where Id=1 ").ToList();
            //}
            //catch (Exception)
            //{ }

            var menus = _context.Menus.FromSqlRaw("SELECT * from Menus").ToList();
            foreach (var item in menus)
            {
                ViewBag.Hienthimenus += item.Name + "--" + item.Id + "<br />";
            }


            // truy vấn thông qua SQl
            var querysql = await _sroreQueries.ListAlLMenu();
            foreach (var item in querysql)
            {
                ViewBag.querysql += item.Name + "--" + item.Id + "<br />";
            }
            // truy vấn thông qua SQl Kiểu 2
            var querysql2 = await _sroreQueries.ListAlLMenu2();
            foreach (var item in querysql2)
            {
                ViewBag.querysql2 += item.Name + "--" + item.Id + "<br />";
            }


            // Update 
            await _sroreQueries.NameSql("update  Menus set Name=N'Cập nhật bằng sql truy vấn thông qua SQl' where Id=1 ");


            var Details = await _sroreQueries.Detail(1);
            ViewBag.querysql3 = Details.Name + "--" + Details.Id + "<br />";


            var news = await _newsService.GetAll();
            var product = await _productService.GetById(1);
            ViewBag.Hienthi = product.Name + "--" + product.Id;
            return View(news);
        }
        // kiểu 2 ko cần thông qua AddTransient trong thư mục start
        //public IActionResult Index()
        //{
        //    var product =  _context.Products.Find(1);
        //    var productViewModel = new ProductVm()
        //    {
        //        Id = product.Id,
        //        Name = product.Name,
        //    };
        //    //var product = await _productService.GetById(1);
        //    ViewBag.Hienthi = productViewModel.Name;
        //    return View(productViewModel);
        //}

        // kiểu 3 ko cần thông qua AddTransient trong thư mục start
        //public IActionResult Index()
        //{
        //    var product = _context.Products
        //    .Select(product => new ProductVm()
        //    {
        //        Id = product.Id,
        //        Name = product.Name,
        //    }).ToList();
        //    foreach (var item in product)
        //    {
        //        ViewBag.Hienthi += item.Name;
        //    }
        //    //var product = await _productService.GetById(1);

        //    return View();
        //}
        public IActionResult Privacy()
        {
            return View();
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
