<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="WeiXin_Web.Index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>微信公众账号测试平台</title>
    <script type="text/javascript" src="Scripts/jquery-2.1.3.min.js"></script>
    <script type="text/javascript" src="UserJS/LoadHeader.js"></script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <div id="header"></div>
        测试号申请地址：http://mp.weixin.qq.com/debug/cgi-bin/sandbox?t=sandbox/login<br />
        官方帮助文档：http://mp.weixin.qq.com/wiki/home/index.html
        <hr/>
        <h1>配置信息</h1>
        公司账号<br/>
        wxa8f97bba9ebb7d27<br/>
        1f9381bd5c8f08b0c4dda7ac55b19769 <br/>
        测试账号<br />
        wxa29576cd9bb8fa92<br/>
        841a341dc0e60c105a14ee9734d51319
        <hr/>
  <asp:Button runat="server" ID="btn_get_access_token" OnClick="btn_get_access_token_OnClick" Text="获取access_token"/><br/>
        <asp:Label runat="server" ID="lab_access_token"></asp:Label>
        <hr/>
        <asp:Button runat="server" ID="btn_get_server_ip" OnClick="btn_get_server_ip_OnClick" Text="获取服务器ip"/><br/>
        <asp:Label runat="server" ID="lab_server_ip"></asp:Label>
        <hr/>
        
        <hr />
     
         <h1>群发文本消息</h1><br/>
       根据分组进行群发文本消息，发送给全部关注者is_to_all为true: {"filter":{"is_to_all":true,"group_id": "2"},"text": {"content": "这里是内容"},"msgtype": "text"}<br/>
        根据OpenID列表群发【订阅号不可用，服务号认证后可用】 :{"touser":["OPENID1","OPENID2"],"msgtype": "text","text": { "content": "hello from boxer."}}
        <br />
        <asp:TextBox ID="txt_sendall" runat="server" TextMode="MultiLine" Width="100%" Height="100px">{"filter":{"is_to_all":true,"group_id": "2"},"text": {"content": "这里是内容"},"msgtype": "text"}</asp:TextBox><br/>
        <asp:Button ID="btn_sendall" runat="server" Text="群发文本消息" OnClick="btn_sendall_OnClick" /><asp:Label runat="server" ID="lab_send_all_msg"></asp:Label>
        <br/>
        <h1>发送预览消息</h1><br/>
        文本格式：{"touser":"o8__KjrxQiTety8PbZb7noPse77s","text":{"content":"CONTENT"},"msgtype":"text"}<br/>
           <asp:TextBox ID="txt_send_preview" runat="server" TextMode="MultiLine" Width="100%" Height="65px">{"touser":"o8__KjrxQiTety8PbZb7noPse77s","text":{"content":"CONTENT"},"msgtype":"text"}</asp:TextBox><br/>
        <asp:Button ID="btn_send_preview" runat="server" Text="预览文本消息"  OnClick="btn_send_preview_OnClick"/><asp:Label runat="server" ID="lab_send_preview_msg"></asp:Label>
           <hr/>
    <h1>上传图文消息素材【订阅号与服务号认证后均可用】 </h1>
    示例：{
   "articles": [
		 {
                        "thumb_media_id":"qI6_Ze_6PtV7svjolgs-rN6stStuHIjs9_DidOHaj0Q-mwvBelOXCFZiq2OsIU-p",
                        "author":"xxx",
			 "title":"Happy Day",
			 "content_source_url":"www.qq.com",
			 "content":"content",
			 "digest":"digest",
                        "show_cover_pic":"1"
		 },
		 {
                        "thumb_media_id":"qI6_Ze_6PtV7svjolgs-rN6stStuHIjs9_DidOHaj0Q-mwvBelOXCFZiq2OsIU-p",
                        "author":"xxx",
			 "title":"Happy Day",
			 "content_source_url":"www.qq.com",
			 "content":"content",
			 "digest":"digest",
                        "show_cover_pic":"0"
		 }
   ]
}
    <br/>
    <asp:TextBox TextMode="MultiLine" runat="server" ID="txt_send_tuwen" Width="100%" Height="300px">{
   "articles": [
		 {
                        "thumb_media_id":"yZUe2ECV77M1brCJHGJDT_HugdQjr5FZye4QR9abxEwwnFDAj38Gm8CD6f-VvVM_",
                        "author":"anyangmaxin",
			 "title":"这是一条测试消息",
			 "content_source_url":"www.qq.com",
			 "content":"这里是详细内容这里是详细内容这里是详细内容这里是详细内容这里是详细内容这里是详细内容这里是详细内容这里是详细内容这里是详细内容这里是详细内容",
			 "digest":"这里是消息简介",
                        "show_cover_pic":"1"
		 }
   ]
}</asp:TextBox>
       <asp:Button ID="btn_send_tuwen" runat="server" Text="提交图文消息素材"  OnClick="btn_send_tuwen_OnClick"/><asp:Label runat="server" ID="lab_send_tuwen_msg"></asp:Label>

    </div>
    </form>
    <hr/>
      <form action="ImageUpload.ashx" method="post" enctype="multipart/form-data">
        <input id="File1" type="file" name="image0" /><br />
        <input id="Submit1" type="submit" value="上传临时素材" />
    </form> 
 
</body>
</html>
