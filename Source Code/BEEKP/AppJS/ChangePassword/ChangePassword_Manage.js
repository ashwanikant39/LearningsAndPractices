jQuery(document).ready(function () {

    Metronic.init(); // init metronic core components
    ValidateChangePassword();

});
function encrypt(txtValue) {
    var key = CryptoJS.enc.Utf8.parse('8080808080808080');
    var iv = CryptoJS.enc.Utf8.parse('8080808080808080');
    var encryptedTxtValue = CryptoJS.AES.encrypt(CryptoJS.enc.Utf8.parse(txtValue), key,
        {
            keySize: 128 / 8,
            iv: iv,
            mode: CryptoJS.mode.CBC,
            padding: CryptoJS.pad.Pkcs7
        });
    return encryptedTxtValue;

}

function Encript() {
    if ($('#old_password').val() !== "") {

        var _old_password = $("#old_password").val();
        var _new_password = $("#new_password").val();
        var _confirm_password = $("#confirm_password").val();

        var old_password = encrypt(_old_password);
        var new_password = encrypt(_new_password);
        var confirm_password = encrypt(_confirm_password);

        $("#old_password").val(old_password+'@');
        $("#new_password").val(new_password+'@');
        $("#confirm_password").val(confirm_password+'@');
    }
}

function ValidateChangePassword() {

    $.validator.addMethod(
        "regex",
        function (value, element, regexp) {
            var re = new RegExp(regexp);
            return this.optional(element) || re.test(value);
        },
        "Invalid Password Policy"
);

    var RequiredMsg = "This field is required";

    jQuery.validator.addMethod("notEqual", function(value, element, param) {
    return this.optional(element) || value != $(param).val();
    }, "New password has to be different from old password");


    $('#frmChangePassword').validate({
        errorElement: 'span', //default input error message container
        errorClass: 'help-block', // default input error message class
        focusInvalid: false, // do not focus the last invalid input
        rules: {
            "ChangePassword.old_password": {
                required: true
            },
            "ChangePassword.new_password": {
                required: true,
                notEqual: "#old_password",
                regex: /^(?=.*[0-9])(?=.*[a-z])(?=.*[A-Z])(?=.*[@#$%])(?=.{6,})/
            },
            "ChangePassword.confirm_password": {
                required: true,
                equalTo: "#new_password"
            }
            
        },
        messages: {
            "ChangePassword.old_password": {
                required: RequiredMsg
            },
            "ChangePassword.new_password": {
                required: RequiredMsg
            },
            "ChangePassword.confirm_password": {
                required: RequiredMsg,
                equalTo: "Invalid Confirm Password"
            }
            
        },

        invalidHandler: function (event, validator) { //display error alert on form submit
            $('.alert-danger', $('#frmChangePassword')).show();
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
    $('#frmChangePassword input').keypress(function (e) {
        if (e.which == 13) {
            if ($('#frmChangePassword').validate().form()) {
                $('#frmChangePassword').submit();
            }
            return false;
        }
    });
}