using System;
using System.IO;
using System.Web;
using WX_Tools;
using WX_Tools.Entites;

namespace WeiXin_Web
{
    /// <summary>
    /// ImageUpload 的摘要说明
    /// </summary>
    public class ImageUpload : IHttpHandler
    {
        AppidSecret appidSecret=new AppidSecret();

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
                string mediaId =
                    new MediaUpload().GetTemporaryMediaID(appidSecret,context.Server.MapPath("/Upload/" + imgName + ".jpg"));
               context.Response.Write(mediaId);
                new DebugLog().BugWriteTxt(mediaId);

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