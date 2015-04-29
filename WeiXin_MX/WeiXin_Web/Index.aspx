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
        测试号申请地址：http://mp.weixin.qq.com/debug/cgi-bin/sandbox?t=sandbox/login    <br />
        官方帮助文档：http://mp.weixin.qq.com/wiki/home/index.html
        <hr/>
       

  <asp:Button runat="server" ID="btn_get_access_token" OnClick="btn_get_access_token_OnClick" Text="获取access_token"/><br/>
        <asp:Label runat="server" ID="lab_access_token"></asp:Label><br/>
        <input type="button" id="btn_update_access_token" value="更新access_token" runat="server" OnServerClick="btn_update_access_token_OnServerClick"/>
        <hr/>
        <asp:Button runat="server" ID="btn_get_server_ip" OnClick="btn_get_server_ip_OnClick" Text="获取服务器ip"/><br/>
        <asp:Label runat="server" ID="lab_server_ip"></asp:Label>
        <hr/>

     

    <h1>上传图文消息素材【订阅号与服务号认证后均可用】 </h1>
    示例：{
   "articles": [{"thumb_media_id":"qI6_Ze_6PtV7svjolgs-rN6stStuHIjs9_DidOHaj0Q-mwvBelOXCFZiq2OsIU-p",
                        "author":"xxx",
			 "title":"Happy Day",
			 "content_source_url":"www.qq.com",
			 "content":"content",
			 "digest":"digest",
                        "show_cover_pic":"1"
		 },
		 {"thumb_media_id":"qI6_Ze_6PtV7svjolgs-rN6stStuHIjs9_DidOHaj0Q-mwvBelOXCFZiq2OsIU-p",
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
   "articles": [{"thumb_media_id":"yZUe2ECV77M1brCJHGJDT_HugdQjr5FZye4QR9abxEwwnFDAj38Gm8CD6f-VvVM_",
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
    
 
</body>
</html>
