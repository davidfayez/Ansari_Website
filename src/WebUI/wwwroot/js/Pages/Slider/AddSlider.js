function setImage(e) {
    debugger;
    var selectedFile = e.files[0];
    var reader = new FileReader();

    var imgtag = document.getElementById("sliderImage");
    imgtag.title = selectedFile.name;

    reader.onload = function (Testiminie) {
        imgtag.src = Testiminie.target.result;
    };

    reader.readAsDataURL(selectedFile);
}
