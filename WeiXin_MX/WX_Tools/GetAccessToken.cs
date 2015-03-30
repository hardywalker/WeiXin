using System;
using System.IO;
using System.Net;
using System.Text;
using System.Web;
using System.Web.Caching;
using Newtonsoft.Json.Linq;
using WX_Tools.Entites;

namespace WX_Tools
{
    /// <summary>
    /// 获取access_token
    /// </summary>
    public class GetAccessToken
    {
        /*
         * access_token是公众号的全局唯一票据，公众号调用各接口时都需使用access_token。开发者需要进行妥善保存。access_token的存储至少要保留512个字符空间。access_token的有效期目前为2个小时，需定时刷新，重复获取将导致上次获取的access_token失效。
         * 
         * 1、为了保密appsecrect，第三方需要一个access_token获取和刷新的中控服务器。而其他业务逻辑服务器所使用的access_token均来自于该中控服务器，不应该各自去刷新，否则会造成access_token覆盖而影响业务；
           2、目前access_token的有效期通过返回的expire_in来传达，目前是7200秒之内的值。中控服务器需要根据这个有效时间提前去刷新新access_token。在刷新过程中，中控服务器对外输出的依然是老access_token，此时公众平台后台会保证在刷新短时间内，新老access_token都可用，这保证了第三方业务的平滑过渡；
           3、access_token的有效时间可能会在未来有调整，所以中控服务器不仅需要内部定时主动刷新，还需要提供被动刷新access_token的接口，这样便于业务服务器在API调用获知access_token已超时的情况下，可以触发access_token的刷新流程。
         * 
         * http请求方式: GET
           https://api.weixin.qq.com/cgi-bin/token?grant_type=client_credential&appid=APPID&secret=APPSECRET
         * 
         * 
         * grant_type 	是 	获取access_token填写client_credential
           appid 	是 	第三方用户唯一凭证
           secret 	是 	第三方用户唯一凭证密钥，即appsecret 
         * 
         * 
         * 返回说明

             正常情况下，微信会返回下述JSON数据包给公众号：

         {"access_token":"ACCESS_TOKEN","expires_in":7200}
 
         * 
        

           参数 	说明
           access_token 	获取到的凭证
           expires_in 	凭证有效时间，单位：秒 
         */
    
       

        /// <summary>
        /// 取得access_token
        /// </summary>
        /// <returns></returns>
        public string Get_access_token(AppidSecret appidSecret)
        {
            string accesstokenCachname = AllCach.AllCachEnum.AccessToken.ToString();

            var accesstokenCache=HttpContext.Current.Cache[accesstokenCachname];


            if (accesstokenCache == null)
            {
                return InsertCache_access_token(appidSecret);
            }
            return accesstokenCache.ToString();
        }

        /// <summary>
        /// 获取access_token，如果有就从缓存中获取，如果没有，就从微信服务器获取。
        /// </summary>
        /// <returns></returns>
        private string InsertCache_access_token(AppidSecret appidSecret)
        {
            string accesstoken = "";
            //建立完整的访问url
     
            string httpGetAccessToken = string.Format(new ApiAddress().AccessToken,appidSecret.Appid,appidSecret.Secret);
            //创建HttpWebRequest对象
            HttpWebRequest httpWebRequest = WebRequest.Create(httpGetAccessToken) as HttpWebRequest;
            if (httpWebRequest != null)
            {
                httpWebRequest.Method = "GET";
                httpWebRequest.ContentType = "application/json; charset=utf-8";
         
                HttpWebResponse httpWebResponse = (HttpWebResponse)httpWebRequest.GetResponse();
                Stream stream = httpWebResponse.GetResponseStream();

                if (stream != null)
                {
                    StreamReader streamReader = new StreamReader(stream, Encoding.GetEncoding("UTF-8"));
                    //获取返回的流字符串
                    string jsonData = streamReader.ReadToEnd();


                    JObject jsonJObject = JObject.Parse(jsonData);
                     accesstoken = jsonJObject["access_token"].ToString();
                    streamReader.Close();
                    stream.Close();

                    //把获取到access_token放入缓存中，设置失效时间为7000秒，比微信服务器上短一点就行
                    HttpContext.Current.Cache.Insert(AllCach.AllCachEnum.AccessToken.ToString(),
                        accesstoken, null, DateTime.Now.AddSeconds(7000),TimeSpan.Zero);

               
                    
                }
           
            }
            return accesstoken;

        }

    }
}
