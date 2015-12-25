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
    /// 系统菜单和用户操作
    /// </summary>
    public class SysMenuAndUser
    {
        DbHelperSQL helper = new DbHelperSQL();
        /// <summary>
        /// 登录信息
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public SysAdminUserModel GetUserForLogin(SysAdminUserModel user)
        {
            SysAdminUserModel result = null;
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
        GName,
        LoginName
FROM    dbo.SysAdminUser
WHERE LoginName=@loginname ";
            SqlParameter[] paramter={
                                    new SqlParameter("@loginname",user.LoginName)
                                    };
            DataTable dt=helper.Query(sqltxt,paramter).Tables[0];
            if (dt != null && dt.Rows.Count > 0)
            {
                result = new SysAdminUserModel();
                result.Answer = dt.Rows[0]["Answer"].ToString();
                result.GID = int.Parse(dt.Rows[0]["GID"].ToString());
                result.GName = dt.Rows[0]["GName"].ToString();
                result.ID = int.Parse(dt.Rows[0]["ID"].ToString());
                result.LoginName = dt.Rows[0]["LoginName"].ToString();
                result.Question = dt.Rows[0]["Question"].ToString();
                result.TruethName = dt.Rows[0]["TruethName"].ToString();
                result.UserEmail = dt.Rows[0]["UserEmail"].ToString();
                result.UserName = dt.Rows[0]["UserName"].ToString();
                result.UserPhone = dt.Rows[0]["UserPhone"].ToString();
                result.UserPwd = dt.Rows[0]["UserPwd"].ToString();
                result.UserStatus = int.Parse(dt.Rows[0]["UserStatus"].ToString());              
                if (result.UserPwd != user.UserPwd)
                {
                    result.LoginResult = "0用户密码不正确";
                    return result;
                } 
                if (result.UserStatus == 0)
                {
                    result.LoginResult="0用户已经被禁用";
                    return result;
                }
                result.LoginResult = "1";
            }
            else
            {
                result = new SysAdminUserModel();
                result.LoginResult = "0无此用户";
                return result;
            }
            return result;
        }
        /// <summary>
        /// 查询用户拥有的菜单权限
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public List<SysAdminMenuModel> GetUserAttributeMenu(SysAdminUserModel user)
        {
            List<SysAdminMenuModel> list = new List<SysAdminMenuModel>();
            string sqltxt = @"SELECT  A.PermissionType ,
        B.ID ,
        B.MenuAlt ,
        b.ActionName ,
        b.AreaName ,
        b.ControllerName ,
        b.FatherID ,
        b.FatherName ,
        b.LinkUrl ,
        b.MenuName ,
        b.MenuType ,
        b.SortIndex,
        B.MenuIcon,
       B.MenuStatus
FROM    dbo.SysAdminGrouprMenu A WITH ( NOLOCK )
        INNER JOIN dbo.SysAdminMenu B WITH ( NOLOCK ) ON A.MID = b.ID
WHERE   A.GID = @gid
        AND b.MenuStatus = 1
ORDER BY b.SortIndex ASC";
            SqlParameter[] paramter = { 
                                      new SqlParameter("@gid",user.GID)
                                      };
            DataTable dt = helper.Query(sqltxt, paramter).Tables[0];
            if (dt != null && dt.Rows.Count > 0)
            {
                foreach (DataRow item in dt.Rows)
                {
                    SysAdminMenuModel model = new SysAdminMenuModel();
                    model.ActionName = item["ActionName"].ToString();
                    model.AreaName = item["AreaName"].ToString();
                    model.ControllerName = item["ControllerName"].ToString();
                    model.FatherID = string.IsNullOrWhiteSpace(item["FatherID"].ToString()) ? 0 : int.Parse(item["FatherID"].ToString());
                    model.FatherName = item["FatherName"].ToString();
                    model.ID = int.Parse(item["ID"].ToString());
                    model.LinkUrl = item["LinkUrl"].ToString();
                    model.MenuAlt = item["MenuAlt"].ToString();
                    model.MenuName = item["MenuName"].ToString();
                    model.MenuStatus = int.Parse(item["MenuStatus"].ToString());
                    model.MenuType = int.Parse(item["MenuType"].ToString());
                    model.PermissionType = int.Parse(item["PermissionType"].ToString());
                    model.SortIndex = string.IsNullOrWhiteSpace(item["SortIndex"].ToString()) ? 0 : int.Parse(item["SortIndex"].ToString());
                    model.MenuIcon = item["MenuIcon"].ToString();
                    list.Add(model);
                }
            }
            return list;
        }
    }
}
