
//HTML ELEMENTS
var newsletter_subject = $('#input_newsletter_subject');
var newsletter_body = $('#txt_newsletter_body');

//VARS


//ARRAYS


//FUNCTIONS
//resets all newsletter fields.
function resetFields() {
    newsletter_title.val("");
    newsletter_body.val("");
}

//validates the newsletter.
function validateNewsletter() {
    var validated = true;
    $(".has-error").removeClass("has-error");

    if (newsletter_body.val() === "") {
        newsletter_body.closest(".form-group").addClass("has-error");
        error.fadeIn();
        error.find('.message').text("Please fill in the body field.");
        validated = false;
    }
    if (newsletter_body.val().length > 1200) {
        newsletter_body.closest(".form-group").addClass("has-error");
        error.fadeIn();
        error.find('.message').text("The body must be less than 1200 characters.");
        validated = false;
    }

    if (newsletter_subject.val() === "") {
        newsletter_subject.closest(".form-group").addClass("has-error");
        error.fadeIn();
        error.find('.message').text("Please fill in the subject field.");
        validated = false;
    }
    if (newsletter_subject.val().length > 60) {
        newsletter_subject.closest(".form-group").addClass("has-error");
        error.fadeIn();
        error.find('.message').text("The subject must be less than 60 characters.");
        validated = false;
    }



    if (validated) {
        error.hide();
        error.find('.message').text("");
    } else {
        error.fadeIn();
        $("html, body").animate({ scrollTop: 0 }, "slow");
    }

    return validated;
}

//send newsletter and alert if it was sent.
function sendNewsletter(subject, body) {
    $.ajax({
        type: "POST",
        contentType: "application/json; charset=utf-8",
        url: "../WebService.asmx/SendNewsletter",
        data: "{subject: " + JSON.stringify(subject) + ", body: " + JSON.stringify(body) + "}",
        dataType: "json",
        success: function (data) {
            if (data.d) {
                $(".se-pre-con").fadeOut();
                swal({
                    title: "Success!",
                    text: "Newsletter successfully sent!",
                    icon: "success",
                    timer: 3000
                }).then((value) => {
                    resetFields();
                });
            } else {
                $(".se-pre-con").fadeOut();
                swal({
                    title: "Error!",
                    text: "Sorry, we are currently unable to fulfill your request!",
                    icon: "warning",
                    timer: 3000
                });
            }
        },
        error: function () {
            $(".se-pre-con").fadeOut();
            swal({
                title: "Error!",
                text: "Sorry, we are currently unable to fulfill your request!",
                icon: "warning",
                timer: 3000
            });
        }
    });
}

//checks if the newslatter is valid.
function confirmAndSubmit() {
    if (!validateNewsletter()) {
        return;
    }
    swal({
        title: "Are you sure?",
        text: "This newsletter will be sent to all subscribed users.",
        icon: "info",
        buttons: true,
        closeModal: false
    }).then((willDelete) => {
        if (willDelete) {
            $(".se-pre-con").fadeIn();
            sendNewsletter(newsletter_subject.val(), newsletter_body.val());
        } else {
            swal({
                title: "Cancelled!",
                text: "",
                icon: "info",
                timer: 1000
            });
        }
    });
}



//CALLS



//EVENTS
$('#reset_newsletter').click(function () {
    resetFields();
});

$('#send_newsletter').click(function () {
    confirmAndSubmit();
});


console.log('READY newsletter.js');