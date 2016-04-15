/// <reference path="/js/jquery-weui/lib/jquery-2.1.4.js" />
/// <reference path="/js/userFun/enumPubdim.js" />
/// <reference path="/js/jquery-weui/js/jquery-weui.js" />
/// <reference path="/js/tyFunLk.js" />
$(function () {
    $("#pageTickList [id=pp1]").css("margin-top", "57px");

    $("#pageTickList [id=zf1]").click(function () {
        var tickJson = null;
        var BatchID="";
        $("#pageTickList [id=pp1]").find("input").each(function (k, v) {
            if (v.checked) {
                tickJson = $(v).data("tickInfo");
                BatchID=$("#pageTickList [id=listHead]").data("BatchID");
                return false;
            }
        });
        if (tickJson == null)
        {
            $.toast("没有选择车票！");
            return;
        }
        $.modal({
            title: "确定购买",
            text: "<div class=\"weui_cell\">" + "\n" +
            "<div class=\"weui_cell_hd\">" + "\n" +
            "<label class=\"weui_label\" style=\"width: 80px;text-align:right;\">车次：</label>" + "\n" +
            "</div>" + "\n" +
            "<div class=\"weui_cell_hd\">" + "\n" +
            "<label class=\"weui_label\" style=\"width: 200px;text-align:left;\">" + tickJson.Checi+ "</label>" + "\n" +
            "</div>" + "\n" +
            "</div>" + "\n" +
            "<div class=\"weui_cell\">" + "\n" +
            "<div class=\"weui_cell_hd\">" + "\n" +
            "<label class=\"weui_label\" style=\"width: 80px;text-align:right;\">出发站：</label>" + "\n" +
            "</div>" + "\n" +
            "<div class=\"weui_cell_hd\">" + "\n" +
            "<label class=\"weui_label\" style=\"width: 200px;text-align:left;\">武汉</label>" + "\n" +
            "</div>" + "\n" +
            "</div>" + "\n" +
            "<div class=\"weui_cell\">" + "\n" +
            "<div class=\"weui_cell_hd\">" + "\n" +
            "<label class=\"weui_label\" style=\"width: 80px;text-align:right;\">目的站：</label>" + "\n" +
            "</div>" + "\n" +
            "<div class=\"weui_cell_hd\">" + "\n" +
            "<label class=\"weui_label\" style=\"width: 200px;text-align:left;\">" + tickJson.Destination + "</label>" + "\n" +
            "</div>" + "\n" +
            "</div>" +
            "<div class=\"weui_cell\">" + "\n" +
            "                <div class=\"weui_cell_hd\">" + "\n" +
            "                    <label class=\"weui_label\" style=\"width: 80px;text-align:right;\">发车时间：</label>" + "\n" +
            "                </div>" + "\n" +
            "                <div class=\"weui_cell_hd\">" + "\n" +
            "                    <label class=\"weui_label\" style=\"width: 200px;text-align:left;\">" + fmtDate(tickJson.FcDate).toCommonCase() + " " + tickJson.FcTime + "</label>" + "\n" +
            "                </div>" + "\n" +
            "            </div>"+
            "<div class=\"weui_cell\">" + "\n" +
            "                <div class=\"weui_cell_hd\">" + "\n" +
            "                    <label class=\"weui_label\" style=\"width: 80px;text-align:right;\">票价：</label>" + "\n" +
            "                </div>" + "\n" +
            "                <div class=\"weui_cell_hd\">" + "\n" +
            "                    <label class=\"weui_label\" style=\"width: 200px;text-align:left;\">" + tickJson.Price + "</label>" + "\n" +
            "                </div>" + "\n" +
            "            </div>"
            ,
            buttons: [
              {
                  text: "微信支付", onClick: function () {
                      callPay(tickJson, BatchID);
                  }
              },
              { text: "取消", className: "default", onClick: function () { console.log(3) } },
            ]
        });
    });
});
//
function addTickList(pJson) {
    var strTickCell = "";

    $.each(pJson, function (k, v) {
        strTickCell = "<label class=\"weui_cell weui_check_label\" for=\"x" + k + "\">" + "\n" +
        "<div class=\"weui_cell_bd weui_cell_primary\">" + "\n" +
        "<p>车次：" + v.Checi + "&nbsp发车时间：" + v.FcTime + "&nbsp票价：" + v.Price + "</p>" + "\n" +
        "</div>" + "\n" +
        "<div class=\"weui_cell_ft\">" + "\n" +
        "<input type=\"radio\" class=\"weui_check\" name=\"radio1\" id=\"x" + k + "\" />" + "\n" +
        "<span class=\"weui_icon_checked\"></span>" + "\n" +
        "</div>" + "\n" +
        " </label>";
        $("#pageTickList [id=pp1]").append(strTickCell);
        $("#x"+k).data("tickInfo", v);
    });
   // $("#pageTickList [id=pp1]").append(strTickCell);
//    "<input type=\"hidden\" name=\"Checi\" id=\"Checi" + k + "\" value=\"" + v.Checi + "\"/>" + "\n" +
//"<input type=\"hidden\" name=\"FcTime\" id=\"FcTime" + k + "\" value=\"" + v.FcTime + "\"/>" + "\n" +
}
//付款买票
function callPay(pJson, pBatchID) {
    try {
        //下订单

        $.showLoading();
        $.post("handler.aspx?rnd=" + new Date().getTime(),
            $.extend({}, pJson, { clFun: en_clFun.统一下单, openid: $("#pageIndex [id=openid]").val(), BatchID: pBatchID, Amount: 0.01 }),//Amount: pJson.Price
            function (data) {
                try {
                    var jsonData = JSON.parse(data);
                    if (!jsonData.success) {
                        $.alert("订单创建失败！" + jsonData.msg, "警告！");
                        return;
                    }
                    var jsonPay = JSON.parse(jsonData.value);
                    wx.chooseWXPay({
                        timestamp: jsonPay.timeStamp, // 支付签名时间戳，注意微信jssdk中的所有使用timestamp字段均为小写。但最新版的支付后台生成签名使用的timeStamp字段名需大写其中的S字符
                        nonceStr: jsonPay.nonceStr, // 支付签名随机串，不长于 32 位
                        package: jsonPay.package, // 统一支付接口返回的prepay_id参数值，提交格式如：prepay_id=***）
                        signType: 'MD5',
                        paySign: jsonPay.paySign, // 支付签名
                        success: function (res) {
                            $("#toPageTwo").click();
                        },
                        cancel: function () {
                        },
                        fail: function (res) {
                            $.alert("支付失败:" + JSON.stringify(res), "警告！");
                        }
                    });
                } catch (e) {
                    $.alert("错误:" + e.message, "警告！");
                }
            }).always(function () { $.hideLoading(); });
    } catch (e) {
        $.hideLoading();
        $.alert("错误:" + e.message, "警告！");
    }
}
