using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Serialization;
using WX_Tools.Entites;

namespace WeiXin_Web
{
    public partial class Set : System.Web.UI.Page
    {
       AppidSecretToken appidSecret=new AppidSecretToken();
        private string filePath;
        protected void Page_Load(object sender, EventArgs e)
        {
        filePath = Server.MapPath("/XML/Set.config");
            //如果文件存在，开始读取
        if (File.Exists(filePath)) { 

            //读取配置文件信息，并赋值给文本框 
            FileStream fileStream=new FileStream(filePath,FileMode.Open,FileAccess.Read,FileShare.ReadWrite);
            XmlSerializer xmlSerializer=new XmlSerializer(typeof(AppidSecretToken));
            appidSecret= xmlSerializer.Deserialize(fileStream) as AppidSecretToken;

            txt_appid.Text = appidSecret.Appid;
            txt_secret.Text = appidSecret.Secret;
        }
        }

        /// <summary>
        /// 保存配置信息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btn_save_set_OnClick(object sender, EventArgs e)
        {
            appidSecret.Appid = txt_appid.Text;
            appidSecret.Secret = txt_secret.Text;
            appidSecret.Token = txt_token.Text;
            SaveConfig(appidSecret);
        }


        private void SaveConfig(object obj)
        {
            filePath = Server.MapPath("/XML/Set.config");
            FileStream fileStream=new FileStream(filePath,FileMode.Create,FileAccess.Write,FileShare.ReadWrite);
            XmlSerializer xmlSerializer=new XmlSerializer(obj.GetType());
            xmlSerializer.Serialize(fileStream,obj);
        }
    }
}