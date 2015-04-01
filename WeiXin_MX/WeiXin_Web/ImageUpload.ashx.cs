using System;
using System.IO;
using System.Web;
using System.Web.Configuration;
using WX_Tools;
using WX_Tools.Entites;

namespace WeiXin_Web
{
    /// <summary>
    /// ImageUpload 的摘要说明
    /// </summary>
    public class ImageUpload : IHttpHandler
    {
        AppidSecretToken _appidSecret=new AppidSecretToken();
        
        public void ProcessRequest(HttpContext context)
        {
          
                    _appidSecret.Appid = WebConfigurationManager.AppSettings["appid"];
                    _appidSecret.Secret = WebConfigurationManager.AppSettings["secret"];
            context.Response.ContentType = "text/plain";
            //context.Response.Write("Hello World");


            //根据前台html的name获取文件
            HttpPostedFile upfile = context.Request.Files["image0"];

            if (upfile == null)
            {
                context.Response.Write("没有选择文件 ");
                return;
            }

            string imgName = DateTime.Now.ToString("yyyy-MM-dd-HH-ss") + DateTime.Now.Ticks;
            bool flag = false;

            try
            {
                upfile.SaveAs(context.Server.MapPath("/Upload/" + imgName + ".jpg"));
                flag = true;
            }
            catch (Exception e)
            {
                new DebugLog().BugWriteTxt("保存图片出错："+e.ToString());
               
            }

            if (flag)
            {
                string mediaId =
                    new MediaUpload().GetTemporaryMediaId(_appidSecret,context.Server.MapPath("/Upload/" + imgName + ".jpg"));
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