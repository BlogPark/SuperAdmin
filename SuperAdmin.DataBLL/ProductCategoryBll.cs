using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SuperAdmin.DataDAL;
using SuperAdmin.datamodel;

namespace SuperAdmin.DataBLL
{
    public class ProductCategoryBll
    {
        ProductCategoryDal dal = new ProductCategoryDal();
        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int AddProductCategory(ProductCategoryModel model)
        {
            return dal.AddProductCategory(model);
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool UpdateProductCategory(ProductCategoryModel model)
        {
            return dal.UpdateProductCategory(model);
        }
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public ProductCategoryModel GetSingleModel(int ID)
        {
            return dal.GetSingleModel(ID);
        }
        /// <summary>
        /// 得到全部对象实体
        /// </summary>
        public List<ProductCategoryModel> GetAllModel()
        {
            return dal.GetAllModel();
        }
    }
}
