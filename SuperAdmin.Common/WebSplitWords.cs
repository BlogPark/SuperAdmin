using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using PanGu;
using SuperAdmin.datamodel;

namespace SuperAdmin.Common
{
    /// <summary>
    /// 分词操作类
    /// </summary>
    //调用示例 
    //       WebSplitWords sp = new WebSplitWords();
    //       string ss = sp.DoSegmentToJsonstr("安稳中国张成航");
    public class WebSplitWords
    {
        private PanGu.Match.MatchOptions _Options;
        private PanGu.Match.MatchParameter _Parameters;
        static readonly string sqlconnect = System.Configuration.ConfigurationManager.AppSettings["connectstr"];
        static readonly string filename = System.AppDomain.CurrentDomain.BaseDirectory + "PanGu.xml";
        public WebSplitWords()
        {
            Segment.Initfromdb(sqlconnect, filename);
            _Options = PanGu.Setting.PanGuSettings.Config.MatchOptions.Clone();
            _Parameters = PanGu.Setting.PanGuSettings.Config.Parameters.Clone();
        }
        /// <summary>
        /// 得到分词结果的字符串
        /// </summary>
        /// <param name="inputText"></param>
        /// <returns></returns>
        public string DisplaySegment(string inputText)
        {
            try
            {
                Segment segment = new Segment();
                ICollection<WordInfo> words = segment.DoSegmentfromDB(sqlconnect, filename, inputText, _Options, _Parameters);

                StringBuilder wordsString = new StringBuilder();
                foreach (WordInfo wordInfo in words)
                {
                    wordsString.AppendFormat("{0}^{1}.0^{2}^{3}/", wordInfo.Word.ToLower(), (int)Math.Pow(3, wordInfo.Rank), wordInfo.TId, wordInfo.Hot);
                }
                return wordsString.ToString().TrimEnd('/');
            }
            catch { }
            return "";
        }
        /// <summary>
        /// 分词得到Json字符串
        /// </summary>
        /// <param name="inputText"></param>
        /// <returns></returns>
        public string DoSegmentToJsonstr(string inputText)
        {
            string jsonstr = "";
            try
            {
                Segment segment = new Segment();
                ICollection<WordInfo> words = segment.DoSegmentfromDB(sqlconnect, filename, inputText, _Options, _Parameters);

                StringBuilder wordsString = new StringBuilder();
                foreach (WordInfo wordInfo in words)
                {
                    wordsString.AppendFormat("{0}^{1}.0^{2}^{3}/", wordInfo.Word.ToLower(), (int)Math.Pow(3, wordInfo.Rank), wordInfo.TId, wordInfo.Hot);
                }
                if (!string.IsNullOrWhiteSpace(wordsString.ToString().TrimEnd('/')))
                {
                    string str = wordsString.ToString().TrimEnd('/');
                    List<object> dic = new List<object>();
                    foreach (var item in str.Split('/'))
                    {
                        string[] subitems = item.Split('^');
                        dic.Add(new { tagId = Convert.ToInt64(subitems[2]), tagName = Convert.ToString(subitems[0]) });
                    }
                    jsonstr = JsonHelper.SerializeObject(dic);
                }
            }
            catch { jsonstr = ""; }
            return jsonstr;
        }
        /// <summary>
        /// 分析分出的关键词
        /// </summary>
        /// <param name="tagjsonstr"></param>
        /// <returns></returns>
        public List<SplitTagModel> AnalyticalTagJson(string tagstr)
        {
            List<SplitTagModel> list = new List<SplitTagModel>();
            string str = tagstr.ToString().TrimEnd('/');
            string[] totaltags = str.Split('/');
            foreach (var item in totaltags)
            {
                string[] subitems = item.Split('^');
                string word = subitems[0];
                long tagid = Convert.ToInt64(subitems[2]);
                int hot = Convert.ToInt32(subitems[3]);
                if (word.Length < 2 || word.Length > 4)
                {
                    //关键词太长或者太短 都不要
                    continue;
                }
                Regex re = new Regex(word);
                int repet = re.Matches(tagstr).Count;
                var result = list.Where(m => m.TagName == word).ToList();
                if (result.Count > 0)
                {
                    continue;
                }
                SplitTagModel model = new SplitTagModel();
                model.TagID = tagid;
                model.TagName = word;
                model.RepeatTime = repet;
                model.hot = hot;
                list.Add(model);
            }
            return list;
        }
    }
}
