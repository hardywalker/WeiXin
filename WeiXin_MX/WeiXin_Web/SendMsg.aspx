<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SendMsg.aspx.cs" Inherits="WeiXin_Web.SendMsg" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>发送消息管理</title>
       <script type="text/javascript" src="Scripts/jquery-2.1.3.min.js"></script>
      <script type="text/javascript" src="UserJS/LoadHeader.js"></script>
</head>
<body>
    <form id="form1" runat="server">
        <div>
    <div id="header"></div>
             <h1>群发消息</h1>
            <h2>根据分组进行群发文本消息</h2>
       根据分组进行群发文本消息，发送给全部关注者is_to_all为true: {"filter":{"is_to_all":true,"group_id": "2"},"text": {"content": "这里是内容"},"msgtype": "text"}<br/>
       <asp:TextBox ID="txt_sendall" runat="server" TextMode="MultiLine" Width="100%" Height="100px">{"filter":{"is_to_all":true,"group_id": "2"},"text": {"content": "这里是内容"},"msgtype": "text"}</asp:TextBox><br/>
        <asp:Button ID="btn_sendall" runat="server" Text="群发文本消息" OnClick="btn_sendall_OnClick" /><asp:Label runat="server" ID="lab_send_all_msg"></asp:Label><br/>
            <hr/>

            <h2>根据OpenID列表群发</h2>
        根据OpenID列表群发【订阅号不可用，服务号认证后可用】 :{"touser":["OPENID1","OPENID2"],"msgtype": "text","text": { "content": "hello from boxer."}}<br/>
            <textarea runat="server" id="txt_send_openlist" value='{"touser":["OPENID1","OPENID2"],"msgtype": "text","text": { "content": "hello from boxer."}}' style="width: 100%; height: 50px"></textarea>
            <input type="button" runat="server" id="btn_sendmsg_openlist" value="根据用户列表群发" OnServerClick="btn_sendmsg_openlist_OnServerClick"/><br/>
            <span runat="server" id="lab_sendmsg_openlist_msg"></span>
       
        <hr/>
            <h1>上传图文消息素材【订阅号与服务号认证后均可用】</h1>
            示例：{"articles": [{"thumb_media_id":"qI6_Ze_6PtV7svjolgs-rN6stStuHIjs9_DidOHaj0Q-mwvBelOXCFZiq2OsIU-p","author":"xxx","title":"Happy Day",
			 "content_source_url":"www.qq.com","content":"content","digest":"digest","show_cover_pic":"1"},{
            "thumb_media_id":"qI6_Ze_6PtV7svjolgs-rN6stStuHIjs9_DidOHaj0Q-mwvBelOXCFZiq2OsIU-p","author":"xxx",
			 "title":"Happy Day","content_source_url":"www.qq.com","content":"content","digest":"digest","show_cover_pic":"0"}]}
            <textarea  runat="server" id="txt_uploadMaterialMpnNews" style="width: 100%; height: 80px;"></textarea>
            <input type="button" runat="server" id="btn_uploadMaterialMpnNews" value="上传图文消息素材" OnServerClick="btn_uploadMaterialMpnNews_OnServerClick"/>
            <span runat="server" id="lab_materialMpnNewsMsg"></span>
            <hr/>
        <h1>发送预览文本消息</h1>
        文本格式：{"touser":"o8__KjrxQiTety8PbZb7noPse77s","text":{"content":"CONTENT"},"msgtype":"text"}<br/>
           <asp:TextBox ID="txt_send_preview" runat="server" TextMode="MultiLine" Width="100%" Height="65px">{"touser":"o8__KjrxQiTety8PbZb7noPse77s","text":{"content":"CONTENT"},"msgtype":"text"}</asp:TextBox><br/>
        <asp:Button ID="btn_send_preview" runat="server" Text="预览文本消息"  OnClick="btn_send_preview_OnClick"/><asp:Label runat="server" ID="lab_send_preview_msg"></asp:Label>
            <hr/>
            <h1>发送图文预览消息</h1>
            文本格式：{"touser":"o8__KjrxQiTety8PbZb7noPse77s","mpnews":{"media_id":"o8__KjrxQiTety8PbZb7noPse77s"},"msgtype":"mpnews"}<br/>
            <textarea runat="server" id="txt_sendPrivewMpnNews" style="width: 100%;height: 50px"></textarea>
           
            <input type="button" runat="server" value="发送预览图文消息" id="btn_sendPreviewMpnNews" OnServerClick="btn_sendPreviewMpnNews_OnServerClick"/>
            <span id="lab_sendPriviewMpnNewsMsg" runat="server"></span>
            <br />
            <h1>发送多条图文消息：</h1>
            <textarea runat="server" id="txt_materialAddNews" style="width: 100%;height: 70px"></textarea>
            <input type="button" runat="server" id="btn_sendMaterialNews" value="发送多条图片消息" OnServerClick="btn_sendMaterialNews_OnServerClick"/>
            <label runat="server" id="lab_materialAddNews_msg"></label>

            </div>
    </form>
</body>
</html>
