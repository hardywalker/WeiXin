using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WX_Tools.Entites;

namespace WeiXin_Web
{
    public partial class Index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            sender sender2=new sender()
            {
                toUserName = "123",
                fromUserName = "456",
                createTime = 123456
            };
            new MyClass(sender2).a();

         

        }

        protected void button1_OnClick(object sender, EventArgs e)
        {

          lab1.Text=  new WX_Tools.get_access_token().Get_access_token();
        }

        protected void button2_OnClick(object sender, EventArgs e)
        {
            Label1.Text =new WX_Tools.getcallbackip().getServerIPString();
        }

        static WX_Tools.Entites.sender sender1;

        public class MyClass
        {
            public MyClass(WX_Tools.Entites.sender objSender)
            {
                sender1 = objSender;
            }
            public void a()
            {
        HttpContext.Current.Response.Write(sender1.toUserName);
            }
        }

      
     


  
    }
}