using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FilmModel;

namespace FilmDAL
{
    public class FilmDal
    {
        //热映口碑榜
        public List<FilmInfo> HotShow()
        {
            string sql = "select top(10) b.FilmCName,CONVERT(varchar(100),b.FilmReleaseTime,23) FilmReleaseTime,b.FilmPhotos,b.Grade,c.ActorCName from MovieActors a inner join FilmInfo b on a.FId=b.FId inner join ActorInfo c on a.AId = c.AId order by Grade desc";
            var table = DBHelper.GetDataTable(sql);
            var list = DBHelper.ConvertTableToList<List<FilmInfo>>(table);
            return list;
        }
        //最受期待榜
        public List<FilmInfo> Anticipated()
        {
            string sql = "select top(10) b.FilmCName,CONVERT(varchar(100),b.FilmReleaseTime,23)FilmReleaseTime,b.FilmPhotos,b.WantSee,c.ActorCName from MovieActors a inner join FilmInfo b on a.FId=b.FId inner join ActorInfo c on a.AId = c.AId order by WantSee desc";
            var table = DBHelper.GetDataTable(sql);
            var list = DBHelper.ConvertTableToList<List<FilmInfo>>(table);
            return list;
        }
        //票房榜
        public List<FilmInfo> Office()
        {
            string sql = "select  top(10) b.FilmCName,CONVERT(varchar(100),b.FilmReleaseTime,23)FilmReleaseTime ,b.FilmPhotos,b.Filmoffice,c.ActorCName from MovieActors a inner join FilmInfo b on a.FId=b.FId inner join ActorInfo c on a.AId = c.AId order by Filmoffice desc";
            var table = DBHelper.GetDataTable(sql);
            var list = DBHelper.ConvertTableToList<List<FilmInfo>>(table);
            return list;
        }
    }
}
