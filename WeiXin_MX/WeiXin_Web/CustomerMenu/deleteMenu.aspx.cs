using System;
using System.Web.UI;
using WeiXin_Web.Common;
using WX_Tools.Entites;

namespace WeiXin_Web.CustomerMenu
{
    public partial class deleteMenu : Page
    {

        private WeiXinConfiguration _weiXinConfiguration = new WeiXinConfiguration();
        CommonClass _commonClass = new CommonClass();
        protected void Page_Load(object sender, EventArgs e)
        {
          
        }

        /// <summary>
        /// 删除现有菜单 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btn_delete_now_menu_OnClick(object sender, EventArgs e)
        {
            lab_delete_menu_msg.Text = WX_Tools.CustomerMenu.DeleteCustomerMenu(_commonClass.Get_access_token(_weiXinConfiguration, "catch"));
        }
    }
}