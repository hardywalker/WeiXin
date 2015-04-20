namespace WX_Tools.Entites
{
    /// <summary>
    /// 回复图文消息的实体类型
    /// </summary>
    public class News
    {
        private string title;

        /// <summary>
        /// 图文消息标题
        /// </summary>
        public string Title {
            get { return title; }
            set { title = value; }
        }

        private string description;
        /// <summary>
        /// 图文消息描述
        /// </summary>
        public string Description {
            get { return description; }
            set { description = value; }
        }

        private string picUrl;
        /// <summary>
        /// 图片链接，支持JPG、PNG格式，较好的效果为大图360*200，小图200*200
        /// </summary>
        public string PicUrl {
            get { return picUrl; }
            set { picUrl = value; }
        }


        private string url;
        /// <summary>
        /// 点击图文消息跳转链接
        /// </summary>
        public string Url {
            get { return url; }
            set { url = value; }
        }
    }
}
