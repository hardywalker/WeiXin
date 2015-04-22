using System;
using System.IO;
using System.Web;
using System.Xml;
using WeiXin_Web.Common;
using WX_Tools;
using WX_Tools.Entites;

namespace WeiXin_Web
{
    /// <summary>
    /// WXCheck 的摘要说明
    /// </summary>
    public class WxCheck : IHttpHandler
    {
     public readonly Log _log=new Log()
       {
           LogTxtPhyPath =  "/ErrorTXT/"
       };
     private WeiXinConfiguration _weiXinConfiguration = new WeiXinConfiguration();
        readonly CommonClass _commonClass=new CommonClass();
        public void ProcessRequest(HttpContext context)
        {

            //验证口令
            string token = _commonClass.GetConfiguration().Token;

            context.Response.ContentType = "text/plain";
            

            if (context.Request.HttpMethod.ToLower().Equals("get"))
            {
               
                //校验
                if (new Check().ValidateUrl(token))
                {
                    _debugLog.BugWriteTxt(_log.LogTxtPhyPath, "验证成功：" + context.Request["echostr"].ToString());
                    //校验正确，输出随机字符串
                    context.Response.Write(context.Request["echostr"].ToString());
                }     
            }
            else
            {
              
                if (!new Check().ValidateUrl(token))
                {
                    _debugLog.BugWriteTxt(_log.LogTxtPhyPath, "参数错误：" + context.Request["echostr"].ToString());
                    context.Response.Write("参数错误");
                    return;
                }
          

                try
                {
                    //获取配置信息
                    _weiXinConfiguration = _commonClass.GetConfiguration();
                  
                    
                    
                    //接收并响应
                   // new Handler().ExecHandler(_appidSecret);
                    ExecHandler(_weiXinConfiguration);
                }
                catch (Exception ex)
                {
                    new DebugLog().BugWriteTxt(_log.LogTxtPhyPath,"WXCheck.ashx页面异常："+ex.ToString());
                }
               

            }

        }



        //开发者微信号
        string _toUserName,//接收者
            _fromUserName,//发送者 
            _msgType,//消息类型
            _content,//内容
            _menuEvent;//按钮事件

        readonly HttpContext _httpContext = HttpContext.Current;
        
        //
        readonly Sender _reciveSender = new Sender();
        //写入日志功能
        readonly DebugLog _debugLog = new DebugLog();
        ReplyTemplate _replyTemplate;


        /// <summary>
        /// 开始处理微信请求
        /// </summary>
        /// <param name="appidSecret"></param>
        private void ExecHandler(WeiXinConfiguration weiXinConfiguration)
        {
            #region 接收普通消息

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

                 #region 小视频消息
            /*
                  *   小视频消息
                
                <xml>
                <ToUserName><![CDATA[toUser]]></ToUserName>
                <FromUserName><![CDATA[fromUser]]></FromUserName>
                <CreateTime>1357290913</CreateTime>
                <MsgType><![CDATA[shortvideo]]></MsgType>
                <MediaId><![CDATA[media_id]]></MediaId>
                <ThumbMediaId><![CDATA[thumb_media_id]]></ThumbMediaId>
                <MsgId>1234567890123456</MsgId>
                </xml>
                
                参数 	描述
                ToUserName 	开发者微信号
                FromUserName 	发送方帐号（一个OpenID）
                CreateTime 	消息创建时间 （整型）
                MsgType 	小视频为shortvideo
                MediaId 	视频消息媒体id，可以调用多媒体文件下载接口拉取数据。
                ThumbMediaId 	视频消息缩略图的媒体id，可以调用多媒体文件下载接口拉取数据。
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


            #endregion


            #region 接收事件推送

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

            #region 扫描带参数二维码事件

            /*
           * 用户扫描带场景值二维码时，可能推送以下两种事件：

                        如果用户还未关注公众号，则用户可以关注公众号，关注后微信会将带场景值关注事件推送给开发者。
                        如果用户已经关注公众号，则微信会将带场景值扫描事件推送给开发者。 
                    
                    1. 用户未关注时，进行关注后的事件推送
                    
                    推送XML数据包示例：
                    
                    <xml><ToUserName><![CDATA[toUser]]></ToUserName>
                    <FromUserName><![CDATA[FromUser]]></FromUserName>
                    <CreateTime>123456789</CreateTime>
                    <MsgType><![CDATA[event]]></MsgType>
                    <Event><![CDATA[subscribe]]></Event>
                    <EventKey><![CDATA[qrscene_123123]]></EventKey>
                    <Ticket><![CDATA[TICKET]]></Ticket>
                    </xml>
                    
                    参数说明：
                    参数 	描述
                    ToUserName 	开发者微信号
                    FromUserName 	发送方帐号（一个OpenID）
                    CreateTime 	消息创建时间 （整型）
                    MsgType 	消息类型，event
                    Event 	事件类型，subscribe
                    EventKey 	事件KEY值，qrscene_为前缀，后面为二维码的参数值
                    Ticket 	二维码的ticket，可用来换取二维码图片
                    
                    2. 用户已关注时的事件推送
                    
                    推送XML数据包示例：
                    
                    <xml>
                    <ToUserName><![CDATA[toUser]]></ToUserName>
                    <FromUserName><![CDATA[FromUser]]></FromUserName>
                    <CreateTime>123456789</CreateTime>
                    <MsgType><![CDATA[event]]></MsgType>
                    <Event><![CDATA[SCAN]]></Event>
                    <EventKey><![CDATA[SCENE_VALUE]]></EventKey>
                    <Ticket><![CDATA[TICKET]]></Ticket>
                    </xml>
                    
                    参数说明：
                    参数 	描述
                    ToUserName 	开发者微信号
                    FromUserName 	发送方帐号（一个OpenID）
                    CreateTime 	消息创建时间 （整型）
                    MsgType 	消息类型，event
                    Event 	事件类型，SCAN
                    EventKey 	事件KEY值，是一个32位无符号整数，即创建二维码时的二维码scene_id
                    Ticket 	二维码的ticket，可用来换取二维码图片 
           */

            #endregion

            #region 上报地理位置事件

            /**
             * 用户同意上报地理位置后，每次进入公众号会话时，都会在进入时上报地理位置，或在进入会话后每5秒上报一次地理位置，公众号可以在公众平台网站中修改以上设置。上报地理位置时，微信会将上报地理位置事件推送到开发者填写的URL。

                    推送XML数据包示例：
                    
                    <xml>
                    <ToUserName><![CDATA[toUser]]></ToUserName>
                    <FromUserName><![CDATA[fromUser]]></FromUserName>
                    <CreateTime>123456789</CreateTime>
                    <MsgType><![CDATA[event]]></MsgType>
                    <Event><![CDATA[LOCATION]]></Event>
                    <Latitude>23.137466</Latitude>
                    <Longitude>113.352425</Longitude>
                    <Precision>119.385040</Precision>
                    </xml>
                    
                    参数说明：
                    参数 	描述
                    ToUserName 	开发者微信号
                    FromUserName 	发送方帐号（一个OpenID）
                    CreateTime 	消息创建时间 （整型）
                    MsgType 	消息类型，event
                    Event 	事件类型，LOCATION
                    Latitude 	地理位置纬度
                    Longitude 	地理位置经度
                    Precision 	地理位置精度 
             */

            #endregion


            #region  点击菜单拉取消息时的事件推送

            /**
             * 推送XML数据包示例：

                    <xml>
                    <ToUserName><![CDATA[toUser]]></ToUserName>
                    <FromUserName><![CDATA[FromUser]]></FromUserName>
                    <CreateTime>123456789</CreateTime>
                    <MsgType><![CDATA[event]]></MsgType>
                    <Event><![CDATA[CLICK]]></Event>
                    <EventKey><![CDATA[EVENTKEY]]></EventKey>
                    </xml>
                    
                    参数说明：
                    参数 	描述
                    ToUserName 	开发者微信号
                    FromUserName 	发送方帐号（一个OpenID）
                    CreateTime 	消息创建时间 （整型）
                    MsgType 	消息类型，event
                    Event 	事件类型，CLICK
                    EventKey 	事件KEY值，与自定义菜单接口中KEY值对应 
             */
            #endregion

            #region 点击菜单跳转链接时的事件推送
            /**
             * 推送XML数据包示例：

                    <xml>
                    <ToUserName><![CDATA[toUser]]></ToUserName>
                    <FromUserName><![CDATA[FromUser]]></FromUserName>
                    <CreateTime>123456789</CreateTime>
                    <MsgType><![CDATA[event]]></MsgType>
                    <Event><![CDATA[VIEW]]></Event>
                    <EventKey><![CDATA[www.qq.com]]></EventKey>
                    </xml>
                    
                    参数说明：
                    参数 	描述
                    ToUserName 	开发者微信号
                    FromUserName 	发送方帐号（一个OpenID）
                    CreateTime 	消息创建时间 （整型）
                    MsgType 	消息类型，event
                    Event 	事件类型，VIEW
                    EventKey 	事件KEY值，设置的跳转URL 
             */
            #endregion

            #endregion


            //接收 xml数据包
            Stream xmlStream = _httpContext.Request.InputStream;

            //构造xml对象
            XmlDocument xmlDocument = new XmlDocument();
            xmlDocument.Load(xmlStream);

            //获取的xml完整文本
            _debugLog.BugWriteTxt(_log.LogTxtPhyPath,"这是入口：" + xmlDocument.OuterXml);

            //获取根节点
            XmlElement rootXmlElement = xmlDocument.DocumentElement;

            if (rootXmlElement != null)
            {

                //开发者微信号
                _toUserName = rootXmlElement.SelectSingleNode("ToUserName").InnerText;

                _fromUserName = rootXmlElement.SelectSingleNode("FromUserName").InnerText;



                _reciveSender.ToUserName = _fromUserName;
                _reciveSender.FromUserName = _toUserName;
                _reciveSender.CreateTime = new GetCreateTime().CreateTime();

                _replyTemplate = new ReplyTemplate(_reciveSender);


                //获取消息类型  转化为小写，方便与全局枚举类对比
                _msgType = rootXmlElement.SelectSingleNode("MsgType").InnerText.ToLower();


                //推送过来文本消息  全部转化为小写来比较
                if (_msgType.Equals(AllEnum.MsgTypeEnum.text.ToString()))
                {
                    //写入日志
                    _debugLog.BugWriteTxt(_log.LogTxtPhyPath,"这是一条文本消息：" + rootXmlElement.OuterXml);
                    
                    //推送过来的内容
                    _content = rootXmlElement.SelectSingleNode("Content").InnerText;
                   
                    //回复内容
                    Reply(weiXinConfiguration, _content);

                }
                else if (_msgType.Equals(AllEnum.MsgTypeEnum.link.ToString()))
                {
                    _debugLog.BugWriteTxt(_log.LogTxtPhyPath, "这是一条链接消息：" + rootXmlElement.OuterXml);
                }
                else if (_msgType.Equals(AllEnum.MsgTypeEnum.image.ToString()))
                {
                    _debugLog.BugWriteTxt(_log.LogTxtPhyPath, "这是一条图片消息：" + rootXmlElement.OuterXml);
                }
                else if (_msgType.Equals(AllEnum.MsgTypeEnum.location.ToString()))
                {
                    _debugLog.BugWriteTxt(_log.LogTxtPhyPath, "这是一条地理位置消息：" + rootXmlElement.OuterXml);
                }
                else if (_msgType.Equals(AllEnum.MsgTypeEnum.voice.ToString()))
                {
                    _debugLog.BugWriteTxt(_log.LogTxtPhyPath, "这是一条语音消息：" + rootXmlElement.OuterXml);
                }
                else if (_msgType.Equals(AllEnum.MsgTypeEnum.video.ToString()))
                {
                    _debugLog.BugWriteTxt(_log.LogTxtPhyPath, "这是一条视频消息：" + rootXmlElement.OuterXml);

                }
                else if (_msgType.Equals(AllEnum.MsgTypeEnum.shortvideo.ToString()))
                {
                    _debugLog.BugWriteTxt(_log.LogTxtPhyPath, "这是一条小视频消息：" + rootXmlElement.OuterXml);
                }
                else if (_msgType.Equals("event"))//菜单按钮消息类型
                {
                    _debugLog.BugWriteTxt(_log.LogTxtPhyPath, "这是一条菜单事件消息：" + rootXmlElement.OuterXml);

                    
                    //事件类型
                    _menuEvent = rootXmlElement.SelectSingleNode("Event").InnerText.ToLower();

                    //获取点击按钮的key
                    string menuButtonKey = rootXmlElement.SelectSingleNode("EventKey").InnerText;


                    //订阅关注事件
                    if (_menuEvent.Equals(AllEnum.EventEnum.subscribe.ToString()))
                    {
                        
                    }//取消关注事件
                    else if (_menuEvent.Equals(AllEnum.EventEnum.unsubscribe.ToString()))
                    {

                    } //点击事件
                    else if (_menuEvent.Equals(AllEnum.CustomerMenuButtonEvent.click.ToString()))
                    {



                    }
                }

            }
            xmlStream.Close();


        }


        /// <summary>
        /// 根据回复来调用不同方法
        /// </summary>
        /// <param name="appidSecret"></param>
        /// <param name="contentStr"></param>
        private void Reply(WeiXinConfiguration weiXinConfiguration, string contentStr)
        {

            //switch (contentStr)
            //{
            //    case "accessToken":
            //        GetAccessToken(appidSecret);
            //        break;
            //    case "serverIP":
            //        GetServerIpString(appidSecret);
            //        break;
            //    case "myGUID":
            //        MyGuid();
            //        break;
            //    default:
            //        MenuName(contentStr);
            //        break;
            //}

            //默认回复原文
         string returnValue= _replyTemplate.ReplyText(contentStr);

         _debugLog.BugWriteTxt(_log.LogTxtPhyPath, "这是一条回复文本消息：" + returnValue);
         _httpContext.Response.Write(returnValue);

            //完成响应
             _httpContext.ApplicationInstance.CompleteRequest();


        }

        /// <summary>
        /// 默认回复 关注后
        /// </summary>
        private void DefaultReply()
        {
            try
            {

                _replyTemplate.ReplyText("微信公众平台测试号欢迎你的关注。\r\n请操作菜单来获取相应信息。");


            }
            catch (Exception e)
            {

                _debugLog.BugWriteTxt(_log.LogTxtPhyPath, "默认回复时的异常:" + e.Message + "|" + e);
            }


        }


        /// <summary>
        /// 回复菜单key
        /// </summary>
        /// <param name="menuName"></param>
        private void MenuName(string menuName)
        {
            try
            {

                _replyTemplate.ReplyText(menuName);
            }
            catch (Exception ex)
            {
                _debugLog.BugWriteTxt(_log.LogTxtPhyPath, "获取菜单名称时异常:" + ex + "|" + ex.Message);

            }
        }





        /// <summary>
        /// 回复获取到的服务器IP地址
        /// </summary>
        private void GetServerIpString(WeiXinConfiguration weiXinConfiguration)
        {
            try
            {
              //  string serverIp = new Getcallbackip().GetServerIpString(appidSecret);
              //  _replyTemplate.ReplyText(serverIp);
            }
            catch (Exception ex)
            {

                _debugLog.BugWriteTxt(_log.LogTxtPhyPath, "获取服务器IP地址时异常:" + ex + "|" + ex.Message);
            }

        }


        /// <summary>
        /// 获取当前用户的微信号
        /// </summary>
        private void MyGuid()
        {
            try
            {
                string myGuid = _fromUserName;
                _replyTemplate.ReplyText(myGuid);
            }
            catch (Exception ex)
            {
                _debugLog.BugWriteTxt(_log.LogTxtPhyPath, "获取myGuid时异常:" + ex + "|" + ex.Message);

            }
        }

        private void ReplySelf(string strMsg)
        {
            //todo:2015年4月9日17:05:35 回复功能有待完善
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