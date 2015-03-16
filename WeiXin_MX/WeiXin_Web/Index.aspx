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
  <asp:Button runat="server" ID="button1" OnClick="button1_OnClick" Text="测试获取acciss_token"/><br/>
        <asp:Label runat="server" ID="lab1"></asp:Label>
    </div>
    </form>
</body>
</html>
