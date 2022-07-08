window.onscroll = function () { myFunction() };
var navbar = $(".wed-navbar")[0];
var sticky = navbar.offsetTop;

function myFunction() {
    if (window.pageYOffset >= sticky) {
        navbar.classList.add("sticky")
    } else {
        navbar.classList.remove("sticky");
    }
}