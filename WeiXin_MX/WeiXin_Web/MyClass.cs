using System;
using System.Web;
using System.Web.Script.Serialization;
using WX_Tools;
using WX_Tools.Entites;

namespace WeiXin_Web
{



    public class MyClass
    {
     

        /// <summary>
        /// 取得access_token
        /// </summary>
        /// <returns></returns>
        public string Get_access_token(AppidSecretToken appidSecret, string serverORcatch)
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

                string resultJson = new GetAccessToken().get_access_token(appidSecret);

                JavaScriptSerializer javaScriptSerializer = new JavaScriptSerializer();
                AccessToken accessToken = javaScriptSerializer.Deserialize(resultJson, typeof(AccessToken)) as AccessToken;


                //把获取到access_token放入缓存中，设置失效时间为7000秒，比微信服务器上短一点就行
                HttpContext.Current.Cache.Insert(AllCach.AllCachEnum.AccessToken.ToString(),
                    accessToken.Access_token, null, DateTime.Now.AddSeconds(7000), TimeSpan.Zero);

                accesstokenCache = HttpContext.Current.Cache[accesstokenCachname];

            }


            return accesstokenCache.ToString();
        }

    }

}

