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
    /// 系统设置底层操作
    /// </summary>
    public class SystemSettings
    {
        DbHelperSQL helper = new DbHelperSQL();
        /// <summary>
        /// 得到所有的系统用户
        /// </summary>
        /// <returns></returns>
        public List<SysAdminUserModel> GetAllSysAdminUser()
        {
            List<SysAdminUserModel> list = new List<SysAdminUserModel>();
            string sqltxt = @"SELECT  ID ,
        UserName ,
        UserPwd ,
        UserStatus ,
        UserEmail ,
        TruethName ,
        UserPhone ,
        Question ,
        Answer ,
        GID ,
        GName ,
        LoginName ,
        HeaderImg ,
        CASE UserStatus
          WHEN 1 THEN '活动'
          ELSE '禁用'
        END AS UserStatusName,PinYin,FirstPinYin
FROM    dbo.SysAdminUser WITH ( NOLOCK )";
            DataTable dt = helper.Query(sqltxt).Tables[0];
            foreach (DataRow item in dt.Rows)
            {
                SysAdminUserModel model = new SysAdminUserModel();
                model.Answer = item["Answer"].ToString();
                model.GID = int.Parse(item["GID"].ToString());
                model.GName = item["GName"].ToString();
                model.HeaderImg = item["HeaderImg"].ToString();
                model.ID = int.Parse(item["ID"].ToString());
                model.LoginName = item["LoginName"].ToString();
                model.Question = item["Question"].ToString();
                model.TruethName = item["TruethName"].ToString();
                model.UserEmail = item["UserEmail"].ToString();
                model.UserName = item["UserName"].ToString();
                model.UserPhone = item["UserPhone"].ToString();
                model.UserPwd = item["UserPwd"].ToString();
                model.UserStatus = int.Parse(item["UserStatus"].ToString());
                model.UserStatusName = item["UserStatusName"].ToString();
                model.PinYin = item["PinYin"].ToString();
                model.FirstPinYin = item["FirstPinYin"].ToString();
                list.Add(model);
            }
            return list;
        }
        /// <summary>
        /// 根据ID查询系统用户信息
        /// </summary>
        /// <param name="userid"></param>
        /// <returns></returns>
        public SysAdminUserModel GetSingleAdminUser(int userid)
        {
            SysAdminUserModel model = new SysAdminUserModel();
            string sqltxt = @"SELECT  ID ,
        UserName ,
        UserPwd ,
        UserStatus ,
        UserEmail ,
        TruethName ,
        UserPhone ,
        Question ,
        Answer ,
        GID ,
        GName ,
        LoginName ,
        HeaderImg ,
        CASE UserStatus
          WHEN 1 THEN '活动'
          ELSE '禁用'
        END AS UserStatusName
FROM    dbo.SysAdminUser WITH ( NOLOCK )
WHERE ID=@id";
            SqlParameter[] paramter = { new SqlParameter("@id", userid) };
            DataTable dt = helper.Query(sqltxt, paramter).Tables[0];
            if (dt != null && dt.Rows.Count > 0)
            {
                model.Answer = dt.Rows[0]["Answer"].ToString();
                model.GID = int.Parse(dt.Rows[0]["GID"].ToString());
                model.GName = dt.Rows[0]["GName"].ToString();
                model.HeaderImg = dt.Rows[0]["HeaderImg"].ToString();
                model.ID = int.Parse(dt.Rows[0]["ID"].ToString());
                model.LoginName = dt.Rows[0]["LoginName"].ToString();
                model.Question = dt.Rows[0]["Question"].ToString();
                model.TruethName = dt.Rows[0]["TruethName"].ToString();
                model.UserEmail = dt.Rows[0]["UserEmail"].ToString();
                model.UserName = dt.Rows[0]["UserName"].ToString();
                model.UserPhone = dt.Rows[0]["UserPhone"].ToString();
                model.UserPwd = dt.Rows[0]["UserPwd"].ToString();
                model.UserStatus = int.Parse(dt.Rows[0]["UserStatus"].ToString());
                model.UserStatusName = dt.Rows[0]["UserStatusName"].ToString();
            }
            return model;
        }
        /// <summary>
        /// 新插入系统用户
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int AddNewSysAdminUser(SysAdminUserModel model)
        {
            int rowcount = 0;
            string sqltxt = @"INSERT  INTO dbo.SysAdminUser
        ( UserName ,
          UserPwd ,
          UserStatus ,
          UserEmail ,
          TruethName ,
          UserPhone ,
          Question ,
          Answer ,
          GID ,
          GName ,
          LoginName ,
          HeaderImg,
          PinYin,
          FirstPinYin
        )
VALUES  ( @UserName ,
          @UserPwd ,
          @UserStatus ,
          @UserEmail ,
          @TruethName ,
          @UserPhone ,
          @Question ,
          @Answer ,
          @GID ,
          @GName ,
          @LoginName ,
          @HeaderImg,
          @PinYin,
          @FirstPinYin
        )";
            SqlParameter[] paramter = { 
                                      new SqlParameter("@UserName",model.UserName),
                                      new SqlParameter("@UserPwd",model.UserPwd),
                                      new SqlParameter("@UserStatus",model.UserStatus),
                                      new SqlParameter("@UserEmail",model.UserEmail),
                                      new SqlParameter("@TruethName",model.TruethName),
                                      new SqlParameter("@UserPhone",model.UserPhone),
                                      new SqlParameter("@Question",model.Question),
                                      new SqlParameter("@Answer",model.Answer),
                                      new SqlParameter("@GID",model.GID),
                                      new SqlParameter("@GName",model.GName),
                                      new SqlParameter("@LoginName",model.LoginName),
                                      new SqlParameter("@HeaderImg",model.HeaderImg),
                                      new SqlParameter("@PinYin",model.PinYin),
                                      new SqlParameter("@FirstPinYin",model.FirstPinYin)
                                      };
            rowcount = helper.ExecuteSql(sqltxt, paramter);
            return rowcount;
        }
        /// <summary>
        /// 修改系统用户
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int UpdateSysAdminUser(SysAdminUserModel model)
        {
            int rowcount = 0;
            string sqltxt = @"UPDATE  dbo.SysAdminUser
SET     UserName = @UserName ,
        UserStatus = @UserStatus ,
        UserEmail = @UserEmail ,
        TruethName = @TruethName ,
        UserPhone = @UserPhone ,
        GID = @GID ,
        GName = @GName ,
        LoginName = @LoginName ,
        PinYin=@PinYin,
        FirstPinYin=@FirstPinYin
WHERE   ID = @id";
            SqlParameter[] paramter = { 
                                      new SqlParameter("@UserName",model.UserName),
                                      new SqlParameter("@UserPwd",model.UserPwd),
                                      new SqlParameter("@UserStatus",model.UserStatus),
                                      new SqlParameter("@UserEmail",model.UserEmail),
                                      new SqlParameter("@TruethName",model.TruethName),
                                      new SqlParameter("@UserPhone",model.UserPhone),
                                      new SqlParameter("@GID",model.GID),
                                      new SqlParameter("@GName",model.GName),
                                      new SqlParameter("@LoginName",model.LoginName),
                                      new SqlParameter("@id",model.ID),
                                      new SqlParameter("@FirstPinYin",model.FirstPinYin),
                                      new SqlParameter("@PinYin",model.PinYin)
                                      };
            rowcount = helper.ExecuteSql(sqltxt, paramter);
            return rowcount;
        }
        /// <summary>
        /// 禁用系统用户
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int DelSysAdminUser(int userid)
        {
            int rowcount = 0;
            string sqltxt = @"UPDATE  dbo.SysAdminUser
SET    UserStatus = 0 
WHERE   ID = @id";
            SqlParameter[] paramter = {                                       
                                      new SqlParameter("@id",userid)
                                      };
            rowcount = helper.ExecuteSql(sqltxt, paramter);
            return rowcount;
        }

        #region 系统配置表设置
        /// <summary>
        /// 得到所有的系统配置
        /// </summary>
        /// <returns></returns>
        public List<SysAdminConfigsModel> GetAllConfigs()
        {
            List<SysAdminConfigsModel> list = new List<SysAdminConfigsModel>();
            string sqltxt = @"SELECT  ID ,
        ConfigName ,
        ConfigFID ,
        ConfigValue ,
        ConfigRemark ,
        AddTime ,
        ConfigStatus ,
        CASE ConfigStatus
          WHEN 1 THEN '启用'
          ELSE '禁用'
        END AS ConfigStatusName
FROM    dbo.SysAdminConfigs WITH(NOLOCK)";
            DataTable dt = helper.Query(sqltxt).Tables[0];
            foreach (DataRow item in dt.Rows)
            {
                SysAdminConfigsModel model = new SysAdminConfigsModel();
                model.AddTime = DateTime.Parse(item["AddTime"].ToString());
                model.ConfigFID = int.Parse(item["ConfigFID"].ToString());
                model.ConfigName = item["ConfigName"].ToString();
                model.ConfigRemark = item["ConfigRemark"].ToString();
                model.ConfigStatus = int.Parse(item["ConfigStatus"].ToString());
                model.ConfigStatusName = item["ConfigStatusName"].ToString();
                model.ConfigValue = item["ConfigValue"].ToString();
                model.ID = int.Parse(item["ID"].ToString());
                list.Add(model);
            }
            return list;
        }
        /// <summary>
        /// 插入配置信息
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int AddConfigInfo(SysAdminConfigsModel model)
        {
            int rowcount = 0;
            string sqltxt = @"INSERT  INTO dbo.SysAdminConfigs
        ( ConfigName ,
          ConfigFID ,
          ConfigValue ,
          ConfigRemark ,
          AddTime ,
          ConfigStatus
        )
VALUES  ( @ConfigName ,
          @ConfigFID ,
          @ConfigValue ,
          @ConfigRemark ,
          GETDATE() ,
          @ConfigStatus
        )";
            SqlParameter[] paramter ={
                                    new SqlParameter("@ConfigName",model.ConfigName),
                                    new SqlParameter("@ConfigFID",model.ConfigFID),
                                    new SqlParameter("@ConfigValue",model.ConfigValue),
                                    new SqlParameter("@ConfigRemark",model.ConfigRemark),
                                    new SqlParameter("@ConfigStatus",model.ConfigStatus)
                                    };
            rowcount = helper.ExecuteSql(sqltxt, paramter);
            return rowcount;
        }
        /// <summary>
        /// 根据ID得到配置信息
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        public List<SysAdminConfigsModel> GetConfigsByIDs(string ids)
        {
            List<SysAdminConfigsModel> list = new List<SysAdminConfigsModel>();
            string sqltxt = @"SELECT  ID ,
        ConfigName ,
        ConfigFID ,
        ConfigValue ,
        ConfigRemark ,
        AddTime ,
        ConfigStatus ,
        CASE ConfigStatus
          WHEN 1 THEN '启用'
          ELSE '禁用'
        END AS ConfigStatusName
FROM    dbo.SysAdminConfigs WITH(NOLOCK)
WHERE ID IN (" + ids + ")";
            DataTable dt = helper.Query(sqltxt).Tables[0];
            foreach (DataRow item in dt.Rows)
            {
                SysAdminConfigsModel model = new SysAdminConfigsModel();
                model.AddTime = DateTime.Parse(item["AddTime"].ToString());
                model.ConfigFID = int.Parse(item["ConfigFID"].ToString());
                model.ConfigName = item["ConfigName"].ToString();
                model.ConfigRemark = item["ConfigRemark"].ToString();
                model.ConfigStatus = int.Parse(item["ConfigStatus"].ToString());
                model.ConfigStatusName = item["ConfigStatusName"].ToString();
                model.ConfigValue = item["ConfigValue"].ToString();
                model.ID = int.Parse(item["ID"].ToString());
                list.Add(model);
            }
            return list;
        }
        /// <summary>
        /// 修改配置信息
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int UpdateConfigs(SysAdminConfigsModel model)
        {
            int rowcount = 0;
            string sqltxt = @"UPDATE  dbo.SysAdminConfigs
SET     ConfigName = @ConfigName ,
        ConfigFID = @ConfigFID ,
        ConfigValue = @ConfigValue ,
        ConfigRemark = @ConfigRemark ,
        ConfigStatus = @ConfigStatus
WHERE   ID = @id";
            SqlParameter[] paramter ={
                                    new SqlParameter("@ConfigName",model.ConfigName),
                                    new SqlParameter("@ConfigFID",model.ConfigFID),
                                    new SqlParameter("@ConfigValue",model.ConfigValue),
                                    new SqlParameter("@ConfigRemark",model.ConfigRemark),
                                    new SqlParameter("@ConfigStatus",model.ConfigStatus),
                                    new SqlParameter("@id",model.ID)
                                    };
            rowcount = helper.ExecuteSql(sqltxt, paramter);
            return rowcount;
        }
        /// <summary>
        /// 得到顶级配置项目
        /// </summary>
        /// <returns></returns>
        public List<SysAdminConfigsModel> GetFirstConfigs()
        {
            List<SysAdminConfigsModel> list = new List<SysAdminConfigsModel>();
            string sqltxt = @"SELECT  ID ,
        ConfigName ,
        ConfigFID ,
        ConfigValue ,
        ConfigRemark ,
        AddTime ,
        ConfigStatus ,
        CASE ConfigStatus
          WHEN 1 THEN '启用'
          ELSE '禁用'
        END AS ConfigStatusName
FROM    dbo.SysAdminConfigs WITH(NOLOCK)
WHERE ConfigFID=0 ";
            DataTable dt = helper.Query(sqltxt).Tables[0];
            foreach (DataRow item in dt.Rows)
            {
                SysAdminConfigsModel model = new SysAdminConfigsModel();
                model.AddTime = DateTime.Parse(item["AddTime"].ToString());
                model.ConfigFID = int.Parse(item["ConfigFID"].ToString());
                model.ConfigName = item["ConfigName"].ToString();
                model.ConfigRemark = item["ConfigRemark"].ToString();
                model.ConfigStatus = int.Parse(item["ConfigStatus"].ToString());
                model.ConfigStatusName = item["ConfigStatusName"].ToString();
                model.ConfigValue = item["ConfigValue"].ToString();
                model.ID = int.Parse(item["ID"].ToString());
                list.Add(model);
            }
            return list;
        }
        /// <summary>
        /// 禁用配置项
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public int DelConfig(int id)
        {
            int rowcount = 0;
            string sqltxt = @"IF EXISTS ( SELECT  1
            FROM    dbo.SysAdminConfigs
            WHERE   id = @id
                    AND ConfigFID = 0 )
    BEGIN
        UPDATE  dbo.SysAdminConfigs
        SET     ConfigStatus = 0
        WHERE   id = @id
    END
ELSE
    BEGIN
        UPDATE  dbo.SysAdminConfigs
        SET     ConfigFID = 0
        WHERE   ConfigFID = @id
        UPDATE  dbo.SysAdminConfigs
        SET     ConfigStatus = 0
        WHERE   id = @id
    END";
            SqlParameter[] paramter = { new SqlParameter("@id", id) };
            rowcount = helper.ExecuteSql(sqltxt, paramter);
            return rowcount;
        }
        #endregion

        #region 网站前端基础配置
        /// <summary>
        /// 得到网站基本信息
        /// </summary>
        /// <returns></returns>
        public WebSettingsModel GetWebSetting()
        {
            WebSettingsModel model = new WebSettingsModel();
            string sqltxt = @"SELECT  ID ,
        WebName ,
        WebDescription ,
        WebType ,
        WebLogoAlt ,
        WebLogo ,
        WebPutonrecord ,
        WebDefaultKey ,
        WebAddress ,
        WebFax ,
        WebMobile ,
        WebPhone ,
        WebEmail ,
        WebAboutUs
FROM    dbo.WebSettings";
            DataTable dt = helper.Query(sqltxt).Tables[0];
            if (dt.Rows.Count > 0)
            {
                model.ID = int.Parse(dt.Rows[0]["ID"].ToString());
                model.WebAboutUs = dt.Rows[0]["WebAboutUs"].ToString();
                model.WebAddress = dt.Rows[0]["WebAddress"].ToString();
                model.WebDefaultKey = dt.Rows[0]["WebDefaultKey"].ToString();
                model.WebDescription = dt.Rows[0]["WebDescription"].ToString();
                model.WebEmail = dt.Rows[0]["WebEmail"].ToString();
                model.WebFax = dt.Rows[0]["WebFax"].ToString();
                model.WebLogo = dt.Rows[0]["WebLogo"].ToString();
                model.WebLogoAlt = dt.Rows[0]["WebLogoAlt"].ToString();
                model.WebMobile = dt.Rows[0]["WebMobile"].ToString();
                model.WebName = dt.Rows[0]["WebName"].ToString();
                model.WebPhone = dt.Rows[0]["WebPhone"].ToString();
                model.WebPutonrecord = dt.Rows[0]["WebPutonrecord"].ToString();
                model.WebType = dt.Rows[0]["WebType"].ToString();
            }
            return model;
        }
        /// <summary>
        /// 修改网站基本信息
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int UpdateWebSetting(WebSettingsModel model)
        {
            int rowcount = 0;
            string sqltxt = @"UPDATE  dbo.WebSettings
SET     WebName = @WebName ,
        WebDescription = @WebDescription ,
        WebType = @WebType ,
        WebLogoAlt = @WebLogoAlt ,
        WebLogo = @WebLogo ,
        WebPutonrecord = @WebPutonrecord ,
        WebDefaultKey = @WebDefaultKey ,
        WebAddress = @WebAddress ,
        WebFax = @WebFax ,
        WebMobile = @WebMobile ,
        WebPhone = @WebPhone ,
        WebEmail = @WebEmail ,
        WebAboutUs = @WebAboutUs
WHERE   ID = 1";
            SqlParameter[] paramter = { 
                                      new SqlParameter("@WebName",model.WebName),
                                      new SqlParameter("@WebDescription",model.WebDescription),
                                      new SqlParameter("@WebType",model.WebType),
                                      new SqlParameter("@WebLogoAlt",model.WebLogoAlt),
                                      new SqlParameter("@WebLogo",model.WebLogo),
                                      new SqlParameter("@WebPutonrecord",model.WebPutonrecord),
                                      new SqlParameter("@WebDefaultKey",model.WebDefaultKey),
                                      new SqlParameter("@WebAddress",model.WebAddress),
                                      new SqlParameter("@WebFax",model.WebFax),
                                      new SqlParameter("@WebMobile",model.WebMobile),
                                      new SqlParameter("@WebPhone",model.WebPhone),
                                      new SqlParameter("@WebEmail",model.WebEmail),
                                      new SqlParameter("@WebAboutUs",model.WebAboutUs)
                                      };
            rowcount = helper.ExecuteSql(sqltxt, paramter);
            return rowcount;
        }
        #endregion

        #region 网站前端模块设置
        /// <summary>
        /// 得到所有的模块
        /// </summary>
        /// <returns></returns>
        public List<WebModuleModel> GetAllWebModules()
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ID, ModuleName, ModuleDescription, ModuleWidth, ModuleHeight, ModuleStatus, AddUserID, AddUserName, AddTime  ");
            strSql.Append("  from WebModule ");
            DataSet ds = helper.Query(strSql.ToString());
            List<WebModuleModel> list = new List<WebModuleModel>();
            foreach (DataRow item in ds.Tables[0].Rows)
            {
                WebModuleModel model = new WebModuleModel();
                model.AddTime = DateTime.Parse(item["AddTime"].ToString());
                model.AddUserID = int.Parse(item["AddUserID"].ToString());
                model.AddUserName = item["AddUserName"].ToString();
                model.ID = int.Parse(item["ID"].ToString());
                model.ModuleDescription = item["ModuleDescription"].ToString();
                model.ModuleHeight = string.IsNullOrWhiteSpace(item["ModuleHeight"].ToString()) ? 0 : int.Parse(item["ModuleHeight"].ToString());
                model.ModuleName = item["ModuleName"].ToString();
                model.ModuleStatus = int.Parse(item["ModuleStatus"].ToString());
                model.ModuleWidth = string.IsNullOrWhiteSpace(item["ModuleWidth"].ToString()) ? 0 : int.Parse(item["ModuleWidth"].ToString());
                list.Add(model);
            }
            return list;
        }
        /// <summary>
        /// 根据ID得到模块信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public WebModuleModel GetWebModuleByID(int id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ID, ModuleName, ModuleDescription, ModuleWidth, ModuleHeight, ModuleStatus, AddUserID, AddUserName, AddTime  ");
            strSql.Append("  from WebModule ");
            strSql.Append(" where ID=@ID");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)
			};
            parameters[0].Value = id;


            WebModuleModel model = new WebModuleModel();
            DataSet ds = helper.Query(strSql.ToString(), parameters);

            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["ID"].ToString() != "")
                {
                    model.ID = int.Parse(ds.Tables[0].Rows[0]["ID"].ToString());
                }
                model.ModuleName = ds.Tables[0].Rows[0]["ModuleName"].ToString();
                model.ModuleDescription = ds.Tables[0].Rows[0]["ModuleDescription"].ToString();
                if (ds.Tables[0].Rows[0]["ModuleWidth"].ToString() != "")
                {
                    model.ModuleWidth = int.Parse(ds.Tables[0].Rows[0]["ModuleWidth"].ToString());
                }
                if (ds.Tables[0].Rows[0]["ModuleHeight"].ToString() != "")
                {
                    model.ModuleHeight = int.Parse(ds.Tables[0].Rows[0]["ModuleHeight"].ToString());
                }
                if (ds.Tables[0].Rows[0]["ModuleStatus"].ToString() != "")
                {
                    model.ModuleStatus = int.Parse(ds.Tables[0].Rows[0]["ModuleStatus"].ToString());
                }
                if (ds.Tables[0].Rows[0]["AddUserID"].ToString() != "")
                {
                    model.AddUserID = int.Parse(ds.Tables[0].Rows[0]["AddUserID"].ToString());
                }
                model.AddUserName = ds.Tables[0].Rows[0]["AddUserName"].ToString();
                if (ds.Tables[0].Rows[0]["AddTime"].ToString() != "")
                {
                    model.AddTime = DateTime.Parse(ds.Tables[0].Rows[0]["AddTime"].ToString());
                }
                return model;
            }
            else
            {
                return null;
            }
        }
        /// <summary>
        /// 添加模块
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int AddWebModule(WebModuleModel model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into dbo.WebModule(");
            strSql.Append("ModuleName,ModuleDescription,ModuleWidth,ModuleHeight,ModuleStatus,AddUserID,AddUserName,AddTime");
            strSql.Append(") values (");
            strSql.Append("@ModuleName,@ModuleDescription,@ModuleWidth,@ModuleHeight,@ModuleStatus,@AddUserID,@AddUserName,GETDATE()");
            strSql.Append(") ");
            SqlParameter[] parameters = {
			            new SqlParameter("@ModuleName", SqlDbType.NVarChar,50) ,            
                        new SqlParameter("@ModuleDescription", SqlDbType.NVarChar,500) ,            
                        new SqlParameter("@ModuleWidth", SqlDbType.Int,4) ,            
                        new SqlParameter("@ModuleHeight", SqlDbType.Int,4) ,            
                        new SqlParameter("@ModuleStatus", SqlDbType.Int,4) ,            
                        new SqlParameter("@AddUserID", SqlDbType.Int,4) ,            
                        new SqlParameter("@AddUserName", SqlDbType.NVarChar,50) 
            };
            parameters[0].Value = model.ModuleName;
            parameters[1].Value = model.ModuleDescription;
            parameters[2].Value = model.ModuleWidth;
            parameters[3].Value = model.ModuleHeight;
            parameters[4].Value = model.ModuleStatus;
            parameters[5].Value = model.AddUserID;
            parameters[6].Value = model.AddUserName;

            int rowcount = helper.ExecuteSql(strSql.ToString(), parameters);
            return rowcount;
        }
        /// <summary>
        /// 修改数据
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int UpdateWebModule(WebModuleModel model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update dbo.WebModule set ");
            strSql.Append(" ModuleName = @ModuleName , ");
            strSql.Append(" ModuleDescription = @ModuleDescription , ");
            strSql.Append(" ModuleWidth = @ModuleWidth , ");
            strSql.Append(" ModuleHeight = @ModuleHeight , ");
            strSql.Append(" ModuleStatus = @ModuleStatus  ");
            strSql.Append(" where ID=@ID ");

            SqlParameter[] parameters = {
			            new SqlParameter("@ID", SqlDbType.Int,4) ,            
                        new SqlParameter("@ModuleName", SqlDbType.NVarChar,50) ,            
                        new SqlParameter("@ModuleDescription", SqlDbType.NVarChar,500) ,            
                        new SqlParameter("@ModuleWidth", SqlDbType.Int,4) ,            
                        new SqlParameter("@ModuleHeight", SqlDbType.Int,4) ,            
                        new SqlParameter("@ModuleStatus", SqlDbType.Int,4) 
              
            };
            parameters[0].Value = model.ID;
            parameters[1].Value = model.ModuleName;
            parameters[2].Value = model.ModuleDescription;
            parameters[3].Value = model.ModuleWidth;
            parameters[4].Value = model.ModuleHeight;
            parameters[5].Value = model.ModuleStatus;
            int rows = helper.ExecuteSql(strSql.ToString(), parameters);
            return rows;
        }
        #endregion

        #region 网站前端菜单设置
        /// <summary>
        /// 添加菜单
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int AddWebMenu(WebMenusModel model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into WebMenus(");
            strSql.Append("AreaName,AddUserID,AddUserName,AddTime,MenuIcon,MenuName,FatherID,FatherName,MenuAlt,LinkUrl,MenuStatus,SortIndex,ControllerName,ActionName");
            strSql.Append(") values (");
            strSql.Append("@AreaName,@AddUserID,@AddUserName,GETDATE(),@MenuIcon,@MenuName,@FatherID,@FatherName,@MenuAlt,@LinkUrl,@MenuStatus,@SortIndex,@ControllerName,@ActionName");
            strSql.Append(") ");
            SqlParameter[] parameters = {
			            new SqlParameter("@AreaName", SqlDbType.NVarChar,50) ,            
                        new SqlParameter("@AddUserID", SqlDbType.Int,4) ,            
                        new SqlParameter("@AddUserName", SqlDbType.NVarChar,50) ,   
                        new SqlParameter("@MenuIcon", SqlDbType.NVarChar,50) ,            
                        new SqlParameter("@MenuName", SqlDbType.NVarChar,50) ,            
                        new SqlParameter("@FatherID", SqlDbType.Int,4) ,            
                        new SqlParameter("@MenuAlt", SqlDbType.NVarChar,50) ,            
                        new SqlParameter("@LinkUrl", SqlDbType.NVarChar,500) ,            
                        new SqlParameter("@MenuStatus", SqlDbType.Int,4) ,            
                        new SqlParameter("@SortIndex", SqlDbType.Int,4) ,            
                        new SqlParameter("@ControllerName", SqlDbType.NVarChar,50) ,            
                        new SqlParameter("@ActionName", SqlDbType.NVarChar,50) ,            
               new SqlParameter("@FatherName", SqlDbType.NVarChar,50)      
            };

            parameters[0].Value = model.AreaName;
            parameters[1].Value = model.AddUserID;
            parameters[2].Value = model.AddUserName;
            parameters[3].Value = model.MenuIcon;
            parameters[4].Value = model.MenuName;
            parameters[5].Value = model.FatherID;
            parameters[6].Value = model.MenuAlt;
            parameters[7].Value = model.LinkUrl;
            parameters[8].Value = model.MenuStatus;
            parameters[9].Value = model.SortIndex;
            parameters[10].Value = model.ControllerName;
            parameters[11].Value = model.ActionName;
            parameters[12].Value = model.FatherName;
            int rowcount = helper.ExecuteSql(strSql.ToString(), parameters);
            return rowcount;
        }
        /// <summary>
        /// 更改菜单
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int UpdateWebMenu(WebMenusModel model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update WebMenus set ");

            strSql.Append(" AreaName = @AreaName , ");
            strSql.Append(" MenuIcon = @MenuIcon , ");
            strSql.Append(" MenuName = @MenuName , ");
            strSql.Append(" FatherID = @FatherID , ");
            strSql.Append(" FatherName = @FatherName , ");
            strSql.Append(" MenuAlt = @MenuAlt , ");
            strSql.Append(" LinkUrl = @LinkUrl , ");
            strSql.Append(" MenuStatus = @MenuStatus , ");
            strSql.Append(" SortIndex = @SortIndex , ");
            strSql.Append(" ControllerName = @ControllerName , ");
            strSql.Append(" ActionName = @ActionName  ");
            strSql.Append(" where ID=@ID ");

            SqlParameter[] parameters = {
			            new SqlParameter("@ID", SqlDbType.Int,4) ,            
                        new SqlParameter("@AreaName", SqlDbType.NVarChar,50) ,  
                        new SqlParameter("@MenuIcon", SqlDbType.NVarChar,50) ,            
                        new SqlParameter("@MenuName", SqlDbType.NVarChar,50) ,            
                        new SqlParameter("@FatherID", SqlDbType.Int,4) ,            
                        new SqlParameter("@MenuAlt", SqlDbType.NVarChar,50) ,            
                        new SqlParameter("@LinkUrl", SqlDbType.NVarChar,500) ,            
                        new SqlParameter("@MenuStatus", SqlDbType.Int,4) ,            
                        new SqlParameter("@SortIndex", SqlDbType.Int,4) ,            
                        new SqlParameter("@ControllerName", SqlDbType.NVarChar,50) ,            
                        new SqlParameter("@ActionName", SqlDbType.NVarChar,50) ,            
              new SqlParameter("@FatherName", SqlDbType.NVarChar,50)
            };

            parameters[0].Value = model.ID;
            parameters[1].Value = model.AreaName;
            parameters[2].Value = model.MenuIcon;
            parameters[3].Value = model.MenuName;
            parameters[4].Value = model.FatherID;
            parameters[5].Value = model.MenuAlt;
            parameters[6].Value = model.LinkUrl;
            parameters[7].Value = model.MenuStatus;
            parameters[8].Value = model.SortIndex;
            parameters[9].Value = model.ControllerName;
            parameters[10].Value = model.ActionName;
            parameters[11].Value = model.FatherName;
            int rows = helper.ExecuteSql(strSql.ToString(), parameters);
            return rows;
        }
        /// <summary>
        /// 根据ID得到菜单信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public WebMenusModel GetWebMenuByID(int id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ID, AreaName, AddUserID, AddUserName, AddTime, MenuIcon, MenuName, FatherID,FatherName, MenuAlt, LinkUrl, MenuStatus, SortIndex, ControllerName, ActionName  ");
            strSql.Append("  from WebMenus ");
            strSql.Append(" where ID=@ID");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)
			};
            parameters[0].Value = id;


            WebMenusModel model = new WebMenusModel();
            DataSet ds = helper.Query(strSql.ToString(), parameters);

            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["ID"].ToString() != "")
                {
                    model.ID = int.Parse(ds.Tables[0].Rows[0]["ID"].ToString());
                }
                model.AreaName = ds.Tables[0].Rows[0]["AreaName"].ToString();
                if (ds.Tables[0].Rows[0]["AddUserID"].ToString() != "")
                {
                    model.AddUserID = int.Parse(ds.Tables[0].Rows[0]["AddUserID"].ToString());
                }
                model.AddUserName = ds.Tables[0].Rows[0]["AddUserName"].ToString();
                if (ds.Tables[0].Rows[0]["AddTime"].ToString() != "")
                {
                    model.AddTime = DateTime.Parse(ds.Tables[0].Rows[0]["AddTime"].ToString());
                }
                model.MenuIcon = ds.Tables[0].Rows[0]["MenuIcon"].ToString();
                model.MenuName = ds.Tables[0].Rows[0]["MenuName"].ToString();
                if (ds.Tables[0].Rows[0]["FatherID"].ToString() != "")
                {
                    model.FatherID = int.Parse(ds.Tables[0].Rows[0]["FatherID"].ToString());
                }
                model.FatherName = ds.Tables[0].Rows[0]["FatherName"].ToString();
                model.MenuAlt = ds.Tables[0].Rows[0]["MenuAlt"].ToString();
                model.LinkUrl = ds.Tables[0].Rows[0]["LinkUrl"].ToString();
                if (ds.Tables[0].Rows[0]["MenuStatus"].ToString() != "")
                {
                    model.MenuStatus = int.Parse(ds.Tables[0].Rows[0]["MenuStatus"].ToString());
                }
                if (ds.Tables[0].Rows[0]["SortIndex"].ToString() != "")
                {
                    model.SortIndex = int.Parse(ds.Tables[0].Rows[0]["SortIndex"].ToString());
                }
                model.ControllerName = ds.Tables[0].Rows[0]["ControllerName"].ToString();
                model.ActionName = ds.Tables[0].Rows[0]["ActionName"].ToString();

                return model;
            }
            else
            {
                return null;
            }
        }
        /// <summary>
        /// 得到全部的菜单
        /// </summary>
        /// <returns></returns>
        public List<WebMenusModel> GetAllWebMenusList()
        {
            List<WebMenusModel> list = new List<WebMenusModel>();
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ID, AreaName, AddUserID, AddUserName, AddTime, MenuIcon, MenuName, FatherID,FatherName, MenuAlt, LinkUrl, MenuStatus, SortIndex, ControllerName, ActionName  ");
            strSql.Append("  from WebMenus ");
            DataTable dt = helper.Query(strSql.ToString()).Tables[0];
            foreach (DataRow item in dt.Rows)
            {
                WebMenusModel model = new WebMenusModel();
                model.ActionName = item["ActionName"].ToString();
                model.AddTime = DateTime.Parse(item["AddTime"].ToString());
                model.AddUserID = int.Parse(item["AddUserID"].ToString());
                model.AddUserName = item["AddUserName"].ToString();
                model.AreaName = item["AreaName"].ToString();
                model.ControllerName = item["ControllerName"].ToString();
                model.FatherID = int.Parse(item["FatherID"].ToString());
                model.FatherName = item["FatherName"].ToString();
                model.ID = int.Parse(item["ID"].ToString());
                model.LinkUrl = item["LinkUrl"].ToString();
                model.MenuAlt = item["MenuAlt"].ToString();
                model.MenuIcon = item["MenuIcon"].ToString();
                model.MenuName = item["MenuName"].ToString();
                model.MenuStatus = int.Parse(item["MenuStatus"].ToString());
                model.SortIndex = int.Parse(item["SortIndex"].ToString());
                list.Add(model);
            }
            return list;
        }
        /// <summary>
        /// 得到所有的顶级菜单
        /// </summary>
        /// <returns></returns>
        public List<WebMenusModel> GetAllFirstWebMenu()
        {
            List<WebMenusModel> list = new List<WebMenusModel>();
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ID, AreaName, AddUserID, AddUserName, AddTime, MenuIcon, MenuName, FatherID,FatherName, MenuAlt, LinkUrl, MenuStatus, SortIndex, ControllerName, ActionName  ");
            strSql.Append("  from WebMenus ");
            strSql.Append(" where FatherID=0 and  MenuStatus=1 ");
            DataTable dt = helper.Query(strSql.ToString()).Tables[0];
            foreach (DataRow item in dt.Rows)
            {
                WebMenusModel model = new WebMenusModel();
                model.ActionName = item["ActionName"].ToString();
                model.AddTime = DateTime.Parse(item["AddTime"].ToString());
                model.AddUserID = int.Parse(item["AddUserID"].ToString());
                model.AddUserName = item["AddUserName"].ToString();
                model.AreaName = item["AreaName"].ToString();
                model.ControllerName = item["ControllerName"].ToString();
                model.FatherID = int.Parse(item["FatherID"].ToString());
                model.FatherName = item["FatherName"].ToString();
                model.ID = int.Parse(item["ID"].ToString());
                model.LinkUrl = item["LinkUrl"].ToString();
                model.MenuAlt = item["MenuAlt"].ToString();
                model.MenuIcon = item["MenuIcon"].ToString();
                model.MenuName = item["MenuName"].ToString();
                model.MenuStatus = int.Parse(item["MenuStatus"].ToString());
                model.SortIndex = int.Parse(item["SortIndex"].ToString());
                list.Add(model);
            }
            return list;
        }
        #endregion
    }
}
