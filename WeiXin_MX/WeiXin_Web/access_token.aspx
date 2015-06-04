<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="access_token.aspx.cs" Inherits="WeiXin_Web.access_token" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
   <asp:Button runat="server" ID="btn_get_access_token" OnClick="btn_get_access_token_OnClick" Text="获取access_token" /><br />
            <asp:Label runat="server" ID="lab_access_token"></asp:Label><br />
            <input type="button" id="btn_update_access_token" value="更新access_token" runat="server" onserverclick="btn_update_access_token_OnServerClick" />
            <hr />
            <asp:Button runat="server" ID="btn_get_server_ip" OnClick="btn_get_server_ip_OnClick" Text="获取服务器ip" /><br />
            <asp:Label runat="server" ID="lab_server_ip"></asp:Label>
    </form>
</body>
</html>
