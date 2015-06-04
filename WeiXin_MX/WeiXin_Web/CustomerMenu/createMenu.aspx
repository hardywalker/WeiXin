<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="createMenu.aspx.cs" Inherits="WeiXin_Web.CustomerMenu.createMenu" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>

</head>
<body>
    <form id="form1" runat="server">
              <h1>生成菜单测试</h1>
        菜单代码示例：{"button":[{"name":"菜单一","sub_button":[{"type":"click","name":"accessToken","key":"accessToken"},{"type":"click","name":"serverIP","key":"serverIP"},{"type":"click","name":"myGUID","key":"myGUID"},{"type":"view","name":"搜索","url":"http://www.baidu.com"},{"type":"view","name":"视频","url":"http://www.youku.com"}]},{"name":"菜单二","sub_button":[{"type":"location_select","name":"GPS","key":"GPS"},{"type":"click","name":"菜单二二","key":"菜单二二"},{"type":"click","name":"菜单二三","key":"菜单二三"},{"type":"click","name":"菜单二四","key":"菜单二四"},{"type":"click","name":"菜单二五","key":"菜单二五"}]},{"name":"菜单三","sub_button":[{"type":"click","name":"菜单三一","key":"菜单三一"},{"type":"click","name":"菜单三二","key":"菜单三二"},{"type":"click","name":"菜单三三","key":"菜单三三"},{"type":"click","name":"菜单三四","key":"菜单三四"},{"type":"click","name":"菜单三五","key":"菜单三五"}]}]}<br/>
        
         <asp:TextBox ID="txt_menu" runat="server" TextMode="MultiLine" Width="100%" Height="300px">{"button":[{"name":"菜单一","sub_button":[{"type":"click","name":"accessToken","key":"accessToken"},{"type":"click","name":"serverIP","key":"serverIP"},{"type":"click","name":"myGUID","key":"myGUID"},{"type":"view","name":"搜索","url":"http://www.baidu.com"},{"type":"view","name":"视频","url":"http://www.youku.com"}]},{"name":"菜单二","sub_button":[{"type":"location_select","name":"GPS","key":"GPS"},{"type":"click","name":"菜单二二","key":"菜单二二"},{"type":"click","name":"菜单二三","key":"菜单二三"},{"type":"click","name":"菜单二四","key":"菜单二四"},{"type":"click","name":"菜单二五","key":"菜单二五"}]},{"name":"菜单三","sub_button":[{"type":"click","name":"菜单三一","key":"菜单三一"},{"type":"click","name":"菜单三二","key":"菜单三二"},{"type":"click","name":"菜单三三","key":"菜单三三"},{"type":"click","name":"菜单三四","key":"菜单三四"},{"type":"click","name":"菜单三五","key":"菜单三五"}]}]}</asp:TextBox><br/>
        <asp:Button runat="server" ID="btn_createMenu" OnClick="btn_createMenu_OnClick" Text="生成菜单"/><label runat="server" id="lab_menu_msg"></label>
        </form>
</body>
</html>
