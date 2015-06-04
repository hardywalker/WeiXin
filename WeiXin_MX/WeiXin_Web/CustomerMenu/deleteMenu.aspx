<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="deleteMenu.aspx.cs" Inherits="WeiXin_Web.CustomerMenu.deleteMenu" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>

</head>
<body>
    <form id="form1" runat="server">
    删除现有菜单：<br/>
        <asp:Button runat="server" ID="btn_delete_now_menu" OnClick="btn_delete_now_menu_OnClick" Text="删除菜单"/> <asp:Label runat="server" ID="lab_delete_menu_msg"></asp:Label>
    </form>
</body>
</html>
