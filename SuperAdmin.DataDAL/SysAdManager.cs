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
WHERE   ID IN (" + ids+" )";
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
            SqlParameter[] paramter = { new SqlParameter("@id",ID)};
            DataTable dt = helper.Query(sqltxt,paramter).Tables[0];
            if (dt.Rows.Count > 0)
            {
                model.AdAddTime = DateTime.Parse(dt.Rows[0]["AdAddTime"].ToString());
                model.AdBackgroundPic = dt.Rows[0]["AdBackgroundPic"].ToString();
                model.AddUserID = int.Parse(dt.Rows[0]["AddUserID"].ToString());
                model.AddUserName = dt.Rows[0]["AddUserName"].ToString();
                model.AdHeight = int.Parse(dt.Rows[0]["AdHeight"].ToString());
                model.AdLinkUrl = dt.Rows[0]["AdLinkUrl"].ToString();
                model.AdPic = dt.Rows[0]["AdPic"].ToString();
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
            rowcount = helper.ExecuteSql(sqltxt,paramter);
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
            rowcount = helper.ExecuteSql(sqltxt,paramter);
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
SET     AdStatus = 0
WHERE   id = @id";
            SqlParameter[] paramter = { new SqlParameter("@id",id)};
            rowcount = helper.ExecuteSql(sqltxt,paramter);
            return rowcount;
        }
        #endregion

        #region 系统广告位置

        #endregion

        #region 系统广告排期

        #endregion
    }
}
