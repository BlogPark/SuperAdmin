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
    /// 系统FAQ信息管理类
    /// </summary>
    public class WebfaqMsgDal
    {
        DbHelperSQL helper = new DbHelperSQL();
        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int AddWebfaqMsg(WebfaqMsgModel model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into WebfaqMsg(");
            strSql.Append("FTitle,FAnswerContent,FStatus,FAnswerId,FAnswerName,FAnswerTime");
            strSql.Append(") values (");
            strSql.Append("@FTitle,@FAnswerContent,@FStatus,@FAnswerId,@FAnswerName,@FAnswerTime");
            strSql.Append(") ");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
			            new SqlParameter("@FTitle", SqlDbType.NVarChar) ,            
                        new SqlParameter("@FAnswerContent", SqlDbType.NVarChar) ,            
                        new SqlParameter("@FStatus", SqlDbType.Int) ,            
                        new SqlParameter("@FAnswerId", SqlDbType.Int) ,            
                        new SqlParameter("@FAnswerName", SqlDbType.NVarChar) ,            
                        new SqlParameter("@FAnswerTime", SqlDbType.DateTime)             
              
            };

            parameters[0].Value = model.FTitle;
            parameters[1].Value = model.FAnswerContent;
            parameters[2].Value = model.FStatus;
            parameters[3].Value = model.FAnswerId;
            parameters[4].Value = model.FAnswerName;
            parameters[5].Value = model.FAnswerTime;

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
        public bool UpdateWebfaqMsg(WebfaqMsgModel model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update WebfaqMsg set ");
            strSql.Append(" FTitle = @FTitle , ");
            strSql.Append(" FAnswerContent = @FAnswerContent , ");
            strSql.Append(" FAnswerId = @FAnswerId , ");
            strSql.Append(" FAnswerName = @FAnswerName , ");
            strSql.Append(" FAnswerTime = @FAnswerTime  ");
            strSql.Append(" where ID=@ID ");

            SqlParameter[] parameters = {
			            new SqlParameter("@ID", SqlDbType.Int) ,            
                        new SqlParameter("@FTitle", SqlDbType.NVarChar) ,            
                        new SqlParameter("@FAnswerContent", SqlDbType.NVarChar) ,   
                        new SqlParameter("@FAnswerId", SqlDbType.Int) ,            
                        new SqlParameter("@FAnswerName", SqlDbType.NVarChar) ,            
                        new SqlParameter("@FAnswerTime", SqlDbType.DateTime)             
              
            };
            parameters[0].Value = model.ID;
            parameters[1].Value = model.FTitle;
            parameters[2].Value = model.FAnswerContent;
            parameters[3].Value = model.FAnswerId;
            parameters[4].Value = model.FAnswerName;
            parameters[5].Value = model.FAnswerTime;
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
        ///删除一条数据
        /// </summary>
        public bool DeleteWebfaqMsg(int id, int status)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update WebfaqMsg set ");
            strSql.Append(" FStatus = @FStatus ");
            strSql.Append(" where ID=@ID ");

            SqlParameter[] parameters = {
			            new SqlParameter("@ID",id) ,               
                        new SqlParameter("@FStatus", status) 
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
        public WebfaqMsgModel GetSingleDataModel(int ID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ID, FTitle, FAnswerContent, FStatus, FAnswerId, FAnswerName, FAnswerTime  ");
            strSql.Append("  from WebfaqMsg ");
            strSql.Append(" where ID=@ID");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)
			};
            parameters[0].Value = ID;


            WebfaqMsgModel model = new WebfaqMsgModel();
            DataSet ds = helper.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["ID"].ToString() != "")
                {
                    model.ID = int.Parse(ds.Tables[0].Rows[0]["ID"].ToString());
                }
                model.FTitle = ds.Tables[0].Rows[0]["FTitle"].ToString();
                model.FAnswerContent = ds.Tables[0].Rows[0]["FAnswerContent"].ToString();
                if (ds.Tables[0].Rows[0]["FStatus"].ToString() != "")
                {
                    model.FStatus = int.Parse(ds.Tables[0].Rows[0]["FStatus"].ToString());
                }
                if (ds.Tables[0].Rows[0]["FAnswerId"].ToString() != "")
                {
                    model.FAnswerId = int.Parse(ds.Tables[0].Rows[0]["FAnswerId"].ToString());
                }
                model.FAnswerName = ds.Tables[0].Rows[0]["FAnswerName"].ToString();
                if (ds.Tables[0].Rows[0]["FAnswerTime"].ToString() != "")
                {
                    model.FAnswerTime = DateTime.Parse(ds.Tables[0].Rows[0]["FAnswerTime"].ToString());
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
        public List<WebfaqMsgModel> GetAllDataModel()
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ID, FTitle, FAnswerContent, FStatus, FAnswerId, FAnswerName, FAnswerTime,case FStatus when 1 then '已发布' else '已删除' end as FStatusName ");
            strSql.Append("  from WebfaqMsg ");
            strSql.Append(" order by ID desc");

            DataSet ds = helper.Query(strSql.ToString());
            List<WebfaqMsgModel> list = new List<WebfaqMsgModel>();
            if (ds.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow item in ds.Tables[0].Rows)
                {
                    WebfaqMsgModel model = new WebfaqMsgModel();
                    if (item["ID"].ToString() != "")
                    {
                        model.ID = int.Parse(item["ID"].ToString());
                    }
                    model.FTitle = item["FTitle"].ToString();
                    model.FAnswerContent = item["FAnswerContent"].ToString();
                    if (item["FStatus"].ToString() != "")
                    {
                        model.FStatus = int.Parse(item["FStatus"].ToString());
                    }
                    if (item["FAnswerId"].ToString() != "")
                    {
                        model.FAnswerId = int.Parse(item["FAnswerId"].ToString());
                    }
                    model.FAnswerName = item["FAnswerName"].ToString();
                    if (item["FAnswerTime"].ToString() != "")
                    {
                        model.FAnswerTime = DateTime.Parse(item["FAnswerTime"].ToString());
                    }
                    model.FStatusName = item["FStatusName"].ToString();
                    list.Add(model);
                }
            }
            return list;
        }
    }
}
