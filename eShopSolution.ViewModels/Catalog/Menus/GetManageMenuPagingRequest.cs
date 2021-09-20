using eShopSolution.ViewModels.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace eShopSolution.ViewModels.Catalog.Menu
{
    public class GetManageMenuPagingRequest : PagingRequestBase
    {
        public string Keyword { get; set; }

        public string Lang { get; set; }
    }
}