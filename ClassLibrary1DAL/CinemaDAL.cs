using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using System.Configuration;
using MovieModel;
using System.Data;
using System.Data.SqlClient;

namespace FilmDAL
{
    public static class DAL
    {


        #region 连接数据库
        /// <summary>
        /// 连接自定义配置节点
        /// </summary>
        private static readonly string ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["connstring"].ConnectionString;
        #endregion


        #region   品牌
        /// <summary>
        /// 显示品牌
        /// </summary>
        /// <returns></returns>
        public static List<ChCinema> ChCinema() {
            using (IDbConnection connection = new SqlConnection(ConnectionString))
            {
                return connection.Query<ChCinema>("select * from ChCinema").ToList();
            }
        }
        #endregion


        #region 品牌下电影院

        /// <summary>
        /// 显示品牌下的电影院
        /// </summary>
        /// <returns></returns>
        public static List<CinemaList> cinemaLists(int Pid)
        {
            using (IDbConnection connection=new SqlConnection(ConnectionString) )
            {
                return connection.Query<CinemaList>("select * from CinemaList where Lpid ="+Pid).ToList();
            }
        }
        #endregion



        #region  显示地区

        /// <summary>
        /// 显示地区
        /// </summary>
        /// <returns></returns>
        public static  List<district> districts()
        {
            using (IDbConnection connection=new SqlConnection(ConnectionString))
            {
               return  connection.Query<district>("select * from district").ToList();
            }
        }
        #endregion






    }
}
