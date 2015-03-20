using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using WX_Tools.Entites;

namespace WX_Tools
{
    /// <summary>
    /// 被动消息回复模板
    /// 官方文档：http://mp.weixin.qq.com/wiki/14/89b871b5466b19b3efa4ada8e577d45e.html
    /// 2015年3月19日15:30:35
    /// anyangmaxin@163.com
    /// </summary>
   public  class replyTemplate
    {
         HttpContext _httpContext = HttpContext.Current;
       static  string _toUserName, _fromUserName;
     static  int _createTime;

       /// <summary>
       /// 有参数的构造函数
       /// </summary>
     /// <param name="toUserName">必须字段，接收方帐号（收到的OpenID）</param>
     /// <param name="fromUserName">必须字段，开发者微信号</param>
        public replyTemplate(string toUserName,string fromUserName)
        {
            _toUserName = toUserName;
            _fromUserName = fromUserName;
            _createTime =new getCreateTime().GetCreateTime();
        }

       /// <summary>
       /// 回复的xml消息中的前一部分，因为此部分是一样的
       /// </summary>
        private string ReplyXmsMsgHeader =string.Format(@"<xml><ToUserName><![CDATA[{0}]]></ToUserName><FromUserName><![CDATA[{1}]]></FromUserName>
                                           <CreateTime>{2}</CreateTime><MsgType>",_toUserName,_fromUserName,_createTime);
        #region 回复文本消息

        /// <summary>
        /// 回复文本消息  MsgType:text   toUser:发送给谁的
        /// </summary>
        /// <param name="content">必须字段，回复的消息内容（换行：在content中能够换行，微信客户端就支持换行显示） </param>
        public  void ReplyText(string content)
        {
            /*回复文本消息  模板
             *  <xml>
                    <ToUserName><![CDATA[toUser]]></ToUserName>
                    <FromUserName><![CDATA[fromUser]]></FromUserName>
                    <CreateTime>12345678</CreateTime>
                    <MsgType><![CDATA[text]]></MsgType>
                    <Content><![CDATA[你好]]></Content>
                </xml>
                    
                    参数 	是否必须 	描述
                    ToUserName 	是 	接收方帐号（收到的OpenID）
                    FromUserName 	是 	开发者微信号
                    CreateTime 	是 	消息创建时间 （整型）
                    MsgType 	是 	text
                    Content 	是 	回复的消息内容（换行：在content中能够换行，微信客户端就支持换行显示） 
             */

            

            string replyTextXmlMsg = string.Format(@"{0}<![CDATA[text]]></MsgType><Content><![CDATA[{1}]]></Content></xml>", ReplyXmsMsgHeader, content);
            new DebugLog().BugWriteTxt(string.Format("回复文本消息：{0}", replyTextXmlMsg));
     

            _httpContext.Response.Write(replyTextXmlMsg);
          
            _httpContext.ApplicationInstance.CompleteRequest();

        }

        #endregion



        #region 回复图片消息

       /// <summary>
       /// 回复图片消息 media_id是必须的
       /// </summary>
       /// <param name="media_id"></param>
        public void ReplyImage(string media_id)
        {
            /*回复图片消息
             *  <xml>
                    <ToUserName><![CDATA[toUser]]></ToUserName>
                    <FromUserName><![CDATA[fromUser]]></FromUserName>
                    <CreateTime>12345678</CreateTime>
                    <MsgType><![CDATA[image]]></MsgType>
                    <Image>
                    <MediaId><![CDATA[media_id]]></MediaId>
                    </Image>
                </xml>
                    
                    参数 	是否必须 	说明
                    ToUserName 	是 	接收方帐号（收到的OpenID）
                    FromUserName 	是 	开发者微信号
                    CreateTime 	是 	消息创建时间 （整型）
                    MsgType 	是 	image
                    MediaId 	是 	通过上传多媒体文件，得到的id。 
             */

            string replyImageXmlMsg = string.Format(@"{0}<![CDATA[image]]></MsgType><Image><MediaId><![CDATA[{1}]]></MediaId>
                    </Image></xml>", ReplyXmsMsgHeader,media_id);
            new DebugLog().BugWriteTxt(string.Format("回复图片消息：{0}", replyImageXmlMsg));
       

            _httpContext.Response.Write(replyImageXmlMsg);

            _httpContext.ApplicationInstance.CompleteRequest();


        }

        #endregion

        #region 回复语音消息

       /// <summary>
       /// 回复语音消息  media_id是必须的
       /// </summary>
       /// <param name="media_id"></param>
        public void ReplyVoice(string media_id)
        {
            /*回复语音消息
             *  <xml>
                    <ToUserName><![CDATA[toUser]]></ToUserName>
                    <FromUserName><![CDATA[fromUser]]></FromUserName>
                    <CreateTime>12345678</CreateTime>
                    <MsgType><![CDATA[voice]]></MsgType>
                    <Voice>
                    <MediaId><![CDATA[media_id]]></MediaId>
                    </Voice>
                </xml>
                    
                    参数 	是否必须 	说明
                    ToUserName 	是 	接收方帐号（收到的OpenID）
                    FromUserName 	是 	开发者微信号
                    CreateTime 	是 	消息创建时间戳 （整型）
                    MsgType 	是 	语音，voice
                    MediaId 	是 	通过上传多媒体文件，得到的id 
             */

            string replyVoiceXmlMsg = string.Format(@"{0}<![CDATA[voice]]></MsgType><Voice><MediaId><![CDATA[{1}]]></MediaId>
                    </Voice></xml>", ReplyXmsMsgHeader, media_id);
            new DebugLog().BugWriteTxt(string.Format("回复语音消息：{0}", replyVoiceXmlMsg));
     

            _httpContext.Response.Write(replyVoiceXmlMsg);

            _httpContext.ApplicationInstance.CompleteRequest();
        }

        #endregion

        #region 回复视频消息

       /// <summary>
       /// 回复视频消息   
       /// </summary>
        /// <param name="media_id">必须字段，通过上传多媒体文件，得到的id</param>
        /// <param name="title">视频消息的标题</param>
        /// <param name="description">视频消息的描述</param>
        public void ReplyVideo(string media_id,string title="",string description="")
        {
            /*回复视频消息
             *  <xml>
                        <ToUserName><![CDATA[toUser]]></ToUserName>
                        <FromUserName><![CDATA[fromUser]]></FromUserName>
                        <CreateTime>12345678</CreateTime>
                        <MsgType><![CDATA[video]]></MsgType>
                        <Video>
                        <MediaId><![CDATA[media_id]]></MediaId>
                        <Title><![CDATA[title]]></Title>
                        <Description><![CDATA[description]]></Description>
                        </Video> 
                </xml>
                        
                        参数 	是否必须 	说明
                        ToUserName 	是 	接收方帐号（收到的OpenID）
                        FromUserName 	是 	开发者微信号
                        CreateTime 	是 	消息创建时间 （整型）
                        MsgType 	是 	video
                        MediaId 	是 	通过上传多媒体文件，得到的id
                        Title 	否 	视频消息的标题
                        Description 	否 	视频消息的描述 
             */

            string replyVideoXmlMsg = string.Format(@"{0}<![CDATA[video]]></MsgType><Video><MediaId><![CDATA[{1}]]></MediaId>
                          <Title><![CDATA[{2}]]></Title><Description><![CDATA[{3}]]></Description>
                    </Video></xml>",ReplyXmsMsgHeader, media_id,title,description);
            new DebugLog().BugWriteTxt(string.Format("回复视频消息：{0}", replyVideoXmlMsg));
         

            _httpContext.Response.Write(replyVideoXmlMsg);

            _httpContext.ApplicationInstance.CompleteRequest();


        }

        #endregion



        #region 回复音乐消息

       /// <summary>
       /// 回复音乐消息  thumbMediaId是必须的
       /// </summary>
        /// <param name="thumbMediaId">必须字段，缩略图的媒体id，通过上传多媒体文件，得到的id </param>
        /// <param name="title">音乐标题</param>
        /// <param name="description">音乐描述</param>
        /// <param name="musicUrl">音乐链接</param>
        /// <param name="HQmusicUrl">高质量音乐链接，WIFI环境优先使用该链接播放音乐</param>
        public void ReplyMusic(string thumbMediaId, string title = "",string description = "",string musicUrl="",string HQmusicUrl="")
        {
            /*回复音乐消息
             *  <xml>
                        <ToUserName><![CDATA[toUser]]></ToUserName>
                        <FromUserName><![CDATA[fromUser]]></FromUserName>
                        <CreateTime>12345678</CreateTime>
                        <MsgType><![CDATA[music]]></MsgType>
                        <Music>
                        <Title><![CDATA[TITLE]]></Title>
                        <Description><![CDATA[DESCRIPTION]]></Description>
                        <MusicUrl><![CDATA[MUSIC_Url]]></MusicUrl>
                        <HQMusicUrl><![CDATA[HQ_MUSIC_Url]]></HQMusicUrl>
                        <ThumbMediaId><![CDATA[media_id]]></ThumbMediaId>
                        </Music>
                </xml>
                        
                        参数 	是否必须 	说明
                        ToUserName 	是 	接收方帐号（收到的OpenID）
                        FromUserName 	是 	开发者微信号
                        CreateTime 	是 	消息创建时间 （整型）
                        MsgType 	是 	music
                        Title 	否 	音乐标题
                        Description 	否 	音乐描述
                        MusicURL 	否 	音乐链接
                        HQMusicUrl 	否 	高质量音乐链接，WIFI环境优先使用该链接播放音乐
                        ThumbMediaId 	是 	缩略图的媒体id，通过上传多媒体文件，得到的id 
             */
            string replyMusicXmlMsg =
                string.Format(@"{0}<![CDATA[music]]></MsgType><Music><Title><![CDATA[{1}]]></Title>
                        <Description><![CDATA[{2}]]></Description><MusicUrl><![CDATA[{3}]]></MusicUrl>
                        <HQMusicUrl><![CDATA[{4}]]></HQMusicUrl><ThumbMediaId><![CDATA[{5}]]></ThumbMediaId>
                    </Music></xml>", ReplyXmsMsgHeader, title, description, musicUrl, HQmusicUrl, thumbMediaId);

          new DebugLog().BugWriteTxt(string.Format("回复音乐消息：{0}",replyMusicXmlMsg));

     

            _httpContext.Response.Write(replyMusicXmlMsg);

            _httpContext.ApplicationInstance.CompleteRequest();
        }

        #endregion


        #region 回复图文消息

       /// <summary>
       /// 回复图文消息  传入泛型
       /// </summary>
       /// <param name="newsList">文章列表（泛型）最多10 条</param>
        public void ReplyNews(List<Entites.news> newsList)
        {
            /*回复图文消息
             *  <xml>
                        <ToUserName><![CDATA[toUser]]></ToUserName>
                        <FromUserName><![CDATA[fromUser]]></FromUserName>
                        <CreateTime>12345678</CreateTime>
                        <MsgType><![CDATA[news]]></MsgType>
                        <ArticleCount>2</ArticleCount>
                        <Articles>
                             <item>
                             <Title><![CDATA[title1]]></Title> 
                             <Description><![CDATA[description1]]></Description>
                             <PicUrl><![CDATA[picurl]]></PicUrl>
                             <Url><![CDATA[url]]></Url>
                             </item>
             * 
                             <item>
                             <Title><![CDATA[title]]></Title>
                             <Description><![CDATA[description]]></Description>
                             <PicUrl><![CDATA[picurl]]></PicUrl>
                             <Url><![CDATA[url]]></Url>
                             </item>
                        </Articles>
                </xml> 
                        
                        参数 	是否必须 	说明
                        ToUserName 	是 	接收方帐号（收到的OpenID）
                        FromUserName 	是 	开发者微信号
                        CreateTime 	是 	消息创建时间 （整型）
                        MsgType 	是 	news
                        ArticleCount 	是 	图文消息个数，限制为10条以内
                        Articles 	是 	多条图文消息信息，默认第一个item为大图,注意，如果图文数超过10，则将会无响应
                        Title 	否 	图文消息标题
                        Description 	否 	图文消息描述
                        PicUrl 	否 	图片链接，支持JPG、PNG格式，较好的效果为大图360*200，小图200*200
                        Url 	否 	点击图文消息跳转链接 
             */
            StringBuilder newsItems=new StringBuilder();
            foreach (news newsItem in newsList)
            {
              newsItems.AppendFormat(@"<item><Title><![CDATA[{0}]]></Title>
                             <Description><![CDATA[{1}]]></Description>
                             <PicUrl><![{2}]]></PicUrl>
                             <Url><![CDATA[{3}]]></Url>
                             </item>",newsItem.Title,newsItem.Description,newsItem.PicUrl,newsItem.Url);
            }

            string replyNewsXmlMsg =
             string.Format(@"{0}<![CDATA[news]]></MsgType><ArticleCount>{1}</ArticleCount>
                        <Articles>{2}</Articles></xml>",ReplyXmsMsgHeader,newsList.Count,newsItems.ToString());

            new DebugLog().BugWriteTxt(string.Format("回复图文消息：{0}", replyNewsXmlMsg));
        

            _httpContext.Response.Write(replyNewsXmlMsg);

            _httpContext.ApplicationInstance.CompleteRequest();
        }

        #endregion

    }
}
