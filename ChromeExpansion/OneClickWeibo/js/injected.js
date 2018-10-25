
function getAuthCode() {
    var hash = document.location.search;
    var query = hash.substr(1);
    if(query.indexOf('code')<0 ){
        return false;
    }
    var params = query.split("&");
    var info = {};
    var l = params.length;
    for(var i=0;i<l;i++){
        var pairs = params[i].split("=");
        if(pairs[0] == 'code'){
        	return pairs[1];
		}
    }
    return false;
}

var authCode = getAuthCode();

var contentDiv = document.getElementById('content');

if(authCode){
    $.post('https://api.weibo.com/oauth2/access_token', {
        'client_id':'38950085',
        'client_secret':"4c6e31814287063de180f0fb5ca139b6",
        'grant_type': 'authorization_code',
        'code':authCode,
        'redirect_uri':"http://wbonfly.applinzi.com/chrome.html"
    }, function(data) {
        var request = {
            "action":"wb_callback",
            "data":data
        };
        chrome.extension.sendRequest(request);
        chrome.windows.getCurrent({},function (window) {
            chrome.windows.remove(window.id);
        });
    }, 'json').error(function () {
        contentDiv.innerText = "授权失败，请重试！";
    });

}else{
	contentDiv.innerText = "授权失败，请重试！";
}


