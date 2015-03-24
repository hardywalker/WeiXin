namespace WX_Tools
{
    /// <summary>
    /// 微信各接口的URL地址
    /// </summary>
    public class ApiAddress
    {
        public ApiAddress()
        {
        }

        #region GET方式接口

        #region 获取access_token，appid   GET

        /// <summary>
        /// 使用AppID和AppSecret调用本接口来获取access_token，appid  与appsecret已经写好占位符
        /// https://api.weixin.qq.com/cgi-bin/token?grant_type=client_credential&appid=APPID&secret=APPSECRET
        /// </summary>
        public string access_token =
            "https://api.weixin.qq.com/cgi-bin/token?grant_type=client_credential&appid={0}&secret={1}";

        #endregion



        #region 获取微信服务器IP地址  GET

        /// <summary>
        /// 获取微信服务器IP地址,access_token已经写好占位符，传入即可
        /// https://api.weixin.qq.com/cgi-bin/getcallbackip?access_token=ACCESS_TOKEN
        /// </summary>
        public string getcallbackip = "https://api.weixin.qq.com/cgi-bin/getcallbackip?access_token={0}";

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
        public string mediaUpload = "https://api.weixin.qq.com/cgi-bin/media/upload?access_token={0}&type={1}";

        #endregion

        #region 群发url

        /// <summary>
        /// 根据分组进行群发【订阅号与服务号认证后均可用】 传入access_token即可，占位符已写
        /// </summary>
        public string sendAll = "https://api.weixin.qq.com/cgi-bin/message/mass/sendall?access_token={0}";

        #endregion


        #endregion



    }
}
