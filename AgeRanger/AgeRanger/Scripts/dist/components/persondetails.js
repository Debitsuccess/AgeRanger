"use strict";
var __extends = (this && this.__extends) || function (d, b) {
    for (var p in b) if (b.hasOwnProperty(p)) d[p] = b[p];
    function __() { this.constructor = d; }
    d.prototype = b === null ? Object.create(b) : (__.prototype = b.prototype, new __());
};
var React = require("react");
var PersonDetails = (function (_super) {
    __extends(PersonDetails, _super);
    function PersonDetails() {
        return _super.call(this) || this;
    }
    PersonDetails.prototype.render = function () {
        var styleWidth = {
            width: 100
        };
        var styleWidthLastCol = {
            width: 250
        };
        return React.createElement("tr", null,
            React.createElement("td", { style: styleWidth },
                " ",
                this.props.person.FirstName),
            React.createElement("td", { style: styleWidth },
                " ",
                this.props.person.LastName),
            React.createElement("td", { style: styleWidth }, this.props.person.Age),
            React.createElement("td", { style: styleWidthLastCol },
                React.createElement("a", { href: "#", onClick: this.props.getPerson.bind(this, this.props.person.Id) }, this.props.person.AgeGroup)));
    };
    return PersonDetails;
}(React.Component));
exports.PersonDetails = PersonDetails;
//# sourceMappingURL=persondetails.js.map