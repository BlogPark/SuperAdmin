using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SuperAdmin.datamodel;
using System.Data;
using System.Data.SqlClient;

namespace SuperAdmin.DataDAL
{
    /// <summary>
    /// 文章操作类
    /// </summary>
    public class ArticleOperate
    {
        DbHelperSQL helper = new DbHelperSQL();
        #region 管理员后台
        /// <summary>
        /// 得到所有的文章
        /// </summary>
        /// <returns></returns>
        public List<ArticlesModel> GetAllArticles()
        {
            List<ArticlesModel> list = new List<ArticlesModel>();
            string sqltxt = @"SELECT  ID ,
        ArtTitle ,
        MemberID ,
        MemberName ,
        ArtPublishTime ,
        ArtStatus ,
        CASE ArtStatus
          WHEN 10 THEN '待审核'
          WHEN 20 THEN '已审核'
          WHEN 30 THEN '已删除'
        END AS ArtStatusName ,
        ArtType ,
        CASE ArtType
          WHEN 1 THEN '原创文章'
          WHEN 2 THEN '原创图集'
          WHEN 3 THEN '广告软文'
          WHEN 4 THEN '引用文章'
          WHEN 5 THEN '引用图集'
        END AS ArtTypeName ,
        AddTime ,
        ArtCID ,
        ArtCName
FROM    dbo.Articles";
            DataTable dt = helper.Query(sqltxt).Tables[0];
            foreach (DataRow item in dt.Rows)
            {
                ArticlesModel model = new ArticlesModel();
                model.ID = int.Parse(item["ID"].ToString());
                model.ArtTitle = item["ArtTitle"].ToString();
                model.MemberID = int.Parse(item["MemberID"].ToString());
                model.MemberName = item["MemberName"].ToString();
                model.ArtPublishTime = DateTime.Parse(item["ArtPublishTime"].ToString());
                model.ArtStatus = int.Parse(item["ArtStatus"].ToString());
                model.ArtStatusName = item["ArtStatusName"].ToString();
                model.ArtType = int.Parse(item["ArtType"].ToString());
                model.ArtTypeName = item["ArtTypeName"].ToString();
                model.AddTime = DateTime.Parse(item["AddTime"].ToString());
                model.ArtCID = int.Parse(item["ArtCID"].ToString());
                model.ArtCName = item["ArtCName"].ToString();
                list.Add(model);
            }
            return list;
        }
        /// <summary>
        /// 查询一条文章信息
        /// </summary>
        /// <param name="aid"></param>
        /// <returns></returns>
        public ArticlesModel GetSingleArticleByID(int aid)
        {
            ArticlesModel model = new ArticlesModel();
            string sqltxt = @"SELECT  ID ,
        ArtTitle ,
        MemberID ,
        MemberName ,
        ArtPic ,
        ArtSummary ,
        ArtContent ,
        ArtTags ,
        ArtPublishTime,
        ArtAlbumJson
FROM    dbo.Articles WITH(NOLOCK)
WHERE ID=@id";
            SqlParameter[] paramter = { new SqlParameter("@id", aid) };
            DataTable dt = helper.Query(sqltxt, paramter).Tables[0];
            if (dt.Rows.Count > 0)
            {
                model.ID = int.Parse(dt.Rows[0]["ID"].ToString());
                model.ArtTitle = dt.Rows[0]["ArtTitle"].ToString();
                model.MemberID = int.Parse(dt.Rows[0]["MemberID"].ToString());
                model.MemberName = dt.Rows[0]["MemberName"].ToString();
                model.ArtPic = dt.Rows[0]["ArtPic"].ToString();
                model.ArtSummary = dt.Rows[0]["ArtSummary"].ToString();
                model.ArtContent = dt.Rows[0]["ArtContent"].ToString();
                model.ArtTags = dt.Rows[0]["ArtTags"].ToString();
                model.ArtPublishTime = DateTime.Parse(dt.Rows[0]["ArtPublishTime"].ToString());
                model.ArtAlbumJson = dt.Rows[0]["ArtAlbumJson"].ToString();
            }
            return model;
        }
        /// <summary>
        /// 修改文章状态
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int UpdateArticleStatus(ArticlesModel model)
        {
            int rowcount = 0;
            string sqltxt = @"UPDATE  dbo.Articles
SET      ArtStatus = CASE ArtStatus
                      WHEN 30 THEN 30
                      WHEN 10 THEN 20
                      WHEN 20 THEN 10
                    END ,
        CheckUserID = @CheckUserID ,
        CheckUserName = @CheckUserName ,
        CheckTime = GETDATE()
WHERE   ID = @id";
            SqlParameter[] paramter = { 
                                      new SqlParameter("@CheckUserID",model.CheckUserID),
                                      new SqlParameter("@CheckUserName",model.CheckUserName),
                                      new SqlParameter("@id",model.ID)
                                      };
            rowcount = helper.ExecuteSql(sqltxt, paramter);
            return rowcount;
        }
        /// <summary>
        /// 反审文章
        /// </summary>
        /// <param name="aid"></param>
        /// <param name="reason"></param>
        /// <returns></returns>
        public int AntiTrialArticle(ArticlesModel model)
        {
            int rowcount = 0;
            string sqltxt = @"UPDATE  dbo.Articles
SET     ArtStatus = 30 ,
        AntitrialReasons = @AntitrialReasons ,
        CheckUserID = @CheckUserID ,
        CheckUserName = @CheckUserName ,
        CheckTime = GETDATE()
WHERE   ID = @id";
            SqlParameter[] paramter = { 
                                      new SqlParameter("@AntitrialReasons",model.AntitrialReasons),
                                      new SqlParameter("@CheckUserID",model.CheckUserID),
                                      new SqlParameter("@CheckUserName",model.CheckUserName),
                                      new SqlParameter("@id",model.ID)
                                      };
            rowcount = helper.ExecuteSql(sqltxt, paramter);
            return rowcount;
        }
        #endregion
    }
}
