using System;
using System.IO;
using System.Net;
using System.Text;
using System.Web;
using Newtonsoft.Json.Linq;

namespace WX_Tools
{
    /// <summary>
    /// 新增临时素材
    /// </summary>
    public class MediaUpload
    {
        private HttpContext context = HttpContext.Current;


        /// <summary>
        /// 上传临时素材，获取media_id,有效期为三天
        /// </summary>
        /// <param name="fileUrl"></param>
        /// <returns></returns>
        public string GetTemporaryMediaID(string fileUrl)
        {
            #region 上传临时素材接口说明

            /*上传临时素材  Temporary临时 
             * 公众号经常有需要用到一些临时性的多媒体素材的场景，例如在使用接口特别是发送消息时，对多媒体文件、多媒体消息的获取和调用等操作，是通过media_id来进行的。素材管理接口对所有认证的订阅号和服务号开放。

                通过本接口，公众号可以新增临时素材（即上传临时多媒体文件）。但请注意，每个多媒体文件（media_id）会在开发者上传或粉丝发送到微信服务器3天后自动删除（所以用户发送给开  发者    的素  材，    若开发者需要，应尽快下载到本地），以节省服务器资源。请注意，media_id是可复用的。
                
                本接口即为原“上传多媒体文件”接口。 
             * 
             * 
             * http请求方式: POST/FORM,需使用https
                    https://api.weixin.qq.com/cgi-bin/media/upload?access_token=ACCESS_TOKEN&type=TYPE
                    调用示例（使用curl命令，用FORM表单方式上传一个多媒体文件）：
                    curl -F media=@test.jpg "https://api.weixin.qq.com/cgi-bin/media/upload?access_token=ACCESS_TOKEN&type=TYPE"
             * 
             * 
             * 
             * 
             * 参数 	是否必须 	说明
                access_token 	是 	调用接口凭证
                type 	是 	媒体文件类型，分别有图片（image）、语音（voice）、视频（video）和缩略图（thumb）
                media 	是 	form-data中媒体文件标识，有filename、filelength、content-type等信息 
             * 
             * 
             * 
             * 
             * 返回说明

                    正确情况下的返回JSON数据包结果如下：
                    
                    {"type":"TYPE","media_id":"MEDIA_ID","created_at":123456789}

                    参数 	描述
                    type 	媒体文件类型，分别有图片（image）、语音（voice）、视频（video）和缩略图（thumb，主要用于视频与音乐格式的缩略图）
                    media_id 	媒体文件上传后，获取时的唯一标识
                    created_at 	媒体文件上传时间戳
                    
                    错误情况下的返回JSON数据包示例如下（示例为无效媒体类型错误）：

                    {"errcode":40004,"errmsg":"invalid media type"}

             * 
             * 
             * 注意事项

                    上传的临时多媒体文件有格式和大小限制，如下：
                    
                        图片（image）: 1M，支持JPG格式
                        语音（voice）：2M，播放长度不超过60s，支持AMR\MP3格式
                        视频（video）：10MB，支持MP4格式
                        缩略图（thumb）：64KB，支持JPG格式 
                    
                    媒体文件在后台保存时间为3天，即3天后media_id失效。 
             */

            #endregion

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(string.Format(new ApiAddress().mediaUpload.ToString(), new GetAccessToken().Get_access_token(), "image"));
            request.Method = "POST";
            MemoryStream postStream = new MemoryStream();

            string boundary = "----" + DateTime.Now.Ticks.ToString("x");

            string formdataTemplate = "\r\n--" + boundary + "\r\nContent-Disposition: form-data; name=\"{0}\"; filename=\"{1}\"\r\nContent-Type: application/octet-stream\r\n\r\n";


            //根据完整文件获取文件流
            FileStream fileStream = new FileStream(fileUrl, FileMode.Open);

            try
            {

                var formdata = string.Format(formdataTemplate, "media", fileUrl);
                var formdataBytes = Encoding.ASCII.GetBytes(postStream.Length == 0 ? formdata.Substring(2, formdata.Length - 2) : formdata);//第一行不需要换行
                postStream.Write(formdataBytes, 0, formdataBytes.Length);

                //写入文件
                byte[] buffer = new byte[1024];
                int bytesRead = 0;
                while ((bytesRead = fileStream.Read(buffer, 0, buffer.Length)) != 0)
                {
                    postStream.Write(buffer, 0, bytesRead);
                }

            }
            catch (Exception e)
            {
                //写入异常日志
                new DebugLog().BugWriteTxt(e.ToString());
            }



            //结尾
            var footer = Encoding.ASCII.GetBytes("\r\n--" + boundary + "--\r\n");
            postStream.Write(footer, 0, footer.Length);

            request.ContentType = string.Format("multipart/form-data; boundary={0}", boundary);


            request.ContentLength = postStream != null ? postStream.Length : 0;
            request.Accept = "text/html,application/xhtml+xml,application/xml;q=0.9,image/webp,*/*;q=0.8";
            request.KeepAlive = true;


            request.UserAgent = "Mozilla/5.0 (Windows NT 6.1; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/31.0.1650.57 Safari/537.36";



            #region 输入二进制流
            if (postStream != null)
            {
                postStream.Position = 0;

                //直接写入流
                Stream requestStream = request.GetRequestStream();

                byte[] buffer = new byte[1024];
                int bytesRead = 0;
                while ((bytesRead = postStream.Read(buffer, 0, buffer.Length)) != 0)
                {
                    requestStream.Write(buffer, 0, bytesRead);
                }

                postStream.Close();//关闭文件访问
            }
            #endregion

            HttpWebResponse response = (HttpWebResponse)request.GetResponse();

            string result = "";
            using (Stream responseStream = response.GetResponseStream())
            {
                using (StreamReader myStreamReader = new StreamReader(responseStream, Encoding.GetEncoding("utf-8")))
                {
                    string retString = myStreamReader.ReadToEnd();

                    //解析json
                    JObject jObject = JObject.Parse(retString);
                    if (!string.IsNullOrWhiteSpace(jObject["media_id"].ToString()))
                    {
                        result= jObject["media_id"].ToString();
                    }

                }
            }
            return result;

        }
    }
}
