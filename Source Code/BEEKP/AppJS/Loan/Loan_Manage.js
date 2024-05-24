jQuery(document).ready(function () {

    Metronic.init(); // init metronic core components
    ValidateLoanSchemeManage();
    // TableAdvanced_EventImageActive();

    //if (jQuery().datepicker) {
    //    $('#dtEventDate').datetimepicker({
    //        format: 'DD/MM/YYYY hh:mm A'
    //    });
    //    //$('body').removeClass("modal-open"); // fix bug when inline picker is used in modal
    //}


    //$('#divPhasesDate').datetimepicker({
    //    format: 'dd/mm/yyyy hh:ii',
    //    autoclose: 1,
    //    todayBtn: 1
    //});

});




function ValidateLoanSchemeManage() {
    var RequiredMsg = "This field is required";

    $('#frmManageLoanScheme').validate({
        errorElement: 'span', //default input error message container
        errorClass: 'help-block', // default input error message class
        focusInvalid: false, // do not focus the last invalid input
        rules: {
            "LoanScheme.loan_scheme_name": {
                required: true
            },
            "LoanScheme.loan_scheme_short_description": {
                required: true
            },
            "LoanScheme.loan_scheme_details": {
                required: true
            }
        },
        messages: {
            "LoanScheme.loan_scheme_name": {
                required: RequiredMsg
            },
            "LoanScheme.loan_scheme_short_description": {
                required: RequiredMsg
            },
            "LoanScheme.loan_scheme_details": {
                required: RequiredMsg
            }
        },

        invalidHandler: function (phases, validator) { //display error alert on form submit   
            $('.alert-danger', $('#frmManageLoanScheme')).show();
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
    $('#frmManageLoanScheme input').keypress(function (e) {
        if (e.which == 13) {
            if ($('#frmManageLoanScheme').validate().form()) {
                $('#frmManageLoanScheme').submit();
            }
            return false;
        }
    });
}
