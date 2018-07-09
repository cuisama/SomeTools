var searchHistory = undefined;
chrome.storage.local.get({"searchHistory":{}}, function(item){
	searchHistory = item.searchHistory;
});
chrome.runtime.onMessage.addListener(function(request, sender, sendResponse){
	if(typeof(request)=="string"){
		request = exec(request);
	}
	if(request){
		var today = request.time.match(/\d{4}\/\d{1,2}\/\d{1,2}/)[0];
		request.time = request.time.match(/\d{1,2}:\d{1,2}:\d{1,2}/)[0];
		var current = request;
		searchHistory[today]=searchHistory[today]||{};
		searchHistory[today][current.key] = current.time;

		chrome.storage.local.set({"searchHistory":searchHistory});
	}
});


function exec(url){
	var key = url;
	if(url.match(/(www.google.)/)){
		key = url.match(/(\?|&)q=.*?&/); 
		key = key[0].substring(3).replace("&","");
	}else if(url.match(/(www.baidu.com)/)){
		key = url.match(/(\?|&)wd=.*?(&|$)/); 
		key = key[0].substring(4).replace("&","");
	}else if(url.match(/(www.bing.com)/)){
		key = url.match(/(\?|&)q=.*?(&|$)/); 
		key = key[0].substring(4).replace("&","");
	}else if(url.match(/(www.so.com)/)){
		key = url.match(/(\?|&)q=.*?(&|$)/); 
		key = key[0].substring(4).replace("&","");
	}else if(url.match(/(www.sogou.com)/)){
		key = url.match(/(\?|&)query=.*?(&|$)/); 
		key = key[0].substring(4).replace("&","");
	}else if(url.match(/(search.yahoo.)/)){
		key = url.match(/(\?|&)p=.*?(&|$)/); 
		key = key[0].substring(4).replace("&","");
	}
	else{
		return;
	}

	key = decodeURIComponent(key);
	if (!key) return;
	var date = new Date();
	//var time = .toLocaleString();
	var time = 1900 + date.getYear() + "/" + (date.getMonth() + 1) + "/" + (date.getDate()) + " " + (date.getHours()) + ":" + date.getMinutes() + ":" + date.getSeconds();
	var current = {
		time:time,
		key:key
	};
	return current;
}