"use strict";
var __extends = (this && this.__extends) || function (d, b) {
    for (var p in b) if (b.hasOwnProperty(p)) d[p] = b[p];
    function __() { this.constructor = d; }
    d.prototype = b === null ? Object.create(b) : (__.prototype = b.prototype, new __());
};
var React = require("react");
var AddPerson = (function (_super) {
    __extends(AddPerson, _super);
    function AddPerson() {
        var _this = _super.call(this) || this;
        _this.state = { visible: false };
        return _this;
    }
    ;
    AddPerson.prototype.render = function () {
        return React.createElement("div", null, this.state.visible
            ? React.createElement("label", null, "visible")
            : null);
    };
    return AddPerson;
}(React.Component));
exports.AddPerson = AddPerson;
//# sourceMappingURL=editperson.js.map