using System;
using System.IO;
using System.Text;
using System.Web;
using WeiXin_Web.Common;
using WX_Tools;
using WX_Tools.Entites;

namespace WeiXin_Web
{
    /// <summary>
    /// ImageUpload 的摘要说明
    /// </summary>
    public class ImageUpload : IHttpHandler
    {
        WeiXinConfiguration _weiXinConfiguration = new WeiXinConfiguration();
        CommonClass _commonClass=new CommonClass();
        private HttpContext _httpContext;
        public void ProcessRequest(HttpContext context)
        {

            _httpContext = context;

            _weiXinConfiguration = _commonClass.GetConfiguration();
                    
          //  context.Response.ContentType = "text/plain";
            //context.Response.Write("Hello World");
            string requestAction=context.Request.Form["action"];

            switch (requestAction)
            {
                    //临时图片素材
                case "TemporaryImage":
                    TemporaryMeidaUpload();
                    break;
            }


        }

        //回复消息状态
        private enum status
        {
            error,
            success,
            warning
        }


        /// <summary>
        /// 上传临时素材
        /// </summary>
        private void TemporaryMeidaUpload()
        {
            //返回格式：{"status":"error,success,warning","msg":""}
     
           // string result = "{\"status\":\"{0}\",\"msg\":\"{1}\"}";

        
         
          
            try
            {
                //根据前台html的name获取文件
                HttpPostedFile upfile = _httpContext.Request.Files["file_temporaryImage"];

                if (upfile == null)
                {
                   
                    ResponseWriteEnd(status.warning.ToString(), "没有选择文件");
                   
                }

                //文件原名称
                string oldMediaName = upfile.FileName;

                //文件后辍名称
                string oldMediaExtension = Path.GetExtension(oldMediaName);

                //判断文件格式是否符合要求
                if (!oldMediaExtension.ToLower().Equals(".jpg"))
                {
                  
                    ResponseWriteEnd(status.warning.ToString(), "请上传jpg格式的文件！");
                }

                //判断文件大小是否符合要求
                if (upfile.ContentLength >= (1024*1024*1))
                {
                


                    ResponseWriteEnd(status.warning.ToString(), "请上传1M以内的文件！");
                }

                string imgName = DateTime.Now.ToString("yyyy-MM-dd-HH-ss") + DateTime.Now.Ticks;
                bool flag = false;

                try
                {
                    upfile.SaveAs(_httpContext.Server.MapPath("/Upload/" + imgName + ".jpg"));
                    flag = true;
                }
                catch (Exception e)
                {

                    
                    ResponseWriteEnd(status.warning.ToString(), "保存图片出错");
                  
                }

                if (flag)
                {
                    // string mediaId =
                    //  new MediaUpload().GetTemporaryMediaId(_appidSecret,context.Server.MapPath("/Upload/" + imgName + ".jpg"));
                    //  context.Response.Write(mediaId);
                    //  new DebugLog().BugWriteTxt(new Log().LogTxtPhyPath, mediaId);


            


                    ResponseWriteEnd(status.success.ToString(), "/Upload/" + imgName + ".jpg");
                 
                }
                else
                {
                    File.Delete(_httpContext.Server.MapPath("/Upload/" + imgName + ".jpg"));


                   

                    ResponseWriteEnd(status.warning.ToString(), "图片保存出错，已经被删除。");
                }
            }
            catch (Exception EX_NAME)
            {

              ResponseWriteEnd(status.error.ToString(),EX_NAME.ToString());
            }
        }


        /// <summary>
        /// 输出方法
        /// </summary>
        /// <param name="status"></param>
        /// <param name="msg"></param>
        private void ResponseWriteEnd(string status,string msg)
        {
            StringBuilder stringBuilder=new StringBuilder();
            stringBuilder.Append("{");
            stringBuilder.Append("\"status\":");
            stringBuilder.AppendFormat("\"{0}\",", status);
            stringBuilder.Append("\"msg\":");
            stringBuilder.AppendFormat("\"{0}\"", msg);
            stringBuilder.Append("}");

            _httpContext.Response.Write(stringBuilder.ToString());
           // _httpContext.Response.End();此方法会引起  中止线程错误 。
           _httpContext.ApplicationInstance.CompleteRequest();
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