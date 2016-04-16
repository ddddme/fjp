//通用JS类库
function _Y(id) { return document.getElementById(id) }
//去处左右空格
function jtrim(sstr) {
    /// <summary>去掉左右空格</summary>
    var astr = "";
    var dstr = "";
    var flag = 0;
    for (i = 0; i < sstr.length; i++) {
        if ((sstr.charAt(i) != ' ') || (flag != 0)) {
            dstr += sstr.charAt(i);
            flag = 1;
        }
    }
    flag = 0;
    for (i = dstr.length - 1; i >= 0; i--) {
        if ((dstr.charAt(i) != ' ') || (flag != 0)) {
            astr += dstr.charAt(i);
            flag = 1;
        }
    }
    dstr = "";
    for (i = astr.length - 1; i >= 0; i--) dstr += astr.charAt(i);
    return dstr;
}
//将字符串转为数字
String.prototype.toNumber = function (pNumerLenger) {
    /// <summary>将字符串转为数字</summary>
    /// <param name="pNumerLenger" type="Number">返回数字的位数,默认为0</param>
    /// <returns type="Number">返回一个指定位数的数字，如果对象无法转换为数字，那么返回0</returns>
    if (nullToEmt(pNumerLenger) == "")
        pNumerLenger = 0;
    if (isNaN(this))
        return 0;
    return Number(this).toFixed(pNumerLenger);
}
//转为空
function nullToEmt(pStr) {
    if (typeof (pStr) == "function") return pStr;
    if (typeof (pStr) == "number") return pStr;
    if (pStr == null) return "";
    if (pStr == "") return "";
    if (typeof (pStr) == "undefined") return "";
    if (pStr == "undefined") return "";
    return pStr;
}
//字符串转为BOOL值
function strToBoolean(pStr) {
    if (typeof (pStr) == "boolean")
        return pStr;
    if (typeof (pStr) == "string") {
        if (pStr == "true")
            return true;
    }
    return false;
}
String.prototype.jtrim = function () {
    return jtrim(this);
}
//获取URL根目录
function getRootPath() {
    var strFullPath = window.document.location.href;
    var strPath = window.document.location.pathname;
    var pos = strFullPath.indexOf(strPath);
    var prePath = strFullPath.substring(0, pos);
    var postPath = strPath.substring(0, strPath.substr(1).indexOf('/') + 1);
    return (prePath + postPath);
}
//| 求两个时间的天数差 日期格式为 YYYY-MM-dd 
function daysBetween(DateOne, DateTwo) {
    /// <summary>比较日期差 dtEnd 格式为日期型或者 有效日期格式字符串 </summary>
    /// <param name="DateOne" type="char">第一个日期</param>
    /// <param name="DateTwo" type="number">第二个日期</param>
    var OneMonth = DateOne.substring(5, DateOne.lastIndexOf('-'));
    var OneDay = DateOne.substring(DateOne.length, DateOne.lastIndexOf('-') + 1);
    var OneYear = DateOne.substring(0, DateOne.indexOf('-'));

    var TwoMonth = DateTwo.substring(5, DateTwo.lastIndexOf('-'));
    var TwoDay = DateTwo.substring(DateTwo.length, DateTwo.lastIndexOf('-') + 1);
    var TwoYear = DateTwo.substring(0, DateTwo.indexOf('-'));

    var cha = ((Date.parse(OneMonth + '/' + OneDay + '/' + OneYear) - Date.parse(TwoMonth + '/' + TwoDay + '/' + TwoYear)) / 86400000);
    return Math.abs(cha);
}
//| 日期计算 
Date.prototype.DateAdd = function (strInterval, Number) {
    /// <summary>比较日期差 dtEnd 格式为日期型或者 有效日期格式字符串 </summary>
    /// <param name="strInterval" type="char">日期格式</param>
    /// <param name="Number" type="number">增加的数字</param>
    var dtTmp = this;
    switch (strInterval) {
        case 's': return new Date(Date.parse(dtTmp) + (1000 * Number));
        case 'n': return new Date(Date.parse(dtTmp) + (60000 * Number));
        case 'h': return new Date(Date.parse(dtTmp) + (3600000 * Number));
        case 'd': return new Date(Date.parse(dtTmp) + (86400000 * Number));
        case 'w': return new Date(Date.parse(dtTmp) + ((86400000 * 7) * Number));
        case 'q': return new Date(dtTmp.getFullYear(), (dtTmp.getMonth()) + Number * 3, dtTmp.getDate(), dtTmp.getHours(), dtTmp.getMinutes(), dtTmp.getSeconds());
        case 'm': return new Date(dtTmp.getFullYear(), (dtTmp.getMonth()) + Number, dtTmp.getDate(), dtTmp.getHours(), dtTmp.getMinutes(), dtTmp.getSeconds());
        case 'y': return new Date((dtTmp.getFullYear() + Number), dtTmp.getMonth(), dtTmp.getDate(), dtTmp.getHours(), dtTmp.getMinutes(), dtTmp.getSeconds());
    }
}
//| 比较日期差
Date.prototype.DateDiff = function (strInterval, dtEnd) {
    /// <summary>比较日期差 dtEnd 格式为日期型或者 有效日期格式字符串 </summary>
    /// <param name="strInterval" type="char">日期格式</param>
    /// <param name="dtEnd" type="string">格式为日期型或者 有效日期格式字符串</param>
    var dtStart = this;
    if (typeof dtEnd == 'string')//如果是字符串转换为日期型 
    {
        dtEnd = StringToDate(dtEnd);
    }
    switch (strInterval) {
        case 's': return parseInt((dtEnd - dtStart) / 1000);
        case 'n': return parseInt((dtEnd - dtStart) / 60000);
        case 'h': return parseInt((dtEnd - dtStart) / 3600000);
        case 'd': return parseInt((dtEnd - dtStart) / 86400000);
        case 'w': return parseInt((dtEnd - dtStart) / (86400000 * 7));
        case 'm': return (dtEnd.getMonth() + 1) + ((dtEnd.getFullYear() - dtStart.getFullYear()) * 12) - (dtStart.getMonth() + 1);
        case 'y': return dtEnd.getFullYear() - dtStart.getFullYear();
    }
}
//时间格式转换
Date.prototype.toCommonCase = function (pType) {
    /// <summary>返回YYYY-MM-DD HHMSSS格式的日期</summary>
    /// <param name="pType" type="int">转换形式，1为带小时分秒</param>
    var xYear = this.getFullYear();
    if (isNaN(xYear))
        return "";

    var xMonth = this.getMonth() + 1;
    if (xMonth < 10) {
        xMonth = "0" + xMonth;
    }

    var xDay = this.getDate();
    if (xDay < 10) {
        xDay = "0" + xDay;
    }

    var xHours = this.getHours();
    if (xHours < 10) {
        xHours = "0" + xHours;
    }

    var xMinutes = this.getMinutes();
    if (xMinutes < 10) {
        xMinutes = "0" + xMinutes;
    }

    var xSeconds = this.getSeconds();
    if (xSeconds < 10) {
        xSeconds = "0" + xSeconds;
    }
    if (pType == 1) {
        return xYear + "-" + xMonth + "-" + xDay + " " + xHours + ":" + xMinutes + ":" + xSeconds;
    }
    return xYear + "-" + xMonth + "-" + xDay;//+" "+xHours+":"+xMinutes+":"+xSeconds;
}
fmtDate = function (pStr) {
    /// <summary>返回美式日期用/代替-</summary>
    /// <param name="pStr" type="Date">要转换的日期</param>
    /// <returns type="Number">返回美式日期</returns>
    var mydate;
    try {
        var sst = pStr.replace(new RegExp("-", 'g'), "/");
        mydate = new Date(Date.parse(sst));
    }
    catch (e) {
        mydate = null;
    }
    finally {
        return mydate
    }
}
getWeekDay = function (dateStr) {
    var weekDay = ["星期天", "星期一", "星期二", "星期三", "星期四", "星期五", "星期六"];
    try {
        var myDate = new Date(Date.parse(dateStr.replace(/-/g, "/")));
        return weekDay[myDate.getDay()];
    } catch (e) {
        return "";
    }
}
//html编码
function myHTMLEncode(html) {
    var temp = document.createElement("div");
    (temp.textContent != null) ? (temp.textContent = html) : (temp.innerText = html);
    var output = temp.innerHTML;
    temp = null;
    return output;
}
//html解码
myHTMLDecode = function (text) {
    var temp = document.createElement("div");
    temp.innerHTML = text;
    var output = temp.innerText || temp.textContent;
    temp = null;
    return output;
}
function sleep(sleepTime) {
    for (var start = Date.now() ; Date.now() - start <= sleepTime;) { }
}
//将数组中的某个元素转为，隔开的字符串
function ArrToStr(pArr, pColName) {
    var tVa = "";
    $.each(pArr, function (k, v) {
        if (typeof (v) == "string")
            tVa += "," + v;
        else {
            if (pColName in v)
                tVa += "," + eval("v." + pColName);
        }
    });
    return tVa.substring(1, tVa.length);
}
function sleep(sleepTime) {
    for (var start = Date.now() ; Date.now() - start <= sleepTime;) { }
}
//生成GUID
function guid() {
    return 'xxxxxxxx-xxxx-4xxx-yxxx-xxxxxxxxxxxx'.replace(/[xy]/g, function (c) {
        var r = Math.random() * 16 | 0, v = c == 'x' ? r : (r & 0x3 | 0x8);
        return v.toString(16);
    });
}
String.prototype.PadLeft = function (totalWidth, paddingChar) {
    /// <summary>
    ///返回一个新字符串，该字符串通过在此实例中的字符左侧填充指定的 Unicode 字符来达到指定的总长度，从而使这些字符右对齐。
    ///</summary>
    /// <param name="totalWidth" type="int">结果字符串中的字符数，等于原始字符数加上任何其他填充字符。</param>
    /// <param name="paddingChar" type="string">Unicode 填充字符。</param>
    /// <returns type="string">与此实例等效的一个新字符串，但该字符串为右对齐，因此，在左侧填充所需任意数量的 paddingChar 字符，使长度达到 totalWidth。如果totalWidth 小于此实例的长度，则为与此实例相同的新字符串。</returns>
    if (paddingChar != null) {
        return this.PadHelper(totalWidth, paddingChar, false);
    } else {
        return this.PadHelper(totalWidth, ' ', false);
    }
}
String.prototype.PadRight = function (totalWidth, paddingChar) {
    /// <summary>
    ///返回一个新字符串，该字符串通过在此实例中的字符右侧填充指定的 Unicode 字符来达到指定的总长度，从而使这些字符左对齐。
    ///</summary>
    /// <param name="totalWidth" type="int">结果字符串中的字符数，等于原始字符数加上任何其他填充字符。</param>
    /// <param name="paddingChar" type="string">Unicode 填充字符。</param>
    /// <returns type="string">与此实例等效的一个新字符串，但该字符串为左对齐，因此，在右侧填充所需任意数量的 paddingChar 字符，<br/>
    ///使长度达到 totalWidth。如果totalWidth 小于此实例的长度，则为与此实例相同的新字符串。</returns>
    if (paddingChar != null) {
        return this.PadHelper(totalWidth, paddingChar, true);
    } else {
        return this.PadHelper(totalWidth, ' ', true);
    }
}
String.prototype.PadHelper = function (totalWidth, paddingChar, isRightPadded) {
    /// <summary>
    ///返回一个新字符串，该字符串会补齐指定位数的字符。
    ///</summary>
    /// <param name="totalWidth" type="int">结果字符串中的字符数，等于原始字符数加上任何其他填充字符。</param>
    /// <param name="paddingChar" type="string">Unicode 填充字符。</param>
    /// <param name="isRightPadded" type="bool">是否从右侧开始补齐。</param>
    /// <returns type="string">与此实例等效的一个新字符串，使长度达到 totalWidth。如果totalWidth 小于此实例的长度，则为与此实例相同的新字符串。</returns>
    if (this.length < totalWidth) {
        var paddingString = new String();
        for (i = 1; i <= (totalWidth - this.length) ; i++) {
            paddingString += paddingChar;
        }
        if (isRightPadded) {
            return (this + paddingString);
        } else {
            return (paddingString + this);
        }
    } else {
        return this;
    }
}
//表单赋值
function setFormValue(pForm, pJson) {
    //初始化表单
    for (var key in pJson) {
        var tControl = pForm.find("[id=" + key + "]");
        if (tControl != undefined)
            tControl.val(eval("pJson." + key));
    }
}

