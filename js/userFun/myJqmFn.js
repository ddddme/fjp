$(function () {
    jQuery.validator.addMethod("phone", function (value, element) {
        var tel = /^(((13[0-9]{1})|(15[0-9]{1})|(18[0-9]{1}))+\d{8})$/;
        return this.optional(element) || (tel.test(value));
    }, "手机号格式不正确");
})
//打开loading组件
//text(string): 加载提示文字
//str(string): load的背景颜色样式(取值:a,b,c,d)
//flag(boolean): 背景是否透明(取值:true透明,false不透明)
function loadStart(text, str, flag) {
    if (!text) {
        text = "";
    }
    $(".ui-loader h1").html(text);
    var _width = window.innerWidth;
    var _height = window.innerHeight;
    var htmlstr = '<div style="width:' + _width + 'px;height:' + _height + 'px;position:fixed;top:0px;left:0px;opacity:0.1;z-index:99999" class="loader-bg"></div>';
    $("body").append(htmlstr);
    if (flag) {
        $(".ui-loader").removeClass("ui-loader-verbose").addClass("ui-loader-default");
    }
    else {
        $(".ui-loader").removeClass("ui-loader-default").addClass("ui-loader-verbose");
    }
    var cla = "ui-body-" + str;
    $("html").addClass("ui-loading");
    var arr = $(".ui-loader").attr("class").split(" ");
    var reg = /ui-body-[a-f]/;
    for (var i in arr) {
        if (reg.test(arr[i])) {
            $(".ui-loader").removeClass(arr[i]);
        }
    }
    $(".ui-loader").addClass(cla);
}
//结束loading组件
function loadStop() {
    $("html").removeClass("ui-loading");
    $(".loader-bg").remove();
}
function setThumImg() {
    $('.fancybox').fancybox({ prevEffect: 'none', nextEffect: 'none', openSpeed: 0, closeSpeed: 0 });
    $('.thumbImg').jqthumb({ classname: 'jqthumb', width: '90px', height: '90px', position: { y: '50%', x: '50%' }, zoom: 1, method: 'auto' });

    $("li[class=section]").css("width", window.innerWidth+"px");
}
function showFileList(pBs, pTb,pPage) {
    var strTb = nullToEmt(pTb) != "" ? pTb : "tb_gzrz";
    var strPage = nullToEmt(pPage) != "" ? pPage+"_" : "";
    //显示文件列表
    $.get("../backstage/getDataA.aspx?rnd=" + (new Date()).getTime(),
        { getDataType: en_getDataType.fileList, tb_file_tb: strTb, tb_file_bs: pBs },
            function (data) {
                if (data == "")
                    return;
                var objJson = JSON.parse(data);
                var strRv = "";
                for (i = 0; i < objJson.length; i++) {
                    strRv += "<ul class=\"sub_section\">" +
                   "<li>" +
                   "<a href=\"#popupParis" + objJson[i].tb_file_ID + "\" data-transition=\"fade\" data-rel=\"popup\" data-position-to=\"window\">" + "\n" +
                   "<div class='frame'><div class='frame-pad'><img class='thumbImg' src='../upload/UploadFile/" + objJson[i].tb_file_guid + "'/></div></div></a>" +
                   "<div id='popupParis" + objJson[i].tb_file_ID + "' data-role=\"popup\" data-theme=\"b\" data-overlay-theme=\"b\" data-corners=\"false\">" +
                   "<a class=\"ui-btn ui-corner-all ui-shadow ui-btn-a ui-icon-delete ui-btn-icon-notext ui-btn-right\" href=\"#\" data-rel=\"back\">Close</a>" +
                   "<img style=\"max-height: 512px;\" class=\"popphoto\" alt=\"Paris, France\" src='../upload/UploadFile/" + objJson[i].tb_file_guid + "'>" +
                   "</div>" +
                   "</li>" +
                   "</ul>";
                }
                $("#" + strPage + "imgFile").html(strRv);
                $("#" + strPage + "imgFile").trigger('create');
                setThumImg();
            });
}
function myAjaxSubmitMB(pJson) {
    var mJson = {
        url: "../sharedView/sharedFrom_save.aspx",
        formName: "form1",
        clfn: function () { alert("提交成功") }
    }
    $.extend(mJson, pJson);

    var myForm = $("#" + mJson.formName);
    var myUrl = mJson.url;

    //window.android2.showLoad("提交中...");
    $.ajax({
        url: myUrl,
        data: myForm.serialize(),
        async: true,
        type: "post",
        contentType: "application/x-www-form-urlencoded; charset=UTF-8",
        success: function (data) {
            var jsonData;
            try { jsonData = JSON.parse(data); } catch (e) { return; };
            if (jsonData.type != 0) {
                alert(jsonData.value);
                return;
            }
            //window.android2.closeLoad();
            //执行提交后函数
            try { mJson.clfn(jsonData.value); } catch (e) { return };
            return;
        },
        error: function (data) {
            alert("服务器错误！");
            return;
        }
    });
}
(function($){
$.getUrlParam = function(name)
{
    var reg = new RegExp("(^|&)" + name + "=([^&]*)(&|$)");
    var iSeah = window.location.href.indexOf("?");
    var r = window.location.href.substr(iSeah+1).match(reg);
    if (r!=null) return unescape(r[2]); return null;
    }
})(jQuery);