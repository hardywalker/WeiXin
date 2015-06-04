<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="getMenu.aspx.cs" Inherits="WeiXin_Web.CustomerMenu.getMenu" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>

</head>
<body>
    <form id="form1" runat="server">
    
           获取现有菜单：<br/>
        <asp:TextBox ID="txt_now_menu" runat="server" TextMode="MultiLine" Width="100%" Height="200px" ></asp:TextBox>
        <asp:Button runat="server" Text="获取菜单" OnClick="btn_get_now_menu_OnClick" ID="btn_get_now_menu"/>

    </form>
</body>
</html>
