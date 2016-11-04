using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SuperAdmin.DataDAL;
using SuperAdmin.datamodel;

namespace SuperAdmin.DataBLL
{
    public  class MemberOperaBll
    {
        MemberOpera dal = new MemberOpera();
        #region 管理员后台
        /// <summary>
        /// 根据ID得到会员的信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public MemberInfoModel GetSingleMemberByID(int id)
        {
            return dal.GetSingleMemberByID(id);
        }

        /// <summary>
        /// 得到所有的会员信息
        /// </summary>
        /// <returns></returns>
        public List<MemberInfoModel> GetAllMemberInfo()
        {
            return dal.GetAllMemberInfo();
        }
        /// <summary>
        /// 更改账户状态
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int CheckMemberStatus(MemberInfoModel model)
        {
            return dal.CheckMemberStatus(model);
        }
        /// <summary>
        /// 禁用会员账户
        /// </summary>
        /// <param name="mid"></param>
        /// <returns></returns>
        public int DelMember(int mid)
        {
            return dal.DelMember(mid);
        }
        #endregion
    }
}
