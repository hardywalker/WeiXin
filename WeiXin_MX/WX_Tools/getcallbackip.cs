using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using Newtonsoft.Json.Linq;

namespace WX_Tools
{
    /// <summary>
    /// 获取服务器ip列表
    /// </summary>
  public  class getcallbackip
    {
      /// <summary>
      /// 正常情况下，微信会返回下述JSON数据包给公众号：
      ///{
	  ///"ip_list":["127.0.0.1","127.0.0.1"]
      ///}
      /// </summary>
      /// <returns></returns>
      public string getServerIPString()
      {

          string ipString = "";
       

          string access_token = new get_access_token().Get_access_token();
             string getHttpUrl =string.Format(new apiAddress().getcallbackip,access_token);

          WebRequest webRequest = (HttpWebRequest) WebRequest.Create(getHttpUrl);
          if (webRequest != null)
          {
              webRequest.Method = "GET";
              webRequest.ContentType = "appliction/json;charset=utf-8";

              WebResponse webResponse = (HttpWebResponse) webRequest.GetResponse();
              Stream stream = webResponse.GetResponseStream();
              if (stream != null)
              {
                  StreamReader streamReader=new StreamReader(stream,Encoding.UTF8);

                  string jsonData = streamReader.ReadToEnd();

                  JObject jsonJObject=JObject.Parse(jsonData);
                  JArray jArray = JArray.Parse(jsonJObject["ip_list"].ToString());
                  streamReader.Close();
                  stream.Close();




                  for (int i = 0; i < jArray.Count; i++)
                  {


                      ipString += jArray[i] + ",";
                  }

                 // ipString = jArray.Aggregate(ipString, (current, t) => current + (t + ","));


                

              }


          }

          return ipString;

      }
    }
}
