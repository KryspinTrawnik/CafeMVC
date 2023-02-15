// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
$(document).ready(function () {
    $.ajax({
        url: "/Menu/DropDownMenus",
        type: "GET",
        success: function (result) {
            $("#dropDownMenu").html(result);
        }
    });
});
const dropdown = document.querySelector('.dropdown');

dropdown.addEventListener('mouseenter', () => {
    dropdown.classList.add('active');
});

dropdown.addEventListener('mouseleave', () => {
    dropdown.classList.remove('active');
});