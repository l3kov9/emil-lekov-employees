import React from "react";
import MaterialTable from "material-table";
import { employeePairColumns, employeePairOptions } from '../../helpers/constants';
import { tableIcons } from '../../helpers/icons';

const EmployeesTable = (props) => {
    return (<MaterialTable
        title="Employees"
        data={props.data}
        columns={employeePairColumns}
        options={employeePairOptions}
        icons={tableIcons} />
    )
}

export default EmployeesTable;