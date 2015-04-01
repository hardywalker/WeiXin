<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UserManage.aspx.cs" Inherits="WeiXin_Web.UserManage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>用户管理</title>
       <script type="text/javascript" src="Scripts/jquery-2.1.3.min.js"></script>
      <script type="text/javascript" src="UserJS/LoadHeader.js"></script>
</head>
<body>
    <form id="form1" runat="server">
        <div>
    <div id="header"></div>
    <h1>获取用户列表</h1>
                <asp:Button runat="server" ID="btn_get_user_list" Text="获取用户列表" OnClick="btn_get_user_list_OnClick"/>
<asp:Label runat="server" ID="lab_user_list_json" Width="100%" Height="80px"></asp:Label>
            <hr/>
            <h1>用户分组管理</h1>
        <h2>查询所有分组</h2>
    </div>
    </form>
</body>
</html>
