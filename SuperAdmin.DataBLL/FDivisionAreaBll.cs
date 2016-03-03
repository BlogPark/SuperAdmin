using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SuperAdmin.datamodel;

namespace SuperAdmin.DataBLL
{
    public class FDivisionAreaBll
    {
        ArtCategoryBll artcatebll = new ArtCategoryBll();
        SystemSettingsBll settingbll = new SystemSettingsBll();
        /// <summary>
        /// 得到所有文章的分类
        /// </summary>
        /// <returns></returns>
        public Dictionary<int, string> GetAllArtCategory()
        {
            var list = artcatebll.GetALLModel(1);
            Dictionary<int, string> dic = new Dictionary<int, string>();
            foreach (var item in list)
            {
                dic.Add(item.ID, item.CName);
            }
            return dic;
        }
        /// <summary>
        /// 根据名称查找系统模块信息
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public WebModuleModel GetModuleMsgByName(string name)
        {
            return settingbll.GetSingleWebModulesByName(name);
        }

    }
}
