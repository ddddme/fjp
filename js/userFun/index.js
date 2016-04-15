/// <reference path="/js/jquery-weui/lib/jquery-2.1.4.js" />
/// <reference path="/js/userFun/enumPubdim.js" />
/// <reference path="/js/jquery-weui/js/jquery-weui.js" />
/// <reference path="/js/tyFunLk.js" />
//页面初始化
//$(document).on("pageinit", "#orderPage", function () {
//    $("#zhifuSub").addClass("ui-state-disabled");//添加禁用标志
//    //开始支付
//    $(document).off("click", "#zhifuSub");
//    $(document).on("click", "#zhifuSub", function () {
//        callPay();
//        //window.location.href = "JsApiPayPage.aspx?" + $("#rzList_content").find("input[type!=radio]").serialize();
//    });
    //$("#form1").validate({
    //    submitHandler: function (form) {
    //        $("#button1").addClass("ui-state-disabled");//添加禁用标志
    //        loadStart();
    //        var sendUrl = "handler.aspx?rnd=" + new Date().getTime() + "&type=0&phone=" + $("#phone").val();
    //        $.post(sendUrl, function (data) {
    //            try {
    //                var objJson = JSON.parse(data.replace("正在中止线程。", ""));
    //                if (objJson.type == "1") {
    //                    $.toast("查询套餐失败！" + objJson.value, "cancel");
    //                    return;
    //                }
    //                $("#controlgroup1").empty();
    //                $.each(objJson.value, function (k, v) {
    //                    $("#controlgroup1").append("<input type=\"radio\" name=\"radio_view\"  " +
    //                    "id=\"radio_view" + v.MerchandiseID + "\" value=\"" + v.Price + "\"/>" +
    //                    "<label for=\"radio_view" + v.MerchandiseID + "\">" +
    //                    "<p><span>" + v.MerchandiseText + "</sapn>" +
    //                    "<span style='margin-left:20px;'>" + v.Price + "元</sapn></p>" +
    //                    "<p><span style=font-size:10px;font-weight:normal;'>" + v.Summary + "</sapn></p>" +
    //                    "</label>");
    //                    $("#radio_view" + v.MerchandiseID).click(function () {
    //                        if (this.checked) {
    //                            $("#MerchandiseText").val(v.MerchandiseText);
    //                            $("#MerchandiseSizeMB").val(v.FlowSizeMB);
    //                            $("#Price").val(v.Price);

    //                            //充值金额
    //                            $("#Amount").val(v.Price);
    //                            $("#MerchandiseID").val(v.MerchandiseID);

    //                            //删除禁用标志
    //                            $("#zhifuSub").removeClass("ui-state-disabled");
    //                        }
    //                    });
    //                    $("#controlgroup1").trigger('create');
    //                    $("input[type=radio]").checkboxradio('refresh');
    //                })
    //            } catch (e) {
    //                alert("查询套餐失败！" + e.message);
    //            }
    //        }).always(function () {
    //            loadStop();
    //            $("#button1").removeClass("ui-state-disabled");//删除禁用标志
    //        });
    //    },
    //    rules: {
    //        phone: {
    //            required: true,
    //            phone: true
    //        }
    //    },
    //    messages: {
    //        phone: {
    //            required: "请输入手机号码！",
    //            phone: "请输入正确的手机号码！"
    //        }
    //    }
    //});
//});

$(function () {
    $("#pageIndex [id=ftime]").val(new Date().toCommonCase());
    $("#pageIndex [id=ftime]").datetimePicker({ min: new Date().toCommonCase(), value: new Date().toCommonCase(), istime: false });

    $.alert("本页面仅供测试使用，如您不是测试人员，请关闭此页面，否则造成的一切财产损失，本站概不负责！","警告"); 

    //获取到达站信息
    $.showLoading();
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
                strStation = ArrToStr(stationJson, "Stationname");
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
                        $.toast("查询车票失败！");
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
                } catch (e) { $.toast("查询车票失败，"+e.message); }
            }).always(function () { $.hideLoading(); });
        };
    });
});

