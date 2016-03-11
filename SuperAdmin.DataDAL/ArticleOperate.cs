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
        ArtPicWidth ,
        ArtPicHeight ,
        ArtSummary ,
        ArtContent ,
        ArtTags ,
        ArtPublishTime ,
        ArtType ,
        ArtFavoriteCount ,
        ArtCommentCount ,
        ArtHitCount ,
        ArtIsAlbum ,
        ArtOuterchain ,
        ArtFrom ,
        ArtFromUrl ,
        AddTime ,
        ArtCID ,
        ArtCName ,
        ArtIsTop ,
        ArtUserTags,
       ArtStatus,
        CASE ArtStatus
          WHEN 10 THEN '待审核'
          WHEN 20 THEN '已审核'
          WHEN 30 THEN '已删除'
        END AS ArtStatusName ,
        CASE ArtType
          WHEN 1 THEN '原创文章'
          WHEN 2 THEN '原创图集'
          WHEN 3 THEN '广告软文'
          WHEN 4 THEN '引用文章'
          WHEN 5 THEN '引用图集'
        END AS ArtTypeName 
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
                model.ArtPublishTime = DateTime.Parse(dt.Rows[0]["ArtPublishTime"].ToString());
                model.ArtStatus = int.Parse(dt.Rows[0]["ArtStatus"].ToString());
                model.ArtStatusName = dt.Rows[0]["ArtStatusName"].ToString();
                model.ArtType = int.Parse(dt.Rows[0]["ArtType"].ToString());
                model.ArtTypeName = dt.Rows[0]["ArtTypeName"].ToString();
                model.AddTime = DateTime.Parse(dt.Rows[0]["AddTime"].ToString());
                model.ArtCID = int.Parse(dt.Rows[0]["ArtCID"].ToString());
                model.ArtCName = dt.Rows[0]["ArtCName"].ToString();
                model.ArtContent = dt.Rows[0]["ArtContent"].ToString();
                model.ArtPic = string.IsNullOrWhiteSpace(dt.Rows[0]["ArtPic"].ToString()) ? "" : appcontent.Imgdomain + dt.Rows[0]["ArtPic"];
                model.ArtSummary = dt.Rows[0]["ArtSummary"].ToString();
                model.ArtPicWidth = Convert.ToInt32(dt.Rows[0]["ArtPicWidth"]);
                model.ArtPicHeight = Convert.ToInt32(dt.Rows[0]["ArtPicHeight"]);
                model.ArtUserTags = dt.Rows[0]["ArtUserTags"].ToString();
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

        /// <summary>
        /// 查询文章信息（分页）
        /// </summary>
        /// <param name="wheremodel">查询条件</param>
        /// <param name="pageindex">页索引</param>
        /// <param name="pagesize">页容量</param>
        /// <param name="totalrowCount">总数</param>
        /// <param name="pageCount">总页数</param>
        /// <returns></returns>
        public List<ArticlesModel> GetArticleDataBypage(ArticlesModel wheremodel, int pageindex, int pagesize, out int totalrowCount, out int pageCount)
        {
            List<ArticlesModel> list = new List<ArticlesModel>();
            totalrowCount = 0;
            pageCount = 0;
            var totalrowcountpram = new SqlParameter("@totalrowcount", System.Data.SqlDbType.Int);
            totalrowcountpram.Direction = System.Data.ParameterDirection.Output;
            var pageCountParam = new SqlParameter("@pageCount", System.Data.SqlDbType.Int);
            pageCountParam.Direction = System.Data.ParameterDirection.Output;
            SqlParameter[] paramter = new[] { 
            new SqlParameter("@pageindex",pageindex),
            new SqlParameter("@pagesize",pagesize),
            new SqlParameter("@starttime",wheremodel.StarTime),
            new SqlParameter("@endtime",wheremodel.EndTime),
            new SqlParameter("@statusnum",wheremodel.ArtStatus),
             new SqlParameter("@aid",wheremodel.ID),
            new SqlParameter("@arttitle",wheremodel.ArtTitle),
            new SqlParameter("@memberID",wheremodel.MemberID),
            new SqlParameter("@arttypeid",wheremodel.ArtType),
            new SqlParameter("@artcid",wheremodel.ArtCID),
            totalrowcountpram,
            pageCountParam
            };
            DataSet ds = helper.RunProcedureDataSet("SeleArticleByPage", paramter);
            if (ds != null && ds.Tables.Count > 0)
            {
                int statusVal = 0;
                DataTable dt = ds.Tables[0];
                foreach (DataRow item in dt.Rows)
                {
                    statusVal = Convert.ToInt32(item["tStatus"]);
                    list.Add(new ArticlesModel
                    {
                        ID = Convert.ToInt32(item["ID"]),
                        MemberID = Convert.ToInt32(item["MemberID"]),
                        ArtTitle = Convert.ToString(item["ArtTitle"]),
                        MemberName = Convert.ToString(item["MemberName"]),
                        ArtPic = Convert.ToString(item["ArtPic"]),
                        ArtPicWidth = Convert.ToInt32(item["ArtPicWidth"]),
                        ArtPicHeight = Convert.ToInt32(item["ArtPicHeight"]),
                        ArtSummary = Convert.ToString(item["ArtSummary"]),
                        ArtContent = Convert.ToString(item["ArtContent"]),
                        ArtTags = Convert.ToString(item["ArtTags"]),
                        ArtPublishTime = Convert.ToDateTime(item["ArtPublishTime"]),
                        ArtType = Convert.ToInt32(item["ArtType"]),
                        ArtFavoriteCount = Convert.ToInt32(item["ArtFavoriteCount"]),
                        ArtCommentCount = Convert.ToInt32(item["ArtCommentCount"]),
                        ArtHitCount = Convert.ToInt32(item["ArtHitCount"]),
                        ArtFrom = Convert.ToString(item["ArtFrom"]),
                        ArtFromUrl = Convert.ToString(item["ArtFromUrl"]),
                        ArtOuterchain = Convert.ToString(item["ArtOuterchain"]),
                        AntitrialReasons = Convert.ToString(item["AntitrialReasons"]),
                        CheckUserID = Convert.ToInt32(item["CheckUserID"]),
                        CheckUserName = Convert.ToString(item["CheckUserName"]),
                        ArtCID = Convert.ToInt32(item["ArtCID"]),
                        ArtCName = Convert.ToString(item["ArtCName"]),
                        ArtIsTop = Convert.ToInt32(item["ArtIsTop"]),
                        ArtUserTags = Convert.ToString(item["ArtUserTags"]),
                        ArtTypeName = Convert.ToString(item["TypeName"])
                    });
                }
            }
            totalrowCount = Convert.ToInt32(totalrowcountpram.Value);
            pageCount = Convert.ToInt32(pageCountParam.Value);
            return list;
        }
        /// <summary>
        /// 根据ID列表得到所需文章列表
        /// </summary>
        /// <returns></returns>
        public List<ArticlesModel> GetAllArticlesbyids(string ids)
        {
            List<ArticlesModel> list = new List<ArticlesModel>();
            string sqltxt = @"SELECT  ID ,
        ArtTitle ,
        MemberID ,
        MemberName ,
        ArtPic ,
        ArtPicWidth ,
        ArtPicHeight ,
        ArtSummary ,
        ArtContent ,
        ArtTags ,
        ArtPublishTime ,
        ArtType ,
        ArtFavoriteCount ,
        ArtCommentCount ,
        ArtHitCount ,
        ArtIsAlbum ,
        ArtOuterchain ,
        ArtFrom ,
        ArtFromUrl ,
        AddTime ,
        ArtCID ,
        ArtCName ,
        ArtIsTop ,
        ArtUserTags,
       ArtStatus,
        CASE ArtStatus
          WHEN 10 THEN '待审核'
          WHEN 20 THEN '已审核'
          WHEN 30 THEN '已删除'
        END AS ArtStatusName ,
        CASE ArtType
          WHEN 1 THEN '原创文章'
          WHEN 2 THEN '原创图集'
          WHEN 3 THEN '广告软文'
          WHEN 4 THEN '引用文章'
          WHEN 5 THEN '引用图集'
        END AS ArtTypeName 
FROM    dbo.Articles
where ArtStatus=20 and ID In (" + ids.TrimEnd(',') + ")";
            DataTable dt = helper.Query(sqltxt).Tables[0];
            foreach (DataRow item in dt.Rows)
            {
                Dictionary<long, string> tagdic = new Dictionary<long, string>();
                string tags = item["ArtTags"].ToString();
                if (!string.IsNullOrWhiteSpace(tags))
                {
                    foreach (var tagitem in tags.Split(','))
                    {
                        string[] tag = tagitem.Split('|');
                        tagdic.Add(Convert.ToInt64(tag[0]), tag[1].ToString());
                    }
                }
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
                model.ArtContent = item["ArtContent"].ToString();
                model.ArtPic = string.IsNullOrWhiteSpace(item["ArtPic"].ToString()) ? "" : appcontent.Imgdomain + item["ArtPic"];
                model.ArtSummary = item["ArtSummary"].ToString();
                model.ArtPicWidth = Convert.ToInt32(item["ArtPicWidth"]);
                model.ArtPicHeight = Convert.ToInt32(item["ArtPicHeight"]);
                model.ArtUserTags = item["ArtUserTags"].ToString();
                model.Tags = tagdic;
                list.Add(model);
            }
            return list;
        }
        /// <summary>
        /// 得到文章和分类的对照
        /// </summary>
        /// <returns></returns>
        public Dictionary<int, List<string>> GetJobCategoryAndArticle()
        {
            Dictionary<int, List<string>> dic = new Dictionary<int, List<string>>();
            string sqltxt = @"SELECT  cateId ,articleids
FROM   dbo.JobCategory_Article";
            DataTable dt = helper.Query(sqltxt).Tables[0];
            foreach (DataRow item in dt.Rows)
            {
                int cate = Convert.ToInt32(item["cateId"]);
                string[] aids = item["articleids"].ToString().TrimEnd(',').Split(',');
                if (!dic.ContainsKey(cate))
                {
                    dic.Add(cate, aids.ToList());
                }
            }
            return dic;
        }
        /// <summary>
        /// 得到文章根据分类Id
        /// </summary>
        /// <returns></returns>
        public List<string> GetJobCategoryAndArticleByCateid(int cateid)
        {
            List<string> list = new List<string>();
            string sqltxt = @"SELECT  cateId ,articleids
FROM   dbo.JobCategory_Article
where cateId=@cateid";
            SqlParameter[] paramter = { new SqlParameter("@cateid", cateid) };
            DataTable dt = helper.Query(sqltxt, paramter).Tables[0];
            if (dt.Rows.Count > 0)
            {
                list = dt.Rows[0]["articleids"].ToString().TrimEnd(',').Split(',').ToList();
            }
            return list;
        }
        /// <summary>
        /// 得到推荐阅读的文章
        /// </summary>
        /// <param name="categoryids"></param>
        /// <param name="artids"></param>
        /// <returns></returns>
        public List<ArticlesModel> GetRecommendArticle(string categoryids, string artids)
        {
            List<ArticlesModel> list = new List<ArticlesModel>();
            string sqltxt = @"SELECT Top 11 ID ,
        ArtTitle ,
        MemberID ,
        MemberName ,
        ArtPic ,
        ArtPicWidth ,
        ArtPicHeight ,
        ArtSummary ,
        ArtContent ,
        ArtTags ,
        ArtPublishTime ,
        ArtType ,
        ArtFavoriteCount ,
        ArtCommentCount ,
        ArtHitCount ,
        ArtIsAlbum ,
        ArtOuterchain ,
        ArtFrom ,
        ArtFromUrl ,
        AddTime ,
        ArtCID ,
        ArtCName ,
        ArtIsTop ,
        ArtUserTags,
       ArtStatus,
        CASE ArtStatus
          WHEN 10 THEN '待审核'
          WHEN 20 THEN '已审核'
          WHEN 30 THEN '已删除'
        END AS ArtStatusName ,
        CASE ArtType
          WHEN 1 THEN '原创文章'
          WHEN 2 THEN '原创图集'
          WHEN 3 THEN '广告软文'
          WHEN 4 THEN '引用文章'
          WHEN 5 THEN '引用图集'
        END AS ArtTypeName 
FROM    dbo.Articles
where ArtStatus=20 and ArtPic <>'' and ArtCID IN (" + categoryids.TrimEnd(',') + ") AND ID NOT IN(" + artids.TrimEnd(',') + ")   ORDER BY ArtIsTop DESC,ID DESC";
            DataTable dt = helper.Query(sqltxt).Tables[0];
            foreach (DataRow item in dt.Rows)
            {
                Dictionary<long, string> tagdic = new Dictionary<long, string>();
                string tags = item["ArtTags"].ToString();
                if (!string.IsNullOrWhiteSpace(tags))
                {
                    foreach (var tagitem in tags.Split(','))
                    {
                        string[] tag = tagitem.Split('|');
                        tagdic.Add(Convert.ToInt64(tag[0]), tag[1].ToString());
                    }
                }
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
                model.ArtContent = item["ArtContent"].ToString();
                model.ArtPic = string.IsNullOrWhiteSpace(item["ArtPic"].ToString()) ? "" : appcontent.Imgdomain + item["ArtPic"];
                model.ArtSummary = item["ArtSummary"].ToString();
                model.ArtPicWidth = Convert.ToInt32(item["ArtPicWidth"]);
                model.ArtPicHeight = Convert.ToInt32(item["ArtPicHeight"]);
                model.ArtUserTags = item["ArtUserTags"].ToString();
                model.Tags = tagdic;
                list.Add(model);
            }
            return list;
        }
    }
}
