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
               
                //校验
                context.Response.Write(new Check().ValidateUrl());     
            }
            else
            {

                if (!new Check().ValidateUrlBool())
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
                    //接收并响应
                    new Handler().ExecHandler();
                }
                catch (Exception ex)
                {


                    File.WriteAllText(context.Server.MapPath("/ErrorTXT/" + new DateTime().ToString("yyyy-MM-dd HH:ss") + ".txt"), "我是入口页面的异常：" + ex.InnerException);

                    context.Response.Write(ex.Message);
                    context.Response.End();
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