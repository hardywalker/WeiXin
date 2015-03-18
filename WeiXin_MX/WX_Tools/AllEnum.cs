using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WX_Tools
{
    /// <summary>
    /// 全局所用的统一名称，枚举方式记录，包括事件等
    /// </summary>
  public  class AllEnum
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

      public enum MsgTypeEnum
      {

          /// <summary>
          /// 文本消息
          /// </summary>
          text,


          /// <summary>
          /// 图片消息
          /// </summary>
          image,

          /// <summary>
          /// 语音消息
          /// </summary>
          voice,


          /// <summary>
          /// 视频消息
          /// </summary>
          video,

          /// <summary>
          /// 地理位置消息
          /// </summary>
          location,

          /// <summary>
          /// 链接消息
          /// </summary>
          link,

          
      }

    }
}
