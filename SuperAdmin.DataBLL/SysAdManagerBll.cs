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
        /// 根据多条件列表查询
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        public List<SystemAdModel> GetSystemAdByWhereStr(SystemAdModel where)
        {
            return dal.GetSystemAdByWhereStr(where);
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

        #region 系统广告位置
        /// <summary>
        /// 得到所有的广告位置
        /// </summary>
        /// <param name="isneeduse">是否只读取激活的信息</param>
        /// <returns></returns>
        public List<SystemAdPositionModel> GetAllAdPosition(bool isneeduse = false)
        {
            return dal.GetAllAdPosition(isneeduse);
        }
         /// <summary>
        /// 得到符合条件的所有的广告位置
        /// </summary>
        /// <param name="where">条件信息</param>
        /// <returns></returns>
        public List<SystemAdPositionModel> GetAllAdPositionByWhereStr(SystemAdPositionModel where)
        {
            return dal.GetAllAdPositionByWhereStr(where);
        }
         /// <summary>
        /// 添加一个广告位置
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int AddSysAdPosition(SystemAdPositionModel model)
        {
            return dal.AddSysAdPosition(model);
        }
        /// <summary>
        /// 添加一个广告位置
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int UpdateSysAdPosition(SystemAdPositionModel model)
        {
            return dal.UpdateSysAdPosition(model);
        }
        /// <summary>
        /// 更改广告位置状态值
        /// </summary>
        /// <param name="id"></param>
        /// <param name="status"></param>
        /// <returns></returns>
        public int UpdateAdPositionStatus(int id, int status)
        {
            return dal.UpdateAdPositionStatus(id,status);
        }
        /// <summary>
        /// 根据信息得到一条单独信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public SystemAdPositionModel GetSinglePositionByID(int id)
        {
            return dal.GetSinglePositionByID(id);
        }
        #endregion

        #region 系统广告排期
        /// <summary>
        /// 得到所有的广告排期信息
        /// </summary>
        /// <param name="isused">是否只需要激活的</param>
        /// <returns></returns>
        public List<SystemAdScheduleModel> GetAllSchedule(bool isused = false)
        {
            return dal.GetAllSchedule(isused);
        }
         /// <summary>
        /// 根据ID得到排期详细信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public SystemAdScheduleModel GetSingleScheduleByID(int id)
        {
            return dal.GetSingleScheduleByID(id);
        }
         /// <summary>
        /// 添加排期信息
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int AddSchedule(SystemAdScheduleModel model)
        {
            return dal.AddSchedule(model);
        }
        /// <summary>
        /// 修改排期信息
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int UpdateSchedule(SystemAdScheduleModel model)
        {
            return dal.UpdateSchedule(model);
        }
        /// <summary>
        /// 更改排期状态
        /// </summary>
        /// <param name="id"></param>
        /// <param name="status"></param>
        /// <returns></returns>
        public int UpdateScheduleStatus(int id, int status)
        {
            return dal.UpdateScheduleStatus(id,status);
        }
        #endregion
    }
}
