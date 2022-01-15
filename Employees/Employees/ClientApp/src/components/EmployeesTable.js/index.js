import React from "react";
import MaterialTable from "material-table";
import {tableIcons} from './icons';

function EmployeesTable () {
    return <MaterialTable 
        icons={tableIcons}/>
}

export default EmployeesTable;