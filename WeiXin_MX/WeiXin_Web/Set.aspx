<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Set.aspx.cs" Inherits="WeiXin_Web.Set" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>配置信息</title>
       <script type="text/javascript" src="Scripts/jquery-2.1.3.min.js"></script>
      <script type="text/javascript" src="UserJS/LoadHeader.js"></script>
</head>
<body>
    <form id="form1" runat="server">
        <div>
    <div id="header"></div>
     <h1>配置信息</h1>
        公司账号<br/>
        wxa8f97bba9ebb7d27<br/>1f9381bd5c8f08b0c4dda7ac55b19769
            <hr/>
        测试账号<br />
        wxa29576cd9bb8fa92<br/>
        841a341dc0e60c105a14ee9734d51319
            <hr/>
            Appid:<asp:TextBox runat="server" ID="txt_appid" Width="200px"></asp:TextBox><br/>
            Secret:<asp:TextBox runat="server" ID="txt_secret" Width="300px"></asp:TextBox><br/>
            Token:<asp:TextBox runat="server" ID="txt_token" Width="200px"></asp:TextBox><br/>
            EncodingAESKey:<input type="text" runat="server" maxlength="43" id="txt_encodingaeskey" style="width: 400px;"/><br/>
            <asp:Button runat="server" ID="btn_save_set" Text="保存配置信息" OnClick="btn_save_set_OnClick"/>
    </div>
    </form>
</body>
</html>
