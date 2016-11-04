using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace System.Web.Mvc
{
    public static class PageHelper
    {
        public static string Pagination(this UrlHelper urlHelper, string actionName, string controllerName, object routeValues, string pageParam, int pageSize, int pageCount, int maxlast = 0)
        {
            const int numbersInMiddle = 6;

            var dict = HttpContext.Current.Request.RequestContext.RouteData.Values;//ctx.HttpContext.Request.RequestContext.RouteData.Values;
            var pageCurrent = 1;
            var param = "";

            //获取 ～/Page/{page number} 的页号参数
            if (dict[pageParam] != null)
                param = dict[pageParam].ToString();

            if (string.IsNullOrEmpty(param))
            {
                param = HttpContext.Current.Request.RequestContext.HttpContext.Request.Params[pageParam];
                param = HttpContext.Current.Request[pageParam];
                if (string.IsNullOrEmpty(param))
                    param = "1";
            }

            pageCurrent = Convert.ToInt32(param);

            var start = (pageCurrent - 1) * pageSize + 1;
            var end = start + pageSize - 1;
            var sideNumber = (int)Math.Floor((double)numbersInMiddle / 2);

            if (routeValues != null)
            {
                var dict1 = new RouteValueDictionary(routeValues);
                foreach (var d in dict1)
                {
                    if (dict.ContainsKey(d.Key) == false)
                        dict.Add(d.Key, d.Value);

                }
            }
            StringBuilder sbStr = new StringBuilder("<ul class=\"pagination\">");
            dict[pageParam] = "1";
            string homeUrl = urlHelper.Action(actionName, controllerName, dict);
            #region
            //上一页和首页
            if (pageCurrent <= 1)
            {
                sbStr.AppendFormat("<li><a target=\"_self\"  href=\"{0}\">首页</a></li>", homeUrl);
                sbStr.AppendFormat("<li><a target=\"_self\"  href=\"{0}\" >上一页</a></li>", homeUrl);
            }
            else
            {
                sbStr.AppendFormat("<li><a target=\"_self\"  href=\"{0}\">首页</a></li>", homeUrl);

                int pagePrev = pageCurrent - 1;
                if (pagePrev <= 0)
                {
                    sbStr.AppendFormat("<li><a target=\"_self\"  href=\"{0}\" >上一页</a></li>", homeUrl);
                }
                else
                {
                    dict[pageParam] = pagePrev.ToString();
                    sbStr.AppendFormat("<li><a target=\"_self\"  href=\"{0}\" >上一页</a></li>", urlHelper.Action(actionName, controllerName, dict));
                }
            }
            var pageParam_1 = pageParam;
            #endregion
            int last = 0;
            int iterations = numbersInMiddle;
            if (pageCurrent < sideNumber)
            {
                iterations = numbersInMiddle + (sideNumber - pageCurrent);
            }
            //最后几页，补齐
            int iterationsPix = pageCount - pageCurrent;
            if (iterationsPix < iterations)
            {
                int complemented = iterations - sideNumber - iterationsPix;//补全分页页码个数
                for (var i = 1; i <= complemented; i++)
                {
                    if ((Math.Abs(pageCurrent - iterations) + i) <= pageCount)//当前页码不能大于最大页数
                    {
                        //一般页处理 
                        dict[pageParam] = (Math.Abs(pageCurrent - iterations) + i).ToString();
                        sbStr.AppendFormat("<li><a target=\"_self\" href=\"{0}\">{1}</a></li>", urlHelper.Action(actionName, controllerName, dict), (Math.Abs(pageCurrent - iterations) + i));
                        last = Math.Abs(pageCurrent - iterations) + i;
                    }
                }
            }
            //处理中间显示的页码                
            for (var i = 1; i <= iterations; i++)
            {
                //一共最多显示5个页码，前面2个，后面2个  
                if ((pageCurrent + i - sideNumber) >= 1 && (pageCurrent + i - sideNumber) <= pageCount)
                {
                    //一般页处理 
                    var tempPage = (pageCurrent + i - sideNumber).ToString();
                    dict[pageParam] = tempPage;
                    if (param == tempPage)
                    {
                        sbStr.Append(string.Format("<li class=\"active\"><a target=\"_self\"  href=\"#\">{0}</a></li>", pageCurrent));
                    }
                    else
                    {
                        sbStr.AppendFormat("<li><a target=\"_self\" href=\"{0}\">{1}</a></li>", urlHelper.Action(actionName, controllerName, dict), (pageCurrent + i - sideNumber));
                    }
                    last = pageCurrent + i - sideNumber;
                }
            }
            if (pageCount > numbersInMiddle)
            {
                var diffCount = (pageCount - last);
                var x = diffCount / 3;
                bool difffix = true;

                if (x > 0 && diffCount >= numbersInMiddle)
                {
                    var mod = diffCount % 3;

                    for (var i = 1; i <= 3; i++)
                    {
                        var pNew = (last + x * i) + mod;
                        if (pNew > pageCount || pNew <= last) break;
                        if (difffix)
                        {
                            sbStr.Append("<li>....</li>");
                            difffix = false;
                        }
                        dict[pageParam] = pNew.ToString();
                        sbStr.AppendFormat("<li><a target=\"_self\" href=\"{0}\">{1}</a></li>", urlHelper.Action(actionName, controllerName, dict), pNew);
                    }
                }
                else if (difffix)
                {
                    var mod = diffCount % 3;
                    if (mod >= 0 && last < pageCount)
                    {
                        if (difffix)
                        {
                            sbStr.Append("<td><i>...</i></td>");
                            difffix = false;
                        }
                        if (mod == 0) mod = 3;
                        for (var i = 1; i <= mod; i++)
                        {
                            if ((last + (i * mod)) > pageCount) break;
                            dict[pageParam] = (last + (i * mod)).ToString();
                            sbStr.AppendFormat("<li><a target=\"_self\" href=\"{0}\">{1}</a></li>", urlHelper.Action(actionName, controllerName, dict), (last + (i * mod)));
                        }
                    }
                }
            }
            dict[pageParam] = (pageCount).ToString();
            string endUrl = urlHelper.Action(actionName, controllerName, dict);
            //下一页和最后一页
            if (pageCurrent >= pageCount)
            {
                sbStr.AppendFormat("<li><a target=\"_self\"   href=\"{0}\" >下一页</a></li>", endUrl);
                sbStr.AppendFormat("<li><a target=\"_self\"   href=\"{0}\">尾页</a></li>", endUrl);
            }
            else
            {
                int pageNext = pageCurrent + 1;
                if (pageNext > pageCount)
                {
                    sbStr.AppendFormat("<li><a target=\"_self\"  href=\"{0}\" >下一页</a></li>", endUrl);
                }
                else
                {
                    dict[pageParam_1] = pageNext.ToString();
                    sbStr.AppendFormat("<li><a target=\"_self\"  href=\"{0}\" >下一页</a></li>", urlHelper.Action(actionName, controllerName, dict));
                }

                dict[pageParam_1] = pageCount.ToString();
                sbStr.AppendFormat("<li><a  target=\"_self\"   href=\"{0}\">尾页</a></li>", urlHelper.Action(actionName, controllerName, dict));
            }
            sbStr.Append("</ul>");
            return sbStr.ToString();
        }
    }
}