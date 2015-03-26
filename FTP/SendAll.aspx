<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SendAll.aspx.cs" Inherits="WeiXin_Web.SendAll" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>群发消息测试功能页</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <h1>群发文本消息</h1><br/>
       根据分组进行群发文本消息，发送给全部关注者is_to_all为true: {"filter":{"is_to_all":true,"group_id": "2"},"text": {"content": "这里是内容"},"msgtype": "text"}<br/>
        根据OpenID列表群发【订阅号不可用，服务号认证后可用】 :{"touser":["OPENID1","OPENID2"],"msgtype": "text","text": { "content": "hello from boxer."}}
        <br />
        <asp:TextBox ID="TextBox1" runat="server" TextMode="MultiLine">{"filter":{"is_to_all":true,"group_id": "2"},"text": {"content": "这里是内容"},"msgtype": "text"}</asp:TextBox><br/>
        <asp:Button ID="Button1" runat="server" Text="群发文本消息" OnClick="Button1_OnClick" />
        <br/>
        <h1>发送预览消息</h1><br/>
        文本格式：{"touser":"o8__KjrxQiTety8PbZb7noPse77s","text":{"content":"CONTENT"},"msgtype":"text"}<br/>
           <asp:TextBox ID="TextBox2" runat="server" TextMode="MultiLine">{"touser":"o8__KjrxQiTety8PbZb7noPse77s","text":{"content":"CONTENT"},"msgtype":"text"}</asp:TextBox><br/>
        <asp:Button ID="Button2" runat="server" Text="预览文本消息" OnClick="Button2_OnClick" />
    </div>
    </form>
</body>
</html>
