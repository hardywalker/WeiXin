using System;
using System.Web.UI;
using WX_Tools;
using WX_Tools.Entites;

namespace WeiXin_Web
{
    public partial class Set : Page
    {
       AppidSecretToken _appidSecret=new AppidSecretToken();
        XmlReadWrite xmlReadWrite=new XmlReadWrite();

        protected void Page_Load(object sender, EventArgs e)
        {
            _appidSecret = xmlReadWrite.Read("/XML/", _appidSecret, "set.config") as AppidSecretToken;
            if (_appidSecret != null)
            {
                txt_appid.Text = _appidSecret.Appid;
                txt_secret.Text = _appidSecret.Secret;
                txt_token.Text = _appidSecret.Token;
            }
        }

        /// <summary>
        /// 保存配置信息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btn_save_set_OnClick(object sender, EventArgs e)
        {
            _appidSecret.Appid = txt_appid.Text;
            _appidSecret.Secret = txt_secret.Text;
            _appidSecret.Token = txt_token.Text;
            SaveConfig(_appidSecret);
        }


        private void SaveConfig(object obj)
        {
            xmlReadWrite.Write("/XML/", obj, "set.config");
        }
    }
}