jQuery(document).ready(function () {

   
    ValidateResetPassword();

});




function ValidateResetPassword() {

    $.validator.addMethod(
        "regex",
        function (value, element, regexp) {
            var re = new RegExp(regexp);
            return this.optional(element) || re.test(value);
        },
        "Invalid Password Policy"
);

    var RequiredMsg = "This field is required";
    $('#frmResetPassword').validate({
        errorElement: 'span', //default input error message container
        errorClass: 'help-block', // default input error message class
        focusInvalid: false, // do not focus the last invalid input
        rules: {
            "email_id": {
                required: true,
                email: true
            },
            "OTP": {
                required: true
            },
            "password": {
                required: true
                ,
                regex: /^(?=.*[0-9])(?=.*[a-z])(?=.*[A-Z])(?=.*[@#$%])(?=.{6,})/
            },
            "confirm_password": {
                required: true,
                equalTo: "#txtpassword"
            }

        },
        messages: {
            "email_id": {
                required: RequiredMsg,
                email: "Invalid Email"
            },
            "OTP": {
                required: RequiredMsg
            },
            "password": {
                required: RequiredMsg
            },
            "confirm_password": {
                required: RequiredMsg,
                equalTo: "Invalid Confirm Password"
            }

        },

        invalidHandler: function (event, validator) { //display error alert on form submit
            $('.alert-danger', $('#frmResetPassword')).show();
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
    $('#frmResetPassword input').keypress(function (e) {
        if (e.which == 13) {
            if ($('#frmResetPassword').validate().form()) {
                $('#frmResetPassword').submit();
            }
            return false;
        }
    });
}