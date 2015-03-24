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
        <asp:TextBox ID="TextBox1" runat="server" TextMode="MultiLine"></asp:TextBox><br/>
        <asp:Button ID="Button1" runat="server" Text="群发文本消息" OnClick="Button1_OnClick" />
    </div>
    </form>
</body>
</html>
