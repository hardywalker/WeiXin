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


        /// <summary>
        /// 创建分组
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btn_create_groups_OnServerClick(object sender, EventArgs e)
        {
            lab_create_groups_msg.Text=new User().CreateGroups(appidSecretToken, txt_create_groups_json.Text.Trim());


        }

        /// <summary>
        /// 查询用户所在分组
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btn_getGroupId_OnServerClick(object sender, EventArgs e)
        {
            lab_getgroupid_msg.InnerText = new User().GetGroupId(appidSecretToken, txt_getgroupid.Value.Trim());
        }

        /// <summary>
        /// 修改分组名
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btn_updateGroup_OnServerClick(object sender, EventArgs e)
        {
            lab_updateGroup_msg.InnerText = new User().UpdateGroupsName(appidSecretToken, txt_updateGroup.Value.Trim());
        }

        /// <summary>
        /// 移动用户分组
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btn_update_members_OnServerClick(object sender, EventArgs e)
        {
            lab_update_members_msg.InnerText = new User().UpdateMembers(appidSecretToken,
                txt_update_members.Value.Trim());
        }

        /// <summary>
        /// 批量移动用户分组
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btn_batch_update_members_OnServerClick(object sender, EventArgs e)
        {
            lab_batch_update_members_msg.InnerText = new User().BatchUpdateMembers(appidSecretToken,
                txt_batch_update_members.Value.Trim());
        }
    }
}