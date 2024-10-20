$(document).ready(function () {
    var output = document.getElementById('ActorPicturePreview');
    output.src = $("#PictureUrl").val();
})

$("#PictureUrl").on("change", function () {
    var output = document.getElementById('ActorPicturePreview');
    output.src = $(this).val();
})