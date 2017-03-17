/******/ (function(modules) { // webpackBootstrap
/******/ 	// The module cache
/******/ 	var installedModules = {};
/******/
/******/ 	// The require function
/******/ 	function __webpack_require__(moduleId) {
/******/
/******/ 		// Check if module is in cache
/******/ 		if(installedModules[moduleId])
/******/ 			return installedModules[moduleId].exports;
/******/
/******/ 		// Create a new module (and put it into the cache)
/******/ 		var module = installedModules[moduleId] = {
/******/ 			i: moduleId,
/******/ 			l: false,
/******/ 			exports: {}
/******/ 		};
/******/
/******/ 		// Execute the module function
/******/ 		modules[moduleId].call(module.exports, module, module.exports, __webpack_require__);
/******/
/******/ 		// Flag the module as loaded
/******/ 		module.l = true;
/******/
/******/ 		// Return the exports of the module
/******/ 		return module.exports;
/******/ 	}
/******/
/******/
/******/ 	// expose the modules object (__webpack_modules__)
/******/ 	__webpack_require__.m = modules;
/******/
/******/ 	// expose the module cache
/******/ 	__webpack_require__.c = installedModules;
/******/
/******/ 	// identity function for calling harmory imports with the correct context
/******/ 	__webpack_require__.i = function(value) { return value; };
/******/
/******/ 	// define getter function for harmory exports
/******/ 	__webpack_require__.d = function(exports, name, getter) {
/******/ 		Object.defineProperty(exports, name, {
/******/ 			configurable: false,
/******/ 			enumerable: true,
/******/ 			get: getter
/******/ 		});
/******/ 	};
/******/
/******/ 	// getDefaultExport function for compatibility with non-harmony modules
/******/ 	__webpack_require__.n = function(module) {
/******/ 		var getter = module && module.__esModule ?
/******/ 			function getDefault() { return module['default']; } :
/******/ 			function getModuleExports() { return module; };
/******/ 		__webpack_require__.d(getter, 'a', getter);
/******/ 		return getter;
/******/ 	};
/******/
/******/ 	// Object.prototype.hasOwnProperty.call
/******/ 	__webpack_require__.o = function(object, property) { return Object.prototype.hasOwnProperty.call(object, property); };
/******/
/******/ 	// __webpack_public_path__
/******/ 	__webpack_require__.p = "";
/******/
/******/ 	// Load entry module and return exports
/******/ 	return __webpack_require__(__webpack_require__.s = 7);
/******/ })
/************************************************************************/
/******/ ([
/* 0 */
/***/ function(module, exports) {

module.exports = React;

/***/ },
/* 1 */
/***/ function(module, exports, __webpack_require__) {

"use strict";
"use strict";
var __extends = (this && this.__extends) || (function () {
    var extendStatics = Object.setPrototypeOf ||
        ({ __proto__: [] } instanceof Array && function (d, b) { d.__proto__ = b; }) ||
        function (d, b) { for (var p in b) if (b.hasOwnProperty(p)) d[p] = b[p]; };
    return function (d, b) {
        extendStatics(d, b);
        function __() { this.constructor = d; }
        d.prototype = b === null ? Object.create(b) : (__.prototype = b.prototype, new __());
    };
})();
Object.defineProperty(exports, "__esModule", { value: true });
var React = __webpack_require__(0);
var saveperson_1 = __webpack_require__(5);
var peoplelist_1 = __webpack_require__(3);
var search_1 = __webpack_require__(6);
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


/***/ },
/* 2 */
/***/ function(module, exports) {

module.exports = ReactDOM;

/***/ },
/* 3 */
/***/ function(module, exports, __webpack_require__) {

"use strict";
"use strict";
var __extends = (this && this.__extends) || (function () {
    var extendStatics = Object.setPrototypeOf ||
        ({ __proto__: [] } instanceof Array && function (d, b) { d.__proto__ = b; }) ||
        function (d, b) { for (var p in b) if (b.hasOwnProperty(p)) d[p] = b[p]; };
    return function (d, b) {
        extendStatics(d, b);
        function __() { this.constructor = d; }
        d.prototype = b === null ? Object.create(b) : (__.prototype = b.prototype, new __());
    };
})();
Object.defineProperty(exports, "__esModule", { value: true });
var React = __webpack_require__(0);
var persondetails_1 = __webpack_require__(4);
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


/***/ },
/* 4 */
/***/ function(module, exports, __webpack_require__) {

"use strict";
"use strict";
var __extends = (this && this.__extends) || (function () {
    var extendStatics = Object.setPrototypeOf ||
        ({ __proto__: [] } instanceof Array && function (d, b) { d.__proto__ = b; }) ||
        function (d, b) { for (var p in b) if (b.hasOwnProperty(p)) d[p] = b[p]; };
    return function (d, b) {
        extendStatics(d, b);
        function __() { this.constructor = d; }
        d.prototype = b === null ? Object.create(b) : (__.prototype = b.prototype, new __());
    };
})();
Object.defineProperty(exports, "__esModule", { value: true });
var React = __webpack_require__(0);
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


/***/ },
/* 5 */
/***/ function(module, exports, __webpack_require__) {

"use strict";
"use strict";
var __extends = (this && this.__extends) || (function () {
    var extendStatics = Object.setPrototypeOf ||
        ({ __proto__: [] } instanceof Array && function (d, b) { d.__proto__ = b; }) ||
        function (d, b) { for (var p in b) if (b.hasOwnProperty(p)) d[p] = b[p]; };
    return function (d, b) {
        extendStatics(d, b);
        function __() { this.constructor = d; }
        d.prototype = b === null ? Object.create(b) : (__.prototype = b.prototype, new __());
    };
})();
Object.defineProperty(exports, "__esModule", { value: true });
var React = __webpack_require__(0);
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


/***/ },
/* 6 */
/***/ function(module, exports, __webpack_require__) {

"use strict";
"use strict";
var __extends = (this && this.__extends) || (function () {
    var extendStatics = Object.setPrototypeOf ||
        ({ __proto__: [] } instanceof Array && function (d, b) { d.__proto__ = b; }) ||
        function (d, b) { for (var p in b) if (b.hasOwnProperty(p)) d[p] = b[p]; };
    return function (d, b) {
        extendStatics(d, b);
        function __() { this.constructor = d; }
        d.prototype = b === null ? Object.create(b) : (__.prototype = b.prototype, new __());
    };
})();
Object.defineProperty(exports, "__esModule", { value: true });
var React = __webpack_require__(0);
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


/***/ },
/* 7 */
/***/ function(module, exports, __webpack_require__) {

"use strict";
"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
var React = __webpack_require__(0);
var ReactDOM = __webpack_require__(2);
var ageranger_1 = __webpack_require__(1);
ReactDOM.render(React.createElement(ageranger_1.AgeRanger, { url: 'person', submitUrl: 'person/new' }), document.getElementById("ageranger"));


/***/ }
/******/ ]);
//# sourceMappingURL=bundle.js.map