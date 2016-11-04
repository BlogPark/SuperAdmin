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
    public class ProductCategoryDal
    {
        DbHelperSQL helper = new DbHelperSQL();
        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int AddProductCategory(ProductCategoryModel model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into ProductCategory(");
            strSql.Append("CateName,CateStatus,AddUserID,AddUserName,AddTime,CateDescription");
            strSql.Append(") values (");
            strSql.Append("@CateName,@CateStatus,@AddUserID,@AddUserName,GETDATE(),@CateDescription");
            strSql.Append(") ");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
			            new SqlParameter("@CateName", SqlDbType.NVarChar,50) ,            
                        new SqlParameter("@CateStatus", SqlDbType.Int,4) ,            
                        new SqlParameter("@AddUserID", SqlDbType.Int,4) ,            
                        new SqlParameter("@AddUserName", SqlDbType.NVarChar,50) ,   
                        new SqlParameter("@CateDescription", SqlDbType.NVarChar,500)  
            };
            parameters[0].Value = model.CateName;
            parameters[1].Value = model.CateStatus;
            parameters[2].Value = model.AddUserID;
            parameters[3].Value = model.AddUserName;
            parameters[4].Value = model.CateDescription;
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
        public bool UpdateProductCategory(ProductCategoryModel model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update ProductCategory set ");
            strSql.Append(" CateName = @CateName , ");
            strSql.Append(" CateStatus = @CateStatus , ");
            strSql.Append(" CateDescription = @CateDescription  ");
            strSql.Append(" where ID=@ID ");

            SqlParameter[] parameters = {
			            new SqlParameter("@ID", SqlDbType.Int,4) ,            
                        new SqlParameter("@CateName", SqlDbType.NVarChar,50) ,            
                        new SqlParameter("@CateStatus", SqlDbType.Int,4) ,        
                        new SqlParameter("@CateDescription", SqlDbType.NVarChar,500)       
            };
            parameters[0].Value = model.ID;
            parameters[1].Value = model.CateName;
            parameters[2].Value = model.CateStatus;
            parameters[3].Value = model.CateDescription;
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
        /// 删除一条数据
        /// </summary>
        public bool DeleteProductCategory(int cateid)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update ProductCategory set ");
            strSql.Append(" CateStatus = 0 ");
            strSql.Append(" where ID=@ID ");

            SqlParameter[] parameters = {
			            new SqlParameter("@ID", SqlDbType.Int)
            };
            parameters[0].Value = cateid;
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
        public ProductCategoryModel GetSingleModel(int ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ID, CateName, CateStatus, AddUserID, AddUserName, AddTime, CateDescription  ");
            strSql.Append("  from ProductCategory ");
            strSql.Append(" where ID=@ID");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)
			};
            parameters[0].Value = ID;
            ProductCategoryModel model = new ProductCategoryModel();
            DataSet ds = helper.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["ID"].ToString() != "")
                {
                    model.ID = int.Parse(ds.Tables[0].Rows[0]["ID"].ToString());
                }
                model.CateName = ds.Tables[0].Rows[0]["CateName"].ToString();
                if (ds.Tables[0].Rows[0]["CateStatus"].ToString() != "")
                {
                    model.CateStatus = int.Parse(ds.Tables[0].Rows[0]["CateStatus"].ToString());
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
                model.CateDescription = ds.Tables[0].Rows[0]["CateDescription"].ToString();
                return model;
            }
            else
            {
                return null;
            }
        }
        /// <summary>
        /// 得到全部对象实体
        /// </summary>
        public List<ProductCategoryModel> GetAllModel(int isuse=0)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ID, CateName, CateStatus, AddUserID, AddUserName, AddTime, CateDescription,Case CateStatus when 1 then '启用' when 0 then '禁用' end as  CateStatusName ");
            strSql.Append("  from ProductCategory ");
            if (isuse == 1)
            {
                strSql.Append("  where CateStatus=1 ");
            }
            List<ProductCategoryModel> list = new List<ProductCategoryModel>();
            DataSet ds = helper.Query(strSql.ToString());
            if (ds.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow item in ds.Tables[0].Rows)
                {
                    ProductCategoryModel model = new ProductCategoryModel();
                    if (item["ID"].ToString() != "")
                    {
                        model.ID = int.Parse(item["ID"].ToString());
                    }
                    model.CateName = item["CateName"].ToString();
                    if (item["CateStatus"].ToString() != "")
                    {
                        model.CateStatus = int.Parse(item["CateStatus"].ToString());
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
                    model.CateDescription = item["CateDescription"].ToString();
                    model.CateStatusName = item["CateStatusName"].ToString();
                    list.Add(model);
                }
            }
            return list;
        }
    }
}
