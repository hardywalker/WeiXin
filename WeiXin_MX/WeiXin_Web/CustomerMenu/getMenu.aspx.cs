using System;
using System.Web.UI;
using WeiXin_Web.Common;
using WX_Tools.Entites;

namespace WeiXin_Web.CustomerMenu
{
    public partial class getMenu : Page
    {
        private WeiXinConfiguration _weiXinConfiguration = new WeiXinConfiguration();
        CommonClass _commonClass = new CommonClass();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// 获取已经有的菜单
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btn_get_now_menu_OnClick(object sender, EventArgs e)
        {

            txt_now_menu.Text = new WX_Tools.CustomerMenu().GetCustomerMenu(_commonClass.Get_access_token(_weiXinConfiguration, "catch"));

        }
    }
}