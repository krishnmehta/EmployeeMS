$(function () {
    var l = abp.localization.getResource('EmployeeMS');

    var dataTable = $('#EmployeesTable').DataTable(
        abp.libs.datatables.normalizeConfiguration({
            serverSide: true,
            paging: true,
            order: [[1, "asc"]],
            searching: false,
            scrollX: true,
            ajax: abp.libs.datatables.createAjax(employeeMS.employees.employee.getList),
            columnDefs: [
                {
                    title: l('Name'),
                    data: "name"
                },
                {
                    title: l('Age'),
                    data: "age"
                    
                },
                {
                    title: l('Email'),
                    data: "email"
                },
                {
                    title: l('Salary'),
                    data: "salary"
                },
                {
                    title: l('CreationTime'), data: "creationTime",
                    render: function (data) {
                        return luxon
                            .DateTime
                            .fromISO(data, {
                                locale: abp.localization.currentCulture.name
                            }).toLocaleString(luxon.DateTime.DATETIME_SHORT);
                    }
                }
            ]
        })
    );
    var createModal = new abp.ModalManager(abp.appPath + 'Employees/CreateModal');

    createModal.onResult(function () {
        dataTable.ajax.reload();
    });

    $('#NewEmployeeButton').click(function (e) {
        e.preventDefault();
        createModal.open();
    });
});
