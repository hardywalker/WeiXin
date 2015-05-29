using System;
using System.Web.UI;

namespace WeiXin_Web
{
    public partial class testUrl : Page
    {
        protected string pageTitle;
        protected void Page_Load(object sender, EventArgs e)
        {
         string getAction=Request.QueryString["action"];
            ExecuteHandle(getAction);
        }

        /// <summary>
        /// 处理方法
        /// </summary>
        /// <param name="action"></param>
        private void ExecuteHandle(string action)
        {

            switch (action)
            {
                case "hbxw":
                    pageTitle = "环保新闻";
                    break;
                case "kqzlbg":
                    pageTitle = "空气质量报告";
                    break;
                case "pfhmd":
                    pageTitle = "排放黑名单";
                    break;
                case "cxqyxx":
                    pageTitle = "查询企业信息";
                    break;
                case "bdxx":
                    pageTitle = "绑定信息";
                    break;
                case "qyjbxx":
                    pageTitle = "企业基本信息";
                    break;
                case "qypfbz":
                    pageTitle = "企业排放标准";
                    break;
                case "qysjpfl":
                    pageTitle = "企业实际排放量";
                    break;
                case "sszscx":
                    pageTitle = "实时指数查询";
                    break;
                case "zxts":
                    pageTitle = "在线投诉";
                    break;
                case "mjcs":
                    pageTitle = "媒介传送";
                    break;
                default:
                    pageTitle = "测试信息";
                    break;
            }
        }
    }
}