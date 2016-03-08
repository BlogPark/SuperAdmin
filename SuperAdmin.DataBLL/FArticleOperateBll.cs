using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SuperAdmin.datamodel;

namespace SuperAdmin.DataBLL
{
    public class FArticleOperateBll
    {
        ArtCategoryBll catebll = new ArtCategoryBll();
        ArticleOperateBll artbll = new ArticleOperateBll();
        public List<ArtCategoryModel> GetAllCategory()
        {
            return catebll.GetALLModel(1);
        }
        public Dictionary<int, List<ArticlesModel>> GetCategoryAndArticles()
        {
            Dictionary<int, List<ArticlesModel>> result = new Dictionary<int, List<ArticlesModel>>();
            Dictionary<int, List<string>> cateids = artbll.GetJobCategoryAndArticle();
            foreach (var item in cateids)
            {
                List<string> aids = item.Value;
                List<ArticlesModel> arts = artbll.GetAllArticlesbyids(string.Join(",", aids.Take(12)));
                result.Add(item.Key, arts);
            }
            return result;
        }

        private List<string> ComputePageByLinq(List<string> ids, int pageCurrent, int pageSize, out int pageCount, out int recordCount)
        {
            pageCount = recordCount = 0;
            List<string> currentArtIds = new List<string>();

            if (ids == null || ids.Any() == false)
                return currentArtIds;

            //文章总数
            recordCount = ids.Count();

            //页码数（此计算方式不存在余数问题）
            pageCount = (recordCount + pageSize - 1) / pageSize;
            //当前页之前的对应的文章总量
            if (pageCurrent < 1) { pageCurrent = 1; }
            if (pageCurrent == 1)
            {
                currentArtIds = ids.Take(pageSize).ToList();
            }
            else
            {
                if (pageCurrent > pageCount) { pageCurrent = pageCount; }
                currentArtIds = ids.Skip(pageSize * (pageCurrent - 1)).Take(pageSize).ToList();
            }

            if (pageCount == pageCurrent && currentArtIds.Count() < pageSize)
            {
                var diffArtIds = ids.Except(currentArtIds).Take(pageSize - currentArtIds.Count());
                currentArtIds.AddRange(diffArtIds);
            }
            return currentArtIds;
        }

    }
}
