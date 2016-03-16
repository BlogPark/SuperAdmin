using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SuperAdmin.Common;
using SuperAdmin.datamodel;

namespace SuperAdmin.WebUI.Controllers
{
    public class publicactionController : Controller
    {
        //
        // GET: /publicaction/
        WebSplitWords sp = new WebSplitWords();
        public ActionResult Index()
        {
            return View();
        }
        /// <summary>
        /// 系统分词接口
        /// </summary>
        /// <param name="content"></param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult AdminSpiltWord(string content)
        {
            string result = "";
            List<SplitTagModel> list = new List<SplitTagModel>();
            string newcontent = content;
            if (!string.IsNullOrWhiteSpace(newcontent))
            {
                string liststr = sp.DisplaySegment(newcontent);
                list = sp.AnalyticalTagJson(liststr).Where(m => m.hot > 0).OrderByDescending(m => m.RepeatTime).Take(10).ToList();
                foreach (var item in list)
                {
                    result += item.TagID + "|" + item.TagName + ",";
                }
            }
            return Content(result);
        }
    }
}
