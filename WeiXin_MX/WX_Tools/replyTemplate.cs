using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WX_Tools
{
    /// <summary>
    /// 消息回复模板
    /// </summary>
   public class replyTemplate
    {
        #region 回复文本消息

        /// <summary>
        /// 回复文本消息  MsgType:text   
        /// </summary>
        public void replyText()
        {
            /*回复文本消息  模板
             *  <xml>
                    <ToUserName><![CDATA[toUser]]></ToUserName>
                    <FromUserName><![CDATA[fromUser]]></FromUserName>
                    <CreateTime>12345678</CreateTime>
                    <MsgType><![CDATA[text]]></MsgType>
                    <Content><![CDATA[你好]]></Content>
                </xml>
                    
                    参数 	是否必须 	描述
                    ToUserName 	是 	接收方帐号（收到的OpenID）
                    FromUserName 	是 	开发者微信号
                    CreateTime 	是 	消息创建时间 （整型）
                    MsgType 	是 	text
                    Content 	是 	回复的消息内容（换行：在content中能够换行，微信客户端就支持换行显示） 
             */
        }

        #endregion

    }
}
