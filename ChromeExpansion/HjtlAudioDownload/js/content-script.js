var audioSrc;
var filename;
var success = false;

function getInfo(noRefresh){
	audioSrc = document.getElementById("newhjvoaplayer").src;
	var oriText;
	var tranText;
	if(noRefresh){
		oriText = document.getElementById("tabOriArticle").innerHTML;
		tranText = document.getElementById("tabTranArticle").innerHTML;
	}else{
		oriText = document.getElementById("tabOriArticle").getElementsByTagName("p")[0].innerHTML;
		tranText = document.getElementById("tabTranArticle").getElementsByTagName("p")[0].innerHTML;
	}

	filename = tranText+"-"+oriText;
	if(filename.indexOf("span_paystate") < 0){
		success = true;
	}else{
		success = false;
		filename = tranText;
	}
}

getInfo();

chrome.runtime.sendMessage({
	url:audioSrc,
	filename:filename,
	success:success
});

chrome.runtime.onMessage.addListener(function(request, sender, sendResponse)
{
	if(request.cmd == 'getInfo'){
		getInfo(true);
		var param = {
			url:audioSrc,
			filename:filename,
			success:success
		};
		console.log(param)
		sendResponse(param);
	}
	
});
