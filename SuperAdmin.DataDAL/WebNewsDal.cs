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
    /// 网站新闻管理操作类
    /// </summary>
    public class WebNewsDal
    {
        DbHelperSQL helper = new DbHelperSQL();
        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int AddWebNews(WebNewsModel model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into WebNews(");
            strSql.Append("NTitle,NContent,NStatus,NAddUser,NAddUserName,NAddTime");
            strSql.Append(") values (");
            strSql.Append("@NTitle,@NContent,@NStatus,@NAddUser,@NAddUserName,GETDATE()");
            strSql.Append(") ");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
			            new SqlParameter("@NTitle", SqlDbType.NVarChar,500) ,            
                        new SqlParameter("@NContent", SqlDbType.NVarChar,-1) ,            
                        new SqlParameter("@NStatus", SqlDbType.Int,4) ,            
                        new SqlParameter("@NAddUser", SqlDbType.Int,4) ,            
                        new SqlParameter("@NAddUserName", SqlDbType.NVarChar,50) 
            };

            parameters[0].Value = model.NTitle;
            parameters[1].Value = model.NContent;
            parameters[2].Value = model.NStatus;
            parameters[3].Value = model.NAddUser;
            parameters[4].Value = model.NAddUserName;
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
        public bool UpdateWebNews(WebNewsModel model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update WebNews set ");

            strSql.Append(" NTitle = @NTitle , ");
            strSql.Append(" NContent = @NContent , ");
            strSql.Append(" NStatus = @NStatus");
            strSql.Append(" where ID=@ID ");

            SqlParameter[] parameters = {
			            new SqlParameter("@ID", SqlDbType.Int,4) ,            
                        new SqlParameter("@NTitle", SqlDbType.NVarChar,500) ,            
                        new SqlParameter("@NContent", SqlDbType.NVarChar,-1) ,            
                        new SqlParameter("@NStatus", SqlDbType.Int,4)   
            };

            parameters[0].Value = model.ID;
            parameters[1].Value = model.NTitle;
            parameters[2].Value = model.NContent;
            parameters[3].Value = model.NStatus;
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
        public WebNewsModel GetSingleModel(int ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ID, NTitle, NContent, NStatus, NAddUser, NAddUserName, NAddTime  ");
            strSql.Append("  from WebNews ");
            strSql.Append(" where ID=@ID");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)
			};
            parameters[0].Value = ID;

            WebNewsModel model = new WebNewsModel();
            DataSet ds = helper.Query(strSql.ToString(), parameters);

            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["ID"].ToString() != "")
                {
                    model.ID = int.Parse(ds.Tables[0].Rows[0]["ID"].ToString());
                }
                model.NTitle = ds.Tables[0].Rows[0]["NTitle"].ToString();
                model.NContent = ds.Tables[0].Rows[0]["NContent"].ToString();
                if (ds.Tables[0].Rows[0]["NStatus"].ToString() != "")
                {
                    model.NStatus = int.Parse(ds.Tables[0].Rows[0]["NStatus"].ToString());
                }
                if (ds.Tables[0].Rows[0]["NAddUser"].ToString() != "")
                {
                    model.NAddUser = int.Parse(ds.Tables[0].Rows[0]["NAddUser"].ToString());
                }
                model.NAddUserName = ds.Tables[0].Rows[0]["NAddUserName"].ToString();
                if (ds.Tables[0].Rows[0]["NAddTime"].ToString() != "")
                {
                    model.NAddTime = DateTime.Parse(ds.Tables[0].Rows[0]["NAddTime"].ToString());
                }
                return model;
            }
            else
            {
                return null;
            }
        }
        /// <summary>
        /// 得到全部的对象实体
        /// </summary>
        /// <returns></returns>
        public List<WebNewsModel> GetAllModelList()
        {
            string sqltxt = @"SELECT  ID ,
        NTitle ,
        NContent ,
        NStatus ,
        NAddUser ,
        NAddUserName ,
        NAddTime
FROM    SuperWebSite.dbo.WebNews WITH(NOLOCK)";
            DataTable dt = helper.Query(sqltxt).Tables[0];
            List<WebNewsModel> list = new List<WebNewsModel>();
            foreach (DataRow item in dt.Rows)
            {
                WebNewsModel model = new WebNewsModel();
                model.ID = int.Parse(item["ID"].ToString());
                model.NAddTime = DateTime.Parse(item["NAddTime"].ToString());
                model.NAddUser = int.Parse(item["NAddUser"].ToString());
                model.NAddUserName = item["NAddUserName"].ToString();
                model.NContent = item["NContent"].ToString();
                model.NStatus = int.Parse(item["NStatus"].ToString());
                model.NTitle = item["NTitle"].ToString();
                list.Add(model);
            }
            return list;
        }
    }
}
