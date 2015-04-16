using System;
using System.Text;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using WX_Tools;
using WX_Tools.Entites;

namespace WeiXin_Web
{
    public partial class Index : Page
    {
        private AppidSecretToken _appidSecret=new AppidSecretToken();

        protected void Page_Load(object sender, EventArgs e)
        {
       
            _appidSecret.Appid = WebConfigurationManager.AppSettings["appid"];
            _appidSecret.Secret = WebConfigurationManager.AppSettings["secret"];




        }
        

       

        /// <summary>
        /// 获取access_token
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btn_get_access_token_OnClick(object sender, EventArgs e)
        {
            string accesstoken=new GetAccessToken().Get_access_token(_appidSecret,"catch");
            new DebugLog().BugWriteTxt(new Log(){LogTxtPhyPath = "/ErrorTXT/"}.LogTxtPhyPath,accesstoken);
            lab_access_token.Text = accesstoken;
        }

        /// <summary>
        /// 获取服务器ip
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btn_get_server_ip_OnClick(object sender, EventArgs e)
        {
            lab_server_ip.Text = new Getcallbackip().GetServerIpString(_appidSecret);
        }

       

        /// <summary>
        /// 提交图文消息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btn_send_tuwen_OnClick(object sender, EventArgs e)
        {
           lab_send_tuwen_msg.Text= new MediaUpload().MediaUploadNews(_appidSecret, txt_send_tuwen.Text.Trim());
        }

        /// <summary>
        /// 更新access_token
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btn_update_access_token_OnServerClick(object sender, EventArgs e)
        {
            lab_access_token.Text = new GetAccessToken().Get_access_token(_appidSecret, "server");
        }
    }
}