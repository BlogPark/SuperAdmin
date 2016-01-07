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
        END AS UserStatusName
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
          HeaderImg
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
          @HeaderImg
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
                                      new SqlParameter("@HeaderImg",model.HeaderImg)
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
        LoginName = @LoginName 
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
                                      new SqlParameter("@id",model.ID)
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
WHERE ID IN ("+ids+")";
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
            SqlParameter[] paramter = { new SqlParameter("@id",id)};
            rowcount = helper.ExecuteSql(sqltxt,paramter);
            return rowcount;
        }
        #endregion
    }
}
