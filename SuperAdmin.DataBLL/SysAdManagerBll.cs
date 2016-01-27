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
    /// 系统广告业务
    /// </summary>
    public class SysAdManagerBll
    {
        private SysAdManager dal = new SysAdManager();
        /// <summary>
        /// 得到系统所有的平台信息
        /// </summary>
        /// <returns></returns>
        public List<SystemAdSiteModel> GetAllSysSites()
        {
            return dal.GetAllSysSites();
        }
        #region 系统广告内容
        /// <summary>
        /// 查询所有的广告内容
        /// </summary>
        /// <returns></returns>
        public List<SystemAdModel> GetAllSystemAd()
        {
            return dal.GetAllSystemAd();
        }
        /// <summary>
        /// 根据ID列表查询
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        public List<SystemAdModel> GetSystemAdByID(string ids)
        {
            return dal.GetSystemAdByID(ids);
        }
        /// <summary>
        /// 根据ID查询广告信息
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        public SystemAdModel GetSingleSystemAd(int ID)
        {
            return dal.GetSingleSystemAd(ID);
        }
        /// <summary>
        /// 添加系统广告内容
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int AddNewSystemAd(SystemAdModel model)
        {
            return dal.AddNewSystemAd(model);
        }
        /// <summary>
        /// 修改广告内容
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int UpdateSystemAd(SystemAdModel model)
        {
            return dal.UpdateSystemAd(model);
        }
        /// <summary>
        /// 删除一条广告信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public int DeleteSystemAd(int id)
        {
            return dal.DeleteSystemAd(id);
        }
        #endregion
    }
}
