using System;
using System.Web.Configuration;
using System.Web.UI;
using WX_Tools;
using WX_Tools.Entites;

namespace WeiXin_Web
{
    public partial class SendMsg : Page
    {
        private AppidSecret _appidSecret = new AppidSecret();

        protected void Page_Load(object sender, EventArgs e)
        {

            _appidSecret.Appid = WebConfigurationManager.AppSettings["appid"];
            _appidSecret.Secret = WebConfigurationManager.AppSettings["secret"];

        }


        /// <summary>
        /// 群发消息
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
    }
}