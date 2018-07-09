
var bg = chrome.extension.getBackgroundPage();
var tbody =document.getElementById("searchHistory_tbody");
document.getElementById("refresh").onclick = function () {
	createTable();
}

setSelect();
createTable();


function setSelect(){
    var html = "";
    var date = new Date();
    var today = 1900 + date.getYear() + "/" + (date.getMonth() + 1) + "/" + (date.getDate());
	//var today = today || new Date().toLocaleString().match(/\d{4}\/\d{1,2}\/\d{1,2}/)[0];
	var searchHistory = bg.searchHistory;
	searchHistory[today] = searchHistory[today]||{};
	
	for(var key in searchHistory){
		html+="<option value ='"+key+"'>"+key+"</option>";
	}
	var mySelect=document.getElementById("selector");
	mySelect.innerHTML = html;
	mySelect.onchange = function(){
		createTable();
	}
}



function createTable(){
	var html = "";
	
	var  myselect=document.getElementById("selector");
	var index=myselect.selectedIndex ;
	var today = myselect.options[index].value;

	var searchHistory = bg.searchHistory;
	for(var key in searchHistory[today]){
		html+="<tr id='"+key+"'><td>"+searchHistory[today][key]+"</td><td>"+key+"</td><td><a href='#'>Delete</a></td></tr>";
	}

	tbody.innerHTML = html;

	var tras = tbody.getElementsByTagName("a");
	for (var i = tras.length - 1; i >= 0; i--) {
	    tras[i].onclick = (function(trNode){
			return function(){
			    var key = trNode.id;
			    tbody.removeChild(trNode);
				delete searchHistory[today][key];
			}
	    })(tras[i].parentNode.parentNode);
	}
}
