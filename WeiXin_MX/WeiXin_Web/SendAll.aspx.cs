using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WeiXin_Web
{
    public partial class SendAll : System.Web.UI.Page
    {
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

            new WX_Tools.SendAll().SendAllText(TextBox1.Text);
        }

        /// <summary>
        /// 发送预览文本消息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Button2_OnClick(object sender, EventArgs e)
        {
            new WX_Tools.SendPreview().SendPriviewText(TextBox2.Text);
        }
    }
}