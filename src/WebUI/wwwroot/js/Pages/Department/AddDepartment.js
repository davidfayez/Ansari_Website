$('select[name = "type"]').on('change', function () {
    var type = $(this).val();
    debugger;
    var data = { type: type };
    common.renderPartialView('/Department/Filter', data, 'departmentsList')
});


function setImage(e) {
    debugger;
    var selectedFile = e.files[0];
    var reader = new FileReader();

    var imgtag = document.getElementById("departmentImage");
    imgtag.title = selectedFile.name;

    reader.onload = function (event) {
        imgtag.src = event.target.result;
    };

    reader.readAsDataURL(selectedFile);
}
