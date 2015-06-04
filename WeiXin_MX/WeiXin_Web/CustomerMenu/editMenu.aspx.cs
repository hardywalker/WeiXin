using System;
using System.Web.UI;
using WeiXin_Web.Common;
using WX_Tools;
using WX_Tools.Entites;

namespace WeiXin_Web.CustomerMenu
{
    public partial class createMenu : Page
    {
        private WeiXinConfiguration _weiXinConfiguration = new WeiXinConfiguration();
        CommonClass _commonClass = new CommonClass();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack)
            {
                //为AppidSecretToken对象赋值
                _weiXinConfiguration = _commonClass.GetConfiguration();
            }
        }


        /// <summary>
        /// 创建菜单
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btn_createMenu_OnClick(object sender, EventArgs e)
        {

            new DebugLog().BugWriteTxt("/ErrorTXT/", txt_menu.Text.Trim());

            lab_menu_msg.InnerText = "创建菜单结果：" + new WX_Tools.CustomerMenu().CreateCustomerMenu(_commonClass.Get_access_token(_weiXinConfiguration, "catch"), txt_menu.Text.Trim());

        }

    }
}