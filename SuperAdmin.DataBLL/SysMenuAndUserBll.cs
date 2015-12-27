using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SuperAdmin.DataDAL;
using SuperAdmin.datamodel;

namespace SuperAdmin.DataBLL
{
    public class SysMenuAndUserBll
    {
        private SysMenuAndUser dal = new SysMenuAndUser();
        /// <summary>
        /// 登录信息
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public SysAdminUserModel GetUserForLogin(SysAdminUserModel user)
        {
            return dal.GetUserForLogin(user);
        }
         /// <summary>
        /// 查询用户拥有的菜单权限
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public List<SysAdminMenuModel> GetUserAttributeMenu(SysAdminUserModel user)
        {
            return dal.GetUserAttributeMenu(user);
        }

        /// <summary>
        /// 查询所有菜单
        /// </summary>
        /// <returns></returns>
        public List<SysAdminMenuModel> GetAllSysMenu()
        {
            return dal.GetAllSysMenu();
        }

        public int AddAndUpdateData(SysAdminMenuModel model)
        {
            return dal.AddAndUpdateData(model);
        }
    }
}
