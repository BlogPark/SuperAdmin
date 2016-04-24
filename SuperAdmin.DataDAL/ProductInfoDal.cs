using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SuperAdmin.datamodel;

namespace SuperAdmin.DataDAL
{
    /// <summary>
    /// 产品操作类
    /// </summary>
    public class ProductInfoDal
    {
        DbHelperSQL helper = new DbHelperSQL();
        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int AddProduct(ProductInfoModel model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into ProductInfo(");
            strSql.Append("ProductCoverImg,ProductStatus,AddUserID,AddUserName,AddTime,ProductName,ProductSpecID,ProductSpecName,ProductAttributeIDs,ProductCostPrice,ProductStandardPrice,ProductSalePrice,ProductDescription,ProductCateID,ProductCateName,ProductSmallPic,ProductContent");
            strSql.Append(") values (");
            strSql.Append("@ProductCoverImg,@ProductStatus,@AddUserID,@AddUserName,GETDATE(),@ProductName,@ProductSpecID,@ProductSpecName,@ProductAttributeIDs,@ProductCostPrice,@ProductStandardPrice,@ProductSalePrice,@ProductDescription,@ProductCateID,@ProductCateName,@ProductSmallPic,@ProductContent");
            strSql.Append(") ");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
			            new SqlParameter("@ProductCoverImg", SqlDbType.NVarChar,200) ,            
                        new SqlParameter("@ProductStatus", SqlDbType.Int,4) ,            
                        new SqlParameter("@AddUserID", SqlDbType.Int,4) ,            
                        new SqlParameter("@AddUserName", SqlDbType.NVarChar,50) ,      
                        new SqlParameter("@ProductName", SqlDbType.NVarChar,500) ,            
                        new SqlParameter("@ProductSpecID", SqlDbType.Int,4) ,            
                        new SqlParameter("@ProductSpecName", SqlDbType.NVarChar,500) ,            
                        new SqlParameter("@ProductAttributeIDs", SqlDbType.NVarChar,500) ,            
                        new SqlParameter("@ProductCostPrice", SqlDbType.Decimal,9) ,            
                        new SqlParameter("@ProductStandardPrice", SqlDbType.Decimal,9) ,            
                        new SqlParameter("@ProductSalePrice", SqlDbType.Decimal,9) ,            
                        new SqlParameter("@ProductDescription", SqlDbType.NVarChar,500) , 
                         new SqlParameter("@ProductCateID", SqlDbType.Int) ,
                          new SqlParameter("@ProductCateName", SqlDbType.NVarChar),
                          new SqlParameter("@ProductSmallPic",SqlDbType.NVarChar),
                          new SqlParameter("@ProductContent",SqlDbType.NVarChar)
            };

            parameters[0].Value = model.ProductCoverImg;
            parameters[1].Value = model.ProductStatus;
            parameters[2].Value = model.AddUserID;
            parameters[3].Value = model.AddUserName;
            parameters[4].Value = model.ProductName;
            parameters[5].Value = model.ProductSpecID;
            parameters[6].Value = model.ProductSpecName;
            parameters[7].Value = model.ProductAttributeIDs;
            parameters[8].Value = model.ProductCostPrice;
            parameters[9].Value = model.ProductStandardPrice;
            parameters[10].Value = model.ProductSalePrice;
            parameters[11].Value = model.ProductDescription;
            parameters[12].Value = model.ProductCateID;
            parameters[13].Value = model.ProductCateName;
            parameters[14].Value = model.ProductSmallPic;
            parameters[15].Value = model.ProductContent;
            object obj = helper.GetSingle(strSql.ToString(), parameters);
            if (obj == null)
            {
                return 0;
            }
            else
            {
                return Convert.ToInt32(obj);
            }

        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool UpdateProduct(ProductInfoModel model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update ProductInfo set ");
            strSql.Append(" ProductCoverImg = @ProductCoverImg , ");
            strSql.Append(" ProductStatus = @ProductStatus , ");
            strSql.Append(" ProductName = @ProductName , ");
            strSql.Append(" ProductSpecID = @ProductSpecID , ");
            strSql.Append(" ProductSpecName = @ProductSpecName , ");
            strSql.Append(" ProductAttributeIDs = @ProductAttributeIDs , ");
            strSql.Append(" ProductCostPrice = @ProductCostPrice , ");
            strSql.Append(" ProductStandardPrice = @ProductStandardPrice , ");
            strSql.Append(" ProductSalePrice = @ProductSalePrice , ");
            strSql.Append(" ProductDescription = @ProductDescription  ");
            strSql.Append(" ProductCateID = @ProductCateID  ");
            strSql.Append(" ProductCateName = @ProductCateName  ");
            strSql.Append(" where ID=@ID ");

            SqlParameter[] parameters = {
			            new SqlParameter("@ID", SqlDbType.Int,4) ,            
                        new SqlParameter("@ProductCoverImg", SqlDbType.NVarChar,200) ,            
                        new SqlParameter("@ProductStatus", SqlDbType.Int,4) , 
                        new SqlParameter("@ProductName", SqlDbType.NVarChar,500) ,            
                        new SqlParameter("@ProductSpecID", SqlDbType.Int,4) ,            
                        new SqlParameter("@ProductSpecName", SqlDbType.NVarChar,500) ,            
                        new SqlParameter("@ProductAttributeIDs", SqlDbType.NVarChar,500) ,            
                        new SqlParameter("@ProductCostPrice", SqlDbType.Decimal,9) ,            
                        new SqlParameter("@ProductStandardPrice", SqlDbType.Decimal,9) ,            
                        new SqlParameter("@ProductSalePrice", SqlDbType.Decimal,9) ,            
                        new SqlParameter("@ProductDescription", SqlDbType.NVarChar,500),             
              new SqlParameter("@ProductCateID", SqlDbType.Int),
            new SqlParameter("@ProductCateName", SqlDbType.NVarChar)
            };

            parameters[0].Value = model.ID;
            parameters[1].Value = model.ProductCoverImg;
            parameters[2].Value = model.ProductStatus;
            parameters[3].Value = model.ProductName;
            parameters[4].Value = model.ProductSpecID;
            parameters[5].Value = model.ProductSpecName;
            parameters[6].Value = model.ProductAttributeIDs;
            parameters[7].Value = model.ProductCostPrice;
            parameters[8].Value = model.ProductStandardPrice;
            parameters[9].Value = model.ProductSalePrice;
            parameters[10].Value = model.ProductDescription;
            parameters[11].Value = model.ProductCateID;
            parameters[12].Value = model.ProductCateName;
            int rows = helper.ExecuteSql(strSql.ToString(), parameters);
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public ProductInfoModel GetSingleModel(int ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ID, ProductCoverImg, ProductStatus, AddUserID, AddUserName, AddTime, ProductName, ProductSpecID, ProductSpecName, ProductAttributeIDs, ProductCostPrice, ProductStandardPrice, ProductSalePrice, ProductDescription,ProductCateID,ProductCateName  ");
            strSql.Append("  from ProductInfo ");
            strSql.Append(" where ID=@ID");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)
			};
            parameters[0].Value = ID;
            ProductInfoModel model = new ProductInfoModel();
            DataSet ds = helper.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["ID"].ToString() != "")
                {
                    model.ID = int.Parse(ds.Tables[0].Rows[0]["ID"].ToString());
                }
                model.ProductCoverImg = ds.Tables[0].Rows[0]["ProductCoverImg"].ToString();
                if (ds.Tables[0].Rows[0]["ProductStatus"].ToString() != "")
                {
                    model.ProductStatus = int.Parse(ds.Tables[0].Rows[0]["ProductStatus"].ToString());
                }
                if (ds.Tables[0].Rows[0]["AddUserID"].ToString() != "")
                {
                    model.AddUserID = int.Parse(ds.Tables[0].Rows[0]["AddUserID"].ToString());
                }
                model.AddUserName = ds.Tables[0].Rows[0]["AddUserName"].ToString();
                if (ds.Tables[0].Rows[0]["AddTime"].ToString() != "")
                {
                    model.AddTime = DateTime.Parse(ds.Tables[0].Rows[0]["AddTime"].ToString());
                }
                model.ProductName = ds.Tables[0].Rows[0]["ProductName"].ToString();
                if (ds.Tables[0].Rows[0]["ProductSpecID"].ToString() != "")
                {
                    model.ProductSpecID = int.Parse(ds.Tables[0].Rows[0]["ProductSpecID"].ToString());
                }
                model.ProductSpecName = ds.Tables[0].Rows[0]["ProductSpecName"].ToString();
                model.ProductAttributeIDs = ds.Tables[0].Rows[0]["ProductAttributeIDs"].ToString();
                if (ds.Tables[0].Rows[0]["ProductCostPrice"].ToString() != "")
                {
                    model.ProductCostPrice = decimal.Parse(ds.Tables[0].Rows[0]["ProductCostPrice"].ToString());
                }
                if (ds.Tables[0].Rows[0]["ProductStandardPrice"].ToString() != "")
                {
                    model.ProductStandardPrice = decimal.Parse(ds.Tables[0].Rows[0]["ProductStandardPrice"].ToString());
                }
                if (ds.Tables[0].Rows[0]["ProductSalePrice"].ToString() != "")
                {
                    model.ProductSalePrice = decimal.Parse(ds.Tables[0].Rows[0]["ProductSalePrice"].ToString());
                }
                if (ds.Tables[0].Rows[0]["ProductCateID"].ToString() != "")
                {
                    model.ProductCateID = int.Parse(ds.Tables[0].Rows[0]["ProductCateID"].ToString());
                }
                model.ProductDescription = ds.Tables[0].Rows[0]["ProductDescription"].ToString();
                model.ProductCateName = ds.Tables[0].Rows[0]["ProductCateName"].ToString();
                return model;
            }
            else
            {
                return null;
            }
        }
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public List<ProductInfoModel> GetAllModel()
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ID, ProductCoverImg, ProductStatus, AddUserID, AddUserName, AddTime, ProductName, ProductSpecID, ProductSpecName, ProductAttributeIDs, ProductCostPrice, ProductStandardPrice, ProductSalePrice, ProductDescription,ProductCateID,ProductCateName  ");
            strSql.Append("  from ProductInfo ");
            List<ProductInfoModel> list = new List<ProductInfoModel>();
            DataSet ds = helper.Query(strSql.ToString());
            if (ds.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow item in ds.Tables[0].Rows)
                {
                    ProductInfoModel model = new ProductInfoModel();
                    if (item["ID"].ToString() != "")
                    {
                        model.ID = int.Parse(item["ID"].ToString());
                    }
                    model.ProductCoverImg = item["ProductCoverImg"].ToString();
                    if (item["ProductStatus"].ToString() != "")
                    {
                        model.ProductStatus = int.Parse(item["ProductStatus"].ToString());
                    }
                    if (item["AddUserID"].ToString() != "")
                    {
                        model.AddUserID = int.Parse(item["AddUserID"].ToString());
                    }
                    model.AddUserName = item["AddUserName"].ToString();
                    if (item["AddTime"].ToString() != "")
                    {
                        model.AddTime = DateTime.Parse(item["AddTime"].ToString());
                    }
                    model.ProductName = item["ProductName"].ToString();
                    if (item["ProductSpecID"].ToString() != "")
                    {
                        model.ProductSpecID = int.Parse(item["ProductSpecID"].ToString());
                    }
                    model.ProductSpecName = item["ProductSpecName"].ToString();
                    model.ProductAttributeIDs = item["ProductAttributeIDs"].ToString();
                    if (item["ProductCostPrice"].ToString() != "")
                    {
                        model.ProductCostPrice = decimal.Parse(item["ProductCostPrice"].ToString());
                    }
                    if (item["ProductStandardPrice"].ToString() != "")
                    {
                        model.ProductStandardPrice = decimal.Parse(item["ProductStandardPrice"].ToString());
                    }
                    if (item["ProductSalePrice"].ToString() != "")
                    {
                        model.ProductSalePrice = decimal.Parse(item["ProductSalePrice"].ToString());
                    }
                    if (item["ProductCateID"].ToString() != "")
                    {
                        model.ProductCateID = int.Parse(item["ProductCateID"].ToString());
                    }
                    model.ProductDescription = item["ProductDescription"].ToString();
                    model.ProductCateName = item["ProductCateName"].ToString();
                    list.Add(model);
                }
            }
            return list;
        }
        /// <summary>
        /// 得到分页数据
        /// </summary>
        /// <param name="model"></param>
        /// <param name="totalrowcount"></param>
        /// <returns></returns>
        public List<ProductInfoModel> GetProductListForPage(ProductInfoModel model, out int totalrowcount)
        {
            List<ProductInfoModel> list = new List<ProductInfoModel>();
            string columms = @"ID,ProductName,ProductSpecID,ProductSpecName,ProductAttributeIDs,ProductCostPrice,ProductStandardPrice,ProductSalePrice,ProductDescription,ProductCoverImg,ProductStatus,AddUserID,AddUserName,AddTime,ProductCateID,ProductCateName,ProductContent,ProductSmallPic";
            string where = "";
            if (model != null)
            {
                if (model.ID > 0)
                {
                    where += "ID=" + model.ID;
                }
                if (!string.IsNullOrWhiteSpace(model.ProductName) && string.IsNullOrWhiteSpace(where))
                {
                    where += @" ProductName Like '%" + model.ProductName + "%'";
                }
                else if (!string.IsNullOrWhiteSpace(model.ProductName) && !string.IsNullOrWhiteSpace(where))
                {
                    where += @" AND ProductName Like '%" + model.ProductName + "%'";
                }
            }
            PageProModel page = new PageProModel();
            page.colums = columms;
            page.orderby = "ID";
            page.pageindex = model.PageIndex;
            page.pagesize = model.PageSize;
            page.tablename = @"dbo.ProductInfo";
            page.where = where;
            DataTable dt = PublicHelperDal.GetTable(page, out totalrowcount);
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow item in dt.Rows)
                {
                    ProductInfoModel promodel = new ProductInfoModel();
                    if (item["ID"].ToString() != "")
                    {
                        promodel.ID = int.Parse(item["ID"].ToString());
                    }
                    model.ProductCoverImg = item["ProductCoverImg"].ToString();
                    if (item["ProductStatus"].ToString() != "")
                    {
                        promodel.ProductStatus = int.Parse(item["ProductStatus"].ToString());
                    }
                    if (item["AddUserID"].ToString() != "")
                    {
                        promodel.AddUserID = int.Parse(item["AddUserID"].ToString());
                    }
                    promodel.AddUserName = item["AddUserName"].ToString();
                    if (item["AddTime"].ToString() != "")
                    {
                        promodel.AddTime = DateTime.Parse(item["AddTime"].ToString());
                    }
                    promodel.ProductName = item["ProductName"].ToString();
                    if (item["ProductSpecID"].ToString() != "")
                    {
                        promodel.ProductSpecID = int.Parse(item["ProductSpecID"].ToString());
                    }
                    promodel.ProductSpecName = item["ProductSpecName"].ToString();
                    promodel.ProductAttributeIDs = item["ProductAttributeIDs"].ToString();
                    if (item["ProductCostPrice"].ToString() != "")
                    {
                        promodel.ProductCostPrice = decimal.Parse(item["ProductCostPrice"].ToString());
                    }
                    if (item["ProductStandardPrice"].ToString() != "")
                    {
                        promodel.ProductStandardPrice = decimal.Parse(item["ProductStandardPrice"].ToString());
                    }
                    if (item["ProductSalePrice"].ToString() != "")
                    {
                        promodel.ProductSalePrice = decimal.Parse(item["ProductSalePrice"].ToString());
                    }
                    if (item["ProductCateID"].ToString() != "")
                    {
                        promodel.ProductCateID = int.Parse(item["ProductCateID"].ToString());
                    }
                    promodel.ProductDescription = item["ProductDescription"].ToString();
                    promodel.ProductCateName = item["ProductCateName"].ToString();
                    list.Add(promodel);
                }
            }
            return list;

        }
    }
}
