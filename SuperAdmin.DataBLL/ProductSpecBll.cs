using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SuperAdmin.DataDAL;
using SuperAdmin.datamodel;

namespace SuperAdmin.DataBLL
{
    public  class ProductSpecBll
    {
        ProductSpecDal dal = new ProductSpecDal();
         /// <summary>
        /// 增加一条数据
        /// </summary>
        public int AddProductSpec(ProductSpecModel model)
        {
            return dal.AddProductSpec(model);
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool UpdateMsg(ProductSpecModel model)
        {
            return dal.UpdateMsg(model);
        }
        /// <summary>
        /// 更新数据状态
        /// </summary>
        public bool Updatestatus(int id, int status)
        {
            return dal.Updatestatus(id,status);
        }
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public ProductSpecModel GetSingleModel(int ID)
        {
            return dal.GetSingleModel(ID);
        }
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public List<ProductSpecModel> GetSingleModelByIds(string ids)
        {
            return dal.GetSingleModelByIds(ids);
        }
         /// <summary>
        /// 得到全部对象实体
        /// </summary>
        public List<ProductSpecModel> GetAllModel()
        {
            return dal.GetAllModel();
        }
        /// <summary>
        /// 根据类型得到全部对象实体
        /// </summary>
        public List<ProductSpecModel> GetAllModelByType(int typeid)
        {
            return dal.GetAllModelByType(typeid);
        }
    }
}
