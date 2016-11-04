using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SuperAdmin.datamodel;
using SuperAdmin.DataDAL;

namespace SuperAdmin.DataBLL
{
    /// <summary>
    /// 网站新闻操作管理类
    /// </summary>
    public  class WebNewsBll
    {
        WebNewsDal dal = new WebNewsDal();
        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int AddWebNews(WebNewsModel model)
        {
            return dal.AddWebNews(model);
        }
         /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool UpdateWebNews(WebNewsModel model)
        {
            return dal.UpdateWebNews(model);
        }
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public WebNewsModel GetSingleModel(int ID)
        {
            return dal.GetSingleModel(ID);
        }
        /// <summary>
        /// 得到全部的对象实体
        /// </summary>
        /// <returns></returns>
        public List<WebNewsModel> GetAllModelList()
        {
            return dal.GetAllModelList();
        }
        /// <summary>
        /// 更新一条信息的状态
        /// </summary>
        /// <param name="id"></param>
        /// <param name="status"></param>
        /// <returns></returns>
        public bool UpdateWebnewsStatus(int id, int status)
        {
            return dal.UpdateWebnewsStatus(id,status);
        }

         /// <summary>
        /// 得到全部的对象实体
        /// </summary>
        /// <returns></returns>
        public List<WebNewsModel> GetNewsByAddtimelList(int top = 8)
        {
            return dal.GetNewsByAddtimelList(top);
        }
    }
}
