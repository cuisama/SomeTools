var searchHistory = undefined;
chrome.storage.local.get({ "searchHistory": {} }, function (item) {
    searchHistory = item.searchHistory;
});
chrome.runtime.onMessage.addListener(function (request, sender, sendResponse) {
    if (typeof (request) == "string") {
        request = exec(request);
    }
    if (request) {
        var today = request.time.match(/\d{4}\/\d{1,2}\/\d{1,2}/)[0];
        request.time = request.time.match(/\d{1,2}:\d{1,2}:\d{1,2}/)[0];
        var current = request;
        searchHistory[today] = searchHistory[today] || {};
        searchHistory[today][current.key] = current.time;

        chrome.storage.local.set({ "searchHistory": searchHistory });
    }
});

var sync = chrome.contextMenus.create({
    type: 'normal',
    title: RM("sync"),
    contexts: ['browser_action'],
});

chrome.contextMenus.create({
    type: 'normal',
    title: RM("incDown"),
    contexts: ['browser_action'],
    onclick: increaseDownload,
    parentId: sync
});
chrome.contextMenus.create({
    type: 'normal',
    title: RM("incUp"),
    contexts: ['browser_action'],
    onclick: increaseUpload,
    parentId: sync
});
chrome.contextMenus.create({
    type: 'separator',
    contexts: ['browser_action'],
    parentId: sync
});
chrome.contextMenus.create({
    type: 'normal',
    title: RM("repDown"),
    contexts: ['browser_action'],
    onclick: replaceDownload,
    parentId: sync
});
chrome.contextMenus.create({
    type: 'normal',
    title: RM("repUp"),
    contexts: ['browser_action'],
    onclick: replaceUpload,
    parentId: sync
});

var other = chrome.contextMenus.create({
    type: 'normal',
    title: RM("other"),
    contexts: ['browser_action'],
});
chrome.contextMenus.create({
    type: 'normal',
    title: RM("formatData"),
    contexts: ['browser_action'],
    onclick: formatData,
    parentId: other
});

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
function increaseDownload() {
    chrome.storage.sync.get({ "searchHistory": {} }, function (item) {
        for (var date in item.searchHistory) {
            if (searchHistory[date]) {
                for (var key in item.searchHistory[date]) {
                    searchHistory[date][key] = item.searchHistory[date][key];
                }
            } else {
                searchHistory[date] = item.searchHistory[date];
            }
        }
        show(RM("finish"));
    });
}

function increaseUpload() {
    var temp = {};
    chrome.storage.local.get({ "searchHistory": {} }, function (item) {
        temp = item.searchHistory;
        chrome.storage.sync.get({ "searchHistory": {} }, function (item) {
            for (var date in item.searchHistory) {
                if (temp[date]) {
                    for (var key in item.searchHistory[date]) {
                        temp[date][key] = item.searchHistory[date][key];
                    }
                } else {
                    temp[date] = item.searchHistory[date];
                }
            }
            chrome.storage.sync.set({ "searchHistory": temp });
            show(RM("success"));
        });
    });
}

function replaceDownload() {
    chrome.storage.sync.get({ "searchHistory": {} }, function (item) {
        searchHistory = item.searchHistory;
        show(RM("finish"));
    });
}

function replaceUpload() {
    chrome.storage.sync.set({ "searchHistory": searchHistory }, function () {
        show(RM("success"));
    });
}

function show(msg) {
    alert(msg);
}

function exec(url) {
    var key = url;
    if (url.match(/(www.google.)/)) {
        key = url.match(/(\?|&)q=.*?&/);
        key = key[0].substring(3).replace("&", "");
    } else if (url.match(/(www.baidu.com)/)) {
        key = url.match(/(\?|&)wd=.*?(&|$)/);
        key = key[0].substring(4).replace("&", "");
    } else if (url.match(/(www.bing.com)/)) {
        key = url.match(/(\?|&)q=.*?(&|$)/);
        key = key[0].substring(3).replace("&", "");
    } else if (url.match(/(www.so.com)/)) {
        key = url.match(/(\?|&)q=.*?(&|$)/);
        key = key[0].substring(3).replace("&", "");
    } else if (url.match(/(www.sogou.com)/)) {
        key = url.match(/(\?|&)query=.*?(&|$)/);
        key = key[0].substring(7).replace("&", "");
    } else if (url.match(/(search.yahoo.)/)) {
        key = url.match(/(\?|&)p=.*?(&|$)/);
        key = key[0].substring(3).replace("&", "");
    }
    else {
        return;
    }

    key = decodeURIComponent(key);
    if (!key) return;
    var time = getTime();
    var current = {
        time: time,
        key: key
    };
    return current;
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