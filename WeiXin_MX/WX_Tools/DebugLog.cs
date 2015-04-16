using System;
using System.IO;
using System.Web;

namespace WX_Tools
{
    /// <summary>
    /// 程序运行中的记录写入txt文档
    /// </summary>
  public  class DebugLog
  {

      private readonly HttpContext _httpContext = HttpContext.Current;

        /// <summary>
        /// 把运行记录写入txt文档
        /// </summary>
        /// <param name="debugMsg">需要写入的内容</param>
        /// <param name="txtPath">日志所存放的目录/***/</param>
        public void BugWriteTxt(string txtPath,string debugMsg)
        {
            //物理路径
           string phyPath= _httpContext.Server.MapPath(txtPath);
            //判断路径是否存在
            if (!Directory.Exists(phyPath))
            {
                //不存在就创建目录
                Directory.CreateDirectory(phyPath);
            }
            //开始写入文件
          File.WriteAllText(Path.Combine(phyPath,DateTime.Now.ToString("yyyy-MM-dd-HH-mm-ss") + "-" +DateTime.Now.Ticks + ".txt"),debugMsg);
      }
    }
}
