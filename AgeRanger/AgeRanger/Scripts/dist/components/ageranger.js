"use strict";
var __extends = (this && this.__extends) || function (d, b) {
    for (var p in b) if (b.hasOwnProperty(p)) d[p] = b[p];
    function __() { this.constructor = d; }
    d.prototype = b === null ? Object.create(b) : (__.prototype = b.prototype, new __());
};
var React = require("react");
var saveperson_1 = require("./saveperson");
var peoplelist_1 = require("./peoplelist");
var search_1 = require("./search");
var AgeRanger = (function (_super) {
    __extends(AgeRanger, _super);
    function AgeRanger() {
        var _this = _super.call(this) || this;
        _this.state = { people: [], person: { Id: 0, FirstName: '', LastName: '', Age: 0, AgeGroup: '' } };
        _this.getDataFromServer();
        _this.getDataFromServer = _this.getDataFromServer.bind(_this);
        _this.handleSavePerson = _this.handleSavePerson.bind(_this);
        _this.search = _this.search.bind(_this);
        _this.getPerson = _this.getPerson.bind(_this);
        return _this;
    }
    AgeRanger.prototype.getDataFromServer = function () {
        var origin = window.location.origin;
        var xhr = new XMLHttpRequest();
        xhr.open('GET', origin + '/api/ageranger/people', true);
        xhr.onload = function () {
            var data = JSON.parse(xhr.responseText);
            this.setState({ people: data });
        }.bind(this);
        xhr.send();
    };
    AgeRanger.prototype.handleSavePerson = function (person) {
        var querystring = 'age=' + person.Age + '&firstName=' + person.FirstName + '&lastName=' + person.LastName + '&Id=' + person.Id;
        var xhr = new XMLHttpRequest();
        xhr.open('POST', window.location.origin + '/api/ageranger', true);
        xhr.setRequestHeader("Content-type", "application/x-www-form-urlencoded");
        xhr.onload = function () {
            this.getDataFromServer();
            this.setState({ person: { Id: 0, FirstName: '', LastName: '', Age: "", AgeGroup: '' } });
        }.bind(this);
        xhr.send(querystring);
    };
    AgeRanger.prototype.search = function (search) {
        if (search.length <= 0) {
            this.getDataFromServer();
            return;
        }
        var xhr = new XMLHttpRequest();
        xhr.open('GET', window.location.origin + '/api/ageranger/search/' + search, true);
        xhr.onload = function () {
            var data = JSON.parse(xhr.responseText);
            this.setState({ people: data });
        }.bind(this);
        xhr.send();
    };
    AgeRanger.prototype.getPerson = function (id) {
        var xhr = new XMLHttpRequest();
        xhr.open('GET', window.location.origin + '/api/ageranger/person/' + id, true);
        xhr.onload = function () {
            var person = JSON.parse(xhr.responseText);
            this.setState({ person: person });
        }.bind(this);
        xhr.send();
    };
    AgeRanger.prototype.render = function () {
        return React.createElement("div", null,
            React.createElement("h1", null, "Age Ranger App"),
            React.createElement("hr", null),
            React.createElement(saveperson_1.SavePerson, { onPersonSave: this.handleSavePerson, onGetPerson: this.getPerson, person: this.state.person }),
            React.createElement("hr", null),
            React.createElement(search_1.Search, { onSearch: this.search, onClear: this.getDataFromServer }),
            React.createElement("hr", null),
            React.createElement(peoplelist_1.PeopleList, { people: this.state.people, getPerson: this.getPerson }));
    };
    return AgeRanger;
}(React.Component));
exports.AgeRanger = AgeRanger;
//# sourceMappingURL=ageranger.js.map