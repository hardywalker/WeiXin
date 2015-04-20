using System;
using System.Web.Configuration;
using System.Web.UI;
using WX_Tools;
using WX_Tools.Entites;

namespace WeiXin_Web
{
    public partial class SendMsg : Page
    {
        private readonly AppidSecretToken _appidSecret = new AppidSecretToken();
        readonly MessageMass _messageMass=new MessageMass();
        protected void Page_Load(object sender, EventArgs e)
        {

            _appidSecret.Appid = WebConfigurationManager.AppSettings["appid"];
            _appidSecret.Secret = WebConfigurationManager.AppSettings["secret"];

        }


        /// <summary>
        /// 根据用户分组群发消息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btn_sendall_OnClick(object sender, EventArgs e)
        {
           // lab_send_all_msg.Text = _messageMass.MessageMassSendAll(_appidSecret, txt_sendall.Text.Trim());
        }

        /// <summary>
        /// 向指定用户发送预览消息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btn_send_preview_OnClick(object sender, EventArgs e)
        {
           // lab_send_preview_msg.Text = _messageMass.MessageMassPreview(_appidSecret, txt_send_preview.Text);
        }

        /// <summary>
        /// 根据用户列表进行群发
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btn_sendmsg_openlist_OnServerClick(object sender, EventArgs e)
        {
           // lab_sendmsg_openlist_msg.InnerText = _messageMass.MessageMassSend(_appidSecret, txt_send_openlist.Value.Trim());
        }
    }
}