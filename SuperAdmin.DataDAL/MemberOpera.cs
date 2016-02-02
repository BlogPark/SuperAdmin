using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using SuperAdmin.datamodel;

namespace SuperAdmin.DataDAL
{
    /// <summary>
    /// 会员操作类
    /// </summary>
    public class MemberOpera
    {
        DbHelperSQL helper = new DbHelperSQL();

        #region 管理员后台
        /// <summary>
        /// 根据ID得到会员的信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public MemberInfoModel GetSingleMemberByID(int id)
        {
            MemberInfoModel model = new MemberInfoModel();
            string sqltxt = @"SELECT  ID ,
        MemberName ,
        MPassword ,
        Mgender ,
        MEmail ,
        MRegisterTime ,
        MStatus ,
        CASE MStatus
          WHEN 100 THEN '待审核'
          WHEN 200 THEN '审核通过'
          WHEN 300 THEN '账户禁用'
        END AS MstatusName ,
        CheckUserID ,
        CheckUserName ,
        CheckTime ,
        HeadImg ,
        ContactMsg ,
        MGrade ,
        CASE MGrade
          WHEN 1 THEN '普通会员'
          WHEN 2 THEN '银牌会员'
          WHEN 3 THEN '金牌会员'
          WHEN 4 THEN '至尊VIP'
        END AS MGradeName ,
        LastLoginTime ,
        LastLoginIP ,
        Paperworkpic ,
        PaperworkImg ,
        TruethName
FROM    dbo.MemberInfo WITH(NOLOCK)
WHERE ID=@id";
            SqlParameter[] paramter = { new SqlParameter("@id", id) };
            DataTable dt = helper.Query(sqltxt, paramter).Tables[0];
            if (dt.Rows.Count > 0)
            {
                model.CheckTime = string.IsNullOrWhiteSpace(dt.Rows[0]["CheckTime"].ToString()) ? DateTime.MinValue : DateTime.Parse(dt.Rows[0]["CheckTime"].ToString()); 
                model.CheckUserID =string.IsNullOrWhiteSpace(dt.Rows[0]["CheckUserID"].ToString())?0: int.Parse(dt.Rows[0]["CheckUserID"].ToString());
                model.CheckUserName = dt.Rows[0]["CheckUserName"].ToString();
                model.ContactMsg = dt.Rows[0]["ContactMsg"].ToString();
                model.HeadImg = dt.Rows[0]["HeadImg"].ToString();
                model.ID = int.Parse(dt.Rows[0]["ID"].ToString());
                model.LastLoginIP = dt.Rows[0]["LastLoginIP"].ToString();
                model.LastLoginTime = string.IsNullOrWhiteSpace(dt.Rows[0]["LastLoginTime"].ToString()) ? DateTime.MinValue : DateTime.Parse(dt.Rows[0]["LastLoginTime"].ToString()); 
                model.MEmail = dt.Rows[0]["MEmail"].ToString();
                model.MemberName = dt.Rows[0]["MemberName"].ToString();
                model.Mgender = dt.Rows[0]["Mgender"].ToString();
                model.MGrade = int.Parse(dt.Rows[0]["MGrade"].ToString());
                model.MGradeName = dt.Rows[0]["MGradeName"].ToString();
                model.MRegisterTime =string.IsNullOrWhiteSpace(dt.Rows[0]["MRegisterTime"].ToString())?DateTime.MinValue: DateTime.Parse(dt.Rows[0]["MRegisterTime"].ToString());
                model.MStatus = int.Parse(dt.Rows[0]["MStatus"].ToString());
                model.MstatusName = dt.Rows[0]["MstatusName"].ToString();
                model.PaperworkImg = dt.Rows[0]["PaperworkImg"].ToString();
                model.Paperworkpic = dt.Rows[0]["Paperworkpic"].ToString();
                model.TruethName = dt.Rows[0]["TruethName"].ToString();
            }
            return model;
        }
        /// <summary>
        /// 得到所有的会员信息
        /// </summary>
        /// <returns></returns>
        public List<MemberInfoModel> GetAllMemberInfo()
        {
            List<MemberInfoModel> list = new List<MemberInfoModel>();
            string sqltxt = @"SELECT  ID ,
        MemberName ,
        MPassword ,
        Mgender ,
        MEmail ,
        MRegisterTime ,
        MStatus ,
        CASE MStatus
          WHEN 100 THEN '待审核'
          WHEN 200 THEN '审核通过'
          WHEN 300 THEN '账户禁用'
        END AS MstatusName ,
        CheckUserID ,
        CheckUserName ,
        CheckTime ,
        HeadImg ,
        ContactMsg ,
        MGrade ,
        CASE MGrade
          WHEN 1 THEN '普通会员'
          WHEN 2 THEN '银牌会员'
          WHEN 3 THEN '金牌会员'
          WHEN 4 THEN '至尊VIP'
        END AS MGradeName ,
        LastLoginTime ,
        LastLoginIP ,
        Paperworkpic ,
        PaperworkImg ,
        TruethName
FROM    dbo.MemberInfo WITH(NOLOCK)";
            DataTable dt = helper.Query(sqltxt).Tables[0];
            foreach (DataRow item in dt.Rows)
            {
                MemberInfoModel model = new MemberInfoModel();
                model.CheckTime = string.IsNullOrWhiteSpace(item["CheckTime"].ToString()) ? DateTime.MinValue : DateTime.Parse(item["CheckTime"].ToString());
                model.CheckUserID = string.IsNullOrWhiteSpace(item["CheckUserID"].ToString()) ? 0 : int.Parse(item["CheckUserID"].ToString());
                model.CheckUserName = item["CheckUserName"].ToString();
                model.ContactMsg = item["ContactMsg"].ToString();
                model.HeadImg = item["HeadImg"].ToString();
                model.ID = int.Parse(item["ID"].ToString());
                model.LastLoginIP = item["LastLoginIP"].ToString();
                model.LastLoginTime = string.IsNullOrWhiteSpace(item["LastLoginTime"].ToString()) ? DateTime.MinValue : DateTime.Parse(item["LastLoginTime"].ToString());
                model.MEmail = item["MEmail"].ToString();
                model.MemberName = item["MemberName"].ToString();
                model.Mgender = item["Mgender"].ToString();
                model.MGrade = int.Parse(item["MGrade"].ToString());
                model.MGradeName = item["MGradeName"].ToString();
                model.MRegisterTime = string.IsNullOrWhiteSpace(item["MRegisterTime"].ToString()) ? DateTime.MinValue : DateTime.Parse(item["MRegisterTime"].ToString());
                model.MStatus = int.Parse(item["MStatus"].ToString());
                model.MstatusName = item["MstatusName"].ToString();
                model.PaperworkImg = item["PaperworkImg"].ToString();
                model.Paperworkpic = item["Paperworkpic"].ToString();
                model.TruethName = item["TruethName"].ToString();
                list.Add(model);
            }
            return list;
        }
        /// <summary>
        /// 更改账户状态
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int CheckMemberStatus(MemberInfoModel model)
        {
            int rowcount = 0;
            string sqltxt = @"UPDATE  dbo.MemberInfo WITH(ROWLOCK)
SET     MStatus =  CASE MStatus
                    WHEN 100 THEN 200
                    WHEN 200 THEN 100
                    WHEN 300 THEN 300
                  END  ,
        CheckUserID = @CheckUserID ,
        CheckUserName = @CheckUserName ,
        CheckTime = GETDATE()
WHERE   ID = @id";
            SqlParameter[] paramter = { new SqlParameter("@CheckUserID",model.CheckUserID),
                                      new SqlParameter("@CheckUserName",model.CheckUserName),
                                      new SqlParameter("@id",model.ID)};
            rowcount = helper.ExecuteSql(sqltxt, paramter);
            return rowcount;
        }
        /// <summary>
        /// 禁用会员账户
        /// </summary>
        /// <param name="mid"></param>
        /// <returns></returns>
        public int DelMember(int mid)
        {
            int rowcount = 0;
            string sqltxt = @"UPDATE  dbo.MemberInfo WITH(ROWLOCK)
SET     MStatus =  300
WHERE   ID = @id";
            SqlParameter[] paramter = { new SqlParameter("@id", mid) };
            rowcount = helper.ExecuteSql(sqltxt, paramter);
            return rowcount;
        }
        #endregion
    }
}
