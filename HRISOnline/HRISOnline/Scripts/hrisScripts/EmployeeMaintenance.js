var page = {
    getEmployeesUrl: "/Employee/GetEmployees",
    tblEmployeeId:"#tblEmployee"
}

$(document).ready(function () {
    $(page.tblEmployeeId).DataTable({
        "ajax": {
            "url": page.getEmployeesUrl,
            "type": "Get"
        }
    });
});