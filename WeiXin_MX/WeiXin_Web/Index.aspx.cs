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
        private AppidSecret _appidSecret=new AppidSecret();

        protected void Page_Load(object sender, EventArgs e)
        {
       
            _appidSecret.Appid = WebConfigurationManager.AppSettings["appid"];
            _appidSecret.Secret = WebConfigurationManager.AppSettings["secret"];




        }
        

        /// <summary>
        /// 创建菜单
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btn_createMenu_OnClick(object sender, EventArgs e)
        {
            new DebugLog().BugWriteTxt(txt_menu.Text.Trim());
            lab_menu_msg.InnerText = "创建菜单结果：" +
                                     new CustomerMenu().CreateCustomerMenu(_appidSecret,txt_menu.Text.Trim());

        }

        /// <summary>
        /// 获取access_token
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btn_get_access_token_OnClick(object sender, EventArgs e)
        {
            lab_access_token.Text = new GetAccessToken().Get_access_token(_appidSecret);
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
        /// 群发消息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btn_sendall_OnClick(object sender, EventArgs e)
        {
           lab_send_all_msg.Text=new SendAll().SendAllText(_appidSecret,txt_sendall.Text.Trim());
        }

        /// <summary>
        /// 向指定用户发送预览消息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btn_send_preview_OnClick(object sender, EventArgs e)
        {
          lab_send_preview_msg.Text=new SendPreview().SendPriviewText(_appidSecret,txt_send_preview.Text);
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
        /// 获取现有已经有的菜单
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btn_get_now_menu_OnClick(object sender, EventArgs e)
        {

            txt_now_menu.Text = new CustomerMenu().GetCustomerMenu(_appidSecret);

        }


        /// <summary>
        /// 删除现有菜单 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btn_delete_now_menu_OnClick(object sender, EventArgs e)
        {
            lab_delete_menu_msg.Text = new CustomerMenu().DeleteCustomerMenu(_appidSecret);
        }
    }
}