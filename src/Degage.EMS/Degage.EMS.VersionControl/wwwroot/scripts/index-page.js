

var windowsHeight = document.documentElement.clientHeight;
var windowsWidth = document.documentElement.clientWidth;

//绑定中部渲染对象
var projectContentVue = new Vue(
    {
        el: "#project-content",
        mounted: async function () {
            //加载所有项目信息
            await this.loadProjectInfos();
        },
        data:
        {
            projectInfos: [],
            projectQueryCondition: new ProjectInfoCondition()
        },
        methods:
        {
            removeProject: function (id) {
                $msgbox.showConfirm("确定删除此项目及其所有附加信息吗？", "提示", {
                    confirmButtonText: '确定',
                    cancelButtonText: '取消',
                    type: 'warning'
                }).then(async () => {
                    var result = await $proxy.deleteProjectInfo(id);
                    var pack = new ResponsePacket(result.data);
                    if (pack.Success) {
                        $msgbox.defaultShowSuccess("已删除！");
                        var filtedInfos = this.projectInfos.filter(p => p.Id !== id);
                        this.projectInfos = filtedInfos;
                    }
                    else {
                        $msgbox.defaultShowFailed("删除失败！" + pack.Message);
                    }
                });
            },
            updateProjectInfo: function (newProjectInfo) {
                if (!newProjectInfo.Id) {
                    return;
                }
                //使用外部传进来的新的对象信息刷新旧对象的值
                var selectedInfos = this.projectInfos.filter(p => p.Id === newProjectInfo.Id);
                var oldInfo = null;
                if (selectedInfos.length > 0) {
                    oldInfo = selectedInfos[0];
                }
                Object.assign(oldInfo, newProjectInfo);
            },
            editProject: async function (id) {

            },
            loadProjectInfos: async function () {
                var resp = await $proxy.queryProjectInfos(this.projectQueryCondition);
                var pack = new ResponsePacket(resp.data);
                if (pack.Success) {
                    let infos = [];
                    for (var item of pack.Data) {
                        var info = new ProjectInfo(item);
                        infos.push(info);
                    }
                    this.projectInfos = infos;
                }
            }
        }
    });
function updateProjectInfo(projectInfo) {
    projectContentVue.updateProjectInfo(projectInfo);
}
function removeProject(id) {
    var a = 1;
}
function addProjectInfo(info) {
    projectContentVue.projectInfos.push(info);
    showInfoText("已添加项目：" + info.Title);
}

var indexFrameDialogObj = new Vue(
    {
        el: "#indexFrameDialog",
        data:
        {
            dialogTitle: '',
            dialogFormVisible: false,
            address: '',
            isFullScreen: true,
            isAdjustedDialogSize: false
        },
        created: function () {

        },
        methods:
        {
            dialogFormClosedHandle: function () {
                //退出全屏
                //exitFullscreen();
            },
            dialogFormOpenedHandle: function () {
                $('#indexDialogFrame').attr("src", this.address);
                if (!this.isAdjustedDialogSize) {
                    var dialogBody = $(".el-dialog__body");
                    if (dialogBody !== null) {
                        dialogBody.css("flex", "1");
                        dialogBody.css("display", "flex");
                        dialogBody.css("flex-direction", "column");
                        dialogBody.css("padding", "5");
                        this.isAdjustedDialogSize = true;
                    }
                }

            }
        }
    }
);


function hasIndexDialog() {
    return indexFrameDialogObj.dialogFormVisible;
}
/**
 * 打开全屏模式的对话框，并导向到指定地址
 * @param {string} address 导向的地址
 * @param {boolean} request 是否请求让浏览器也进入全屏，默认请求
 * @param {string} title 对话框的标题
 */
function closeIndexDialog() {
    indexFrameDialogObj.dialogFormVisible = false;
}
function openIndexDialog(address, title, isfull) {
    address = address || null;
    title = title || '';
    isfull = isfull || true;
    //如果已经在全屏模式下
    if (indexFrameDialogObj.dialogFormVisible) {
        return;
    }
    if (address !== null) {
        indexFrameDialogObj.address = address;
        indexFrameDialogObj.dialogFormVisible = true;
        indexFrameDialogObj.dialogTitle = title;
        indexFrameDialogObj.isFullScreen = isfull;
        return;
    }
}

/***************************************底部设置*******************************************/
//绑定底部状态栏
var bottomrowVue = new Vue(
    {
        el: "#status-bar",
        data:
        {
            infoType: "info",
            infoText: "...",
            senconds: "",
            minutes: "",
            hours: "",
            noon: ""
        },
        methods:
        {

        }
    });

function showInfoText(info) {
    bottomrowVue.infoText = info;
}


//更新窗体底部显示的时间
function updateTime() {
    let time = new Date();
    var obj = bottomrowVue;
    obj.hours = formatNumber(time.getHours(), 2);
    obj.minutes = formatNumber(time.getMinutes(), 2);
    obj.senconds = formatNumber(time.getSeconds(), 2);
    obj.noon = "AM";
    if (obj.hours > 12) {
        obj.noon = "PM";
    }
}
//设置时间更新得定时器
setInterval(function () { updateTime(); }, 1000);

//文档加载完毕后，立即更新时间显示
window.addEventListener("load", updateTime);


//监听窗体大小变化
function resizeHandler() {
    windowsHeight = document.documentElement.clientHeight;
    windowsWidth = document.documentElement.clientWidth;

    //设置 contentTabs 元素的高度
}
window.addEventListener("resize", resizeHandler);





/**
 * 请求进入全屏
 * */
let g_isFulling = false;
function requestFullScreen() {
    var de = document.documentElement;
    if (de.requestFullscreen) {
        g_isFulling = true;
        de.requestFullscreen();
    } else if (de.mozRequestFullScreen) {
        g_isFulling = true;
        de.mozRequestFullScreen();
    } else if (de.webkitRequestFullScreen) {
        g_isFulling = true;
        de.webkitRequestFullScreen();
    }
}
/**
 * 退出全屏
 * */
function exitFullscreen() {
    if (!g_isFulling) return;
    var de = document;
    if (de.exitFullscreen) {
        g_isFulling = false;
        de.exitFullscreen();
    } else if (de.mozCancelFullScreen) {
        g_isFulling = false;
        de.mozCancelFullScreen();
    } else if (de.webkitCancelFullScreen) {
        g_isFulling = false;
        de.webkitCancelFullScreen();
    }
}

//SignalR设置
//var connection = new signalR.HubConnectionBuilder().withUrl("/notificationHubs").build();
//console.log(connection);

//connection.on("receiveMessageCourier", function (message) {
//    //处理信息
//});

//connection.start()
//    .catch(err => console.error(err.toString()));



