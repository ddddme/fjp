/// <reference path="/js/jquery-weui/lib/jquery-2.1.4.js" />
/// <reference path="/js/jquery-weui/js/jquery-weui.js" />
/// <reference path="/js/myFun/tyFunLk.js" />
/// <reference path="/js/userFun/enumPubdim.js" />
/// <reference path="/js/userFun/userValida.js" />

$(function () {
    $.showLoading();
    $.get("handler.aspx?rnd=" + new Date().getTime(),
    { clFun: en_clFun.获取用户信息, wxbs: $("#pageIndex [id=openid]").val() },
    function (data) {
        var rvJson = JSON.parse(data);
        if (rvJson.success) {
            var userJson = JSON.parse(rvJson.value);
            setFormValue($("#pageUserinfo [id=userForm]"), userJson);
            $("#pageUserinfo [id=tb_user_ID]").data("userinfo", userJson);
        }
    });
    //获取到达站信息
    $.get("handler.aspx?rnd=" + new Date().getTime(),
        { clFun: en_clFun.获取到达站 },
        function (data) {
            try {
                var rvJson = JSON.parse(data);
                if (!rvJson.success) {
                    $.toast("获取车站列表失败！");
                    return;
                }
                var stationJson = JSON.parse(rvJson.value);
                strStation = ArrToStr(stationJson, "stationname");
                $("#pageIndex [id=ddz]").select({
                    title: "选择目的地",
                    items: strStation.split(",")
                });
            } catch (e) { $.toast("获取车站列表失败！"); }
        }).always(function () { $.hideLoading(); });

    //查询的表单验证
    $("#pageIndex [id=form1]").validate({
        rules: {
            ddz: {
                required: true
            }
        },
        messages: {
            ddz: {
                required: "目的地不能为空！"
            }
        }
    });
    //查询票列表
    $("#pageIndex [id=search]").click(function () {
        if ($("#pageIndex [id=form1]").valid()) {
            $.showLoading();
            $.post("handler.aspx?rnd=" + new Date().getTime(),
            { clFun: en_clFun.获取票列表, ddz: $("#pageIndex [id=ddz]").val() },
            function (data) {
                try {
                    var rvJson = JSON.parse(data);
                    if (!rvJson.success) {
                        $.toast(rvJson.message);
                        return;
                    }
                    //清空列表
                    $("#pageTickList [id=pp1]").empty();
                    //添加列表HEAD
                    $("#pageTickList [id=pp1]").append("<div class=\"weui_panel_hd\" id=\"listHead\"></div>");
                    //添加订单信息
                    $("#pageTickList [id=listHead]").data("BatchID", rvJson.BatchID)
                    //修改列表HEAD
                    $("#pageTickList [id=listHead]").html("<span style='font-size:16px;'>武汉-" +
                    $("#pageIndex [id=ddz]").val() + "&nbsp;" + $("#pageIndex [id=ftime]").val() + "</span>");
                    //添加列表
                    addTickList(JSON.parse(rvJson.value));
                    $("#pageTickList").popup();
                } catch (e) { $.toast("查询车票失败，" + e.message); }
            }).always(function () { $.hideLoading(); });
        };
    });
});

