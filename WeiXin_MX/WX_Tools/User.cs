using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using WX_Tools.Entites;

namespace WX_Tools
{
    /// <summary>
    /// 用户管理
    /// </summary>
    public class User
    {
        #region 获取用户列表

        /// <summary>
        /// 获取用户列表  最大一次获取10000，获取更多的话，需要写上next_openid
        /// </summary>
        /// <param name="appidSecret">appidSecret对象</param>
        /// <param name="nextOpenid">根据此openid获取以后的用户列表，可不填写</param>
        public string GetUserList(AppidSecretToken appidSecret, string nextOpenid = "")
        {
            #region 使用说明

            /*
             * 公众号可通过本接口来获取帐号的关注者列表，关注者列表由一串OpenID（加密后的微信号，每个用户对每个公众号的OpenID是唯一的）组成。
             * 一次拉取调用最多拉取10000个关注者的OpenID，可以通过多次拉取的方式来满足需求。

                接口调用请求说明
                
                http请求方式: GET（请使用https协议）
                https://api.weixin.qq.com/cgi-bin/user/get?access_token=ACCESS_TOKEN&next_openid=NEXT_OPENID
                
                参数 	是否必须 	说明
                access_token 	是 	调用接口凭证
                next_openid 	是 	第一个拉取的OPENID，不填默认从头开始拉取
                
                返回说明
                
                正确时返回JSON数据包：
                
                {"total":2,"count":2,"data":{"openid":["","OPENID1","OPENID2"]},"next_openid":"NEXT_OPENID"}
                
                参数 	说明
                total 	关注该公众账号的总用户数
                count 	拉取的OPENID个数，最大值为10000
                data 	列表数据，OPENID的列表
                next_openid 	拉取列表的后一个用户的OPENID
                
                错误时返回JSON数据包（示例为无效AppID错误）：
                
                {"errcode":40013,"errmsg":"invalid appid"}

             */

            #endregion

            string result = "";

            string access_token = new GetAccessToken().Get_access_token(appidSecret);
            string getUrl = string.Format(new ApiAddress().GetUserUrl, access_token, nextOpenid);

            HttpWebRequest httpWebRequest = WebRequest.Create(getUrl) as HttpWebRequest;

            httpWebRequest.Method = "GET";
            httpWebRequest.ContentType = "application/json; charset=utf-8";

            HttpWebResponse httpWebResponse = httpWebRequest.GetResponse() as HttpWebResponse;
            Stream stream = httpWebResponse.GetResponseStream();
            if (stream != null)
            {
                StreamReader streamReader = new StreamReader(stream, Encoding.UTF8);
                result = streamReader.ReadToEnd();
            }

            return result;



        }

        #endregion



        #region  查询所有分组

        /// <summary>
        /// 查询所有分组  GET  方式   传入AppidSecretToken对象
        /// </summary>
        /// <param name="appidSecretToken">AppidSecretToken对象</param>
        /// <returns>json字符串</returns>
        public string GetGroups(AppidSecretToken appidSecretToken)
        {
            #region 使用说明

            /**
             * 接口调用请求说明

                        http请求方式: GET（请使用https协议）
                        https://api.weixin.qq.com/cgi-bin/groups/get?access_token=ACCESS_TOKEN
                        
                        参数说明
                        参数 	说明
                        access_token 	调用接口凭证
                        
                        返回说明 正常时的返回JSON数据包示例：
                        
                        {
                            "groups": [
                                {
                                    "id": 0, 
                                    "name": "未分组", 
                                    "count": 72596
                                }, 
                                {
                                    "id": 1, 
                                    "name": "黑名单", 
                                    "count": 36
                                }, 
                                {
                                    "id": 2, 
                                    "name": "星标组", 
                                    "count": 8
                                }, 
                                {
                                    "id": 104, 
                                    "name": "华东媒", 
                                    "count": 4
                                }, 
                                {
                                    "id": 106, 
                                    "name": "★不测试组★", 
                                    "count": 1
                                }
                            ]
                        }
                        
                        参数说明
                        参数 	说明
                        groups 	公众平台分组信息列表
                        id 	分组id，由微信分配
                        name 	分组名字，UTF8编码
                        count 	分组内用户数量
                        
                        错误时的JSON数据包示例（该示例为AppID无效错误）：
                        
                        {"errcode":40013,"errmsg":"invalid appid"}

             */

            #endregion

            string result = "";
            string access_token = new GetAccessToken().Get_access_token(appidSecretToken);
            string getUrl = string.Format(new ApiAddress().GetGroupsUrl, access_token);
            HttpWebRequest httpWebRequest = WebRequest.Create(getUrl) as HttpWebRequest;
            httpWebRequest.Method = "GET";
            httpWebRequest.ContentType = "application/json;charset=utf-8";

            HttpWebResponse httpWebResponse = httpWebRequest.GetResponse() as HttpWebResponse;
            Stream stream = httpWebResponse.GetResponseStream();
            if (stream != null)
            {
                StreamReader streamReader=new StreamReader(stream,Encoding.UTF8);
                result = streamReader.ReadToEnd();
            }
            return result;
        }
        #endregion

    }
}
