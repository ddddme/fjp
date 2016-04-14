/// <reference path="/js/jquery-weui/lib/jquery-2.1.4.js" />
/// <reference path="/js/userFun/enumPubdim.js" />
/// <reference path="/js/jquery-weui/js/jquery-weui.js" />
/// <reference path="/js/tyFunLk.js" />
$(function () {
    $("#pageTickList [id=pp1]").css("margin-top", "57px");

    $("#pageTickList [id=zf1]").click(function () {
        $.modal({
            title: "Hello",
            text: "我是自定义的modal",
            buttons: [
              {
                  text: "微信支付", onClick: function () {
                      callPay();
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

    $.each(pJson, function (k,v) {
        strTickCell+="<label class=\"weui_cell weui_check_label\" for=\"x"+k+"\">" + "\n" +
        "<div class=\"weui_cell_bd weui_cell_primary\">" + "\n" +
        "<p>车次：0091&nbsp发车时间：07-12&nbsp票价：171</p>" + "\n" +
        "</div>" + "\n" +
        "<div class=\"weui_cell_ft\">" + "\n" +
        "<input type=\"radio\" class=\"weui_check\" name=\"radio1\" id=\"x"+k+"\" />" + "\n" +
        "<span class=\"weui_icon_checked\"></span>" + "\n" +
        "</div>" + "\n" +
        " </label>";
    });
    $("#pageTickList [id=pp1]").empty();
    $("#pageTickList [id=pp1]").append(strTickCell);
}
