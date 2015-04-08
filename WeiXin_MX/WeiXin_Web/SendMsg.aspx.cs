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
            lab_send_all_msg.Text = new SendAll().SendAllText(_appidSecret, txt_sendall.Text.Trim());
        }

        /// <summary>
        /// 向指定用户发送预览消息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btn_send_preview_OnClick(object sender, EventArgs e)
        {
            lab_send_preview_msg.Text = new SendPreview().SendPriviewText(_appidSecret, txt_send_preview.Text);
        }

        /// <summary>
        /// 根据用户列表进行群发
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btn_sendmsg_openlist_OnServerClick(object sender, EventArgs e)
        {
         //Todo:2015年4月8日18:12:48 尚未完成根据用户列表群发功能，需要把发送消息封装成一个单独类
        }
    }
}