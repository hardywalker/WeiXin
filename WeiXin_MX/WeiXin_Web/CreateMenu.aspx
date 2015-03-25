<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CreateMenu.aspx.cs" Inherits="WeiXin_Web.CreateMenu" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>创建菜单测试</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <h1>创建菜单测试</h1><br/>
        菜单示例：                                                                                                                          
        <asp:Button ID="Button1" runat="server" Text="创建菜单" OnClick="Button1_OnClick" />
    </div>
    </form>
</body>
</html>
