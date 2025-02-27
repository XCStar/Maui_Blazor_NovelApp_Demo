﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security;
using System.Security.Cryptography;

namespace MauiApp3.Common
{
    public class StringExtensions
    {
        public static string GetMd5(string s)
        {
            if (string.IsNullOrEmpty(s))
            {
                return string.Empty;
            }
            using (var md5 = MD5.Create())
            {
                var bytes=md5.ComputeHash(Encoding.UTF8.GetBytes(s));
                var builder=new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2"));
                }
                return builder.ToString();  
            }
           
        }
        public static string HtmlFormat(string s)
        {
            var sb = new StringBuilder(s.Length*2);
            sb.Append("<p>");
            var index = 0;
            while (index < s.Length)
            {
                if (s[index] == '\n' || s[index] == '\r')
                {
                    index++;
                    continue;
                }
                if (s[index] == '【')
                {
                    sb.Append("<p>");
                    sb.Append(s[index]);
                    index++;
                }
                else if (s[index] == '】')
                {
                    sb.Append(s[index]);
                    sb.Append("</p>");
                    index++;
                }
                else if (s[index] == '。')
                {
                    if (index < s.Length - 1)
                    {
                        if (s[index + 1] == '”')
                        {
                            sb.Append("。");
                            sb.Append(s[index + 1]);
                            sb.Append("</p>");
                            sb.Append("<p>");
                            index += 2;
                            continue;
                        }
                        else if (s[index + 1] == '】')
                        {
                            index++;
                            continue;
                        }

                    }
                    sb.Append('。');
                    sb.Append("</p>");
                    sb.Append("<p>");
                    index++;
                }
                else if (s[index] == '！' || s[index] == '？')
                {
                    if (index < s.Length - 1)
                    {
                        if (s[index + 1] == '”')
                        {
                            sb.Append("。");
                            sb.Append(s[index + 1]);
                            sb.Append("</p>");
                            sb.Append("<p>");
                            index += 2;
                            continue;
                        }
                    }
                    sb.Append(s[index++]);
                }
                else
                {
                    sb.Append(s[index]);
                    index++;
                }
            }
            
            sb.Append("</p>");
            return sb.ToString();
        }
        public static string HtmlForMat166(string s)
        {
          
            var span = s.AsMemory();
            var index= GetEndIndex(span, 0);
            while (index != -1&&index<span.Length)
            {
                span=span.Slice(index);
                index = GetEndIndex(span,0);
            }
            index= GetEndIndex(span);
            if (index != -1)
            {
                span= span.Slice(0,index);
            }
            return span.ToString();
        }
        private static int GetEndIndex(ReadOnlyMemory<char> span, int index)
        {
            while (index < span.Length)
            {
                var c = span.Span[index];
               
                if (span.Span[index] == '/' &&index<span.Length-2&&span.Span[index + 1] == 'p'&& span.Span[index + 2] == '>')
                {
                    break;
                }
                if (span.Span[index] == '<' && index < span.Length - 1 && span.Span[index + 1] == 'b')
                {
                    return -1;
                }
                index++;
            }
            if (index == span.Length)
            {
                return -1;
            }
            return index+3;
        }
        private static int GetEndIndex(ReadOnlyMemory<char> span)
        {
            var index = 0;
            while (index < span.Length)
            {
                if (span.Span[index] == '<' && index < span.Length - 1 && span.Span[index + 1] == 's')
                {
                    return index;
                }
                index++;
            }
            return -1;
            
        }
        public  static IEnumerable<KeyValuePair<string, string>> GetCookie(IEnumerable<string> cookies)
        {
            var list = new List<KeyValuePair<string, string>>();
            foreach (var cookie in cookies)
            {
                var cookieInfo = cookie.Split(new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries);
                if (cookieInfo.Length > 1)
                {
                    var arr = cookieInfo.First().Split(new char[] { '=' }, StringSplitOptions.RemoveEmptyEntries);
                    if (arr.Length > 0)
                    {
                        var key = arr[0];
                        var value = string.Empty;
                        if (arr.Length > 1)
                        {
                            value = arr[1];
                        }
                        list.Add(new KeyValuePair<string, string>(key, value));
                    }

                }
            }
            return list;
        }
    }
}
