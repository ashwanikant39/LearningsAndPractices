jQuery(document).ready(function () {
    $.fn.dataTable.ext.errMode = 'none';
    Metronic.init();
    
    TableAdvanced_ManufacturersInapproved();
});


function TableAdvanced_ManufacturersApproved() {

    if (!jQuery().dataTable) {
        return;
    }

    var table = $("#tblManufacturersApproved");

    var oTable = table.dataTable({
        "ordering": false,
        "bServerSide": true,
        "bProcessing": true,
        "sAjaxSource": "/Admin/Manufacturers/GetManufacturersActiveRecord",
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
        "lengthMenu": [
            [5, 10, 15, 20], // value - change per page values here
            [5, 10, 15, 20] // display- change per page values here
        ],
        // set the initial value
        "pageLength": 5,
        "aoColumns": [

            { "mData": "EE_equipment_name" },
            { "mData": "name_manufacturer" },
            { "mData": "contact_address" },
            { "mData": "contact_person" },
            { "mData": "contact_no" },
            { "mData": "email" },
            { "mData": "website" },
            { "mData": "approval_status_message" },
            {
                "mData": "smanufacturer_id",
                "render": function (smanufacturer_id, type, full, meta) {
                    var html = ""
                    var isEdit = $("#PagePermission_role_edit").val();
                    var isDelete = $("#PagePermission_role_delete").val();
                    if (isEdit) {
                        html += '<a href="/Admin/Manufacturers/ManageManufacturers?smanufacturer_id=' + smanufacturer_id + '" class="custom-edit-tooltip"><i class="fa fa-pencil"></i></a>'
                    }
                    if (isDelete) {
                        html += ' | <a href="/Admin/Manufacturers/DeleteManufacturers?smanufacturer_id=' + smanufacturer_id + '" class="custom-edit-tooltip"title="" data-toggle="confirmation" data-original-title="Are you sure ?"><i class="fa fa-trash-o"></i></a>'
                    }
                    return html;
                }
            },



        ]
    });


}
function TableAdvanced_ManufacturersInapproved() {

    if (!jQuery().dataTable) {
        return;
    }

    var table = $("#tblManufacturersInapproved");

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
        "sAjaxSource": "/Admin/Manufacturers/GetManufacturersInActiveRecord",
        "lengthMenu": [
            [5, 10, 15, 20], // value - change per page values here
            [5, 10, 15, 20] // display- change per page values here
        ],
        // set the initial value
        "pageLength": 5,
        "fnServerData": function (sSource1, aoData1, fnCallback1) {

            $.ajax({

                type: "Get",
                data: aoData1,
                url: sSource1,
                success: fnCallback1
            })

        },
        "aoColumns": [

            { "mData": "EE_equipment_name" },
            { "mData": "name_manufacturer" },
            { "mData": "contact_address" },
            { "mData": "contact_person" },
            { "mData": "contact_no" },
            { "mData": "email" },
            { "mData": "website" },
            { "mData": "approval_status_message" },
            {
                "mData": "smanufacturer_id",
                "render": function (smanufacturer_id, type, full, meta) {
                    var html = ""
                    var isEdit = $("#PagePermission_role_edit").val();
                    var isDelete = $("#PagePermission_role_delete").val();
                    if (isEdit) {
                        html += '<a href="/Admin/AdminMSME/ManageMSME?sMSMEID=' + smanufacturer_id + '" class="custom-edit-tooltip"><i class="fa fa-pencil"></i></a>'
                    }
                    if (isDelete) {
                        html += ' | <a href="/Admin/AdminMSME/DeleteMSME?sMSMEID=' + smanufacturer_id + '" class="custom-edit-tooltip"title="" data-toggle="confirmation" data-original-title="Are you sure ?"><i class="fa fa-trash-o"></i></a>'
                    }
                    return html;
                }
            },



        ],
        "initComplete": function (settings, json) {
            TableAdvanced_ManufacturersApproved();
        },
    });


}
function fnCallback1() {
    
}