$(document).ready(function () {
    var output = document.getElementById('ProducerPicturePreview');
    output.src = $("#PictureUrl").val();
})

$("#PictureUrl").on("change", function () {
    var output = document.getElementById('ProducerPicturePreview');
    output.src = $(this).val();
})