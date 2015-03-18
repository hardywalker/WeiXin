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
      {
          #region 各种消息类型

          #region 文本消息类型

          /*
             *     ToUserName 	开发者微信号
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

          #endregion

          #region 图片消息

           /*
            *  <xml>
                     <ToUserName><![CDATA[toUser]]></ToUserName>
                     <FromUserName><![CDATA[fromUser]]></FromUserName>
                     <CreateTime>1348831860</CreateTime>
                     <MsgType><![CDATA[image]]></MsgType>
                     <PicUrl><![CDATA[this is a url]]></PicUrl>
                     <MediaId><![CDATA[media_id]]></MediaId>
                     <MsgId>1234567890123456</MsgId>
                </xml>
                    
                    参数 	描述
                    ToUserName 	开发者微信号
                    FromUserName 	发送方帐号（一个OpenID）
                    CreateTime 	消息创建时间 （整型）
                    MsgType 	image
                    PicUrl 	图片链接
                    MediaId 	图片消息媒体id，可以调用多媒体文件下载接口拉取数   据。
                    MsgId 	消息id，64位整型 
           */

          #endregion

          #region 语音消息

          /*
           * <xml>
                    <ToUserName><![CDATA[toUser]]></ToUserName>
                    <FromUserName><![CDATA[fromUser]]></FromUserName>
                    <CreateTime>1357290913</CreateTime>
                    <MsgType><![CDATA[voice]]></MsgType>
                    <MediaId><![CDATA[media_id]]></MediaId>
                    <Format><![CDATA[Format]]></Format>
                    <MsgId>1234567890123456</MsgId>
             </xml>
                    
                    参数 	描述
                    ToUserName 	开发者微信号
                    FromUserName 	发送方帐号（一个OpenID）
                    CreateTime 	消息创建时间 （整型）
                    MsgType 	语音为voice
                    MediaId 	语音消息媒体id，可以调用多媒体文件下载接口拉取数   据。
                    Format 	语音格式，如amr，speex等
                    MsgID 	消息id，64位整型 
           */

          #endregion

          #region 视频消息

          /*
           * <xml>
                    <ToUserName><![CDATA[toUser]]></ToUserName>
                    <FromUserName><![CDATA[fromUser]]></FromUserName>
                    <CreateTime>1357290913</CreateTime>
                    <MsgType><![CDATA[video]]></MsgType>
                    <MediaId><![CDATA[media_id]]></MediaId>
                    <ThumbMediaId><![CDATA[thumb_media_id]]></ThumbMediaId>
                    <MsgId>1234567890123456</MsgId>
              </xml>
                    
                    参数 	描述
                    ToUserName 	开发者微信号
                    FromUserName 	发送方帐号（一个OpenID）
                    CreateTime 	消息创建时间 （整型）
                    MsgType 	视频为video
                    MediaId 	视频消息媒体id，可以调用多媒体文件下载接口拉取数   据。
                    ThumbMediaId 	视频消息缩略图的媒体id，可以调用多媒体文件下 载接   口拉 取数   据。
                    MsgId 	消息id，64位整型 
           */

          #endregion

          #region 地理位置消息

/*
           * <xml>
                    <ToUserName><![CDATA[toUser]]></ToUserName>
                    <FromUserName><![CDATA[fromUser]]></FromUserName>
                    <CreateTime>1351776360</CreateTime>
                    <MsgType><![CDATA[location]]></MsgType>
                    <Location_X>23.134521</Location_X>
                    <Location_Y>113.358803</Location_Y>
                    <Scale>20</Scale>
                    <Label><![CDATA[位置信息]]></Label>
                    <MsgId>1234567890123456</MsgId>
                    </xml> 
                    
                    参数 	描述
                    ToUserName 	开发者微信号
                    FromUserName 	发送方帐号（一个OpenID）
                    CreateTime 	消息创建时间 （整型）
                    MsgType 	location
                    Location_X 	地理位置维度
                    Location_Y 	地理位置经度
                    Scale 	地图缩放大小
                    Label 	地理位置信息
                    MsgId 	消息id，64位整型 
           */

          #endregion

          #region 链接消息

          /*
           * <xml>
                    <ToUserName><![CDATA[toUser]]></ToUserName>
                    <FromUserName><![CDATA[fromUser]]></FromUserName>
                    <CreateTime>1351776360</CreateTime>
                    <MsgType><![CDATA[link]]></MsgType>
                    <Title><![CDATA[公众平台官网链接]]></Title>
                    <Description><![CDATA[公众平台官网链接]]></Description>
                    <Url><![CDATA[url]]></Url>
                    <MsgId>1234567890123456</MsgId>
                    </xml> 
                    
                    参数 	描述
                    ToUserName 	接收方微信号
                    FromUserName 	发送方微信号，若为普通用户，则是一个OpenID
                    CreateTime 	消息创建时间
                    MsgType 	消息类型，link
                    Title 	消息标题
                    Description 	消息描述
                    Url 	消息链接
                    MsgId 	消息id，64位整型 
           */

          #endregion


          #region 关注/取消关注事件

          /*
           * <xml>
                <ToUserName><![CDATA[toUser]]></ToUserName>
                <FromUserName><![CDATA[FromUser]]></FromUserName>
                <CreateTime>123456789</CreateTime>
                <MsgType><![CDATA[event]]></MsgType>
                <Event><![CDATA[subscribe]]></Event>
                </xml>
                
                参数说明：
                参数 	描述
                ToUserName 	开发者微信号
                FromUserName 	发送方帐号（一个OpenID）
                CreateTime 	消息创建时间 （整型）
                MsgType 	消息类型，event
                Event 	事件类型，subscribe(订阅)、unsubscribe(取消订阅) 
           */

          #endregion

          #endregion





          //接收 xml数据包
          Stream xmlStream = _httpContext.Request.InputStream;
          
          //构造xml对象
          XmlDocument xmlDocument = new XmlDocument();
          xmlDocument.Load(xmlStream);
          //获取根节点
          XmlElement rootXmlElement = xmlDocument.DocumentElement;


          if (rootXmlElement != null)
          {
              msgType = rootXmlElement.SelectSingleNode("MsgType").InnerText;

              //开发者微信号
              toUserName = rootXmlElement.SelectSingleNode("ToUserName").InnerText;

              fromUserName = rootXmlElement.SelectSingleNode("FromUserName").InnerText;

              createTime = rootXmlElement.SelectSingleNode("CreateTime").InnerText;

              if (msgType.Equals(AllEnum.MsgTypeEnum.text.ToString()))
              {
                  
                  content = rootXmlElement.SelectSingleNode("Content").InnerText;

                  msgId = rootXmlElement.SelectSingleNode("MsgId").InnerText;
              }
              else if(msgType.Equals(AllEnum.MsgTypeEnum.link.ToString()))
              {

              }
              else if (msgType.Equals(AllEnum.MsgTypeEnum.image.ToString()))
              {

              }
              else if (msgType.Equals(AllEnum.MsgTypeEnum.location.ToString()))
              {

              }
              else if (msgType.Equals(AllEnum.MsgTypeEnum.voice.ToString()))
              {

              }
              else if (msgType.Equals(AllEnum.MsgTypeEnum.video.ToString()))
              {

              }
              else if (msgType.Equals("event"))
              {

              }

          }
          else
          {
              _httpContext.Response.Write("");
              _httpContext.Response.End();
          }


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

        private void getMsgType()
        {
            
        }



      /// <summary>
      /// 根据回复来调用不同方法
      /// </summary>
      /// <param name="contentStr"></param>
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
          try
          {
              string defaultReplyXmlMsg = string.Format(@"<xml><ToUserName><![CDATA[{0}]]></ToUserName><FromUserName><![CDATA[{1}]]></FromUserName>
                                           <CreateTime>{2}</CreateTime><MsgType><![CDATA[text]]></MsgType><Content><![CDATA[{3}]]></Content></xml>", fromUserName, toUserName, GetCreateTime(), "回复指南\r\n1.查看access_token\r\n2.查看服务器IP\r\n更多功能敬请期待\n请回复对应文字来查询");

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
              File.WriteAllText(_httpContext.Server.MapPath("/ErrorTXT/" + DateTime.Now.ToString("yyyy-MM-dd-HH-mm-ss") + ".txt"), "我是查询access_token时异常：" + ex.InnerException);
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
