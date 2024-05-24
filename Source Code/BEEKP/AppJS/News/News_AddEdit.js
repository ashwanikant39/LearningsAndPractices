jQuery(document).ready(function () {

    Metronic.init(); // init metronic core components
    ValidateNewsAddEdit();

   TableAdvanced_NewsImageActive();

    //if (jQuery().datepicker) {
    //    $('#dtEventDate').datetimepicker({
    //        format: 'DD/MM/YYYY hh:mm A'
    //    });
    //    //$('body').removeClass("modal-open"); // fix bug when inline picker is used in modal
    //}


    $('#divNewsDate').datetimepicker({
        format: 'dd/mm/yyyy hh:ii',
        autoclose: 1,
        todayBtn: 1
    });

    function readURL(input) {

        if (input.files && input.files[0]) {

            //------------------ SIZE CHECK ----------------
            var file_size = input.files[0].size;
            if (file_size > 10485760) {
                $('#txtShowMessage').val('true');
                $('#txtMessageType').val('error');
                $('#txtMessageTitle').val('Error');
                $('#txtMessage').val('Invalid File Size, Maximum File Size 10MB !');
                Toastr();
                $("#imgNewsImage").attr("src", "/images/NoImage.png");
                return;
            }
            //------------------END SIZE CHECK ----------------


            var reader = new FileReader();

            reader.onload = function (e) {
                $('#imgNewsImage').attr('src', e.target.result);
            }

            reader.readAsDataURL(input.files[0]);
        }
        else {
            $("#imgNewsImage").attr("src", "/images/NoImage.png");
        }
    }

    $("#fileNewsImage").change(function () {
        readURL(this);
    });

    //$('.form_datetime').datetimepicker({
    //    format: 'dd/mm/yyyy hh:mm',
    //    weekStart: 1,
    //    todayBtn:  1,
    //	autoclose: 1,
    //	todayHighlight: 1,
    //	startView: 2,
    //	forceParse: 0,
    //    showMeridian: 1
    //});

    $('.btn-file :file').change(
        function () {
            var input = $(this),
                numFiles = input.get(0).files ? input.get(0).files.length : 1,
                label = input.val().replace(/\\/g, '/').replace(/.*\//, '');
            input.trigger('fileselect', [numFiles, label]);
        });

    $('.btn-file :file').on('fileselect', function (news, numFiles, label) {
        var input = $(this).parents('.input-group').find(':text'),
            log = numFiles > 1 ? numFiles + ' files selected' : label;

        if (input.length) {
            input.val(log);
        } else {
            if (log) alert(log);
        }

    });
});




function ValidateNewsAddEdit() {
    var RequiredMsg = "This field is required";

    //$.validator.addMethod('imageDimentionCheck',
    //    function (value, element, minWidth) {
    //    return ($(element).data('imageWidth') || 0) > minWidth;
    //    },
    //    function (minWidth, element) {
    //        var imageWidth = $(element).data('imageWidth');
    //        return (imageWidth) ? ("Your image's width must be greater than " + minWidth + "px") : "Selected file is not an image.";
    //    }
    //);

    //var img = document.getElementById('imgEventImage');
    //$('#txtImageHeight').val(img.naturalHeight);
    //$('#txtImageWidth').val(img.naturalWidth);

    //$.validator.addMethod("nok", function (value, element) {
    //    return !/^\bnok\b$/.test(value);
    //}, 'Must not be nok!');

    //$.validator.addClassRules({
    //    nok: { nok: true }
    //});



    $('#frmNewsAddEdit').validate({
        errorElement: 'span', //default input error message container
        errorClass: 'help-block', // default input error message class
        focusInvalid: false, // do not focus the last invalid input
        rules: {
            "News.news_title": {
                required: true
            },
            "News.news_date": {
                required: true
            },
            "News.news_short_description": {
                required: true
            },
            "News.news_full_description": {
                required: true
            }

            //,
            //"EventImage": {
            //    required: true,
            //    minImageWidth: 500
            //}
        },
        messages: {
            "News.news_title": {
                required: RequiredMsg
            },
            "News.news_date": {
                required: RequiredMsg
            },
            "News.news_short_description": {
                required: RequiredMsg
            },
            "News.news_full_description": {
                required: RequiredMsg
            }

            //,
            //"EventImage": {
            //   required: RequiredMsg
            //}
        },

        invalidHandler: function (news, validator) { //display error alert on form submit   
            $('.alert-danger', $('#frmNewsAddEdit')).show();
        },

        highlight: function (element) { // hightlight error inputs
            $(element)
                .closest('.form-group').addClass('has-error'); // set error class to the control group
        },

        success: function (label) {
            label.closest('.form-group').removeClass('has-error');
            label.remove();
        },

        errorPlacement: function (error, element) { // render error placement for each input type
            if (element.parent(".input-group").size() > 0) {
                error.insertAfter(element.parent(".input-group"));
            } else if (element.attr("data-error-container")) {
                error.appendTo(element.attr("data-error-container"));
            } else {
                error.insertAfter(element);
            }
        },

        submitHandler: function (form) {
            form.submit();
        }
    });
    $('#frmNewsAddEdit input').keypress(function (e) {
        if (e.which == 13) {
            if ($('#frmNewsAddEdit').validate().form()) {
                $('#frmNewsAddEdit').submit();
            }
            return false;
        }
    });
}

function TableAdvanced_NewsImageActive() {

    if (!jQuery().dataTable) {
        return;
    }

    var table = $("#tblNewsImage");

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
            "targets": [2] //for the columns
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