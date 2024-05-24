jQuery(document).ready(function () {
    // initiate layout and plugins
    // Metronic.init(); // init metronic core components

    ValidateFAQCategoryAddEdit();

});




function ValidateFAQCategoryAddEdit() {
    var RequiredMsg = "This field is required"
    $('#frmManageFAQCategory').validate({
        errorElement: 'span', //default input error message container
        errorClass: 'help-block', // default input error message class
        focusInvalid: false, // do not focus the last invalid input
        rules: {
            "FAQCategory.category_name": {
                required: true
            },
            "FAQCategory.cluster_id": {
                required: true,
                min:1
            }
            
           
        },
        messages: {
            "FAQCategory.category_name": {
                required: RequiredMsg
            },
            "FAQCategory.cluster_id": {
                required: RequiredMsg,
                min:"Please select an option"

            }
            
            
        },

        invalidHandler: function (event, validator) { //display error alert on form submit   
            $('.alert-danger', $('#frmEventAddEdit')).show();
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
    $('#frmManageFAQCategory input').keypress(function (e) {
        if (e.which == 13) {
            if ($('#frmManageFAQCategory').validate().form()) {
                $('#frmManageFAQCategory').submit();
            }
            return false;
        }
    });
}