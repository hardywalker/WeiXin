using System.IO;
using System.Net;
using System.Text;
using WX_Tools.Entites;

namespace WX_Tools
{
    /// <summary>
    /// 自定义菜单类处理类
    /// </summary>
    public class CustomerMenu
    {
        /// <summary>
        /// 创建菜单 POST
        /// </summary>
        /// <param name="accesstoken"></param>
        /// <param name="jsonMenu">菜单json字符串</param>
        /// <returns>返回创建结果json格式</returns>
        public string CreateCustomerMenu(string accesstoken, string jsonMenu)
        {


            byte[] postBytes = Encoding.UTF8.GetBytes(jsonMenu);

     
            string createMenuUrl = string.Format(new ApiAddress().CreateMenu, accesstoken);

            HttpWebRequest webRequest = WebRequest.Create(createMenuUrl) as HttpWebRequest;

            webRequest.Method = "POST";
            webRequest.ContentType = "application/json; encoding=utf-8";
            webRequest.ContentLength = postBytes.Length;

            Stream streamWrite = webRequest.GetRequestStream();
            streamWrite.Write(postBytes, 0, postBytes.Length);

            streamWrite.Close();

            string createResult = "";
            HttpWebResponse httpWebResponse = webRequest.GetResponse() as HttpWebResponse;
            Stream streamRead = httpWebResponse.GetResponseStream();
            if (streamRead != null)
            {
                StreamReader streamReader = new StreamReader(streamRead, Encoding.UTF8);
                //string result = streamReader.ReadToEnd();
                //streamReader.Close();
                //streamRead.Close();
                //JObject jObject = JObject.Parse(result);
                //createResult = jObject["errmsg"].ToString();
                createResult = streamReader.ReadToEnd();

            }

            return createResult;

        }

        /// <summary>
        /// 查询自定义菜单
        /// </summary>
        /// <param name="appidSecret">AppidSecretToken对象</param>
        /// <returns>返回json格式的处理结果</returns>
        public string GetCustomerMenu(string accesstoken)
        {
            /*
             * 使用接口创建自定义菜单后，开发者还可使用接口查询自定义菜单的结构。

                    请求说明
                    
                    http请求方式：GET
                    https://api.weixin.qq.com/cgi-bin/menu/get?access_token=ACCESS_TOKEN
                    
                    返回说明
                    
                    对应创建接口，正确的Json返回结果:
                    {"menu":{"button":[{"type":"click","name":"今日歌曲","key":"V1001_TODAY_MUSIC","sub_button":[]},{"type":"click","name":"歌手简介","key":"V1001_TODAY_SINGER","sub_button":[]},{"name":"菜单","sub_button":[{"type":"view","name":"搜索","url":"http://www.soso.com/","sub_button":[]},{"type":"view","name":"视频","url":"http://v.qq.com/","sub_button":[]},{"type":"click","name":"赞一下我们","key":"V1001_GOOD","sub_button":[]}]}]}}

             */

            string result = "";

     
            string getUrl = string.Format(new ApiAddress().GetMenuUrl, accesstoken);

            HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(getUrl);
            httpWebRequest.Method = "GET";
            httpWebRequest.ContentType = "appliction/json;charset=utf-8";

            HttpWebResponse httpWebResponse = httpWebRequest.GetResponse() as HttpWebResponse;
            Stream stream = httpWebResponse.GetResponseStream();
            if (stream != null)
            {
                StreamReader streamReader = new StreamReader(stream, Encoding.UTF8);
                result = streamReader.ReadToEnd();

            }

            return result;



        }


        /// <summary>
        /// 删除自定义菜单
        /// </summary>
        /// <param name="appidSecret">AppidSecretToken对象</param>
        /// <returns>返回json格式的处理结果</returns>
        public string DeleteCustomerMenu(string accesstoken)
        {

            /*
             * 使用接口创建自定义菜单后，开发者还可使用接口删除当前使用的自定义菜单。

                请求说明
                
                http请求方式：GET
                https://api.weixin.qq.com/cgi-bin/menu/delete?access_token=ACCESS_TOKEN
                
                返回说明
                
                对应创建接口，正确的Json返回结果:
                {"errcode":0,"errmsg":"ok"}

             */

            string result = "";
      
            string getUrl = string.Format(new ApiAddress().DeleteCustomerMenuUrl, accesstoken);

            HttpWebRequest httpWebRequest = WebRequest.Create(getUrl) as HttpWebRequest;
            httpWebRequest.Method = "GET";
            httpWebRequest.ContentType = "appliction/json;charset=utf-8";


            HttpWebResponse httpWebResponse = httpWebRequest.GetResponse() as HttpWebResponse;
            Stream stream = httpWebResponse.GetResponseStream();

            if (stream != null)
            {
                StreamReader streamReader = new StreamReader(stream, Encoding.UTF8);

                result = streamReader.ReadToEnd();
            }

            return result;

        }





    }
}
