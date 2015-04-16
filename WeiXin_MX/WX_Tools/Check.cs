using System;
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
      
     
       /// <summary>
       /// 验证token
       /// </summary>
       /// <param name="strToken">token</param>
       /// <returns>返回布尔值</returns>
       public bool ValidateUrl(string strToken)
       {
              HttpContext httpContext = HttpContext.Current;
           string signature = httpContext.Request["signature"];
           string timestamp = httpContext.Request["timestamp"];
           string nonce = httpContext.Request["nonce"];
           //string echostr = httpContext.Request["echostr"];


           string[] temp1 = { strToken, timestamp, nonce };

           //排序
           Array.Sort(temp1);

           //sha1加密
           string temp2 = string.Join("", temp1);
           string temp3 = FormsAuthentication.HashPasswordForStoringInConfigFile(temp2, "SHA1");


           return temp3.ToLower().Equals(signature);
       }



    }
}
