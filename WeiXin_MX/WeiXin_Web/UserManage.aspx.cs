using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WX_Tools;
using WX_Tools.Entites;

namespace WeiXin_Web
{
    public partial class UserManage : System.Web.UI.Page
    {
        User user=new User();
        AppidSecretToken appidSecretToken=new AppidSecretToken();
        protected void Page_Load(object sender, EventArgs e)
        {
        
            appidSecretToken = new XmlReadWrite().Read("/XML/", appidSecretToken, "set.config") as AppidSecretToken;
    
        }

        /// <summary>
        /// 获取用户列表
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btn_get_user_list_OnClick(object sender, EventArgs e)
        {
            

          lab_user_list_json.Text= user.GetUserList(appidSecretToken);
        }


        /// <summary>
        /// 获取全部分组
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btn_get_all_groups_OnServerClick(object sender, EventArgs e)
        {
            lab_all_groups.InnerText = user.GetGroups(appidSecretToken);
        }
    }
}