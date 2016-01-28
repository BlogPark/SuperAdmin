using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SuperAdmin.datamodel;

namespace SuperAdmin.DataDAL
{
    /// <summary>
    /// 系统广告管理
    /// </summary>
    public class SysAdManager
    {
        DbHelperSQL helper = new DbHelperSQL();
        /// <summary>
        /// 得到系统所有的平台信息
        /// </summary>
        /// <returns></returns>
        public List<SystemAdSiteModel> GetAllSysSites()
        {
            List<SystemAdSiteModel> list = new List<SystemAdSiteModel>();
            string sqltxt = @"SELECT  ID ,
        AdSiteName ,
        AdSiteState
FROM    dbo.SystemAdSite";
            DataTable dt = helper.Query(sqltxt).Tables[0];
            foreach (DataRow item in dt.Rows)
            {
                SystemAdSiteModel model = new SystemAdSiteModel();
                model.AdSiteName = item["AdSiteName"].ToString();
                model.AdSiteState = int.Parse(item["AdSiteState"].ToString());
                model.ID = int.Parse(item["ID"].ToString());
                list.Add(model);
            }
            return list;
        }

        #region 系统广告
        /// <summary>
        /// 查询所有的广告内容
        /// </summary>
        /// <returns></returns>
        public List<SystemAdModel> GetAllSystemAd()
        {
            List<SystemAdModel> list = new List<SystemAdModel>();
            string sqltxt = @"SELECT  ID ,
        AdTitle ,
        AdType ,
        AdWidth ,
        AdHeight ,
        AdSummary ,
        AdPic ,
        AdBackgroundPic ,
        AdLinkUrl ,
        AdSourceCode ,
        AdRemark ,
        AdStatus ,
        AdAddTime ,
        AdSiteID ,
        AdSiteName ,
        AddUserID ,
        AddUserName,
        CASE AdStatus
          WHEN 0 THEN '禁用'
          WHEN 1 THEN '启用'
        END AS AdStatusName
FROM  dbo.SystemAd WITH(NOLOCK)";
            DataTable dt = helper.Query(sqltxt).Tables[0];
            foreach (DataRow item in dt.Rows)
            {
                SystemAdModel model = new SystemAdModel();
                model.AdAddTime = DateTime.Parse(item["AdAddTime"].ToString());
                model.AdBackgroundPic = item["AdBackgroundPic"].ToString();
                model.AddUserID = int.Parse(item["AddUserID"].ToString());
                model.AddUserName = item["AddUserName"].ToString();
                model.AdHeight = int.Parse(item["AdHeight"].ToString());
                model.AdLinkUrl = item["AdLinkUrl"].ToString();
                model.AdPic = item["AdPic"].ToString();
                model.AdRemark = item["AdRemark"].ToString();
                model.AdSiteID = int.Parse(item["AdSiteID"].ToString());
                model.AdSiteName = item["AdSiteName"].ToString();
                model.AdSourceCode = item["AdSourceCode"].ToString();
                model.AdStatus = int.Parse(item["AdStatus"].ToString());
                model.AdSummary = item["AdSummary"].ToString();
                model.AdTitle = item["AdTitle"].ToString();
                model.AdType = int.Parse(item["AdType"].ToString());
                model.AdWidth = int.Parse(item["AdWidth"].ToString());
                model.ID = int.Parse(item["ID"].ToString());
                model.AdStatusName = item["AdStatusName"].ToString();
                list.Add(model);
            }
            return list;
        }
        /// <summary>
        /// 根据ID列表查询
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        public List<SystemAdModel> GetSystemAdByID(string ids)
        {
            List<SystemAdModel> list = new List<SystemAdModel>();
            string sqltxt = @"SELECT  ID ,
        AdTitle ,
        AdType ,
        AdWidth ,
        AdHeight ,
        AdSummary ,
        AdPic ,
        AdBackgroundPic ,
        AdLinkUrl ,
        AdSourceCode ,
        AdRemark ,
        AdStatus ,
        AdAddTime ,
        AdSiteID ,
        AdSiteName ,
        AddUserID ,
        AddUserName,
        CASE AdStatus
          WHEN 0 THEN '禁用'
          WHEN 1 THEN '启用'
        END AS AdStatusName
FROM    dbo.SystemAd
WHERE   ID IN (" + ids + " )";
            DataTable dt = helper.Query(sqltxt).Tables[0];
            foreach (DataRow item in dt.Rows)
            {
                SystemAdModel model = new SystemAdModel();
                model.AdAddTime = DateTime.Parse(item["AdAddTime"].ToString());
                model.AdBackgroundPic = item["AdBackgroundPic"].ToString();
                model.AddUserID = int.Parse(item["AddUserID"].ToString());
                model.AddUserName = item["AddUserName"].ToString();
                model.AdHeight = int.Parse(item["AdHeight"].ToString());
                model.AdLinkUrl = item["AdLinkUrl"].ToString();
                model.AdPic = item["AdPic"].ToString();
                model.AdRemark = item["AdRemark"].ToString();
                model.AdSiteID = int.Parse(item["AdSiteID"].ToString());
                model.AdSiteName = item["AdSiteName"].ToString();
                model.AdSourceCode = item["AdSourceCode"].ToString();
                model.AdStatus = int.Parse(item["AdStatus"].ToString());
                model.AdSummary = item["AdSummary"].ToString();
                model.AdTitle = item["AdTitle"].ToString();
                model.AdType = int.Parse(item["AdType"].ToString());
                model.AdWidth = int.Parse(item["AdWidth"].ToString());
                model.ID = int.Parse(item["ID"].ToString());
                model.AdStatusName = item["AdStatusName"].ToString();
                list.Add(model);
            }
            return list;
        }
        /// <summary>
        /// 根据ID查询广告信息
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        public SystemAdModel GetSingleSystemAd(int ID)
        {
            SystemAdModel model = new SystemAdModel();
            string sqltxt = @"SELECT  ID ,
        AdTitle ,
        AdType ,
        AdWidth ,
        AdHeight ,
        AdSummary ,
        AdPic ,
        AdBackgroundPic ,
        AdLinkUrl ,
        AdSourceCode ,
        AdRemark ,
        AdStatus ,
        AdAddTime ,
        AdSiteID ,
        AdSiteName ,
        AddUserID ,
        AddUserName,
        CASE AdStatus
          WHEN 0 THEN '禁用'
          WHEN 1 THEN '启用'
        END AS AdStatusName
FROM    dbo.SystemAd
WHERE   ID = @id";
            SqlParameter[] paramter = { new SqlParameter("@id", ID) };
            DataTable dt = helper.Query(sqltxt, paramter).Tables[0];
            if (dt.Rows.Count > 0)
            {
                model.AdAddTime = DateTime.Parse(dt.Rows[0]["AdAddTime"].ToString());
                model.AdBackgroundPic = string.IsNullOrWhiteSpace(dt.Rows[0]["AdBackgroundPic"].ToString()) ? "" : appcontent.Imgdomain + dt.Rows[0]["AdBackgroundPic"].ToString();
                model.AddUserID = int.Parse(dt.Rows[0]["AddUserID"].ToString());
                model.AddUserName = dt.Rows[0]["AddUserName"].ToString();
                model.AdHeight = int.Parse(dt.Rows[0]["AdHeight"].ToString());
                model.AdLinkUrl = dt.Rows[0]["AdLinkUrl"].ToString();
                model.AdPic = string.IsNullOrWhiteSpace(dt.Rows[0]["AdPic"].ToString()) ? "" : appcontent.Imgdomain + dt.Rows[0]["AdPic"].ToString();
                model.AdRemark = dt.Rows[0]["AdRemark"].ToString();
                model.AdSiteID = int.Parse(dt.Rows[0]["AdSiteID"].ToString());
                model.AdSiteName = dt.Rows[0]["AdSiteName"].ToString();
                model.AdSourceCode = dt.Rows[0]["AdSourceCode"].ToString();
                model.AdStatus = int.Parse(dt.Rows[0]["AdStatus"].ToString());
                model.AdSummary = dt.Rows[0]["AdSummary"].ToString();
                model.AdTitle = dt.Rows[0]["AdTitle"].ToString();
                model.AdType = int.Parse(dt.Rows[0]["AdType"].ToString());
                model.AdWidth = int.Parse(dt.Rows[0]["AdWidth"].ToString());
                model.ID = int.Parse(dt.Rows[0]["ID"].ToString());
                model.AdStatusName = dt.Rows[0]["AdStatusName"].ToString();
            }
            return model;
        }
        /// <summary>
        /// 添加系统广告内容
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int AddNewSystemAd(SystemAdModel model)
        {
            int rowcount = 0;
            string sqltxt = @"INSERT  INTO dbo.SystemAd
        ( AdTitle ,
          AdType ,
          AdWidth ,
          AdHeight ,
          AdSummary ,
          AdPic ,
          AdBackgroundPic ,
          AdLinkUrl ,
          AdSourceCode ,
          AdRemark ,
          AdStatus ,
          AdAddTime ,
          AdSiteID ,
          AdSiteName ,
          AddUserID ,
          AddUserName
        )
VALUES  ( @AdTitle ,
          @AdType ,
          @AdWidth ,
          @AdHeight ,
          @AdSummary ,
          @AdPic ,
          @AdBackgroundPic ,
          @AdLinkUrl ,
          @AdSourceCode ,
          @AdRemark ,
          @AdStatus ,
          GETDATE(),
          @AdSiteID ,
          @AdSiteName ,
          @AddUserID ,
          @AddUserName
        )";
            SqlParameter[] paramter = { 
                                      new SqlParameter("@AdTitle",model.AdTitle),
                                      new SqlParameter("@AdType",model.AdType),
                                      new SqlParameter("@AdWidth",model.AdWidth),
                                      new SqlParameter("@AdHeight",model.AdHeight),
                                      new SqlParameter("@AdSummary",model.AdSummary),
                                      new SqlParameter("@AdPic",model.AdPic),
                                      new SqlParameter("@AdBackgroundPic",model.AdBackgroundPic),
                                      new SqlParameter("@AdLinkUrl",model.AdLinkUrl),
                                      new SqlParameter("@AdSourceCode",model.AdSourceCode),
                                      new SqlParameter("@AdRemark",model.AdRemark),
                                      new SqlParameter("@AdStatus",model.AdStatus),
                                      new SqlParameter("@AdSiteID",model.AdSiteID),
                                      new SqlParameter("@AdSiteName",model.AdSiteName),
                                      new SqlParameter("@AddUserID",model.AddUserID),
                                      new SqlParameter("@AddUserName",model.AddUserName)
                                      };
            rowcount = helper.ExecuteSql(sqltxt, paramter);
            return rowcount;
        }
        /// <summary>
        /// 修改广告内容
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int UpdateSystemAd(SystemAdModel model)
        {
            int rowcount = 0;
            string sqltxt = @"UPDATE  dbo.SystemAd
SET     AdTitle = @AdTitle ,
        AdType = @AdType ,
        AdWidth = @AdWidth ,
        AdHeight = @AdHeight ,
        AdSummary = @AdSummary ,
        AdPic = @AdPic ,
        AdBackgroundPic = @AdBackgroundPic ,
        AdLinkUrl = @AdLinkUrl ,
        AdSourceCode = @AdSourceCode ,
        AdRemark = @AdRemark ,
        AdStatus = @AdStatus ,
        AdSiteID = @AdSiteID ,
        AdSiteName = @AdSiteName ,
        AddUserID = @AddUserID ,
        AddUserName = @AddUserName
WHERE   id = @id";
            SqlParameter[] paramter = {
                                          new SqlParameter("@id",model.ID),
                                          new SqlParameter("@AdTitle",model.AdTitle),
                                          new SqlParameter("@AdType",model.AdType),
                                          new SqlParameter("@AdWidth",model.AdWidth),
                                          new SqlParameter("@AdHeight",model.AdHeight),
                                          new SqlParameter("@AdSummary",model.AdSummary),
                                          new SqlParameter("@AdPic",model.AdPic.Replace(appcontent.Imgdomain,"")),
                                          new SqlParameter("@AdBackgroundPic",model.AdBackgroundPic.Replace(appcontent.Imgdomain,"")),
                                          new SqlParameter("@AdLinkUrl",model.AdLinkUrl),
                                          new SqlParameter("@AdSourceCode",model.AdSourceCode),
                                          new SqlParameter("@AdRemark",model.AdRemark),
                                          new SqlParameter("@AdStatus",model.AdStatus),
                                          new SqlParameter("@AdSiteID",model.AdSiteID),
                                          new SqlParameter("@AdSiteName",model.AdSiteName),
                                          new SqlParameter("@AddUserID",model.AddUserID),
                                          new SqlParameter("@AddUserName",model.AddUserName)
                                    };
            rowcount = helper.ExecuteSql(sqltxt, paramter);
            return rowcount;
        }
        /// <summary>
        /// 删除一条广告信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public int DeleteSystemAd(int id)
        {
            int rowcount = 0;
            string sqltxt = @"UPDATE  dbo.SystemAd
SET     AdStatus = CASE AdStatus
                     WHEN 0 THEN 1
                     WHEN 1 THEN 0
                   END
WHERE   id = @id";
            SqlParameter[] paramter = { new SqlParameter("@id", id) };
            rowcount = helper.ExecuteSql(sqltxt, paramter);
            return rowcount;
        }
        #endregion

        #region 系统广告位置
        /// <summary>
        /// 得到所有的广告位置
        /// </summary>
        /// <param name="isneeduse">是否只读取激活的信息</param>
        /// <returns></returns>
        public List<SystemAdPositionModel> GetAllAdPosition(bool isneeduse = false)
        {
            List<SystemAdPositionModel> list = new List<SystemAdPositionModel>();
            string sqltxt = @"SELECT  ID ,
        PName ,
        AdSiteID ,
        AdSiteName ,
        PWidth ,
        PHeight ,
        PType,PStatus
FROM    dbo.SystemAdPosition";
            if (isneeduse)
            { sqltxt += " WHERE PStatus=1 "; }
            DataTable dt = helper.Query(sqltxt).Tables[0];
            foreach (DataRow item in dt.Rows)
            {
                SystemAdPositionModel model = new SystemAdPositionModel();
                model.AdSiteID = int.Parse(item["AdSiteID"].ToString());
                model.AdSiteName = item["AdSiteName"].ToString();
                model.ID = int.Parse(item["ID"].ToString());
                model.PHeight = int.Parse(item["PHeight"].ToString());
                model.PName = item["PName"].ToString();
                model.PStatus = int.Parse(item["PStatus"].ToString()); ;
                model.PType = int.Parse(item["PType"].ToString());
                model.PWidth = int.Parse(item["PWidth"].ToString());
                list.Add(model);
            }
            return list;
        }
        /// <summary>
        /// 添加一个广告位置
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int AddSysAdPosition(SystemAdPositionModel model)
        {
            int rowcount = 0;
            string sqltxt = @"INSERT  INTO  dbo.SystemAdPosition
        ( PName ,
          AdSiteID ,
          AdSiteName ,
          PWidth ,
          PHeight ,
          PType ,
          PStatus
        )
VALUES  ( @PName ,
          @AdSiteID ,
          @AdSiteName ,
          @PWidth ,
          @PHeight ,
          @PType ,
          @PStatus
        )";
            SqlParameter[] paramter = { 
                                      new SqlParameter("@PName",model.PName),
                                      new SqlParameter("@AdSiteID",model.AdSiteID),
                                      new SqlParameter("@AdSiteName",model.AdSiteName),
                                      new SqlParameter("@PWidth",model.PWidth),
                                      new SqlParameter("@PHeight",model.PHeight),
                                      new SqlParameter("@PType",model.PType),
                                      new SqlParameter("@PStatus",model.PStatus)
                                      };
            rowcount = helper.ExecuteSql(sqltxt, paramter);
            return rowcount;
        }
        /// <summary>
        /// 添加一个广告位置
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int UpdateSysAdPosition(SystemAdPositionModel model)
        {
            int rowcount = 0;
            string sqltxt = @"UPDATE  dbo.SystemAdPosition
SET     PName = @PName ,
        AdSiteID = @AdSiteID ,
        AdSiteName = @AdSiteName ,
        PWidth = @PWidth ,
        PHeight = @PHeight ,
        PType = @PType 
WHERE   ID = @ID";
            SqlParameter[] paramter = { 
                                      new SqlParameter("@PName",model.PName),
                                      new SqlParameter("@AdSiteID",model.AdSiteID),
                                      new SqlParameter("@AdSiteName",model.AdSiteName),
                                      new SqlParameter("@PWidth",model.PWidth),
                                      new SqlParameter("@PHeight",model.PHeight),
                                      new SqlParameter("@PType",model.PType),
                                      new SqlParameter("@ID",model.ID)
                                      };
            rowcount = helper.ExecuteSql(sqltxt, paramter);
            return rowcount;
        }
        /// <summary>
        /// 更改广告位置状态值
        /// </summary>
        /// <param name="id"></param>
        /// <param name="status"></param>
        /// <returns></returns>
        public int UpdateAdPositionStatus(int id, int status)
        {
            int rowcount = 0;
            string sqltxt = @"UPDATE  dbo.SystemAdPosition
SET      PStatus = @PStatus
WHERE   ID = @ID";
            SqlParameter[] paramter = {                                     
                                      new SqlParameter("@PStatus",status),
                                      new SqlParameter("@ID",id)
                                      };
            rowcount = helper.ExecuteSql(sqltxt, paramter);
            return rowcount;
        }
        /// <summary>
        /// 根据信息得到一条单独信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public SystemAdPositionModel GetSinglePositionByID(int id)
        {
            SystemAdPositionModel model = new SystemAdPositionModel();
            string sqltxt = @"SELECT  ID ,
        PName ,
        AdSiteID ,
        AdSiteName ,
        PWidth ,
        PHeight ,
        PType ,
        PStatus
FROM    dbo.SystemAdPosition
WHERE   id = @id ";
            SqlParameter[] paramter = { new SqlParameter("@id",id)};
            DataTable dt = helper.Query(sqltxt,paramter).Tables[0];
            if (dt.Rows.Count > 0)
            {
                model.AdSiteID = int.Parse(dt.Rows[0]["AdSiteID"].ToString());
                model.AdSiteName = dt.Rows[0]["AdSiteName"].ToString();
                model.ID = int.Parse(dt.Rows[0]["ID"].ToString());
                model.PHeight = int.Parse(dt.Rows[0]["PHeight"].ToString());
                model.PName = dt.Rows[0]["PName"].ToString();
                model.PStatus = int.Parse(dt.Rows[0]["PStatus"].ToString());
                model.PType = int.Parse(dt.Rows[0]["PType"].ToString());
                model.PWidth = int.Parse(dt.Rows[0]["PWidth"].ToString());
            }
            return model;
        }
        #endregion

        #region 系统广告排期

        #endregion
    }
}
