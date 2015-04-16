namespace WX_Tools
{
    /// <summary>
    /// 全局所用的统一名称(全部小写)，枚举方式记录，包括事件等
    /// </summary>
  public partial  class AllEnum
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
          /// 小视频消息
          /// </summary>
          shortvideo,

          /// <summary>
          /// 地理位置消息
          /// </summary>
          location,

          /// <summary>
          /// 链接消息
          /// </summary>
          link,

          
      }


      /// <summary>
      /// 自定义菜单按键的事件类型
      /// </summary>
  public enum CustomerMenuButtonEvent
  {
      /// <summary>
      /// 点击推事件
      /// </summary>
      click,

      /// <summary>
      /// 跳转URL
      /// </summary>
      view,

      /// <summary>
      /// 扫码推事件
      /// </summary>
      scancodepush,

      /// <summary>
      /// 扫码推事件且弹出“消息接收中”提示框
      /// </summary>
      scancodewaitmsg,

      /// <summary>
      /// 弹出系统拍照发图
      /// </summary>
      picsysphoto,

      /// <summary>
      /// 弹出拍照或者相册发图
      /// </summary>
      picphotooralbum,

      /// <summary>
      /// 弹出微信相册发图器
      /// </summary>
      picweixin,

      /// <summary>
      /// 弹出地理位置选择器
      /// </summary>
      locationselect
  }

    }
}
