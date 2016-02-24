using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SuperAdmin.DataDAL;
using SuperAdmin.datamodel;

namespace SuperAdmin.DataBLL
{
    public class WebfaqMsgBll
    {
        WebfaqMsgDal dal = new WebfaqMsgDal();
        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int AddWebfaqMsg(WebfaqMsgModel model)
        {
            return dal.AddWebfaqMsg(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool UpdateWebfaqMsg(WebfaqMsgModel model)
        {
            return dal.UpdateWebfaqMsg(model);
        }

        /// <summary>
        ///删除一条数据
        /// </summary>
        public bool DeleteWebfaqMsg(int id, int status)
        {
            return dal.DeleteWebfaqMsg(id, status);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public WebfaqMsgModel GetSingleDataModel(int ID)
        {
            return dal.GetSingleDataModel(ID);
        }
        /// <summary>
        /// 得到全部对象实体
        /// </summary>
        public List<WebfaqMsgModel> GetAllDataModel()
        {
            return dal.GetAllDataModel();
        }
    }
}
