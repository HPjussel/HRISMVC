var page = {
    getEmployeesUrl: "/Employee/GetEmployees",
    tblEmployeeId:"#tblEmployee"
}

$(document).ready(function () {
    $(page.tblEmployeeId).DataTable({
        "ajax": {
            "url": page.getEmployeesUrl,
            "type": "Post", 
            columns: [
                { 'data': 'Id' },
                { 'data': 'FirstName' },
                { 'data': 'LastName' },
                { 'data': 'DepartmentId' },
                { 'data': 'UserName' }, 
            ]
        },
        "contentType":"application/json", 
    });
}); 