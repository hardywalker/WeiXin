using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WX_Tools;
using WX_Tools.Entites;

namespace WeiXin_Web
{
    public partial class Index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {




        }

        protected void button1_OnClick(object sender, EventArgs e)
        {

            lab1.Text = new WX_Tools.GetAccessToken().Get_access_token();
        }

        protected void button2_OnClick(object sender, EventArgs e)
        {
            Label1.Text = new WX_Tools.Getcallbackip().getServerIPString();
        }


        /// <summary>
        /// 创建菜单
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btn_createMenu_OnClick(object sender, EventArgs e)
        {
            StringBuilder postDataStringBuilder = new StringBuilder();
            postDataStringBuilder.Append("{");
            postDataStringBuilder.Append("\"button\":");
            postDataStringBuilder.Append("[");

            postDataStringBuilder.Append("{");
            postDataStringBuilder.Append("\"name\":\"菜单一\",\"sub_button\":");
            postDataStringBuilder.Append("[");

            postDataStringBuilder.Append("{");
            postDataStringBuilder.AppendFormat("\"type\":\"{0}\",\"name\":\"菜单一一\",\"key\":\"menu1_1\"", AllEnum.CustomerMenuButtonEvent.click.ToString());
            postDataStringBuilder.Append("},");
            postDataStringBuilder.Append("{");
            postDataStringBuilder.AppendFormat("\"type\":\"{0}\",\"name\":\"菜单一二\",\"key\":\"menu1_2\"", AllEnum.CustomerMenuButtonEvent.click.ToString());
            postDataStringBuilder.Append("},");
            postDataStringBuilder.Append("{");
            postDataStringBuilder.AppendFormat("\"type\":\"{0}\",\"name\":\"菜单一三\",\"key\":\"menu1_3\"", AllEnum.CustomerMenuButtonEvent.click.ToString());
            postDataStringBuilder.Append("}");


            postDataStringBuilder.Append("]");
            postDataStringBuilder.Append("},");


            postDataStringBuilder.Append("{");
            postDataStringBuilder.Append("\"name\":\"菜单二\",\"sub_button\":");
            postDataStringBuilder.Append("[");

            postDataStringBuilder.Append("{");
            postDataStringBuilder.AppendFormat("\"type\":\"{0}\",\"name\":\"菜单二一\",\"key\":\"menu2_1\"", AllEnum.CustomerMenuButtonEvent.click.ToString());
            postDataStringBuilder.Append("},");
            postDataStringBuilder.Append("{");
            postDataStringBuilder.AppendFormat("\"type\":\"{0}\",\"name\":\"菜单二二\",\"key\":\"menu2_2\"", AllEnum.CustomerMenuButtonEvent.click.ToString());
            postDataStringBuilder.Append("},");
            postDataStringBuilder.Append("{");
            postDataStringBuilder.AppendFormat("\"type\":\"{0}\",\"name\":\"菜单二三\",\"key\":\"menu2_3\"", AllEnum.CustomerMenuButtonEvent.click.ToString());
            postDataStringBuilder.Append("}");


            postDataStringBuilder.Append("]");
            postDataStringBuilder.Append("},");


            postDataStringBuilder.Append("{");
            postDataStringBuilder.Append("\"name\":\"菜单三\",\"sub_button\":");
            postDataStringBuilder.Append("[");

            postDataStringBuilder.Append("{");
            postDataStringBuilder.AppendFormat("\"type\":\"{0}\",\"name\":\"菜单三一\",\"key\":\"menu3_1\"", AllEnum.CustomerMenuButtonEvent.click.ToString());
            postDataStringBuilder.Append("},");
            postDataStringBuilder.Append("{");
            postDataStringBuilder.AppendFormat("\"type\":\"{0}\",\"name\":\"菜单三二\",\"key\":\"menu3_2\"", AllEnum.CustomerMenuButtonEvent.click.ToString());
            postDataStringBuilder.Append("},");
            postDataStringBuilder.Append("{");
            postDataStringBuilder.AppendFormat("\"type\":\"{0}\",\"name\":\"菜单三三\",\"key\":\"menu3_3\"", AllEnum.CustomerMenuButtonEvent.click.ToString());
            postDataStringBuilder.Append("}");


            postDataStringBuilder.Append("]");
            postDataStringBuilder.Append("}");

            postDataStringBuilder.Append("]");
            postDataStringBuilder.Append("}");

            HttpContext.Current.Response.Write("创建菜单结果：" + new CustomerMenu().CreateCustomerMenu(postDataStringBuilder.ToString()));
        }
    }
}