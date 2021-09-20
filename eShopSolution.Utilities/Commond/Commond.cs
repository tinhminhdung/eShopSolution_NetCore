using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eShopSolution.Utilities.Commond
{
    public class Commond
    {
        public static string Enable(string enable)
        {
            if (enable.Trim().Equals("InActive"))
            {
                return "Ẩn";
            }
            return "Hiển thị";
        }
        public static string Image_width_height_Admin(string image, string width, string height)
        {
            if (!string.IsNullOrEmpty(image))
            {
                return "<img src='" + image + "' style='height:" + height + "px;width:" + width + "px'  >";
            }
            return "";
        }
        public static string FormatDatehhss(object date)
        {
            return (Convert.ToDateTime(date).ToString("dd/MM/yyyy hh:mm"));
        }
        public static string FormatDate(object date)
        {
            return (Convert.ToDateTime(date).ToString("dd/MM/yyyy"));
        }
        public static string Hienthihinhcay(string treecode)
        {
            string chuoi = "<img src='/admin/images/Speerio_folderopen_edit.gif'  >";
            if (treecode.ToString().Trim().Length > 50)
            {
                chuoi = "<span style='margin-left:100px'><img src='/admin/images/sub.gif'  ></span>";
            }
            else if (treecode.ToString().Trim().Length > 45)
            {
                chuoi = "<span style='margin-left:90px'><img src='/admin/images/sub.gif'  ></span>";
            }
            else if (treecode.ToString().Trim().Length > 40)
            {
                chuoi = "<span style='margin-left:80px'><img src='/admin/images/sub.gif'  ></span>";
            }
            else if (treecode.ToString().Trim().Length > 35)
            {
                chuoi = "<span style='margin-left:70px'><img src='/admin/images/sub.gif'  ></span>";
            }
            else if (treecode.ToString().Trim().Length > 30)
            {
                chuoi = "<span style='margin-left:60px'><img src='/admin/images/sub.gif'  ></span>";
            }
            else if (treecode.ToString().Trim().Length > 25)
            {
                chuoi = "<span style='margin-left:50px'><img src='/admin/images/sub.gif'  ></span>";
            }
            else if (treecode.ToString().Trim().Length > 20)
            {
                chuoi = "<span style='margin-left:40px'><img src='/admin/images/sub.gif'  ><span>";
            }
            else if (treecode.ToString().Trim().Length > 15)
            {
                chuoi = "<span style='margin-left:30px'><img src='/admin/images/sub.gif'  ></span>";
            }
            else if (treecode.ToString().Trim().Length > 10)
            {
                chuoi = "<span style='margin-left:20px'><img src='/admin/images/sub.gif'  ></span>";
            }
            else if (treecode.ToString().Trim().Length > 5)
            {
                chuoi = "<span style='margin-left:10px'><img src='/admin/images/sub.gif'  ></span>";
            }
            else
            {
                chuoi = chuoi;
            }
            return chuoi = chuoi;
        }
    }
}
