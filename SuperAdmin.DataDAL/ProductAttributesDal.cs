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
    public class ProductAttributesDal
    {
        DbHelperSQL helper = new DbHelperSQL();
        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int AddProductAttributes(ProductAttributesModel model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into ProductAttributes(");
            strSql.Append("ProductID,ProductAttrKey,ProductAttrValue,AttrStatus,AddTime,IsImportent,ProductAttrDescript");
            strSql.Append(") values (");
            strSql.Append("@ProductID,@ProductAttrKey,@ProductAttrValue,@AttrStatus,@AddTime,@IsImportent,@ProductAttrDescript");
            strSql.Append(") ");
            SqlParameter[] parameters = {
			            new SqlParameter("@ProductID", SqlDbType.Int) ,            
                        new SqlParameter("@ProductAttrKey", SqlDbType.NVarChar) ,            
                        new SqlParameter("@ProductAttrValue", SqlDbType.NVarChar) ,            
                        new SqlParameter("@AttrStatus", SqlDbType.Int) ,            
                        new SqlParameter("@AddTime", SqlDbType.DateTime) ,            
                        new SqlParameter("@IsImportent", SqlDbType.Int) ,            
                        new SqlParameter("@ProductAttrDescript", SqlDbType.NVarChar)             
              
            };
            parameters[0].Value = model.ProductID;
            parameters[1].Value = model.ProductAttrKey;
            parameters[2].Value = model.ProductAttrValue;
            parameters[3].Value = model.AttrStatus;
            parameters[4].Value = model.AddTime;
            parameters[5].Value = model.IsImportent;
            parameters[6].Value = model.ProductAttrDescript;
            int obj = helper.ExecuteSql(strSql.ToString(), parameters);
            return obj;
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool UpdateProductAttributes(ProductAttributesModel model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update ProductAttributes set ");
            strSql.Append(" ProductID = @ProductID , ");
            strSql.Append(" ProductAttrKey = @ProductAttrKey , ");
            strSql.Append(" ProductAttrValue = @ProductAttrValue , ");
            strSql.Append(" AttrStatus = @AttrStatus , ");
            strSql.Append(" AddTime = @AddTime , ");
            strSql.Append(" IsImportent = @IsImportent , ");
            strSql.Append(" ProductAttrDescript = @ProductAttrDescript  ");
            strSql.Append(" where ID=@ID ");
            SqlParameter[] parameters = {
			            new SqlParameter("@ID", SqlDbType.Int) ,            
                        new SqlParameter("@ProductID", SqlDbType.Int) ,            
                        new SqlParameter("@ProductAttrKey", SqlDbType.NVarChar) ,            
                        new SqlParameter("@ProductAttrValue", SqlDbType.NVarChar) ,            
                        new SqlParameter("@AttrStatus", SqlDbType.Int) ,            
                        new SqlParameter("@AddTime", SqlDbType.DateTime) ,            
                        new SqlParameter("@IsImportent", SqlDbType.Int) ,            
                        new SqlParameter("@ProductAttrDescript", SqlDbType.NVarChar)             
              
            };
            parameters[0].Value = model.ID;
            parameters[1].Value = model.ProductID;
            parameters[2].Value = model.ProductAttrKey;
            parameters[3].Value = model.ProductAttrValue;
            parameters[4].Value = model.AttrStatus;
            parameters[5].Value = model.AddTime;
            parameters[6].Value = model.IsImportent;
            parameters[7].Value = model.ProductAttrDescript;
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
        public ProductAttributesModel GetProductAttributesModel(int ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ID, ProductID, ProductAttrKey, ProductAttrValue, AttrStatus, AddTime, IsImportent, ProductAttrDescript  ");
            strSql.Append("  from ProductAttributes ");
            strSql.Append(" where ID=@ID");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int)
			};
            parameters[0].Value = ID;
            ProductAttributesModel model = new ProductAttributesModel();
            DataSet ds = helper.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["ID"].ToString() != "")
                {
                    model.ID = int.Parse(ds.Tables[0].Rows[0]["ID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["ProductID"].ToString() != "")
                {
                    model.ProductID = int.Parse(ds.Tables[0].Rows[0]["ProductID"].ToString());
                }
                model.ProductAttrKey = ds.Tables[0].Rows[0]["ProductAttrKey"].ToString();
                model.ProductAttrValue = ds.Tables[0].Rows[0]["ProductAttrValue"].ToString();
                if (ds.Tables[0].Rows[0]["AttrStatus"].ToString() != "")
                {
                    model.AttrStatus = int.Parse(ds.Tables[0].Rows[0]["AttrStatus"].ToString());
                }
                if (ds.Tables[0].Rows[0]["AddTime"].ToString() != "")
                {
                    model.AddTime = DateTime.Parse(ds.Tables[0].Rows[0]["AddTime"].ToString());
                }
                if (ds.Tables[0].Rows[0]["IsImportent"].ToString() != "")
                {
                    model.IsImportent = int.Parse(ds.Tables[0].Rows[0]["IsImportent"].ToString());
                }
                model.ProductAttrDescript = ds.Tables[0].Rows[0]["ProductAttrDescript"].ToString();
                return model;
            }
            else
            {
                return null;
            }
        }
        /// <summary>
        /// 根据ProductID得到属性列表
        /// </summary>
        /// <param name="productid"></param>
        /// <returns></returns>
        public Dictionary<string, string> GetProductAttributesByProductID(int productid)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ID, ProductID, ProductAttrKey, ProductAttrValue, AttrStatus, AddTime, IsImportent, ProductAttrDescript  ");
            strSql.Append("  from ProductAttributes ");
            strSql.Append(" where ProductID=@ProductID");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int)
			};
            parameters[0].Value = productid;
            Dictionary<string, string> modeldic = new Dictionary<string, string>();
            DataSet ds = helper.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow item in ds.Tables[0].Rows)
                {
                    string key=item["ProductAttrKey"].ToString();
                    string value = item["ProductAttrValue"].ToString();
                    if (!modeldic.ContainsKey(key))
                    {
                        modeldic.Add(key,value);
                    }
                }
            }
            return modeldic;
        }
        /// <summary>
        /// 根据ProductID得到属性列表
        /// </summary>
        /// <param name="productid"></param>
        /// <returns></returns>
        public List<ProductAttributesModel> GetProductAttributesByPID(int productid)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ID, ProductID, ProductAttrKey, ProductAttrValue, AttrStatus, AddTime, IsImportent, ProductAttrDescript  ");
            strSql.Append("  from ProductAttributes ");
            strSql.Append(" where ProductID=@ProductID");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int)
			};
            parameters[0].Value = productid;
            List<ProductAttributesModel> modellist = new List<ProductAttributesModel>();
            DataSet ds = helper.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow item in ds.Tables[0].Rows)
                {
                    ProductAttributesModel model = new ProductAttributesModel();
                    if (item["ID"].ToString() != "")
                    {
                        model.ID = int.Parse(item["ID"].ToString());
                    }
                    if (item["ProductID"].ToString() != "")
                    {
                        model.ProductID = int.Parse(item["ProductID"].ToString());
                    }
                    model.ProductAttrKey = item["ProductAttrKey"].ToString();
                    model.ProductAttrValue = item["ProductAttrValue"].ToString();
                    if (item["AttrStatus"].ToString() != "")
                    {
                        model.AttrStatus = int.Parse(item["AttrStatus"].ToString());
                    }
                    if (item["AddTime"].ToString() != "")
                    {
                        model.AddTime = DateTime.Parse(item["AddTime"].ToString());
                    }
                    if (item["IsImportent"].ToString() != "")
                    {
                        model.IsImportent = int.Parse(item["IsImportent"].ToString());
                    }
                    model.ProductAttrDescript = item["ProductAttrDescript"].ToString();
                    modellist.Add(model);
                }
            }
            return modellist;
        }
    }
}
