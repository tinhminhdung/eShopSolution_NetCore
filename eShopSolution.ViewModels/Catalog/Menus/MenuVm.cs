using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using eShopSolution.Data.Enums;

namespace eShopSolution.ViewModels.Catalog.Menu
{
    public class MenuVm
    {
        public int Id { set; get; }
        public int Parent_ID { set; get; }
        public string capp { set; get; }
        public string Lang { set; get; }

        [Required(ErrorMessage = "Tiêu đề không được để trống")]
        public string Name { set; get; }
        public string SeoAlias { set; get; }
        public string Images { set; get; }
        public string Details { set; get; }
        public DateTime Create_Date { set; get; }

        [Required(ErrorMessage = "Thứ tự không được để trống")]
        public int Orders { set; get; }
        public string Level { set; get; }
        public string SeoTitle { set; get; }
        public string SeoDescription { set; get; }
        public string SeoKeyword { set; get; }
        public Status Status { set; get; }
        public Status Check_01 { set; get; }
        public Status Check_02 { set; get; }
        public Status Check_03 { set; get; }
        public Status Check_04 { set; get; }
        public Status Check_05 { set; get; }
        public Status Check_06 { set; get; }
        public Status Check_07 { set; get; }
        public Status Check_08 { set; get; }
        public Status Check_09 { set; get; }
        public Status Check_10 { set; get; }
        public string Noidung1 { set; get; }
        public string Noidung2 { set; get; }
        public string Noidung3 { set; get; }
        public string Noidung4 { set; get; }
        public string Noidung5 { set; get; }
        public string Noidung6 { set; get; }
        public string Noidung7 { set; get; }
        public string Noidung8 { set; get; }
        public string Noidung9 { set; get; }
        public string Noidung10 { set; get; }
    }
}