// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

var but = document.getElementById("toggler");
var hid_div = document.getElementById("header");
var close_but = document.getElementById("close");
but.addEventListener("click", function () {
    hid_div.style.display = "none";

})
close_but.addEventListener("click", function () {
    hid_div.style.display = "block";

})
