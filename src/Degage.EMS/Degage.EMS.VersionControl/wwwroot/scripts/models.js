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
 * 角色信息的查询条件
 * */
class RoleInfoCondition extends PageCondition {
    constructor() {
        super();
        this.ApplicationArea = '';
    }
}

/**
 * 功能信息的查询条件
 * */
class FunctionInfoCondition extends PageCondition {
    constructor() {
        super();
        this.ApplicationArea = '';
    }
}

/**
 * 统计数据源查询条件
 * */
class StatisDataSourceInfoCondition extends PageCondition {
    constructor() {
        super();
        /**
         *  数据源的类型
         * */
        this.Type = null;
    }
}

/**
 * 菜单信息的查询条件
 * */
class MenuInfoCondition extends PageCondition {
    constructor() {
        super();
        this.ApplicationArea = '';
    }
}

/**
 * 用户信息的查询条件
 * */
class UserInfoCondition extends PageCondition {
    constructor() {
        super();
        this.ApplicationArea = '';
    }
}

/**
 * 令牌信息查询条件
 * */
class PermissionTokenCondition {
    constructor() {
        this.TokenType = null;
        this.UserId = '';
        this.Feature = '';
    }

}

/**
 * 功能信息
 * */
class PermissionFunctionInfo {
    constructor() {
        this.Code = '';
        this.Name = '';
        this.Description = '';
        this.ApplicationArea = '';
    }
}

/**
 * 用户信息
 * */
class PermissionUser {
    constructor() {
        this.PinyinNameCode = '';
        this.Name = '';
        this.WubiNameCode = '';
        this.UserType = null;
        this.UserTypeDesc = '';
        this.Id = '';
        this.Idcard = '';
        this.AvatarFileId = '';
        this.ApplicationArea = '';
        this.IsDisable = false;
    }
}

/**
 * 用户类型
 * */
let PermissionUserTypes = {
    Normal: { Value: 0, Desc: "普通用户" },
    Admin: { Value: 10, Desc: "管理员" }
};

/**
 * 用户令牌信息
 * */
class PermissionToken {
    constructor() {
        this.Feature = '';
        this.TokenType = null;
        this.TokenTypeDesc = '';
        this.PasswordValidTime = new Date();
        this.UserId = '';
    }
}

/**
 * 角色信息
 * */
class PermissionRoleInfo {
    constructor() {
        this.Id = '';
        this.Name = '';
        this.Description = '';
        this.ApplicationArea = '';
        this.IsDisabled = false;
    }
}


/**
 * 菜单信息
 * */
class MenuConfigInfo {
    constructor() {
        this.Id = '';
        this.MenuName = '';
        this.ParentId = '';
        this.Title = '';
        this.FunctionCode = '';
        this.IconClass = '';
        this.Sort = 0;
        this.Route = '';
        this.IsShortcuts = false;
        this.IsStartup = false;
        this.IsFullScreen = false;
        this.IsLink = false;
        this.ApplicationArea = '';
    }
}


/**
 * 文件目录信息
 * */
class FileDirectoryInfo {
    constructor() {
        this.Id = '';
        this.Name = '';
        this.Description = '';
        this.ParentId = '';
        this.IconClass = '';
        this.Sort = 0;
        this.Level = 0;
    }
}



/**
 * 记录各个角色对目录中文件的操作权限
 * */
class AuthorizationDirectory {
    constructor() {
        this.Id = '';
        this.RoleId = '';
        this.DirectoryId = '';
        this.IsReadable = false;
        this.IsAddable = false;
        this.IsDeletable = false;
        this.IsMovable = false;

    }

}


/**
 * 表示一个文件结点信息，此类对象用于构建文件树
 * */
class FileInfoNode {
    constructor(data) {

        this.Name = '';
        this.Id = '';
        this.Description = '';
        /**
         * 结点类型，目前有 file、directory 两种
         * @type {string}
         * */
        this.NodeType = '';
        /**
         * 当结点类型为 file 时，此值保存文件标识
         * */
        this.FileId = '';
        /**
           * 当结点类型为 file 时，此值保存所属目录的标识，为 directory 时，保存所属的父目录的标识
           * */
        this.ParentId = '';
        /**
         * 结点的图标样式
         * */
        this.IconClass = '';
        /**
         * 当结点类型为 file 时，表示此文件是否被删除
         * */
        this.IsDeleted = false;
        /**
         * 当结点类型为 file 时，表示此文件的类型
         * */
        this.FileType = '';
        this.CreateTime = new Date();
        this.CreatorName = '';
        this.EnabledVersion = 0;
        this.IsLeaf = false;
        /**
        * 表示此结点的状态
        * */
        this.State = null;
        this.StateDesc = '';
        this.IsModifying = false;
        if (data !== undefined) {
            Object.assign(this, data);
        }
    }

}



/**
*记录系统的文件项信息
**/
class FileItemInfo {
    constructor() {

        /**
         *内部：标识
        **/
        this.Id = '';

        /**
         *文件的名称
        **/
        this.Name = '';

        /**
         *文件的描述信息
        **/
        this.Description = '';

        /**
         *此文件所属的目录的标识
        **/
        this.DirectoryId = '';

        /**
         *当前启用的文件版本的 file_id
        **/
        this.EnabledFileId = '';

        /**
         *当前启用的文件版本的版本号
        **/
        this.EnabledVersion = 0;

        /**
         *文件类型，例如 png、doc 等
        **/
        this.FileType = '';

        /**
         *为文件定义的图标样式
        **/
        this.IconClass = '';

        /**
         *文件最新的版本号
        **/
        this.LatestVersion = 0;
        this.Sort = 0;

        /**
         *此文件是否被标识为已删除
        **/
        this.IsDeleted = false;
        /**
         * 文件项的状态
         * */
        this.State = 0;
        /**
         * 文件项的状态的描述
         * */
        this.StateDesc = '';
    }
}



/**
 * 目录授权信息查询条件
 * */
class DirectoryAuthInfoCondition extends PageCondition {
    constructor() {
        super();
        this.RoleId = '';
        this.DirectoryId = '';
        this.UserId = '';
    }
}

/**
 * 文件项信息查询条件
 * */
class FileItemInfoCondition extends PageCondition {
    constructor() {
        super();
        this.DirectoryId = "";
    }
}


/**
* 消息明细信息查询条件
* */
class MessageDetailCondition extends PageCondition {
    constructor() {
        super();
        this.UserId = '';
        this.MessageType = null;
    }
}

/**
  *记录消息明细信息
  **/
class MessageDetailInfo {
    constructor(data) {

        /**
         *消息唯一标识
        **/
        this.Id = '';

        /**
         *消息类型：公开、组、私有
        **/
        this.Type = 0;
        this.TypeDesc = '';
        /**
         *消息的标题
        **/
        this.Title = '';

        /**
         *内容
        **/
        this.Content = '';

        /**
         *消息等级
        **/
        this.Level = 0;
        this.LevelDesc = '';

        /**
         *消息排序字段
        **/
        this.Sort = 0;

        /**
         *创建时间
        **/
        this.CreateTime = new Date();

        /**
         *所属用户，私有消息使用
        **/
        this.UserId = '';

        /**
         *所属角色，组消息使用
        **/
        this.RoleId = '';

        /**
         *是否有链接
        **/
        this.HasLink = false;

        /**
         *链接值
        **/
        this.LinkValue = '';

        /**
         *指示内容是否为 HTML
        **/
        this.IsHtml = false;

        /**
         *消息是否已读，当消息为私有类型时，此字段生效
        **/
        this.IsReaded = false;

        if (data !== undefined) {
            Object.assign(this, data);
        }
    }
}






/**
*文件修改申请信息
**/
class FileModifyApply {
    constructor() {

        /**
         *内部：唯一标识
        **/
        this.Id = '';

        /**
         *关联的文件项的标识
        **/
        this.FileItemId = '';

        /**
         *申请人姓名
        **/
        this.ApplicantName = '';

        /**
         *申请人的标识
        **/
        this.ApplicantId = '';

        /**
         *原始内容
        **/
        this.OriginalContent = '';

        /**
         *修订内容
        **/
        this.ReviseContent = '';

        /**
         *申请时间
        **/
        this.ApplyTime = new Date();

        /**
         *审核人姓名
        **/
        this.AuditorName = '';

        /**
         *审核人标识
        **/
        this.AuditorId = '';

        /**
         *审核意见
        **/
        this.AuditOpinion = '';

        /**
         *文件的新名称
        **/
        this.NewName = '';

        /**
         *新的文件标识
        **/
        this.NewFileId = '';
        /**
       *旧的文件标识
      **/
        this.OldFileId = '';
        /**
         *申请当前的状态
        **/
        this.State = 0;
        this.StateDesc = '';
        /**
         *审核时间
        **/
        this.AuditTime = new Date();
        /**
         * 审核结果
         * */
        this.AuditResult = '';
        /**
         * 审核结果描述
         * */
        this.AuditResultDesc = null;
        /**
         *修改理由
        **/
        this.Reason = '';
        /**
         * 申请关联的文件版本号
         * */
        this.Version = 0;
        /**
         * 是否启用此修改的版本
         * */
        this.IsEnabledVersion = false;
    }
}




/**
 * 文件修改审核信息
 * */
class FileModifyAuditInfo {
    constructor(data) {
        this.ApplyId = null;
        this.AuditOpinion = null;
        this.AuditTime = null;
        this.AuditResult = null;
        this.AuditResultDesc = '';
        this.IsEnabledVersion = true;
        if (data !== undefined) {
            Object.assign(this, data);
        }
    }
}






/**
 * 文件修改申请查询条件
 * */
class FileModifyApplyCondition extends PageCondition {
    constructor() {
        super();
        this.ApplyId = '';
        this.ApplicantId = '';
        this.ApplyTimeStart = null;
        this.ApplyTimeEnd = null;
        this.ApplyState = null;
    }
}


/**
 * 消息载体
 * */
class MessageCourier {
    constructor(data) {
        this.Type = '';
        this.Content = '';
        this.Target = '';
        if (data !== undefined) {
            Object.assign(this, data);
        }
    }
}




/**
*数据统计与分析：数据源信息
**/
class StatisDataSourceInfo {
    constructor(data) {
        /**
         *内部：唯一标识
        **/
        this.Id = '';

        /**
         *数据源的名称
        **/
        this.Name = '';

        /**
         *数据源的类型，默认数据库
        **/
        this.Type = 0;

        /**
         *数据源的连接字符串
        **/
        this.ConnctionString = '';

        /**
         *数据库的类型，当数据源类型为数据库时
        **/
        this.DataBaseType = '';

        /**
         *数据源的描述信息
        **/
        this.Description = '';

        /**
         *表示资源的基础地址，当数据源为 RESTFULL 服务时
        **/
        this.ResourceUrl = '';

        /**
         *数据源类型的描述信息
        **/
        this.TypeDesc = '';

        if (data) {
            Object.assign(this, data);
        }
    }
}

/**
 * 存儲用戶密碼的修改信息
 * */
class PasswordChangeInfo {
    constructor() {
        this.OldPassword = '';
        this.NewPassword = '';
        this.ConfirmPassword = '';
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






/**
 * 响应状态码集合
 * */
let ResponseStatusCodes = {
    Ok: 0,
    SessionExceed: 100
};


/**
 * 文件修改申请审核结果
 * */
let FileModifyAuditResult = {
    /**
     * 不通过
     * */
    NoPass: { Value: 0, Desc: "不通过" },
    /**
    * 通过
    * */
    Passed: { Value: 1, Desc: "通过" }
};


/**
 * 文件修改申请状态码
 * */
let FileModifyApplyState = {
    Submitted: { Value: 0, Desc: "提交" },
    Audit: { Value: 1, Desc: "待审核" },
    Auditting: { Value: 2, Desc: "审核中" },
    Audited: { Value: 3, Desc: "已审核" }
};



/**
 * 页面编辑模式
 * */
let PageEditMode = {
    ReadOnly: "readonly",
    Edit: "edit",
    Add: "add",
    Audit: "audit"
};

/**
 * 文件项状态
 * */
let FileItemInfoState = {
    /**
     *正常
     */
    Normal: { Value: 0, Desc: "正常" },
    /**
     *修改中
     */
    Modifying: { Value: 1, Desc: "修改中" }
};


/**
 * 记录文件结点类型
 * */
let FileInfoNodeType = {
    File: "file",
    Directory: 'directory'
};


/**
 * 权限令牌的类型
 * */
let PermissionTokenTypes = {
    Login: { Value: 0, Desc: "登录验证" },
    Operation: { Value: 1, Desc: "操作验证" }
};


/**
 * 统计数据源类型
 * */
let StatisDataSourceTypes = {
    DataBase: { Value: 0, Desc: "数据库" },
    Rest: { Value: 1, Desc: "REST 服务" }
};


/**
 * 数据库类型
 * */
let DatabaseTypes = {
    DataBase: { Value: "Mssql", Desc: "SQL Server 数据库" },
    Restfull: { Value: "MySql", Desc: "MySql （MariaDb）" }
};

let DatabaseConnStrTemplates = [
    {
        value: "server= 主机地址 ;Port= 端口号 ;Uid= 账户 ;Pwd= 密码 ;DataBase= 数据库名称 ;Pooling=true;charset=utf8;",
        label: "MySql 连接字符串模板"
    },
    {
        value: "Data Source= 主机地址 ;Uid= 账户 ;Pwd= 密码 ;Initial Catalog= dbname ;",
        label: "SqlServer 连接字符串模板"
    }
];
