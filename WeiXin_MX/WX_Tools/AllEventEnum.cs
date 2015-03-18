using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WX_Tools
{
    /// <summary>
    /// 全局所用的统一名称，枚举方式记录，包括事件等
    /// </summary>
  public  class AllEventEnum
    {
      public enum EventEnum
      {
          /// <summary>
          /// 订阅（关注）事件
          /// </summary>
          subscribe,

          /// <summary>
          /// 取消订阅（取消关注）事件
          /// </summary>
          unsubscribe
      }
    }
}
