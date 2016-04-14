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

    //微信JSSDK配置
    try {
        $.post("handler.aspx?rnd=" + new Date().getTime(),
            { clFun: en_clFun.获取微信JS配置签名, signUrl: location.href.split('#')[0] },
            function (data) {
                try {
                    var jsonData = JSON.parse(data);
                    wx.config({
                        debug: false,
                        appId: $("$pageIndex [id=openid]").val(),
                        timestamp: jsonData.timestamp,          //时间戳
                        nonceStr: jsonData.noncestr,   //随机字符串
                        signature: jsonData.signature,
                        jsApiList: [
                            "checkJsApi",
                            "chooseImage",
                            "onMenuShareTimeline",
                            "closeWindow",
                            "chooseWXPay"
                        ]
                    });
                } catch (e) {
                    $.toast("错误:" + e.message);
                }
            });
    } catch (e) {$.toast("错误:" + e.message);}

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
                    $("#pageTickList [id=pp1]").empty();
                    $("#pageTickList [id=pp1]").append("<div class=\"weui_panel_hd\" id=\"listHead\">文字组合列表</div>");
                    $("#pageTickList [id=listHead]").html("<span style='font-size:16px;'>武汉-" +
                        $("#pageIndex [id=ddz]").val() + "&nbsp;" + $("#pageIndex [id=ftime]").val()+"</span>");
                    addTickList(JSON.parse(rvJson.value));
                    $("#pageTickList").popup();
                } catch (e) { $.toast("查询车票失败，"+e.message); }
            }).always(function () { $.hideLoading(); });
        };
    });
});
//付款买票
function callPay() {
    try {
        //下订单
        $("#zhifuSub").removeClass("ui-btn-active");//删除点击标志
        $("#zhifuSub").addClass("ui-state-disabled");//添加禁用标志
        $.showLoading();
        $.post("handler.aspx?rnd=" + new Date().getTime(),
            { clFun: en_clFun.统一下单, Amount: 0.01, MerchandiseText: "测试商品", MerchandiseSizeMB: 1, MerchandiseID: 1, phone: 1, openid: $("#openid").val() },
            function (data) {
                try {
                    var jsonData = JSON.parse(data);
                    if (jsonData.type == "1") {
                        $.alert("订单创建失败！" + jsonData.value, "警告！");
                        return;
                    }
                    var jsonPay = jsonData.value;
                    wx.chooseWXPay({
                        timestamp: jsonPay.timeStamp, // 支付签名时间戳，注意微信jssdk中的所有使用timestamp字段均为小写。但最新版的支付后台生成签名使用的timeStamp字段名需大写其中的S字符
                        nonceStr: jsonPay.nonceStr, // 支付签名随机串，不长于 32 位
                        package: jsonPay.package, // 统一支付接口返回的prepay_id参数值，提交格式如：prepay_id=***）
                        signType: 'MD5',
                        paySign: jsonPay.paySign, // 支付签名
                        success: function (res) {
                            $("#tcmc").html($("#MerchandiseText").val());
                            $("#toPageTwo").click();
                            $("#zhifuSub").removeClass("ui-state-disabled");//删除禁用标志
                        },
                        cancel: function () {
                            //用户取消
                            $("#zhifuSub").removeClass("ui-state-disabled");//删除禁用标志
                        },
                        fail: function (res) {
                            $.alert("支付失败:" + JSON.stringify(res), "警告！");
                            $("#zhifuSub").removeClass("ui-state-disabled");//删除禁用标志
                        }
                    });
                } catch (e) {
                    $.alert("错误:" + e.message, "警告！");
                    $("#zhifuSub").removeClass("ui-state-disabled");//删除禁用标志
                }
            }).always(function () { $.hideLoading(); });
    } catch (e) {
        $.hideLoading();
        $.alert("错误:" + e.message, "警告！");
        $("#zhifuSub").removeClass("ui-state-disabled");//删除禁用标志
    }
}
