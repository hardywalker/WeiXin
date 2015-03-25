using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;

namespace WX_Tools
{
    /// <summary>
    /// 发送预览消息
    /// </summary>
  public  class SendPreview
    {
      /// <summary>
      /// 发送文本预览消息  
      /// </summary>
      /// <param name="strJson">消息体json</param>
        public void SendPriviewText(string strJson)
        {
            #region 发送文本预览消息

            /*
             * 开发者可通过该接口发送消息给指定用户，在手机端查看消息的样式和排版。

                接口调用请求说明
                
                http请求方式: POST
                https://api.weixin.qq.com/cgi-bin/message/mass/preview?access_token=ACCESS_TOKEN
                
                POST数据说明
                
                POST数据示例如下：
                
                
                文本：
                
                {     
                    "touser":"OPENID",
                    "text":{           
                           "content":"CONTENT"            
                           },     
                    "msgtype":"text"
                }

             */

            #endregion

            new DebugLog().BugWriteTxt(strJson);
            byte[] postBytes = Encoding.UTF8.GetBytes(strJson.ToString());

            string access_token = new GetAccessToken().Get_access_token();
            string actionUrl = string.Format(new ApiAddress().previewUrl, access_token);

            WebRequest webRequest = (HttpWebRequest)WebRequest.Create(actionUrl);

            webRequest.Method = "POST";
            webRequest.ContentType = "application/x-www-form-urlencoded;";
            webRequest.ContentLength = postBytes.Length;

            Stream streamWrite = webRequest.GetRequestStream();
            streamWrite.Write(postBytes, 0, postBytes.Length);
            streamWrite.Close();

            string createResult = "";
            HttpWebResponse httpWebResponse = (HttpWebResponse)webRequest.GetResponse();
            Stream streamRead = httpWebResponse.GetResponseStream();
            if (streamRead != null)
            {
                StreamReader streamReader = new StreamReader(streamRead, Encoding.UTF8);
                string result = streamReader.ReadToEnd();
                streamReader.Close();
                streamRead.Close();

                new DebugLog().BugWriteTxt(result);
            }

        }
    }
}
