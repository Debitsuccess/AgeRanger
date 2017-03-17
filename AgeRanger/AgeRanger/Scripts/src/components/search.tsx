import * as React from 'react';
import { IPerson } from './ageranger';


interface ISearchProps {
    onSearch: any;
    onClear: any;

}


interface ISearchState {
    searchText: string;
}

export class Search extends React.Component<ISearchProps, ISearchState>{
    constructor() {
        super();
        this.state = { searchText: '' };

        this.search = this.search.bind(this);
        this.clear = this.clear.bind(this);
    }

    search(e: any) {
        e.preventDefault();
        this.setState({ searchText: e.target.value });
        this.props.onSearch(e.target.value);
    }

    clear(e: any) {
        e.preventDefault();  
        this.setState({ searchText: '' });
        this.props.onClear();
    }


    render() {

        const styleWidth = {
            width: 100
        }

        return <div>
            <label style={styleWidth}>Search</label>
            <input type="text" value={this.state.searchText} onChange={this.search} placeholder="Search by Name" />
            <input type="button" onClick={this.clear} value="Reload All Data" />
        </div>
    }
}

