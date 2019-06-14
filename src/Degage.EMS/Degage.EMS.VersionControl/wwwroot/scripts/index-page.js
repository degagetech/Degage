

var windowsHeight = document.documentElement.clientHeight;
var windowsWidth = document.documentElement.clientWidth;

//绑定中部渲染对象
var middlerowLeftVue = new Vue(
    {
        el: "#project-content",
        data:
        {

        },
        methods:
        {
        }
    });


var fullDialogVueObj = new Vue(
    {
        el: "#fullDialog",
        data:
        {
            dialogTitle: '',
            dialogFormVisible: false,
            fullPageAddress: '',
            isAdjustedDialogSize: false
        },
        created: function () {

        },
        methods:
        {
            dialogFormClosedHandle: function () {
                //退出全屏
                exitFullscreen();
                //刷新当前 tab 页面
                if (middlerowRightVue.selectTabId !== null) {
                    var iframe = $('#iframe-' + middlerowRightVue.selectTabId);
                    var url = iframe.attr("src");
                    if (url === this.fullPageAddress) {
                        iframe.attr("src", url);
                        middlerowRightVue.$message({ message: "正在刷新...", type: "info", duration: 500 });
                    }
                }
            },
            dialogFormOpenedHandle: function () {
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
                $('#fullPageIframe').attr("src", this.fullPageAddress);
            }
        }
    }
);


function hasFullDialog() {
    return fullDialogVueObj.dialogFormVisible;
}
/**
 * 打开全屏模式的对话框，并导向到指定地址
 * @param {string} address 导向的地址
 * @param {boolean} request 是否请求让浏览器也进入全屏，默认请求
 * @param {string} title 对话框的标题
 */

function openFullDialog(address, request, title) {
    address = address || null;
    title = title || '';
    //如果已经在全屏模式下
    if (fullDialogVueObj.dialogFormVisible) {
        return;
    }
    if (address !== null) {

        //不需要浏览器也进入全屏
        if (request !== undefined && !request) {
            fullDialogVueObj.fullPageAddress = address;
            fullDialogVueObj.dialogFormVisible = true;
            fullDialogVueObj.dialogTitle = title;
            return;
        }
        $msgbox.showConfirm('系统请求进入全屏模式，是否继续？', '提示', {
            confirmButtonText: '继续',
            cancelButtonText: '取消',
            distinguishCancelAndClose: true,
            type: 'warning'
        }).then(() => {
            requestFullScreen();
            fullDialogVueObj.fullPageAddress = address;
            fullDialogVueObj.dialogFormVisible = true;
            fullDialogVueObj.dialogTitle = title;
        }).catch((action) => {
            if (action === "cancel") {
                fullDialogVueObj.fullPageAddress = address;
                fullDialogVueObj.dialogFormVisible = true;
                fullDialogVueObj.dialogTitle = title;
            }
        });
        return;
    }

}
//用于控制导航栏的展开与收缩
function collapseNav() {
    middlerowLeftVue.isCollapseNav = !middlerowLeftVue.isCollapseNav;
}

//此处代码用于使 iframe 框架高度充满容器剩余高度，应该置于 middlerow 容器渲染后
function adjustePageIframeDialogBody() {
    var bodys = $(".el-tabs__content");
    if (bodys !== null) {
        bodys.css('flex', '1');
        bodys.css('margin-bottom', '10px');
    }
}
adjustePageIframeDialogBody();


/***************************************底部设置*******************************************/
//绑定底部状态栏
var bottomrowVue = new Vue(
    {
        el: "#status-bar",
        data:
        {
            senconds: "",
            minutes: "",
            hours: "",
            noon: ""
        },
        methods:
        {

        }
    });




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



