using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WX_Tools
{

    /// <summary>
    /// 整个项目中用到的缓存名称，保持全局统一
    /// </summary>
   public class AllCach
    {
       public AllCach() { }

       public enum AllCachEnum
       {
           /// <summary>
           /// 全局唯一票据，每天请求上限2000
           /// </summary>
           AccessToken
       }
    }
}
