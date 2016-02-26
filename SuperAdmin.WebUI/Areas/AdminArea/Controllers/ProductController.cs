using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SuperAdmin.datamodel;
using SuperAdmin.WebUI.Areas.AdminArea.Models;

namespace SuperAdmin.WebUI.Areas.AdminArea.Controllers
{
    public class ProductController : Controller
    {
        //系统产品管理
        // GET: /AdminArea/Product/
        /// <summary>
        ///  产品管理首页
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            ProductIndexViewModel model = new ProductIndexViewModel();
            return View(model);
        }

        /// <summary>
        /// 产品属性规格管理
        /// </summary>
        /// <returns></returns>
        public ActionResult productspec()
        {
            productspecViewModel model = new productspecViewModel();
            return View(model);
        }
        [HttpPost]
        public ActionResult addspec(ProductSpecModel addmodel)
        {
            return RedirectToAction("productspec", "Product", new { area = "AdminArea" });
        }

        /// <summary>
        /// 产品分类管理
        /// </summary>
        /// <returns></returns>
        public ActionResult productcategory()
        {
            productcategoryViewModel model = new productcategoryViewModel();
            return View(model);
        }
        /// <summary>
        /// 添加产品
        /// </summary>
        /// <returns></returns>
        public ActionResult AddProduct()
        {
            ProductInfoModel model = new ProductInfoModel();
            return View(model);
        }
    }
}
