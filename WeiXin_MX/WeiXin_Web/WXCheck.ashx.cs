using System;
using System.IO;
using System.Web;
using WX_Tools;

namespace WeiXin_Web
{
    /// <summary>
    /// WXCheck 的摘要说明
    /// </summary>
    public class WXCheck : IHttpHandler
    { 

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            //context.Response.Write("Hello World");

            if (context.Request.HttpMethod.ToLower().Equals("get"))
            {
                File.WriteAllText(context.Server.MapPath("/ErrorTXT/" + DateTime.Now.ToString("yyyy-MM-dd-HH-mm-ss") + ".txt"), "我是通过GET方式来的");
                //校验
                if (new Check().ValidateUrl())
                {
                    context.Response.Write(context.Request["echostr"].ToString());
                }     
            }
            else
            {
                File.WriteAllText(context.Server.MapPath("/ErrorTXT/" + DateTime.Now.ToString("yyyy-MM-dd-HH-mm-ss") + ".txt"), "我是通过Post方式来的");
                if (!new Check().ValidateUrl())
                {
                    File.WriteAllText(context.Server.MapPath("/ErrorTXT/" + DateTime.Now.ToString("yyyy-MM-dd-HH-mm-ss") + ".txt"), "我是通过Post方式来的，我没有通过验证");
                    context.Response.Write("参数错误");
                    return;
                }
                File.WriteAllText(context.Server.MapPath("/ErrorTXT/" + DateTime.Now.ToString("yyyy-MM-dd-HH-mm-ss") + ".txt"), "我是通过Post方式来的，我已经通过了验证");
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
                    //接收并响应
                    new Handler().ExecHandler();
                }
                catch (Exception ex)
                {


                    File.WriteAllText(context.Server.MapPath("/ErrorTXT/" + DateTime.Now.ToString("yyyy-MM-dd-HH-mm-ss") + ".txt"), "我是入口页面的异常：\r\n" + ex.Message+"|\r\n"+ex.StackTrace+"|\r\n"+ex.ToString());

                    context.Response.Write(ex.Message);
                    //context.Response.End();
                    context.ApplicationInstance.CompleteRequest();
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