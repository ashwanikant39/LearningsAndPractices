jQuery(document).ready(function () {
   
    Metronic.init(); // init metronic core components
    ValidateAnnouncementsAddEdit();
   // TableAdvanced_EventImageActive();

    //if (jQuery().datepicker) {
    //    $('#dtEventDate').datetimepicker({
    //        format: 'DD/MM/YYYY hh:mm A'
    //    });
    //    //$('body').removeClass("modal-open"); // fix bug when inline picker is used in modal
    //}


    $('#divAnnouncementsDate').datetimepicker({
        format: 'dd/mm/yyyy hh:ii',
        autoclose: 1,
        todayBtn: 1
    });

});




function ValidateAnnouncementsAddEdit() {
    var RequiredMsg = "This field is required";

    $('#frmAnnouncementsAddEdit').validate({
        errorElement: 'span', //default input error message container
        errorClass: 'help-block', // default input error message class
        focusInvalid: false, // do not focus the last invalid input
        rules: {
            "Announcements.announcements_title": {
                required: true
            },
            "Announcements.announcements_date": {
               // required: true
            },
            "Announcemenst.announcements_short_description": {
                required: true
            },
            "Announcements.announcements_full_description": {
                required: true
            }
          
            //,
            //"EventImage": {
            //    required: true,
            //    minImageWidth: 500
            //}
        },
        messages: {
            "Announcements.announcements_title": {
                required: RequiredMsg
            },
            "Announcements.announcements_date": {
                required: RequiredMsg
            },
            "Announcements.announcements_short_description": {
                required: RequiredMsg
            },
        "Announcements.announcements_full_description": {
            required: RequiredMsg
        }
            //,
            //"EventImage": {
            //   required: RequiredMsg
            //}
        },

        invalidHandler: function (event, validator) { //display error alert on form submit   
            $('.alert-danger', $('#frmAnnouncementsAddEdit')).show();
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
    $('#frmAnnouncementsAddEdit input').keypress(function (e) {
        if (e.which == 13) {
            if ($('#frmAnnouncementsAddEdit').validate().form()) {
                $('#frmAnnouncementsAddEdit').submit();
            }
            return false;
        }
    });
}
