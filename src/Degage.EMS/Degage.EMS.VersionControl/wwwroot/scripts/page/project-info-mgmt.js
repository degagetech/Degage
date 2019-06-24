var app = new Vue({
    el: "#app",
    mounted: async function () {
        var result = await $proxy.getProjectInfo(p_projectId);
        var pack = new ResponsePacket(result.data);
        if (!pack.Success) {
            $proxy.gotoErrorPage("未能找到项目信息");
            return;
        }
        var info = new ProjectInfo(pack.Data);
        this.projectInfo = info;
        if (info.IconFileId) {
            this.iconUrl = $proxy.getFileDownUrl(info.IconFileId);
        }
      
    },
    data:
    {
        projectInfo: new ProjectInfo(),
        iconUrl: null,
        tableData: [{
            date: '2016-05-02',
            name: '王小虎',
            address: '上海市普陀区金沙江路 1518 弄'
        }, {
            date: '2016-05-04',
            name: '王小虎',
            address: '上海市普陀区金沙江路 1517 弄'
        }, {
            date: '2016-05-01',
            name: '王小虎',
            address: '上海市普陀区金沙江路 1519 弄'
        }, {
            date: '2016-05-03',
            name: '王小虎',
            address: '上海市普陀区金沙江路 1516 弄'
        }],
    },
    methods:
    {
        handleCurrentChange: function (row) {

        },
        dialogCancelHandle: function () {
            window.top.closeIndexDialog();
        },
        projectAlterHandle: async function () {
            var resp = await $proxy.updateProjectInfo(this.projectInfo);
            var pack = new ResponsePacket(resp.data);
            if (pack.Success) {
                var projectInfo = new ProjectInfo(pack.Data);
                window.top.addProjectInfo(projectInfo);
                $msgbox.defaultShowSuccess("已更新！");
            }
            else {
                $msgbox.defaultShowFailed("更新失败！" + pack.Message);
            }
        },
        handleIconSuccess: function (res, file) {
            var avatarId = res;
            this.projectInfo.IconFileId = avatarId;
            this.iconUrl = URL.createObjectURL(file.raw);
        },
        beforeIconUpload: function (file) {
            const isJPGOrPNG = file.type === 'image/jpeg' || file.type === 'image/png';
            const isLt2M = file.size / 1024 / 1024 < 2;

            if (!isJPGOrPNG) {
                this.$message.error('项目图标只能是 JPG 或 PNG 格式！');
            }
            if (!isLt2M) {
                this.$message.error('项目图标大小不能超过 2MB!');
            }
            return isJPGOrPNG && isLt2M;
        }
    }
});