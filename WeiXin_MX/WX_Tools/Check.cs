﻿using System;
using System.IO;
using System.Web;
using System.Web.Security;

namespace WX_Tools
{

    /// <summary>
    /// 验证
    /// </summary>
   public class Check
    {
        /*
            * signature 	微信加密签名，signature结合了开发者填写的token参数和请求中的timestamp参数、nonce参数。
               timestamp 	时间戳
               nonce 	随机数
               echostr 	随机字符串 
            */
      
     
       public bool ValidateUrl()
       {
              HttpContext httpContext = HttpContext.Current;
           string signature = httpContext.Request["signature"];
           string timestamp = httpContext.Request["timestamp"];
           string nonce = httpContext.Request["nonce"];
           string echostr = httpContext.Request["echostr"];
           string token = "anyangmaxin";

           string[] temp1 = { token, timestamp, nonce };

           //排序
           Array.Sort(temp1);

           //sha1加密
           string temp2 = string.Join("", temp1);
           string temp3 = FormsAuthentication.HashPasswordForStoringInConfigFile(temp2, "SHA1");


           //对比
           //if (temp3.ToLower().Equals(signature))
           //{
           //    File.WriteAllText(httpContext.Server.MapPath("/ErrorTXT/" + DateTime.Now.ToString("yyyy-MM-dd-HH-mm-ss") + ".txt"), "我是验证时候的记录|" + signature + "|" + timestamp + "|" + nonce);
           //    return echostr;
           //}
           //return "";


           return temp3.ToLower().Equals(signature);
       }



    }
}