using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using MovieModel;
using FilmDAL;

namespace FilmDemoApi.Controllers
{
    public class CinemaController : ApiController
    {
        #region 品牌显示
        /// <summary>
        /// 调用DAl里显示品牌
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public List<ChCinema> GetChCinemas()
        {
            return DAL.ChCinema();
        }
        #endregion
         

        #region 品牌下的电影院显示
        /// <summary>
        /// 调用Api品牌下的电音院
        /// </summary>
        /// <param name="Pid">获取品牌id匹配电影Id</param>
        /// <returns></returns>
        [HttpGet]
        public List<CinemaList> GetChCinemasList(int Pid)
        {
            return DAL.cinemaLists(Pid);
        }
        #endregion

        #region 显示地区
        [HttpGet]
        public List<district> districts()
        {
            return DAL.districts();
        }
        #endregion
    }
}
