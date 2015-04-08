namespace WX_Tools
{
    /// <summary>
    /// 微信各接口的URL地址
    /// </summary>
    public class ApiAddress
    {
    

        #region GET方式接口

        #region 获取access_token，appid   GET

        /// <summary>
        /// 使用AppID和AppSecret调用本接口来获取access_token，appid  GET   与appsecret已经写好占位符
        /// https://api.weixin.qq.com/cgi-bin/token?grant_type=client_credential&appid=APPID&secret=APPSECRET
        /// </summary>
        public string AccessToken ="https://api.weixin.qq.com/cgi-bin/token?grant_type=client_credential&appid={0}&secret={1}";

        #endregion



        #region 获取微信服务器IP地址  GET

        /// <summary>
        /// 获取微信服务器IP地址     GET     access_token已经写好占位符，传入即可
        /// https://api.weixin.qq.com/cgi-bin/getcallbackip?access_token=ACCESS_TOKEN
        /// </summary>
        public string Getcallbackip = "https://api.weixin.qq.com/cgi-bin/getcallbackip?access_token={0}";

        #endregion



        #region 自定义菜单查询接口  GET 

        /// <summary>
        /// 自定义菜单查询接口  GET方式   需要传入access_token   占位符已写
        /// https://api.weixin.qq.com/cgi-bin/menu/get?access_token=ACCESS_TOKEN
        /// </summary>
        public string GetMenuUrl = "https://api.weixin.qq.com/cgi-bin/menu/get?access_token={0}";
        #endregion


        #region  删除当前使用的自定义菜单 GET 
        /// <summary>
        /// 删除当前使用的自定义菜单  GET  需要传入access_token  点位符已写
        /// https://api.weixin.qq.com/cgi-bin/menu/delete?access_token=ACCESS_TOKEN
        /// </summary>
        public string DeleteCustomerMenuUrl = "https://api.weixin.qq.com/cgi-bin/menu/delete?access_token={0}";
        #endregion



        #region 获取用户列表  GET 
        /// <summary>
        /// 获取用户列表  GET   需要传入access_token,next_openid(可不传)  占位符已写好 
        /// https://api.weixin.qq.com/cgi-bin/user/get?access_token=ACCESS_TOKEN&next_openid=NEXT_OPENID
        /// </summary>
        public string GetUserUrl = "https://api.weixin.qq.com/cgi-bin/user/get?access_token={0}&next_openid={1}";
        #endregion


        #region 查询所有分组  GET

        /// <summary>
        /// 查询所有分组    GET    需要传入access_token  占位符已写
        /// https://api.weixin.qq.com/cgi-bin/groups/get?access_token=ACCESS_TOKEN
        /// </summary>
        public string GetGroupsUrl = "https://api.weixin.qq.com/cgi-bin/groups/get?access_token={0}";
        #endregion


        #endregion



        #region POST方式接口

        #region 创建自定义菜单接口  POST

        /// <summary>
        /// 创建自定义菜单接口  POST方式  access_token已经写好占位符
        ///  https://api.weixin.qq.com/cgi-bin/menu/create?access_token=ACCESS_TOKEN
        /// </summary>
        public string CreateMenu = "https://api.weixin.qq.com/cgi-bin/menu/create?access_token={0}";

        #endregion


        #region 新增临时素材

        /// <summary>
        /// 新增临时素材  POST  需要传入access_token,type(image:图片，voice:语音，video:视频,thumb:缩略图)  占位符已写好
        /// https://api.weixin.qq.com/cgi-bin/media/upload?access_token=ACCESS_TOKEN&type=image
        /// </summary>
        public string MediaUpload = "https://api.weixin.qq.com/cgi-bin/media/upload?access_token={0}&type={1}";

        #endregion

        #region 上传图文消息素材【订阅号与服务号认证后均可用】  POST

        /// <summary>
        /// 上传图文消息素材【订阅号与服务号认证后均可用】   POST  需要传入access_token  占位符已写
        /// https://api.weixin.qq.com/cgi-bin/media/uploadnews?access_token=ACCESS_TOKEN
        /// </summary>
        public string MediaUploadNews = "https://api.weixin.qq.com/cgi-bin/media/uploadnews?access_token={0}";

        #endregion




        #region 高级群发接口


                #region 上传图文消息素材【订阅号与服务号认证后均可用】  POST 
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
                ///<summary>
                /// 上传图文消息素材【订阅号与服务号认证后均可用】 POST   ，需要传入access_token  ,占位符已写
                /// https://api.weixin.qq.com/cgi-bin/media/uploadnews?access_token=ACCESS_TOKEN
                /// </summary>
                public string media_uploadnews = "https://api.weixin.qq.com/cgi-bin/media/uploadnews?access_token={0}";

                #endregion


                #region 根据分组进行群发【订阅号与服务号认证后均可用】  POST

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
                /// <summary>
                /// 根据分组进行群发【订阅号与服务号认证后均可用】   POST   传入access_token即可，占位符已写
                /// https://api.weixin.qq.com/cgi-bin/message/mass/sendall?access_token=ACCESS_TOKEN
                /// </summary>
                public string message_mass_sendall = "https://api.weixin.qq.com/cgi-bin/message/mass/sendall?access_token={0}";

                #endregion

        #endregion



        #region  预览接口   POST

        /// <summary>
        /// 预览接口【订阅号与服务号认证后均可用】  POST 需要传入access_token   占位符已写
        /// https://api.weixin.qq.com/cgi-bin/message/mass/preview?access_token=ACCESS_TOKEN
        /// </summary>
        public string PreviewUrl = "https://api.weixin.qq.com/cgi-bin/message/mass/preview?access_token={0}";

        #endregion



        #region 创建分组  POST

        /// <summary>
        /// 创建分组  POST  需要传入access_token 占位符已写
        /// https://api.weixin.qq.com/cgi-bin/groups/create?access_token=ACCESS_TOKEN
        /// </summary>
        public string CreateGroupsUrl = "https://api.weixin.qq.com/cgi-bin/groups/create?access_token={0}";

        #endregion


        #region 查询用户所在分组  POST

        /// <summary>
        /// 查询用户所在分组  POST  需要传入access_token   占位符已写
        /// https://api.weixin.qq.com/cgi-bin/groups/getid?access_token=ACCESS_TOKEN
        /// </summary>
        public string GetIDGroupsUrl = "https://api.weixin.qq.com/cgi-bin/groups/getid?access_token={0}";

        #endregion


        #region 修改分组名  POST

        /// <summary>
        /// 修改分组名  POST   需要传入access_token  占位符已写
        /// https://api.weixin.qq.com/cgi-bin/groups/update?access_token=ACCESS_TOKEN
        /// </summary>
        public string UpdateGroupsUrl = "https://api.weixin.qq.com/cgi-bin/groups/update?access_token={0}";

        #endregion

     


        #region 移动用户分组  POST 
        /// <summary>
        /// 移动用户分组  POST   需要传入access_token，占位符已写好
        /// https://api.weixin.qq.com/cgi-bin/groups/members/update?access_token=ACCESS_TOKEN
        /// </summary>
        public string UpdateMembersUrl = "https://api.weixin.qq.com/cgi-bin/groups/members/update?access_token={0}";

        #endregion

        #region 批量移动用户分组  POST 
        /// <summary>
        /// 批量移动用户分组  POST    需要传入access_token  占位任已写
        /// https://api.weixin.qq.com/cgi-bin/groups/members/batchupdate?access_token=ACCESS_TOKEN
        /// </summary>
        public string BatchUpdateMembersUrl = "https://api.weixin.qq.com/cgi-bin/groups/members/batchupdate?access_token={0}";

        #endregion


        #endregion



    }
}
