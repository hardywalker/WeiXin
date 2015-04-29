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
                    
            context.Response.ContentType = "text/plain";
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



        private void TemporaryMeidaUpload()
        {
            //返回格式：{"status":"error,success,warning","msg":""}
     
           // string result = "{\"status\":\"{0}\",\"msg\":\"{1}\"}";

            StringBuilder stringBuilder=new StringBuilder();
         
          
            try
            {
                //根据前台html的name获取文件
                HttpPostedFile upfile = _httpContext.Request.Files["file_temporaryImage"];

                if (upfile == null)
                {
                    stringBuilder.Append("{");
                    stringBuilder.Append("\"status\":");
                    stringBuilder.AppendFormat("\"{0}\",", status.warning);
                    stringBuilder.Append("\"msg\":");
                    stringBuilder.AppendFormat("\"{0}\"", "没有选择文件");
                    stringBuilder.Append("}");

                   // _httpContext.Response.Write(stringBuilder.ToString());
                    _httpContext.Response.Write("{\"status\":\"warning\",\"msg\":\"没有选择文件\"}");
                    _httpContext.Response.End();
                    return;
                   
                }

                //文件原名称
                string oldMediaName = upfile.FileName;

                //文件后辍名称
                string oldMediaExtension = Path.GetExtension(oldMediaName);

                //判断文件格式是否符合要求
                if (!oldMediaExtension.ToLower().Equals("jpg"))
                {
                    stringBuilder.Append("{");
                    stringBuilder.Append("\"status\":");
                    stringBuilder.AppendFormat("\"{0}\",", status.warning);
                    stringBuilder.Append("\"msg\":");
                    stringBuilder.AppendFormat("\"{0}\"", "请上传jpg格式的文件！");
                    stringBuilder.Append("}");
                    _httpContext.Response.Write(stringBuilder.ToString());
                    _httpContext.Response.End();
                    return;
                }

                //判断文件大小是否符合要求
                if (upfile.ContentLength >= (1024*1024*1))
                {
                    stringBuilder.Append("{");
                    stringBuilder.Append("\"status\":");
                    stringBuilder.AppendFormat("\"{0}\",", status.warning);
                    stringBuilder.Append("\"msg\":");
                    stringBuilder.AppendFormat("\"{0}\"", "请上传1M以内的文件！");
                    stringBuilder.Append("}");
                    _httpContext.Response.Write(stringBuilder.ToString());
                    _httpContext.Response.End();
                    return;
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

                    new DebugLog().BugWriteTxt(new Log().LogTxtPhyPath, "保存图片出错：" + e.ToString());

                    stringBuilder.Append("{");
                    stringBuilder.Append("\"status\":");
                    stringBuilder.AppendFormat("\"{0}\",", status.warning);
                    stringBuilder.Append("\"msg\":");
                    stringBuilder.AppendFormat("\"{0}\"", "保存图片出错");
                    stringBuilder.Append("}");
                    _httpContext.Response.Write(stringBuilder.ToString());
                    _httpContext.Response.End();
                  
                }

                if (flag)
                {
                    // string mediaId =
                    //  new MediaUpload().GetTemporaryMediaId(_appidSecret,context.Server.MapPath("/Upload/" + imgName + ".jpg"));
                    //  context.Response.Write(mediaId);
                    //  new DebugLog().BugWriteTxt(new Log().LogTxtPhyPath, mediaId);


                    stringBuilder.Append("{");
                    stringBuilder.Append("\"status\":");
                    stringBuilder.AppendFormat("\"{0}\",", status.success);
                    stringBuilder.Append("\"msg\":");
                    stringBuilder.AppendFormat("\"{0}\"",  _httpContext.Server.MapPath("/Upload/" + imgName + ".jpg"));
                    stringBuilder.Append("}");
                    _httpContext.Response.Write(stringBuilder.ToString());
                    _httpContext.Response.End();
                 
                }
                else
                {
                    File.Delete(_httpContext.Server.MapPath("/Upload/" + imgName + ".jpg"));


                    stringBuilder.Append("{");
                    stringBuilder.Append("\"status\":");
                    stringBuilder.AppendFormat("\"{0}\",", status.success);
                    stringBuilder.Append("\"msg\":");
                    stringBuilder.AppendFormat("\"{0}\"", "图片保存出错，已经被删除。");
                    stringBuilder.Append("}");
                    _httpContext.Response.Write(stringBuilder.ToString());
                    _httpContext.Response.End();
                }
            }
            catch (Exception EX_NAME)
            {

                stringBuilder.Append("{");
                stringBuilder.Append("\"status\":");
                stringBuilder.AppendFormat("\"{0}\",", status.error);
                stringBuilder.Append("\"msg\":");
                stringBuilder.AppendFormat("\"{0}\"", "程序错误：" + EX_NAME);
                stringBuilder.Append("}");

                _httpContext.Response.Write(stringBuilder.ToString());
                _httpContext.Response.End();
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