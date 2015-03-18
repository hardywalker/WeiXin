<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="WeiXin_Web.Index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        测试号申请地址：http://mp.weixin.qq.com/debug/cgi-bin/sandbox?t=sandbox/login
        <hr/>
  <asp:Button runat="server" ID="button1" OnClick="button1_OnClick" Text="测试获取acciss_token"/><br/>
        <asp:Label runat="server" ID="lab1"></asp:Label>
        <br/>
        <asp:Button runat="server" ID="button2" OnClick="button2_OnClick" Text="测试获取服务器ip"/><br/>
        <asp:Label runat="server" ID="Label1"></asp:Label>
        <hr/>

    </div>
    </form>
</body>
</html>
