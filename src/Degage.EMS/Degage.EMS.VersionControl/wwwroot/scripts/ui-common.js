/**
 * 用于调正 elment-ui 内部元素无法充满对话框的问题
 * @typedef {DialogBodyAdjuster} 用于调正 elment-ui 内部元素无法充满对话框的问题
 * */
function DialogBodyAdjuster() {
    /**
     * 表示是否已经调整过 Dialog
     * */
    this.isAdjustedDialogSize = false;
    /**
     * 调整 dialog body
     * @description 调整 dialog body
     * */
    this.adjusting = function () {
        if (!this.isAdjustedDialogSize) {
            //使得内部的dialog body充满剩余高度，如此一来嵌套的 iframe 也能随着充满
            var dialogBody = $(".el-dialog__body");
            if (dialogBody !== null) {
                dialogBody.css("flex", "1");
                dialogBody.css("display", "flex");
                dialogBody.css("flex-direction", "column");
                this.isAdjustedDialogSize = true;
            }
        }
    };
}

/**
 * 提供信息显示的功能
 * */
class MessageBoxEx {
    constructor() {
        this.vueObject = new Vue();
    }
    /**
     * 使用默认的方式显示错误信息
     * @param {any} err 错误信息
     * @param {string} message 显示消息
     */
    defaultShowError(err, message) {
        message = message || "操作异常！";
        this.vueObject.$message({ message: message + err || "", type: "error", duration: 1500 });
    }

    /**
 * 使用默认的方式显示失败信息
 * @param {string} message 失败信息
 */
    defaultShowFailed(message) {
        message = message || "操作失败！";
        this.vueObject.$message({ message: message, type: "warning", duration: 1200 });
    }

    /**
* 使用默认的方式显示成功信息
* @param {string} message 成功信息
*/
    defaultShowSuccess(message) {
        message = message || "操作成功！";
        this.vueObject.$message({ message: message, type: "success", duration: 800 });
    }

    showLoading(options) {
        loadingInstance = this.$loading(options);
    }

    hideLoading() {
        if (loadingInstance !== null) {
            loadingInstance.close();
        }
    }

    /**
     * 使用默认的选项显示一则通知信息
     * @param {string} text 通知的文本信息
     *  @param {string} title 通知的提示标题信息
     * @param {function} callback 通知被点击时的回调
     * */
    defaultShowNotification(text,title, callback) {
        this.vueObject.$notify(
            {
                title: title|| "提示",
                message: text,
                type: "info",
                duration: 5000,
                onClick: callback,
                position:"bottom-right"
            });
    }
    /**
     * 使用默认的设置显示一个警告信息
     * @param {string} info 警告信息
     */
    defaultShowWarning(info) {
        this.vueObject.$message({ message: info, type: "warning", duration: 1200 });
    }
    showMessage(options, duration) {
        if (typeof options === "string") {
            if (duration === undefined) {
                duration = 500;
            }
            return this.vueObject.$message({ message: options, type: "info", duration: duration });
        }
        else {
            return this.vueObject.$message(options);
        }
    }
    showMsgbox(options) {
        return this.vueObject.$msgbox(options);
    }
    showAlert(message, title, options) {
        return this.vueObject.$alert(message, title, options);
    }

    showConfirm(message, title, options) {
        return this.vueObject.$confirm(message, title, options);
    }


    showPrompt(message, title, options) {
        return this.vueObject.$prompt(message, title, options);
    }
}

/**
 * 全局消息框对象
 * @type {MessageBoxEx}
 * */
const $msgbox = new MessageBoxEx();

/**
 *提供 UI 通用方法工具箱
 * */
class UiToolKit {
    constructor() { }

    /**
     * 通过文件后缀名获取合适的图标样式
     * @param {string} name 文件名称
     * @returns {string} 返回样式的名称
     */
    getIconClassByFileName(name) {
        var className = "qms-icon qi-file";
        if (name) {
            var suffix = $utilities.getFileExstension(name);
            //您如果有需要请扩展此 switch 语句
            switch (suffix) {
                case "txt":
                    {
                        className = "qms-icon qi-file-txt";
                    } break;
                case "png":
                case "jpg":
                case "bmp":
                case "gif":
                    {
                        className = "qms-icon qi-file-image";
                    } break;
                case "doc":
                case "docx":
                    {
                        className = "qms-icon qi-file-word";
                    } break;
                case "xls":
                case "xlsx":
                    {
                        className = "qms-icon qi-file-excel";
                    } break;
                case "ppt":
                case "pptx":
                    {
                        className = "qms-icon qi-file-ppt";
                    } break;
                case "pdf":
                    {
                        className = "qms-icon qi-file-pdf";
                    } break;
                default:
                    {
                        //
                    } break;
            }
            //
        }
        return className;
    }

}
/** 
 * 全局UI工具箱对象
 * */
const $uitoolkit = new UiToolKit();