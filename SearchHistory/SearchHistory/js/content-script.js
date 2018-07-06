
// document.getElementById("su").onclick = function(){
// 	var key = document.getElementById("kw").value;

// 	var time = new Date().toLocaleString();
// 	var current = {
// 		time:time,
// 		key:key
// 	};

// 	//chrome.runtime.sendMessage(current);
// };


var oldLocation = undefined;

setInterval(function() {
	if(location.href != oldLocation) {
		oldLocation = location.href;
		chrome.runtime.sendMessage(oldLocation);
	}
}, 1000);
