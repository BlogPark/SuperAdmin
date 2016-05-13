using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SuperAdmin.datamodel;

namespace SuperAdmin.DataBLL.Website
{
    /// <summary>
    /// 网站前端首页使用类
    /// </summary>
    public class WebIndexBll
    {
        static ProductInfoBll productbll = new ProductInfoBll();//产品处理类
        static WebNewsBll webnewsbll = new WebNewsBll();//网站新闻处理类
        /// <summary>
        /// 得到推荐的产品列表
        /// </summary>
        /// <returns></returns>
        public static List<ProductInfoModel> GetCommendProductList()
        {
            return productbll.GetCommendProductList(8);
        }
        /// <summary>
        /// 得到网站首页展示的新闻列表
        /// </summary>
        /// <returns></returns>
        public static List<WebNewsModel> GetIndexWebNewsList()
        {
            return webnewsbll.GetNewsByAddtimelList(8);
        }
    }
}
