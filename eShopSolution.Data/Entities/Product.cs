using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace eShopSolution.Data.Entities
{
    public class Product
    {
        public int Id { set; get; }
        public string Name { set; get; }
        public string Price { set; get; }

        //public List<OrderDetail> OrderDetails { get; set; }

        //public List<Cart> Carts { get; set; }

        //public List<ProductTranslation> ProductTranslations { get; set; }

        //public List<ProductImage> ProductImages { get; set; }
    }
}