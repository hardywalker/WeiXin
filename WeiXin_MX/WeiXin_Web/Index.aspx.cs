using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WeiXin_Web
{
    public partial class Index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
           
            File.WriteAllText(Server.MapPath("/ErrorTXT/" + DateTime.Now.ToString("yyyy-MM-dd-HH-mm-ss") + ".txt"), "访问Index页");
            List<model1> modelList = new List<model1>();
            for (int i = 0; i < 10; i++)
            {
                model1 modelp = new model1()
                {
                    Title = "我是第" + (i + 1),
                    Description = "描述" + (i + 1),
                    PicUrl = "路径" + (i + 1),
                    Url = "Url" + (i + 1)
                };
                modelList.Add(modelp);
            }
            string a = modelList.Aggregate("", (current, modelc) => current + (modelc.Title + "|" + modelc.Description + "|" + modelc.PicUrl + "|" + modelc.Url + "*"));

            label2.InnerText = a;
        }

        protected void button1_OnClick(object sender, EventArgs e)
        {

          lab1.Text=  new WX_Tools.get_access_token().Get_access_token();
        }

        protected void button2_OnClick(object sender, EventArgs e)
        {
            Label1.Text =new WX_Tools.getcallbackip().getServerIPString();
        }




        public class model1
        {
            public string Title { get; set; }
            public string Description { get; set; }
            public string PicUrl { get; set; }
            public string Url { get; set; }
        }
    }
}