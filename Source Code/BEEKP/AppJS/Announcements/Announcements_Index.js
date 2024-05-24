$(document).ready(function () {
    Metronic.init();
    TableAdvanced_AnnouncementsInactive();
});


function TableAdvanced_AnnouncementsActive() {

    if (!jQuery().dataTable) {
        return;
    }

    var table = $("#tblAnnouncementsActive");

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
        "sAjaxSource": "/Admin/AdminAnnouncements/GetActiveRecord",
        "lengthMenu": [
            [5, 10, 15, 20], // value - change per page values here
            [5, 10, 15, 20] // display- change per page values here
        ],
        // set the initial value
        "pageLength": 5,
        "aoColumns": [

            { "mData": "announcements_title" },
            { "mData": "announcements_date" },
            { "mData": "announcements_short_description" },
            {
                "mData": "sAnnouncementsID",
                "render": function (sAnnouncementsID, type, full, meta) {
                    var html = ""
                    var isEdit = $("#PagePermission_role_edit").val();
                    var isDelete = $("#PagePermission_role_delete").val();
                    if (isEdit) {
                        html += '<a href="/Admin/AdminAnnouncements/AnnouncementsAddEdit?sAnnouncementsID=' + sAnnouncementsID + '" class="custom-edit-tooltip"><i class="fa fa-pencil"></i></a>'
                    }
                    if (isDelete) {
                        html += ' | <a href="/Admin/AdminAnnouncements/DeleteAnnouncements?sAnnouncementsID=' + sAnnouncementsID + '" class="custom-edit-tooltip"title="" data-toggle="confirmation" data-original-title="Are you sure ?"><i class="fa fa-trash-o"></i></a>'
                    }
                    return html;
                }
            },



        ]
    });


}
function TableAdvanced_AnnouncementsInactive() {

    if (!jQuery().dataTable) {
        return;
    }

    var table = $("#tblAnnouncementsInactive");

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
        "sAjaxSource": "/Admin/AdminAnnouncements/GetInActiveRecord",
        "lengthMenu": [
            [5, 10, 15, 20], // value - change per page values here
            [5, 10, 15, 20] // display- change per page values here
        ],
        // set the initial value
        "pageLength": 5,
        "aoColumns": [

            { "mData": "announcements_title" },
            { "mData": "announcements_date" },
            { "mData": "announcements_short_description" },
            {
                "mData": "sAnnouncementsID",
                "render": function (sAnnouncementsID, type, full, meta) {
                    var html = ""
                    var isEdit = $("#PagePermission_role_edit").val();
                    var isDelete = $("#PagePermission_role_delete").val();
                    if (isEdit) {
                        html += '<a href="/Admin/AdminAnnouncements/AnnouncementsAddEdit?sAnnouncementsID=' + sAnnouncementsID + '" class="custom-edit-tooltip"><i class="fa fa-pencil"></i></a>'
                    }
                    if (isDelete) {
                        html += ' | <a href="/Admin/AdminAnnouncements/DeleteAnnouncements?sAnnouncementsID=' + sAnnouncementsID + '" class="custom-edit-tooltip"title="" data-toggle="confirmation" data-original-title="Are you sure ?"><i class="fa fa-trash-o"></i></a>'
                    }
                    return html;
                }
            },



        ],
        "initComplete": function (settings, json) {
            TableAdvanced_AnnouncementsActive();
        }
    });


}