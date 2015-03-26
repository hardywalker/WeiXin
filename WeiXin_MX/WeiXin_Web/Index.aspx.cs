using System;
using System.Text;
using System.Web;
using System.Web.UI;
using WX_Tools;
using WX_Tools.Entites;

namespace WeiXin_Web
{
    public partial class Index : Page
    {
      public  AppidSecret appidSecret=new AppidSecret();

        protected void Page_Load(object sender, EventArgs e)
        {
            appidSecret.appid = txt_appid.Text;
            appidSecret.secret = txt_secret.Text;


        }
        

        /// <summary>
        /// 创建菜单
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btn_createMenu_OnClick(object sender, EventArgs e)
        {
       
            lab_menu_msg.InnerText = "创建菜单结果：" +
                                     new CustomerMenu().CreateCustomerMenu(appidSecret, txt_menu.ToString().Trim());

        }

        /// <summary>
        /// 获取access_token
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btn_get_access_token_OnClick(object sender, EventArgs e)
        {
            lab_access_token.Text = new GetAccessToken().Get_access_token(appidSecret);
        }

        /// <summary>
        /// 获取服务器ip
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btn_get_server_ip_OnClick(object sender, EventArgs e)
        {
            lab_server_ip.Text = new Getcallbackip().getServerIPString(appidSecret);
        }



    }
}