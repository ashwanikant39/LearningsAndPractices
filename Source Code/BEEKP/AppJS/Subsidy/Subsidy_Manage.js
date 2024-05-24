jQuery(document).ready(function () {

    Metronic.init(); // init metronic core components
    ValidateManageSubsidyScheme();
});

function ValidateManageSubsidyScheme() {
    var RequiredMsg = "This field is required";

    $('#frmManageSubsidyScheme').validate({
        errorElement: 'span', //default input error message container
        errorClass: 'help-block', // default input error message class
        focusInvalid: false, // do not focus the last invalid input
        rules: {
            "SubsidyScheme.subsidy_scheme_name": {
                required: true
            },
            "SubsidyScheme.subsidy_scheme_short_description": {
                required: true
            },
            "SubsidyScheme.subsidy_scheme_details": {
                required: true
            }
        },
        messages: {
            "SubsidyScheme.subsidy_scheme_name": {
                required: RequiredMsg
            },
            "SubsidyScheme.subsidy_scheme_short_description": {
                required: RequiredMsg
            },
            "SubsidyScheme.subsidy_scheme_details": {
                required: RequiredMsg
            }
        },

        invalidHandler: function (phases, validator) { //display error alert on form submit   
            $('.alert-danger', $('#frmManageSubsidyScheme')).show();
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
    $('#frmManageSubsidyScheme input').keypress(function (e) {
        if (e.which == 13) {
            if ($('#frmManageSubsidyScheme').validate().form()) {
                $('#frmManageSubsidyScheme').submit();
            }
            return false;
        }
    });
}
