/***
2015年4月29日10:26:17
小马
微信上传素材管理
**/




/********************上传临时素材  Start*****************************/
function TemporaryMedia() {
    //var image0 = $("input[name='file_temporaryImage']").val();
    //判断上传控件中是否选择了图片
    var image = $("#file_temporaryImage").val();
    if ($.trim(image) == "") {
        alert("请选择图片！");
        return;
    }
    //提交请求处理的url
    var actionUrl = "ImageUpload.ashx";
    //开始ajax操作
    $("#form1").ajaxSubmit({
      
            type: "POST",//提交类型
            dataType: "json",//返回结果格式
            url: actionUrl,//请求地址
            data: { "action": "TemporaryImage" },//请求数据
            success: function (data) {//请求成功后的函数
             
                if (data.status == "warning") {//返回警告
                    alert(data.msg);
                } else if (data.status == "success") {//返回成功
                    $("#div_temporaryImage").append("<img style='width:300px;height:300px;' src='" + data.msg + "' /><span>临时素材mediaId:" + data.uploadmsg.media_id + "</span>");
                }

            },
            error: function (data) { alert(data.msg); },//请求失败的函数
            async: true
     
    });
    

}
/********************上传临时素材  End*****************************/




/********************上传永久素材  Start*****************************/
function ForeverMedia() {
    
}
/********************上传永久素材  End*****************************/