using System;
using System.Web.UI;
using WeiXin_Web.Common;
using WX_Tools;
using WX_Tools.Entites;

namespace WeiXin_Web
{
    public partial class Index : Page
    {
        private WeiXinConfiguration _weiXinConfiguration;
        CommonClass _commonClass=new CommonClass();


 
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack)
            {
                _weiXinConfiguration = _commonClass.GetConfiguration();
            }
      
        }
        

       


        /// <summary>
        /// 获取服务器ip
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btn_get_server_ip_OnClick(object sender, EventArgs e)
        {

            lab_server_ip.Text = _commonClass.GET_IP_List(_weiXinConfiguration);
        }

       



        /// <summary>
        /// 获取access_token
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btn_get_access_token_OnClick(object sender, EventArgs e)
        {

            string accesstoken = _commonClass.Get_access_token(_weiXinConfiguration, "catch");
            new DebugLog().BugWriteTxt(new Log() { LogTxtPhyPath = "/ErrorTXT/" }.LogTxtPhyPath, accesstoken);
            lab_access_token.Text = accesstoken;
        }





        /// <summary>
        /// 更新access_token
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btn_update_access_token_OnServerClick(object sender, EventArgs e)
        {
            lab_access_token.Text = _commonClass.Get_access_token(_weiXinConfiguration, "server");
       
        }




       
    }
}