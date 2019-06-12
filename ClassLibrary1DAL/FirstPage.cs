﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using Dapper;
using FilmModel;
using System.Data;
using System.Data.SqlClient;

namespace FilmDAL
{
    public class FirstPage
    {
        static string sqlconn = ConfigurationManager.AppSettings["SqlConnection"];
        IDbConnection db = new SqlConnection(sqlconn);
        public List<FilmInfo> GetFilm()
        {
            string sql = "select * from FilmInfo";
            var list = db.Query<FilmInfo>(sql).ToList();
            return list;
        }
        public List<FilmInfo> SearchFilm(string AName)
        {
            string sql = "select * from FilmInfo where ";
            var list = db.Query<FilmInfo>(sql).ToList();
            return list;
        }
        public List<FilmInfo> FilmOrderByOffice()
        {
            string sql = "select top(10) * from FilmInfo  order by Filmoffice desc";
            var list = db.Query<FilmInfo>(sql).ToList();
            return list;
        }
        public List<FilmInfo> FilmOrderByGradee()
        {
            string sql = "select top(10) * from FilmInfo  order by Grade desc";
            var list = db.Query<FilmInfo>(sql).ToList();
            return list;
        }

    }
}
