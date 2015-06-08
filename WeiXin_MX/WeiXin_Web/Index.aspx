<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="WeiXin_Web.Index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>微信公众账号测试平台</title>
    


    <script src="Scripts/jquery-1.3.2.min.js"></script>

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
            newTab = $("#navtab1").ligerTab({

                dragToMove: true,  //是否允许拖动时改变tab项的位置 
                changeHeightOnResize: true  //自适应高度
            });


            ;
        });
        /*
        创建新的Tab
     newTabId:指定的新tab的tabid
     tabText:新创建的tab的title
     tabUrl:新创建的tab需要加载的页面
        */
        function addNewTab(newTabId, tabText, tabUrl) {


            newTab.addTabItem({ tabid: newTabId, text: tabText, url: tabUrl });;
        }



    </script>
    <link href="css/main.css" rel="stylesheet" />
    <!--Ligerui配置End-->
</head>
<body>
    <form id="form1" runat="server">

        <div id="layout1">
            <div position="left" title="我是左侧收缩导航">
                <div id="accordion1">
                    <div title="功能列表">
                        <ul>
                            <li onclick="addNewTab('ul1li1','配置信息','set.aspx');">配置信息</li>
                            <li onclick="addNewTab('ul1li2','access_token','access_token.aspx');">access_token</li>
                        </ul>
                    </div>
                    <div title="菜单管理">
                        <ul>
                            <li onclick="addNewTab('ul2li1','现有菜单','CustomerMenu/getMenu.aspx');">现有菜单</li>
                            <li onclick="addNewTab('ul2li2','编辑菜单','CustomerMenu/editMenu.aspx');">编辑菜单</li>
                            <li onclick="addNewTab('ul2li3','删除菜单','CustomerMenu/deleteMenu.aspx');">删除菜单</li>

                        </ul>
                    </div>
                    <div title="用户管理">
                        <ul>
                            <li>所有用户</li>
                            <li>编辑菜单</li>
                            <li>删除菜单</li>

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
        <div class="footer">
            <div class="footer_link">
                <ul>
                    <li><a href="http://yibaobei999.taobao.com" target="_blank">韩尙王国</a></li>
                    <li><a href="http://yibaobei888.taobao.com" target="_blank">小维家高端定制</a></li>

                </ul>
            </div>
            <div class="footer_copyright">
                <span>@2015 anyangmaxin.com 豫ICP备15015309号</span>
            </div>
        </div>
    </form>
</body>
</html>
