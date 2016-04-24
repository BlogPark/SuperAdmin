﻿using System;
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
        ProductAttributesBll proattr = new ProductAttributesBll();
        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int AddProduct(ProductInfoModel model)
        {
           int productid= dal.AddProduct(model);
           if (productid > 0)
           {
               bool success = proattr.AddList(productid,model.AttrLists);
               if (success)
                   return 1;
               else
                   return 0;
           }
           else
           {
               return 0;
           }
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
         /// <summary>
        /// 得到分页数据
        /// </summary>
        /// <param name="model"></param>
        /// <param name="totalrowcount"></param>
        /// <returns></returns>
        public List<ProductInfoModel> GetProductListForPage(ProductInfoModel model, out int totalrowcount)
        {
            List<ProductInfoModel> list= dal.GetProductListForPage(model,out totalrowcount);
            return list;
        }
    }
}
