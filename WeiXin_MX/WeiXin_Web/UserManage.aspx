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
              <h2>创建分组</h2>
            {"group":{"name":"test"}}
            <asp:TextBox runat="server" ID="txt_create_groups_json" Width="100%" Height="20px" >{"group":{"name":"test"}}</asp:TextBox>
            <asp:Label runat="server" ID="lab_create_groups_msg" Width="100%"></asp:Label><input runat="server" type="button" id="btn_create_groups" value="创建分组" OnServerClick="btn_create_groups_OnServerClick" />
        <h2>查询所有分组</h2>
            <label runat="server" id="lab_all_groups" style="width: 100%"></label>
            <input type="button" runat="server" id="btn_get_all_groups" value="获取所有分组" OnServerClick="btn_get_all_groups_OnServerClick"/>
            <h2>查询用户所在分组</h2>
            {"openid":"od8XIjsmk6QdVTETa9jLtGWA6KBc"}<br/>
            <input type="text" id="txt_getgroupid" runat="server" style="width: 100%;" value='{"openid":"od8XIjsmk6QdVTETa9jLtGWA6KBc"}'/><input runat="server" type="button" id="btn_getGroupId" OnServerClick="btn_getGroupId_OnServerClick" value="查询用户所在分组"/><br/>
            <span runat="server" id="lab_getgroupid_msg"></span>
            <h2>修改分组名</h2>
            {"group":{"id":108,"name":"test2_modify2"}}<br/>
            <input type="text" runat="server" id="txt_updateGroup" value='{"group":{"id":108,"name":"test2_modify2"}}' style="width: 100%"/>
            <input type="button" runat="server" id="btn_updateGroup" value="修改分组名" OnServerClick="btn_updateGroup_OnServerClick"/>
            <span runat="server" id="lab_updateGroup_msg"></span>
            <h2>移动用户分组</h2>
            {"openid":"oDF3iYx0ro3_7jD4HFRDfrjdCM58","to_groupid":108}<br/>
            <input type="text" style="width: 100%" runat="server" id="txt_update_members" value='{"openid":"oDF3iYx0ro3_7jD4HFRDfrjdCM58","to_groupid":108}'/>
            <input type="button" runat="server" id="btn_update_members" OnServerClick="btn_update_members_OnServerClick" value="移动用户分组"/>
            <span runat="server" id="lab_update_members_msg"></span>
            <h2>批量移动用户分组</h2>
            {"openid_list":["oDF3iYx0ro3_7jD4HFRDfrjdCM58","oDF3iY9FGSSRHom3B-0w5j4jlEyY"],"to_groupid":108}<br/>
            <textarea style="width: 100%; height: 30px" runat="server" id="txt_batch_update_members">{"openid_list":["oDF3iYx0ro3_7jD4HFRDfrjdCM58","oDF3iY9FGSSRHom3B-0w5j4jlEyY"],"to_groupid":108}</textarea>
          <input type="button" runat="server" id="btn_batch_update_members" value="批量移动用户分组" OnServerClick="btn_batch_update_members_OnServerClick"/>
            <span runat="server" id="lab_batch_update_members_msg"></span>
    </div>
    </form>
</body>
</html>
