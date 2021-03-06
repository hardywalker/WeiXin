﻿using System.IO;
using System.Net;
using System.Text;
using WX_Tools.Entites;

namespace WX_Tools
{
    /// <summary>
    /// 获取服务器ip列表
    /// </summary>
    public class Getcallbackip
    {
        /// <summary>
        /// 正常情况下，微信会返回下述JSON数据包给公众号：
        ///{
        ///"ip_list":["127.0.0.1","127.0.0.1"]
        ///}
        /// </summary>
        /// <returns>返回json格式的字符串</returns>
        public string GetServerIpString(string accesstoken)
        {

            string result = "";



            string getHttpUrl = string.Format(new ApiAddress().Getcallbackip, accesstoken);

            HttpWebRequest webRequest = (HttpWebRequest)WebRequest.Create(getHttpUrl);
            if (webRequest != null)
            {
                webRequest.Method = "GET";
                webRequest.ContentType = "appliction/json;charset=utf-8";

                HttpWebResponse webResponse = (HttpWebResponse)webRequest.GetResponse();
                Stream stream = webResponse.GetResponseStream();
                if (stream != null)
                {
                    StreamReader streamReader = new StreamReader(stream, Encoding.UTF8);

                    result = streamReader.ReadToEnd();


                    streamReader.Close();
                    stream.Close();



                }

            }

            return result;

        }
    }
}
