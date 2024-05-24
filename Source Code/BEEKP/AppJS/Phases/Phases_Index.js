jQuery(document).ready(function () {
    Metronic.init();
    TableAdvanced_PhasesActive();
    TableAdvanced_PhasesInactive();
});


function TableAdvanced_PhasesActive() {

    if (!jQuery().dataTable) {
        return;
    }

    var table = $("#tblPhasesActive");

    var oTable = table.dataTable({

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
        "columnDefs": [{
            "orderable": false, // false = sorting not applicale
            "targets": [3] //for the columns
        }],
        //"order": [
        //    [0, 'asc'] // default column sorting
        //],
        "lengthMenu": [
            [5, 10, 15, 20, -1], // value - change per page values here
            [5, 10, 15, 20, "All"] // display- change per page values here
        ],
        // set the initial value
        "pageLength": 5
    });


}
function TableAdvanced_PhasesInactive() {

    if (!jQuery().dataTable) {
        return;
    }

    var table = $("#tblPhasesInactive");

    var oTable = table.dataTable({

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
        "columnDefs": [{
            "orderable": false, // false = sorting not applicale
            "targets": [3] //for the columns
        }],
        //"order": [
        //    [0, 'asc'] // default column sorting
        //],
        "lengthMenu": [
            [5, 10, 15, 20, -1], // value - change per page values here
            [5, 10, 15, 20, "All"] // display- change per page values here
        ],
        // set the initial value
        "pageLength": 5
    });


}