using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;

namespace WX_Tools
{
    /// <summary>
    /// 程序运行中的记录写入txt文档
    /// </summary>
  public  class DebugLog
  {

      private HttpContext _httpContext = HttpContext.Current;

      /// <summary>
      /// 把运行记录写入txt文档
      /// </summary>
      /// <param name="debugMsg">需要写入的内容</param>
      public void BugWriteTxt(string debugMsg)
      {
          File.WriteAllText(
               _httpContext.Server.MapPath("/ErrorTXT/" + DateTime.Now.ToString("yyyy-MM-dd-HH-mm-ss") + "-" +
                                           DateTime.Now.Ticks + ".txt"),debugMsg);
      }
    }
}
