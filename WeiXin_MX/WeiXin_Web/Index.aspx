<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="WeiXin_Web.Index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>微信公众账号测试平台</title>
    <script type="text/javascript" src="Scripts/jquery-2.1.3.min.js"></script>
    <script type="text/javascript" src="UserJS/LoadHeader.js"></script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <div id="header"></div>
        测试号申请地址：http://mp.weixin.qq.com/debug/cgi-bin/sandbox?t=sandbox/login    <br />
        官方帮助文档：http://mp.weixin.qq.com/wiki/home/index.html
        <hr/>
       

  <asp:Button runat="server" ID="btn_get_access_token" OnClick="btn_get_access_token_OnClick" Text="获取access_token"/><br/>
        <asp:Label runat="server" ID="lab_access_token"></asp:Label><br/>
        <input type="button" id="btn_update_access_token" value="更新access_token" runat="server" OnServerClick="btn_update_access_token_OnServerClick"/>
        <hr/>
        <asp:Button runat="server" ID="btn_get_server_ip" OnClick="btn_get_server_ip_OnClick" Text="获取服务器ip"/><br/>
        <asp:Label runat="server" ID="lab_server_ip"></asp:Label>
        <hr/>


    </div>
        
    </form>

    
 
</body>
</html>
