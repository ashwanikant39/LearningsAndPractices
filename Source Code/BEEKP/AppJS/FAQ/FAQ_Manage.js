jQuery(document).ready(function () {
    // initiate layout and plugins
    // Metronic.init(); // init metronic core components

    ValidateFAQAddEdit();

    
});




function ValidateFAQAddEdit() {
    var RequiredMsg = "This field is required"
    $('#frmManageFAQ').validate({
        errorElement: 'span', //default input error message container
        errorClass: 'help-block', // default input error message class
        focusInvalid: false, // do not focus the last invalid input
        rules: {
            "FAQ.FAQ_question": {
                required: true
            },
            "FAQ.FAQ_answer": {
                required: true
            },
            "FAQ.cluster_name": {
                required: true
            },
            "FAQ.cluster_id": {
                required: true,
                min:1
            },
            "FAQ.category_name": {
                required: true
            },
            "FAQ.category_id": {
                required: true,
                min:1
            },
            "FAQ.approved_FAQ_answer": {
                required: true
            },
            "FAQ.remarks": {
                required: true
            },
             "FAQ.approved_FAQ_question": {
        required: true
    }

        },
        messages: {
            "FAQ.FAQ_question": {
                required: RequiredMsg
            },
            "FAQ.FAQ_answer": {
                required: RequiredMsg
            },
            "FAQ.cluster_name": {
                required: RequiredMsg
            },
            "FAQ.cluster_id": {
                required: RequiredMsg,
                min:"Please select an option"

            },
            "FAQ.category_name": {
                required: RequiredMsg
            },
            "FAQ.category_id": {
                required: RequiredMsg,
                min: "Please select an option"

            },
            "FAQ.approved_FAQ_answer": {
                required: RequiredMsg
            },
            "FAQ.approved_FAQ_question": {
                required: RequiredMsg
            },
        },

        invalidHandler: function (event, validator) { //display error alert on form submit   
            $('.alert-danger', $('#frmManageFAQ')).show();
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
    $('#frmManageFAQ input').keypress(function (e) {
        if (e.which == 13) {
            if ($('#frmManageFAQ').validate().form()) {
                $('#frmManageFAQ').submit();
            }
            return false;
        }
    });
}