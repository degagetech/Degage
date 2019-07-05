var windowsHeight = document.documentElement.clientHeight;
var windowsWidth = document.documentElement.clientWidth;

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
            addProject: function () {
                window.location = $proxy.getAddProjectUrl("/");  
            },
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
            editProject: function (id) {
                window.location = $proxy.getProjectMgmtUrl(id);   
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

//监听窗体大小变化
function resizeHandler() {
    windowsHeight = document.documentElement.clientHeight;
    windowsWidth = document.documentElement.clientWidth;
}
window.addEventListener("resize", resizeHandler);




