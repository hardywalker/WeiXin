using System.IO;
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
        #region 获取用户列表  GET

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

            string access_token = new GetAccessToken().Get_access_token(appidSecret, "catch");
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



        #region  查询所有分组  GET

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
            string access_token = new GetAccessToken().Get_access_token(appidSecretToken, "catch");
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


        #region  创建分组  POST

        /// <summary>
        ///创建分组
        /// </summary>
        /// <param name="appidSecretToken"></param>
        /// <param name="strJson"></param>
        /// <returns></returns>
        public string CreateGroups(AppidSecretToken appidSecretToken, string strJson)
        {
            #region  使用说明 
            /**
             * 一个公众账号，最多支持创建100个分组。

                    接口调用请求说明
                    
                    http请求方式: POST（请使用https协议）
                    https://api.weixin.qq.com/cgi-bin/groups/create?access_token=ACCESS_TOKEN
                    POST数据格式：json
                    POST数据例子：{"group":{"name":"test"}}
                    
                    参数说明
                    参数 	说明
                    access_token 	调用接口凭证
                    name 	分组名字（30个字符以内）
                    
                    返回说明 正常时的返回JSON数据包示例：
                    
                    {
                        "group": {
                            "id": 107, 
                            "name": "test"
                        }
                    }
                    
                    参数说明
                    参数 	说明
                    id 	分组id，由微信分配
                    name 	分组名字，UTF8编码
                    
                    错误时的JSON数据包示例（该示例为AppID无效错误）：
                    
                    {"errcode":40013,"errmsg":"invalid appid"}

             */
            #endregion

            string result = "";
            byte[] postBytes = Encoding.UTF8.GetBytes(strJson);
            string access_token = new GetAccessToken().Get_access_token(appidSecretToken, "catch");
            string postUrl = string.Format(new ApiAddress().CreateGroupsUrl, access_token);
            HttpWebRequest httpWebRequest=WebRequest.Create(postUrl) as HttpWebRequest;
            httpWebRequest.Method = "POST";
            httpWebRequest.ContentType = "application/x-www-form-urlencoded;";
            httpWebRequest.ContentLength = postBytes.Length;


            Stream streamWriter = httpWebRequest.GetRequestStream();
            streamWriter.Write(postBytes,0,postBytes.Length);
            new DebugLog().BugWriteTxt("创建分组：" + strJson);
            streamWriter.Close();

            HttpWebResponse httpWebResponse = httpWebRequest.GetResponse() as HttpWebResponse;
            Stream streamRead = httpWebResponse.GetResponseStream();
            if (streamRead != null)
            {
                StreamReader streamReader=new StreamReader(streamRead,Encoding.UTF8);
                result = streamReader.ReadToEnd();
            }
            

            return result;
        }
        #endregion



        #region  查询用户所在分组  POST

        /// <summary>
        /// 根据OPENID查询出用户所在分组  POSt   返回用户分组ID
        /// </summary>
        /// <param name="appidSecretToken">AppidSecretToken对象 </param>
        /// <param name="openId">用户唯一识别码</param>
        /// <returns>返回json</returns>
        public string GetGroupId(AppidSecretToken appidSecretToken,string openId)
        {
            #region  使用说明
            /**
             * 通过用户的OpenID查询其所在的GroupID。 接口调用请求说明
                    
                    http请求方式: POST（请使用https协议）
                    https://api.weixin.qq.com/cgi-bin/groups/getid?access_token=ACCESS_TOKEN
                    POST数据格式：json
                    POST数据例子：{"openid":"od8XIjsmk6QdVTETa9jLtGWA6KBc"}
                    
                    参数说明
                    参数 	说明
                    access_token 	调用接口凭证
                    openid 	用户的OpenID
                    
                    返回说明 正常时的返回JSON数据包示例：
                    
                    {
                        "groupid": 102
                    }
                    
                    参数说明
                    参数 	说明
                    groupid 	用户所属的groupid
                    
                    错误时的JSON数据包示例（该示例为OpenID无效错误）：
                    
                    {"errcode":40003,"errmsg":"invalid openid"}

             */
            #endregion

            string result = "";

            string access_token = new GetAccessToken().Get_access_token(appidSecretToken, "catch");
            string postUrl = string.Format(new ApiAddress().GetIDGroupsUrl, access_token);
            byte[] postBytes = Encoding.UTF8.GetBytes(openId);

            HttpWebRequest httpWebRequest = WebRequest.Create(postUrl) as HttpWebRequest;
            httpWebRequest.Method = "POST";
            httpWebRequest.ContentType = "application/x-www-form-urlencoded;";
            httpWebRequest.ContentLength = postBytes.Length;

            Stream streamWrite = httpWebRequest.GetRequestStream();
            streamWrite.Write(postBytes,0,postBytes.Length);
            new DebugLog().BugWriteTxt("查询用户所在分组：" + openId);
            streamWrite.Close();

            HttpWebResponse httpWebResponse = httpWebRequest.GetResponse() as HttpWebResponse;
            Stream streamRead = httpWebResponse.GetResponseStream();

            if (streamRead != null)
            {
                StreamReader streamReader=new StreamReader(streamRead,Encoding.UTF8);
                result = streamReader.ReadToEnd();
            }




            return result;
        }

        #endregion 



        #region 修改分组名   POST 

        /// <summary>
        /// 根据groupid修改分组名称  POST
        /// </summary>
        /// <param name="appidSecretToken">AppidSecretToken对象</param>
        /// <param name="strJson">json字符串</param>
        /// <returns>返回结果</returns>
        public string UpdateGroupsName(AppidSecretToken appidSecretToken,string strJson)
        {
            #region 使用说明 
            /**
             * 接口调用请求说明

                    http请求方式: POST（请使用https协议）
                    https://api.weixin.qq.com/cgi-bin/groups/update?access_token=ACCESS_TOKEN
                    POST数据格式：json
                    POST数据例子：{"group":{"id":108,"name":"test2_modify2"}}
                    
                    参数说明
                    参数 	说明
                    access_token 	调用接口凭证
                    id 	分组id，由微信分配
                    name 	分组名字（30个字符以内）
                    
                    返回说明 正常时的返回JSON数据包示例：
                    
                    {"errcode": 0, "errmsg": "ok"}
                    
                    错误时的JSON数据包示例（该示例为AppID无效错误）：
                    
                    {"errcode":40013,"errmsg":"invalid appid"}

             */
            #endregion

            string result = "";
            string access_token = new GetAccessToken().Get_access_token(appidSecretToken, "catch");
            string postUrl = string.Format(new ApiAddress().UpdateGroupsUrl, access_token);
            byte[] postBytes = Encoding.UTF8.GetBytes(strJson);

            HttpWebRequest httpWebRequest = WebRequest.Create(postUrl) as HttpWebRequest;
            httpWebRequest.Method = "POST";
            httpWebRequest.ContentType = "application/x-www-form-urlencoded;";
            httpWebRequest.ContentLength = postBytes.Length;

            Stream stream = httpWebRequest.GetRequestStream();
            stream.Write(postBytes,0,postBytes.Length);
            new DebugLog().BugWriteTxt("修改分组名：" + strJson);
            stream.Close();
            HttpWebResponse httpWebResponse = httpWebRequest.GetResponse() as HttpWebResponse;
            Stream streamRead = httpWebResponse.GetResponseStream();
            if (streamRead != null)
            {
                StreamReader streamReader=new StreamReader(streamRead,Encoding.UTF8);
                result = streamReader.ReadToEnd();
            }

            return result;
        }
        #endregion


        #region 移动用户分组 POST

        /// <summary>
        /// 根据OPenid,以及指定分组id来移动用户到分组  POSt
        /// </summary>
        /// <param name="appidSecretToken">AppidSecretToken对象</param>
        /// <param name="strJson">字符串</param>
        /// <returns>返回结果</returns>
        public string UpdateMembers(AppidSecretToken appidSecretToken,string strJson)
        {
            #region 使用说明 
            /**
             * 接口调用请求说明

                    http请求方式: POST（请使用https协议）
                    https://api.weixin.qq.com/cgi-bin/groups/members/update?access_token=ACCESS_TOKEN
                    POST数据格式：json
                    POST数据例子：{"openid":"oDF3iYx0ro3_7jD4HFRDfrjdCM58","to_groupid":108}
                    
                    参数说明
                    参数 	说明
                    access_token 	调用接口凭证
                    openid 	用户唯一标识符
                    to_groupid 	分组id
                    
                    返回说明 正常时的返回JSON数据包示例：
                    
                    {"errcode": 0, "errmsg": "ok"}
                    
                    错误时的JSON数据包示例（该示例为AppID无效错误）：
                    
                    {"errcode":40013,"errmsg":"invalid appid"}

             */
            #endregion

            string result = "";
            string access_token = new GetAccessToken().Get_access_token(appidSecretToken, "catch");
            string postUrl = string.Format(new ApiAddress().UpdateMembersUrl, access_token);
            byte[] postBytes = Encoding.UTF8.GetBytes(strJson);

            HttpWebRequest httpWebRequest = WebRequest.Create(postUrl) as HttpWebRequest;
            httpWebRequest.Method = "POST";
            httpWebRequest.ContentType = "application/x-www-form-urlencoded;";
            httpWebRequest.ContentLength = postBytes.Length;

            Stream stream = httpWebRequest.GetRequestStream();
            stream.Write(postBytes, 0, postBytes.Length);
            new DebugLog().BugWriteTxt("移动用户分组：" + strJson);
            stream.Close();


            HttpWebResponse httpWebResponse = httpWebRequest.GetResponse() as HttpWebResponse;
            Stream streamRead = httpWebResponse.GetResponseStream();
            if (streamRead != null)
            {
                StreamReader streamReader = new StreamReader(streamRead, Encoding.UTF8);
                result = streamReader.ReadToEnd();
            }

            return result;
        }

        #endregion

        #region  批量移动用户分组   POST 

        /// <summary>
        /// 根据用户openid以及指定分组id,批量移动用户到指定分组，用户openid不能超过50个
        /// </summary>
        /// <param name="appidSecretToken">AppidSecretToken对象 </param>
        /// <param name="strJson">json字符串</param>
        /// <returns>返回结果</returns>
        public string BatchUpdateMembers(AppidSecretToken appidSecretToken, string strJson)
        {
            #region 使用说明 
            /**
             * 接口调用请求说明

                    http请求方式: POST（请使用https协议）
                    https://api.weixin.qq.com/cgi-bin/groups/members/batchupdate?access_token=ACCESS_TOKEN
                    POST数据格式：json
                    POST数据例子：{"openid_list":["oDF3iYx0ro3_7jD4HFRDfrjdCM58","oDF3iY9FGSSRHom3B-0w5j4jlEyY"],"to_groupid":108}
                    
                    参数说明
                    参数 	说明
                    access_token 	调用接口凭证
                    openid_list 	用户唯一标识符openid的列表（size不能超过50）
                    to_groupid 	分组id
                    
                    返回说明 正常时的返回JSON数据包示例：
                    
                    {"errcode": 0, "errmsg": "ok"}
                    
                    错误时的JSON数据包示例（该示例为AppID无效错误）：
                    
                    {"errcode":40013,"errmsg":"invalid appid"}

             */
            #endregion


            string result = "";
            string access_token = new GetAccessToken().Get_access_token(appidSecretToken, "catch");
            string postUrl = string.Format(new ApiAddress().BatchUpdateMembersUrl, access_token);
            byte[] postBytes = Encoding.UTF8.GetBytes(strJson);

            HttpWebRequest httpWebRequest = WebRequest.Create(postUrl) as HttpWebRequest;
            httpWebRequest.Method = "POST";
            httpWebRequest.ContentType = "application/x-www-form-urlencoded;";
            httpWebRequest.ContentLength = postBytes.Length;

            Stream stream = httpWebRequest.GetRequestStream();
            stream.Write(postBytes, 0, postBytes.Length);
            new DebugLog().BugWriteTxt("批量移动用户分组：" + strJson);
            stream.Close();



            HttpWebResponse httpWebResponse = httpWebRequest.GetResponse() as HttpWebResponse;
            Stream streamRead = httpWebResponse.GetResponseStream();
            if (streamRead != null)
            {
                StreamReader streamReader = new StreamReader(streamRead, Encoding.UTF8);
                result = streamReader.ReadToEnd();
            }

            return result;
        }
        #endregion
    }
}
