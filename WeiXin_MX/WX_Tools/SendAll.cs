using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using Newtonsoft.Json.Linq;

namespace WX_Tools
{
    /// <summary>
    /// 群发类
    /// </summary>
  public  class SendAll
    {
      /// <summary>
      /// 群发文本消息
      /// <param name="strText">要群发的消息</param>
      /// </summary>
        public void SendAllText(string strText)
        {
          #region 群发文本消息说明

          /*
             * 文本：

                    {
                       "filter":{
                          "is_to_all":false,
                          "group_id":"2"
                       },
                       "text":{
                          "content":"CONTENT"
                       },
                        "msgtype":"text"
                    }

             */

          #endregion

          string msg ="{\"filter\":{\"is_to_all\":true},\"text\": {\"content\": \""+strText+"\"},\"msgtype\": \"text\"}";

            new DebugLog().BugWriteTxt(msg);
          byte[] postBytes = Encoding.ASCII.GetBytes(msg.ToString());

            string access_token = new GetAccessToken().Get_access_token();
            string createMenuUrl = string.Format(new ApiAddress().sendAll, access_token);

            WebRequest webRequest = (HttpWebRequest)WebRequest.Create(createMenuUrl);

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
