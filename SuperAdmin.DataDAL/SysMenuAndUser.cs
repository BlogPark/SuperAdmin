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
        LoginName,HeaderImg
FROM    dbo.SysAdminUser
WHERE LoginName=@loginname ";
            SqlParameter[] paramter ={
                                    new SqlParameter("@loginname",user.LoginName)
                                    };
            DataTable dt = helper.Query(sqltxt, paramter).Tables[0];
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
                result.HeaderImg = dt.Rows[0]["HeaderImg"].ToString();
                result.UserStatus = int.Parse(dt.Rows[0]["UserStatus"].ToString());
                if (result.UserPwd != user.UserPwd)
                {
                    result.LoginResult = "0用户密码不正确";
                    return result;
                }
                if (result.UserStatus == 0)
                {
                    result.LoginResult = "0用户已经被禁用";
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
       AND A.PermissionType<>4
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
        /// <summary>
        /// 查询所有菜单
        /// </summary>
        /// <returns></returns>
        public List<SysAdminMenuModel> GetAllSysMenu()
        {
            List<SysAdminMenuModel> list = new List<SysAdminMenuModel>();
            string sqltxt = @"SELECT ID,
      MenuName,
      FatherID,
      MenuAlt,
      FatherName,
      LinkUrl,
      MenuStatus,
      SortIndex,
      MenuType,
      ControllerName,
      ActionName,
      AreaName,
      MenuIcon
  FROM dbo.SysAdminMenu With(nolock)";
            DataTable dt = helper.Query(sqltxt).Tables[0];
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
                    model.SortIndex = string.IsNullOrWhiteSpace(item["SortIndex"].ToString()) ? 0 : int.Parse(item["SortIndex"].ToString());
                    model.MenuIcon = item["MenuIcon"].ToString();
                    list.Add(model);
                }
            }
            return list;
        }
        /// <summary>
        /// 新增和修改系统菜单
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int AddAndUpdateData(SysAdminMenuModel model)
        {
            int rowcount = 0;
            string sqltxt = "";
            if (model.Type == 0)
            {
                sqltxt = @"INSERT INTO dbo.SysAdminMenu
           (MenuName,
           FatherID,
           MenuAlt,
           FatherName,
           LinkUrl,
           MenuStatus,
           SortIndex,
           MenuType,
           ControllerName,
           ActionName,
           AreaName,
           MenuIcon)
     VALUES
           (@MenuName,
           @FatherID,
           @MenuAlt,
           @FatherName,
           @LinkUrl,
           @MenuStatus,
           @SortIndex,
           @MenuType,
           @ControllerName,
           @ActionName, 
           @AreaName,
           @MenuIcon)";
            }
            else
            {
                sqltxt = @"UPDATE dbo.SysAdminMenu
   SET MenuName = @MenuName,
      FatherID = @FatherID,
      MenuAlt = @MenuAlt,
      FatherName =@FatherName,
      LinkUrl = @LinkUrl,
      MenuStatus = @MenuStatus,
      SortIndex = @SortIndex,
      MenuType = @MenuType,
      ControllerName = @ControllerName,
      ActionName = @ActionName,
      AreaName = @AreaName,
      MenuIcon = @MenuIcon
 WHERE ID=@ID";
            }
            SqlParameter[] paramter = { 
                                          new SqlParameter("@ID",model.ID),
                                          new SqlParameter("@MenuName",model.MenuName),
                                          new SqlParameter("@FatherID",model.FatherID),
                                          new SqlParameter("@MenuAlt",model.MenuAlt),
                                          new SqlParameter("@FatherName",model.FatherName),
                                          new SqlParameter("@LinkUrl",model.LinkUrl),
                                          new SqlParameter("@MenuStatus",model.MenuStatus),
                                          new SqlParameter("@SortIndex",model.SortIndex),
                                          new SqlParameter("@MenuType",model.MenuType),
                                          new SqlParameter("@ControllerName",model.ControllerName),
                                          new SqlParameter("@ActionName",model.ActionName),
                                          new SqlParameter("@AreaName",model.AreaName),
                                          new SqlParameter("@MenuIcon",model.MenuIcon)
                                      };
            rowcount = helper.ExecuteSql(sqltxt, paramter);
            return rowcount;
        }
        /// <summary>
        /// 得到所有的用户组
        /// </summary>
        /// <returns></returns>
        public List<SysAdminUserGroupModel> GetAllAdminGroup()
        {
            List<SysAdminUserGroupModel> list = new List<SysAdminUserGroupModel>();
            string sqltxt = @"SELECT  ID ,
        GroupName ,
        GroupAlt ,
        GroupStatus ,
        Addtime
FROM    dbo.SysAdminUserGroup";
            DataTable dt = helper.Query(sqltxt).Tables[0];
            foreach (DataRow item in dt.Rows)
            {
                SysAdminUserGroupModel model = new SysAdminUserGroupModel();
                model.Addtime = DateTime.Parse(item["Addtime"].ToString());
                model.GroupAlt = item["GroupAlt"].ToString();
                model.GroupName = item["GroupName"].ToString();
                model.GroupStatus = int.Parse(item["GroupStatus"].ToString());
                model.ID = int.Parse(item["ID"].ToString());
                list.Add(model);
            }
            return list;
        }
        /// <summary>
        /// 添加和修改系统用户组
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int AddAndUpdateAdminGroup(SysAdminUserGroupModel model)
        {
            int rowcount = 0;
            string sqltxt = "";
            if (model.Type == 0)
            {
                sqltxt = @"INSERT INTO dbo.SysAdminUserGroup
        ( GroupName ,
          GroupAlt ,
          GroupStatus ,
          Addtime
        )
VALUES  ( @GroupName,
          @GroupAlt,
          @GroupStatus,
          GETDATE()
        )";
            }
            else
            {
                sqltxt = @"UPDATE  dbo.SysAdminUserGroup
SET     GroupAlt = @GroupAlt ,
        GroupName = @GroupName ,
        GroupStatus = @GroupStatus
WHERE   ID = @ID";
            }
            SqlParameter[] paramter = { 
                                      new SqlParameter("@GroupName",model.GroupName),
                                      new SqlParameter("@GroupAlt",model.GroupAlt),
                                      new SqlParameter("@GroupStatus",model.GroupStatus),
                                      new SqlParameter("@ID",model.ID)
                                      };
            rowcount = helper.ExecuteSql(sqltxt, paramter);
            return rowcount;
        }
        /// <summary>
        /// 得到所有用户组权限
        /// </summary>
        /// <returns></returns>
        public List<SysAdminGrouprMenuModel> GetAllUserMenu()
        {
            List<SysAdminGrouprMenuModel> list = new List<SysAdminGrouprMenuModel>();
            string sqltxt = @"SELECT  A.ID ,
        A.GID ,
        A.GName ,
        A.MID ,
        A.MName ,
        A.MType ,
        A.PermissionType ,
        A.AddTime ,
        A.IsEdit ,
        B.FatherID ,
        CASE a.PermissionType
          WHEN 1 THEN '查看'
          WHEN 2 THEN '编辑'
          WHEN 3 THEN '修改'
          WHEN 4 THEN '禁用'
        END AS PermissionTypeName,
        CASE a.MType
          WHEN 1 THEN '菜单'
          WHEN 2 THEN '按钮'
        END AS MTypeName,
        CASE a.IsEdit
          WHEN 0 THEN '否'
          WHEN 1 THEN '是'
        END AS IsEditName
FROM    dbo.SysAdminGrouprMenu A WITH ( NOLOCK )
        INNER JOIN dbo.SysAdminMenu B WITH ( NOLOCK ) ON A.MID = B.ID";
            DataTable dt = helper.Query(sqltxt).Tables[0];
            foreach (DataRow item in dt.Rows)
            {
                SysAdminGrouprMenuModel model = new SysAdminGrouprMenuModel();
                model.AddTime = DateTime.Parse(item["AddTime"].ToString());
                model.FatherID = int.Parse(item["FatherID"].ToString());
                model.GID = int.Parse(item["GID"].ToString());
                model.GName = item["GName"].ToString();
                model.ID = int.Parse(item["ID"].ToString());
                model.IsEdit = int.Parse(item["IsEdit"].ToString());
                model.MID = int.Parse(item["MID"].ToString());
                model.MName = item["MName"].ToString();
                model.MType = int.Parse(item["MType"].ToString());
                model.PermissionType = int.Parse(item["PermissionType"].ToString());
                model.PermissionTypeName = item["PermissionTypeName"].ToString();
                model.MenuTypeName = item["MTypeName"].ToString();
                model.IsEditName = item["IsEditName"].ToString();
                list.Add(model);
            }
            return list;
        }
        /// <summary>
        ///查询用户组没权限的菜单 
        /// </summary>
        /// <returns></returns>
        public List<SysAdminMenuModel> GetOtherMenuByGroup(int gid)
        {
            List<SysAdminMenuModel> list = new List<SysAdminMenuModel>();
            string sqltxt = @"  SELECT    ID ,
            MenuName ,
            FatherID ,
            MenuAlt ,
            FatherName ,
            LinkUrl ,
            MenuStatus ,
            SortIndex ,
            MenuType ,
            ControllerName ,
            ActionName ,
            AreaName ,
            MenuIcon
  FROM      dbo.SysAdminMenu
  WHERE     id NOT IN ( SELECT  mid
                        FROM    dbo.SysAdminGrouprMenu
                        WHERE   GID = @gid )
            AND MenuStatus=1";
            SqlParameter[] paramter = { 
                                      new SqlParameter("@gid",gid)
                                      };
            DataTable dt = helper.Query(sqltxt,paramter).Tables[0];
            foreach (DataRow item in dt.Rows)
            {
                SysAdminMenuModel model = new SysAdminMenuModel();
                model.ActionName = item["ActionName"].ToString();
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
                model.MenuType = int.Parse(item["MenuType"].ToString());
                model.SortIndex = int.Parse(item["SortIndex"].ToString());
                list.Add(model);
            }
            return list;
        }
        /// <summary>
        /// 得到用户组拥有的权限菜单
        /// </summary>
        /// <returns></returns>
        public List<SysAdminGrouprMenuModel> GetMenuByGroupID(int gid)
        {
            List<SysAdminGrouprMenuModel> list = new List<SysAdminGrouprMenuModel>();
            string sqltxt = @"SELECT  A.ID ,
        A.GID ,
        A.GName ,
        A.MID ,
        A.MName ,
        A.MType ,
        A.PermissionType ,
        A.AddTime ,
        A.IsEdit ,
        B.FatherID ,
        CASE a.PermissionType
          WHEN 1 THEN '查看'
          WHEN 2 THEN '编辑'
          WHEN 3 THEN '修改'
          WHEN 4 THEN '禁用'
        END AS PermissionTypeName,
        CASE a.MType
          WHEN 1 THEN '菜单'
          WHEN 2 THEN '按钮'
        END AS MTypeName,
        CASE a.IsEdit
          WHEN 0 THEN '否'
          WHEN 1 THEN '是'
        END AS IsEditName
FROM    dbo.SysAdminGrouprMenu A WITH ( NOLOCK )
        INNER JOIN dbo.SysAdminMenu B WITH ( NOLOCK ) ON A.MID = B.ID
  where GID=@gid";
            SqlParameter[] paramter = {new SqlParameter("@gid",gid) };
            DataTable dt = helper.Query(sqltxt,paramter).Tables[0];
            foreach (DataRow item in dt.Rows)
            {
                SysAdminGrouprMenuModel model = new SysAdminGrouprMenuModel();
                model.AddTime = DateTime.Parse(item["AddTime"].ToString());
                model.FatherID = int.Parse(item["FatherID"].ToString());
                model.GID = int.Parse(item["GID"].ToString());
                model.GName = item["GName"].ToString();
                model.ID = int.Parse(item["ID"].ToString());
                model.IsEdit = int.Parse(item["IsEdit"].ToString());
                model.MID = int.Parse(item["MID"].ToString());
                model.MName = item["MName"].ToString();
                model.MType = int.Parse(item["MType"].ToString());
                model.PermissionType = int.Parse(item["PermissionType"].ToString());
                model.PermissionTypeName = item["PermissionTypeName"].ToString();
                model.MenuTypeName = item["MTypeName"].ToString();
                model.IsEditName = item["IsEditName"].ToString();
                list.Add(model);
            }
            return list;

        }
    }
}
