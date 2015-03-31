using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using WX_Tools.Entites;

namespace WX_Tools
{
    /// <summary>
    /// 用户管理
    /// </summary>
  public  class User
    {

      /// <summary>
      /// 获取用户列表  最大一次获取10000，获取更多的话，需要写上next_openid
      /// </summary>
      /// <param name="appidSecret">appidSecret对象</param>
      /// <param name="nextOpenid">根据此openid获取以后的用户列表，可不填写</param>
        public string GetUserList(AppidSecret appidSecret,string nextOpenid="")
      {
          string result = "";

          string access_token = new GetAccessToken().Get_access_token(appidSecret);
          string getUrl = string.Format(new ApiAddress().GetUserUrl, access_token, nextOpenid);

          HttpWebRequest httpWebRequest = WebRequest.Create(getUrl) as HttpWebRequest;

          httpWebRequest.Method = "GET";
          httpWebRequest.ContentType = "application/json; charset=utf-8";

          HttpWebResponse httpWebResponse = httpWebRequest.GetResponse() as HttpWebResponse;
          Stream stream = httpWebResponse.GetResponseStream();
          if (stream != null)
          {
              StreamReader streamReader=new StreamReader(stream,Encoding.UTF8);
              result = streamReader.ReadToEnd();
          }

            return result;



      }
    }
}
