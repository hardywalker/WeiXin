using System.IO;
using System.Net;
using System.Text;
using Newtonsoft.Json.Linq;
using WX_Tools.Entites;

namespace WX_Tools
{
    /// <summary>
    /// 获取服务器ip列表
    /// </summary>
  public  class Getcallbackip
    {
      /// <summary>
      /// 正常情况下，微信会返回下述JSON数据包给公众号：
      ///{
	  ///"ip_list":["127.0.0.1","127.0.0.1"]
      ///}
      /// </summary>
      /// <returns></returns>
      public string GetServerIpString(AppidSecretToken appidSecret)
      {

          string ipString = "";


          string accessToken = new GetAccessToken().Get_access_token(appidSecret, "catch");
             string getHttpUrl =string.Format(new ApiAddress().Getcallbackip,accessToken);

          HttpWebRequest webRequest = (HttpWebRequest) WebRequest.Create(getHttpUrl);
          if (webRequest != null)
          {
              webRequest.Method = "GET";
              webRequest.ContentType = "appliction/json;charset=utf-8";

              HttpWebResponse webResponse = (HttpWebResponse) webRequest.GetResponse();
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
