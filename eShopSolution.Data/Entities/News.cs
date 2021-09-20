﻿using eShopSolution.Data.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace eShopSolution.Data.Entities
{
    public class News
    {
        public int Id { set; get; }
        public string Name { set; get; }
        public string SeoAlias { set; get; }
        public string ImagesSmall { set; get; }
        public string Images { set; get; }
        public string Alt { set; get; }
        public string Brief { set; get; }
        public string Details { set; get; }
        public string SeoTitle { set; get; }
        public string SeoKeyword { set; get; }
        public string SeoDescription { set; get; }
        public DateTime Create_Date { set; get; }
        public string Lang { set; get; }
        public int Views { set; get; }
        public Status Status { set; get; }
    }
}