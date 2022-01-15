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
            <p className="card text-center">
                <span className="card-header">
                    Pair of employees that have worked as a team for the longest time
                </span>
                <span className="card-body">
                    <strong className="card-title">Upload a text file</strong>
                    <br /><br />
                    <FileUpload actions={actions} />
                </span>
            </p>

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