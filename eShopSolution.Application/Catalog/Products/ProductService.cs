using eShopSolution.Data.EF;
using eShopSolution.Data.Entities;
using eShopSolution.Utilities.Constants;
using eShopSolution.Utilities.Exceptions;
using eShopSolution.ViewModels.Catalog.Products;
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

namespace eShopSolution.Application.Catalog.Products
{
          public class ProductService : IProductService
    {
        private readonly EShopDbContext _context;
        private const string USER_CONTENT_FOLDER_NAME = "user-content";

        public ProductService(EShopDbContext context)
        {
            _context = context;
        }
        public async Task<ProductVm> GetById(int productId)
        {
            var product = await _context.Products.FindAsync(productId);
          
            var productViewModel = new ProductVm()
            {
                Id = product.Id,
                Name = product.Name,
            };
            return productViewModel;
        }
    }
}