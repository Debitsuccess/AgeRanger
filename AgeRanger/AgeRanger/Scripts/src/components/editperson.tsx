import * as React from "react";

export interface EditPersonProps {

}

export interface EditPersonState {
    visible: boolean;
}

export class AddPerson extends React.Component<EditPersonProps, EditPersonState>{
    constructor() {
        super();
        this.state = { visible: false};
    };

    render() {
        return <div >
            {
                this.state.visible
                    ? <label>visible</label>
                    : null
            }
            </div>
    }
}
