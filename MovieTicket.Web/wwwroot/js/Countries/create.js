$(document).ready(function () {
    var output = document.getElementById('CountryPicturePreview');
    output.src = $("#PictureUrl").val();
})

$("#PictureUrl").on("change", function () {
    var output = document.getElementById('CountryPicturePreview');
    output.src = $(this).val();
})