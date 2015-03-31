using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using Newtonsoft.Json.Linq;
using WX_Tools.Entites;

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
        public string SendAllText(AppidSecret appidSecret,string strJson)
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

         // string msg ="{\"filter\":{\"is_to_all\":true},\"text\": {\"content\": \""+strText+"\"},\"msgtype\": \"text\"}";

            //把群发的消息体内容写入日志
            new DebugLog().BugWriteTxt(strJson);

            byte[] postBytes = Encoding.UTF8.GetBytes(strJson);

            string accessToken = new GetAccessToken().Get_access_token(appidSecret);
            string sendAllUrl = string.Format(new ApiAddress().SendAll, accessToken);

            HttpWebRequest webRequest =WebRequest.Create(sendAllUrl) as HttpWebRequest;

            webRequest.Method = "POST";
            webRequest.ContentType = "application/x-www-form-urlencoded;";
            webRequest.ContentLength = postBytes.Length;

            Stream streamWrite = webRequest.GetRequestStream();
            streamWrite.Write(postBytes, 0, postBytes.Length);
            streamWrite.Close();

            string result = "";
            HttpWebResponse httpWebResponse = webRequest.GetResponse() as HttpWebResponse;
            Stream streamRead = httpWebResponse.GetResponseStream();
            if (streamRead != null)
            {
                StreamReader streamReader = new StreamReader(streamRead, Encoding.UTF8);
                result = streamReader.ReadToEnd();
                streamReader.Close();
                streamRead.Close();

                new DebugLog().BugWriteTxt(result);
            }
          return result;

        }
    }
}
