export const employeePairColumns = [
    {
        title: "Employee Id #1",
        field: "firstEmployeeId"
    },
    {
        title: "Employee Id #2",
        field: "secondEmployeeId",
    },
    {
        title: "Project Id",
        field: "projectId"
    },
    {
        title: "Days Worked",
        field: "daysWorked",
    },
]

export const employeePairOptions = {
    search: true,
    paging: true,
    grouping: true,
    pageSize: 5,
    emptyRowsWhenPaging: false,
    filtering: false,
    pageSizeOptions: [5, 10, 25, 50],
    headerStyle: {
        "fontWeight": "bold"
    },
    filterCellStyle: {
        "textAlign": "center"
    }
};
