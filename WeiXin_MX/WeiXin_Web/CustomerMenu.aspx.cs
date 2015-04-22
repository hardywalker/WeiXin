using System;
using System.Web.Configuration;
using System.Web.UI;
using WeiXin_Web.Common;
using WX_Tools;
using WX_Tools.Entites;

namespace WeiXin_Web
{
    public partial class CustomerMenu : Page
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

          lab_menu_msg.InnerText = "创建菜单结果：" + new WX_Tools.CustomerMenu().CreateCustomerMenu(_commonClass.Get_access_token(_weiXinConfiguration,"catch"), txt_menu.Text.Trim());

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


        /// <summary>
        /// 删除现有菜单 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btn_delete_now_menu_OnClick(object sender, EventArgs e)
        {
            lab_delete_menu_msg.Text = new WX_Tools.CustomerMenu().DeleteCustomerMenu(_commonClass.Get_access_token(_weiXinConfiguration, "catch"));
        }

    }
}