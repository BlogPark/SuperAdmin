using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SuperAdmin.DataDAL;
using SuperAdmin.datamodel;

namespace SuperAdmin.DataBLL
{
    public class ArtCategoryBll
    {
        ArtCategoryDal dal = new ArtCategoryDal();
        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int AddArtCategory(ArtCategoryModel model)
        {
            return dal.AddArtCategory(model);
        }
        /// <summary>
        /// 更新一条数据状态
        /// </summary>
        public bool UpdateArtCategoryStatus(int id,int status)
        {
            return dal.UpdateArtCategoryStatus(id,status);
        }
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public ArtCategoryModel GetSingleModel(int ID)
        {
            return dal.GetSingleModel(ID);
        }
        /// <summary>
        /// 得到全部对象实体
        /// </summary>
        public List<ArtCategoryModel> GetALLModel(int isuse = 0)
        {
            return dal.GetALLModel(isuse);
        }
    }
}
