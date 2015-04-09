using System;
using System.Web;
using System.Web.Configuration;
using WX_Tools;
using WX_Tools.Entites;

namespace WeiXin_Web
{
    /// <summary>
    /// WXCheck 的摘要说明
    /// </summary>
    public class WxCheck : IHttpHandler
    {
        private readonly AppidSecretToken _appidSecret=new AppidSecretToken();
        public void ProcessRequest(HttpContext context)
        {

            string token = WebConfigurationManager.AppSettings["token"];

            context.Response.ContentType = "text/plain";
            //context.Response.Write("Hello World");

            if (context.Request.HttpMethod.ToLower().Equals("get"))
            {
               
                //校验
                if (new Check().ValidateUrl(token))
                {
                    context.Response.Write(context.Request["echostr"].ToString());
                }     
            }
            else
            {
              
                if (!new Check().ValidateUrl(token))
                {
                   
                    context.Response.Write("参数错误");
                    return;
                }
          

                try
                {
                    _appidSecret.Appid = WebConfigurationManager.AppSettings["appid"];
                    _appidSecret.Secret = WebConfigurationManager.AppSettings["secret"];
                    //接收并响应
                    new Handler().ExecHandler(_appidSecret);
                }
                catch (Exception ex)
                {
                    new DebugLog().BugWriteTxt("WXCheck.ashx页面异常："+ex.ToString());
                }
               

            }

        }



     
   

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}