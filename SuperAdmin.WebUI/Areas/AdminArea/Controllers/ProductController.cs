﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SuperAdmin.DataBLL;
using SuperAdmin.datamodel;
using SuperAdmin.WebUI.Areas.AdminArea.Models;
using SuperAdmin.WebUI.Controllers;
using SuperAdmin.WebUI.Models;

namespace SuperAdmin.WebUI.Areas.AdminArea.Controllers
{
    public class ProductController : Controller
    {
        //系统产品管理
        // GET: /AdminArea/Product/

        #region 变量声明
        private ProductCategoryBll catebll = new ProductCategoryBll();
        private ProductInfoBll bll = new ProductInfoBll();
        #endregion
        /// <summary>
        ///  产品管理首页
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            ProductIndexViewModel model = new ProductIndexViewModel();
            ViewBag.PageTitle = "产品管理";
            return View(model);
        }

        /// <summary>
        /// 产品属性规格管理
        /// </summary>
        /// <returns></returns>
        public ActionResult productspec()
        {
            productspecViewModel model = new productspecViewModel();
            ViewBag.PageTitle = "";
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
            ViewBag.PageTitle = "类别管理";
            return View(model);
        }

        /// <summary>
        /// 添加产品
        /// </summary>
        /// <returns></returns>
        public ActionResult AddProduct()
        {
            AddProductViewModel model = new AddProductViewModel();
            model.categories = catebll.GetAllModel(1);
            ViewBag.PageTitle = "添加产品";
            return View(model);
        }
        /// <summary>
        /// 添加产品
        /// </summary>
        /// <returns></returns>
        public ActionResult AddProduct2()
        {
            AddProductViewModel model = new AddProductViewModel();
            model.categories = catebll.GetAllModel(1);
            ViewBag.PageTitle = "添加产品";
            return View(model);
        }
        /// <summary>
        /// 添加产品
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult AddProduct(ProductInfoModel product)
        {
            SessionLoginModel user = Session[AppContext.SESSION_LOGIN_NAME] as SessionLoginModel;
            if (user == null)
            {
                return RedirectToAction("Index", "Login", new { area = "" });
            }
            if (product != null)
            {
                product.AddUserID = user.User.ID;
                product.AddUserName = user.User.UserName;
                product.ProductStatus = 1;
                int rowcount = bll.AddProduct(product);
            }
            AddProductViewModel model = new AddProductViewModel();
            model.categories = catebll.GetAllModel(1);
            ViewBag.PageTitle = "添加产品";
            return View(model);
        }
    }
}
