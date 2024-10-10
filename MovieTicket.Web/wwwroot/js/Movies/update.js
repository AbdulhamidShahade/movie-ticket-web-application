$(document).ready(function () {
    var output = document.getElementById("ImageUrlPreview");
    output.src = $("#PictureUrl").val();
});

$("#PictureUrl").on("input", function () {
    var imageUrl = $(this).val();
    $("#ImageUrlPreview").attr("src", imageUrl);
});