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
    /// 系统设置数据层操作
    /// </summary>
    public class SystemSettingsBll
    {
        public SystemSettings dal = new SystemSettings();
        private WebSiteImageDal imagedal = new WebSiteImageDal();
        /// <summary>
        /// 得到所有的系统用户
        /// </summary>
        /// <returns></returns>
        public List<SysAdminUserModel> GetAllSysAdminUser()
        {
            return dal.GetAllSysAdminUser();
        }
        /// <summary>
        /// 根据ID查询系统用户信息
        /// </summary>
        /// <param name="userid"></param>
        /// <returns></returns>
        public SysAdminUserModel GetSingleAdminUser(int userid)
        {
            return dal.GetSingleAdminUser(userid);
        }
        /// <summary>
        /// 新插入系统用户
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int AddNewSysAdminUser(SysAdminUserModel model)
        {
            return dal.AddNewSysAdminUser(model);
        }
        /// <summary>
        /// 修改系统用户
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int UpdateSysAdminUser(SysAdminUserModel model)
        {
            return dal.UpdateSysAdminUser(model);
        }
        /// <summary>
        /// 禁用系统用户
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int DelSysAdminUser(int userid)
        {
            return dal.DelSysAdminUser(userid);
        }


        #region 系统配置表设置
        /// <summary>
        /// 得到所有的系统配置
        /// </summary>
        /// <returns></returns>
        public List<SysAdminConfigsModel> GetAllConfigs()
        {
            return dal.GetAllConfigs();
        }
        /// <summary>
        /// 插入配置信息
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int AddConfigInfo(SysAdminConfigsModel model)
        { return dal.AddConfigInfo(model); }
        /// <summary>
        /// 根据ID得到配置信息
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        public List<SysAdminConfigsModel> GetConfigsByIDs(string ids)
        { return dal.GetConfigsByIDs(ids); }
        /// <summary>
        /// 修改配置信息
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int UpdateConfigs(SysAdminConfigsModel model)
        {
            return dal.UpdateConfigs(model);
        }
        /// <summary>
        /// 得到顶级配置项目
        /// </summary>
        /// <returns></returns>
        public List<SysAdminConfigsModel> GetFirstConfigs()
        {
            return dal.GetFirstConfigs();
        }
        /// <summary>
        /// 禁用配置项
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public int DelConfig(int id)
        { return dal.DelConfig(id); }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public SysAdminConfigsModel GetSingleSysAdminConfigsModel(int ID)
        {
            return dal.GetSingleSysAdminConfigsModel(ID);
        }
        #endregion

        #region 网站前端基础配置
        /// <summary>
        /// 得到网站基本信息
        /// </summary>
        /// <returns></returns>
        public WebSettingsModel GetWebSetting()
        {
            return dal.GetWebSetting();
        }
        /// <summary>
        /// 修改网站基本信息
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int UpdateWebSetting(WebSettingsModel model)
        {
            return dal.UpdateWebSetting(model);
        }
        #endregion

        #region 网站前端模块设置
        /// <summary>
        /// 得到所有的模块
        /// </summary>
        /// <returns></returns>
        public List<WebModuleModel> GetAllWebModules()
        {
            return dal.GetAllWebModules();
        }
        /// <summary>
        /// 根据ID得到模块信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public WebModuleModel GetWebModuleByID(int id)
        {
            return dal.GetWebModuleByID(id);
        }
        /// <summary>
        /// 添加模块
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int AddWebModule(WebModuleModel model)
        {
            return dal.AddWebModule(model);
        }
        /// <summary>
        /// 修改数据
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int UpdateWebModule(WebModuleModel model)
        {
            return dal.UpdateWebModule(model);
        }
        /// <summary>
        /// 根据名称查找网站模块
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public WebModuleModel GetSingleWebModulesByName(string name)
        {
            return dal.GetSingleWebModulesByName(name);
        }
        #endregion

        #region 网站前端菜单设置
        /// <summary>
        /// 添加菜单
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int AddWebMenu(WebMenusModel model)
        {
            return dal.AddWebMenu(model);
        }
        /// <summary>
        /// 更改菜单
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int UpdateWebMenu(WebMenusModel model)
        {
            return dal.UpdateWebMenu(model);
        }
        /// <summary>
        /// 根据ID得到菜单信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public WebMenusModel GetWebMenuByID(int id)
        {
            return dal.GetWebMenuByID(id);
        }
        /// <summary>
        /// 得到全部的菜单
        /// </summary>
        /// <returns></returns>
        public List<WebMenusModel> GetAllWebMenusList(int isuse = 0)
        {
            return dal.GetAllWebMenusList(isuse);
        }
        /// <summary>
        /// 得到所有的顶级菜单
        /// </summary>
        /// <returns></returns>
        public List<WebMenusModel> GetAllFirstWebMenu()
        {
            return dal.GetAllFirstWebMenu();
        }
        #endregion

        #region 查询网页图片
        /// <summary>
        /// 根据ID或分类得到网站图片信息
        /// </summary>
        /// <param name="name"></param>
        /// <param name="cateid"></param>
        /// <returns></returns>
        public List<WebSiteImageModel> GetImageList(string name, int cateid)
        {
            return imagedal.GetModelListByNamecate(name,cateid);
        }
        /// <summary>
        /// 得到网站图片的分类
        /// </summary>
        /// <returns></returns>
        public List<PicCategoryModel> GetWebImageCatelist()
        {
            return imagedal.GetPicCategoryModel();
        }
        #endregion
    }
}
