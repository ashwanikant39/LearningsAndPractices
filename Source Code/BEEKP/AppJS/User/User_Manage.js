jQuery(document).ready(function () {

    Metronic.init(); // init metronic core components
    ValidateUser();


});




function ValidateUser() {
    $.validator.addMethod(
        "regex",
        function (value, element, regexp) {
            var re = new RegExp(regexp);
            return this.optional(element) || re.test(value);
        },
        "Invalid Password Policy"
);
    var RequiredMsg = "This field is required"
    $('#frmManageUser').validate({
        errorElement: 'span', //default input error message container
        errorClass: 'help-block', // default input error message class
        focusInvalid: false, // do not focus the last invalid input
        rules: {
            "User.state_id": {
                required: true,
                min: 1
            },
            "User.user_type_id": {
                required: true,
                min: 1
            },
            "User.first_name": {
                required: true
            },
            "User.last_name": {
                required: true
            },
            "User.password": {
                required: true,
                regex: /^(?=.*[0-9])(?=.*[a-z])(?=.*[A-Z])(?=.*[@#$%])(?=.{6,})/
            },
            "User.mobile": {
                required: true
            },
            "User.emailid": {
                required: true,
                email: true
            }

        },
        messages: {
            "User.state_id": {
                required: RequiredMsg,
                min: "Please select an option"
            },
            "User.user_type_id": {
                required: RequiredMsg,
                min: "Please select an option"
            },
            "User.first_name": {
                required: RequiredMsg
            },
            "User.last_name": {
                required: RequiredMsg
            },
            "User.password": {
                required: RequiredMsg
            },
            "User.mobile": {
                required: RequiredMsg
            },
            "User.emailid": {
                required: RequiredMsg,
                email: "Invalid Email"
            }
        },

        invalidHandler: function (event, validator) { //display error alert on form submit   
            $('.alert-danger', $('#frmManageUser')).show();
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
    $('#frmManageUser input').keypress(function (e) {
        if (e.which == 13) {
            if ($('#frmManageUser').validate().form()) {
                $('#frmManageUser').submit();
            }
            return false;
        }
    });
}