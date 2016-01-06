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
            List<SysAdminUserModel> list =new List<SysAdminUserModel>();
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
            SqlParameter[] paramter = { new SqlParameter("@id",userid)};
            DataTable dt = helper.Query(sqltxt,paramter).Tables[0];
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
            rowcount = helper.ExecuteSql(sqltxt,paramter);
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
    }
}
