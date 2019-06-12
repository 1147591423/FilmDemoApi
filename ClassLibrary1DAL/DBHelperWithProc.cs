﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using Newtonsoft.Json;

namespace FilmDAL
{
    public static class DBHelper
    {
        //获取web.config里的连接字符串
        public static string strCon = " Data Source=DESKTOP-S9913EK;Initial Catalog=FilmDemo;Persist Security Info=True;User ID=sa;pwd=123";

        /// <summary>
        /// 将DataTable装换为List
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="dt">DataTable</param>
        /// <returns></returns>
        public static T ConvertTableToList<T>(DataTable dt)
        {
            var str = JsonConvert.SerializeObject(dt);
            var list = JsonConvert.DeserializeObject<T>(str);
            return list;
        }


        /// <summary>
        /// 增删改使用存储过程
        /// </summary>
        /// <param name="procName">存储过程名称</param>
        /// <param name="str">连接字符串</param>
        /// <returns></returns>
        public static int ExecuteNonQueryByProcedure(string procName, SqlParameter[] paras = null)
        {
            //实例化连接对象
            SqlConnection conn = new SqlConnection(strCon);
            int result = 0;
            try
            {
                conn.Open();
                //实例化命令对象
                SqlCommand cmd = new SqlCommand(procName, conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddRange(paras);
                //执行命令
                result = cmd.ExecuteNonQuery();
                cmd.Parameters.Clear();
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                conn.Close();
            }
            return result;
        }

        /// <summary>
        /// 获取表格使用存储过程
        /// </summary>
        /// <param name="procName">存储过程名称</param>
        /// <param name="str">连接字符串</param>
        /// <returns></returns>
        public static DataTable GetDataTableByProcedure(string procName, SqlParameter[] paras = null)
        {
            //实例化连接对象
            SqlConnection conn = new SqlConnection(strCon);
            DataTable dt = new DataTable();

            try
            {
                SqlCommand cmd = new SqlCommand(procName, conn);
                cmd.CommandType = CommandType.StoredProcedure;
                //如果参数不为空
                if (paras != null)
                {
                    cmd.Parameters.AddRange(paras);
                }
                //实例化适配器
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                sda.Fill(dt);

            }
            catch (Exception)
            {

                throw;
            }
            return dt;
        }

        /// <summary>
        /// 增删改
        /// </summary>
        /// <param name="sql">sql语句</param>
        /// <param name="str">连接字符串</param>
        /// <returns></returns>
        public static int ExecuteNonQuery(string sql)
        {
            //实例化连接对象
            SqlConnection conn = new SqlConnection(strCon);
            int result = 0;
            try
            {
                conn.Open();
                //实例化命令对象
                SqlCommand cmd = new SqlCommand(sql, conn);
                //执行命令
                result = cmd.ExecuteNonQuery();
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                conn.Close();
            }
            return result;
        }
        /// <summary>
        /// 获取表格
        /// </summary>
        /// <param name="sql">sql语句</param>
        /// <param name="str">连接字符串</param>
        /// <returns></returns>
        public static DataTable GetDataTable(string sql)
        {
            //实例化连接对象
            SqlConnection conn = new SqlConnection(strCon);
            DataTable dt = new DataTable();

            try
            {
                //实例化适配器
                SqlDataAdapter sda = new SqlDataAdapter(sql, conn);
                sda.Fill(dt);

            }
            catch (Exception)
            {

                throw;
            }
            return dt;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sql">sql语句</param>
        /// <param name="str">连接字符串</param>
        /// <returns></returns>
        public static SqlDataReader GetDataReader(string sql)
        {
            //实例化连接对象
            SqlConnection conn = new SqlConnection(strCon);
            SqlDataReader sdr;
            try
            {
                conn.Open();
                //实例化命令对象
                SqlCommand cmd = new SqlCommand(sql, conn);
                sdr = cmd.ExecuteReader();

            }
            catch (Exception)
            {

                throw;
            }
            return sdr;
        }
        /// <summary>
        /// 返回单行单列
        /// </summary>
        /// <param name="sql">sql语句</param>
        /// <param name="str">连接字符串</param>
        /// <returns></returns>
        public static int ExecuteScalar(string sql)
        {
            //实例化连接对象
            SqlConnection conn = new SqlConnection(strCon);
            int result = 0;
            try
            {
                conn.Open();
                //实例化命令对象
                SqlCommand cmd = new SqlCommand(sql, conn);
                result = Convert.ToInt32(cmd.ExecuteScalar());
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {

                conn.Close();
            }
            return result;
        }
    }
}
