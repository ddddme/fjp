//系统初始化
$(document).bind("mobileinit", function () {
    //处理按钮按下/划过的状态感觉反应有些迟缓
    $.mobile.buttonMarkup.hoverDelay = "false";
});
//页面初始化
$(document).on("pageinit", "#orderList", function () {
    $.post("handler.aspx?rnd=" + new Date().getTime() + "&type=1&openid=" + $("#openid").val() + "", function (data) {
        var objJson = JSON.parse(data.replace("正在中止线程。", ""));
        $("#li1").trigger('create');
        $.each(objJson, function (k, v) {
            $("#ul_lv").append("<li id=\"l1_" + v.tb_order_ID + "\" data-role=\"list-divider\">" +
                fmtDate(v.tb_order_CreateDate).toCommonCase(1) +"&nbsp;&nbsp;&nbsp;" +
            "<span class=\"ui-li-count\">" + v.tb_order_Status + "</span></li>");
            $("#ul_lv").append("<li id=\"l2_" + v.tb_order_ID + "\">" +
                "<p>充值手机：" + v.tb_order_phone + "</p>" +
                "<p>充值金额：" + Number(v.tb_order_Amount).toFixed(2) + "元</p>" +
                "<p>充值产品：" + v.tb_order_MerchandiseText + "</p></li>");
            $('#ul_lv').listview('refresh');
        })
    }).always(function () { loadStop(); });
});

