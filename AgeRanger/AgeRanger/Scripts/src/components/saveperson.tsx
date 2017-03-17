import * as React from "react";
import { IPerson } from './ageranger';

export interface SavePersonProps {
    onPersonSave: any;
    onGetPerson: any;
    person: IPerson;
}

export interface SavePersonState {
    FirstName: string;
    LastName: string;
    Age: string;
    Message: string;
    Id: number;
}

export class SavePerson extends React.Component<SavePersonProps, SavePersonState>{
    constructor(props: SavePersonProps) {
        super(props);
        this.state = {
            FirstName: '',
            LastName: '',
            Age: '',
            Message: '',
            Id: 0              
        };    

        this.handleSubmit = this.handleSubmit.bind(this);
        this.updateFirstName = this.updateFirstName.bind(this);
        this.updateLastName = this.updateLastName.bind(this);
        this.updateAge = this.updateAge.bind(this);
    }

    componentWillReceiveProps(nextProps: any, nextState: any) {
        if (nextProps.person.Id) {
            this.setState({
                FirstName: nextProps.person.FirstName,
                LastName: nextProps.person.LastName,
                Age: nextProps.person.Age.toString(),
                Message: '',
                Id: nextProps.person.Id
            });
        }

    }

    shouldComponentUpdate(nextProps: any, nextState: any): boolean {
        return true;
    }


     updateFirstName(e: any) {
        var result = e.target.value;
        this.setState({ FirstName: e.target.value, LastName: this.state.LastName, Age: this.state.Age });
    }

    updateLastName(e: any) {
        this.setState({ FirstName: this.state.FirstName, LastName: e.target.value, Age: this.state.Age });
    }

    updateAge(e: any) {
        if (isNaN(e.target.value)) {
            this.setState({ FirstName: this.state.FirstName, LastName: this.state.LastName, Age: '' });
            return;
        }
        this.setState({ FirstName: this.state.FirstName, LastName: this.state.LastName, Age: e.target.value });   
    }

    handleSubmit(e: any) {
        e.preventDefault();
        let firstName = this.state.FirstName.trim();
        let lastName = this.state.LastName.trim();
        let age = this.state.Age;
        let id = this.props.person.Id;

        if (!firstName || !lastName || !age) {
            this.setState({ FirstName: firstName, LastName: lastName, Age: age, Message: "First Name, Last Name and Age are required." });
            return;
        }

        this.props.onPersonSave({ FirstName: firstName, LastName: lastName, Age: age, Id: this.props.person.Id });
        this.setState({ FirstName: '', LastName: '', Age: '', Message: '' });
    }

    render() {
        const style = {
            width: 100
        };

        const styleError = {
            color: 333
        };

        const styleLeftMargin = {
            marginLeft: 100
        };

        return <form onSubmit={this.handleSubmit} >
            <label style={styleError}>{this.state.Message}</label><br />

            <label style={style}>First Name</label>
            <input type='text' value={this.state.FirstName} onChange={this.updateFirstName} placeholder='Enter Your Name' /><br />
          
            <label style={style}>Last Name</label>
            <input type='text' value={this.state.LastName} onChange={this.updateLastName} placeholder='Enter Your Last Name' /><br />

            <label style={style}>Age</label>
            <input type='text' value={this.state.Age} onChange={this.updateAge} placeholder='Enter Your Age' /><br />

            <input style={styleLeftMargin} type='submit' value='Add/Edit Person' />
        </form>
    }
}