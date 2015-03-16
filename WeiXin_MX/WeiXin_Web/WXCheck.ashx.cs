using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Xml;

namespace WeiXin_Web
{
    /// <summary>
    /// WXCheck 的摘要说明
    /// </summary>
    public class WXCheck : IHttpHandler
    {

        private static string msg;

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            //context.Response.Write("Hello World");

            if (context.Request.HttpMethod.ToLower().Equals("get"))
            {
                //输出结果
                context.Response.Write(msg);
                //校验
            ValidateUrl();     
            }
            else
            {
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

                //接收并响应
                HandleMsg();



            }

        }

        private void ValidateUrl()
        {
            /*
             * signature 	微信加密签名，signature结合了开发者填写的token参数和请求中的timestamp参数、nonce参数。
                timestamp 	时间戳
                nonce 	随机数
                echostr 	随机字符串 
             */

            HttpContext httpContext=HttpContext.Current;
            string signature = httpContext.Request["signature"];
            string timestamp = httpContext.Request["timestamp"];
            string nonce = httpContext.Request["nonce"];
            string echostr = httpContext.Request["echostr"];

            string token = "anyangmaxin";

            string[] temp1 = {token,timestamp,nonce};

            //排序
            Array.Sort(temp1);

            //sha1加密
            string temp2 = string.Join("", temp1);
            string temp3=FormsAuthentication.HashPasswordForStoringInConfigFile(temp2, "SHA1");


            //对比
            if (temp3.ToLower().Equals(signature))
            {
                httpContext.Response.Write(echostr);
            }
         



        }


        private void HandleMsg()
        {
            /*
             *  ToUserName 	开发者微信号
                   FromUserName 	发送方帐号（一个OpenID）
                   CreateTime 	消息创建时间 （整型）
                   MsgType 	text
                   Content 	文本消息内容
                   MsgId 	消息id，64位整型 
             * 
             * 
             * 
             *  <xml>
                        <ToUserName><![CDATA[toUser]]></ToUserName>
                        <FromUserName><![CDATA[fromUser]]></FromUserName> 
                        <CreateTime>1348831860</CreateTime>
                        <MsgType><![CDATA[text]]></MsgType>
                        <Content><![CDATA[this is a test]]></Content>
                        <MsgId>1234567890123456</MsgId>
                    </xml>
             */


            HttpContext httpContext = HttpContext.Current;

            //接收 xml数据包
            Stream xmlStream = httpContext.Request.InputStream;


            //构造xml对象
            XmlDocument xmlDocument=new XmlDocument();
            xmlDocument.Load(xmlStream);
            //获取根节点
            XmlElement rootXmlElement = xmlDocument.DocumentElement;

            //开发者微信号
            string toUserName = rootXmlElement.SelectSingleNode("ToUserName").InnerText;

            string fromUserName = rootXmlElement.SelectSingleNode("FromUserName").InnerText;

            string createTime = rootXmlElement.SelectSingleNode("CreateTime").InnerText;


            string msgType = rootXmlElement.SelectSingleNode("MsgType").InnerText;

            string content = rootXmlElement.SelectSingleNode("Content").InnerText;

            string msgId = rootXmlElement.SelectSingleNode("MsgId").InnerText;

            //将捕获的消息封装成指定格式字符串
            msg = string.Format("{0}\r\n-{1}\r\n-{2}\r\n-{3}\r\n-{4}\r\n-{5}\r\n",toUserName,fromUserName,createTime,msgType,content,msgId);



            /*被动回复消息
             * <xml>
               <ToUserName><![CDATA[toUser]]></ToUserName>
               <FromUserName><![CDATA[fromUser]]></FromUserName>
               <CreateTime>12345678</CreateTime>
               <MsgType><![CDATA[text]]></MsgType>
               <Content><![CDATA[你好]]></Content>
               </xml>
             */
            string access_token = "暂未获取access_token";
            if (content == "票据")
            {
                access_token= new WX_Tools.get_access_token().Get_access_token();

            }



            string replyXmlMsg = string.Format(@"<xml><ToUserName><![CDATA[{0}]]></ToUserName><FromUserName><![CDATA[{1}]]></FromUserName>
                                           <CreateTime>{2}</CreateTime><MsgType><![CDATA[text]]></MsgType><Content><![CDATA[{3}{4}{5}{6}-access_token为：{7}]]></Content></xml>",fromUserName,toUserName,GetCreateTime(),"十分感谢-",fromUserName,"-来光临我的公众号.时间戳为：",GetCreateTime(),access_token);

            httpContext.Response.Write(replyXmlMsg);

        }


        /// <summary>
        /// 取得时间戳
        /// </summary>
        /// <returns></returns>
        private int GetCreateTime()
        {
            DateTime dateTime=new DateTime(1970,1,1,8,0,0);
           return (int)(DateTime.Now - dateTime).TotalSeconds;

 
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