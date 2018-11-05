function IsFormValid() {

    var usernameStatus  = document.getElementById("usernameStatus");
    var txtUsername     = document.getElementById("txtUsername").value;
    
    var passwordStatus  = document.getElementById("passwordStatus");
    var txtPassword     = document.getElementById("txtPassword").value;


    var result = true;

    if (txtUsername.length === 0) {
        usernameStatus.innerText = "Required";
        result = false;
    }
    else if (txtUsername.length > 50) {
        usernameStatus.innerText = "Max length 50";
        result = false;
    }
    else {
        usernameStatus.innerText = "";
    }

    if (txtPassword.length === 0) {
        passwordStatus.innerText = "Required";
        result = false;
    }
    else if (txtPassword.length < 6) {
        passwordStatus.innerText = "Min length 6";
        result = false;
    }
    else if (txtPassword.length > 100) {
        passwordStatus.innerText = "Max length 100";
        result = false;
    }
    else {
        passwordStatus.innerText = "";
    }


    return result;
}