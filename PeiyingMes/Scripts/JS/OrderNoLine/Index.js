// 表格唯一标识
const gridManagerName = 'test';

// 渲染类型声明
//const TYPE_MAP = {
//    '1': 'HTML/CSS',
//    '2': 'nodeJS',
//    '3': 'javaScript',
//    '4': '前端鸡汤',
//    '5': 'PM Coffee',
//    '6': '前端框架',
//    '7': '前端相关'
//};

// 公开方法列表
const GM_PUBLISH_METHOD_MAP = {
    init: {
        key: 'init',
        relyInit: false,
        title: '初始化',
        code: 'demo1.initGM(document.querySelector("table"));'
    },
    get: {
        key: 'get',
        relyInit: true,  // 是否依赖init方法
        title: '获取表格的实时配置信息',
        code: `GridManager.get('${gridManagerName}');`
    },
    version: {
        key: 'version',
        relyInit: false,
        title: '获取当前GridManager的版本号',
        code: 'GridManager.version;'
    },
    getLocalStorage: {
        key: 'getLocalStorage',
        relyInit: true,
        title: '获取表格用户记忆',
        code: `GridManager.getLocalStorage('${gridManagerName}');`
    },
    resetLayout: {
        key: 'resetLayout',
        relyInit: true,
        title: '重置表格布局',
        code: `GridManager.resetLayout('${gridManagerName}', '800px', '500px');`
    },
    clear: {
        key: 'clear',
        relyInit: true,
        title: '清除表格记忆数据',
        code: `GridManager.clear('${gridManagerName}');`
    },
    getTableData: {
        key: 'getTableData',
        relyInit: true,
        title: '获取指定tr所使用的数据',
        code: `GridManager.getTableData('${gridManagerName}');`
    },
    getRowData: {
        key: 'getRowData',
        relyInit: true,
        title: '获取指定tr所使用的数据',
        code: `GridManager.getRowData('${gridManagerName}', document.querySelector("table[grid-manager=${gridManagerName}] tbody tr"));`
    },
    updateRowData: {
        key: 'updateRowData',
        relyInit: true,
        title: '更新指定行所使用的数据',
        code: `GridManager.updateRowData('${gridManagerName}', 'id', {id: 92, title: 'ccc'});`
    },
    updateTreeState: {
        key: 'updateTreeState',
        relyInit: true,
        title: '更新树的展开状态',
        code: `GridManager.updateTreeState('${gridManagerName}', true);`
    },
    setSort: {
        key: 'setSort',
        relyInit: true,
        title: '手动设置排序',
        code: `GridManager.setSort('${gridManagerName}', {createDate: 'ASC'});`
    },
    setConfigVisible: {
        key: 'setConfigVisible',
        relyInit: true,
        title: '设置表头配置区域可视状态',
        code: `GridManager.setConfigVisible('${gridManagerName}', true);`
    },
    showTh: {
        key: 'showTh',
        relyInit: true,
        title: '设置列为可视状态',
        code: `GridManager.showTh('${gridManagerName}', 'pic');`
    },
    hideTh: {
        key: 'hideTh',
        relyInit: true,
        title: '设置列为隐藏状态',
        code: `GridManager.hideTh('${gridManagerName}', 'pic');`
    },
    exportGrid: {
        key: 'exportGrid',
        relyInit: true,
        title: '导出指定表格',
        code: `GridManager.exportGrid('${gridManagerName}', 'demo中使用的导出').then(res=>{console.log('success')}).catch(err=>{console.error('error', err)});`
    },
    setQuery: {
        key: 'setQuery',
        relyInit: true,
        title: '更改在生成组件时所配置的参数query',
        code: `GridManager.setQuery('${gridManagerName}', {'userName':'baukh','sex':'男'});`
    },
    setAjaxData: {
        key: 'setAjaxData',
        relyInit: true,
        title: '用于再次配置ajaxData数据',
        code: `GridManager.setAjaxData('${gridManagerName}', {data: [{title: '通过setAjaxData动态添加的数据，其它项为空'}], totals: 1});`
    },
    //refreshGrid: {
    //    key: 'refreshGrid',
    //    relyInit: true,
    //    title: '刷新表格',
    //    code: `GridManager.refreshGrid('${gridManagerName}');`
    //},
    renderGrid: {
        key: 'renderGrid',
        relyInit: true,
        title: '渲染表格',
        code: `GridManager.renderGrid('${gridManagerName}');`
    },
    getCheckedTr: {
        key: 'getCheckedTr',
        relyInit: true,
        title: '获取当前选中的行',
        code: `GridManager.getCheckedTr('${gridManagerName}');`
    },
    getCheckedData: {
        key: 'getCheckedData',
        relyInit: true,
        title: '获取选中行的渲染数据',
        code: `GridManager.getCheckedData('${gridManagerName}');`
    },
    setCheckedData: {
        key: 'setCheckedData',
        relyInit: true,
        title: '设置选中的数据',
        code: `GridManager.setCheckedData('${gridManagerName}', [GridManager.getTableData('${gridManagerName}')[1]]);`
    },
    cleanData: {
        key: 'cleanData',
        relyInit: true,
        title: '清除指定表格数据',
        code: `GridManager.cleanData('${gridManagerName}');`
    },
    print: {
        key: 'print',
        relyInit: true,
        title: '打印当前页',
        code: `GridManager.print('${gridManagerName}');`
    },
    destroy: {
        key: 'destroy',
        relyInit: true,
        title: '消毁指定的GridManager实例',
        code: `GridManager.destroy('${gridManagerName}');`
    }
};
const demo1 = {
    /**
     * 初始化搜索区域
     */
    initSearch: function () {
        // 渲染下拉框
        //var typeSelect = document.querySelector('.search-area select[name="type"]');

        //for(let key in TYPE_MAP) {
        //    const option = document.createElement('option');
        //    option.value = key;
        //    option.innerText = TYPE_MAP[key];
        //    typeSelect.appendChild(option);
        //}

        // 绑定搜索事件
        document.querySelector('.search-action').addEventListener('click', function () {
            var _query = {
                OrderNO: document.querySelector('[name="orderNo"]').value,
                //type: document.querySelector('[name="type"]').value,
                //content: document.querySelector('[name="content"]').value
            };
            table.GM('setQuery', _query, function () {
                console.log('setQuery执行成功');
            });
        });

         //绑定重置
        document.querySelector('.reset-action').addEventListener('click', function () {
            document.querySelector('[name="orderNo"]').value = '';
            //document.querySelector('[name="type"]').value = '-1';
            //document.querySelector('[name="content"]').value = '';
        });
    },

    //initSearch: function () {
    //    document.querySelector('.search-action').addEventListener('click', function () {
    //        var _query = {
    //            OrderNO: document.querySelector('[name="orderNo"]').value
    //        };

    //        table.GM('setQuery', _query, function () {
    //            console.log("search");
    //        });
    //    })

    //},

    /**
     * 初始化方法区域
     */
    initFN: () => { },

    /**
     * 初始化表格
     */
    initGM: function () {
        new window.GridManager(table,
            {
            gridManagerName: 'test',
            width: '100%',
            height: '100%',
            // 初始渲染时是否加载数据
            // firstLoading: false,

            // supportAutoOrder: false,
            // 自动序号配置
            autoOrderConfig: {
                // 固定列
                fixed: 'left'
            },
           // supportCheckbox: false,
            // 选择框配置
            checkboxConfig: {
                // 使用单选
                 useRadio: true,

                // 使用行选中
                 useRowCheck: true,

                key: 'id',
                // 复选时最大可选数
                // max: 2,

                // 固定列
                fixed: 'left'
            },

            // 是否使用无总条数模式
            // useNoTotalsMode: true,
            // 是否开启分页
            supportAjaxPage: true,
            // 排序模式，single(升降序单一触发) overall(升降序整体触发)
            sortMode: 'single',

            // supportAdjust: false,
            // 是否开启配置功能
            // supportConfig: false,

            // 设置表头的icon图标是否跟随文本
            // isIconFollowText: true,

            // 是否开启导出
            // supportExport: false,

            // 是否开启打印
            // supportPrint: false,

            // 右键菜单
            //supportMenu: true,
            //menuHandler: list => {
            //    list.unshift({
            //        content: '自定义菜单',
            //        line: true,
            //        onClick: _ => {
            //            alert(_);
            //        }
            //    });
            //    return list;
            //},

            // 禁用分割线
            // disableLine: true,

            // 组合排序
            // isCombSorting: true,

            // 合并排序
            // mergeSort: true,

            // 禁用边框线
            // disableBorder: true,

            //// 行移动
            //supportMoveRow: true,
            //moveRowConfig: {
            //    key: 'priority',
            //    handler: (list, tableData) => {
            //        console.log(list, tableData);
            //    }
            //},

            // 禁用缓存
            disableCache: false,
            //数据请求AJAX用法
            ajaxData: function (settings, params) {
               // document.querySelector('[name="type"]').value = params.type || -1;
             //  return 'https://www.lovejavascript.com/blogManager/getBlogList';
                return '/api/ProdForOrder/GetVOrderNoLine';
            },
         //   ajaxHeaders: { 'Content-Type': 'application/json' },
            //请求的数据为list,要将list转换成数组的形式
            //responseHandler: function (response) {
            //    //var DataOrder = {};
            //    //DataOrder.data = response;
            //    //DataOrder.totals = response.length;
            //    //console.log(DataOrder);
            //    //return DataOrder;
            //    for (var i = 0; i < response.length; i++) {
            //        dataInfo.push(response[i]);
            //    };
            //    dataOrdder.totals = response.length;
            //    console.log(dataOrdder);
            //    return dataOrdder;
            //},
            totalskey:'totals',
            ajaxType: 'POST',
            columnData: columnOrder,
            // 导出配置
            //exportConfig: {
            //    fileName: query => {
            //        const date = new Date();
            //        let fileName = `${date.getFullYear()}-${date.getMonth() + 1}-${date.getDate()}`;
            //        for (let key in query) {
            //            fileName = `${fileName}-${key}=${query[key]}`;
            //        }
            //        return fileName;
            //    },
            //    suffix: 'xls'
            //},
         
            //// 选择事件执行前事件
            //checkedBefore: function (checkedList, isChecked, row) {
            //    console.log('checkedBefore==', checkedList, isChecked, row);
            //    if (row && row.id === 90) {
            //        alert('该节点在checkedBefore中配置为不可选');
            //    }
            //    return row && row.id !== 90;
            //},
            
            // 选择事件执行后事件
            checkedAfter: function (checkedList, isChecked, row) {
                //console.log(row.OrderNO);
                //console.log('checkedAfter==', row);
                //给文本框赋值
                
                    if (isChecked) {
                        document.querySelector('[name="hiddenValue"]').setAttribute("value", row.OrderNO);
                        console.log($("[name='hiddenValue']").val());
                }
                else {
                        document.querySelector('[name="hiddenValue"]').setAttribute("value", "");
                        console.log($("[name='hiddenValue']").val());
                }
            },
          

            
            //// 全选事件执行前事件
            //checkedAllBefore: function (checkedList, isChecked) {
            //    console.log('checkedAllBefore==', checkedList, isChecked);
            //    //
            //    // if (isChecked) {
            //    //     alert('不能取消全选');
            //    // }
            //    // return !isChecked;
            //},

            //// 全选事件执行后事件
            //checkedAllAfter: function (checkedList, isChecked) {
            //    console.log('checkedAllAfter==', checkedList, isChecked);
            //},

            //// 执行排序前事件
            //sortingBefore: function (query) {
            //    console.log('sortingBefore', query);
            //},

            //// 排行排序后事件
            //sortingAfter: function (query) {
            //    console.log('sortingAfter', query);
            //},

            //// AJAX请求前事件函数
            //ajaxBeforeSend: function (promise) {
            //    console.log('ajaxBeforeSend');
            //},
            // AJAX成功事件函数
            //ajaxSuccess: function (response) {
            //    //console.log('ajaxSuccess');
            //},

            // AJAX失败事件函数
            ajaxError: function (errorInfo) {
                //console.log('ajaxError');
                alert("error", "数据请求失败！");
            },

            //// AJAX结束事件函数
            //ajaxComplete: function (complete) {
            //    console.log('ajaxComplete');
            //},
            //adjustBefore: eve => {
            //    console.log('adjustBefore=>', eve);
            //},
            //adjustAfter: eve => {
            //    console.log('adjustAfter=>', eve);
            //},

            //// 执行请求后执行程序
            //responseHandler: res => {
            //    //res.data.forEach(item => {
            //    //    Console.log(res.data);
            //    //    // 用id模拟优先级字段
            //    //    item.priority = item.ProdOrderID;
            //    //});
            //    console.log(res.data);
            //    return res;
            //},
            // 单行数据渲染时执行程序
            rowRenderHandler: (row, index) => {
                // if (row.id === 90) {
                //     row.gm_checkbox = true;
                // }

                // 指定第92行不可选中
                if (row.id === 92) {
                        // row.gm_checkbox = true;
                    row.gm_checkbox_disabled = true;
                    row.gm_row_class_name = 'test-row-class';
                }
                return row;
            },

            emptyTemplate: settings => {
                return `<div style="text-align: center;">${settings.query.title ? '搜索为空' : '暂无数据'}</div>`;
            }
            // 单个td的hover事件
            // cellClick: (row, rowIndex, colIndex) => {
            //     // console.log(row, rowIndex, colIndex);
            //     return {
            //         text: '这里有个提示',
            //         position: 'left'
            //     };
            // },
            //rowHover: (a, b, c) => {
            //  console.log(a, b, c);
            //    return {
            //        text: '这里有个提示',
            //        position: 'right'
            //    };
            //},
            // useWordBreak: true,
            },
            query => {
            // 渲染完成后的回调函数
            console.log('渲染完成后的回调函数:', query);
            }
        );
    },

    /**
     * 编辑功能
     */
    editRowData: function (dom) {
        window.GridManager.updateRowData('test', 'id', {id: window.parseInt(dom.getAttribute('data-id')), lastDate: new Date().getTime()});
    }
};


const columnOrder = [
    //{
    //    key: "ProdOrderID",
    //    text: "ID"
    //}, 
    {
        key: "OrderNO",
        text: "工单号",
        width:"160px"
    },
    {
        key: "ItemCode",
        text: "产品编码"
    },
    {
        key: "ItemName",
        text: "产品名称"
    },
    {
        key: "ItemSpec",
        text: "产品规格"
    },
    {
        key: "BaraName",
        text: "程序包名称",
        width: "150px"
    },
    {
        key: "BaraPath",
        text: "程序包上地址",
        width:"250px"
    },
    {
        key: "BaraTime",
        text: "上传时间",
        width: "100px"
    },
    {
        key: "Qty_to_Build",
        text: "工单数量"
    },
    {
        key: "Qty_Released",
        text: "已释放数量"
    }, {
        key: "Qty_Done",
        text: "已完成数量"
    },
    //{
    //    key: "OrderType",
    //    text: "订单类型"
    //},
    {
        key: "StatusDesc",
        text: "状态",
    },
    {
        key: "R_Name",
        text: "路由名称"
    },
    {
        key: "CustomerName",
        text: "客户简称"
    },
    {
        key: "Planned_Start_Time",
        text: "工单计划开始时间"
    },
    {
        key: "Actual_Start_Date",
        title: "工单实际开始时间"
    },
    {
        key: "Planned_Completed_Date",
        text: "工单计划完成时间"
    },
    {
        key: "Actual_Completed_Date",
        text: "工单实际完成时间"
    },
    {
        key: "IsMESaddDesc",
        text: "工单来源"
    }
    
]

// GridManager 渲染
const table = document.querySelector('table');
demo1.initSearch(table);
demo1.initGM(table);
demo1.initFN();

//上传前验证
function Uploadfile() {

    
    var orderNo = $("[name='hiddenValue']").val();
    if (orderNo == "") {
        alert("请选择工单！");
        return;
    }
    var zipUpdate = $('#zipId')[0].files[0];
    var formData = new FormData();
    formData.append("zipFile", zipUpdate);
    formData.append("orderNo", orderNo);

    //uploadZip(formData, callback);

    //校验文件存在的情况是否继续上传
    $.ajax({
        url: '/api/ProdForOrder/CheckFile',
        method: 'POST',
        async: true,
        processData: false,
        contentType: false,
        data: formData,
        success: function (result) {
            if (result)
            {
                if (confirm("文件已存在，是否覆盖上传？")) {
                    $("[name='upbutton']").val('上传中...');
                    UplaodData(formData);
                }
                else {
                    return;
                }
            }
            else {
                $("[name='upbutton']").val('上传中...');
                UplaodData(formData);
            }
        }
    });
}


//上传文件
function UplaodData(formData) {
    $.ajax({
        url: '/api/ProdForOrder/UpLoadFile',
        method: 'POST',
        async: true,
        processData: false,
        contentType: false,
        data: formData,

        success: function (result) {
            alert(result);
            if (result == "success") {
                //重新加载表格
                //  GM_PUBLISH_METHOD_MAP.refreshGrid("refreshGrid", true, "刷新表格","test");
                //刷新表格
                GridManager.refreshGrid('test', false, function (result) {
                 
                });
            }
            $("[name='upbutton']").val('上传');
            //页面跳转
            // window.location.href = '/Home/Index';
        },
        error: function () {
            alert("Error", "上传失败！");
        }

    });
}
