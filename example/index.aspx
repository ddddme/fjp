<%@ Page Language="C#" AutoEventWireup="true" CodeFile="index.aspx.cs" Inherits="example_index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="content-type" content="text/html;charset=utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <title>付家坡客运站</title>
    <script src="/js/jquery-weui/lib/jquery-2.1.4.js"></script>
    <link href="/js/jquery-weui/lib/weui.css" rel="stylesheet" />
    <link href="/js/jquery-weui/css/jquery-weui.css" rel="stylesheet" />
    <script src="/js/jqm/jquery.validate.min.js"></script>
    <script src="/js/jquery-weui/js/jquery-weui.js"></script>
    <script src="http://res.wx.qq.com/open/js/jweixin-1.0.0.js"></script>
    <script src="../js/userFun/enumPubdim.js"></script>
    <script src="/js/tyFunLk.js"></script>

    <script src="../js/userFun/index.js?ver=0.3"></script>
    <script src="../js/userFun/tickList.js?ver=0.3"></script>

    <style type="text/css">
        .ui-loader .ui-icon-loading {
            background-color: #D4D4D4;
        }
    </style>

    <style type="text/css">
        body {
            background-image: url(text.txt);
            background-attachment: fixed;
            height: 1000px;
        }

        .bottomNav {
            z-index: 999;
            position: fixed;
            top: 57px;
            left: 0;
            width: 100%;
            _position: absolute;
            _bottom: expression_r(documentElement.scrollTop + documentElement.clientHeight-this.offsetHeight);
            overflow: visible;
        }
    </style>

</head>
<body>
    <div class="weui_cells weui_cells_form" id="pageIndex">
        <form id="form1">
            <div class="weui_cell">
                <div class="weui_cell_hd">
                    <label class="weui_label" style="width: 130px;">出发地</label>
                </div>
                <div class="weui_cell_bd weui_cell_primary">
                    <input class="weui_input" type="tel" value="武汉" readonly="readonly" />
                </div>
            </div>
            <div class="weui_cell">
                <div class="weui_cell_hd">
                    <label for="ftime" class="weui_label" style="width: 130px;">出发日期</label>
                </div>
                <div class="weui_cell_bd weui_cell_primary">
                    <input class="weui_input" name="ftime" id="ftime" type="text" value="" />
                </div>
            </div>
            <div class="weui_cell">
                <div class="weui_cell_hd">
                    <label for="ddz" class="weui_label" style="width: 130px;">目的地</label>
                </div>
                <div class="weui_cell_bd weui_cell_primary">
                    <input class="weui_input" name="ddz" id="ddz" type="text" value="" />
                </div>
            </div>
            <a href="javascript:;" class="weui_btn weui_btn_plain_primary" id="search">查询</a>
            <input type="hidden" id="openid" value="<%=ViewState["openid"]%>" />
            <input type="hidden" id="appid" value="<%=FlowRecharge.Wechat.WxPayConfig.APPID%>" />
        </form>
    </div>
    <%--票列表--%>
    <div class="weui-popup-container" id="pageTickList">
        <div class="weui-popup-modal">
            <div class="weui_cells weui_cells_radio" id="pp1">
                <div class="weui_panel_hd" id="listHead">文字组合列表</div>
            </div>
        </div>
        <div id="bottomNav" class="bottomNav">
            <div class="weui_tabbar">
                <a href="javascript:;" id="closeList" class="weui_tabbar_item weui_btn_plain_primary close-popup">
                    <div class="weui_tabbar_icon">
                        <img src="path/to/images/icon_nav_button.png" alt="" />
                    </div>
                    <p class="weui_tabbar_label">关闭</p>
                </a>
                <a href="javascript:;" id="zf1" class="weui_tabbar_item weui_btn_disabled weui_btn_plain_primary">
                    <div class="weui_tabbar_icon">
                        <img src="path/to/images/icon_nav_msg.png" alt="" />
                    </div>
                    <p class="weui_tabbar_label">确定购票</p>
                </a>
            </div>
        </div>
    </div>
</body>
</html>

<script type="text/javascript">
    //微信JSSDK配置
    try {
        $.post("handler.aspx?rnd=" + new Date().getTime(),
            { clFun: en_clFun.获取微信JS配置签名, signUrl: location.href.split('#')[0] },
            function (data) {
                try {
                    var jsonData = JSON.parse(data);
                    wx.config({
                        debug: false,
                        appId: $("#pageIndex [id=appid]").val(),
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
                    $.alert("错误:" + e.message);
                }
            });
    } catch (e) { $.toast("错误:" + e.message); }
</script>

