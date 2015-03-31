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
        /// 使用AppID和AppSecret调用本接口来获取access_token，appid  与appsecret已经写好占位符
        /// https://api.weixin.qq.com/cgi-bin/token?grant_type=client_credential&appid=APPID&secret=APPSECRET
        /// </summary>
        public string AccessToken ="https://api.weixin.qq.com/cgi-bin/token?grant_type=client_credential&appid={0}&secret={1}";

        #endregion



        #region 获取微信服务器IP地址  GET

        /// <summary>
        /// 获取微信服务器IP地址,access_token已经写好占位符，传入即可
        /// https://api.weixin.qq.com/cgi-bin/getcallbackip?access_token=ACCESS_TOKEN
        /// </summary>
        public string Getcallbackip = "https://api.weixin.qq.com/cgi-bin/getcallbackip?access_token={0}";

        #endregion



        #region 自定义菜单查询接口  GET 

        /// <summary>
        /// 自定义菜单查询接口  GET方式   需要传入access_token   占位符已写
        /// </summary>
        public string GetMenuUrl = "https://api.weixin.qq.com/cgi-bin/menu/get?access_token={0}";
        #endregion


        #region  删除当前使用的自定义菜单 GET 
        /// <summary>
        /// 删除当前使用的自定义菜单  需要传入access_token  点位符已写
        /// </summary>
        public string DeleteCustomerMenuUrl = "https://api.weixin.qq.com/cgi-bin/menu/delete?access_token={0}";
        #endregion



        #region 获取用户列表  GET 
        /// <summary>
        /// 获取用户列表  GET   需要传入access_token,next_openid(可不传)  占位符已写好 
        /// https://api.weixin.qq.com/cgi-bin/user/get?access_token=ACCESS_TOKEN&next_openid=NEXT_OPENID
        /// </summary>
        public string GetUser = "https://api.weixin.qq.com/cgi-bin/user/get?access_token={0}&next_openid={1}";
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
        /// </summary>
        public string MediaUpload = "https://api.weixin.qq.com/cgi-bin/media/upload?access_token={0}&type={1}";

        #endregion

        #region 上传图文消息素材【订阅号与服务号认证后均可用】  POST

        /// <summary>
        /// 上传图文消息素材【订阅号与服务号认证后均可用】 POST  需要传入access_token  占位符已写
        /// </summary>
        public string MediaUploadNews = "https://api.weixin.qq.com/cgi-bin/media/uploadnews?access_token=ACCESS_TOKEN";

        #endregion





        #region 群发url

        /// <summary>
        /// 根据分组进行群发【订阅号与服务号认证后均可用】 传入access_token即可，占位符已写
        /// </summary>
        public string SendAll = "https://api.weixin.qq.com/cgi-bin/message/mass/sendall?access_token={0}";

        #endregion


        #region  预览接口

        /// <summary>
        /// 预览接口【订阅号与服务号认证后均可用】  POST 需要传入access_token   占位符已写
        /// </summary>
        public string PreviewUrl = "https://api.weixin.qq.com/cgi-bin/message/mass/preview?access_token={0}";

        #endregion



        #endregion



    }
}
