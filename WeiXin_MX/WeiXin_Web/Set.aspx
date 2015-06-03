<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Set.aspx.cs" Inherits="WeiXin_Web.Set" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>

</head>
<body>
    <form id="form1" runat="server">
    
        测试账号<br />
        wxa29576cd9bb8fa92<br/>
        841a341dc0e60c105a14ee9734d51319
            <hr/>
            Appid:<asp:TextBox runat="server" ID="txt_appid" Width="200px"></asp:TextBox><br/>
            Secret:<asp:TextBox runat="server" ID="txt_secret" Width="300px"></asp:TextBox><br/>
            Token:<asp:TextBox runat="server" ID="txt_token" Width="200px"></asp:TextBox><br/>
            EncodingAESKey:<input type="text" runat="server" maxlength="43" id="txt_encodingaeskey" style="width: 400px;"/><br/>
            <asp:Button runat="server" ID="btn_save_set" Text="保存配置信息" OnClick="btn_save_set_OnClick"/>

    </form>
</body>
</html>
