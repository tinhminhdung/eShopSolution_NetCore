using eShopSolution.ViewModels.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace eShopSolution.ViewModels.Catalog.News
{
    public class GetManageNewsPagingRequest : PagingRequestBase
    {
        public string Keyword { get; set; }

        public string Lang { get; set; }

        public int? CategoryId { get; set; }
    }
}