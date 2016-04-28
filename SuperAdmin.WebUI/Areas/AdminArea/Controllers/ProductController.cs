using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SuperAdmin.DataBLL;
using SuperAdmin.datamodel;
using SuperAdmin.WebUI.Areas.AdminArea.Models;
using SuperAdmin.WebUI.Controllers;
using SuperAdmin.WebUI.Models;
using Webdiyer.WebControls.Mvc;

namespace SuperAdmin.WebUI.Areas.AdminArea.Controllers
{
    public class ProductController : Controller
    {
        //系统产品管理
        // GET: /AdminArea/Product/

        #region 变量声明
        private ProductCategoryBll catebll = new ProductCategoryBll();
        private ProductInfoBll bll = new ProductInfoBll();
        private readonly int PageSize = 30;
        #endregion
        /// <summary>
        ///  产品管理首页
        /// </summary>
        /// <returns></returns>
        public ActionResult Index(ProductInfoModel product,int page = 1)
        {
            int totalrowcount = 0;
            product.PageIndex = page;
            product.PageSize = PageSize;
            List<ProductInfoModel> list = bll.GetProductListForPage(product, out totalrowcount);
            PagedList<ProductInfoModel> pageList = null;
            if (list != null)
            {
                pageList = new PagedList<ProductInfoModel>(list, page, PageSize, totalrowcount);
            }
            this.ViewData["product.ProductCateID"] = GetCategoriesListItem();
            this.ViewData["product.ProductStatus"] = GetStatusListItem(0);
            this.ViewData["product.IsCommend"] = GetcommendListItem(10);
            ProductIndexViewModel model = new ProductIndexViewModel();
            model.productlist = pageList;
            model.totalcount = totalrowcount;
            model.pagesize = PageSize;
            model.currentpage = page;
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
            model.catelists = catebll.GetAllModel();
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
        /// 添加产品（测试）
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
        /// <summary>
        /// 禁用一条数据
        /// </summary>
        /// <param name="cateid"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult DeleteCate(int cateid)
        {
            if (cateid < 1)
            {
                return Json("0");
            }
            bool success = catebll.DeleteProductCategory(cateid);
            if (success)
            {
                return Json("1");
            }
            else
            {
                return Json("0");
            }
        }
        /// <summary>
        /// 设置推荐
        /// </summary>
        /// <param name="ids"></param>
        /// <param name="commend"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult setcommend(string ids,int commend)
        {
            int rowcount = bll.SetCommend(ids,commend);
            if (rowcount > 0)
            {
                return Json("1");
            }
            else
            {
                return Json("0");
            }
        }
        /// <summary>
        /// 下架产品
        /// </summary>
        /// <param name="pid"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult delepro(int pid)
        {
            int rowcount = bll.DeleteProduct(pid);
            if (rowcount > 0)
            {
                return Json("1");
            }
            else
            {
                return Json("0");
            }
        }
        /// <summary>
        /// 获取分类列表
        /// </summary>
        /// <returns></returns>
        private List<SelectListItem> GetCategoriesListItem(long defval = 0)
        {
            List<SelectListItem> items = new List<SelectListItem>();
            items.Add(new SelectListItem { Text = "请选择", Value = "0", Selected = defval == 0 ? true : false });
            var classList = catebll.GetAllModel(1);

            if (classList != null && classList.Count() > 0)
            {
                foreach (var item in classList)
                {
                    string strName = item.CateName;
                    int cateid = item.ID;

                    items.Add(new SelectListItem { Text = strName, Value = cateid.ToString(), Selected = defval == item.ID });
                }
            }
            return items;
        }
        /// <summary>
        /// 得到状态列表
        /// </summary>
        /// <param name="defval"></param>
        /// <returns></returns>
        private List<SelectListItem> GetStatusListItem(int defval = 1)
        {
            List<SelectListItem> items = new List<SelectListItem>();
            items.Add(new SelectListItem { Text = "全部", Value = "0", Selected = defval == 0 });
            items.Add(new SelectListItem { Text = "已发布", Value = "1", Selected = defval == 1 });
            items.Add(new SelectListItem { Text = "已下架", Value = "2", Selected = defval == 2 });
            items.Add(new SelectListItem { Text = "已删除", Value = "3", Selected = defval == 3 });
            return items;
        }
        /// <summary>
        /// 得到状态列表
        /// </summary>
        /// <param name="defval"></param>
        /// <returns></returns>
        private List<SelectListItem> GetcommendListItem(int defval = 1)
        {
            List<SelectListItem> items = new List<SelectListItem>();
            items.Add(new SelectListItem { Text = "请选择", Value = "10", Selected = defval == 10 });
            items.Add(new SelectListItem { Text = "是", Value = "1", Selected = defval == 1 });
            items.Add(new SelectListItem { Text = "否", Value = "0", Selected = defval == 0 });
            return items;
        }
    }
}
