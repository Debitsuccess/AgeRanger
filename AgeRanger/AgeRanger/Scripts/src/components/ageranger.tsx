import * as React from "react";
import { SavePerson } from './saveperson';
import {PeopleList } from './peoplelist'
import { Search } from './search';

export interface IPerson {
    Id: number;
    FirstName: string;
    LastName: string;
    Age: number;
    AgeGroup: string;
}


export interface AgeRangerProps {
    url: string;
    submitUrl: string;
}

export interface AgeRangerState {
    people: IPerson[];
    person : IPerson;
}

export class AgeRanger extends React.Component<AgeRangerProps, AgeRangerState> {

    constructor() {
        super();
        
        this.state = {people: [], person: { Id: 0, FirstName: '', LastName: '', Age: 0, AgeGroup :'' }};
        this.getDataFromServer();
        this.getDataFromServer = this.getDataFromServer.bind(this);
        this.handleSavePerson = this.handleSavePerson.bind(this);
        this.search = this.search.bind(this);
        this.getPerson = this.getPerson.bind(this);
    }

    getDataFromServer() {
        var origin = window.location.origin;
        var xhr = new XMLHttpRequest();
        xhr.open('GET', origin + '/api/ageranger/people', true);
        xhr.onload = function () {
            var data = JSON.parse(xhr.responseText);
            this.setState({ people: data });
        }.bind(this);
        xhr.send();
    }

    handleSavePerson(person: IPerson) {
        let querystring = 'age=' + person.Age + '&firstName=' + person.FirstName + '&lastName=' + person.LastName + '&Id=' + person.Id; 

        var xhr = new XMLHttpRequest();
        xhr.open('POST', window.location.origin + '/api/ageranger', true);
        xhr.setRequestHeader("Content-type", "application/x-www-form-urlencoded");
        xhr.onload = function () {
            this.getDataFromServer();
            this.setState({ person: { Id: 0, FirstName: '', LastName: '', Age: "", AgeGroup: '' } });
        }.bind(this);
        xhr.send(querystring);
       
    }

    search(search: string) {
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
    }


    getPerson(id: number) {
        var xhr = new XMLHttpRequest();
        xhr.open('GET', window.location.origin + '/api/ageranger/person/' + id, true);
        xhr.onload = function () {
            var person = JSON.parse(xhr.responseText);
            this.setState({ person: person });
        }.bind(this);
        xhr.send();
    }


    render() {
        return <div>
            <h1>Age Ranger App</h1>
            <hr />
            <SavePerson onPersonSave={this.handleSavePerson} onGetPerson={this.getPerson} person={this.state.person} />
            <hr />
            <Search onSearch={this.search} onClear={this.getDataFromServer} />
            <hr />
            <PeopleList people={this.state.people} getPerson={this.getPerson} />
        </div>
    }
}