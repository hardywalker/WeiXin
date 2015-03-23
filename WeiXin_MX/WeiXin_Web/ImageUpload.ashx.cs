using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
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
       
       
            //_upfile.SaveAs(context.Server.MapPath("/Upload/"+DateTime.Now.ToString("yyyy-MM-dd-HH-ss")+".jpg"));
            _upfile.SaveAs(context.Server.MapPath("/Upload/a.jpg"));
     

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