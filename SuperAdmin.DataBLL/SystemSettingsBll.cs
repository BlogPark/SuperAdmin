using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SuperAdmin.DataDAL;
using SuperAdmin.datamodel;

namespace SuperAdmin.DataBLL
{
    /// <summary>
    /// 系统设置数据层操作
    /// </summary>
    public  class SystemSettingsBll
    {
        public SystemSettings dal = new SystemSettings();
        /// <summary>
        /// 得到所有的系统用户
        /// </summary>
        /// <returns></returns>
        public List<SysAdminUserModel> GetAllSysAdminUser()
        {
            return dal.GetAllSysAdminUser();
        }
        /// <summary>
        /// 根据ID查询系统用户信息
        /// </summary>
        /// <param name="userid"></param>
        /// <returns></returns>
        public SysAdminUserModel GetSingleAdminUser(int userid)
        {
            return dal.GetSingleAdminUser(userid);
        }
        /// <summary>
        /// 新插入系统用户
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int AddNewSysAdminUser(SysAdminUserModel model)
        {
            return dal.AddNewSysAdminUser(model);
        }
        /// <summary>
        /// 修改系统用户
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int UpdateSysAdminUser(SysAdminUserModel model)
        {
            return dal.UpdateSysAdminUser(model);
        }
        /// <summary>
        /// 禁用系统用户
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int DelSysAdminUser(int userid)
        {
            return dal.DelSysAdminUser(userid);
        }
    }
}
