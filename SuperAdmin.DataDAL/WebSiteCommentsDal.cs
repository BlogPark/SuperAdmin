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
    public class WebSiteCommentsDal
    {
        DbHelperSQL helper = new DbHelperSQL();

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int AddWebSiteComments(WebSiteCommentsModel model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into WebSiteComments(");
            strSql.Append("ObjectID,ObjectType,ObjectName,MemberID,MemberName,ComCentent,Addtime,ComStatus");
            strSql.Append(") values (");
            strSql.Append("@ObjectID,@ObjectType,@ObjectName,@MemberID,@MemberName,@ComCentent,@Addtime,@ComStatus");
            strSql.Append(") ");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
			            new SqlParameter("@ObjectID", SqlDbType.BigInt,8) ,            
                        new SqlParameter("@ObjectType", SqlDbType.Int,4) ,            
                        new SqlParameter("@ObjectName", SqlDbType.NVarChar,500) ,            
                        new SqlParameter("@MemberID", SqlDbType.Int,4) ,            
                        new SqlParameter("@MemberName", SqlDbType.NVarChar,50) ,            
                        new SqlParameter("@ComCentent", SqlDbType.NVarChar,500) ,            
                        new SqlParameter("@Addtime", SqlDbType.DateTime) ,            
                        new SqlParameter("@ComStatus", SqlDbType.Int,4)      
            };
            parameters[0].Value = model.ObjectID;
            parameters[1].Value = model.ObjectType;
            parameters[2].Value = model.ObjectName;
            parameters[3].Value = model.MemberID;
            parameters[4].Value = model.MemberName;
            parameters[5].Value = model.ComCentent;
            parameters[6].Value = model.Addtime;
            parameters[7].Value = model.ComStatus;
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
        public bool UpdateWebSiteCommentsStatus(int id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update WebSiteComments set ");
            strSql.Append(" ComStatus = 0 ");
            strSql.Append(" where ID=@ID ");
            SqlParameter[] parameters = {
			            new SqlParameter("@ID", id)      
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
        public WebSiteCommentsModel GetSingleModel(int ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ID, ObjectID, ObjectType, ObjectName, MemberID, MemberName, ComCentent, Addtime, ComStatus  ");
            strSql.Append("  from WebSiteComments ");
            strSql.Append(" where ID=@ID");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)
			};
            parameters[0].Value = ID;
            WebSiteCommentsModel model = new WebSiteCommentsModel();
            DataSet ds = helper.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["ID"].ToString() != "")
                {
                    model.ID = int.Parse(ds.Tables[0].Rows[0]["ID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["ObjectID"].ToString() != "")
                {
                    model.ObjectID = long.Parse(ds.Tables[0].Rows[0]["ObjectID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["ObjectType"].ToString() != "")
                {
                    model.ObjectType = int.Parse(ds.Tables[0].Rows[0]["ObjectType"].ToString());
                }
                model.ObjectName = ds.Tables[0].Rows[0]["ObjectName"].ToString();
                if (ds.Tables[0].Rows[0]["MemberID"].ToString() != "")
                {
                    model.MemberID = int.Parse(ds.Tables[0].Rows[0]["MemberID"].ToString());
                }
                model.MemberName = ds.Tables[0].Rows[0]["MemberName"].ToString();
                model.ComCentent = ds.Tables[0].Rows[0]["ComCentent"].ToString();
                if (ds.Tables[0].Rows[0]["Addtime"].ToString() != "")
                {
                    model.Addtime = DateTime.Parse(ds.Tables[0].Rows[0]["Addtime"].ToString());
                }
                if (ds.Tables[0].Rows[0]["ComStatus"].ToString() != "")
                {
                    model.ComStatus = int.Parse(ds.Tables[0].Rows[0]["ComStatus"].ToString());
                }
                return model;
            }
            else
            {
                return null;
            }
        }
        /// <summary>
        /// 得到一个对象的全部评论实体
        /// </summary>
        public List<WebSiteCommentsModel> GetAllListModel(int objID, int type)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ID, ObjectID, ObjectType, ObjectName, MemberID, MemberName, ComCentent, Addtime, ComStatus  ");
            strSql.Append("  from WebSiteComments ");
            strSql.Append(" where ObjectID=@ObjectID AND ObjectType=@ObjectType AND ComStatus=1  ORDER BY ID DESC");
            SqlParameter[] parameters = {
					new SqlParameter("@ObjectID", SqlDbType.Int),
                    new SqlParameter("@ObjectType", SqlDbType.Int)

			};
            parameters[0].Value = objID;
            parameters[1].Value = type;
            List<WebSiteCommentsModel> list = new List<WebSiteCommentsModel>();

            DataSet ds = helper.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow item in ds.Tables[0].Rows)
                {
                    WebSiteCommentsModel model = new WebSiteCommentsModel();
                    if (item["ID"].ToString() != "")
                    {
                        model.ID = int.Parse(item["ID"].ToString());
                    }
                    if (item["ObjectID"].ToString() != "")
                    {
                        model.ObjectID = long.Parse(item["ObjectID"].ToString());
                    }
                    if (item["ObjectType"].ToString() != "")
                    {
                        model.ObjectType = int.Parse(item["ObjectType"].ToString());
                    }
                    model.ObjectName = item["ObjectName"].ToString();
                    if (item["MemberID"].ToString() != "")
                    {
                        model.MemberID = int.Parse(item["MemberID"].ToString());
                    }
                    model.MemberName = item["MemberName"].ToString();
                    model.ComCentent = item["ComCentent"].ToString();
                    if (item["Addtime"].ToString() != "")
                    {
                        model.Addtime = DateTime.Parse(item["Addtime"].ToString());
                    }
                    if (item["ComStatus"].ToString() != "")
                    {
                        model.ComStatus = int.Parse(item["ComStatus"].ToString());
                    }
                    list.Add(model);
                }
            }
            return list;
        }
    }
}
