using System;
using System.Web;
using WX_Tools;
using WX_Tools.Entites;

namespace WeiXin_Web
{
    /// <summary>
    /// WXCheck 的摘要说明
    /// </summary>
    public class WXCheck : IHttpHandler
    { 
        public AppidSecret AppidSecret=new AppidSecret();
        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            //context.Response.Write("Hello World");

            if (context.Request.HttpMethod.ToLower().Equals("get"))
            {
               
                //校验
                if (new Check().ValidateUrl())
                {
                    context.Response.Write(context.Request["echostr"].ToString());
                }     
            }
            else
            {
              
                if (!new Check().ValidateUrl())
                {
                   
                    context.Response.Write("参数错误");
                    return;
                }
              
                /*
                 *  <xml>
                        <ToUserName><![CDATA[toUser]]></ToUserName>
                        <FromUserName><![CDATA[fromUser]]></FromUserName> 
                        <CreateTime>1348831860</CreateTime>
                        <MsgType><![CDATA[text]]></MsgType>
                        <Content><![CDATA[this is a test]]></Content>
                        <MsgId>1234567890123456</MsgId>
                    </xml>
                 * 
                 * 
                 *
                 */

                try
                {
                    AppidSecret.appid = "wxa29576cd9bb8fa92";
                    AppidSecret.secret = "841a341dc0e60c105a14ee9734d51319";
                    //接收并响应
                    new Handler().ExecHandler(AppidSecret);
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