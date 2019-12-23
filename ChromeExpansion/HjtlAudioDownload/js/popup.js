var bg = chrome.extension.getBackgroundPage();

document.getElementById("filename").innerHTML = bg.filename;

document.getElementById("download").onclick = function () {
    if(bg.success){
        download(bg.url, bg.filename);
    }else{
        getInfo({cmd:'getInfo'}, function(response){
            bg.dealInfo(response);
            document.getElementById("filename").innerHTML = bg.filename;
            if(bg.success){
                download(bg.url, bg.filename);
            }
        });
    }
}

//直接从centent-script.js获取信息
function getInfo(message, callback){
    chrome.tabs.query({active: true, currentWindow: true}, function(tabs){
        chrome.tabs.sendMessage(tabs[0].id, message, function(response){
            if(callback) callback(response);
        });
    });
}

//url:文件地址 filename:想要修改为的名称
function download(url, filename) {
    getBlob(url, function (blob) {
        saveAs(blob, filename);
    });
};

function getBlob(url, cb) {
    var xhr = new XMLHttpRequest();
    xhr.open('GET', url, true);
    xhr.responseType = 'blob';
    xhr.onload = function () {
        if (xhr.status === 200) {
            cb(xhr.response);
        }
    };
    xhr.send();
}

function saveAs(blob, filename) {
    if (window.navigator.msSaveOrOpenBlob) {
        navigator.msSaveBlob(blob, filename);
    } else {
        var link = document.createElement('a');
        var body = document.querySelector('body');
        link.href = window.URL.createObjectURL(blob);
        link.download = filename;
        // fix Firefox
        link.style.display = 'none';
        body.appendChild(link);
        link.click();
        body.removeChild(link);
        window.URL.revokeObjectURL(link.href);
    };
}