"use strict";
/**
 * 用于向服务发出请求
 * */
class ServiceRequester {
    constructor() {
        this.LoadingCounter = 0;
        this.LastShowTime = new Date();
        this.WaitShowLoading = false;

        /**
       * axios 对象，提供提供服务请求能力
       * @type {axios}
      * */
        var axiosObj = axios.create({
            //调式时使用
            timeout: 50000  // 请求超时时间
        });
        axiosObj.interceptors.request.use(config => {
            //预处理
            this.LoadingCounter++;
            var currentTime = new Date();
            //如果两次等待的时间间隔大于 800 ms 才显示等待
            if (!this.WaitShowLoading && currentTime - this.LastShowTime > 800) {
                this.WaitShowLoading = true;
                //一些执行时间过短暂的任务不显示等待框
                setTimeout(this.showLoading.bind(this), 400);
            }

            return config;
        }, error => {
            //请求错误处理
                this.LoadingCounter--;
                if (this.LoadingCounter <= 0) {
                    msgbox.hideLoading();
                    this.LoadingCounter = 0;
                }
            return Promise.reject(error);
        });

        axiosObj.interceptors.response.use((response) => {
            //预处理
            this.LoadingCounter--;
            if (this.LoadingCounter <= 0) {
                msgbox.hideLoading();
                this.LoadingCounter = 0;
            }
            return response;
        }, (error) => {
                this.LoadingCounter--;
            if (this.LoadingCounter <= 0) {
                msgbox.hideLoading();
                this.LoadingCounter = 0;
            }
            return Promise.reject(error);
        });
        return axiosObj;
    }
    showLoading() {
        if (this.LoadingCounter > 0) {
            msgbox.showLoading({ lock: true });
            this.LastShowTime = new Date();
        }
        this.WaitShowLoading = false;
    }

}
/**
 * 全局服务请求对象
 * */
var $serviceRequester = new ServiceRequester();
/**
 * 基础服务代理类，提供服务接口访问
 * */
class ServiceProxy {
    constructor() {
        this.PostRequestConfig = {
            headers:
            {
                'Content-Type': 'application/x-www-form-urlencoded; charset=UTF-8'
            }
        };
        this.Requester = $serviceRequester;
    }

    /**
     * 通过指定条件查询数据源信息
     * @param {ProjectInfoCondition} condition 查询条件
     * @returns {ProjectInfo[]}  ProjectInfo 信息数组
     */
    queryProjectInfos(condition) {
        var para = $.param(condition);
        return this.Requester.get("/AddProject?handler=QueryProjectInfos&" + para);
    }

    addProjectInfo(info) {
        var formData = $utilities.createFormData(info);
        return this.Requester.post("/AddProject?handler=AddProjectInfo",
            formData,
            this.PostRequestConfig
        );
    }


    updateProjectInfo(newInfo) {
        var formData = $utilities.createFormData(newInfo);
        return this.Requester.post("/AddProject?handler=UpdateProjectInfo",
            formData,
            this.PostRequestConfig
        );
    }

    deleteProjectInfo(id) {
        return this.Requester.delete("/AddProject?handler=RemoveProjectInfo&id="+id);
    }
   

 
}




/**
 * 全局基础服务代理对象
 * @type {ServiceProxy}
 * */
var $proxy = new ServiceProxy();





