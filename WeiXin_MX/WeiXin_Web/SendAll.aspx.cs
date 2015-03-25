using System;
using System.Web.UI;
using WX_Tools;
using WX_Tools.Entites;

namespace WeiXin_Web
{
    public partial class SendAll : Page
    {
        AppidSecret appidSecret=new AppidSecret();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// 群发文本消息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Button1_OnClick(object sender, EventArgs e)
        {

            new WX_Tools.SendAll().SendAllText(appidSecret,TextBox1.Text);
        }

        /// <summary>
        /// 发送预览文本消息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Button2_OnClick(object sender, EventArgs e)
        {
            new SendPreview().SendPriviewText(appidSecret,TextBox2.Text);
        }
    }
}