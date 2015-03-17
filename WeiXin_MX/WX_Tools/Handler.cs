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
       HttpContext _httpContext = HttpContext.Current;

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
          Stream xmlStream = _httpContext.Request.InputStream;


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


           File.WriteAllText(_httpContext.Server.MapPath("/ErrorTXT/" + DateTime.Now.ToString("yyyy-MM-dd HH:ss") + ".txt"), toUserName + "|" + fromUserName + "|" + createTime + "|" + msgType + "|" + content + "|" + msgId);

         /*被动回复消息
           * <xml>
             <ToUserName><![CDATA[toUser]]></ToUserName>
             <FromUserName><![CDATA[fromUser]]></FromUserName>
             <CreateTime>12345678</CreateTime>
             <MsgType><![CDATA[text]]></MsgType>
             <Content><![CDATA[你好]]></Content>
             </xml>
           */

           Reply(content);

      }


      private void Reply(string contentStr)
        {
          switch (contentStr)
          {
              case "查看":
                  getAccessToken();
                  break;
              case "服务器":
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
          try
          {
              string defaultReplyXmlMsg = string.Format(@"<xml><ToUserName><![CDATA[{0}]]></ToUserName><FromUserName><![CDATA[{1}]]></FromUserName>
                                           <CreateTime>{2}</CreateTime><MsgType><![CDATA[text]]></MsgType><Content><![CDATA[{3}]]></Content></xml>", fromUserName, toUserName, GetCreateTime(), "回复指南\r\n\"查看\".查看access_token\r\n\"服务器\".查看服务器IP\r\n请回复对应文字来查询");

              _httpContext.Response.Write(defaultReplyXmlMsg);
          }
          catch (Exception e)
          {
             
              _httpContext.Response.Write(e.Message);
          }
            _httpContext.Response.End();
        }


      /// <summary>
      /// 回复获取的access_token
      /// </summary>
        private void getAccessToken()
      {
          string access_token;
          try
          {
               access_token = new get_access_token().Get_access_token();
          }
          catch (Exception ex)
          {
              File.WriteAllText(_httpContext.Server.MapPath("/ErrorTXT/" + DateTime.Now.ToString("yyyy-MM-dd HH:ss") + ".txt"), "我是查询access_token时异常：" + ex.InnerException);
              access_token = ex.Message;
          }
         

            string getAccessTokenReplyXmlMsg = string.Format(@"<xml><ToUserName><![CDATA[{0}]]></ToUserName><FromUserName><![CDATA[{1}]]></FromUserName>
                                           <CreateTime>{2}</CreateTime><MsgType><![CDATA[text]]></MsgType><Content><![CDATA[{3}{4}]]></Content></xml>", fromUserName, toUserName, GetCreateTime(), "本次获取的access_token为：",access_token);

            _httpContext.Response.Write(getAccessTokenReplyXmlMsg);
            _httpContext.Response.End();
        }


      /// <summary>
      /// 回复获取到的服务器IP地址
      /// </summary>
        private void getServerIPString()
      {

          string serverIP;
          try
          {
            serverIP=  new getcallbackip().getServerIPString();
          }
          catch (Exception ex)
          {

              serverIP = ex.Message;
          }
      
            string getServerIPReplyXmlMsg = string.Format(@"<xml><ToUserName><![CDATA[{0}]]></ToUserName><FromUserName><![CDATA[{1}]]></FromUserName>
                                           <CreateTime>{2}</CreateTime><MsgType><![CDATA[text]]></MsgType><Content><![CDATA[{3}{4}]]></Content></xml>", fromUserName, toUserName, GetCreateTime(), "本次获取的服务器IP地址为：", serverIP);

            _httpContext.Response.Write(getServerIPReplyXmlMsg);
            _httpContext.Response.End();
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
