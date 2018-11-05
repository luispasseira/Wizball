// Humburger click.
document.getElementById("humburger").addEventListener("click", function () {

    document.getElementById("responsive-menu").classList.toggle("responsive-menu-open");

});




// Modal logout show.
// The logout desktop btn only exists if the user has login, because its a dynamically generated btn (a).
var desktoBtnLogout = document.getElementById("logout");
var desktoBtnLogoutt = document.getElementById("logoutt");
if (desktoBtnLogout !== null) {

    desktoBtnLogout.addEventListener("click", function () {
        document.getElementById("outter-modal").style.display = "block";
    });

    desktoBtnLogoutt.addEventListener("click", function () {
        document.getElementById("outter-modal").style.display = "block";
    });
}

// Modal logout close.
document.getElementById("btnModalCancel").addEventListener("click", function () {

    document.getElementById("outter-modal").style.display = "none";

});