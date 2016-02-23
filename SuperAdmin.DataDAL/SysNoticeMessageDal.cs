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
    /// 系统公告处理类
    /// </summary>
    public class SysNoticeMessageDal
    {
        DbHelperSQL helper = new DbHelperSQL();
        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int AddSysNotice(SysNoticeMessageModel model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into SysNoticeMessage(");
            strSql.Append("NoticeStatus,NoticeTitle,NoticeType,LaunchPeopleID,LaunchPeopleName,NoticeContent,CreateTime");
            strSql.Append(") values (");
            strSql.Append("@NoticeStatus,@NoticeTitle,@NoticeType,@LaunchPeopleID,@LaunchPeopleName,@NoticeContent,GETDATE()");
            strSql.Append(") ");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
			            new SqlParameter("@NoticeStatus", SqlDbType.Int) ,            
                        new SqlParameter("@NoticeTitle", SqlDbType.NVarChar) ,            
                        new SqlParameter("@NoticeType", SqlDbType.Int) ,            
                        new SqlParameter("@LaunchPeopleID", SqlDbType.Int) ,            
                        new SqlParameter("@LaunchPeopleName", SqlDbType.NVarChar) ,            
                        new SqlParameter("@NoticeContent", SqlDbType.NVarChar) 
            };
            parameters[0].Value = model.NoticeStatus;
            parameters[1].Value = model.NoticeTitle;
            parameters[2].Value = model.NoticeType;
            parameters[3].Value = model.LaunchPeopleID;
            parameters[4].Value = model.LaunchPeopleName;
            parameters[5].Value = model.NoticeContent;
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
        /// 更新一条数据详细信息
        /// </summary>
        public bool UpdateSysNotice(SysNoticeMessageModel model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update SysNoticeMessage set ");
            strSql.Append(" NoticeStatus = @NoticeStatus , ");
            strSql.Append(" NoticeTitle = @NoticeTitle , ");
            strSql.Append(" NoticeType = @NoticeType , ");
            strSql.Append(" LaunchPeopleID = @LaunchPeopleID , ");
            strSql.Append(" LaunchPeopleName = @LaunchPeopleName , ");
            strSql.Append(" NoticeContent = @NoticeContent , ");
            strSql.Append(" CreateTime = @CreateTime , ");
            strSql.Append(" LoseTime = @LoseTime , ");
            strSql.Append(" Sort = @Sort  ");
            strSql.Append(" where ID=@ID ");
            SqlParameter[] parameters = {
			            new SqlParameter("@ID", SqlDbType.Int) ,            
                        new SqlParameter("@NoticeStatus", SqlDbType.Int) ,            
                        new SqlParameter("@NoticeTitle", SqlDbType.NVarChar) ,            
                        new SqlParameter("@NoticeType", SqlDbType.Int,4) ,            
                        new SqlParameter("@LaunchPeopleID", SqlDbType.Int,4) ,            
                        new SqlParameter("@LaunchPeopleName", SqlDbType.NVarChar) ,            
                        new SqlParameter("@NoticeContent", SqlDbType.NVarChar) ,            
                        new SqlParameter("@CreateTime", SqlDbType.DateTime) ,            
                        new SqlParameter("@LoseTime", SqlDbType.DateTime) ,            
                        new SqlParameter("@Sort", SqlDbType.Int)             
            };
            parameters[0].Value = model.ID;
            parameters[1].Value = model.NoticeStatus;
            parameters[2].Value = model.NoticeTitle;
            parameters[3].Value = model.NoticeType;
            parameters[4].Value = model.LaunchPeopleID;
            parameters[5].Value = model.LaunchPeopleName;
            parameters[6].Value = model.NoticeContent;
            parameters[7].Value = model.CreateTime;
            parameters[8].Value = model.LoseTime;
            parameters[9].Value = model.Sort;
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
        /// 更新一条数据的状态
        /// </summary>
        public bool UpdateSysNoticeStatus(int id,int status)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update SysNoticeMessage set ");
            strSql.Append(" NoticeStatus = @NoticeStatus ");
            strSql.Append(" where ID=@ID ");
            SqlParameter[] parameters = {
			            new SqlParameter("@ID", SqlDbType.Int) ,            
                        new SqlParameter("@NoticeStatus", SqlDbType.Int) 
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
        public SysNoticeMessageModel GetSingleSysNotice(int ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ID, NoticeStatus, NoticeTitle, NoticeType, LaunchPeopleID, LaunchPeopleName, NoticeContent, CreateTime, LoseTime, Sort  ");
            strSql.Append("  from SysNoticeMessage ");
            strSql.Append(" where ID=@ID");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int)
			};
            parameters[0].Value = ID;
            SysNoticeMessageModel model = new SysNoticeMessageModel();
            DataSet ds = helper.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["ID"].ToString() != "")
                {
                    model.ID = int.Parse(ds.Tables[0].Rows[0]["ID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["NoticeStatus"].ToString() != "")
                {
                    model.NoticeStatus = int.Parse(ds.Tables[0].Rows[0]["NoticeStatus"].ToString());
                }
                model.NoticeTitle = ds.Tables[0].Rows[0]["NoticeTitle"].ToString();
                if (ds.Tables[0].Rows[0]["NoticeType"].ToString() != "")
                {
                    model.NoticeType = int.Parse(ds.Tables[0].Rows[0]["NoticeType"].ToString());
                }
                if (ds.Tables[0].Rows[0]["LaunchPeopleID"].ToString() != "")
                {
                    model.LaunchPeopleID = int.Parse(ds.Tables[0].Rows[0]["LaunchPeopleID"].ToString());
                }
                model.LaunchPeopleName = ds.Tables[0].Rows[0]["LaunchPeopleName"].ToString();
                model.NoticeContent = ds.Tables[0].Rows[0]["NoticeContent"].ToString();
                if (ds.Tables[0].Rows[0]["CreateTime"].ToString() != "")
                {
                    model.CreateTime = DateTime.Parse(ds.Tables[0].Rows[0]["CreateTime"].ToString());
                }
                if (ds.Tables[0].Rows[0]["LoseTime"].ToString() != "")
                {
                    model.LoseTime = DateTime.Parse(ds.Tables[0].Rows[0]["LoseTime"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Sort"].ToString() != "")
                {
                    model.Sort = int.Parse(ds.Tables[0].Rows[0]["Sort"].ToString());
                }
                return model;
            }
            else
            {
                return null;
            }
        }
        /// <summary>
        /// 得到全部公告信息
        /// </summary>
        public List<SysNoticeMessageModel> GetAllSysNotice()
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ID, NoticeStatus, NoticeTitle, NoticeType, LaunchPeopleID, LaunchPeopleName, NoticeContent, CreateTime, LoseTime, Sort, case NoticeStatus when 1 then '已发布' when 0  then '已删除' end as NoticeStatusName");
            strSql.Append("  from SysNoticeMessage ");
            List<SysNoticeMessageModel> list = new List<SysNoticeMessageModel>();
            DataSet ds = helper.Query(strSql.ToString());
            if (ds.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow item in ds.Tables[0].Rows)
                {
                    SysNoticeMessageModel model = new SysNoticeMessageModel();
                    if (item["ID"].ToString() != "")
                    {
                        model.ID = int.Parse(item["ID"].ToString());
                    }
                    if (item["NoticeStatus"].ToString() != "")
                    {
                        model.NoticeStatus = int.Parse(item["NoticeStatus"].ToString());
                    }
                    model.NoticeTitle = item["NoticeTitle"].ToString();
                    if (item["NoticeType"].ToString() != "")
                    {
                        model.NoticeType = int.Parse(item["NoticeType"].ToString());
                    }
                    if (item["LaunchPeopleID"].ToString() != "")
                    {
                        model.LaunchPeopleID = int.Parse(item["LaunchPeopleID"].ToString());
                    }
                    model.LaunchPeopleName = item["LaunchPeopleName"].ToString();
                    model.NoticeContent = item["NoticeContent"].ToString();
                    if (item["CreateTime"].ToString() != "")
                    {
                        model.CreateTime = DateTime.Parse(item["CreateTime"].ToString());
                    }
                    if (item["LoseTime"].ToString() != "")
                    {
                        model.LoseTime = DateTime.Parse(item["LoseTime"].ToString());
                    }
                    if (item["Sort"].ToString() != "")
                    {
                        model.Sort = int.Parse(item["Sort"].ToString());
                    }
                    model.NoticeStatusName = item["NoticeStatusName"].ToString();
                    list.Add(model);
                }
            }
            return list;
        }
    }
}
