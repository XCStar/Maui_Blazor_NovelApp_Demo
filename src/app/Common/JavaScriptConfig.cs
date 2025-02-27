﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiApp3.Common
{
    public class JavaScriptConfig
    {
        public static readonly string userAgentScript = @"
 Object.defineProperties(window.navigator, {
    'userAgent': {
      enumerable: true,
      value: 'Mozilla/5.0 (Windows Phone 10)'
    },
    'appVersion': {
      enumerable: true,
      value: '5.0 (Windows Phone 10)'
    },
    'platform': {
      enumerable: true,
      value: 'Win32'
    }
  });
".Replace("\r", "").Replace("\n", "");
        public static readonly string zhiHuJavaSrcitpt = @"
var style = document.querySelector('style');
      style.innerHTML +='.MobileAppHeader-downloadLink {display: none !important;}';
function remove(sel) {document.querySelectorAll(sel).forEach( a => a.style.display='none');};
remove('DIV.AdvertImg.AdvertImg--isLoaded.MBannerAd-image');
remove('DIV.Banner-adTag');
remove('div.MBannerAd-third');
remove('a.MHotFeedAd');
remove('div.Pc-feedAd-container.Pc-feedAd-container--mobile');
remove('.WeiboAd-wrap');
remove('div.AdBelowMoreAnswers');
remove('div.OpenInAppButton');
remove('.KfeCollection-VipRecommendCard');
remove('div.MHotFeedAd-smallCard');
remove('div[style = ""margin - bottom: 10px;""]');
remove('div.Question-sideColumn');
remove('div .HotQuestions');
remove('div.RelatedReadings');
remove('div.MobileAppHeader-actions');
remove('div.ecommerce-ad-box');
remove('div.ecommerce-ad-commodity-box');
document.querySelector('.MBannerAd').style.display='none';
var links=document.querySelectorAll('a.HotQuestionsItem');
for(var i=0;i<links.length;i++)
{
  links[i].onClick=null;
}
remove('img.HotQuestionsItem-img');
window.alert('clear');
".Replace("\r", "").Replace("\n", "");
        public static readonly HashSet<string> userAgentHosts = new HashSet<string>();
    }
}
