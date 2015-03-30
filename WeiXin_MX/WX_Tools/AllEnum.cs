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

      /// <summary>
      /// 订阅事件
      /// </summary>
      public enum EventEnum
      {
          /// <summary>
          /// 订阅（关注）事件
          /// </summary>
          Subscribe,

          /// <summary>
          /// 取消订阅（取消关注）事件
          /// </summary>
          Unsubscribe
      }

      /// <summary>
      /// 消息类型
      /// </summary>
      public enum MsgTypeEnum
      {

          /// <summary>
          /// 文本消息
          /// </summary>
          Text,


          /// <summary>
          /// 图片消息
          /// </summary>
          Image,

          /// <summary>
          /// 语音消息
          /// </summary>
          Voice,


          /// <summary>
          /// 视频消息
          /// </summary>
          Video,

          /// <summary>
          /// 小视频消息
          /// </summary>
          Shortvideo,

          /// <summary>
          /// 地理位置消息
          /// </summary>
          Location,

          /// <summary>
          /// 链接消息
          /// </summary>
          Link,

          
      }


      /// <summary>
      /// 自定义菜单按键的事件类型
      /// </summary>
  public enum CustomerMenuButtonEvent
  {
      /// <summary>
      /// 点击推事件
      /// </summary>
      Click,

      /// <summary>
      /// 跳转URL
      /// </summary>
      View,

      /// <summary>
      /// 扫码推事件
      /// </summary>
      ScancodePush,

      /// <summary>
      /// 扫码推事件且弹出“消息接收中”提示框
      /// </summary>
      ScancodeWaitmsg,

      /// <summary>
      /// 弹出系统拍照发图
      /// </summary>
      PicSysphoto,

      /// <summary>
      /// 弹出拍照或者相册发图
      /// </summary>
      PicPhotoOrAlbum,

      /// <summary>
      /// 弹出微信相册发图器
      /// </summary>
      PicWeixin,

      /// <summary>
      /// 弹出地理位置选择器
      /// </summary>
      LocationSelect
  }

    }
}
