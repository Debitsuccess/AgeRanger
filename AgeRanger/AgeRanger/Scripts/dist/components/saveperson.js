"use strict";
var __extends = (this && this.__extends) || function (d, b) {
    for (var p in b) if (b.hasOwnProperty(p)) d[p] = b[p];
    function __() { this.constructor = d; }
    d.prototype = b === null ? Object.create(b) : (__.prototype = b.prototype, new __());
};
var React = require("react");
var SavePerson = (function (_super) {
    __extends(SavePerson, _super);
    function SavePerson(props) {
        var _this = _super.call(this, props) || this;
        _this.state = {
            FirstName: '',
            LastName: '',
            Age: '',
            Message: '',
            Id: 0
        };
        _this.handleSubmit = _this.handleSubmit.bind(_this);
        _this.updateFirstName = _this.updateFirstName.bind(_this);
        _this.updateLastName = _this.updateLastName.bind(_this);
        _this.updateAge = _this.updateAge.bind(_this);
        return _this;
    }
    SavePerson.prototype.componentWillReceiveProps = function (nextProps, nextState) {
        if (nextProps.person.Id) {
            this.setState({
                FirstName: nextProps.person.FirstName,
                LastName: nextProps.person.LastName,
                Age: nextProps.person.Age.toString(),
                Message: '',
                Id: nextProps.person.Id
            });
        }
    };
    SavePerson.prototype.shouldComponentUpdate = function (nextProps, nextState) {
        return true;
    };
    SavePerson.prototype.updateFirstName = function (e) {
        var result = e.target.value;
        this.setState({ FirstName: e.target.value, LastName: this.state.LastName, Age: this.state.Age });
    };
    SavePerson.prototype.updateLastName = function (e) {
        this.setState({ FirstName: this.state.FirstName, LastName: e.target.value, Age: this.state.Age });
    };
    SavePerson.prototype.updateAge = function (e) {
        if (isNaN(e.target.value)) {
            this.setState({ FirstName: this.state.FirstName, LastName: this.state.LastName, Age: '' });
            return;
        }
        this.setState({ FirstName: this.state.FirstName, LastName: this.state.LastName, Age: e.target.value });
    };
    SavePerson.prototype.handleSubmit = function (e) {
        e.preventDefault();
        var firstName = this.state.FirstName.trim();
        var lastName = this.state.LastName.trim();
        var age = this.state.Age;
        var id = this.props.person.Id;
        if (!firstName || !lastName || !age) {
            this.setState({ FirstName: firstName, LastName: lastName, Age: age, Message: "First Name, Last Name and Age are required." });
            return;
        }
        this.props.onPersonSave({ FirstName: firstName, LastName: lastName, Age: age, Id: this.props.person.Id });
        this.setState({ FirstName: '', LastName: '', Age: '', Message: '' });
    };
    SavePerson.prototype.render = function () {
        var style = {
            width: 100
        };
        var styleError = {
            color: 333
        };
        var styleLeftMargin = {
            marginLeft: 100
        };
        return React.createElement("form", { onSubmit: this.handleSubmit },
            React.createElement("label", { style: styleError }, this.state.Message),
            React.createElement("br", null),
            React.createElement("label", { style: style }, "First Name"),
            React.createElement("input", { type: 'text', value: this.state.FirstName, onChange: this.updateFirstName, placeholder: 'Enter Your Name' }),
            React.createElement("br", null),
            React.createElement("label", { style: style }, "Last Name"),
            React.createElement("input", { type: 'text', value: this.state.LastName, onChange: this.updateLastName, placeholder: 'Enter Your Last Name' }),
            React.createElement("br", null),
            React.createElement("label", { style: style }, "Age"),
            React.createElement("input", { type: 'text', value: this.state.Age, onChange: this.updateAge, placeholder: 'Enter Your Age' }),
            React.createElement("br", null),
            React.createElement("input", { style: styleLeftMargin, type: 'submit', value: 'Add/Edit Person' }));
    };
    return SavePerson;
}(React.Component));
exports.SavePerson = SavePerson;
//# sourceMappingURL=saveperson.js.map