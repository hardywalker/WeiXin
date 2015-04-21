namespace WX_Tools.Entites
{
    /// <summary>
    /// appid以及appsecret,token,encodingaeskey实体类
    /// </summary>
   public  class Configuration
    {


        private string appid;

       /// <summary>
        /// AppID(应用ID)
       /// </summary>
       public  string Appid {
           get { return appid; }
           set { appid = value; }
       }



        private string appSecret;
       /// <summary>
        /// AppSecret(应用密钥)
       /// </summary>
       public  string AppSecret {
           get { return appSecret; }
           set { appSecret = value; }
       }



        private string token;
       /// <summary>
        /// Token(令牌)
       /// </summary>
        public string Token {
           get { return token; }
           set { token = value; }
        }


        private string encodingAESKey;

       /// <summary>
        /// EncodingAESKey(消息加解密密钥)
       /// </summary>
        public string EncodingAESKey
        {
            get { return encodingAESKey; }
            set { encodingAESKey = value; }
        }
    }
}
