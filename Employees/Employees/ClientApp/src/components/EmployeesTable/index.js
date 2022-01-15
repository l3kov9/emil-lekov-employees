import React from "react";
import MaterialTable from "material-table";
import { employeePairColumns, employeePairOptions } from '../../helpers/constants';
import { tableIcons } from '../../helpers/icons';
import { TablePagination } from '@material-ui/core';

const EmployeesTable = (props) => {
    return (<MaterialTable
        title="Pair of Employees"
        data={props.data}
        columns={employeePairColumns}
        options={employeePairOptions}
        icons={tableIcons}
        components={{
            Pagination: PatchedPagination,
        }} />
    )
}

function PatchedPagination(props) {
    const {
        ActionsComponent,
        onChangePage,
        onChangeRowsPerPage,
        ...tablePaginationProps
    } = props;

    return (
        <TablePagination
            {...tablePaginationProps}
            onPageChange={onChangePage}
            onRowsPerPageChange={onChangeRowsPerPage}
            ActionsComponent={(subprops) => {
                const { onPageChange, ...actionsComponentProps } = subprops;
                return (
                    <ActionsComponent
                        {...actionsComponentProps}
                        onChangePage={onPageChange}
                    />
                );
            }}
        />
    );
}

export default EmployeesTable;