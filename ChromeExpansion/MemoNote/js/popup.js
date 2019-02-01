
if (navigator.userAgent.indexOf("SE 2.X MetaSr 1.0") > -1) {
    document.body.style.height = "400px";
}

//var tasks = bg.tasks || { "list": {}, "over": {} };

$taskList = document.getElementById("task-list");
$taskOver = document.getElementById("task-over");

var $add = document.getElementById("task-add").getElementsByTagName("a")[0];
var $pending = document.getElementById("pending").getElementsByTagName("span")[0];
var $completed = document.getElementById("completed").getElementsByTagName("span")[0];

var bg = chrome.extension.getBackgroundPage();
$add.innerHTML = bg.RM("add");
$pending.innerHTML = bg.RM("pending");
$completed.innerHTML = bg.RM("completed");

document.getElementById("task-add").onclick = function () {
    addTaskItem();
}

document.getElementById("input-task").addEventListener("keydown", function () {
    var evt = window.event || e;
    if (evt.keyCode == 13) {
        addTaskItem();
    }
}, false);


var tasks = undefined;
chrome.storage.sync.get({ "tasks": { "list": {}, "over": {} } }, function (item) {
    tasks = item.tasks;

    init();

});



//初始化
function init() {
    //var today = bg.getTime().substring(0, 10);

    //构建【待处理】列表    
    var html = "";
    for (var task in tasks.list) {
        html += taskItemModel(task, 0)
    }
    $taskList.innerHTML = html;

    //绑定checkbox事件
    var task = $taskList.getElementsByClassName("checkbox");
    for (var i = task.length - 1; i >= 0; i--) {
        task[i].onclick = (function (trNode) {
            return function () {
                var taskValue = trNode.id;
                $taskList.removeChild(trNode);
                subTaskItem(taskValue)
            }
        })(task[i].parentNode);
    }

    //构建【已完成】列表
    var html = "";
    for (var task in tasks.over) {
        html += taskItemModel(task, 1);
    }
    $taskOver.innerHTML = html;

    //为删除按钮绑定事件
    var taskdDel = document.getElementById("content").getElementsByClassName("del");
    for (var i = taskdDel.length - 1; i >= 0; i--) {
        taskdDel[i].onclick = (function (trNode) {
            return function () {
                var taskValue = trNode.id;
                try{
                    $taskList.removeChild(trNode);
                    delete tasks.list[taskValue];
                }catch(ex){

                }
                try {
                    $taskOver.removeChild(trNode);
                    delete tasks.over[taskValue];
                } catch (ex) {

                }
                chrome.storage.sync.set({ "tasks": tasks });
            }
        })(taskdDel[i].parentNode);
    }
}


//添加一个【待处理】
function addTaskItem() {

    var task = document.getElementById("input-task");
    var taskValue = task.value;

    $taskList.innerHTML += taskItemModel(taskValue, 0);
    task.value = "";

    tasks.list[taskValue] = "";

    chrome.storage.sync.set({ "tasks": tasks });

    //checkbox事件
    var task = $taskList.getElementsByClassName("checkbox");
    //添加一个item，要为所有的item都重新注册一遍事件
    for (var i = task.length - 1; i >= 0; i--) {
        task[i].onclick = (function (trNode) {
            return function () {
                var taskValue = trNode.id;
                $taskList.removeChild(trNode);
                subTaskItem(taskValue)
            }
        })(task[i].parentNode);
    }
    //del事件
    var task = $taskList.getElementsByClassName("del");
    for (var i = task.length - 1; i >= 0; i--) {
        task[i].onclick = (function (trNode) {
            return function () {
                var taskValue = trNode.id;
                $taskList.removeChild(trNode);
                delete tasks.list[taskValue];
                chrome.storage.sync.set({ "tasks": tasks });
            }
        })(task[i].parentNode);
    }
}

//添加一个【已完成】
function subTaskItem(taskValue) {

    $taskOver.innerHTML += taskItemModel(taskValue, 1);

    delete tasks.list[taskValue];
    tasks.over[taskValue] = "";
    chrome.storage.sync.set({ "tasks": tasks });

    //del事件
    var task = $taskOver.getElementsByClassName("del");
    for (var i = task.length - 1; i >= 0; i--) {
        task[i].onclick = (function (trNode) {
            return function () {
                var taskValue = trNode.id;
                $taskOver.removeChild(trNode);
                delete tasks.over[taskValue];
                chrome.storage.sync.set({ "tasks": tasks });
            }
        })(task[i].parentNode);
    }
}

//list模块删除 函数绑定
function bindDel($taskModel,dom) {

}

//任务item模型
function taskItemModel(taskValue, status) {
    return "<div class='task-item' id='" + taskValue + "'>"
                 + "<div class='checkbox checkbox-" + status + "'></div>"
                 + "<div class='text'>" + taskValue + "</div>"
                 + "<a href='#' class='del'>" + bg.RM("del") + "</a>"
                 + "</div>";
}