/// <reference path="/js/jquery-weui/lib/jquery-2.1.4.js" />
/// <reference path="/js/userFun/enumPubdim.js" />
/// <reference path="/js/jquery-weui/js/jquery-weui.js" />
/// <reference path="/js/tyFunLk.js" />
$(function () {
    $("#pageTickList [id=pp1]").css("margin-top", "57px");

    $("#pageTickList [id=zf1]").click(function () {
        $("#pageTickList [id=pp1]").find("input[check=true]");
        $.modal({
            title: "确定购买",
            text: "<div class=\"weui_cell\">" + "\n" +
            "<div class=\"weui_cell_hd\">" + "\n" +
            "<label class=\"weui_label\" style=\"width: 80px;text-align:right;\">车次：</label>" + "\n" +
            "</div>" + "\n" +
            "<div class=\"weui_cell_hd\">" + "\n" +
            "<label class=\"weui_label\" style=\"width: 100px;text-align:left;\">A1909</label>" + "\n" +
            "</div>" + "\n" +
            "</div>" + "\n" +
            "<div class=\"weui_cell\">" + "\n" +
            "<div class=\"weui_cell_hd\">" + "\n" +
            "<label class=\"weui_label\" style=\"width: 80px;text-align:right;\">出发站：</label>" + "\n" +
            "</div>" + "\n" +
            "<div class=\"weui_cell_hd\">" + "\n" +
            "<label class=\"weui_label\" style=\"width: 100px;text-align:left;\">武汉</label>" + "\n" +
            "</div>" + "\n" +
            "</div>" + "\n" +
            "<div class=\"weui_cell\">" + "\n" +
            "<div class=\"weui_cell_hd\">" + "\n" +
            "<label class=\"weui_label\" style=\"width: 80px;text-align:right;\">目的站：</label>" + "\n" +
            "</div>" + "\n" +
            "<div class=\"weui_cell_hd\">" + "\n" +
            "<label class=\"weui_label\" style=\"width: 100px;text-align:left;\">安庆</label>" + "\n" +
            "</div>" + "\n" +
            "</div>" +
            "<div class=\"weui_cell\">" + "\n" +
            "                <div class=\"weui_cell_hd\">" + "\n" +
            "                    <label class=\"weui_label\" style=\"width: 80px;text-align:right;\">发车时间：</label>" + "\n" +
            "                </div>" + "\n" +
            "                <div class=\"weui_cell_hd\">" + "\n" +
            "                    <label class=\"weui_label\" style=\"width: 100px;text-align:left;\">2012-09-09</label>" + "\n" +
            "                </div>" + "\n" +
            "            </div>"+
            "<div class=\"weui_cell\">" + "\n" +
            "                <div class=\"weui_cell_hd\">" + "\n" +
            "                    <label class=\"weui_label\" style=\"width: 80px;text-align:right;\">票价：</label>" + "\n" +
            "                </div>" + "\n" +
            "                <div class=\"weui_cell_hd\">" + "\n" +
            "                    <label class=\"weui_label\" style=\"width: 100px;text-align:left;\">171</label>" + "\n" +
            "                </div>" + "\n" +
            "            </div>"
            ,
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
        $("#x"+k).data("tickInfo",v);
    });
   // $("#pageTickList [id=pp1]").append(strTickCell);
//    "<input type=\"hidden\" name=\"Checi\" id=\"Checi" + k + "\" value=\"" + v.Checi + "\"/>" + "\n" +
//"<input type=\"hidden\" name=\"FcTime\" id=\"FcTime" + k + "\" value=\"" + v.FcTime + "\"/>" + "\n" +
}
