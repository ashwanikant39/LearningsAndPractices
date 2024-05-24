jQuery(document).ready(function () {

   
    ValidateFeedBackHome();

});




function ValidateFeedBackHome() {
    var RequiredMsg = "This field is required"
    $('#frmFeedbackHome').validate({
        errorElement: 'span', //default input error message container
        errorClass: 'help-block', // default input error message class
        focusInvalid: false, // do not focus the last invalid input
        rules: {
            "FeedBack.name_user": {
                required: true
                
            },
            "FeedBack.email_id": {
                required: true,
                email: true
            },
            "FeedBack.contact_no": {
                required: true
            },
            "FeedBack.feedback_message": {
                required: true
            }
           
        },
        messages: {
            "FeedBack.name_user": {
                required: RequiredMsg
            },
            "FeedBack.email_id": {
                required: RequiredMsg,
                email: "Invalid Email"
            },
            "FeedBack.contact_no": {
                required: RequiredMsg
            },
            "FeedBack.feedback_message": {
                required: RequiredMsg
            }
           
        },

        invalidHandler: function (event, validator) { //display error alert on form submit
            $('.alert-danger', $('#frmFeedbackHome')).show();
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
    $('#frmFeedbackHome input').keypress(function (e) {
        if (e.which == 13) {
            if ($('#frmFeedbackHome').validate().form()) {
                $('#frmFeedbackHome').submit();
            }
            return false;
        }
    });
}