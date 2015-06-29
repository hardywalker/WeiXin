<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="getMenu.aspx.cs" Inherits="WeiXin_Web.CustomerMenu.getMenu" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <script src="../Scripts/jquery-1.3.2.min.js"></script>
    <link href="../Scripts/ligerUI/skins/Aqua/css/ligerui-all.css" rel="stylesheet" />
    <script src="../Scripts/ligerUI/js/core/base.js"></script>
    <script src="../Scripts/ligerUI/js/plugins/ligerTree.js"></script>
    <script src="../Scripts/ligerUI/js/plugins/ligerMenu.js"></script>
    <script type="text/javascript">
        var menu;
        var actionNodeID;
        function itemclick(item) {

            alert(actionNodeID + " | " + item.text);
        }
        $(function () {
            menu = $.ligerMenu({
                top: 100,
                left: 100,
                width: 120,
                items: [
                { text: '增加', click: itemclick, icon: 'add' },
                { text: '修改', click: itemclick },
                { line: true },
                { text: '查看', click: itemclick }
                ]
            });

            $("#menu_tree").ligerTree({
                onContextmenu: function (node, e) {
                    actionNodeID = node.data.text;
                    menu.show({ top: e.pageY, left: e.pageX });
                    return false;
                }
            });
        });
    </script>

    <style type="text/css">
        .menu_right {
            border: 1px solid red;
            float: left;
            height: 400px;
            width: 500px;
        }
    </style>



    <script type="text/javascript">

        var tree;
        $(function () {
            tree = $("#tree1").ligerTree({
                nodeWidth: 200,
                checkbox: true,
                idFieldName: 'id',
                delay: [1, 2],//1级和2级都延迟
                slide: false,
                onAfterAppend: function () {
                },
                onBeforeAppend: function () {
                }
            });

            showNodesCountMessage();
        });

        $(".nodescount").live('change', function () {
            showNodesCountMessage();
        });


        ///创建节点方法
        function f_load() {
            var data = createData();
            var op = {
                isExpand: parseInt($("#expandLevel").val()),
                delay: []
            };
            $(".delayChk").each(function () {
                if (this.checked) {
                    op.delay.push(parseInt(this.value));
                }
            });
            if (!op.delay.length) op.delay = false;
            tree.set(op);
            var time1 = new Date();
            tree.set('data', data);
            var time2 = new Date();
            var showed = $("#tree1 li").length;
            var h = "节点总数:" + getNodesCount() + ",已渲染节点总数:" + showed + ",耗时:" + (time2 - time1) + "毫秒";
            $("#message").append("<p>" + h + "</p>");
            alert(h);
        }
        function createData(e) {
            e = e || {};
            var level = e.level || 1,
                prev = e.prev || "",
                count = $("#nodescount" + level).val(),
                data = [],
                nextLevelNodesCount = $("#nodescount" + (level + 1)).val();
            var hasChildren = false;
            if (nextLevelNodesCount && nextLevelNodesCount != "0") {
                hasChildren = true;
            }
            for (var i = 0, l = parseInt(count) ; i < l ; i++) {
                var num = i + 1, id = prev + num;
                var o = {
                    text: "node" + id
                };
                if (hasChildren) {
                    o.children = createData({
                        level: level + 1,
                        prev: id + "-"
                    });
                }
                data.push(o);
            }
            return data;
        }

        function getNodesCount(level) {
            if (level == null) level = getMaxLevel();
            if (level == 0) return 0;
            var sum = 1;
            for (var i = 1; i <= level; i++) {
                var value = $("#nodescount" + i).val();
                if (value == "0" || !value) continue;
                sum = sum * parseInt(value);
            }
            return sum + getNodesCount(level - 1);
        }
        function getMaxLevel() {
            for (var i = 4; i >= 1; i--) {
                var value = $("#nodescount" + i).val();
                if (value == "0" || !value) continue;
                return i;
            }
        }
        function showNodesCountMessage() {
            $("#nodesCountMessage").html("总节点数:" + getNodesCount());
        }
    </script>

</head>
<body>
    <form id="form1" runat="server">
        获取现有菜单：<br />
        <asp:TextBox ID="txt_now_menu" runat="server" TextMode="MultiLine" Width="100%" Height="200px"></asp:TextBox>
        <asp:Button runat="server" Text="获取菜单" OnClick="btn_get_now_menu_OnClick" ID="btn_get_now_menu" />
        <input type="button" id="btn_getAllMenu" value="获取当前菜单" onclick="" />

        <hr />
        <!--带复选框和Icon-->
        <div style="height: 100%; margin-right: 10px; float: left; border: 1px solid #ccc; overflow: auto;">
            <ul id="menu_tree">
                <li>
                    <span>主菜单一</span>
                    <ul>
                        <li><span>子菜单1.1</span></li>
                        <li><span>子菜单1.2</span></li>
                        <li><span>子菜单1.3</span></li>
                        <li><span>子菜单1.4</span></li>
                        <li><span>子菜单1.5</span></li>
                    </ul>
                </li>

                <li>
                    <span>主菜单二</span>
                    <ul>
                        <li><span>子菜单2.1</span></li>
                        <li><span>子菜单2.2</span></li>
                        <li><span>子菜单2.3</span></li>
                        <li><span>子菜单2.4</span></li>
                        <li><span>子菜单2.5</span></li>
                    </ul>
                </li>
                <li>
                    <span>主菜单三</span>
                    <ul>
                        <li><span>子菜单3.1</span></li>
                        <li><span>子菜单3.2</span></li>
                        <li><span>子菜单3.3</span></li>
                        <li><span>子菜单3.4</span></li>
                        <li><span>子菜单3.5</span></li>
                    </ul>
                </li>
            </ul>
        </div>
        <div style="display: none"></div>
        <div class="menu_right">
        </div>

        <div>
            <span>第一级节点数</span>
            <select id="nodescount1" class="nodescount">

                <option selected="selected">100</option>
                <option>150</option>

            </select>

            <span>第二级节点数</span>
            <select id="nodescount2" class="nodescount">
                <option value="0"></option>
                <option selected="selected">10</option>
                <option>20</option>

            </select>

            <span id="nodesCountMessage"></span>
            <span>展开</span><select id="expandLevel">
                <option>1</option>
                <option>2</option>
                <option>3</option>
                <option>4</option>
            </select>
            <span>级</span>

  

            <input type="button" value="确定" onclick="f_load()" style="padding: 0px 5px;" />
        </div>
        <div style="width: 300px; height: 400px; margin: 10px; position: relative; border: 1px solid #ccc; overflow: auto;">
            <ul id="tree1"></ul>
        </div>
    </form>
</body>
</html>
