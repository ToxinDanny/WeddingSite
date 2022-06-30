

var validationOpts = {
    errorPlacement: function(error, element) {
        let barSelector = $(`#${element[0].id}`).siblings()[1];
        error.css({
            "font-size": "10px", 
            "color": "red"
        });
        error.insertAfter(barSelector);
    }
};

$(document).ready(function() {
    $("#invitationForm").validate(validationOpts);
});