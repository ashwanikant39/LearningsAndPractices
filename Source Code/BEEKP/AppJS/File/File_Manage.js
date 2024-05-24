jQuery(document).ready(function () {
   
    Metronic.init(); // init metronic core components
    ValidateFileManage();
});

function ValidateFileManage() {
    var RequiredMsg = "This field is required"
    $('#frmManage').validate({
        errorElement: 'span', //default input error message container
        errorClass: 'help-block', // default input error message class
        focusInvalid: false, // do not focus the last invalid input
        rules: {
            "File.view": {
                required: true
            },
            "File.controller": {
                required: true
            }
        },
        messages: {
            "File.view": {
                required: RequiredMsg
            },
            "File.controller": {
                required: RequiredMsg
            }
        },
        invalidHandler: function (event, validator) { //display error alert on form submit   
            $('.alert-danger', $('#frmManage')).show();
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

    $('#frmManage input').keypress(function (e) {
        if (e.which == 13) {
            if ($('#frmManage').validate().form()) {
                $('#frmManage').submit();
            }
            return false;
        }
    });
}