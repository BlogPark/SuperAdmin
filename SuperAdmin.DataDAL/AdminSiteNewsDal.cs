﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SuperAdmin.datamodel;

namespace SuperAdmin.DataDAL
{
    public class AdminSiteNewsDal
    {
        DbHelperSQL helper = new DbHelperSQL();
        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int AddAdminSiteNew(AdminSiteNewsModel model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into AdminSiteNews(");
            strSql.Append("STitle,SContent,SendUserID,SendUserName,ReceiveUserID,ReceiveUserName,SStatus,SAddTime");
            strSql.Append(") values (");
            strSql.Append("@STitle,@SContent,@SendUserID,@SendUserName,@ReceiveUserID,@ReceiveUserName,1,GETDATE()");
            strSql.Append(") ");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {      
                        new SqlParameter("@STitle", SqlDbType.NVarChar) ,            
                        new SqlParameter("@SContent", SqlDbType.NVarChar) ,            
                        new SqlParameter("@SendUserID", SqlDbType.Int) ,            
                        new SqlParameter("@SendUserName", SqlDbType.NVarChar) ,            
                        new SqlParameter("@ReceiveUserID", SqlDbType.Int) ,            
                        new SqlParameter("@ReceiveUserName", SqlDbType.NVarChar) ,            
                        new SqlParameter("@SStatus", SqlDbType.Int)  
            };
            parameters[0].Value = model.STitle;
            parameters[1].Value = model.SContent;
            parameters[2].Value = model.SendUserID;
            parameters[3].Value = model.SendUserName;
            parameters[4].Value = model.ReceiveUserID;
            parameters[5].Value = model.ReceiveUserName;
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
        /// 设置紧急条目
        /// </summary>
        public bool SetUrgent(int id, int isurgent)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update AdminSiteNews set ");
            strSql.Append(" IsUrgent = @IsUrgent ");
            strSql.Append(" where ID=@ID ");

            SqlParameter[] parameters = {
			            new SqlParameter("@ID", SqlDbType.Int) ,            
                        new SqlParameter("@IsUrgent", SqlDbType.Int)
            };
            parameters[0].Value = id;
            parameters[1].Value = isurgent;
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
        /// 设置置顶条目
        /// </summary>
        public bool SetIsTop(int id, int istop)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update AdminSiteNews set ");
            strSql.Append(" IsTop = @IsTop  ");
            strSql.Append(" where ID=@ID ");

            SqlParameter[] parameters = {
			            new SqlParameter("@ID", SqlDbType.Int) ,                
                        new SqlParameter("@IsTop", SqlDbType.Int)      
            };
            parameters[0].Value = id;
            parameters[1].Value = istop;
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
        /// 更新条目状态
        /// </summary>
        public bool UpdateStatus(int id, int status)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update AdminSiteNews set ");
            strSql.Append(" SStatus = @SStatus ");
            strSql.Append(" where ID=@ID ");

            SqlParameter[] parameters = {
			            new SqlParameter("@ID", SqlDbType.Int) ,          
                        new SqlParameter("@SStatus", SqlDbType.Int)  
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
        /// 根据ID得到一个对象实体
        /// </summary>
        public AdminSiteNewsModel GetModel(int ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ID, IsUrgent, IsTop, STitle, SContent, SendUserID, SendUserName, ReceiveUserID, ReceiveUserName, SStatus, SAddTime  ");
            strSql.Append("  from AdminSiteNews ");
            strSql.Append(" where ID=@ID");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int)
			};
            parameters[0].Value = ID;
            AdminSiteNewsModel model = new AdminSiteNewsModel();
            DataSet ds = helper.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["ID"].ToString() != "")
                {
                    model.ID = int.Parse(ds.Tables[0].Rows[0]["ID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["IsUrgent"].ToString() != "")
                {
                    model.IsUrgent = int.Parse(ds.Tables[0].Rows[0]["IsUrgent"].ToString());
                }
                if (ds.Tables[0].Rows[0]["IsTop"].ToString() != "")
                {
                    model.IsTop = int.Parse(ds.Tables[0].Rows[0]["IsTop"].ToString());
                }
                model.STitle = ds.Tables[0].Rows[0]["STitle"].ToString();
                model.SContent = ds.Tables[0].Rows[0]["SContent"].ToString();
                if (ds.Tables[0].Rows[0]["SendUserID"].ToString() != "")
                {
                    model.SendUserID = int.Parse(ds.Tables[0].Rows[0]["SendUserID"].ToString());
                }
                model.SendUserName = ds.Tables[0].Rows[0]["SendUserName"].ToString();
                if (ds.Tables[0].Rows[0]["ReceiveUserID"].ToString() != "")
                {
                    model.ReceiveUserID = int.Parse(ds.Tables[0].Rows[0]["ReceiveUserID"].ToString());
                }
                model.ReceiveUserName = ds.Tables[0].Rows[0]["ReceiveUserName"].ToString();
                if (ds.Tables[0].Rows[0]["SStatus"].ToString() != "")
                {
                    model.SStatus = int.Parse(ds.Tables[0].Rows[0]["SStatus"].ToString());
                }
                if (ds.Tables[0].Rows[0]["SAddTime"].ToString() != "")
                {
                    model.SAddTime = DateTime.Parse(ds.Tables[0].Rows[0]["SAddTime"].ToString());
                }
                return model;
            }
            else
            {
                return null;
            }
        }
        /// <summary>
        /// 根据ID得到一个对象实体
        /// </summary>
        public List<AdminSiteNewsModel> GetModelListByUserID(int userid)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ID, IsUrgent, IsTop, STitle, SContent, SendUserID, SendUserName, ReceiveUserID, ReceiveUserName, SStatus, SAddTime  ");
            strSql.Append("  from AdminSiteNews ");
            strSql.Append(" where ReceiveUserID=@userID AND SStatus IN (1,2) ");
            strSql.Append(" ORDER BY  IsTop DESC,ID DESC ");
            SqlParameter[] parameters = {
					new SqlParameter("@userID", SqlDbType.Int)
			};
            parameters[0].Value = userid;
            List<AdminSiteNewsModel> list = new List<AdminSiteNewsModel>();
            DataSet ds = helper.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow item in ds.Tables[0].Rows)
                {
                    AdminSiteNewsModel model = new AdminSiteNewsModel();
                    if (item["ID"].ToString() != "")
                    {
                        model.ID = int.Parse(item["ID"].ToString());
                    }
                    if (item["IsUrgent"].ToString() != "")
                    {
                        model.IsUrgent = int.Parse(item["IsUrgent"].ToString());
                    }
                    if (item["IsTop"].ToString() != "")
                    {
                        model.IsTop = int.Parse(item["IsTop"].ToString());
                    }
                    model.STitle = item["STitle"].ToString();
                    model.SContent = item["SContent"].ToString();
                    if (item["SendUserID"].ToString() != "")
                    {
                        model.SendUserID = int.Parse(item["SendUserID"].ToString());
                    }
                    model.SendUserName = item["SendUserName"].ToString();
                    if (item["ReceiveUserID"].ToString() != "")
                    {
                        model.ReceiveUserID = int.Parse(item["ReceiveUserID"].ToString());
                    }
                    model.ReceiveUserName = item["ReceiveUserName"].ToString();
                    if (item["SStatus"].ToString() != "")
                    {
                        model.SStatus = int.Parse(item["SStatus"].ToString());
                    }
                    if (item["SAddTime"].ToString() != "")
                    {
                        model.SAddTime = DateTime.Parse(item["SAddTime"].ToString());
                    }
                    list.Add(model);
                }
            }
            return list;
        }

        /// <summary>
        /// 根据ID得到一个对象实体
        /// </summary>
        public List<AdminSiteNewsModel> GetTop3ModelListByUserID(int userid)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select top 3 ID, IsUrgent, IsTop, STitle, SContent, SendUserID, SendUserName, ReceiveUserID, ReceiveUserName, SStatus, SAddTime  ");
            strSql.Append("  from AdminSiteNews ");
            strSql.Append(" where ReceiveUserID=@userID AND SStatus IN (1,2) ");
            strSql.Append(" ORDER BY  IsTop DESC,ID DESC ");
            SqlParameter[] parameters = {
					new SqlParameter("@userID", SqlDbType.Int)
			};
            parameters[0].Value = userid;
            List<AdminSiteNewsModel> list = new List<AdminSiteNewsModel>();
            DataSet ds = helper.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow item in ds.Tables[0].Rows)
                {
                    AdminSiteNewsModel model = new AdminSiteNewsModel();
                    if (item["ID"].ToString() != "")
                    {
                        model.ID = int.Parse(item["ID"].ToString());
                    }
                    if (item["IsUrgent"].ToString() != "")
                    {
                        model.IsUrgent = int.Parse(item["IsUrgent"].ToString());
                    }
                    if (item["IsTop"].ToString() != "")
                    {
                        model.IsTop = int.Parse(item["IsTop"].ToString());
                    }
                    model.STitle = item["STitle"].ToString();
                    model.SContent = item["SContent"].ToString();
                    if (item["SendUserID"].ToString() != "")
                    {
                        model.SendUserID = int.Parse(item["SendUserID"].ToString());
                    }
                    model.SendUserName = item["SendUserName"].ToString();
                    if (item["ReceiveUserID"].ToString() != "")
                    {
                        model.ReceiveUserID = int.Parse(item["ReceiveUserID"].ToString());
                    }
                    model.ReceiveUserName = item["ReceiveUserName"].ToString();
                    if (item["SStatus"].ToString() != "")
                    {
                        model.SStatus = int.Parse(item["SStatus"].ToString());
                    }
                    if (item["SAddTime"].ToString() != "")
                    {
                        model.SAddTime = DateTime.Parse(item["SAddTime"].ToString());
                    }
                    list.Add(model);
                }
            }
            return list;
        }
    }
}
