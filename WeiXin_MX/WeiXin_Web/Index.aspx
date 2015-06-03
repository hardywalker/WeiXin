<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="WeiXin_Web.Index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>微信公众账号测试平台</title>

    
    <script src="Scripts/jquery-1.3.2.min.js"></script>
    <script type="text/javascript" src="UserJS/LoadHeader.js"></script>
    <!--Ligerui配置Start-->
    <link href="Scripts/ligerUI/skins/ligerui-icons.css" rel="stylesheet" />
    <link href="Scripts/ligerUI/skins/Aqua/css/ligerui-all.css" rel="stylesheet" />
    <script src="Scripts/ligerUI/js/core/base.js"></script>
    <script src="Scripts/ligerUI/js/plugins/ligerLayout.js"></script>

    <script src="Scripts/ligerUI/js/plugins/ligerAccordion.js"></script>
    <script src="Scripts/ligerUI/js/plugins/ligerTab.js"></script>
 
    <script src="Scripts/ligerUI/js/plugins/ligerMenu.js"></script>
    <script type="text/javascript">
        var newTab = null;
        $(function () {

            $("#navtab1").children("div").eq(0).load("main.html");

            //布局
            $("#layout1").ligerLayout({ leftWidth: 200 });
            //手风琴
            $("#accordion1").ligerAccordion(
            {
                changeHeightOnResize: true  //自适应高度
            });

            //Tab
         newTab= $("#navtab1").ligerTab({
           
             dragToMove: true,  //是否允许拖动时改变tab项的位置 
             changeHeightOnResize:true  //自适应高度
            });


            ;
        });
        /*
        创建新的Tab
     newTabId:指定的新tab的tabid
     tabText:新创建的tab的title
     tabUrl:新创建的tab需要加载的页面
        */
        function addNewTab(newTabId,tabText,tabUrl) {
           
            // newTab.addTabItem(tabid).setHeader(tabid,text);
            newTab.addTabItem({ tabid: newTabId, text: tabText, url: tabUrl });;
        }



    </script>
    <link href="css/main.css" rel="stylesheet" />
    <!--Ligerui配置End-->
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <div id="header"></div>
       
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
                            <li onclick="addNewTab('li1','配置信息','set.aspx');" >配置信息</li>
                            <li>列表二</li>
                       
                        </ul>
                    </div>
                    <div title="列表">
                        <ul>
                            <li>列表一</li>
                        
                        </ul>
                    </div>
                 
                </div>

                <div style="display: none;"></div>

            </div>
            <div position="center" title="操作区">
                <div id="navtab1" style="width: 100%; height: 100%; overflow: hidden; border: 1px solid #A3C0E8;">
                    <div tabid="home" title="主页" lselected="true" style="height: 100%">
                        <!--用来显示首页信息-->
                    </div>
                  
                </div>
            </div>
        </div>
    </form>
</body>
</html>
