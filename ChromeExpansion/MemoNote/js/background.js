function formatData() {
    var temp = {};
    for (var date in searchHistory) {
        var v = date.split('/');
        var nDate = v[0] + "/" + pf(v[1], 2, '0') + "/" + pf(v[2], 2, '0');
        temp[nDate] = temp[nDate] || {};
        for (var key in searchHistory[date]) {
            var s = searchHistory[date][key].split(':');
            temp[nDate][key] = pf(s[0], 2, '0') + ":" + pf(s[1], 2, '0') + ":" + pf(s[2], 2, '0');
        }
        if (JSON.stringify(temp[nDate]) == "{}") {
            delete temp[nDate];
        }
    }
    searchHistory = objKeySort(temp);
    show(RM("finish"));
}

function objKeySort(obj) {
    var newkey = Object.keys(obj).sort();
    var newObj = {};
    for (var i = 0; i < newkey.length; i++) {
        if (obj[newkey[i]] instanceof Object) {
            newObj[newkey[i]] = objKeySort(obj[newkey[i]]);
        }else{
            newObj[newkey[i]] = obj[newkey[i]];
        }
    }
    return newObj;
}

function pf(str, l, c) {
    return (new Array(l + 1).join(c) + str).slice(-2);
}
function getTime() {
    var date = new Date();
    return 1900 + date.getYear() + "/" 
        + pf(date.getMonth() + 1, 2, '0') + "/" 
        + pf(date.getDate(), 2, '0') + " " 
        + pf(date.getHours(), 2, '0') + ":" 
        + pf(date.getMinutes(), 2, '0') + ":" 
        + pf(date.getSeconds(), 2, '0');
}

function show(msg) {
    alert(msg);
}

function RM(key) {
    return chrome.i18n.getMessage(key);
}
function showVersionUpdate() {
    var xhr = new XMLHttpRequest();
    xhr.onreadystatechange = function () {
        if (xhr.readyState == 4) {
            if (xhr.status >= 200 && xhr.status < 300 || xhr.status == 304) {
                var versionCode = xhr.responseText.match(/versionCode:\[.*\]/)[0];
                versionCode = versionCode.match(/\[.*\]/)[0];
                versionCode = versionCode.substring(1, versionCode.length - 1);
                var reg = new RegExp("versionMsg_" + RM("locale") + ":\\[.*\\]");
                var versionMsg = reg.exec(xhr.responseText)[0];
                versionMsg = versionMsg.match(/\[.*\]/)[0];
                versionMsg = versionMsg.substring(1, versionMsg.length - 1);
                if (compVersion(RM("version"), versionCode) < 0) {
                    chrome.notifications.create(null, {
                        type: 'basic',
                        iconUrl: 'img/wa.png',
                        title: RM("versionCode"),
                        message: versionMsg.split('\\n').join("\n")
                    });
                }
            }
        }
    };
    xhr.open("get", "https://blog.csdn.net/AHcpCuiIan/article/details/81096205", true);
    xhr.send();
}

function compVersion(v1,v2) {
    s1 = v1.split('.');
    s2 = v2.split('.');
    for (var i = 0; i < 3; i++) {
        if (s1[i] == s2[i]) continue;
        break;
    }
    return s1[i] - s2[i];
}

function mediaCss(document) {
    var css = screen.width <= 1024 ? "1024" : screen.width <= 1440 ? "1440" : "1960";
    document.write("<link href='/css/" + css + ".css' rel='stylesheet' type='text/css' />");
}