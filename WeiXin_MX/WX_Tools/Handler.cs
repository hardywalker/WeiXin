using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Xml;

namespace WX_Tools
{
    /// <summary>
    /// 处理通过POST方式提交过来的请求
    /// </summary>
  public  class Handler
    {

        //开发者微信号
       string toUserName, fromUserName, createTime, msgType, content, msgId;
       HttpContext httpContext = HttpContext.Current;

      public void ExecHandler()
      { /*
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


     

          //接收 xml数据包
          Stream xmlStream = httpContext.Request.InputStream;


          //构造xml对象
          XmlDocument xmlDocument = new XmlDocument();
          xmlDocument.Load(xmlStream);
          //获取根节点
          XmlElement rootXmlElement = xmlDocument.DocumentElement;

          //开发者微信号
           toUserName = rootXmlElement.SelectSingleNode("ToUserName").InnerText;

           fromUserName = rootXmlElement.SelectSingleNode("FromUserName").InnerText;

           createTime = rootXmlElement.SelectSingleNode("CreateTime").InnerText;


           msgType = rootXmlElement.SelectSingleNode("MsgType").InnerText;

           content = rootXmlElement.SelectSingleNode("Content").InnerText;

           msgId = rootXmlElement.SelectSingleNode("MsgId").InnerText;

         
         



          /*被动回复消息
           * <xml>
             <ToUserName><![CDATA[toUser]]></ToUserName>
             <FromUserName><![CDATA[fromUser]]></FromUserName>
             <CreateTime>12345678</CreateTime>
             <MsgType><![CDATA[text]]></MsgType>
             <Content><![CDATA[你好]]></Content>
             </xml>
           */
//          string access_token = "暂未获取access_token";
//          if (content == "票据")
//          {
//              access_token = new WX_Tools.get_access_token().Get_access_token();

//          }
          
//          string replyXmlMsg = string.Format(@"<xml><ToUserName><![CDATA[{0}]]></ToUserName><FromUserName><![CDATA[{1}]]></FromUserName>
//                                           <CreateTime>{2}</CreateTime><MsgType><![CDATA[text]]></MsgType><Content><![CDATA[{3}{4}{5}{6}-access_token为：{7}]]></Content></xml>", fromUserName, toUserName, GetCreateTime(), "十分感谢-", fromUserName, "-来光临我的公众号.时间戳为：", GetCreateTime(), access_token);

//          httpContext.Response.Write(replyXmlMsg);
           Reply(content);

      }


      private void Reply(string contentStr)
        {
          switch (contentStr)
          {
              case "1":
                  getAccessToken();
                  break;
              case "2":
                 getServerIPString();
                  break;
              default:
                  DefaultReply();
                  break;


          }
            
        }

      /// <summary>
      /// 默认回复 
      /// </summary>
        private void DefaultReply()
        {
         
            string defaultReplyXmlMsg = string.Format(@"<xml><ToUserName><![CDATA[{0}]]></ToUserName><FromUserName><![CDATA[{1}]]></FromUserName>
                                           <CreateTime>{2}</CreateTime><MsgType><![CDATA[text]]></MsgType><Content><![CDATA[{3}]]></Content></xml>", fromUserName, toUserName, GetCreateTime(), "回复指南\r1.查看access_token\r2.查看服务器IP\r请回复对应数字来查询");

            httpContext.Response.Write(defaultReplyXmlMsg);
        }


      /// <summary>
      /// 回复获取的access_token
      /// </summary>
        private void getAccessToken()
        {
            string access_token = new get_access_token().Get_access_token();
            string getAccessTokenReplyXmlMsg = string.Format(@"<xml><ToUserName><![CDATA[{0}]]></ToUserName><FromUserName><![CDATA[{1}]]></FromUserName>
                                           <CreateTime>{2}</CreateTime><MsgType><![CDATA[text]]></MsgType><Content><![CDATA[{3}{4}]]></Content></xml>", fromUserName, toUserName, GetCreateTime(), "本次获取的access_token为：",access_token);

            httpContext.Response.Write(getAccessTokenReplyXmlMsg);
        }


      /// <summary>
      /// 回复获取到的服务器IP地址
      /// </summary>
        private void getServerIPString()
        {

            string serverIP = new getcallbackip().getServerIPString();
            string getServerIPReplyXmlMsg = string.Format(@"<xml><ToUserName><![CDATA[{0}]]></ToUserName><FromUserName><![CDATA[{1}]]></FromUserName>
                                           <CreateTime>{2}</CreateTime><MsgType><![CDATA[text]]></MsgType><Content><![CDATA[{3}{4}]]></Content></xml>", fromUserName, toUserName, GetCreateTime(), "本次获取的服务器IP地址为：", serverIP);

            httpContext.Response.Write(getServerIPReplyXmlMsg);
        }



      /// <summary>
      /// 取得时间戳  格林威治时间  1970,1,1,00:00开始到当前时间的秒数
      /// 中国是  1790,1,1,08:00
      /// </summary>
      /// <returns></returns>
      private int GetCreateTime()
      {
          DateTime dateTime = new DateTime(1970, 1, 1, 8, 0, 0);
          return (int)(DateTime.Now - dateTime).TotalSeconds;


      }






    }


}
