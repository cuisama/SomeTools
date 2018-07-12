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
    title: 'sync（同步）',
    contexts: ['browser_action'],
});

chrome.contextMenus.create({
    type: 'normal',
    title: 'Increase Download（增量下载）',
    contexts: ['browser_action'],
    onclick: increaseDownload,
    parentId: sync
});
chrome.contextMenus.create({
    type: 'normal',
    title: 'Increase Upload（增量上传）',
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
    title: 'Replace Download（替换下载）',
    contexts: ['browser_action'],
    onclick: replaceDownload,
    parentId: sync
});
chrome.contextMenus.create({
    type: 'normal',
    title: 'Replace Upload（替换上传）',
    contexts: ['browser_action'],
    onclick: replaceUpload,
    parentId: sync
});

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
        show("finish");
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
            show("success");
        });
    });
}

function replaceDownload() {
    chrome.storage.sync.get({ "searchHistory": {} }, function (item) {
        searchHistory = item.searchHistory;
        show("finish");
    });
}

function replaceUpload() {
    chrome.storage.sync.set({ "searchHistory": searchHistory }, function () {
        show("success");
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
        key = key[0].substring(4).replace("&", "");
    } else if (url.match(/(www.so.com)/)) {
        key = url.match(/(\?|&)q=.*?(&|$)/);
        key = key[0].substring(4).replace("&", "");
    } else if (url.match(/(www.sogou.com)/)) {
        key = url.match(/(\?|&)query=.*?(&|$)/);
        key = key[0].substring(4).replace("&", "");
    } else if (url.match(/(search.yahoo.)/)) {
        key = url.match(/(\?|&)p=.*?(&|$)/);
        key = key[0].substring(4).replace("&", "");
    }
    else {
        return;
    }

    key = decodeURIComponent(key);
    if (!key) return;
    var date = new Date();
    //var time = .toLocaleString();
    var time = 1900 + date.getYear() + "/" + (date.getMonth() + 1) + "/" + (date.getDate()) + " " + (date.getHours()) + ":" + date.getMinutes() + ":" + date.getSeconds();
    var current = {
        time: time,
        key: key
    };
    return current;
}