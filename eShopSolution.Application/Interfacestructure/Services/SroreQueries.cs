using Dapper;
using eShopSolution.ViewModels.Catalog.Menu;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eShopSolution.Application.Interfacestructure.Services
{
    public class SroreQueries : ISroreQueries
    {
        //https://www.youtube.com/watch?v=c7LRznQ3WJQ&t=663s
        private readonly string _Connectionstring;
        public SroreQueries(string Connectionstring)
        {
            _Connectionstring = Connectionstring;
        }
        public async Task<List<MenuVm>> ListAlLMenu2()
        {
            using (SqlConnection connection = new SqlConnection(_Connectionstring))
            {
                string query = "SELECT * FROM Menus";

                var result = await connection.QueryAsync<MenuVm>(query);
                return result.ToList();
            }
        }


        public async Task<List<dynamic>> ListAlLMenu()
        {
            using (SqlConnection connection = new SqlConnection(_Connectionstring))
            {
                string query = "SELECT * FROM Menus";

                var result = await connection.QueryAsync<dynamic>(query);
                return result.ToList();
            }
        }
        public async Task<MenuVm> Detail(int Id)// kiểu truyền bằng @Id
        {
            using (SqlConnection connection = new SqlConnection(_Connectionstring))
            {
                StringBuilder sb = new StringBuilder();
                sb.Append("SELECT * FROM Menus ");
                sb.Append("where Id=@Id");

                string query = sb.ToString();
                var result = await connection.QueryAsync<MenuVm>(query, new { Id });
                return result.FirstOrDefault();
            }
        }


        public async Task<List<dynamic>> NameSql(string Sql)
        {
            using (SqlConnection connection = new SqlConnection(_Connectionstring))
            {
                string query = Sql;
                var result = await connection.QueryAsync<dynamic>(query);
                return result.ToList();
            }
        }
        //public async Task<int> CreateOauthAccessToken(IDbConnection db, OauthAccessToken oauthAccessToken)
        //{
        //    string sqlQuery = @"INSERT INTO oauth_access_token(service, identity, access_token, game_id)
        //                 VALUES (@service, @identity, @access_token, @game_id)
        //                      RETURNING id";
        //    var obj = await db.QueryAsync<int>(sqlQuery, oauthAccessToken);
        //    return obj.FirstOrDefault();
        //}
    }
}
