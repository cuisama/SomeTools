var Pop = {};

Pop.render = function (info){
	$("#avatar img").attr('src',info.profile_image_url);
	
	$("#userName").html(info.screen_name);
	$("#userName").attr('href',"http://www.weibo.com/"+info.domain);
	
	$("#location").html(info.location);
	$("#desc").html(info.description);
	
	$("#ifFollow").html(info.friends_count);
	$("#ifFans").html(info.followers_count);
	$("#ifStatus").html(info.statuses_count);
	$("#ifFav").html(info.favourites_count);
	
	var ct=Date.parse(info.created_at);
	var nt=Date.parse(new Date());
	var days = Math.ceil((nt-ct)/(1000*60*60*24));	
	$("#ifDay").html(days);
	
	
	$(".clickLink").click(function(){
		chrome.tabs.create({
			"url":$(this).attr('href')
		});
	});
	
	$("#recommendButton").click(function(){
		Weibo.share("https://chrome.google.com/extensions/detail/dlnibcgilcbfohdalmandfokomeljkfc","用Chrome玩微博，一定要试试一键微博。使用Chrome的右键菜单实现一键发送微博。");
	});
	
	$("#logout").click(function(){
		Weibo.unAuth();
		$("#userDiv").hide();
		$("#nonuserDiv").show();
	});
	
};

$(document).ready(function(){
	Weibo.getUserInfo(function(info){
		if(info){
			$("body").css('height','230px');
			$("body").css('width','190px');
			$("#nonuserDiv").hide();
			$("#userDiv").show();
			Pop.render(info);
		}else{
			$("body").css('height','32px');
			$("body").css('width','173px');
			$("#userDiv").hide();
			$("#nonuserDiv").show();
		}
	});
	
	$("#authButton").click(function(){
		Weibo.auth();
	});
});