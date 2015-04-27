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
             <h1>群发文本消息</h1>
            <h2>根据分组进行群发</h2>
       根据分组进行群发文本消息，发送给全部关注者is_to_all为true: {"filter":{"is_to_all":true,"group_id": "2"},"text": {"content": "这里是内容"},"msgtype": "text"}<br/>
       
        <asp:TextBox ID="txt_sendall" runat="server" TextMode="MultiLine" Width="100%" Height="100px">{"filter":{"is_to_all":true,"group_id": "2"},"text": {"content": "这里是内容"},"msgtype": "text"}</asp:TextBox><br/>
        <asp:Button ID="btn_sendall" runat="server" Text="群发文本消息" OnClick="btn_sendall_OnClick" /><asp:Label runat="server" ID="lab_send_all_msg"></asp:Label><br/>
            <h2>根据OpenID列表群发</h2>
        根据OpenID列表群发【订阅号不可用，服务号认证后可用】 :{"touser":["OPENID1","OPENID2"],"msgtype": "text","text": { "content": "hello from boxer."}}<br/>
            <input type="text" runat="server" id="txt_send_openlist" value='{"touser":["OPENID1","OPENID2"],"msgtype": "text","text": { "content": "hello from boxer."}}' style="width: 100%; height: 50px"/>
            <input type="button" runat="server" id="btn_sendmsg_openlist" value="根据用户列表群发" OnServerClick="btn_sendmsg_openlist_OnServerClick"/><br/>
            <span runat="server" id="lab_sendmsg_openlist_msg"></span>
       
        <br/>
        <h1>发送预览文本消息</h1>
        文本格式：{"touser":"o8__KjrxQiTety8PbZb7noPse77s","text":{"content":"CONTENT"},"msgtype":"text"}<br/>
           <asp:TextBox ID="txt_send_preview" runat="server" TextMode="MultiLine" Width="100%" Height="65px">{"touser":"o8__KjrxQiTety8PbZb7noPse77s","text":{"content":"CONTENT"},"msgtype":"text"}</asp:TextBox><br/>
        <asp:Button ID="btn_send_preview" runat="server" Text="预览文本消息"  OnClick="btn_send_preview_OnClick"/><asp:Label runat="server" ID="lab_send_preview_msg"></asp:Label>
            <br />
            <h1>发送多条图文消息：</h1>
            <input type="text" runat="server" id="txt_materialAddNews" value="" style="width: 100%;height: 70px"/>
            <input type="button" runat="server" id="btn_sendMaterialNews" value="发送多条图片消息" OnServerClick="btn_sendMaterialNews_OnServerClick"/>
            <label runat="server" id="lab_materialAddNews_msg"></label>

            </div>
    </form>
</body>
</html>
