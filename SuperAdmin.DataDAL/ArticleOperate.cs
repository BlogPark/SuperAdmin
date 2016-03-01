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

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int AddArticle(ArticlesModel model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into Articles(");
            strSql.Append("ArtTags,ArtPublishTime,ArtStatus,ArtType,ArtFavoriteCount,ArtCommentCount,ArtHitCount,ArtIsAlbum,ArtAlbumJson,ArtOuterchain,ArtTitle,ArtFrom,ArtFromUrl,AntitrialReasons,AddTime,ArtCID,ArtCName,ArtIsTop,MemberID,ArtUserTags,MemberName,ArtPic,ArtPicWidth,ArtPicHeight,ArtSummary,ArtContent");
            strSql.Append(") values (");
            strSql.Append("@ArtTags,@ArtPublishTime,@ArtStatus,@ArtType,@ArtFavoriteCount,@ArtCommentCount,@ArtHitCount,@ArtIsAlbum,@ArtAlbumJson,@ArtOuterchain,@ArtTitle,@ArtFrom,@ArtFromUrl,@AntitrialReasons,@AddTime,@ArtCID,@ArtCName,@ArtIsTop,@MemberID,@ArtUserTags,@MemberName,@ArtPic,@ArtPicWidth,@ArtPicHeight,@ArtSummary,@ArtContent");
            strSql.Append(") ");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
			            new SqlParameter("@ArtTags", SqlDbType.NVarChar) ,            
                        new SqlParameter("@ArtPublishTime", SqlDbType.DateTime) ,            
                        new SqlParameter("@ArtStatus", SqlDbType.Int) ,            
                        new SqlParameter("@ArtType", SqlDbType.Int) ,            
                        new SqlParameter("@ArtFavoriteCount", SqlDbType.Int) ,            
                        new SqlParameter("@ArtCommentCount", SqlDbType.Int) ,            
                        new SqlParameter("@ArtHitCount", SqlDbType.Int) ,            
                        new SqlParameter("@ArtIsAlbum", SqlDbType.Int) ,            
                        new SqlParameter("@ArtAlbumJson", SqlDbType.NVarChar) ,            
                        new SqlParameter("@ArtOuterchain", SqlDbType.NVarChar) ,            
                        new SqlParameter("@ArtTitle", SqlDbType.NVarChar) ,            
                        new SqlParameter("@ArtFrom", SqlDbType.NVarChar) ,            
                        new SqlParameter("@ArtFromUrl", SqlDbType.NVarChar) ,            
                        new SqlParameter("@AntitrialReasons", SqlDbType.NVarChar) ,      
                        new SqlParameter("@AddTime", SqlDbType.DateTime) ,            
                        new SqlParameter("@ArtCID", SqlDbType.Int) ,            
                        new SqlParameter("@ArtCName", SqlDbType.NVarChar) ,            
                        new SqlParameter("@ArtIsTop", SqlDbType.Int) ,            
                        new SqlParameter("@MemberID", SqlDbType.Int) ,            
                        new SqlParameter("@ArtUserTags", SqlDbType.NVarChar) ,            
                        new SqlParameter("@MemberName", SqlDbType.NVarChar) ,            
                        new SqlParameter("@ArtPic", SqlDbType.NVarChar) ,            
                        new SqlParameter("@ArtPicWidth", SqlDbType.Int) ,            
                        new SqlParameter("@ArtPicHeight", SqlDbType.Int) ,            
                        new SqlParameter("@ArtSummary", SqlDbType.NVarChar) ,            
                        new SqlParameter("@ArtContent", SqlDbType.NVarChar)       
            };
            parameters[0].Value = model.ArtUserTags;//model.ArtTags;//在没有建设好关键词库之前  先记入用户自己填写的关键词
            parameters[1].Value = model.ArtPublishTime;
            parameters[2].Value = model.ArtStatus;
            parameters[3].Value = model.ArtType;
            parameters[4].Value = model.ArtFavoriteCount;
            parameters[5].Value = model.ArtCommentCount;
            parameters[6].Value = model.ArtHitCount;
            parameters[7].Value = model.ArtIsAlbum;
            parameters[8].Value = model.ArtAlbumJson;
            parameters[9].Value = model.ArtOuterchain;
            parameters[10].Value = model.ArtTitle;
            parameters[11].Value = model.ArtFrom;
            parameters[12].Value = model.ArtFromUrl;
            parameters[13].Value = model.AntitrialReasons;
            parameters[14].Value = model.AddTime;
            parameters[15].Value = model.ArtCID;
            parameters[16].Value = model.ArtCName;
            parameters[17].Value = model.ArtIsTop;
            parameters[18].Value = model.MemberID;
            parameters[19].Value = model.ArtUserTags;
            parameters[20].Value = model.MemberName;
            parameters[21].Value = model.ArtPic;
            parameters[22].Value = model.ArtPicWidth;
            parameters[23].Value = model.ArtPicHeight;
            parameters[24].Value = model.ArtSummary;
            parameters[25].Value = model.ArtContent;
            object obj = helper.GetSingle(strSql.ToString(), parameters);
            if (obj == null)
            {
                return 0;
            }
            else
            {
                return Convert.ToInt32(obj);
            }
        }
        /// <summary>
        /// 更新一条文章信息
        /// </summary>
        public bool UpdateArticle(ArticlesModel model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Articles set ");
            strSql.Append(" ArtTags = @ArtTags , ");
            strSql.Append(" ArtPublishTime = @ArtPublishTime , ");
            strSql.Append(" ArtStatus = @ArtStatus , ");
            strSql.Append(" ArtType = @ArtType , ");
            strSql.Append(" ArtFavoriteCount = @ArtFavoriteCount , ");
            strSql.Append(" ArtCommentCount = @ArtCommentCount , ");
            strSql.Append(" ArtHitCount = @ArtHitCount , ");
            strSql.Append(" ArtIsAlbum = @ArtIsAlbum , ");
            strSql.Append(" ArtAlbumJson = @ArtAlbumJson , ");
            strSql.Append(" ArtOuterchain = @ArtOuterchain , ");
            strSql.Append(" ArtTitle = @ArtTitle , ");
            strSql.Append(" ArtFrom = @ArtFrom , ");
            strSql.Append(" ArtFromUrl = @ArtFromUrl , ");
            strSql.Append(" AntitrialReasons = @AntitrialReasons , ");
            strSql.Append(" CheckUserID = @CheckUserID , ");
            strSql.Append(" CheckUserName = @CheckUserName , ");
            strSql.Append(" CheckTime = @CheckTime , ");
            strSql.Append(" AddTime = @AddTime , ");
            strSql.Append(" ArtCID = @ArtCID , ");
            strSql.Append(" ArtCName = @ArtCName , ");
            strSql.Append(" ArtIsTop = @ArtIsTop , ");
            strSql.Append(" MemberID = @MemberID , ");
            strSql.Append(" ArtUserTags = @ArtUserTags , ");
            strSql.Append(" MemberName = @MemberName , ");
            strSql.Append(" ArtPic = @ArtPic , ");
            strSql.Append(" ArtPicWidth = @ArtPicWidth , ");
            strSql.Append(" ArtPicHeight = @ArtPicHeight , ");
            strSql.Append(" ArtSummary = @ArtSummary , ");
            strSql.Append(" ArtContent = @ArtContent  ");
            strSql.Append(" where ID=@ID ");

            SqlParameter[] parameters = {
			            new SqlParameter("@ID", SqlDbType.Int) ,            
                        new SqlParameter("@ArtTags", SqlDbType.NVarChar) ,            
                        new SqlParameter("@ArtPublishTime", SqlDbType.DateTime) ,            
                        new SqlParameter("@ArtStatus", SqlDbType.Int) ,            
                        new SqlParameter("@ArtType", SqlDbType.Int) ,            
                        new SqlParameter("@ArtFavoriteCount", SqlDbType.Int) ,            
                        new SqlParameter("@ArtCommentCount", SqlDbType.Int) ,            
                        new SqlParameter("@ArtHitCount", SqlDbType.Int) ,            
                        new SqlParameter("@ArtIsAlbum", SqlDbType.Int) ,            
                        new SqlParameter("@ArtAlbumJson", SqlDbType.NVarChar) ,            
                        new SqlParameter("@ArtOuterchain", SqlDbType.NVarChar) ,            
                        new SqlParameter("@ArtTitle", SqlDbType.NVarChar) ,            
                        new SqlParameter("@ArtFrom", SqlDbType.NVarChar) ,            
                        new SqlParameter("@ArtFromUrl", SqlDbType.NVarChar) ,            
                        new SqlParameter("@AntitrialReasons", SqlDbType.NVarChar) ,            
                        new SqlParameter("@CheckUserID", SqlDbType.Int) ,            
                        new SqlParameter("@CheckUserName", SqlDbType.NVarChar) ,            
                        new SqlParameter("@CheckTime", SqlDbType.DateTime) ,            
                        new SqlParameter("@AddTime", SqlDbType.DateTime) ,            
                        new SqlParameter("@ArtCID", SqlDbType.Int) ,            
                        new SqlParameter("@ArtCName", SqlDbType.NVarChar) ,            
                        new SqlParameter("@ArtIsTop", SqlDbType.Int) ,            
                        new SqlParameter("@MemberID", SqlDbType.Int) ,            
                        new SqlParameter("@ArtUserTags", SqlDbType.NVarChar) ,            
                        new SqlParameter("@MemberName", SqlDbType.NVarChar) ,            
                        new SqlParameter("@ArtPic", SqlDbType.NVarChar) ,            
                        new SqlParameter("@ArtPicWidth", SqlDbType.Int) ,            
                        new SqlParameter("@ArtPicHeight", SqlDbType.Int) ,            
                        new SqlParameter("@ArtSummary", SqlDbType.NVarChar) ,            
                        new SqlParameter("@ArtContent", SqlDbType.NVarChar)       
            };
            parameters[0].Value = model.ID;
            parameters[1].Value = model.ArtTags;
            parameters[2].Value = model.ArtPublishTime;
            parameters[3].Value = model.ArtStatus;
            parameters[4].Value = model.ArtType;
            parameters[5].Value = model.ArtFavoriteCount;
            parameters[6].Value = model.ArtCommentCount;
            parameters[7].Value = model.ArtHitCount;
            parameters[8].Value = model.ArtIsAlbum;
            parameters[9].Value = model.ArtAlbumJson;
            parameters[10].Value = model.ArtOuterchain;
            parameters[11].Value = model.ArtTitle;
            parameters[12].Value = model.ArtFrom;
            parameters[13].Value = model.ArtFromUrl;
            parameters[14].Value = model.AntitrialReasons;
            parameters[15].Value = model.CheckUserID;
            parameters[16].Value = model.CheckUserName;
            parameters[17].Value = model.CheckTime;
            parameters[18].Value = model.AddTime;
            parameters[19].Value = model.ArtCID;
            parameters[20].Value = model.ArtCName;
            parameters[21].Value = model.ArtIsTop;
            parameters[22].Value = model.MemberID;
            parameters[23].Value = model.ArtUserTags;
            parameters[24].Value = model.MemberName;
            parameters[25].Value = model.ArtPic;
            parameters[26].Value = model.ArtPicWidth;
            parameters[27].Value = model.ArtPicHeight;
            parameters[28].Value = model.ArtSummary;
            parameters[29].Value = model.ArtContent;
            int rows = helper.ExecuteSql(strSql.ToString(), parameters);
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        #endregion
    }
}
