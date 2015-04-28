var Common = {
    getExternalObj: function () {
        if (window.external)
            return window.external;
        return {};
    },
    callApi: function (apiname, jsonArg) {
        var apiurl = apiname.split('.');
        var result = JSON.parse(this.getExternalObj().API(apiurl[0], apiurl[1], JSON.stringify(jsonArg)));
         alert(JSON.stringify(result));
        //todo:需要实现异步请求的封装
        return new XHR(result);
    },
    requestApi: function (url, jsonArg) {
        var result = JSON.parse(this.getExternalObj().requestAPI(url, JSON.stringify(jsonArg)));
        //alert(JSON.stringify(result));
        //todo:需要实现异步请求的封装
        return new XHR(result);
    },
    error: function (msg) {

    }
};

var OData = {
    getDataForSql: function (sqlStr) {

    },
    getUserList: function () {
        //var result = Common.getExternalObj().API("DbContent", "getUserList", null);
        return Common.callApi("DbContent.getUserList", null);
    }
};
var System = {
    exit: function () {
        Common.callApi("application.exit", {});
    },
    windows_size: function () {
       return Common.callApi("application.windows_size", {});
    }
};
/**
    * XHR is only wrapper Deferred now , can do some special things
    * @param xhr
    * @param options
    * @constructor
    */
var XHR = function (data, option) {
    var _this = this;
    _this.success = function (fn) {
        if (fn && data.status) {
            fn(data.data);
        }
        return this;
    }
    _this.error = function (fn) {
        if (fn && !data.status) {
            fn(data.msg || "");
        }
        return this;
    }
    _this.data = function () {
        //alert(JSON.stringify(data));
        return data.data;
    }
};

var API = {
    request: function (controllerAction, arg) {
        return Common.requestApi(controllerAction, arg);
    }
}