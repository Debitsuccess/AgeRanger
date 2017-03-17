import * as React from 'react';
import { IPerson } from './ageranger';
import { PersonDetails } from './persondetails';


interface IPeopleListProps {
    people: IPerson[];
    getPerson: any;
}


interface IPeopleListState {

}

export class PeopleList extends React.Component<IPeopleListProps, IPeopleListState>{
    constructor() {
        super();
        this.mapItem = this.mapItem.bind(this);
    }

    mapItem(person: IPerson) {
        return (<PersonDetails person={person} getPerson={this.props.getPerson} key={person.Id}></PersonDetails>);
    }

    render() {
        let allPeople = null;

        if (Object.prototype.toString.call(this.props.people) === '[object Array]') {
             allPeople = this.props.people.map(this.mapItem);
        } 

        return <table>
            <tbody>
                <tr>
                    <th>First Name</th>
                    <th>Last Name</th>
                    <th>Age</th>
                    <th>Age Group</th>
                </tr>
                {allPeople}
            </tbody>
        </table>


    }
}
