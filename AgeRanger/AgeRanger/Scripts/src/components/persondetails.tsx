import * as React from 'react';
import { IPerson } from './ageranger';


interface IPersonDetailsProps {
    person: IPerson;
    getPerson: any;
}


interface IPersonDetailsState {

}

export class PersonDetails extends React.Component<IPersonDetailsProps, IPersonDetailsState>{
    constructor() {
        super();
    }

    render() {

        const styleWidth = {
            width: 100
        }


        const styleWidthLastCol = {
            width: 250
        }

        return <tr>
            <td style={styleWidth}> {this.props.person.FirstName}</td>
            <td style={styleWidth}> {this.props.person.LastName}</td>
            <td style={styleWidth}>{this.props.person.Age}</td>
            <td style={styleWidthLastCol}>
                <a href="#" onClick={this.props.getPerson.bind(this,this.props.person.Id)}>{this.props.person.AgeGroup}</a>
            </td>
        </tr>
    }
}

