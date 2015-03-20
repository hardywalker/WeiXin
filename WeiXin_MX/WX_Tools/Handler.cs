using System;
using System.IO;
using System.Web;
using System.Xml;
using WX_Tools.Entites;

namespace WX_Tools
{
    /// <summary>
    /// 处理通过POST方式提交过来的请求
    /// </summary>
    public class Handler
    {

        //开发者微信号
        string _toUserName, _fromUserName, _msgType, _content, _menuEvent;
        HttpContext _httpContext = HttpContext.Current;
        Sender _reciveSender = new Sender();

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
                _toUserName = rootXmlElement.SelectSingleNode("ToUserName").InnerText;

                _fromUserName = rootXmlElement.SelectSingleNode("FromUserName").InnerText;

         

                _reciveSender.toUserName = _fromUserName;
                _reciveSender.fromUserName = _toUserName;
                _reciveSender.createTime = new GetCreateTime().CreateTime();



                _msgType = rootXmlElement.SelectSingleNode("MsgType").InnerText;
         

                //推送过来文本消息
                if (_msgType.Equals(AllEnum.MsgTypeEnum.text.ToString()))
                {
                    _content = rootXmlElement.SelectSingleNode("Content").InnerText;
                    Reply(_content);

                }
                else if (_msgType.Equals(AllEnum.MsgTypeEnum.link.ToString()))
                {

                }
                else if (_msgType.Equals(AllEnum.MsgTypeEnum.image.ToString()))
                {

                }
                else if (_msgType.Equals(AllEnum.MsgTypeEnum.location.ToString()))
                {
                   
                }
                else if (_msgType.Equals(AllEnum.MsgTypeEnum.voice.ToString()))
                {

                }
                else if (_msgType.Equals(AllEnum.MsgTypeEnum.video.ToString()))
                {

                }
                else if (_msgType.Equals("event"))//菜单按钮事件
                {
                    _menuEvent = rootXmlElement.SelectSingleNode("Event").InnerText;
                
                    if (_menuEvent.ToLower().Equals(AllEnum.EventEnum.subscribe.ToString()))
                    {
                       DefaultReply();
                    }
                    else if (_menuEvent.ToLower().Equals(AllEnum.CustomerMenuButtonEvent.click.ToString()))
                    {
                       string menuButtonKey=rootXmlElement.SelectSingleNode("EventKey").InnerText;

                      Reply(menuButtonKey);


                    }
                    else if (_menuEvent.ToLower().Equals(AllEnum.CustomerMenuButtonEvent.location_select.ToString()))
                    {
                        new DebugLog().BugWriteTxt(_menuEvent + "与" + AllEnum.CustomerMenuButtonEvent.location_select.ToString()+"相等");
                   
                        if (rootXmlElement.SelectSingleNode("EventKey").InnerText.Equals("GPS"))
                        {
                            new ReplyTemplate(_reciveSender).ReplyText(rootXmlElement.SelectSingleNode("SendLocationInfo").InnerText);
                        }
                        //StreamReader srStreamReader=new StreamReader(xmlStream);
                        
                        //new DebugLog().BugWriteTxt(srStreamReader.ReadToEnd());
                        //string myLocation = rootXmlElement.SelectSingleNode("Label").InnerText;
                        //new DebugLog().BugWriteTxt("获取地址："+myLocation);
                        //new ReplyTemplate(_reciveSender).ReplyText(myLocation);
                    }
                }
             
            }
            xmlStream.Close();
        
            
        }
        


        /// <summary>
        /// 根据回复来调用不同方法
        /// </summary>
        /// <param name="contentStr"></param>
        private void Reply(string contentStr)
        {
            switch (contentStr)
            {
                case "accessToken":
                    getAccessToken();
                    break;
                case "serverIP":
                    getServerIPString();
                    break;
                case "myGUID":
                    myGUID();
                    break;
               default:
                    MenuName(contentStr);
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

                new ReplyTemplate(_reciveSender).ReplyText("微信公众平台测试号欢迎你的关注。\r\n请操作菜单来获取相应信息。");


            }
            catch (Exception e)
            {

                new DebugLog().BugWriteTxt("默认回复时的异常:" + e.Message + "|" + e);
            }

       
        }


        private void MenuName(string menuName)
        {
            try
            {

                new ReplyTemplate(_reciveSender).ReplyText(menuName);
            }
            catch (Exception ex)
            {
                new DebugLog().BugWriteTxt("获取菜单名称时异常:" + ex + "|" + ex.Message);

            }
        }



        /// <summary>
        /// 回复获取的access_token
        /// </summary>
        private void getAccessToken()
        {
            try
            {
                string accessToken = new GetAccessToken().Get_access_token();
                new ReplyTemplate(_reciveSender).ReplyText(accessToken);
            }
            catch (Exception ex)
            {
                new DebugLog().BugWriteTxt("获取access_token时异常:" + ex + "|" + ex.Message);

            }




        }


        /// <summary>
        /// 回复获取到的服务器IP地址
        /// </summary>
        private void getServerIPString()
        {
            try
            {
                string serverIp = new Getcallbackip().getServerIPString();
                new ReplyTemplate(_reciveSender).ReplyText(serverIp);
            }
            catch (Exception ex)
            {

                new DebugLog().BugWriteTxt("获取服务器IP地址时异常:" + ex + "|" + ex.Message);
            }

        }


        /// <summary>
        /// 获取当前用户的微信号
        /// </summary>
        private void myGUID()
        {
            try
            {
                string myGuid = _fromUserName;
                new ReplyTemplate(_reciveSender).ReplyText(myGuid);
            }
            catch (Exception ex)
            {
                new DebugLog().BugWriteTxt("获取myGuid时异常:" + ex + "|" + ex.Message);

            }
        }


        
    }


}
