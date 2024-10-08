$(document).ready(function () {
    var output = document.getElementById('CategoryPicturePreview');
    output.src = $("#PictureUrl").val();
})

$("#PictureUrl").on("change", function () {
    var output = document.getElementById('CategoryPicturePreview');
    output.src = $(this).val();
})