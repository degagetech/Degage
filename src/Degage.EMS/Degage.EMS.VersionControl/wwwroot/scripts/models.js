"use strict";

/**
 * 包含服务响应信息的集合
 * */
class ResponsePacket {
    constructor(source) {
        /**
         * 表示此次请求处理是否成功
         * */
        this.Success = false;
        /**
         *  响应附加的消息，通常用于说明处理结果
         * */
        this.Message = '';
        this.State = 0;
        /**
         * 响应返回的数据
         * */
        this.Data = null;
        /**
         *  响应返回的数据1
         * */
        this.Data1 = null;
        Object.assign(this, source);
    }
}


/**
 * 分页条件
 * */
class PageCondition {
    constructor() {
        this.StartIndex = 0;
        this.Count = 200;
        this.StatisticsCount = 0;
        this.RequiredStatistics = false;
        this.RequiredLimit = false;
    }
}


/**
 * 消息类型定义
 * */
let MessageTypes = {
    Public: { Value: 0, Desc: "公开" },
    Group: { Value: 1, Desc: "组" },
    Private: { Value: 2, Desc: "私有" }
};

/**
 * 消息的等级集合
 * */
let MessageLevels =
{
    Info: { Value: 0, Desc: "信息" },
    Alert: { Value: 1, Desc: "提醒" },
    Warning: { Value: 2, Desc: "警告" },
    Error: { Value: 3, Desc: "错误" }
};


class ProjectInfo {
    constructor(data) {
        this.Id = '';
        this.CurrentVersionId = '';
        this.Title = '';
        this.IconFileId = '';
        this.Description = '';
        this.CreationTime = new Date();
        this.LastAccessTime = new Date();
        if (data !== undefined) {
            Object.assign(this, data);
        }
    }
}

class ProjectInfoCondition extends PageCondition
{
    constructor() {
        super();
        this.Id = '';
        this.LastAccessTimeStart = null;
        this.LastAccessTimeEnd = null;
    }
}