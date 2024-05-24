jQuery(document).ready(function () {
   
     Metronic.init(); // init metronic core components
    ValidateManufacturersAddEdit();


});




function ValidateManufacturersAddEdit() {
    var RequiredMsg = "This field is required"
    $('#frmManageManufacturers').validate({
        errorElement: 'span', //default input error message container
        errorClass: 'help-block', // default input error message class
        focusInvalid: false, // do not focus the last invalid input
        rules: {
            "Manufacturers.EE_equipment_id": {
                required: true,
                min:1
            },
            "Manufacturers.name_manufacturer": {
                required: true
            },
            "Manufacturers.contact_address": {
                required: true
            },
            "Manufacturers.contact_person": {
                required: true
            },
            "Manufacturers.contact_no": {
                required: true
            },
            "Manufacturers.email": {
                required: true,
                email:true
            }

        },
        messages: {
            "Manufacturers.EE_equipment_id": {
                required: RequiredMsg,
                min: "Please select an option"
            },
            "Manufacturers.name_manufacturer": {
                required: RequiredMsg
            },
            "Manufacturers.contact_address": {
                required: RequiredMsg
            },
            "Manufacturers.contact_person": {
                required: RequiredMsg
            },
            "Manufacturers.contact_no": {
                required: RequiredMsg
            },
            "Manufacturers.email": {
                required: RequiredMsg,
                email:"Invalid Email"
            }
        },

        invalidHandler: function (event, validator) { //display error alert on form submit   
            $('.alert-danger', $('#frmManageManufacturers')).show();
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
    $('#frmManageManufacturers input').keypress(function (e) {
        if (e.which == 13) {
            if ($('#frmManufacturersAddEdit').validate().form()) {
                $('#frmManufacturersAddEdit').submit();
            }
            return false;
        }
    });
}