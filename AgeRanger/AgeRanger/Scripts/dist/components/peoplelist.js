"use strict";
var __extends = (this && this.__extends) || function (d, b) {
    for (var p in b) if (b.hasOwnProperty(p)) d[p] = b[p];
    function __() { this.constructor = d; }
    d.prototype = b === null ? Object.create(b) : (__.prototype = b.prototype, new __());
};
var React = require("react");
var persondetails_1 = require("./persondetails");
var PeopleList = (function (_super) {
    __extends(PeopleList, _super);
    function PeopleList() {
        var _this = _super.call(this) || this;
        _this.mapItem = _this.mapItem.bind(_this);
        return _this;
    }
    PeopleList.prototype.mapItem = function (person) {
        return (React.createElement(persondetails_1.PersonDetails, { person: person, getPerson: this.props.getPerson, key: person.Id }));
    };
    PeopleList.prototype.render = function () {
        var allPeople = null;
        if (Object.prototype.toString.call(this.props.people) === '[object Array]') {
            allPeople = this.props.people.map(this.mapItem);
        }
        return React.createElement("table", null,
            React.createElement("tbody", null,
                React.createElement("tr", null,
                    React.createElement("th", null, "First Name"),
                    React.createElement("th", null, "Last Name"),
                    React.createElement("th", null, "Age"),
                    React.createElement("th", null, "Age Group")),
                allPeople));
    };
    return PeopleList;
}(React.Component));
exports.PeopleList = PeopleList;
//# sourceMappingURL=peoplelist.js.map