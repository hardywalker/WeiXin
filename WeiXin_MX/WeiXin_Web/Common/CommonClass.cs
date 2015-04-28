using System;
using System.Web;
using System.Web.Script.Serialization;
using Newtonsoft.Json.Linq;
using WX_Tools;
using WX_Tools.Entites;

namespace WeiXin_Web.Common
{
    public class CommonClass
    {
        WeiXinConfiguration _weiXinConfiguration = new WeiXinConfiguration();
        readonly XmlReadWrite _xmlReadWrite = new XmlReadWrite();


        /// <summary>
        /// 取得access_token
        /// </summary>
        /// <returns></returns>
        public string Get_access_token(WeiXinConfiguration weiXinConfiguration, string serverORcatch)
        {

            //access_token缓存名称
            string accesstokenCachname = AllCach.AllCachEnum.AccessToken.ToString();

            //缓存类型
            object accesstokenCache = HttpContext.Current.Cache[accesstokenCachname];



            //从服务器获得access_token
            if (serverORcatch.Equals("server"))
            {
                accesstokenCache = null;
            }


            if (accesstokenCache == null)
            {

                string resultJson = new GetAccessToken().get_access_token(weiXinConfiguration);

               JavaScriptSerializer javaScriptSerializer = new JavaScriptSerializer();
                AccessToken accessToken = javaScriptSerializer.Deserialize(resultJson, typeof(AccessToken)) as AccessToken;


                //把获取到access_token放入缓存中，设置失效时间为7000秒，比微信服务器上短一点就行
                HttpContext.Current.Cache.Insert(AllCach.AllCachEnum.AccessToken.ToString(),
                    accessToken.Access_token, null, DateTime.Now.AddSeconds(7000), TimeSpan.Zero);

                accesstokenCache = HttpContext.Current.Cache[accesstokenCachname];

            }


            return accesstokenCache.ToString();
        }

        /// <summary>
        /// 获取服务器Ip地址,
        /// </summary>
        /// <param name="appidSecretToken"></param>
        /// <returns></returns>

        public string GET_IP_List(WeiXinConfiguration weiXinConfiguration)
        {
            string accesstoken = Get_access_token(weiXinConfiguration, "catch");

            

          string jsonResult=  new Getcallbackip().GetServerIpString(accesstoken);
            JObject jObject = JObject.Parse(jsonResult);//获取服务器Ip,这样获得是的json格式
            JArray jArray = JArray.Parse(jObject["ip_list"].ToString());//转换指定的ip_list
            
          return string.Join(",", jArray);
        }


        /// <summary>
        /// 获取appid secret token等信息
        /// </summary>
        /// <returns>返回AppidSecretToken对象</returns>
        public WeiXinConfiguration GetConfiguration()
        {
            return _weiXinConfiguration = _xmlReadWrite.Read("/XML/", _weiXinConfiguration, "set.config") as WeiXinConfiguration;
        }

    }
}