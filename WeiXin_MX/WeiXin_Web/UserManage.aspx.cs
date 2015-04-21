using System;
using System.Web.UI;
using WeiXin_Web.Common;
using WX_Tools;
using WX_Tools.Entites;

namespace WeiXin_Web
{
    public partial class UserManage : Page
    {
        readonly User _user=new User();
        AppidSecretToken _appidSecret=new AppidSecretToken();
        CommonClass _commonClass = new CommonClass();

        protected void Page_Load(object sender, EventArgs e)
        {
        
       if (IsPostBack)
            {

                //获得AppidSecretToken对象
                _appidSecret = _commonClass.GetAppidSecretToken();

            }
    
        }

        /// <summary>
        /// 获取用户列表
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btn_get_user_list_OnClick(object sender, EventArgs e)
        {
            

        lab_user_list_json.Text= _user.GetUserList(_commonClass.Get_access_token(_appidSecret,"catch"));
        }


        /// <summary>
        /// 获取全部分组
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btn_get_all_groups_OnServerClick(object sender, EventArgs e)
        {
            lab_all_groups.InnerText = _user.GetGroups(_commonClass.Get_access_token(_appidSecret, "catch"));
        }


        /// <summary>
        /// 创建分组
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btn_create_groups_OnServerClick(object sender, EventArgs e)
        {
            lab_create_groups_msg.Text = _user.CreateGroups(_commonClass.Get_access_token(_appidSecret, "catch"), txt_create_groups_json.Text.Trim());


        }

        /// <summary>
        /// 查询用户所在分组
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btn_getGroupId_OnServerClick(object sender, EventArgs e)
        {
            lab_getgroupid_msg.InnerText = _user.GetGroupId(_commonClass.Get_access_token(_appidSecret, "catch"), txt_getgroupid.Value.Trim());
        }

        /// <summary>
        /// 修改分组名
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btn_updateGroup_OnServerClick(object sender, EventArgs e)
        {
            lab_updateGroup_msg.InnerText = _user.UpdateGroupsName(_commonClass.Get_access_token(_appidSecret, "catch"), txt_updateGroup.Value.Trim());
        }

        /// <summary>
        /// 移动用户分组
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btn_update_members_OnServerClick(object sender, EventArgs e)
        {
            lab_update_members_msg.InnerText = _user.UpdateMembers(_commonClass.Get_access_token(_appidSecret, "catch"),txt_update_members.Value.Trim());
        }

        /// <summary>
        /// 批量移动用户分组
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btn_batch_update_members_OnServerClick(object sender, EventArgs e)
        {
            lab_batch_update_members_msg.InnerText = _user.BatchUpdateMembers(_commonClass.Get_access_token(_appidSecret, "catch"),txt_batch_update_members.Value.Trim());
        }
    }
}