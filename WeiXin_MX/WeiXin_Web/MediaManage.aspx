<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MediaManage.aspx.cs" Inherits="WeiXin_Web.MediaManage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>素材管理</title>
  
    <script src="Scripts/jquery-2.1.4.min.js"></script>
     <script type="text/javascript" src="UserJS/LoadHeader.js"></script>
    <script src="Scripts/jquery.form.js" type="text/javascript"></script>
    <script src="UserJS/mediaUpload.js" type="text/javascript"></script>
   
</head>
<body>
    <form id="form1" runat="server">
    <div>
           <div id="header"></div>
    <h1>素材管理</h1>
        <hr/>
        <h2>新增临时图片素材</h2>
        <input id="file_temporaryImage" type="file" name="file_temporaryImage" />&nbsp;&nbsp;<div id="div_temporaryImage"></div><br />
        <input id="btn_temporary" type="button" value="上传临时素材" onclick="javascript:TemporaryMedia();" />
        <hr/>
        <h2>上传永久图片素材</h2>
          <input id="file_foreverImage" type="file" name="file_foreverImage" />&nbsp;&nbsp;<div id="div_foreverImage"></div><br />
        <input id="btn_forever" type="button" value="上传永久素材" onclick="javascript: ForeverMedia();" />
    </div>
    </form>
    
</body>
</html>
