using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SuperAdmin.DataDAL;
using SuperAdmin.datamodel;

namespace SuperAdmin.DataBLL
{
    public class ProductInfoBll
    {
        ProductInfoDal dal = new ProductInfoDal();
        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int AddProduct(ProductInfoModel model)
        {
            return dal.AddProduct(model);
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool UpdateProduct(ProductInfoModel model)
        {
            return dal.UpdateProduct(model);
        }
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public ProductInfoModel GetSingleModel(int ID)
        {
            return dal.GetSingleModel(ID);
        }
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public List<ProductInfoModel> GetAllModel()
        {
            return dal.GetAllModel();
        }
    }
}
