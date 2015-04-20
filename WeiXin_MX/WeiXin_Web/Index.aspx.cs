using System;
using System.Text;
using System.Web;
using System.Web.Configuration;
using System.Web.Script.Serialization;
using System.Web.UI;
using WX_Tools;
using WX_Tools.Entites;

namespace WeiXin_Web
{
    public partial class Index : Page
    {
        private AppidSecretToken _appidSecret=new AppidSecretToken();

        protected void Page_Load(object sender, EventArgs e)
        {

            //为AppidSecretToken对象赋值
            _appidSecret.Appid = WebConfigurationManager.AppSettings["appid"];
            _appidSecret.Secret = WebConfigurationManager.AppSettings["secret"];
            }
        

       


        /// <summary>
        /// 获取服务器ip
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btn_get_server_ip_OnClick(object sender, EventArgs e)
        {
          //  lab_server_ip.Text = new Getcallbackip().GetServerIpString(_appidSecret);
        }

       

        /// <summary>
        /// 提交图文消息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btn_send_tuwen_OnClick(object sender, EventArgs e)
        {
          // lab_send_tuwen_msg.Text= new MediaUpload().MediaUploadNews(_appidSecret, txt_send_tuwen.Text.Trim());
        }


        /// <summary>
        /// 获取access_token
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btn_get_access_token_OnClick(object sender, EventArgs e)
        {

            //  string accesstoken=new GetAccessToken().Get_access_token(_appidSecret,"catch");
            string accesstoken = Get_access_token(_appidSecret, "catch");
            new DebugLog().BugWriteTxt(new Log() { LogTxtPhyPath = "/ErrorTXT/" }.LogTxtPhyPath, accesstoken);
            lab_access_token.Text = accesstoken;
        }





        /// <summary>
        /// 更新access_token
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btn_update_access_token_OnServerClick(object sender, EventArgs e)
        {
            lab_access_token.Text = Get_access_token(_appidSecret, "server");
        }




        /// <summary>
        /// 取得access_token
        /// </summary>
        /// <returns></returns>
        public string Get_access_token(AppidSecretToken appidSecret, string serverORcatch)
        {

            //access_token缓存名称
            string accesstokenCachname = AllCach.AllCachEnum.AccessToken.ToString();
           
            //缓存类型
            var accesstokenCache = HttpContext.Current.Cache[accesstokenCachname];

            //从服务器获得access_token
            if (serverORcatch.Equals("server"))
            {
                accesstokenCache = null;
            }
            

            if (accesstokenCache == null)
            {
              
               string resultJson=  new GetAccessToken().get_access_token(appidSecret);

                JavaScriptSerializer javaScriptSerializer=new JavaScriptSerializer();
               AccessToken accessToken= javaScriptSerializer.Deserialize(resultJson, typeof (AccessToken)) as AccessToken;


               //把获取到access_token放入缓存中，设置失效时间为7000秒，比微信服务器上短一点就行
               HttpContext.Current.Cache.Insert(AllCach.AllCachEnum.AccessToken.ToString(),
                   accessToken.Access_token, null, DateTime.Now.AddSeconds(7000), TimeSpan.Zero);

            }
            


           


            return accesstokenCache.ToString();
        }
    }
}