import React from "react";
import FileUpload from '../FileUpload';
import EmployeesTable from "../EmployeesTable";
import { registerEmployeePairs } from '../../helpers/actions';

class Admin extends React.Component {
    constructor(props) {
        super(props);

        this.state = {
            employeePairs: []
        }

        this.registerEmployeePairs = registerEmployeePairs.bind(this);
    }

    render() {
        const actions = { registerEmployeePairs: this.registerEmployeePairs };

        return <>
            <FileUpload actions={actions} />
            {
                this.state.employeePairs.length !== 0
                    ? <EmployeesTable
                        data={this.state.employeePairs}
                    />
                    : null
            }
        </>
    }
}

export default Admin;