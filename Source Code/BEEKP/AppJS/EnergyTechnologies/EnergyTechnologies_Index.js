jQuery(document).ready(function () {
    $.fn.dataTable.ext.errMode = 'none';
     Metronic.init();
    TableAdvanced_EnergyTechnologiesInactive();
});


function TableAdvanced_EnergyTechnologiesActive() {

    if (!jQuery().dataTable) {
        return;
    }

    var table = $("#tblListEnergyTechnologyActive");

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
        "sAjaxSource": "/Admin/AdminEnergyTechnologies/GetActiveRecord",
        "lengthMenu": [
            [5, 10, 15, 20], // value - change per page values here
            [5, 10, 15, 20] // display- change per page values here
        ],
        // set the initial value
        "pageLength": 5,
        "aoColumns": [

            { "mData": "category_measure_name" },
            { "mData": "EE_measure" },
            { "mData": "clusters" },
            {
                "mData": "sEE_technology_id",
                "render": function (sEE_technology_id, type, full, meta) {
                    var html = ""
                    var isEdit = $("#PagePermission_role_edit").val();
                    var isDelete = $("#PagePermission_role_delete").val();
                    if (isEdit) {
                        html += '<a href="/Admin/AdminEnergyTechnologies/ManageEnergyTechnologies?sEE_technology_id=' + sEE_technology_id + '" class="custom-edit-tooltip"><i class="fa fa-pencil"></i></a>'
                    }
                    if (isDelete) {
                        html += ' | <a href="/Admin/AdminEnergyTechnologies/DeleteEnergyTechnologies?sEE_technology_id=' + sEE_technology_id + '" class="custom-edit-tooltip"title="" data-toggle="confirmation" data-original-title="Are you sure ?"><i class="fa fa-trash-o"></i></a>'
                    }
                    return html;
                }
            },



        ]
    });


}
function TableAdvanced_EnergyTechnologiesInactive() {

    if (!jQuery().dataTable) {
        return;
    }

    var table = $("#tblListEnergyTechnologyInactive");

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
        "sAjaxSource": "/Admin/AdminEnergyTechnologies/GetInActiveRecord",
        "lengthMenu": [
            [5, 10, 15, 20], // value - change per page values here
            [5, 10, 15, 20] // display- change per page values here
        ],
        // set the initial value
        "pageLength": 5,
        "aoColumns": [

            { "mData": "category_measure_name" },
            { "mData": "EE_measure" },
            { "mData": "clusters" },
            {
                "mData": "sEE_technology_id",
                "render": function (sEE_technology_id, type, full, meta) {
                    var html = ""
                    var isEdit = $("#PagePermission_role_edit").val();
                    var isDelete = $("#PagePermission_role_delete").val();
                    if (isEdit) {
                        html += '<a href="/Admin/AdminEnergyTechnologies/ManageEnergyTechnologies?sEE_technology_id=' + sEE_technology_id + '" class="custom-edit-tooltip"><i class="fa fa-pencil"></i></a>'
                    }
                    if (isDelete) {
                        html += ' | <a href="/Admin/AdminEnergyTechnologies/DeleteEnergyTechnologies?sEE_technology_id=' + sEE_technology_id + '" class="custom-edit-tooltip"title="" data-toggle="confirmation" data-original-title="Are you sure ?"><i class="fa fa-trash-o"></i></a>'
                    }
                    return html;
                }
            },
        ],
        "initComplete": function (settings, json) {
            TableAdvanced_EnergyTechnologiesActive();
        }
    });


}