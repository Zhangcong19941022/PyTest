// 表格唯一标识
const gridManagerName = 'Details';

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
    refreshGrid: {
        key: 'refreshGrid',
        relyInit: true,
        title: '刷新表格',
        code: `GridManager.refreshGrid('${gridManagerName}');`
    },
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
        // 绑定搜索事件
        document.querySelector('.search-action').addEventListener('click', function () {
            var _query = {
                OrderNO: document.querySelector('[name="orderNo"]').value,
            };
            table.GM('setQuery', _query, function () {
                console.log('setQuery执行成功');
            });
        });

        //绑定重置
        document.querySelector('.reset-action').addEventListener('click', function () {
            document.querySelector('[name="orderNo"]').value = '';
        });
    },


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
                gridManagerName: 'Details',
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
             supportCheckbox: false,
            //选择框配置
            checkboxConfig: {
                // 使用单选
                // useRadio: true,

                // 使用行选中
                // useRowCheck: true,

                key: 'id',
                // 复选时最大可选数
                // max: 2,

                // 固定列
                fixed: 'left'
            },

            // 是否使用无总条数模式
            // useNoTotalsMode: true,
                // 是否开启分页
                supportAjaxPage: false,
            // 排序模式，single(升降序单一触发) overall(升降序整体触发)
            sortMode: 'single',


            // 禁用缓存
            disableCache: false,
            //数据请求AJAX用法
            ajaxData: function (settings, params) {
                return '/api/ProdForOrder/GetOrderHistory';
            },
            totalskey:'totals',
            ajaxType: 'POST',
            columnData: column,
          
            // AJAX失败事件函数
            ajaxError: function (errorInfo) {
                //console.log('ajaxError');
                alert("error", "数据请求失败！");
            },

          
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
        window.GridManager.updateRowData('Details', 'id', {id: window.parseInt(dom.getAttribute('data-id')), lastDate: new Date().getTime()});
    }
};


const column = [
    //{
    //    key: "Id",
    //    text: "ID"
    //}, 
    {
        key: "HisOrderNo",
        text: "工单号",
        width:"160px"
    },
    {
        key: "HisBaraName",
        text: "程序名称",
        width: "160px"
    },
    {
        key: "HisBaraPath",
        text: "上传地址",
        width: "300px"
    },
    {
        key: "CreateTime",
        text: "上传时间"
    },
    {
        key: "CreateBy",
        text: "上传人",
        width: "150px"
    }
]

// GridManager 渲染
const table = document.querySelector('table');
demo1.initSearch(table);
demo1.initGM(table);
demo1.initFN();

