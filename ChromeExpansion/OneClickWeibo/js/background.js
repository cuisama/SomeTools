var WbFly = {};

WbFly.share = function (data,tab){
	var mediaType=data.mediaType;
	var pageUrl=data.pageUrl;
	var srcUrl=data.srcUrl;
	var selectionText=data.selectionText;
	var title=tab.title||"";

	if(mediaType && mediaType=="image"){
        if(!selectionText){
            selectionText = "我正在浏览："+title+" "+pageUrl;
        }
		Weibo.upload(selectionText,srcUrl,pageUrl);
	}else{
        if(!selectionText){
            selectionText = "我正在浏览："+title;
        }
        Weibo.share(pageUrl,selectionText,srcUrl);
	}

};

WbFly.updateNew = function(){
	Weibo.checkStatus(function(info){
		if(info.follower>0 ||info.cmt>0 ||info.dm>0 ||info.mention_status>0 ||info.mention_cmt>0||info.notice>0 ){
			chrome.browserAction.setBadgeText({
				  "text":"NEW"
			  });
		}else{
			chrome.browserAction.setBadgeText({
				  "text":""
			  });
		}
	});
};

WbFly.detectUrl = function(url){
	if(url.indexOf('weibo.com')!==-1){
		setTimeout(WbFly.updateNew,1000*10);
	}
};


chrome.extension.onRequest.addListener(function(request) {
    switch (request.action) {
    case "wb_callback":
    	Weibo.processAccessToken(request.data);
        break;
    }
});

chrome.contextMenus.create({
	'type':'normal',
	'title':'发送到新浪微博',
	'onclick':WbFly.share,
	'contexts':['all']
},null);

function ontime(){
	WbFly.updateNew();
	
	setTimeout(ontime,1000*60*30);
}

chrome.tabs.onCreated.addListener(function(tab) {
	if(tab.url){
		WbFly.detectUrl(tab.url);
	}
});



chrome.tabs.onUpdated.addListener(function(tabId, changeInfo, tab) {
	if(changeInfo.url){
		WbFly.detectUrl(changeInfo.url);
	}
});


ontime();

