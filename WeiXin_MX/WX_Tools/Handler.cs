using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Xml;
using Newtonsoft.Json.Linq;
using WX_Tools.Entites;

namespace WX_Tools
{
    /// <summary>
    /// 处理通过POST方式提交过来的请求
    /// </summary>
  public  class Handler
    {

        //开发者微信号
       string toUserName, fromUserName, createTime, msgType, content, msgId,subscribeEvent;
       HttpContext _httpContext = HttpContext.Current;
      sender reciveSender=new sender();

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
             

              //开发者微信号
              toUserName = rootXmlElement.SelectSingleNode("ToUserName").InnerText;

              fromUserName = rootXmlElement.SelectSingleNode("FromUserName").InnerText;

              createTime = rootXmlElement.SelectSingleNode("CreateTime").InnerText;

              reciveSender.toUserName = fromUserName;
              reciveSender.fromUserName = toUserName;
              reciveSender.createTime = new getCreateTime().GetCreateTime();



              msgType = rootXmlElement.SelectSingleNode("MsgType").InnerText;
            
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
                  subscribeEvent = rootXmlElement.SelectSingleNode("Event").InnerText;
                
                  if (subscribeEvent.ToLower().Equals(AllEnum.EventEnum.subscribe.ToString()))
                  {
                      Reply("关注");
                  }
              }

          }
          else
          {
              _httpContext.Response.Write("");
              _httpContext.Response.End();
          }



           Reply(content);

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
              case "menu1_1":
              case "menu1_2":
              case "menu1_3":
              case "menu2_1":
              case "menu2_2":
              case "menu2_3":
              case "menu3_1":
              case "menu3_2":
              case "menu3_3":
                  CreateCustomeMenu();
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
                                           <CreateTime>{2}</CreateTime><MsgType><![CDATA[text]]></MsgType><Content><![CDATA[{3}]]></Content></xml>", fromUserName, toUserName,new getCreateTime().GetCreateTime(), "回复指南\r\n1.查看access_token\r\n2.查看服务器IP\r\n更多功能敬请期待\n请回复对应文字来查询");

              _httpContext.Response.Write(defaultReplyXmlMsg);


              

          }
          catch (Exception e)
          {
             
              _httpContext.Response.Write(e.Message);
          }
           
            _httpContext.ApplicationInstance.CompleteRequest();
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
         
              new replyTemplate(reciveSender).ReplyText(access_token);

            
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
          new replyTemplate(reciveSender).ReplyText(serverIP);
        }



    


      /// <summary>
      /// 创建菜单
      /// </summary>
        public void CreateCustomeMenu()
        {
            StringBuilder postDataStringBuilder=new StringBuilder();
            postDataStringBuilder.Append("{");
            postDataStringBuilder.Append("\"button\":");
            postDataStringBuilder.Append("[");

            postDataStringBuilder.Append("{");
            postDataStringBuilder.Append("\"name\":\"菜单一\",\"sub_button\":");
            postDataStringBuilder.Append("[");

            postDataStringBuilder.Append("{");
                postDataStringBuilder.AppendFormat("\"type\":\"{0}\",\"name\":\"菜单一一\",\"key\":\"menu1_1\"",AllEnum.CustomerMenuButtonEvent.click.ToString());
            postDataStringBuilder.Append("},");
            postDataStringBuilder.Append("{");
                postDataStringBuilder.AppendFormat("\"type\":\"{0}\",\"name\":\"菜单一二\",\"key\":\"menu1_2\"", AllEnum.CustomerMenuButtonEvent.click.ToString());
            postDataStringBuilder.Append("},");
            postDataStringBuilder.Append("{");
                postDataStringBuilder.AppendFormat("\"type\":\"{0}\",\"name\":\"菜单一三\",\"key\":\"menu1_3\"", AllEnum.CustomerMenuButtonEvent.click.ToString());
            postDataStringBuilder.Append("}");


            postDataStringBuilder.Append("]");
            postDataStringBuilder.Append("},");


            postDataStringBuilder.Append("{");
            postDataStringBuilder.Append("\"name\":\"菜单二\",\"sub_button\":");
            postDataStringBuilder.Append("[");

            postDataStringBuilder.Append("{");
            postDataStringBuilder.AppendFormat("\"type\":\"{0}\",\"name\":\"菜单二一\",\"key\":\"menu2_1\"", AllEnum.CustomerMenuButtonEvent.click.ToString());
            postDataStringBuilder.Append("},");
            postDataStringBuilder.Append("{");
            postDataStringBuilder.AppendFormat("\"type\":\"{0}\",\"name\":\"菜单二二\",\"key\":\"menu2_2\"", AllEnum.CustomerMenuButtonEvent.click.ToString());
            postDataStringBuilder.Append("},");
            postDataStringBuilder.Append("{");
            postDataStringBuilder.AppendFormat("\"type\":\"{0}\",\"name\":\"菜单二三\",\"key\":\"menu2_3\"", AllEnum.CustomerMenuButtonEvent.click.ToString());
            postDataStringBuilder.Append("}");


            postDataStringBuilder.Append("]");
            postDataStringBuilder.Append("},");


            postDataStringBuilder.Append("{");
            postDataStringBuilder.Append("\"name\":\"菜单三\",\"sub_button\":");
            postDataStringBuilder.Append("[");

            postDataStringBuilder.Append("{");
            postDataStringBuilder.AppendFormat("\"type\":\"{0}\",\"name\":\"菜单三一\",\"key\":\"menu3_1\"", AllEnum.CustomerMenuButtonEvent.click.ToString());
            postDataStringBuilder.Append("},");
            postDataStringBuilder.Append("{");
            postDataStringBuilder.AppendFormat("\"type\":\"{0}\",\"name\":\"菜单三二\",\"key\":\"menu3_2\"", AllEnum.CustomerMenuButtonEvent.click.ToString());
            postDataStringBuilder.Append("},");
            postDataStringBuilder.Append("{");
            postDataStringBuilder.AppendFormat("\"type\":\"{0}\",\"name\":\"菜单三三\",\"key\":\"menu3_3\"", AllEnum.CustomerMenuButtonEvent.click.ToString());
            postDataStringBuilder.Append("}");


            postDataStringBuilder.Append("]");
            postDataStringBuilder.Append("}");

            postDataStringBuilder.Append("]");
            postDataStringBuilder.Append("}");

            byte[] postBytes =System.Text.Encoding.UTF8.GetBytes(postDataStringBuilder.ToString());
          //string postBytes = postDataStringBuilder.ToString();
            string access_token = new get_access_token().Get_access_token();
            string createMenuUrl = string.Format(new apiAddress().CreateMenu, access_token);

            WebRequest webRequest = (HttpWebRequest) WebRequest.Create(createMenuUrl);
            
                webRequest.Method = "POST";
                webRequest.ContentType = "application/x-www-form-urlencoded;";
                webRequest.ContentLength = postBytes.Length;

                Stream streamWrite = webRequest.GetRequestStream();
            streamWrite.Write(postBytes, 0, postBytes.Length);
             streamWrite.Close();


                HttpWebResponse httpWebResponse = (HttpWebResponse)webRequest.GetResponse();
          Stream streamRead = httpWebResponse.GetResponseStream();
          if (streamRead != null)
          {
              StreamReader streamReader=new StreamReader(streamRead,Encoding.UTF8);
              string result = streamReader.ReadToEnd();
              streamReader.Close();
              streamRead.Close();
              JObject jObject = JObject.Parse(result);
              string resultXmlMsg = string.Format(@"<xml><ToUserName><![CDATA[{0}]]></ToUserName>
                                                              <FromUserName><![CDATA[{1}]]></FromUserName>
                                                              <CreateTime>{2}</CreateTime>
                                                              <MsgType><![CDATA[text]]></MsgType>
                                                              <Content><![CDATA[{3}{4}]]></Content>
                                                            </xml>", fromUserName, toUserName, new getCreateTime().GetCreateTime(), "创建菜单结果：", jObject["errmsg"]);

              _httpContext.Response.Write(resultXmlMsg);

              _httpContext.ApplicationInstance.CompleteRequest();
          }

   

        }



      /// <summary>
      /// 回复按钮名称
      /// </summary>
        public void ReplyMenuName()
        {
            string menuButtonName = string.Format(@"<xml><ToUserName><![CDATA[{0}]]></ToUserName>
                                                              <FromUserName><![CDATA[{1}]]></FromUserName>
                                                              <CreateTime>{2}</CreateTime>
                                                              <MsgType><![CDATA[text]]></MsgType>
                                                              <Content><![CDATA[{3}{4}]]></Content>
                                                            </xml>", fromUserName, toUserName, new getCreateTime().GetCreateTime(), "你好，我是按钮：", content);

            _httpContext.Response.Write(menuButtonName);
            // _httpContext.Response.End();
            _httpContext.ApplicationInstance.CompleteRequest();
        }






    }


}
