$(document).ready(function () {
    Metronic.init();
    $.fn.dataTable.ext.errMode = 'none';
    TableAdvanced_EnergyProfessionals_Inactive()
});


function TableAdvanced_EnergyProfessionals_Active() {

    if (!jQuery().dataTable) {
        return;
    }

    var table = $('#tblEnergyProfessionalsActive');

    var oTable = table.dataTable({
        "ordering": false,
        "bServerSide": true,
        "bProcessing": true,
        "language": {
            "aria": {
                "sortAscending": ": activate to sort column ascending",
                "sortDescending": ": activate to sort column descending"
            },
            "emptyTable": "No data available in table",
            "info": "Showing _START_ to _END_ of _TOTAL_ entries",
            "infoEmpty": "No entries found",
            "infoFiltered": "(filtered1 from _MAX_ total entries)",
            "lengthMenu": "Show _MENU_ entries",
            "search": "Search:",
            "zeroRecords": "No matching records found"
        },
        "sAjaxSource": "/Admin/EnergyProfessionals/GetEnergyProfessionalsActiveRecord",
        "lengthMenu": [
            [5, 10, 15, 20], // value - change per page values here
            [5, 10, 15, 20] // display- change per page values here
        ],
        // set the initial value
        "pageLength": 5,
        "aoColumns": [

            { "mData": "name" },
            { "mData": "organization_address" },
            { "mData": "email_id" },
            { "mData": "area_specialization_name" },
            { "mData": "approval_status_message" },
            {
                "mData": "senergy_professional_id",
                "render": function (senergy_professional_id, type, full, meta) {
                    var html = ""
                    var isEdit = $("#PagePermission_role_edit").val();
                    var isDelete = $("#PagePermission_role_delete").val();
                    if (isEdit) {
                        html += '<a href="/Admin/EnergyProfessionals/ManageEnergyProfessional?senergy_professional_id=' + senergy_professional_id + '" class="custom-edit-tooltip"><i class="fa fa-pencil"></i></a>'
                    }
                    if (isDelete) {
                        html += ' | <a href="/Admin/EnergyProfessionals/DeleteEnergyProfessional?senergy_professional_id=' + senergy_professional_id + '" class="custom-edit-tooltip"title="" data-toggle="confirmation" data-original-title="Are you sure ?"><i class="fa fa-trash-o"></i></a>'
                    }
                    return html;
                }
            },



        ],
    });


}
function TableAdvanced_EnergyProfessionals_Inactive() {

    if (!jQuery().dataTable) {
        return;
    }

    var table = $('#tblEnergyProfessionalsInactive');

    var oTable = table.dataTable({
        "ordering": false,
        "bServerSide": true,
        "bProcessing": true,
        "language": {
            "aria": {
                "sortAscending": ": activate to sort column ascending",
                "sortDescending": ": activate to sort column descending"
            },
            "emptyTable": "No data available in table",
            "info": "Showing _START_ to _END_ of _TOTAL_ entries",
            "infoEmpty": "No entries found",
            "infoFiltered": "(filtered1 from _MAX_ total entries)",
            "lengthMenu": "Show _MENU_ entries",
            "search": "Search:",
            "zeroRecords": "No matching records found"
        },
        "sAjaxSource": "/Admin/EnergyProfessionals/GetEnergyProfessionalsInActiveRecord",
        "lengthMenu": [
            [5, 10, 15, 20], // value - change per page values here
            [5, 10, 15, 20] // display- change per page values here
        ],
        // set the initial value
        "pageLength": 5,
        "aoColumns": [

            { "mData": "name" },
            { "mData": "organization_address" },
            { "mData": "email_id" },
            { "mData": "area_specialization_name" },
            { "mData": "approval_status_message" },
            {
                "mData": "senergy_professional_id",
                "render": function (senergy_professional_id, type, full, meta) {
                    var html = ""
                    var isEdit = $("#PagePermission_role_edit").val();
                    var isDelete = $("#PagePermission_role_delete").val();
                    if (isEdit) {
                        html += '<a href="/Admin/EnergyProfessionals/ManageEnergyProfessional?senergy_professional_id=' + senergy_professional_id + '" class="custom-edit-tooltip"><i class="fa fa-pencil"></i></a>'
                    }
                    if (isDelete) {
                        html += ' | <a href="/Admin/EnergyProfessionals/DeleteEnergyProfessional?senergy_professional_id=' + senergy_professional_id + '" class="custom-edit-tooltip"title="" data-toggle="confirmation" data-original-title="Are you sure ?"><i class="fa fa-trash-o"></i></a>'
                    }
                    return html;
                }
            },



        ],
        "initComplete": function (settings, json) {
            TableAdvanced_EnergyProfessionals_Active();
        }
    });


}