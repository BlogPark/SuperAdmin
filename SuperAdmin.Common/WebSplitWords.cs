﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PanGu;

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

        public string DisplaySegment(string inputText)
        {
            try
            {
                Segment segment = new Segment();
                ICollection<WordInfo> words = segment.DoSegmentfromDB(sqlconnect,filename, inputText, _Options, _Parameters);

                StringBuilder wordsString = new StringBuilder();
                foreach (WordInfo wordInfo in words)
                {
                    wordsString.AppendFormat("{0}^{1}.0^{2}^{3}/", wordInfo.Word.ToLower(), (int)Math.Pow(3, wordInfo.Rank), wordInfo.TId,wordInfo.Hot);
                }
                return wordsString.ToString().TrimEnd('/');
            }
            catch { }
            return "";
        }

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
                    Dictionary<long, string> dic = new Dictionary<long, string>();
                    foreach (var item in str.Split('/'))
                    {
                        string[] subitems = item.Split('^');
                        dic.Add(Convert.ToInt64(subitems[2]),Convert.ToString(subitems[0]));
                    }
                   jsonstr= JsonHelper.SerializeObject(dic);
                }
            }
            catch {jsonstr=""; }
            return jsonstr;
        }
    }
}