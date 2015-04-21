using System.IO;
using System.Net;
using System.Text;

namespace WX_Tools
{
    /// <summary>
    /// 高级群发接口
    /// </summary>
  public  class MessageMass
  {
      #region 上传图文消息素材【订阅号与服务号认证后均可用】  POST 

      /// <summary>
      /// 上传图文消息素材【订阅号与服务号认证后均可用】  POST 
      /// </summary>
      /// <param name="appidSecretToken">AppidSecretToken对象</param>
      /// <param name="strJson">json字符串</param>
      /// <returns>返回json格式结果</returns>
      public string MediaUploadNews(string accesstoken, string strJson)
        {
            #region 接口调用请求说明

            /**
             * http请求方式: POST
                        https://api.weixin.qq.com/cgi-bin/media/uploadnews?access_token=ACCESS_TOKEN
                        
                        POST数据说明
                        
                        POST数据示例如下：
                        
                        {
                           "articles": [
                        		 {
                                                "thumb_media_id":"qI6_Ze_6PtV7svjolgs-rN6stStuHIjs9_DidOHaj0Q-mwvBelOXCFZiq2OsIU-p",
                                                "author":"xxx",
                        			 "title":"Happy Day",
                        			 "content_source_url":"www.qq.com",
                        			 "content":"content",
                        			 "digest":"digest",
                                                "show_cover_pic":"1"
                        		 },
                        		 {
                                                "thumb_media_id":"qI6_Ze_6PtV7svjolgs-rN6stStuHIjs9_DidOHaj0Q-mwvBelOXCFZiq2OsIU-p",
                                                "author":"xxx",
                        			 "title":"Happy Day",
                        			 "content_source_url":"www.qq.com",
                        			 "content":"content",
                        			 "digest":"digest",
                                                "show_cover_pic":"0"
                        		 }
                           ]
                        }
                        
                        参数 	是否必须 	说明
                        Articles 	是 	图文消息，一个图文消息支持1到10条图文
                        thumb_media_id 	是 	图文消息缩略图的media_id，可以在基础支持-上传多媒体文件接口中获得
                        author 	否 	图文消息的作者
                        title 	是 	图文消息的标题
                        content_source_url 	否 	在图文消息页面点击“阅读原文”后的页面
                        content 	是 	图文消息页面的内容，支持HTML标签
                        digest 	否 	图文消息的描述
                        show_cover_pic 	否 	是否显示封面，1为显示，0为不显示
                        
                        返回说明
                        
                        返回数据示例（正确时的JSON返回结果）：
                        
                        {
                           "type":"news",
                           "media_id":"CsEf3ldqkAYJAU6EJeIkStVDSvffUJ54vqbThMgplD-VJXXof6ctX5fI6-aYyUiQ",
                           "created_at":1391857799
                        }
                        
                        参数 	说明
                        type 	媒体文件类型，分别有图片（image）、语音（voice）、视频（video）和缩略图（thumb），次数为news，即图文消息
                        media_id 	媒体文件/图文消息上传后获取的唯一标识
                        created_at 	媒体文件上传时间 
             */

            #endregion

            string result = "";
            byte[] postBytes = Encoding.UTF8.GetBytes(strJson);
     
            string postUrl = string.Format(new ApiAddress().media_uploadnews, accesstoken);
            HttpWebRequest httpWebRequest = WebRequest.Create(postUrl) as HttpWebRequest;
            httpWebRequest.Method = "POST";
            httpWebRequest.ContentType = "application/x-www-form-urlencoded;";
            httpWebRequest.ContentLength = postBytes.Length;


            Stream streamWriter = httpWebRequest.GetRequestStream();
            streamWriter.Write(postBytes, 0, postBytes.Length);
      
            streamWriter.Close();

            HttpWebResponse httpWebResponse = httpWebRequest.GetResponse() as HttpWebResponse;
            Stream streamRead = httpWebResponse.GetResponseStream();
            if (streamRead != null)
            {
                StreamReader streamReader = new StreamReader(streamRead, Encoding.UTF8);
                result = streamReader.ReadToEnd();
            }
            return result;

        }

        #endregion


        #region 根据分组进行群发【订阅号与服务号认证后均可用】  POST

      /// <summary>
        /// 根据分组进行群发【订阅号与服务号认证后均可用】  POST
      /// </summary>
        /// <param name="appidSecretToken">AppidSecretToken对象</param>
      /// <param name="strJson">json字符串</param>
        /// <returns>返回json字符串</returns>
      public string MessageMassSendAll(string accesstoken, string strJson)
        {

            #region 接口调用请求说明
            /**
             * http请求方式: POST
                            https://api.weixin.qq.com/cgi-bin/message/mass/sendall?access_token=ACCESS_TOKEN
                            
                            POST数据说明
                            
                            POST数据示例如下：
                            
                            图文消息（注意图文消息的media_id需要通过上述方法来得到）：
                            
                            {
                               "filter":{
                                  "is_to_all":false
                                  "group_id":"2"
                               },
                               "mpnews":{
                                  "media_id":"123dsdajkasd231jhksad"
                               },
                                "msgtype":"mpnews"
                            }
                            
                            文本：
                            
                            {
                               "filter":{
                                  "is_to_all":false
                                  "group_id":"2"
                               },
                               "text":{
                                  "content":"CONTENT"
                               },
                                "msgtype":"text"
                            }
                            
                            语音（注意此处media_id需通过基础支持中的上传下载多媒体文件来得到）：
                            
                            {
                               "filter":{
                                  "is_to_all":false
                                  "group_id":"2"
                               },
                               "voice":{
                                  "media_id":"123dsdajkasd231jhksad"
                               },
                                "msgtype":"voice"
                            }
                            
                            图片（注意此处media_id需通过基础支持中的上传下载多媒体文件来得到）：
                            
                            {
                               "filter":{
                                  "is_to_all":false
                                  "group_id":"2"
                               },
                               "image":{
                                  "media_id":"123dsdajkasd231jhksad"
                               },
                                "msgtype":"image"
                            }
                            
                            视频
                            
                            请注意，此处视频的media_id需通过POST请求到下述接口特别地得到： https://file.api.weixin.qq.com/cgi-bin/media/uploadvideo?access_token=ACCESS_TOKEN POST数  据如    下   （此处       media_id    需通  过基础支持中的上传下载多媒体文件来得到）：
                            
                            {
                              "media_id": "rF4UdIMfYK3efUfyoddYRMU50zMiRmmt_l0kszupYh_SzrcW5Gaheq05p_lHuOTQ",
                              "title": "TITLE",
                              "description": "Description"
                            }
                            
                            返回将为
                            
                            {
                              "type":"video",
                              "media_id":"IhdaAQXuvJtGzwwc0abfXnzeezfO0NgPK6AQYShD8RQYMTtfzbLdBIQkQziv2XJc",
                              "created_at":1398848981
                            }
                            
                            然后，POST下述数据（将media_id改为上一步中得到的media_id），即可进行发送
                            
                            {
                               "filter":{
                                  "is_to_all":false
                                  "group_id":"2"
                               },
                               "mpvideo":{
                                  "media_id":"IhdaAQXuvJtGzwwc0abfXnzeezfO0NgPK6AQYShD8RQYMTtfzbLdBIQkQziv2XJc",
                               },
                                "msgtype":"mpvideo"
                            }
                            
                            
                            参数 	是否必须 	说明
                            filter 	是 	用于设定图文消息的接收者
                            is_to_all 	否 	用于设定是否向全部用户发送，值为true或false，选择true该消息群发给所有用户，选择false可根据group_id发送给指定群组的用户
                            group_id 	否 	群发到的分组的group_id，参加用户管理中用户分组接口，若is_to_all值为true，可不填写group_id
                            mpnews 	是 	用于设定即将发送的图文消息
                            media_id 	是 	用于群发的消息的media_id
                            msgtype 	是 	群发的消息类型，图文消息为mpnews，文本消息为text，语音为voice，音乐为music，图片为image，视频为video
                            title 	否 	消息的标题
                            description 	否 	消息的描述
                            thumb_media_id 	是 	视频缩略图的媒体ID
                            
                            返回说明
                            
                            返回数据示例（正确时的JSON返回结果）：
                            
                            {
                               "errcode":0,
                               "errmsg":"send job submission success",
                               "msg_id":34182
                            }
                            
                            参数 	说明
                            type 	媒体文件类型，分别有图片（image）、语音（voice）、视频（video）和缩略图（thumb），图文消息为news
                            errcode 	错误码
                            errmsg 	错误信息
                            msg_id 	消息ID
                            
                            请注意：在返回成功时，意味着群发任务提交成功，并不意味着此时群发已经结束，所以，仍有可能在后续的发送过程中出现异常情况导致用户未收到消息，如消息有时会进行审核、服务器不稳定等。此外，群发任务一般需要较长的时间才能全部发送完毕，请耐心等待。 
             */
            #endregion
            string result = "";
            byte[] postBytes = Encoding.UTF8.GetBytes(strJson);
        
            string postUrl = string.Format(new ApiAddress().message_mass_sendall, accesstoken);
            HttpWebRequest httpWebRequest = WebRequest.Create(postUrl) as HttpWebRequest;
            httpWebRequest.Method = "POST";
            httpWebRequest.ContentType = "application/x-www-form-urlencoded;";
            httpWebRequest.ContentLength = postBytes.Length;


            Stream streamWriter = httpWebRequest.GetRequestStream();
            streamWriter.Write(postBytes, 0, postBytes.Length);
       
            streamWriter.Close();

            HttpWebResponse httpWebResponse = httpWebRequest.GetResponse() as HttpWebResponse;
            Stream streamRead = httpWebResponse.GetResponseStream();
            if (streamRead != null)
            {
                StreamReader streamReader = new StreamReader(streamRead, Encoding.UTF8);
                result = streamReader.ReadToEnd();
            }
            return result;
        }

        #endregion

        #region 根据OpenID列表群发【订阅号不可用，服务号认证后可用】 POST

        /// <summary>
        /// 根据OpenID列表群发【订阅号不可用，服务号认证后可用】   POST
        /// </summary>
        /// <param name="appidSecretToken">AppidSecretToken对象</param>
        /// <param name="strJson">json字符串</param>
        /// <returns>返回json字符串</returns>
      public string MessageMassSend(string accesstoken, string strJson)
        {
            #region 接口调用请求说明
            /**
             * http请求方式: POST
                        https://api.weixin.qq.com/cgi-bin/message/mass/send?access_token=ACCESS_TOKEN
                        
                        POST数据说明
                        
                        POST数据示例如下：
                        
                        图文消息（注意图文消息的media_id需要通过上述方法来得到）：
                        
                        {
                           "touser":[
                            "OPENID1",
                            "OPENID2"
                           ],
                           "mpnews":{
                              "media_id":"123dsdajkasd231jhksad"
                           },
                            "msgtype":"mpnews"
                        }
                        
                        文本：
                        
                        {
                           "touser":[
                            "OPENID1",
                            "OPENID2"
                           ],
                            "msgtype": "text",
                            "text": { "content": "hello from boxer."}
                        }
                        
                        语音：
                        
                        {
                           "touser":[
                            "OPENID1",
                            "OPENID2"
                           ],
                           "voice":{
                              "media_id":"mLxl6paC7z2Tl-NJT64yzJve8T9c8u9K2x-Ai6Ujd4lIH9IBuF6-2r66mamn_gIT"
                           },
                            "msgtype":"voice"
                        }
                        
                        图片：
                        
                        {
                           "touser":[
                            "OPENID1",
                            "OPENID2"
                           ],
                           "image":{
                              "media_id":"BTgN0opcW3Y5zV_ZebbsD3NFKRWf6cb7OPswPi9Q83fOJHK2P67dzxn11Cp7THat"
                           },
                            "msgtype":"image"
                        }
                        
                        视频：
                        
                        请注意，此处视频的media_id需通过POST请求到下述接口特别地得到： https://file.api.weixin.qq.com/cgi-bin/media/uploadvideo?access_token=ACCESS_TOKEN POST数据如    下   （此处       media_id    需通  过基础支持中的上传下载多媒体文件来得到）：
                        
                        {
                          "media_id": "rF4UdIMfYK3efUfyoddYRMU50zMiRmmt_l0kszupYh_SzrcW5Gaheq05p_lHuOTQ",
                          "title": "TITLE",
                          "description": "Description"
                        }
                        
                        返回将为
                        
                        {
                          "type":"video",
                          "media_id":"IhdaAQXuvJtGzwwc0abfXnzeezfO0NgPK6AQYShD8RQYMTtfzbLdBIQkQziv2XJc",
                          "created_at":1398848981
                        }
                        
                        然后，POST下述数据（将media_id改为上一步中得到的media_id），即可进行发送
                        
                        {
                           "touser":[
                            "OPENID1",
                            "OPENID2"
                           ],
                           "video":{
                              "media_id":"123dsdajkasd231jhksad",
                              "title":"TITLE",
                              "description":"DESCRIPTION"
                           },
                            "msgtype":"video"
                        }
                        
                        
                        参数 	是否必须 	说明
                        touser 	是 	填写图文消息的接收者，一串OpenID列表，OpenID最少个，最多10000个
                        mpnews 	是 	用于设定即将发送的图文消息
                        media_id 	是 	用于群发的图文消息的media_id
                        msgtype 	是 	群发的消息类型，图文消息为mpnews，文本消息为text，语音为voice，音乐为music，图片为image，视频为video
                        title 	否 	消息的标题
                        description 	否 	消息的描述
                        thumb_media_id 	是 	视频缩略图的媒体ID
                        
                        返回说明
                        
                        返回数据示例（正确时的JSON返回结果）：
                        
                        {
                           "errcode":0,
                           "errmsg":"send job submission success",
                           "msg_id":34182
                        }
                        
                        参数 	说明
                        type 	媒体文件类型，分别有图片（image）、语音（voice）、视频（video）和缩略图（thumb），次数为news，即图文消息
                        errcode 	错误码
                        errmsg 	错误信息
                        msg_id 	消息ID
                        
                        请注意：在返回成功时，意味着群发任务提交成功，并不意味着此时群发已经结束，所以，仍有可能在后续的发送过程中出现异常情况导致用户未收到消息，如消息有时会进行审核、服务器不稳定等。此外，群发任务一般需要较长的时间才能全部发送完毕，请耐心等待。 
             */
            #endregion
            string result = "";
            byte[] postBytes = Encoding.UTF8.GetBytes(strJson);
       
            string postUrl = string.Format(new ApiAddress().message_mass_send, accesstoken);
            HttpWebRequest httpWebRequest = WebRequest.Create(postUrl) as HttpWebRequest;
            httpWebRequest.Method = "POST";
            httpWebRequest.ContentType = "application/x-www-form-urlencoded;";
            httpWebRequest.ContentLength = postBytes.Length;


            Stream streamWriter = httpWebRequest.GetRequestStream();
            streamWriter.Write(postBytes, 0, postBytes.Length);
   
            streamWriter.Close();

            HttpWebResponse httpWebResponse = httpWebRequest.GetResponse() as HttpWebResponse;
            Stream streamRead = httpWebResponse.GetResponseStream();
            if (streamRead != null)
            {
                StreamReader streamReader = new StreamReader(streamRead, Encoding.UTF8);
                result = streamReader.ReadToEnd();
            }
            return result;
        }

        #endregion

        #region 删除群发【订阅号与服务号认证后均可用】 POST

        /// <summary>
        /// 删除群发【订阅号与服务号认证后均可用】 POST
        /// </summary>
        /// <param name="appidSecretToken">AppidSecretToken 对象</param>
        /// <param name="strJson">json格式</param>
        /// <returns>返回json格式结果</returns>
      public string MessageMassDelete(string accesstoken, string strJson)
        {
            #region 接口调用请求说明
            /**
             * http请求方式: POST
                        https://api.weixin.qq.com/cgi-bin/message/mass/delete?access_token=ACCESS_TOKEN
                        
                        POST数据说明
                        
                        POST数据示例如下：
                        
                        {
                           "msg_id":30124
                        }
                        
                        参数 	是否必须 	说明
                        msg_id 	是 	发送出去的消息ID
                        
                        请注意，只有已经发送成功的消息才能删除删除消息只是将消息的图文详情页失效，已经收到的用户，还是能在其本地看到消息卡片。 另外，删除群发消息只能删除图文消息和  视频    消   息，其    他类  型的    消息一经发送，无法删除。
                        
                        返回说明
                        
                        返回数据示例（正确时的JSON返回结果）：
                        
                        {
                           "errcode":0,
                           "errmsg":"ok"
                        }
                        
                        参数 	说明
                        errcode 	错误码
                        errmsg 	错误信息 
             */
            #endregion

            string result = "";
            byte[] postBytes = Encoding.UTF8.GetBytes(strJson);
     
            string postUrl = string.Format(new ApiAddress().message_mass_delete, accesstoken);
            HttpWebRequest httpWebRequest = WebRequest.Create(postUrl) as HttpWebRequest;
            httpWebRequest.Method = "POST";
            httpWebRequest.ContentType = "application/x-www-form-urlencoded;";
            httpWebRequest.ContentLength = postBytes.Length;


            Stream streamWriter = httpWebRequest.GetRequestStream();
            streamWriter.Write(postBytes, 0, postBytes.Length);
      
            streamWriter.Close();

            HttpWebResponse httpWebResponse = httpWebRequest.GetResponse() as HttpWebResponse;
            Stream streamRead = httpWebResponse.GetResponseStream();
            if (streamRead != null)
            {
                StreamReader streamReader = new StreamReader(streamRead, Encoding.UTF8);
                result = streamReader.ReadToEnd();
            }
            return result;
        }

        #endregion



        #region 预览接口【订阅号与服务号认证后均可用】POST

        /// <summary>
        /// 预览接口【订阅号与服务号认证后均可用】  POST
        /// </summary>
        /// <param name="appidSecretToken">AppidSecretToken对象</param>
        /// <param name="strJson">json字符串</param>
        /// <returns>返回字符串</returns>
      public string MessageMassPreview(string accesstoken, string strJson)
        {

            #region 接口调用请求说明
            /**
             * 开发者可通过该接口发送消息给指定用户，在手机端查看消息的样式和排版。

                    接口调用请求说明
                    
                    http请求方式: POST
                    https://api.weixin.qq.com/cgi-bin/message/mass/preview?access_token=ACCESS_TOKEN
                    
                    POST数据说明
                    
                    POST数据示例如下：
                    
                    图文消息（其中media_id与根据分组群发中的media_id相同）：
                    
                    {
                       "touser":"OPENID", 
                       "mpnews":{              
                                "media_id":"123dsdajkasd231jhksad"               
                                 },
                       "msgtype":"mpnews" 
                    }
                    
                    文本：
                    
                    {     
                        "touser":"OPENID",
                        "text":{           
                               "content":"CONTENT"            
                               },     
                        "msgtype":"text"
                    }
                    
                    语音（其中media_id与根据分组群发中的media_id相同）：
                    
                    {
                        "touser":"OPENID",
                        "voice":{              
                                "media_id":"123dsdajkasd231jhksad"
                                },
                        "msgtype":"voice" 
                    }
                    
                    图片（其中media_id与根据分组群发中的media_id相同）：
                    
                    {
                        "touser":"OPENID",
                        "image":{      
                                "media_id":"123dsdajkasd231jhksad"
                                },
                        "msgtype":"image" 
                    }
                    
                    视频（其中media_id与根据分组群发中的media_id相同）：
                    
                    {
                        "touser":"OPENID",
                        "mpvideo":{  "media_id":"IhdaAQXuvJtGzwwc0abfXnzeezfO0NgPK6AQYShD8RQYMTtfzbLdBIQkQziv2XJc",   
                                   },
                        "msgtype":"mpvideo" 
                    }
                    
                    
                    参数 	说明
                    touser 	接收消息用户对应该公众号的openid
                    msgtype 	群发的消息类型，图文消息为mpnews，文本消息为text，语音为voice，音乐为music，图片为image，视频为video
                    media_id 	用于群发的消息的media_id
                    content 	发送文本消息时文本的内容
                    
                    返回说明
                    
                    返回数据示例（正确时的JSON返回结果）：
                    
                    {
                       "errcode":0,
                       "errmsg":"send job submission success",
                       "msg_id":34182
                    }
                    
                    参数 	说明
                    errcode 	错误码
                    errmsg 	错误信息
                    msg_id 	消息ID 
             */
            #endregion
            string result = "";
            byte[] postBytes = Encoding.UTF8.GetBytes(strJson);
      
            string postUrl = string.Format(new ApiAddress().message_mass_preview, accesstoken);
            HttpWebRequest httpWebRequest = WebRequest.Create(postUrl) as HttpWebRequest;
            httpWebRequest.Method = "POST";
            httpWebRequest.ContentType = "application/x-www-form-urlencoded;";
            httpWebRequest.ContentLength = postBytes.Length;


            Stream streamWriter = httpWebRequest.GetRequestStream();
            streamWriter.Write(postBytes, 0, postBytes.Length);
  
            streamWriter.Close();

            HttpWebResponse httpWebResponse = httpWebRequest.GetResponse() as HttpWebResponse;
            Stream streamRead = httpWebResponse.GetResponseStream();
            if (streamRead != null)
            {
                StreamReader streamReader = new StreamReader(streamRead, Encoding.UTF8);
                result = streamReader.ReadToEnd();
            }
            return result;
        }

        #endregion


        #region 查询群发消息发送状态【订阅号与服务号认证后均可用】 POST

        /// <summary>
        /// 查询群发消息发送状态【订阅号与服务号认证后均可用】 POST
        /// </summary>
        /// <param name="appidSecretToken">AppidSecretToken对象</param>
        /// <param name="strJson">json字符串</param>
        /// <returns>返回字符串</returns>
      public string MessageMassGet(string accesstoken, string strJson)
        {
            #region 接口调用请求说明
            /**
             * http请求方式: POST
                        https://api.weixin.qq.com/cgi-bin/message/mass/get?access_token=ACCESS_TOKEN
                        
                        POST数据说明
                        
                        POST数据示例如下：
                        
                        {
                           "msg_id": "201053012"
                        }
                        
                        参数 	说明
                        msg_id 	群发消息后返回的消息id
                        
                        返回说明
                        
                        返回数据示例（正确时的JSON返回结果）：
                        
                        {
                             "msg_id":201053012,
                             "msg_status":"SEND_SUCCESS"
                        }
                        
                        参数 	说明
                        msg_id 	群发消息后返回的消息id
                        msg_status 	消息发送后的状态，SEND_SUCCESS表示发送成功
                        事件推送群发结果
                        
                        由于群发任务提交后，群发任务可能在一定时间后才完成，因此，群发接口调用时，仅会给出群发任务是否提交成功的提示，若群发任务提交成功，则在群发任务结束时，会向开  发者    在公  众平    台填  写的    开发者URL（callback URL）推送事件。
                        
                        推送的XML结构如下（发送成功时）：
                        
                        <xml>
                        <ToUserName><![CDATA[gh_3e8adccde292]]></ToUserName>
                        <FromUserName><![CDATA[oR5Gjjl_eiZoUpGozMo7dbBJ362A]]></FromUserName>
                        <CreateTime>1394524295</CreateTime>
                        <MsgType><![CDATA[event]]></MsgType>
                        <Event><![CDATA[MASSSENDJOBFINISH]]></Event>
                        <MsgID>1988</MsgID>
                        <Status><![CDATA[sendsuccess]]></Status>
                        <TotalCount>100</TotalCount>
                        <FilterCount>80</FilterCount>
                        <SentCount>75</SentCount>
                        <ErrorCount>5</ErrorCount>
                        </xml>
                        
                        参数 	说明
                        ToUserName 	公众号的微信号
                        FromUserName 	公众号群发助手的微信号，为mphelper
                        CreateTime 	创建时间的时间戳
                        MsgType 	消息类型，此处为event
                        Event 	事件信息，此处为MASSSENDJOBFINISH
                        MsgID 	群发的消息ID
                        Status 	群发的结构，为“send success”或“send fail”或“err(num)”。但send success时，也有可能因用户拒收公众号的消息、系统错误等原因造成少量用户接收失败。  err   (num)  是审    核失  败的    具体原因，可能的情况如下：
                        
                        err(10001), //涉嫌广告 err(20001), //涉嫌政治 err(20004), //涉嫌社会 err(20002), //涉嫌色情 err(20006), //涉嫌违法犯罪 err(20008), //涉嫌欺诈 err(20013), //  涉嫌    版权   err        (22000), //涉嫌互推(互相宣传) err(21000), //涉嫌其他
                        TotalCount 	group_id下粉丝数；或者openid_list中的粉丝数
                        FilterCount 	过滤（过滤是指特定地区、性别的过滤、用户设置拒收的过滤，用户接收已超4条的过滤）后，准备发送的粉丝数，原则上，FilterCount = SentCount +        ErrorCount
                        SentCount 	发送成功的粉丝数
                        ErrorCount 	发送失败的粉丝数 
             */
            #endregion
            string result = "";
            byte[] postBytes = Encoding.UTF8.GetBytes(strJson);
      
            string postUrl = string.Format(new ApiAddress().message_mass_get, accesstoken);
            HttpWebRequest httpWebRequest = WebRequest.Create(postUrl) as HttpWebRequest;
            httpWebRequest.Method = "POST";
            httpWebRequest.ContentType = "application/x-www-form-urlencoded;";
            httpWebRequest.ContentLength = postBytes.Length;


            Stream streamWriter = httpWebRequest.GetRequestStream();
            streamWriter.Write(postBytes, 0, postBytes.Length);
      
            streamWriter.Close();

            HttpWebResponse httpWebResponse = httpWebRequest.GetResponse() as HttpWebResponse;
            Stream streamRead = httpWebResponse.GetResponseStream();
            if (streamRead != null)
            {
                StreamReader streamReader = new StreamReader(streamRead, Encoding.UTF8);
                result = streamReader.ReadToEnd();
            }
            return result;
        }

        #endregion






    }
}
