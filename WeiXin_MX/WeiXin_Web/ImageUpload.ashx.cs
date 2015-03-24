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
                MemoryStream postStream = new MemoryStream();

                string boundary = "----" + DateTime.Now.Ticks.ToString("x");
                
                string formdataTemplate = "\r\n--" + boundary + "\r\nContent-Disposition: form-data; name=\"{0}\"; filename=\"{1}\"\r\nContent-Type: application/octet-stream\r\n\r\n";


                //根据完整文件获取文件流
              FileStream fileStream=new FileStream(context.Server.MapPath("/Upload/" + imgName + ".jpg"),FileMode.Open);

                try
                {
                
                    var formdata = string.Format(formdataTemplate, "media", context.Server.MapPath("/Upload/" + imgName + ".jpg")/*Path.GetFileName(fileName)*/);
                    var formdataBytes = Encoding.ASCII.GetBytes(postStream.Length == 0 ? formdata.Substring(2, formdata.Length - 2) : formdata);//第一行不需要换行
                    postStream.Write(formdataBytes, 0, formdataBytes.Length);

                    //写入文件
                    byte[] buffer = new byte[1024];
                    int bytesRead = 0;
                    while ((bytesRead = fileStream.Read(buffer, 0, buffer.Length)) != 0)
                    {
                        postStream.Write(buffer, 0, bytesRead);
                    }

                }
                catch (Exception)
                {
                    
                 
                }
            


              //结尾
              var footer = Encoding.ASCII.GetBytes("\r\n--" + boundary + "--\r\n");
              postStream.Write(footer, 0, footer.Length);

              request.ContentType = string.Format("multipart/form-data; boundary={0}", boundary);


              request.ContentLength = postStream != null ? postStream.Length : 0;
              request.Accept = "text/html,application/xhtml+xml,application/xml;q=0.9,image/webp,*/*;q=0.8";
              request.KeepAlive = true;

            
              request.UserAgent = "Mozilla/5.0 (Windows NT 6.1; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/31.0.1650.57 Safari/537.36";

         

              #region 输入二进制流
              if (postStream != null)
              {
                  postStream.Position = 0;

                  //直接写入流
                  Stream requestStream = request.GetRequestStream();

                  byte[] buffer = new byte[1024];
                  int bytesRead = 0;
                  while ((bytesRead = postStream.Read(buffer, 0, buffer.Length)) != 0)
                  {
                      requestStream.Write(buffer, 0, bytesRead);
                  }

                  postStream.Close();//关闭文件访问
              }
              #endregion

              HttpWebResponse response = (HttpWebResponse)request.GetResponse();


              using (Stream responseStream = response.GetResponseStream())
              {
                  using (StreamReader myStreamReader = new StreamReader(responseStream, Encoding.GetEncoding("utf-8")))
                  {
                      string retString = myStreamReader.ReadToEnd();
                      context.Response.Write(retString);
                  }
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