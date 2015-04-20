using System;
using System.Collections.Generic;

using System.Text;

namespace WX_Tools.Entites
{
    /// <summary>
    /// 回复消息时发送人与指定接收者实体
    /// </summary>
  public class Sender
    {

        private string toUserName;
      /// <summary>
        /// 必须字段，接收方帐号（收到的OpenID）
      /// </summary>
      public string ToUserName {
          get { return toUserName; }
          set { toUserName = value; }
      }


        private string fromUserName;
      /// <summary>
      /// 必须字段，开发者微信号
      /// </summary>
      public string FromUserName {
          get { return fromUserName; }
          set { fromUserName = value; }
      }


        private int createTime;
      /// <summary>
      /// 发送消息的时间戳
      /// </summary>
      public int CreateTime {
          get { return createTime; }
          set { createTime = value; }
      }

    }
}
