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
    //$("#form1").attr({"action":actionUrl}).submit();
    
    $.ajax({
        type: "POST",
        dataType: "json",
        url: actionUrl,
        data: { "action": "TemporaryImage" },
        success: function (data) {
            var result = $.parseJSON(data);
            if (result.status == "warning") {
                alert(result.msg);
            } else if (result.status == "success") {
                $("#div_temporaryImage").append("<img src='" + result.msg + "' />");
            }
         
        },
        error: function(data) { alert(data.msg); },
        async: true
});
}
/********************上传临时素材  End*****************************/
