
var statusBarVue = new Vue(
    {
        el: "#status-bar",
        data:
        {
            infoType: "info",
            infoText: ".",
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
    statusBarVue.infoText = info;
}


//更新窗体底部显示的时间
function updateTime() {
    let time = new Date();
    var obj = statusBarVue;
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