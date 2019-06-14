"use strict";
//用于对齐数字，例如 length 传入 3，  1->001、10->010
function formatNumber(num, length) {
    var r = "" + num;
    while (r.length < length) {
        r = "0" + r;
    }
    return r;
}

var loadingInstance = null;
var msgbox = new Vue();
msgbox.showLoading = function (options) {
    loadingInstance = this.$loading(options);
};
msgbox.hideLoading = function () {
    if (loadingInstance !== null) {
        loadingInstance.close();
    }
};

msgbox.showMessage = function (options, duration) {
    if (typeof options === "string") {
        if (duration === undefined) {
            duration = 500;
        }
        return this.$message({ message: options, type: "info", duration: duration });
    }
    else {
        return this.$message(options);
    }

};
msgbox.showMsgbox = function (options) {
    return this.$msgbox(options);
};
msgbox.showAlert = function (message, title, options) {
    return this.$alert(message, title, options);
};

msgbox.showConfirm = function (message, title, options) {
    return this.$confirm(message, title, options);
};


msgbox.showPrompt = function (message, title, options) {
    return this.$prompt(message, title, options);
};

/**
 * 通过表单中的数据创建一个 FormData，此函数忽略信息的  parent、children 属性
 * @returns {FomData} 返回一个 FormData 对象
 * @param {any} formInfo 表单信息
 */
function createFormData(formInfo) {
    var formData = new FormData();
    for (var pro in formInfo) {
        if (pro !== "parent" && pro !== "children") {
            formData.append(pro, formInfo[pro]);
        }
    }
    return formData;
}


/**
 * 通过具有子父关系的数组构建一个树
 * @returns {Tree} 通过数组构建的树
 * @param {Array} data  含有子父关系的原始数据
 * @param {any} options 构建选项  id 表示数据的唯一标识，parentId 表示父项的标识  children 表示存储子项的属性名称 parent 表示存储父项的属性名称
 */
function listToTree(data, options) {
    options = getTreeOptions(options);
    var tree = [],
        childrenOf = {};
    var item, id, parentId;
    let chrildren = [];
    for (var i = 0, length = data.length; i < length; i++) {
        item = data[i];
        id = item[options.id];
        parentId = item[options.parentId] || 0;
        chrildren = item[options.children];
        if (chrildren === undefined || chrildren === null) {
            // every item may have children
            childrenOf[id] = childrenOf[id] || [];
            // init its children
            item[options.children] = childrenOf[id];
        }
        if (parentId !== 0) {
            // init its parent's children object
            childrenOf[parentId] = childrenOf[parentId] || [];
            // 如果容器中已经有此子对象，则不添加
            if (_.findIndex(childrenOf[parentId], t => t[options.id] === item[options.id]) === -1) {
                childrenOf[parentId].push(item);
            }
        } else {
            tree.push(item);
        }
    }

    //如果定了某个 parent id 的子结点容器，但是又不存在这个结点，则相应容器中的结点，直接添加到最外层
    for (var pro in childrenOf) {
        var index = _.findIndex(data, t => t[options.id] === pro);
        if (index === -1) {
            childrenOf[pro].forEach(t => {
                tree.push(t);
            });
        }
        else {
            //如果找到了，则把容器中所有子结点的父结点设为自己
            var parent = data[index];
            var container = childrenOf[pro];
            var containerLength = container.length;
            for (var j = 0; j < containerLength; j++) {
                container[j][options.parent] = parent;
            }
        }
    }
    return tree;
}

/**
 * 更新树的结构
 * @return {tree} 更新结构后的树
 * @param {any} tree 需要被更新的树
 * @param {any} options 结点的结构
 */
function updateTree(tree, options) {
    options = getTreeOptions(options);
    var list = treeToList(tree);
    var result = listToTree(list, options);
    return result;
}

/**
 * 将具有子父关系的数据树，转换为一个所有结点平级的数组
 * @returns {Array} 转换后的数组
 * @param {any} tree 数据树
 *  @param {any} options  提供树结点结构的选项 id 表示数据的唯一标识，parentId 表示父项的标识  children 表示存储子项的属性名称 parent 表示存储父项的属性名称
 */
function treeToList(tree, options) {
    options = getTreeOptions(options);
    let length = tree.length;
    let array = [];
    for (var i = 0; i < length; i++) {
        let item = tree[i];
        getTreeNodeItem(item, options, array);
    }
    return array;
}
function getTreeOptions(options) {
    options = options || {};
    options.id = options.id || 'id';
    options.parentId = options.parentId || 'parentId';
    options.children = options.children || 'children';
    options.parent = options.parent || 'parent';
    return options;
}
/**
 * 向树中添加结点
 * @param {any} tree 树
 * @param {any} options 结点结构选项
 * @param {any} node 需要被添加的结点
 */
function addNodeToTree(tree, options, node) {
    options = getTreeOptions(options);

    var parentId = node[options.parentId];
    //如果结点没有标识父结点则直接添加
    if (parentId === undefined || parentId === null) {
        tree.push(node);
    }
    else {
        var length = tree.length;
        //寻找父结点
        for (var i = 0; i < length; i++) {
            let item = findNode(tree[i], options, parentId);
            if (item !== null) {
                let children = item[options.children];
                if (children === undefined || children === null) {
                    children = [];
                    item[options.children] = children;
                }
                children.push(node);
                break;
            }
        }
    }

}

function findNode(item, options, id) {
    var result = null;
    if (item[options.id] === id) return item;
    var chrildren = item[options.chrildren];
    if (chrildren !== undefined && chrildren !== null && chrildren.length > 0) {
        let length = chrildren.length;
        let subItem = null;
        for (var i = 0; i < length; i++) {
            subItem = chrildren[i];
            if (subItem[options.id] === id) return subItem[options.id];
            result = findNode(subItem, options, id);
            if (result !== null) {
                return result;
            }
        }
    }
    return result;
}

function deleteNodeToTree(tree, options, node) {


}


/**
 * 获取树结点的子项，并添加至指定数组中
 * @param {any} item 树的结点
 * @param {any} options  提供树结点结构的选项 id 表示数据的唯一标识，parentId 表示父项的标识  children 表示存储子项的属性名称 parent 表示存储父项的属性名称
 * @param {any} array 存放数据的数组
 */
function getTreeNodeItem(item, options, array) {
    var chrildren = item[options.children];
    if (item[options.parent] !== undefined) {
        item[options.parent] = null;
    }
    if (chrildren !== undefined && chrildren !== null) {
        chrildren.forEach(t => {
            getTreeNodeItem(t, options, array);
        });
        item[options.children] = null;
    }
    array.push(item);

}


function getParentSelectOptions(row, datalist, configs) {
    configs = getTreeOptions(configs);
    var selectOptions = [];
    if (row !== undefined && row !== null) {
        //添加同级选项
        var parent = row[configs.parent] || null;
        if (parent !== undefined && parent !== null) {
            let levelOptions = [];
            parent[configs.children].forEach(t => {
                if (t[configs.id] !== row[configs.id]) {
                    levelOptions.push(t);
                }
            });
            selectOptions.push({ label: "同级", options: levelOptions });
            //添加父级选项
            let parentOptions = [];
            var gradfather = parent[configs.parent] || null;
            if (gradfather !== undefined && gradfather !== null) {
                gradfather[configs.chrildren].forEach(t => {
                    if (t[configs.id] !== row[configs.parentId]) {
                        parentOptions.push(t);
                    }
                });
                selectOptions.push({ label: "父级", options: parentOptions });
            }
            else {
                //表示是父容器是顶层容器
                let parentOptions = [];
                datalist.forEach(t => {
                    if (t[configs.id] !== row[configs.id]) {
                        parentOptions.push(t);
                    }
                });
                selectOptions.push({ label: "父级", options: parentOptions });
            }
        }
        else {
            let levelOptions = [];
            datalist.forEach(t => {
                if (t[configs.id] !== row[configs.id]) {
                    levelOptions.push(t);
                }
            });
            selectOptions.push({ label: "同级", options: levelOptions });
        }
    }
    else {
        let levelOptions = [];
        datalist.forEach(t => {
            levelOptions.push(t);
        });
        selectOptions.push({ label: "同级", options: levelOptions });
    }
    return selectOptions;
}

/**
 * 工具集合类
 * */
class Utilities {
    constructor() {

    }

    /**
     * 通过指定的对象，复制其属性创建一个新的对象，并忽略特定属性
     * @returns {any} 复制的对象
     * @param {any} obj 需要被复制的对象
     * @param {any} ignores 忽略的属性
     */
    cloneObject(obj, ignores) {
        ignores = ignores || ['parent', 'children'];
        var newObj = new Object();
        for (var pro in obj) {
            let index = _.findIndex(ignores, t => t === pro);
            if (index !== -1) continue;
            newObj[pro] = obj[pro];
        }
        return newObj;
    }

    /**
     * 将指定对象的属性值复制到另一个对象中，并指定需要忽略的属性
     * @param {any} target 复制接收对象
     * @param {any} source 需要被复制的对象
     * @param {any} ignores 忽略的属性
 */
    copyObject(target, source, ignores) {
        ignores = ignores || ['parent', 'children'];
        for (var pro in obj) {
            let index = _.findIndex(ignores, t => t === pro);
            if (index !== -1) continue;
            target[pro] = source[pro];
        }
    }


    /**
 * 通过表单中的数据创建一个 FormData，此函数忽略信息的  parent、children 属性
 * @returns {FomData} 返回一个 FormData 对象
 * @param {any} formInfo 表单信息
 */
    createFormData(formInfo) {
        var formData = new FormData();
        for (var pro in formInfo) {
            if (pro !== "parent" && pro !== "children") {
                formData.append(pro, formInfo[pro]);
            }
        }
        return formData;
    }

    /**
     * 将文件目录信息，转化为文件信息结点
     * @param {FileDirectoryInfo[]} directoryInfos 需要转化的文件目录信息
     * @returns {FileInfoNode[]} 返回文件信息结点数组
     */
    convertDirectoryInfosToNode(directoryInfos) {
        var result = [];
        var length = directoryInfos.length;
        for (var i = 0; i < length; i++) {
            var directory = directoryInfos[i];
            var info = new FileInfoNode();
            info.Id = directory.Id;
            info.ParentId = directory.ParentId;
            info.IconClass = directory.IconClass;
            info.NodeType = FileInfoNodeType.Directory;
            info.Name = directory.Name;
            info.Description = directory.Description;
            result.push(info);
        }
        return result;
    }



    /**
 * 将文件目录信息数组，转化为文件信息结点数组
 * @param {FileItemInfo[]} itemInfos 需要转化的文件目录信息数组
 * @returns {FileInfoNode[]} 返回文件信息结点数组
 */
    convertFileItemInfosToNode(itemInfos) {
        var result = [];
        var length = itemInfos.length;
        for (var i = 0; i < length; i++) {
            var itemInfo = itemInfos[i];
            var info = this.convertFileItemInfoToNode(itemInfo);
            result.push(info);
        }
        return result;
    }

    /**
    * 将文件目录信息，转化为文件信息结点
    * @param {FileItemInfo} itemInfo 需要转化的文件目录信息
    * @returns {FileInfoNode} 返回文件信息结点数组
    */
    convertFileItemInfoToNode(itemInfo) {
        var info = new FileInfoNode();
        info.Id = itemInfo.Id;
        info.ParentId = itemInfo.DirectoryId;
        info.IconClass = itemInfo.IconClass;
        info.NodeType = FileInfoNodeType.File;
        info.Name = itemInfo.Name;
        info.Description = itemInfo.Description;
        info.FileType = itemInfo.FileType;
        info.FileId = itemInfo.EnabledFileId;
        info.IsDeleted = itemInfo.IsDeleted;
        info.CreationTime = itemInfo.CreationTime;
        info.CreatorName = itemInfo.CreatorName;
        info.EnabledVersion = itemInfo.EnabledVersion;
        info.Sort = itemInfo.Sort;
        info.State = itemInfo.State;
        info.StateDesc = itemInfo.StateDesc;
        if (itemInfo.State === FileItemInfoState.Modifying.Value) {
            info.IsModifying = true;
        }

        info.IsLeaf = true;
        return info;
    }

    /**
     * 通过指定的名称获取文件扩展名，不包括 .  返回例如： png、doc、xls
     * @param {string} name 文件名称
     * @returns {string} 返回文件的后缀名
     */
    getFileExstension(name) {
        var index1 = name.lastIndexOf(".");
        var index2 = name.length;
        var suffix = name.substring(index1 + 1, index2) + "";
        return suffix.toLowerCase();
    }
    /**
    * 获取文件名称，但不包括扩展名   返回例如：test.jpg=>test
    * @param {string} name 文件名称
    * @returns {string} 返回文件名称
    */
    getFileNameWithoutExstension(name) {
        var index1 = name.lastIndexOf(".");
        var result = name.substring(0, index1) + "";
        return result;
    }

    /**
     * 获取枚举值对应的描述信息
     * @param {any} enumInfo 枚举信息
     * @param {Number} value  枚举值
     * @returns {string} 返回枚举值的描述
     */
    getEnumDesc(enumInfo, value) {
        for (var x in enumInfo) {
            if (enumInfo[x].Value === undefined) {
                return '';
            }
            if (enumInfo[x].Value === value) {
                return enumInfo[x].Desc;
            }
        }
        return '';
    }
    /**
     * 返回文件标识的包装信息
     * @param {string} fileId 文件标识
     * @returns {string} 返回包装后的文件信息
     */
    getFileIdWarpper(fileId) {
        var ext = $utilities.getFileExstension(fileId);
        switch (ext) {
            case "doc":
            case "docx":
            case "xls":
            case "xlsx":
            case "ppt":
            case "pptx":
                {
                    fileId += ".pdf";
                } break;
        }
        return fileId;
    }
    /**
     * 判断字符串是否为空
     * @param {string} str 需要判断的字符串
     * @returns {boolean} 若为空则 true，否则为 false
     */
    isNullOrEmpty(str) {
        if (str === undefined || str === null) {
            return true;
        }
        if (str.length === 0) {
            return true;
        }
        return false;
    }

    /**
     * 打开全屏模式的对话框，并导向到指定地址
     * @param {string} address 导向的地址
     * @param {boolean} request 是否请求让浏览器也进入全屏，默认请求
     * @param {string} title 对话框的标题
     */
    openFullDialog(address, request, title) {
        window.top.openFullDialog(address, request, title);
    }
    /**
     * 当前是否已有全屏窗口
     * @returns {boolean} 若有返回 true，若无返回 false
     * */
    hadFullDialog() {
        return window.top.hasFullDialog();
    }

    /**
     *将指定文本按换行符分割为包含所有单行文本的数组
     * @param {string} text 需要分割的文本
     * @returns {string[]} 返回一个字符串的数组
     */
    splitTextToLines(text) {
        let lines = [];
        lines=text.split("\n");
        return lines;
    }
    /**
     * 将文本按指定符号分割为字符串数组
     * @param {string} text 待分割的文本
     * @param {string} symbol 分割符号
     * @returns {string[]} 返回一个字符串的数组
    */
    splitText(text, symbol) {
        let lines = [];
        lines = text.split(symbol);
        return lines;
    }
}

/**
 * 全局的工具类对象
 * */
const $utilities = new Utilities();