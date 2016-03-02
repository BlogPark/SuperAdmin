using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SuperAdmin.DataDAL;
using SuperAdmin.datamodel;

namespace SuperAdmin.DataBLL
{
    public class WebSiteImageBll
    {
        WebSiteImageDal dal = new WebSiteImageDal();
        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int AddWebSiteImage(WebSiteImageModel model)
        {
            return dal.AddWebSiteImage(model);
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool UpdateWebSiteImage(WebSiteImageModel model)
        {
            return dal.UpdateWebSiteImage(model);
        }
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public WebSiteImageModel GetSingleModel(int ID)
        {
            return dal.GetSingleModel(ID);
        }
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public List<WebSiteImageModel> GetAllModel()
        {
            return dal.GetAllModel();
        }
        /// <summary>
        /// 得到文章类别对象实体
        /// </summary>
        public List<PicCategoryModel> GetPicCategoryModel()
        {
            return dal.GetPicCategoryModel();
        }
    }
}
