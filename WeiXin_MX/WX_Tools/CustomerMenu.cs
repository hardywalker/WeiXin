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
    /// 自定义菜单类
    /// </summary>
  public  class CustomerMenu
    {
        /// <summary>
        /// 创建菜单
        /// </summary>
        public string CreateCustomerMenu(AppidSecret appidSecret,string jsonMenu)
        {
         

            byte[] postBytes = Encoding.UTF8.GetBytes(jsonMenu.ToString());
        
            string access_token = new GetAccessToken().Get_access_token(appidSecret);
            string createMenuUrl = string.Format(new ApiAddress().CreateMenu, access_token);

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
                JObject jObject = JObject.Parse(result);
                createResult = jObject["errmsg"].ToString();
                
            }

            return createResult;

        }
    }
}
