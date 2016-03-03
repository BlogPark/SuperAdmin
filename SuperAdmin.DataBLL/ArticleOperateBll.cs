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
    /// 文章管理
    /// </summary>
    public class ArticleOperateBll
    {
        ArticleOperate dal = new ArticleOperate();
        #region 后台管理页面
        /// <summary>
        /// 得到所有的文章
        /// </summary>
        /// <returns></returns>
        public List<ArticlesModel> GetAllArticles()
        {
            return dal.GetAllArticles();
        }
         /// <summary>
        /// 查询一条文章信息
        /// </summary>
        /// <param name="aid"></param>
        /// <returns></returns>
        public ArticlesModel GetSingleArticleByID(int aid)
        {
            return dal.GetSingleArticleByID(aid);
        }
        /// <summary>
        /// 修改文章状态
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int UpdateArticleStatus(ArticlesModel model)
        {
            return dal.UpdateArticleStatus(model);
        }
        /// <summary>
        /// 反审文章
        /// </summary>
        /// <param name="aid"></param>
        /// <param name="reason"></param>
        /// <returns></returns>
        public int AntiTrialArticle(ArticlesModel model)
        {
            return dal.AntiTrialArticle(model);
        }
        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int AddArticle(ArticlesModel model)
        {
            return dal.AddArticle(model);
        }
        /// <summary>
        /// 更新一条文章信息
        /// </summary>
        public bool UpdateArticle(ArticlesModel model) 
        {
            return dal.UpdateArticle(model);
        }
        #endregion

        /// <summary>
        /// 查询文章信息（分页）
        /// </summary>
        /// <param name="wheremodel">查询条件</param>
        /// <param name="pageindex">页索引</param>
        /// <param name="pagesize">页容量</param>
        /// <param name="totalrowCount">总数</param>
        /// <param name="pageCount">总页数</param>
        /// <returns></returns>
        public List<ArticlesModel> GetArticleDataBypage(ArticlesModel wheremodel, int pageindex, int pagesize, out int totalrowCount, out int pageCount)
        {
            return dal.GetArticleDataBypage(wheremodel,pageindex,pagesize,out totalrowCount,out pageCount);
        }

        /// <summary>
        /// 根据ID列表得到所需文章列表
        /// </summary>
        /// <returns></returns>
        public List<ArticlesModel> GetAllArticlesbyids(string ids)
        {
            return dal.GetAllArticlesbyids(ids);
        }
    }
}
