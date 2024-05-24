jQuery(document).ready(function () {


    Metronic.init();

    ValidateClusterDetailsAddEdit();

    $('.btn-file :file').change(
        function () {
            var input = $(this),
            numFiles = input.get(0).files ? input.get(0).files.length : 1,
            label = input.val().replace(/\\/g, '/').replace(/.*\//, '');
            input.trigger('fileselect', [numFiles, label]);
        });

    $('.btn-file :file').on('fileselect', function (event, numFiles, label) {
        var input = $(this).parents('.input-group').find(':text'),
            log = numFiles > 1 ? numFiles + ' files selected' : label;

        if (input.length) {
            input.val(log);
        } else {
            if (log) alert(log);
        }

    });

});




function ValidateClusterDetailsAddEdit() {
    var RequiredMsg = "This field is required"
    $('#frmClusterDetailsAddEdit').validate({
        errorElement: 'span', //default input error message container
        errorClass: 'help-block', // default input error message class
        focusInvalid: false, // do not focus the last invalid input
        rules: {
            "Cluster.cluster_name": {
                required: true
            },
            "Cluster.location": {
                required: true
            },
            "Cluster.phase_id": {
                required: true,
                min: 1
            }
            //"Cluster.products_manufactured": {
            //    required: true
            //},
            //"Cluster.number_of_units": {
            //    required: true
            //}
        },
        messages: {
            "Cluster.cluster_name": {
                required: RequiredMsg
            },
            "Cluster.location": {
                required: RequiredMsg
            },

            "Cluster.phase_id": {
                required: RequiredMsg,
                min: "Please select an option"
            }
            //"Cluster.products_manufactured": {
            //    required: RequiredMsg
            //},
            //"Cluster.number_of_units": {
            //    required: RequiredMsg
            //}
        },

        invalidHandler: function (event, validator) { //display error alert on form submit
            $('.alert-danger', $('#frmClusterDetailsAddEdit')).show();
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
    $('#frmClusterDetailsAddEdit input').keypress(function (e) {
        if (e.which == 13) {
            if ($('#frmClusterDetailsAddEdit').validate().form()) {
                $('#frmClusterDetailsAddEdit').submit();
            }
            return false;
        }
    });
}