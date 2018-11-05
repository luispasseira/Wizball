document.getElementById("btnSubmit").blur();

document.getElementById("btnSubmit").addEventListener("click", function () {
    isFormValid();
});


function isFormValid() {

    if (isEmailReady()) {
        return true;
    }
    
    return false;
}



// VALIDATION ********************************************************************
function isEmailReady() {

    var result = true;

    var txtEmail = document.getElementById("txtEmail").value;
    var emailStatus = document.getElementById("emailStatus");

    var emailValidator = /^(([^<>()\[\]\.,;:\s@\"]+(\.[^<>()\[\]\.,;:\s@\"]+)*)|(\".+\"))@(([^<>()\.,;\s@\"]+\.{0,1})+[^<>()\.,;:\s@\"]{2,})$/;


    if (txtEmail.length === 0) {
        emailStatus.innerText = "Required";
        result = false;
    }
    else if (txtEmail.length > 100) {
        emailStatus.innerText = "Max length 100";
        result = false;
    }
    else if (!emailValidator.test(txtEmail)) {
        emailStatus.innerText = "Invalid email format";
        result = false;
    }
    else {
        emailStatus.innerText = "";
    }


    return result;
}


// MODAL *************************************************************************
function recoverPasswordConfirmation() {

    // Shows modal.
    var modal = document.getElementById('outterModal');
    modal.style.display = "block";

    // Get elements.
    var counter = document.getElementById("modal-counter");
    var currentValue = parseInt(counter.innerText);

    window.setTimeout(closeViewRecoverPassword, currentValue * 1000);

    window.setInterval(function () {
        counter.innerText = currentValue === 0 ? 0 : --currentValue;
    }, 1000);
}
function closeViewRecoverPassword() {
    window.location.replace("/Pages/ViewHome.aspx");
}
document.getElementById("modal-close").addEventListener("click", closeViewRecoverPassword);