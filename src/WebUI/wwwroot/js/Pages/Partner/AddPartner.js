﻿
function setImage(e) {
    debugger;
    var selectedFile = e.files[0];
    var reader = new FileReader();

    var imgtag = document.getElementById("partnerImage");
    imgtag.title = selectedFile.name;

    reader.onload = function (event) {
        imgtag.src = event.target.result;
    };

    reader.readAsDataURL(selectedFile);
}
