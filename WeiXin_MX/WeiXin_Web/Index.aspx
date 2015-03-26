<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="WeiXin_Web.Index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>微信公众账号测试平台</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        测试号申请地址：http://mp.weixin.qq.com/debug/cgi-bin/sandbox?t=sandbox/login
        <hr/>
        <h1>配置信息</h1>
        appid:<asp:TextBox ID="txt_appid" runat="server" Width="300px">wxa29576cd9bb8fa92</asp:TextBox><br/>
        secret:<asp:TextBox ID="txt_secret" runat="server" Width="300px">841a341dc0e60c105a14ee9734d51319</asp:TextBox><br/>
        token:<asp:TextBox ID="txt_token" runat="server" Width="300px">anyangmaxin</asp:TextBox><br/>
  <asp:Button runat="server" ID="btn_get_access_token" OnClick="btn_get_access_token_OnClick" Text="获取access_token"/><br/>
        <asp:Label runat="server" ID="lab_access_token"></asp:Label>
        <hr/>
        <asp:Button runat="server" ID="btn_get_server_ip" OnClick="btn_get_server_ip_OnClick" Text="获取服务器ip"/><br/>
        <asp:Label runat="server" ID="lab_server_ip"></asp:Label>
        <hr/>
        <h1>生成菜单测试</h1>
        菜单代码示例：{"button":[{"name":"菜单一","sub_button":[{"type":"click","name":"accessToken","key":"accessToken"},{"type":"click","name":"serverIP","key":"serverIP"},{"type":"click","name":"myGUID","key":"myGUID"},{"type":"view","name":"搜索","url":"http://www.baidu.com"},{"type":"view","name":"视频","url":"http://www.youku.com"}]},{"name":"菜单二","sub_button":[{"type":"location_select","name":"GPS","key":"GPS"},{"type":"click","name":"菜单二二","key":"菜单二二"},{"type":"click","name":"菜单二三","key":"菜单二三"},{"type":"click","name":"菜单二四","key":"菜单二四"},{"type":"click","name":"菜单二五","key":"菜单二五"}]},{"name":"菜单三","sub_button":[{"type":"click","name":"菜单三一","key":"菜单三一"},{"type":"click","name":"菜单三二","key":"菜单三二"},{"type":"click","name":"菜单三三","key":"菜单三三"},{"type":"click","name":"菜单三四","key":"菜单三四"},{"type":"click","name":"菜单三五","key":"菜单三五"}]}]}<br/>
        
         <asp:TextBox ID="txt_menu" runat="server" TextMode="MultiLine" Width="100%" Height="300px">{"button":[{"name":"菜单一","sub_button":[{"type":"click","name":"accessToken","key":"accessToken"},{"type":"click","name":"serverIP","key":"serverIP"},{"type":"click","name":"myGUID","key":"myGUID"},{"type":"view","name":"搜索","url":"http://www.baidu.com"},{"type":"view","name":"视频","url":"http://www.youku.com"}]},{"name":"菜单二","sub_button":[{"type":"location_select","name":"GPS","key":"GPS"},{"type":"click","name":"菜单二二","key":"菜单二二"},{"type":"click","name":"菜单二三","key":"菜单二三"},{"type":"click","name":"菜单二四","key":"菜单二四"},{"type":"click","name":"菜单二五","key":"菜单二五"}]},{"name":"菜单三","sub_button":[{"type":"click","name":"菜单三一","key":"菜单三一"},{"type":"click","name":"菜单三二","key":"菜单三二"},{"type":"click","name":"菜单三三","key":"菜单三三"},{"type":"click","name":"菜单三四","key":"菜单三四"},{"type":"click","name":"菜单三五","key":"菜单三五"}]}]}</asp:TextBox><br/>
        <asp:Button runat="server" ID="btn_createMenu" OnClick="btn_createMenu_OnClick" Text="生成菜单"/><label runat="server" id="lab_menu_msg"></label>
        <hr />
     

    </div>
    </form>
</body>
</html>
