//Uploading
function onBeginSubmit(layer_index) {
    layer_index = layer.load(0, { shade: false });
} 

function getClipboardText() { 
    var clipboard = new ClipboardJS('.clipboard'); 
    clipboard.on('success', function (e) {
        console.log(e);
        layer.msg('copy');
    });
}
//参数n为休眠时间，单位为毫秒:
function sleep(numberMillis) {
    var now = new Date();
    var exitTime = now.getTime() + numberMillis;
    var loop1 = true;
    while (loop1) {
        now = new Date();
        console.log(now);
        if (now.getTime() > exitTime)
            return;
    }
}
function layerTips(msg) {
    //提示
    var PopupTips = layer.open({
          content: msg
        , skin: 'msg'
        , time: 3
    });
} 

 
////用法 ： var str = "{0}{1}".StringFormat("Eric", "Yu");
// str = "EricYu"
String.prototype.StringFormat = function () {
    if (arguments.length === 0) {
        return this;
    }
    for (var StringFormat_s = this, StringFormat_i = 0; StringFormat_i < arguments.length; StringFormat_i++) {
        StringFormat_s = StringFormat_s.replace(new RegExp("\\{" + StringFormat_i + "\\}", "g"), arguments[StringFormat_i]);
    }
    return StringFormat_s;
};

//--Time Business Start--------------------------------
function TurnToMinutes(strTimeSpan) {

    var splitarr = strTimeSpan.split(":");
    var Hours = parseInt(splitarr[0]);
    var min1 = Hours * 60;
    var min2 = parseInt(splitarr[1]);
    var totalmins = min1 + min2;

    return totalmins;
}
function ReturnValIndex(totalmins) {

    for (var i = 0; i < custom_values.length; i++) {

        if (custom_values[i] === totalmins) { 
            return i;
        }
    }
}
function MinsScaleIndex(TimeSpan) {

    var totalmins = TurnToMinutes(TimeSpan);
    var index = ReturnValIndex(totalmins);
    return index;
}
function my_prettify(n) {

    hours = Math.floor(n / 60).toString();
    minutes = (n % 60).toString();
    if (n !== 0 && n !== '' && n !== null) {
        result = hours + ':' + (minutes.length < 2 ? '0' + minutes : minutes);
        if (result === "24:00") {
            result = "23:59";
        }
        if (result === "11:59") {
            result = "11:59";
        }
        return result;
    } else {
        return '00:00';
    }
}

function my_percent(n) {

    result = n + '%'
    return result;
}

//调用 getQueryVariable("id") 返回 1。  http://www.runoob.com/index.php?id=1&image=awesome.jpg
//调用 getQueryVariable("image") 返回 "awesome.jpg"。
//get url params
function GetQueryVariable(variable) {
    var query = window.location.search.substring(1);
    var vars = query.split("&");
    for (var i = 0; i < vars.length; i++) {
        var pair = vars[i].split("=");
        if (pair[0] == variable) { return pair[1]; }
    }
    return (false);
}
function preventSubmit(e) {
    if (document.all) {
        e.returnValue;
    } else {
        e.preventDefault();
    }
}
//调用 getQueryVariable("id") 返回 1。  http://www.runoob.com/index.php?id=1&image=awesome.jpg
//调用 getQueryVariable("image") 返回 "awesome.jpg"。
//get url params
function GetQueryVariable(variable) {
    var query = window.location.search.substring(1);
    var vars = query.split("&");
    for (var i = 0; i < vars.length; i++) {
        var pair = vars[i].split("=");
        if (pair[0] == variable) { return pair[1]; }
    }
    return (false);
}

//  /**
//* 通用的打开下载对话框方法，没有测试过具体兼容性
//*  param url 下载地址，也可以是一个blob对象，必选
//*  param saveName 保存文件名，可选
//*/
function openDownloadDialog(url, saveName) {
    if (typeof url == 'object' && url instanceof Blob) {
        url = URL.createObjectURL(url); // 创建blob地址
    }

    var aLink = document.createElement('a');
    aLink.href = url;
    aLink.download = saveName || ''; // HTML5新增的属性，指定保存文件名，可以不要后缀，注意，file:///模式下不会生效
    var event;

    if (window.MouseEvent)
        event = new MouseEvent('click');
    else {
        event = document.createEvent('MouseEvents');
        event.initMouseEvent('click', true, false, window, 0, 0, 0, 0, 0, false, false, false, false, 0, null);
    }
    aLink.dispatchEvent(event);
}