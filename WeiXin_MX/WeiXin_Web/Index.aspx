<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="WeiXin_Web.Index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>微信公众账号测试平台</title>


    <script src="Scripts/jquery-2.0.2.min.js"></script>
    <script type="text/javascript" src="UserJS/LoadHeader.js"></script>
    <!--Ligerui配置Start-->
    <link href="Content/Ligerui/Themes/Default/css/ligerui-all.css" rel="stylesheet" />
    <script src="Scripts/Ligerui/core/base.js"></script>
    <script src="Scripts/Ligerui/plugins/ligerLayout.js"></script>
      <script type="text/javascript">
 
            $(function ()
            {
                $("#layout1").ligerLayout({
                    leftWidth: 200,
                    centerbottomHeight: 150
                    
                });
            });
             
     </script> 
    <style type="text/css"> 
 
        body{ padding:5px; margin:0; padding-bottom:15px;}
        #layout1{  width:100%;margin:0; padding:0;  }  
  
        h4{ margin:20px;}
    </style>
    <!--Ligerui配置End-->
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
        
      
      <div id="layout1">
            <div position="left" title="左侧"></div>
            <div position="center" title="标题">
            <h4>$("#layout1").ligerLayout({ leftWidth: 200});</h4> 
                <br />
                如果上面有其他页面元素，layout会自适应调整
             </div>  
          <div position="centerbottom" title="下方区域">
              中间下方区域
              <br/>
                中间下方区域
            </div>  
        </div> 

    </form>
</body>
</html>
