﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace MauiApp3.Model
{
    public class UpdateNovelInfo: NovelInfo
    {
      
      
        private string _id;
        public string NovleId
        {
            get
            {
                if (!string.IsNullOrEmpty(_id))
                {
                    return _id;
                }
                var match = Regex.Match(Url, @"\d+");
                if (int.TryParse(match.Value, out int id))
                {
                    _id = match.Value.ToString();
                }
                else
                {

                    _id = Guid.NewGuid().ToString("N");
                }
                return _id;
            }
        }

    }
    public class NovelPageInfo
    {
        public List<UpdateNovelInfo> Infos { get; set; }
        public int PageCount { get; set; }
        public int CurrentPage { get; set; }
    }
}
