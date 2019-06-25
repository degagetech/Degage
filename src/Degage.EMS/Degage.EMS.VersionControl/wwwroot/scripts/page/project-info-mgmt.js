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


        //加载项目版本信息
    },
    data:
    {
        projectInfo: new ProjectInfo(),
        iconUrl: null,
        isEditMode: false,
        versionInfos: [{
            Major: 1,
            Minor: 0,
            Revised: 10,
            Type: "BETA",
            LastAccessTime: "2019-06-11 11:09",
            Description: "测试版本",
            IsEnabled: false
        },
        {
            Major: 1,
            Minor: 1,
            Revised: 11,
            Type: "BETA",
            LastAccessTime: "2019-06-12 11:09",
            Description: "测试版本",
            IsEnabled: true
        }]
    },
    methods:
    {
        getVersionTableRowClassName({ row, rowIndex }) {
            if (row.IsEnabled) {
                return 'enabled-row';
            }
            return '';
        },
        handleCurrentChange: function (row) {

        },
        dialogCancelHandle: function () {
            window.top.closeIndexDialog();
        },
        cancelAlter: function () {
            this.isEditMode = false;
        },
        saveAlter: function () {
            this.isEditMode = false;
        },
        projectAlter: async function () {
            this.isEditMode = true;
            //var resp = await $proxy.updateProjectInfo(this.projectInfo);
            //var pack = new ResponsePacket(resp.data);
            //if (pack.Success) {
            //    var projectInfo = new ProjectInfo(pack.Data);
            //    window.top.addProjectInfo(projectInfo);
            //    $msgbox.defaultShowSuccess("已更新！");
            //}
            //else {
            //    $msgbox.defaultShowFailed("更新失败！" + pack.Message);
            //}
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