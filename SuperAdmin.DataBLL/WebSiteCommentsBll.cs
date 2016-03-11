using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SuperAdmin.DataDAL;
using SuperAdmin.datamodel;

namespace SuperAdmin.DataBLL
{
    public class WebSiteCommentsBll
    {
        WebSiteCommentsDal dal = new WebSiteCommentsDal();
         /// <summary>
        /// 增加一条数据
        /// </summary>
        public int AddWebSiteComments(WebSiteCommentsModel model)
        {
            return dal.AddWebSiteComments(model);
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool UpdateWebSiteCommentsStatus(int id)
        {
            return dal.UpdateWebSiteCommentsStatus(id);
        }
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public WebSiteCommentsModel GetSingleModel(int ID)
        {
            return dal.GetSingleModel(ID);
        }
        /// <summary>
        /// 得到一个对象的全部评论实体
        /// </summary>
        public List<WebSiteCommentsModel> GetAllListModel(int objID, int type)
        {
            return dal.GetAllListModel(objID,type);
        }
    }
}
