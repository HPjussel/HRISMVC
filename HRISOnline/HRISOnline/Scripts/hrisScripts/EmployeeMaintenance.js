var page = {
    getEmployeesUrl: "/Employee/GetEmployees",
    tblEmployeeId:"#tblEmployee"
}

$(document).ready(function () {
    $(page.tblEmployeeId).DataTable({ 

        "ajax": {
            "url": page.getEmployeesUrl,
            "type": "get", 
            "dataType": "json",
            "dataSrc": "",  
        },
        "columns": [
            {
                'data': null,
                'render': function () {
                    return '<a href="#" data-toggle="modal" data-target="#exampleModalCenter">Modify</a>';
                }
            },
            { 'data': 'FirstName' },
            { 'data': 'LastName' },
            { 'data': 'DepartmentId' },
            { 'data': 'UserName' },
        ],
        "contentType": "application/json",
        "initComplete": function () {

        }
    });
}); 