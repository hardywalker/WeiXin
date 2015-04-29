/***
2015年4月29日10:26:17
小马
微信上传素材管理
**/




/********************上传临时素材  Start*****************************/
function TemporaryMedia() {
    //var image0 = $("input[name='file_temporaryImage']").val();
    var image0 = $("#file_temporaryImage").val();
    if ($.trim(image0) == "") {
        alert("请选择图片！");
        return;
    }
    var actionUrl = "ImageUpload.ashx";
    $("#form1").ajaxSubmit({
      
            type: "POST",
            dataType: "json",
            url: actionUrl,
            data: { "action": "TemporaryImage" },
            success: function (data) {
             
                if (data.status == "warning") {
                    alert(data.msg);
                } else if (data.status == "success") {
                    $("#div_temporaryImage").append("<img style='width:300px;height:300px;' src='" + data.msg + "' /><span>临时素材mediaId:" + data.uploadmsg.media_id + "</span>");
                }

            },
            error: function (data) { alert(data.msg); },
            async: true
     
    });
    

}
/********************上传临时素材  End*****************************/




/********************上传永久素材  Start*****************************/
function ForeverMedia() {
    
}
/********************上传永久素材  End*****************************/