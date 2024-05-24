jQuery(document).ready(function () {
 
    Metronic.init(); // init metronic core components
    ValidateVideoAddEdit();
  
    function readURL(input) {

        if (input.files && input.files[0]) {

            //------------------ SIZE CHECK ----------------
            var file_size = input.files[0].size;
            if (file_size > 1048576) {
                $('#txtShowMessage').val('true');
                $('#txtMessageType').val('error');
                $('#txtMessageTitle').val('Error');
                $('#txtMessage').val('Invalid File Size, Maximum File Size 1MB !');
                Toastr();
                $("#VideoImage").attr("src", "/images/NoImage.png");
                return;
            }
            //------------------END SIZE CHECK ----------------

            var reader = new FileReader();

            reader.onload = function (e) {
                $('#VideoImage').attr('src', e.target.result);
            }

            reader.readAsDataURL(input.files[0]);
        }
        else {
            $("#VideoImage").attr("src", "/images/NoImage.png");
        }
    }

    $("#imagevideo").change(function () {
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

    $('.btn-file :file').on('fileselect', function (event, numFiles, label) {
        var input = $(this).parents('.input-group').find(':text'),
            log = numFiles > 1 ? numFiles + ' files selected' : label;

        if (input.length) {
            input.val(log);
        } else {
            if (log) alert(log);
        }

    });
});




function ValidateVideoAddEdit() {
    var RequiredMsg = "This field is required"
    $('#frmManageVideo').validate({
        errorElement: 'span', //default input error message container
        errorClass: 'help-block', // default input error message class
        focusInvalid: false, // do not focus the last invalid input
        rules: {
            "Video.video_url": {
                required: true,
                url:true
            },
            "Video.video_title": {
                required:true
            }
        },
        messages: {
            "Video.video_url": {
                required: RequiredMsg,
                url:"Invalid Url"
            },
            "Video.video_title": {
                required: RequiredMsg
            }
        },

        invalidHandler: function (event, validator) { //display error alert on form submit   
            $('.alert-danger', $('#frmManageVideo')).show();
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
    $('#frmManageVideo input').keypress(function (e) {
        if (e.which == 13) {
            if ($('#frmManageVideo').validate().form()) {
                $('#frmManageVideo').submit();
            }
            return false;
        }
    });
}