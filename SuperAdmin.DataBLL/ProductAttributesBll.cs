using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SuperAdmin.DataDAL;
using SuperAdmin.datamodel;

namespace SuperAdmin.DataBLL
{
    public class ProductAttributesBll
    {
        ProductAttributesDal dal = new ProductAttributesDal();
        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int AddProductAttributes(ProductAttributesModel model)
        {
            return dal.AddProductAttributes(model);
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool UpdateProductAttributes(ProductAttributesModel model)
        {
            return dal.UpdateProductAttributes(model);
        }
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public ProductAttributesModel GetProductAttributesModel(int ID)
        {
            return dal.GetProductAttributesModel(ID);
        }
        /// <summary>
        /// 根据ProductID得到属性列表
        /// </summary>
        /// <param name="productid"></param>
        /// <returns></returns>
        public Dictionary<string, string> GetProductAttributesByProductID(int productid)
        {
            return dal.GetProductAttributesByProductID(productid);
        }
        /// <summary>
        /// 根据ProductID得到属性列表
        /// </summary>
        /// <param name="productid"></param>
        /// <returns></returns>
        public List<ProductAttributesModel> GetProductAttributesByPID(int productid)
        {
            return dal.GetProductAttributesByPID(productid);
        }
        /// <summary>
        /// 批量添加产品属性
        /// </summary>
        /// <param name="productid"></param>
        /// <param name="AttrList"></param>
        /// <returns></returns>
        public bool AddList(int productid,List<ProductSimpleAttr> AttrList)
        {
            bool success = true;
            if (AttrList.Count > 0)
            {
                foreach (var item in AttrList)
                {
                    ProductAttributesModel model = new ProductAttributesModel();
                    model.ProductID = productid;
                    model.ProductAttrKey = item.AttrKey;
                    model.ProductAttrValue = item.AttrValue;
                    model.ProductAttrDescript = item.descript;
                    model.IsImportent = 0;
                    model.AddTime = DateTime.Now;
                    model.AttrStatus = 1;
                    int rowcount = dal.AddProductAttributes(model);

                }
            }
            return success;
        }
    }
}
