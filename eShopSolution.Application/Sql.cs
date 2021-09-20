using eShopSolution.Data.EF;
using eShopSolution.Data.Enums;
using eShopSolution.Utilities.Exceptions;
using eShopSolution.ViewModels.Catalog.Menu;
using eShopSolution.ViewModels.Common;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

public class SqlCommand
{

    // udapte  nó bị lỗi lên phải cho vào try nhé
    //try
    //{
    //_context.Menus.FromSqlRaw("update  Menus set Name=N'Cập nhật bằng sql 555' where Id=1 ").ToList();
    //}
    //catch (Exception)
    //{ }

    // Lấy ra 1 danh sách
    //var menus = _context.Menus.FromSqlRaw("SELECT * from Menus").ToList();
    //foreach (var item in menus)
    //{
    //ViewBag.Hienthimenus += item.Name + "--" + item.Id + "<hr />";
    //}


    //private const string _dataSettingsFilePath = "App_Data/dataSettings.json";

    //public object Connection { get; private set; }

    //public List<MenuVm> Name_Text_ID(string Name_Text)
    //{
    //    SqlConnection conn = GetConnection();
    //    SqlCommand comm = new SqlCommand(Name_Text, conn);
    //    comm.CommandType = CommandType.Text;
    //    try
    //    {
    //        return Bind_List_Reader<MenuVm>(comm);
    //    }
    //    catch (Exception ex)
    //    {
    //        throw ex;
    //    }
    //    finally
    //    {
    //        conn.Close();
    //    }
    //}
    //private SqlConnection GetConnection()
    //{
    //    SqlConnection connection = new SqlConnection("");
    //    if (connection.State != ConnectionState.Open)
    //        connection.Open();
    //    return connection;
    //}

    //public static List<T> Bind_List_Reader<T>(SqlCommand command) where T : class
    //{
    //    List<T> list2;
    //    List<T> list = new List<T>();
    //    SqlDataReader rdr = command.ExecuteReader();
    //    try
    //    {
    //        while (rdr.Read())
    //        {
    //            T item = Get_Item_From_Reader<T>(rdr);
    //            list.Add(item);
    //        }
    //        list2 = list;
    //    }
    //    catch (Exception exception)
    //    {
    //        throw exception;
    //    }
    //    finally
    //    {
    //        command.Connection.Close();
    //    }
    //    return list2;
    //}
    //private static T Get_Item_From_Reader<T>(SqlDataReader rdr) where T : class
    //{
    //    Type type = typeof(T);
    //    T local = Activator.CreateInstance<T>();
    //    PropertyInfo[] properties = type.GetProperties();
    //    try
    //    {
    //        foreach (PropertyInfo info in properties)
    //        {
    //            if (rdr[info.Name].ToString().Trim() != string.Empty)
    //            {
    //                info.SetValue(local, rdr[info.Name], null);
    //            }
    //            else if (rdr[info.Name] == string.Empty)
    //            {
    //                info.SetValue(local, rdr[info.Name], null);
    //            }
    //        }
    //        return local;
    //    }
    //    catch (Exception)
    //    {
    //        return local;
    //    }
    //}

}
