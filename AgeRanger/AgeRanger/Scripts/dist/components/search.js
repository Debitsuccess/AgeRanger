"use strict";
var __extends = (this && this.__extends) || function (d, b) {
    for (var p in b) if (b.hasOwnProperty(p)) d[p] = b[p];
    function __() { this.constructor = d; }
    d.prototype = b === null ? Object.create(b) : (__.prototype = b.prototype, new __());
};
var React = require("react");
var Search = (function (_super) {
    __extends(Search, _super);
    function Search() {
        var _this = _super.call(this) || this;
        _this.state = { searchText: '' };
        _this.search = _this.search.bind(_this);
        _this.clear = _this.clear.bind(_this);
        return _this;
    }
    Search.prototype.search = function (e) {
        e.preventDefault();
        this.setState({ searchText: e.target.value });
        this.props.onSearch(e.target.value);
    };
    Search.prototype.clear = function (e) {
        e.preventDefault();
        this.setState({ searchText: '' });
        this.props.onClear();
    };
    Search.prototype.render = function () {
        var styleWidth = {
            width: 100
        };
        return React.createElement("div", null,
            React.createElement("label", { style: styleWidth }, "Search"),
            React.createElement("input", { type: "text", value: this.state.searchText, onChange: this.search, placeholder: "Search by Name" }),
            React.createElement("input", { type: "button", onClick: this.clear, value: "Reload All Data" }));
    };
    return Search;
}(React.Component));
exports.Search = Search;
//# sourceMappingURL=search.js.map