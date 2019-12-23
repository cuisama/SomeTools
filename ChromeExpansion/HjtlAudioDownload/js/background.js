var url;
var filename = "未识别";
var success = false;

//content_scripts向popup主动发消息的前提是popup必须打开！否则需要利用background作中转
chrome.runtime.onMessage.addListener(function (request, sender, sendResponse) {
	dealInfo(request);
});

var dealInfo = function(request){
	if(!request) return;
	url = request.url;
	filename = request.filename;
	success = request.success;
}