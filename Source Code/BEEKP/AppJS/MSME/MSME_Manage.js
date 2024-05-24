jQuery(document).ready(function () {

    // init metronic core components
    ValidateMSMEAddEdit();

});




function ValidateMSMEAddEdit() {
    var RequiredMsg = "This field is required"
    $('#frmManageMSME').validate({
        errorElement: 'span', //default input error message container
        errorClass: 'help-block', // default input error message class
        focusInvalid: false, // do not focus the last invalid input
        rules: {
            "MSME.cluster_id": {
                required: true,
                min: 1
            },
            "MSME.sector_id": {
                required: true,
                min: 1
            }
            // "MSME.email_id": {
                // required: true
            // }
        },
        messages: {
            "MSME.cluster_id": {
                required: RequiredMsg,
                min: "Please select an option"
            },
            "MSME.sector_id": {
                required: RequiredMsg,
                min: "Please select an option"
            }
            // "MSME.email_id": {
                // required: RequiredMsg
            // }

        },

        invalidHandler: function (event, validator) { //display error alert on form submit
            $('.alert-danger', $('#frmManageMSME')).show();
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
    $('#frmManageMSME input').keypress(function (e) {
        if (e.which == 13) {
            if ($('#frmManageMSME').validate().form()) {
                $('#frmManageMSME').submit();
            }
            return false;
        }
    });
}