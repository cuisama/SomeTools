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
    var searchHistory = JSON.parse("{\"2018/07/06\":{\"SearchHistory\":\"10:59:00\",\"c# winform 画面修改后 resx文件被清空\":\"02:25:47\",\"c# winform 窗体修改后 resx文件被清空\":\"02:42:23\",\"c# 获得文件行数\":\"03:39:21\",\"c#+winform+窗体修改后+resx文件被清空\":\"02:42:34\",\"chrome开发者 删除上传的应用\":\"04:51:32\",\"chrome扩展 permissions\":\"01:01:27\",\"ry=世界杯1/4决赛\":\"17:15:54\",\"sqlserver 日期格式\":\"02:57:17\",\"为什么上传的chrome扩展在商店中搜索不到\":\"11:04:43\",\"原生js获取父节点\":\"21:24:25\",\"向开朗的技术大牛致敬\":\"18:03:22\",\"向致敬\":\"18:04:34\",\"字体\":\"18:07:52\",\"开源中国\":\"11:01:16\",\"敬礼\":\"18:04:49\"},\"2018/07/09\":{\"Scripting.FileSystemObject\":\"13:06:48\",\"WScript.Arguments.Named\":\"17:34:58\",\"WScript.Arguments.Unnamed.Count\":\"12:02:53\",\"debug vbs\":\"17:06:49\",\"js+对象按照key排序\":\"11:15:14\",\"p-code\":\"11:10:58\",\"vbs \":\"11:06:03\",\"vbs :ReturnValue\":\"15:44:09\",\"vbs CreateObject\":\"11:48:31\",\"vbs On Error Resume Next\":\"16:19:20\",\"vbs set\":\"13:08:41\",\"vbs sub function\":\"11:55:02\",\"vbs 结尾的下划线\":\"15:38:48\",\"vbs 语法\":\"11:26:30\",\"vbs 赋值 冒号\":\"15:48:06\",\"vbs+:ReturnValue\":\"15:47:13\",\"vb和vba\":\"11:06:20\"},\"2018/07/10\":{\"eclipse svn 文件时间\":\"16:18:34\",\"eclipse svn 文件时间变成本地时间\":\"16:16:31\",\"eclipse svn 显示秒\":\"16:15:27\",\"eclipse svn 获取文件的时间\":\"16:16:09\",\"eclipse 版本不显示时分秒\":\"16:05:07\",\"eclipse+svn+文件修改‘时间\":\"16:19:11\",\"eclipse+svn+文件修改时间\":\"16:19:15\",\"eclipse+svn+文件时间\":\"16:18:43\",\"js 对象逆序遍历\":\"11:15:26\",\"vbs 删除文件夹\":\"15:18:04\",\"vbs 参数省略\":\"13:53:57\"},\"2018/07/11\":{\"c# 判断文件夹下是否包含某文件\":\"14:34:51\",\"chrome.contextMenus\":\"18:43:49\",\"github\":\"18:17:14\",\"select的结果作积\":\"11:44:08\",\"sqlserver 查询主键条件顺序 性能\":\"17:35:33\",\"sqlserver 补成多少位\":\"11:46:57\",\"vbs InStr\":\"20:04:28\",\"执行计划跟什么有关\":\"17:46:06\",\"警告：如果使用带有格式文件的BCP导入，则分隔符列中的空字符串将转换为NULL\":\"20:07:02\"},\"2018/07/12\":{\"C# winform panel 滚动条到指定位置\":\"17:47:02\",\"C#+winform+panel+滚动条到指定位置+百度一下\":\"17:56:30\",\"c# datagridview 单元格变色\":\"19:27:56\",\"c# winform progressBar\":\"18:09:50\",\"c# winform 下拉框添加值\":\"18:51:38\",\"chrome.contextMenus\":\"10:46:02\",\"debug vbs\":\"10:47:02\",\"github\":\"10:46:19\",\"gmail\":\"20:21:11\",\"ipsaa\":\"10:51:15\",\"sqlserver 查询主键条件顺序 性能\":\"10:46:12\",\"vbs InStr\":\"10:45:53\",\"vbs 参数省略\":\"10:46:29\",\"世界杯\":\"20:03:10\",\"叉号怎么打\":\"18:45:00\",\"向右的箭头\":\"18:40:30\",\"无效的线程到线程操作：控件'PBarLoad'是从除创建控件的线程以外的线程访问的 提出修改建议\":\"18:22:12\",\"警告：如果使用带有格式文件的BCP导入，则分隔符列中的空字符串将转换为NULL\":\"10:46:07\"},\"2018/07/13\":{\"c# winform 鼠标在控件下边\":\"21:23:14\",\"sqlserver 插入多条语句\":\"21:05:52\"},\"2018/07/17\":{\"C# winform panel 滚动条到指定位置\":\"10:48:44\",\"c# winform 鼠标在控件下边\":\"10:48:35\",\"c# winform 鼠标被下拉框覆盖\":\"10:58:46\",\"chrome 设置启动时为英文\":\"17:25:48\",\"html table 内间距\":\"11:50:45\",\"html 扁平化 下拉框 样式\":\"14:07:46\",\"html 扁平化按钮 样式\":\"13:55:51\",\"html 按钮 样式\":\"13:34:39\",\"js 从右侧截取字符串\":\"15:32:34\",\"js 创建全是0的字符串\":\"15:45:07\",\"js 对象属性排序\":\"15:16:01\",\"table 样式\":\"13:24:06\",\"win字体\":\"17:25:45\",\"中文简体翻译为繁体\":\"17:36:43\",\"引入css\":\"13:39:07\",\"html 删除一行后 滚动条滚动到最上侧\":\"17:58:58\",\"字体\":\"18:36:54\",\"简繁转换\":\"19:06:10\",\"js 生成txt到本地\":\"19:12:49\",\"js chrome 生成txt到本地\":\"19:18:44\"}}");
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
