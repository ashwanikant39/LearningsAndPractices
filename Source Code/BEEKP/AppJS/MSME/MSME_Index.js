jQuery(document).ready(function () {
    $.fn.dataTable.ext.errMode = 'none';
    Metronic.init();
    BindMSMEInActiveDataTable();
});

var BindMSMEActiveDataTable = function (response) {

    $("#tblMSMEActive").DataTable({
        "ordering": false,
        "bServerSide": true,
        "bProcessing": true,
        "language": {
            "emptyTable": "No record found.",
            "processing":
                '<i class="fa fa-spinner fa-spin fa-3x fa-fw" style="color:#2a2b2b;"></i><span class="sr-only">Loading...</span> '
        },
        "sAjaxSource": "/Admin/AdminMSME/GetMSMEActiveRecord",
       
        "lengthMenu": [
            [5, 10, 15, 20], // value - change per page values here
            [5, 10, 15, 20] // display- change per page values here
        ],
        "pageLength": 5,
        "aoColumns": [

            { "mData": "type_unit" },
            { "mData": "sector_name" },
            { "mData": "cluster_name" },
            { "mData": "unit_name" },
            { "mData": "unit_address" },
            { "mData": "contact_name" },
            { "mData": "email_id" },
            {
                "mData": "WTA_conducted",
                "render": function (WTA_conducted, type, full, meta) {
                    if (WTA_conducted === true) {
                        return 'Conducted';
                    }
                    else
                        return '';
                }
            },
            {
                "mData": "DEA_conducted",
                "render": function (DEA_conducted, type, full, meta) {
                    if (DEA_conducted === true) {
                        return 'Conducted';
                    }
                    else
                        return '';
                }
            },
            {
                "mData": "sMSMEID",
                "render": function (sMSMEID, type, full, meta) {
                    var html = ""
                    var isEdit = $("#PagePermission_role_edit").val();
                    var isDelete = $("#PagePermission_role_delete").val();
                    if (isEdit) {
                        html += '<a href="/Admin/AdminMSME/ManageMSME?sMSMEID=' + sMSMEID+'" class="custom-edit-tooltip"><i class="fa fa-pencil"></i></a>'
                    }
                    if (isDelete) {
                        html += ' | <a href="/Admin/AdminMSME/DeleteMSME?sMSMEID=' + sMSMEID +'" class="custom-edit-tooltip"title="" data-toggle="confirmation" data-original-title="Are you sure ?"><i class="fa fa-trash-o"></i></a>'
                    }
                    return html;
                }
            },



        ]

    });
}

var BindMSMEInActiveDataTable = function (response) {

    $("#tblMSMEInactive").DataTable({
        "ordering": false,
        "bServerSide": true,
        "bProcessing": true,
        "language": {
            "emptyTable": "No record found.",
            "processing":
                '<i class="fa fa-spinner fa-spin fa-3x fa-fw" style="color:#2a2b2b;"></i><span class="sr-only">Loading...</span> '
        },
        "sAjaxSource": "/Admin/AdminMSME/GetMSMEInActiveRecord",
        "fnServerData": function (sSource, aoData, fnCallback) {

            $.ajax({

                type: "Get",
                data: aoData,
                url: sSource,
                success: fnCallback
            })

        },
        "lengthMenu": [
            [5, 10, 15, 20], // value - change per page values here
            [5, 10, 15, 20] // display- change per page values here
        ],
        "pageLength": 5,
        "aoColumns": [

            { "mData": "type_unit" },
            { "mData": "sector_name" },
            { "mData": "cluster_name" },
            { "mData": "unit_name" },
            { "mData": "unit_address" },
            { "mData": "contact_name" },
            { "mData": "email_id" },
            {
                "mData": "WTA_conducted",
                "render": function (WTA_conducted, type, full, meta) {
                    if (WTA_conducted === true) {
                        return 'Conducted';
                    }
                    else
                        return '';
                }
            },
            {
                "mData": "DEA_conducted",
                "render": function (DEA_conducted, type, full, meta) {
                    if (DEA_conducted === true) {
                        return 'Conducted';
                    }
                    else
                        return '';
                }
            },
            {
                "mData": "sMSMEID",
                "render": function (sMSMEID, type, full, meta) {
                    var html = ""
                    var isEdit = $("#PagePermission_role_edit").val();
                    var isDelete = $("#PagePermission_role_delete").val();
                    if (isEdit) {
                        html += '<a href="/Admin/AdminMSME/ManageMSME?sMSMEID=' + sMSMEID + '" class="custom-edit-tooltip"><i class="fa fa-pencil"></i></a>'
                    }
                    if (isDelete) {
                        html += ' | <a href="/Admin/AdminMSME/DeleteMSME?sMSMEID=' + sMSMEID + '" class="custom-edit-tooltip"title="" data-toggle="confirmation" data-original-title="Are you sure ?"><i class="fa fa-trash-o"></i></a>'
                    }
                    return html;
                }
            },



        ],
        "initComplete": function (settings, json) {
            BindMSMEActiveDataTable();
        }

    });
}
