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
    public class WebSiteImageDal
    {
        DbHelperSQL helper = new DbHelperSQL();
        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int AddWebSiteImage(WebSiteImageModel model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into WebSiteImage(");
            strSql.Append("AddTime,PicCateID,PicCateName,PicName,PicTags,PicUrl,PicWidth,PicHeight,PicStatus,AddUserID,AddUserName");
            strSql.Append(") values (");
            strSql.Append("GETDATE(),@PicCateID,@PicCateName,@PicName,@PicTags,@PicUrl,@PicWidth,@PicHeight,@PicStatus,@AddUserID,@AddUserName");
            strSql.Append(") ");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {          
                        new SqlParameter("@PicCateID", SqlDbType.Int,4) ,            
                        new SqlParameter("@PicCateName", SqlDbType.NVarChar,50) ,            
                        new SqlParameter("@PicName", SqlDbType.NVarChar,100) ,            
                        new SqlParameter("@PicTags", SqlDbType.NVarChar,500) ,            
                        new SqlParameter("@PicUrl", SqlDbType.NVarChar,500) ,            
                        new SqlParameter("@PicWidth", SqlDbType.Int,4) ,            
                        new SqlParameter("@PicHeight", SqlDbType.Int,4) ,            
                        new SqlParameter("@PicStatus", SqlDbType.Int,4) ,            
                        new SqlParameter("@AddUserID", SqlDbType.Int,4) ,            
                        new SqlParameter("@AddUserName", SqlDbType.NVarChar,20)       
            };
            parameters[0].Value = model.PicCateID;
            parameters[1].Value = model.PicCateName;
            parameters[2].Value = model.PicName;
            parameters[3].Value = model.PicTags;
            parameters[4].Value = model.PicUrl;
            parameters[5].Value = model.PicWidth;
            parameters[6].Value = model.PicHeight;
            parameters[7].Value = model.PicStatus;
            parameters[8].Value = model.AddUserID;
            parameters[9].Value = model.AddUserName;
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
        public bool UpdateWebSiteImage(WebSiteImageModel model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update WebSiteImage set ");
            strSql.Append(" PicCateID = @PicCateID , ");
            strSql.Append(" PicCateName = @PicCateName , ");
            strSql.Append(" PicName = @PicName , ");
            strSql.Append(" PicTags = @PicTags , ");
            strSql.Append(" PicStatus = @PicStatus");
            strSql.Append(" where ID=@ID ");

            SqlParameter[] parameters = {
			            new SqlParameter("@ID", SqlDbType.Int,4) ,                
                        new SqlParameter("@PicCateID", SqlDbType.Int,4) ,            
                        new SqlParameter("@PicCateName", SqlDbType.NVarChar,50) ,            
                        new SqlParameter("@PicName", SqlDbType.NVarChar,100) ,            
                        new SqlParameter("@PicTags", SqlDbType.NVarChar,500) , 
                        new SqlParameter("@PicStatus", SqlDbType.Int,4)        
            };
            parameters[0].Value = model.ID;
            parameters[1].Value = model.PicCateID;
            parameters[2].Value = model.PicCateName;
            parameters[3].Value = model.PicName;
            parameters[4].Value = model.PicTags;
            parameters[5].Value = model.PicStatus;
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
        public WebSiteImageModel GetSingleModel(int ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ID, AddTime, PicCateID, PicCateName, PicName, PicTags, PicUrl, PicWidth, PicHeight, PicStatus, AddUserID, AddUserName  ");
            strSql.Append("  from WebSiteImage ");
            strSql.Append(" where ID=@ID");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)
			};
            parameters[0].Value = ID;
            WebSiteImageModel model = new WebSiteImageModel();
            DataSet ds = helper.Query(strSql.ToString(), parameters);

            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["ID"].ToString() != "")
                {
                    model.ID = int.Parse(ds.Tables[0].Rows[0]["ID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["AddTime"].ToString() != "")
                {
                    model.AddTime = DateTime.Parse(ds.Tables[0].Rows[0]["AddTime"].ToString());
                }
                if (ds.Tables[0].Rows[0]["PicCateID"].ToString() != "")
                {
                    model.PicCateID = int.Parse(ds.Tables[0].Rows[0]["PicCateID"].ToString());
                }
                model.PicCateName = ds.Tables[0].Rows[0]["PicCateName"].ToString();
                model.PicName = ds.Tables[0].Rows[0]["PicName"].ToString();
                model.PicTags = ds.Tables[0].Rows[0]["PicTags"].ToString();
                model.PicUrl = ds.Tables[0].Rows[0]["PicUrl"].ToString();
                if (ds.Tables[0].Rows[0]["PicWidth"].ToString() != "")
                {
                    model.PicWidth = int.Parse(ds.Tables[0].Rows[0]["PicWidth"].ToString());
                }
                if (ds.Tables[0].Rows[0]["PicHeight"].ToString() != "")
                {
                    model.PicHeight = int.Parse(ds.Tables[0].Rows[0]["PicHeight"].ToString());
                }
                if (ds.Tables[0].Rows[0]["PicStatus"].ToString() != "")
                {
                    model.PicStatus = int.Parse(ds.Tables[0].Rows[0]["PicStatus"].ToString());
                }
                if (ds.Tables[0].Rows[0]["AddUserID"].ToString() != "")
                {
                    model.AddUserID = int.Parse(ds.Tables[0].Rows[0]["AddUserID"].ToString());
                }
                model.AddUserName = ds.Tables[0].Rows[0]["AddUserName"].ToString();
                model.PicUrlStr = appcontent.Imgdomain + ds.Tables[0].Rows[0]["PicUrl"].ToString();
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
        public List<WebSiteImageModel> GetAllModel()
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ID, AddTime, PicCateID, PicCateName, PicName, PicTags, PicUrl, PicWidth, PicHeight, PicStatus, AddUserID, AddUserName ,case PicStatus when 1 then '激活' else '已删除' end as PicStatusName ");
            strSql.Append("  from WebSiteImage ");
            DataSet ds = helper.Query(strSql.ToString());
            List<WebSiteImageModel> list = new List<WebSiteImageModel>();
            if (ds.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow item in ds.Tables[0].Rows)
                {
                    WebSiteImageModel model = new WebSiteImageModel();
                    if (item["ID"].ToString() != "")
                    {
                        model.ID = int.Parse(item["ID"].ToString());
                    }
                    if (item["AddTime"].ToString() != "")
                    {
                        model.AddTime = DateTime.Parse(item["AddTime"].ToString());
                    }
                    if (item["PicCateID"].ToString() != "")
                    {
                        model.PicCateID = int.Parse(item["PicCateID"].ToString());
                    }
                    model.PicCateName = item["PicCateName"].ToString();
                    model.PicName = item["PicName"].ToString();
                    model.PicTags = item["PicTags"].ToString();
                    model.PicUrl = item["PicUrl"].ToString();
                    if (item["PicWidth"].ToString() != "")
                    {
                        model.PicWidth = int.Parse(item["PicWidth"].ToString());
                    }
                    if (item["PicHeight"].ToString() != "")
                    {
                        model.PicHeight = int.Parse(item["PicHeight"].ToString());
                    }
                    if (item["PicStatus"].ToString() != "")
                    {
                        model.PicStatus = int.Parse(item["PicStatus"].ToString());
                    }
                    if (item["AddUserID"].ToString() != "")
                    {
                        model.AddUserID = int.Parse(item["AddUserID"].ToString());
                    }
                    model.PicUrlStr = appcontent.Imgdomain + item["PicUrl"].ToString();
                    model.AddUserName = item["AddUserName"].ToString();
                    model.PicStatusName = item["PicStatusName"].ToString();
                    list.Add(model);
                }
            }
            return list;
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool UpdateWebSiteImageStatus(int id,int status)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update WebSiteImage set ");
            strSql.Append(" PicStatus = @PicStatus");
            strSql.Append(" where ID=@ID ");

            SqlParameter[] parameters = {
			            new SqlParameter("@ID", SqlDbType.Int,4) ,    
                        new SqlParameter("@PicStatus", SqlDbType.Int,4)        
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
        /// 得到图片类别对象实体
        /// </summary>
        public List<PicCategoryModel> GetPicCategoryModel()
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ID, PiccName, PiccStatus, Addtime, AddUserID  ");
            strSql.Append("  from PicCategory ");
            strSql.Append(" where PiccStatus=1");
            DataSet ds = helper.Query(strSql.ToString());
            List<PicCategoryModel> list = new List<PicCategoryModel>();
            if (ds.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow item in ds.Tables[0].Rows)
                {
                    PicCategoryModel model = new PicCategoryModel();
                    if (item["ID"].ToString() != "")
                    {
                        model.ID = int.Parse(item["ID"].ToString());
                    }
                    model.PiccName = item["PiccName"].ToString();
                    if (item["PiccStatus"].ToString() != "")
                    {
                        model.PiccStatus = int.Parse(item["PiccStatus"].ToString());
                    }
                    if (item["Addtime"].ToString() != "")
                    {
                        model.Addtime = DateTime.Parse(item["Addtime"].ToString());
                    }
                    if (item["AddUserID"].ToString() != "")
                    {
                        model.AddUserID = int.Parse(item["AddUserID"].ToString());
                    }
                    list.Add(model);
                }
            }
            return list;
        }
    }
}
