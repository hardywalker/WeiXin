﻿using System;
using System.Web.UI;
using WX_Tools;
using WX_Tools.Entites;

namespace WeiXin_Web
{
    public partial class Set : Page
    {
        WeiXinConfiguration _configuration = new WeiXinConfiguration();
   
        
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                
                _configuration = XmlReadWrite.Read("/XML/", _configuration, "set.config") as WeiXinConfiguration;
                if (_configuration != null)
                {
                    txt_appid.Text = _configuration.Appid;
                    txt_secret.Text = _configuration.AppSecret;
                    txt_token.Text = _configuration.Token;
                    txt_encodingaeskey.Value = _configuration.EncodingAESKey;
                }
            }
          
        }

        /// <summary>
        /// 保存配置信息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btn_save_set_OnClick(object sender, EventArgs e)
        {
            _configuration.Appid = txt_appid.Text;
            _configuration.AppSecret = txt_secret.Text;
            _configuration.Token = txt_token.Text;
            _configuration.EncodingAESKey = txt_encodingaeskey.Value.Trim();
            SaveConfig(_configuration);
        }


        private void SaveConfig(object obj)
        {
            XmlReadWrite.Write("/XML/", obj, "set.config");
        }
    }
}