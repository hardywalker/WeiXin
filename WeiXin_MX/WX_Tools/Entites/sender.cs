using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WX_Tools.Entites
{
    /// <summary>
    /// 回复消息时发送人与指定接收者实体
    /// </summary>
  public class sender
    {
      /// <summary>
        /// 必须字段，接收方帐号（收到的OpenID）
      /// </summary>
      public string toUserName { get; set; }


      /// <summary>
      /// 必须字段，开发者微信号
      /// </summary>
      public string fromUserName { get; set; }


      /// <summary>
      /// 发送消息的时间戳
      /// </summary>
      public int createTime { get; set; }

    }
}
