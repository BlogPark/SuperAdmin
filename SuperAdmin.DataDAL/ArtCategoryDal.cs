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
    /// 文章类别操作类
    /// </summary>
    public class ArtCategoryDal
    {
        DbHelperSQL helper = new DbHelperSQL();
        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int AddArtCategory(ArtCategoryModel model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into ArtCategory(");
            strSql.Append("CName,CStatus,AddUserID,AddUserName,AddTime");
            strSql.Append(") values (");
            strSql.Append("@CName,@CStatus,@AddUserID,@AddUserName,GETDATE()");
            strSql.Append(") ");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
			            new SqlParameter("@CName", SqlDbType.NVarChar,50) ,            
                        new SqlParameter("@CStatus", SqlDbType.Int,4) ,            
                        new SqlParameter("@AddUserID", SqlDbType.Int,4) ,            
                        new SqlParameter("@AddUserName", SqlDbType.NVarChar,50) 
            };
            parameters[0].Value = model.CName;
            parameters[1].Value = model.CStatus;
            parameters[2].Value = model.AddUserID;
            parameters[3].Value = model.AddUserName;
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
        /// 更新一条数据状态
        /// </summary>
        public bool UpdateArtCategoryStatus(int id,int status)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update ArtCategory set ");
            strSql.Append(" CStatus = @CStatus  ");
            strSql.Append(" where ID=@ID ");
            SqlParameter[] parameters = {
			            new SqlParameter("@ID", SqlDbType.Int) ,                    
                        new SqlParameter("@CStatus", SqlDbType.Int)    
            };
            parameters[0].Value = id;
            parameters[1].Value = status;
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
        public ArtCategoryModel GetSingleModel(int ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ID, CName, CStatus, AddUserID, AddUserName, AddTime ,case CStatus when 1 then '激活' when 0 then '禁用' end as CStatusName ");
            strSql.Append("  from ArtCategory ");
            strSql.Append(" where ID=@ID");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int)
			};
            parameters[0].Value = ID;
            ArtCategoryModel model = new ArtCategoryModel();
            DataSet ds = helper.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["ID"].ToString() != "")
                {
                    model.ID = int.Parse(ds.Tables[0].Rows[0]["ID"].ToString());
                }
                model.CName = ds.Tables[0].Rows[0]["CName"].ToString();
                if (ds.Tables[0].Rows[0]["CStatus"].ToString() != "")
                {
                    model.CStatus = int.Parse(ds.Tables[0].Rows[0]["CStatus"].ToString());
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
                model.CStatusName = ds.Tables[0].Rows[0]["CStatusName"].ToString();
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
        public List<ArtCategoryModel> GetALLModel(int isuse=0)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ID, CName, CStatus, AddUserID, AddUserName, AddTime,case CStatus when 1 then '激活' when 0 then '禁用' end as CStatusName  ");
            strSql.Append("  from ArtCategory ");
            if (isuse==1)
            {
                strSql.Append(" where CStatus=1 ");
            }
            List<ArtCategoryModel> list = new List<ArtCategoryModel>();
            DataSet ds = helper.Query(strSql.ToString());
            if (ds.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow item in ds.Tables[0].Rows)
                {
                    ArtCategoryModel model = new ArtCategoryModel();
                    if (item["ID"].ToString() != "")
                    {
                        model.ID = int.Parse(item["ID"].ToString());
                    }
                    model.CName = item["CName"].ToString();
                    if (item["CStatus"].ToString() != "")
                    {
                        model.CStatus = int.Parse(item["CStatus"].ToString());
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
                    model.CStatusName = item["CStatusName"].ToString();
                    list.Add(model);
                }
            }
            return list;
        }
    }
}
