using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PanGu;

namespace SuperAdmin.Common
{
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

        public string DisplaySegment(string inputText)
        {
            try
            {
                Segment segment = new Segment();
                ICollection<WordInfo> words = segment.DoSegmentfromDB(sqlconnect,filename, inputText, _Options, _Parameters);

                StringBuilder wordsString = new StringBuilder();
                foreach (WordInfo wordInfo in words)
                {
                    wordsString.AppendFormat("{0}^{1}.0^{2}/", wordInfo.Word.ToLower(), (int)Math.Pow(3, wordInfo.Rank), wordInfo.TId);
                }
                return wordsString.ToString().TrimEnd('/');
            }
            catch { }
            return "";
        }
    }
}
