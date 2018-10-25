Weibo = {};

Weibo.StoragePrefix = "wbfly_";

Weibo.auth = function(){
	var appKey = '38950085';
    var callback = 'http://wbonfly.applinzi.com/chrome.html';
    var authURL = 'https://api.weibo.com/oauth2/authorize?client_id=' + appKey + '&scope=all&redirect_uri=' + encodeURIComponent(callback);
    chrome.windows.create({
        url: authURL,
        width: 600,
        height: 450,
        left: (screen.width - 600) / 2,
        top: (screen.height - 450) / 2,
        focused: true,
        type: "popup"
    },function (window) {
		localStorage.setItem("authWindowId",window.id);
    });
};

Weibo.processAccessToken = function (data){
    var wid = localStorage.getItem("authWindowId");
    if(wid){
    	chrome.windows.remove(parseInt(wid));
	}

	var time = new Date().getTime();
	var t = Math.floor(time/1000);
	localStorage.setItem(Weibo.StoragePrefix+"auth_in",t);
	for (var p in data){
		localStorage.setItem(Weibo.StoragePrefix+p,data[p]);
	}
};

Weibo.unAuth = function(){
	localStorage.removeItem(Weibo.StoragePrefix+"access_token");
	localStorage.removeItem(Weibo.StoragePrefix+"auth_in");
	localStorage.removeItem(Weibo.StoragePrefix+"expires_in");
	localStorage.removeItem(Weibo.StoragePrefix+"remind_in");
	localStorage.removeItem(Weibo.StoragePrefix+"uid");
};

Weibo.isAuthed = function(){
	if(localStorage.getItem(Weibo.StoragePrefix+"access_token")){
		var auth_in = localStorage.getItem(Weibo.StoragePrefix+"auth_in");
		var expires_in  = localStorage.getItem(Weibo.StoragePrefix+"expires_in");
		var time = new Date().getTime()/1000;
		if((parseInt(auth_in)+parseInt(expires_in)) > time){
			return true;
		}
	}
	
	return false;
};


Weibo.upload = function (status,pic,pageurl){
	if(!Weibo.isAuthed()){
        Weibo.share(pageurl,status,pic);
		return false;
	}
	
	$.ajax({
		  type: 'POST',
		  url: 'https://api.weibo.com/2/statuses/upload_url_text.json',
		  data: {
			     'access_token':localStorage.getItem(Weibo.StoragePrefix+"access_token"),
			     'status': status,
			     'url':pic
			 },
		  success: function(data,statusText,xhr){
		  },
		  dataType: 'json',
		  error:function(xhr,statusText,e){
			  Weibo.share(pageurl,status,pic);
		  }
		});
	
};


Weibo.getUserInfo = function (callback){
	if(!Weibo.isAuthed()){
		callback(false);
		return false;
	}
	
	 $.getJSON('https://api.weibo.com/2/users/show.json', {
	     'access_token': localStorage.getItem(Weibo.StoragePrefix+"access_token"),
	     'uid': localStorage.getItem(Weibo.StoragePrefix+"uid")
	 }, function(info) {
	     callback(info);
	 });
};

Weibo.checkStatus = function(callback){
	if(!Weibo.isAuthed()){
		callback(false);
		return false;
	}
	
	$.getJSON('https://rm.api.weibo.com/2/remind/unread_count.json', {
	     'access_token': localStorage.getItem(Weibo.StoragePrefix+"access_token"),
	     'uid': localStorage.getItem(Weibo.StoragePrefix+"uid")
	 }, function(info) {
	     callback(info);
	 });
};

Weibo.share = function(pageUrl,title,srcUrl){
	var url = "http://service.weibo.com/share/share.php?url=" + encodeURIComponent(pageUrl)
		+"&title="+encodeURIComponent(title)
		+"&appkey=38950085";
		
		if(srcUrl && srcUrl.indexOf("http") == 0){
			url+= "&pic="+ encodeURIComponent(srcUrl);
		}
	chrome.windows.create({
        url: url,
        width: 600,
        height: 450,
        left: (screen.width - 600) / 2,
        top: (screen.height - 450) / 2,
        focused: true,
        type: "popup"
    });
};

