using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;

namespace WeiXin_Web
{
    /// <summary>
    /// ImageUpload 的摘要说明
    /// </summary>
    public class ImageUpload : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            //context.Response.Write("Hello World");


            //根据前台html的name获取文件
            HttpPostedFile _upfile = context.Request.Files["image0"];

            if (_upfile == null)
            {
                context.Response.Write("没有选择文件 ");
                return;
            }

            string imgName = DateTime.Now.ToString("yyyy-MM-dd-HH-ss") + DateTime.Now.Ticks;
            bool flag = false;

            try
            {
                _upfile.SaveAs(context.Server.MapPath("/Upload/" + imgName + ".jpg"));
                flag = true;
            }
            catch (Exception)
            {
                
               
            }

            if (flag)
            {

                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(string.Format(new WX_Tools.ApiAddress().mediaUpload.ToString(), new WX_Tools.GetAccessToken().Get_access_token(), "image"));
                request.Method = "POST";
               
                request.ContentType = "application/x-www-form-urlencoded;";
      
                MemoryStream memoryStream=new MemoryStream();

                //根据完整文件获取文件流
              FileStream fileStream=new FileStream(context.Server.MapPath("/Upload/" + imgName + ".jpg"),FileMode.Open);
         
                //TODO:2015年3月23日18:07:10   上传文件测试
              


                byte[] imgBytes = Encoding.UTF8.GetBytes(fileStream.ToString());





                Stream streamWrite = request.GetRequestStream();
                streamWrite.Write(imgBytes,0,imgBytes.Length);
                streamWrite.Close();

                string backResult = "";
                HttpWebResponse httpWebResponse = (HttpWebResponse)request.GetResponse();
                Stream streamRead = httpWebResponse.GetResponseStream();
                if (streamRead != null)
                {
                    StreamReader streamReader=new StreamReader(streamRead,Encoding.UTF8);
                    backResult = streamReader.ReadToEnd();
                    context.Response.Write(backResult);
                }

            }
            else
            {
                File.Delete(context.Server.MapPath("/Upload/" + imgName + ".jpg"));
            }



     

        }
       
        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}