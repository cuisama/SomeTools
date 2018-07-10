
var oldLocation = undefined;

setInterval(function () {
    if (location.href != oldLocation) {
        oldLocation = location.href;
        chrome.runtime.sendMessage(oldLocation);
    }
}, 1000);
