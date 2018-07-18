var bg = chrome.extension.getBackgroundPage();
var $tbody = document.getElementById("searchHistory_tbody");
var $thead = document.getElementById("searchHistory_thead");
var $refresh = document.getElementById("refresh").getElementsByTagName("a")[0];
var $backup = document.getElementById("backup").getElementsByTagName("a")[0];
$thead.innerHTML = "<tr><th>" + bg.RM("time") + "</th><th>" + bg.RM("key") + "</th><th>" + bg.RM("option") + "</th></tr>";
$refresh.innerHTML = bg.RM("refresh");
$backup.innerHTML = bg.RM("backup");

$refresh.onclick = function () {
    createTable();
}
$backup.onclick = function () {
    var html = "";
    var searchHistory = bg.searchHistory;
    for (var date in searchHistory) {
        var dayHtml = "";
        for (var key in searchHistory[date]) {
            dayHtml += date + " " + searchHistory[date][key] + "\t" + key + "\r\n";
        }
        html = dayHtml + "\r\n" + html;
    }
    downloadTextFile(html);
    setTimeout(function () {
        bg.show(bg.RM("bakSucc"))
    }, 100);
}

function downloadTextFile(text) {
    var file = new File([text], "SearchHistoryBak.txt", { type: "text/plain;charset=utf-8" });
    saveAs(file);
}

setSelect();
createTable();


function setSelect() {
    var html = "";
    var today = bg.getTime().substring(0, 10);
    var searchHistory = bg.searchHistory;
    searchHistory[today] = searchHistory[today] || {};

    for (var key in searchHistory) {
        html = "<option value ='" + key + "'>" + key + "</option>" + html;
    }
    html = "<option value ='All'>" + bg.RM("all") + "</option>" + html;
    var mySelect = document.getElementById("selector");
    mySelect.innerHTML = html;
    mySelect.onchange = function () {
        createTable();
    }
}



function createTable() {
    var html = "";

    var myselect = document.getElementById("selector");
    var index = myselect.selectedIndex;
    var today = myselect.options[index].value;

    var searchHistory = bg.searchHistory;
    
    if (today == "All") {
        for (var date in searchHistory) {
            var dayHtml = "";
            for (var key in searchHistory[date]) {
                dayHtml += "<tr id='" + key + "'><td>" + date + " " + searchHistory[date][key] + "</td><td>" + key + "</td><td><a href='#'>" + bg.RM("delete") + "</a></td></tr>";
            }
            html = dayHtml + html;
        }
    } else {
        for (var key in searchHistory[today]) {
            html += "<tr id='" + key + "'><td>" + today + " " + searchHistory[today][key] + "</td><td>" + key + "</td><td><a href='#'>" + bg.RM("delete") + "</a></td></tr>";
        }
    }

    

    $tbody.innerHTML = html;

    var tras = $tbody.getElementsByTagName("a");
    for (var i = tras.length - 1; i >= 0; i--) {
        tras[i].onclick = (function (trNode) {
            return function () {
                var key = trNode.id;
                $tbody.removeChild(trNode);
                delete searchHistory[today][key];
            }
        })(tras[i].parentNode.parentNode);
    }
}
