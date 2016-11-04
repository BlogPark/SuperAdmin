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
    /// 系统公告操作类
    /// </summary>
    public class SysNoticeMessageBll
    {
        SysNoticeMessageDal dal = new SysNoticeMessageDal();
        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int AddSysNotice(SysNoticeMessageModel model)
        {
            return dal.AddSysNotice(model);
        }
        /// <summary>
        /// 更新一条数据详细信息
        /// </summary>
        public bool UpdateSysNotice(SysNoticeMessageModel model)
        {
            return dal.UpdateSysNotice(model);
        }
         /// <summary>
        /// 更新一条数据的状态
        /// </summary>
        public bool UpdateSysNoticeStatus(int id, int status)
        {
            return dal.UpdateSysNoticeStatus(id,status);
        }
         /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public SysNoticeMessageModel GetSingleSysNotice(int ID)
        {
            return dal.GetSingleSysNotice(ID);
        }
        /// <summary>
        /// 得到全部公告信息
        /// </summary>
        public List<SysNoticeMessageModel> GetAllSysNotice()
        {
            return dal.GetAllSysNotice();
        }
    }
}
