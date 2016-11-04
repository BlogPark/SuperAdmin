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
    public class ProductSpecDal
    {
        DbHelperSQL helper = new DbHelperSQL();
        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int AddProductSpec(ProductSpecModel model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into ProductSpec(");
            strSql.Append("SpecName,SpecDecription,SpecType,SpecStatus,AdduserID,AdduserName,AddTime");
            strSql.Append(") values (");
            strSql.Append("@SpecName,@SpecDecription,@SpecType,@SpecStatus,@AdduserID,@AdduserName,GETDATE()");
            strSql.Append(") ");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
			            new SqlParameter("@SpecName", SqlDbType.NVarChar) ,            
                        new SqlParameter("@SpecDecription", SqlDbType.NVarChar) ,            
                        new SqlParameter("@SpecType", SqlDbType.Int) ,            
                        new SqlParameter("@SpecStatus", SqlDbType.Int) ,            
                        new SqlParameter("@AdduserID", SqlDbType.Int) ,            
                        new SqlParameter("@AdduserName", SqlDbType.NVarChar) 
            };
            parameters[0].Value = model.SpecName;
            parameters[1].Value = model.SpecDecription;
            parameters[2].Value = model.SpecType;
            parameters[3].Value = model.SpecStatus;
            parameters[4].Value = model.AdduserID;
            parameters[5].Value = model.AdduserName;

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
        public bool UpdateMsg(ProductSpecModel model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update ProductSpec set ");
            strSql.Append(" SpecName = @SpecName , ");
            strSql.Append(" SpecDecription = @SpecDecription , ");
            strSql.Append(" SpecType = @SpecType ");
            strSql.Append(" where ID=@ID ");

            SqlParameter[] parameters = {
			            new SqlParameter("@ID", SqlDbType.Int) ,            
                        new SqlParameter("@SpecName", SqlDbType.NVarChar) ,            
                        new SqlParameter("@SpecDecription", SqlDbType.NVarChar) ,            
                        new SqlParameter("@SpecType", SqlDbType.Int)
            };
            parameters[0].Value = model.ID;
            parameters[1].Value = model.SpecName;
            parameters[2].Value = model.SpecDecription;
            parameters[3].Value = model.SpecType;
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
        /// 更新数据状态
        /// </summary>
        public bool Updatestatus(int id, int status)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update ProductSpec set ");
            strSql.Append(" SpecStatus = @SpecStatus ");
            strSql.Append(" where ID=@ID ");

            SqlParameter[] parameters = {
			            new SqlParameter("@ID", id) ,            
                        new SqlParameter("@SpecStatus", status) 
            };
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
        public ProductSpecModel GetSingleModel(int ID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ID, SpecName, SpecDecription, SpecType, SpecStatus, AdduserID, AdduserName, AddTime  ");
            strSql.Append("  from ProductSpec ");
            strSql.Append(" where ID=@ID");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int)
			};
            parameters[0].Value = ID;
            ProductSpecModel model = new ProductSpecModel();
            DataSet ds = helper.Query(strSql.ToString(), parameters);

            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["ID"].ToString() != "")
                {
                    model.ID = int.Parse(ds.Tables[0].Rows[0]["ID"].ToString());
                }
                model.SpecName = ds.Tables[0].Rows[0]["SpecName"].ToString();
                model.SpecDecription = ds.Tables[0].Rows[0]["SpecDecription"].ToString();
                if (ds.Tables[0].Rows[0]["SpecType"].ToString() != "")
                {
                    model.SpecType = int.Parse(ds.Tables[0].Rows[0]["SpecType"].ToString());
                }
                if (ds.Tables[0].Rows[0]["SpecStatus"].ToString() != "")
                {
                    model.SpecStatus = int.Parse(ds.Tables[0].Rows[0]["SpecStatus"].ToString());
                }
                if (ds.Tables[0].Rows[0]["AdduserID"].ToString() != "")
                {
                    model.AdduserID = int.Parse(ds.Tables[0].Rows[0]["AdduserID"].ToString());
                }
                model.AdduserName = ds.Tables[0].Rows[0]["AdduserName"].ToString();
                if (ds.Tables[0].Rows[0]["AddTime"].ToString() != "")
                {
                    model.AddTime = DateTime.Parse(ds.Tables[0].Rows[0]["AddTime"].ToString());
                }

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
        public List<ProductSpecModel> GetAllModel()
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ID, SpecName, SpecDecription, SpecType, SpecStatus, AdduserID, AdduserName, AddTime  ");
            strSql.Append("  from ProductSpec ");
            strSql.Append("  ORDER BY ID DESC");
            List<ProductSpecModel> list = new List<ProductSpecModel>();
            DataSet ds = helper.Query(strSql.ToString());

            if (ds.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow item in ds.Tables[0].Rows)
                {
                    ProductSpecModel model = new ProductSpecModel();
                    if (item["ID"].ToString() != "")
                    {
                        model.ID = int.Parse(item["ID"].ToString());
                    }
                    model.SpecName = item["SpecName"].ToString();
                    model.SpecDecription = item["SpecDecription"].ToString();
                    if (item["SpecType"].ToString() != "")
                    {
                        model.SpecType = int.Parse(item["SpecType"].ToString());
                    }
                    if (item["SpecStatus"].ToString() != "")
                    {
                        model.SpecStatus = int.Parse(item["SpecStatus"].ToString());
                    }
                    if (item["AdduserID"].ToString() != "")
                    {
                        model.AdduserID = int.Parse(item["AdduserID"].ToString());
                    }
                    model.AdduserName = item["AdduserName"].ToString();
                    if (item["AddTime"].ToString() != "")
                    {
                        model.AddTime = DateTime.Parse(item["AddTime"].ToString());
                    }
                    list.Add(model);
                }
            }
            return list;
        }
        /// <summary>
        /// 得到全部对象实体
        /// </summary>
        public List<ProductSpecModel> GetSingleModelByIds(string ids)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ID, SpecName, SpecDecription, SpecType, SpecStatus, AdduserID, AdduserName, AddTime  ");
            strSql.Append("  from ProductSpec ");
            strSql.Append(" where id in ("+ids.TrimEnd(',')+")");
            strSql.Append("  ORDER BY ID DESC");
            List<ProductSpecModel> list = new List<ProductSpecModel>();
            DataSet ds = helper.Query(strSql.ToString());

            if (ds.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow item in ds.Tables[0].Rows)
                {
                    ProductSpecModel model = new ProductSpecModel();
                    if (item["ID"].ToString() != "")
                    {
                        model.ID = int.Parse(item["ID"].ToString());
                    }
                    model.SpecName = item["SpecName"].ToString();
                    model.SpecDecription = item["SpecDecription"].ToString();
                    if (item["SpecType"].ToString() != "")
                    {
                        model.SpecType = int.Parse(item["SpecType"].ToString());
                    }
                    if (item["SpecStatus"].ToString() != "")
                    {
                        model.SpecStatus = int.Parse(item["SpecStatus"].ToString());
                    }
                    if (item["AdduserID"].ToString() != "")
                    {
                        model.AdduserID = int.Parse(item["AdduserID"].ToString());
                    }
                    model.AdduserName = item["AdduserName"].ToString();
                    if (item["AddTime"].ToString() != "")
                    {
                        model.AddTime = DateTime.Parse(item["AddTime"].ToString());
                    }
                    list.Add(model);
                }
            }
            return list;
        }
        /// <summary>
        /// 根据类型得到全部对象实体
        /// </summary>
        public List<ProductSpecModel> GetAllModelByType(int typeid)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ID, SpecName, SpecDecription, SpecType, SpecStatus, AdduserID, AdduserName, AddTime  ");
            strSql.Append("  from ProductSpec ");
            strSql.Append(" where SpecType=@SpecType  ");
            strSql.Append("  ORDER BY ID DESC");
            SqlParameter[] paramter = { new SqlParameter("@SpecType",typeid) };
            List<ProductSpecModel> list = new List<ProductSpecModel>();
            DataSet ds = helper.Query(strSql.ToString(),paramter);
            if (ds.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow item in ds.Tables[0].Rows)
                {
                    ProductSpecModel model = new ProductSpecModel();
                    if (item["ID"].ToString() != "")
                    {
                        model.ID = int.Parse(item["ID"].ToString());
                    }
                    model.SpecName = item["SpecName"].ToString();
                    model.SpecDecription = item["SpecDecription"].ToString();
                    if (item["SpecType"].ToString() != "")
                    {
                        model.SpecType = int.Parse(item["SpecType"].ToString());
                    }
                    if (item["SpecStatus"].ToString() != "")
                    {
                        model.SpecStatus = int.Parse(item["SpecStatus"].ToString());
                    }
                    if (item["AdduserID"].ToString() != "")
                    {
                        model.AdduserID = int.Parse(item["AdduserID"].ToString());
                    }
                    model.AdduserName = item["AdduserName"].ToString();
                    if (item["AddTime"].ToString() != "")
                    {
                        model.AddTime = DateTime.Parse(item["AddTime"].ToString());
                    }
                    list.Add(model);
                }
            }
            return list;
        }       
    }
}
