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
        #endregion
    }
}
