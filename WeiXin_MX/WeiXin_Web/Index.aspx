<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="WeiXin_Web.Index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>微信公众账号测试平台</title>


   
    <script src="Scripts/jquery-1.3.2.min.js"></script>
    <script type="text/javascript" src="UserJS/LoadHeader.js"></script>
    <!--Ligerui配置Start-->

    <link href="Content/Ligerui/Themes/Default/css/ligerui-all.css" rel="stylesheet" />
    <script src="Scripts/Ligerui/core/base.js"></script>
    <script src="Scripts/Ligerui/plugins/ligerLayout.js"></script>
    <script src="Scripts/Ligerui/plugins/ligerTree.js"></script>
    <script src="Scripts/Ligerui/plugins/ligerAccordion.js"></script>
 
    <script src="Scripts/Ligerui/plugins/ligerTab.js"></script>
 
    <script type="text/javascript">

        $(function () {
            $("#layout1").ligerLayout({
                leftWidth: 200
            });
            $("#accordion1").ligerAccordion({

                height: 100

            });


            //tab
            $("#navtab3").ligerTab({
                showSwitch: true,
                ShowSwitchInTab: true
            });


        });

    </script>
    <style type="text/css">
        body {
            padding: 5px;
            margin: 0;
            padding-bottom: 15px;
        }

        #layout1 {
            width: 100%;
            margin: 0;
            padding: 0;
        }

        h4 {
            margin: 20px;
        }


        #accordion1 {
            width: 100%;
            overflow: hidden;
        }
    </style>
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
            <div position="left" title="左侧">

                <div id="accordion1" class="l-accordion-panel" style="height: 300px;" ligeruiid="accordion1">
                    <div class="l-accordion-header">
                        <div class="l-accordion-toggle l-accordion-toggle-open"></div>
                        <div class="l-accordion-header-inner">功能列表</div>
                    </div>
                    <div title="" class="l-accordion-content" style="height: 225px; display: block;">
                        <ul>
                            <li>列表一</li>
                            <li>列表二</li>
                            <li>列表三</li>
                            <li>列表四</li>
                            <li>列表五</li>
                        </ul>
                    </div>
                    <div class="l-accordion-header l-accordion-header-downfirst">
                        <div class="l-accordion-toggle l-accordion-toggle-close"></div>
                        <div class="l-accordion-header-inner">列表</div>
                    </div>
                    <div title="" class="l-accordion-content" style="display: none; height: 225px;">
                        <ul>
                            <li>列表一</li>
                            <li>列表二</li>
                            <li>列表三</li>
                            <li>列表四</li>
                            <li>列表五</li>
                        </ul>
                    </div>
                    <div class="l-accordion-header">
                        <div class="l-accordion-toggle l-accordion-toggle-close"></div>
                        <div class="l-accordion-header-inner">其他</div>
                    </div>
                    <div style="padding: 10px; display: none; height: 225px;" title="" class="l-accordion-content">
                        其他内容
                    </div>
                </div>
                <div style="display: none;"></div>

            </div>
        </div>


        <div id="navtab3" class="l-tab" ligeruiid="navtab3" style="width: 600px; overflow: hidden; border: 1px solid #A3C0E8; margin-top: 6px;" >
            <div class="l-tab-links">
                <ul style="left: 0px;">
                    <li class="" tabid="home">
                        <a>我的主页</a>
                        <div class="l-tab-links-item-left"></div>
                        <div class="l-tab-links-item-right"></div>
                    </li>
                    <li class="" tabid="tabitem1"><a>我的主页2</a><div class="l-tab-links-item-left"></div>
                        <div class="l-tab-links-item-right"></div>
                        <div class="l-tab-links-item-close"></div>
                    </li>
                    <li class="" tabid="tabitem2"><a>我的主页3</a><div class="l-tab-links-item-left"></div>
                        <div class="l-tab-links-item-right"></div>
                        <div class="l-tab-links-item-close"></div>
                    </li>
                    <li class="l-selected" tabid="tabitem3"><a>我的主页4</a><div class="l-tab-links-item-left"></div>
                        <div class="l-tab-links-item-right"></div>
                        <div class="l-tab-links-item-close"></div>
                    </li>
                    <li class="l-tab-itemswitch"><a></a>
                        <div class="l-tab-links-item-left"></div>
                        <div class="l-tab-links-item-right"></div>
                    </li>
                </ul>
            </div>




            <div class="l-tab-content">
                <div style="height: 300px; display: none;" lselected="true" title="" tabid="home" class="l-tab-content-item">
                    <div style="display: none;" class="l-tab-loading"></div>
                  
                </div>
                <div showclose="true" title="" tabid="tabitem1" class="l-tab-content-item" style="display: none;">
                    <div style="margin: 10px; height: 300px;" id="Div7">我的主页2</div>
                </div>
                <div showclose="true" title="" tabid="tabitem2" class="l-tab-content-item" style="display: none;">
                    <div style="margin: 10px; height: 300px;" id="Div8">我的主页3</div>
                </div>
                <div showclose="true" title="" tabid="tabitem3" class="l-tab-content-item" style="display: block;">
                    <div style="margin: 10px; height: 300px;" id="Div9">我的主页4</div>
                </div>
            </div>
        </div>





    </form>
</body>
</html>
