jQuery(document).ready(function () {
    // initiate layout and plugins
    // Metronic.init(); // init metronic core components

    ValidateEventAddEdit();


});




function ValidateEventAddEdit() {
    var RequiredMsg = "This field is required"
    $('#frmManageDiscussionForum').validate({
        errorElement: 'span', //default input error message container
        errorClass: 'help-block', // default input error message class
        focusInvalid: false, // do not focus the last invalid input
        rules: {
            "DiscussionForum.forum_topic": {
                required: true
            },
            "DiscussionForum.forum_description": {
                required: true
            },
            "DiscussionForum.cluster_name": {
                required: true
            },
            "DiscussionForum.cluster_id": {
                required: true,
                min: 1
            },
            //"DiscussionForum.approved_forum_topic": {
            //    required: true
            //},
            //"DiscussionForum.remarks": {
            //    required: true
            //},
            //"DiscussionForum.approved_forum_description": {
            //    required: true
            //}

        },
        messages: {
            "DiscussionForum.forum_topic": {
                required: RequiredMsg
            },
            "DiscussionForum.forum_description": {
                required: RequiredMsg
            },
            "DiscussionForum.cluster_name": {
                required: RequiredMsg
            },
            "DiscussionForum.cluster_id": {
                required: RequiredMsg,
                min: "Please select an option"
            },
            //"DiscussionForum.approved_forum_topic": {
            //    required: RequiredMsg
            //},
            //"DiscussionForum.approved_forum_description": {
            //    required: RequiredMsg
            //},
            //"DiscussionForum.remarks": {
            //    required: RequiredMsg
            //},
        },

        invalidHandler: function (event, validator) { //display error alert on form submit   
            $('.alert-danger', $('#frmManageDiscussionForum')).show();
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
    $('#frmManageDiscussionForum input').keypress(function (e) {
        if (e.which == 13) {
            if ($('#frmManageDiscussionForum').validate().form()) {
                $('#frmManageDiscussionForum').submit();
            }
            return false;
        }
    });
}