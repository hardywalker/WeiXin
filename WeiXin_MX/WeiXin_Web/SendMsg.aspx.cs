using System;
using System.Collections.Generic;
using System.Web.UI;
using WeiXin_Web.Common;
using WX_Tools;
using WX_Tools.Entites;

namespace WeiXin_Web
{
    public partial class SendMsg : Page
    {
        private WeiXinConfiguration _weiXinConfiguration = new WeiXinConfiguration();
        readonly MessageMass _messageMass=new MessageMass();
        CommonClass _commonClass = new CommonClass();
        protected void Page_Load(object sender, EventArgs e)
        {

            if (IsPostBack)
            {
                //AppidSecretToken对象
                _weiXinConfiguration = _commonClass.GetConfiguration();

            }

        }


        /// <summary>
        /// 根据用户分组群发消息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btn_sendall_OnClick(object sender, EventArgs e)
        {
            lab_send_all_msg.Text = _messageMass.MessageMassSendAll(_commonClass.Get_access_token(_weiXinConfiguration, "catch"), txt_sendall.Text.Trim());
        }

        /// <summary>
        /// 向指定用户发送预览消息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btn_send_preview_OnClick(object sender, EventArgs e)
        {
            lab_send_preview_msg.Text = _messageMass.MessageMassPreview(_commonClass.Get_access_token(_weiXinConfiguration, "catch"), txt_send_preview.Text);
        }

        /// <summary>
        /// 根据用户列表进行群发
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btn_sendmsg_openlist_OnServerClick(object sender, EventArgs e)
        {
            lab_sendmsg_openlist_msg.InnerText = _messageMass.MessageMassSend(_commonClass.Get_access_token(_weiXinConfiguration, "catch"), txt_send_openlist.Value.Trim());
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btn_sendMaterialNews_OnServerClick(object sender, EventArgs e)
        {
          List<News> allList=new List<News>();
            for (int i = 0; i < 5; i++)
            {
                News news = new News();
                news.Title = "标题"+i;
                news.Description = "描述" + i;
                news.PicUrl = "http://tuchong.com/381497/6898938/7481525/";
                allList.Add(news);
            }


            

        }
    }
}