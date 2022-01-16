import React from "react";
import FileUpload from '../FileUpload';
import EmployeesTable from "../EmployeesTable";
import { setEmployeePairs, setIsFileUploaded } from '../../helpers/actions';

class Admin extends React.Component {
    constructor(props) {
        super(props);

        this.state = {
            employeePairs: [],
            IsFileUploaded: false
        }

        this.setEmployeePairs = setEmployeePairs.bind(this);
        this.setIsFileUploaded = setIsFileUploaded.bind(this);
    }

    render() {
        const actions = {
            setEmployeePairs: this.setEmployeePairs,
            setIsFileUploaded: this.setIsFileUploaded
        };

        return <>
            <div className="jumbotron">
                <h5>Pair of employees that have worked as a team for the longest time</h5>
                <i className="card-title">Upload a text file</i>
                <br />
                <FileUpload actions={actions} />
            </div>

            {
                this.state.IsFileUploaded
                    ? <EmployeesTable
                        data={this.state.employeePairs.length > 0
                            ? this.state.employeePairs :
                            []
                        }
                    />
                    : null
            }
        </>
    }
}

export default Admin;