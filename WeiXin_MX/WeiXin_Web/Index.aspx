<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="WeiXin_Web.Index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>微信公众账号测试平台</title>



    <script src="Scripts/jquery-1.3.2.min.js"></script>
    <script type="text/javascript" src="UserJS/LoadHeader.js"></script>
    <!--Ligerui配置Start-->
    <link href="Scripts/ligerUI/skins/Aqua/css/ligerui-all.css" rel="stylesheet" />
    <script src="Scripts/ligerUI/js/core/base.js"></script>
    <script src="Scripts/ligerUI/js/plugins/ligerLayout.js"></script>
    <script src="Scripts/ligerUI/js/plugins/ligerTree.js"></script>
    <script src="Scripts/ligerUI/js/plugins/ligerAccordion.js"></script>
    <script type="text/javascript">

        $(function () {
            //布局
            $("#layout1").ligerLayout({ leftWidth: 200 });
            //手风琴
            $("#accordion1").ligerAccordion(
            {
                changeHeightOnResize:true  //自适应高度
            });
        });

    </script>
    <link href="css/main.css" rel="stylesheet" />
    <!--Ligerui配置End-->
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <div id="header"></div>
            测试号申请地址：http://mp.weixin.qq.com/debug/cgi-bin/sandbox?t=sandbox/login   
            <br />
            官方帮助文档：http://mp.weixin.qq.com/wiki/home/index.html
        <hr />
            <asp:Button runat="server" ID="btn_get_access_token" OnClick="btn_get_access_token_OnClick" Text="获取access_token" /><br />
            <asp:Label runat="server" ID="lab_access_token"></asp:Label><br />
            <input type="button" id="btn_update_access_token" value="更新access_token" runat="server" onserverclick="btn_update_access_token_OnServerClick" />
            <hr />
            <asp:Button runat="server" ID="btn_get_server_ip" OnClick="btn_get_server_ip_OnClick" Text="获取服务器ip" /><br />
            <asp:Label runat="server" ID="lab_server_ip"></asp:Label>
            <hr />
        </div>
        <div id="layout1">
            <div position="left" title="我是左侧收缩导航">
                <div id="accordion1">
                    <div title="功能列表">
                        <ul>
                            <li>列表一</li>
                            <li>列表二</li>
                            <li>列表三</li>
                            <li>列表四</li>
                            <li>列表五</li>
                        </ul>
                    </div>
                    <div title="列表">
                        <ul>
                            <li>列表一</li>
                            <li>列表二</li>
                            <li>列表三</li>
                            <li>列表四</li>
                            <li>列表五</li>
                        </ul>
                    </div>
                    <div title="其他" style="padding: 10px">
                        其他内容
                    </div>
                </div>

                <div style="display: none;"></div>

            </div>
            <div position="center" title="标题">
                这里是右侧内容
            </div>
        </div>
    </form>
</body>
</html>
