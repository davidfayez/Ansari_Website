
$(document).on('click', '#btnSubmitTestiminieDetail', function () {
    $("#table_id").find(".dataTables_empty").parents('tbody').empty();

    var TitleEnDetail = $("#TitleEnDetail").val();
    var TitleArDetail = $("#TitleArDetail").val();
    var OrderDetail = $("#OrderDetail").val();
    var count = $('#table_id tr').length;
    var num = count;
    var file = $('#TestiminieImageDetail')[0].files[0]
    var files = $('#TestiminieImageDetail').prop("files");
    console.log(file)

    if (TitleEnDetail != "" && TitleArDetail != "") {
        $("#TitleEnDetailValidation").hide();
        $("#TitleArDetailValidation").hide();


        $("#TestiminieDiv").append(`<input type="hidden" name="TestiminieDetailVMs[` + (count - 1) + `].TitleEn"  value=` + TitleEnDetail + `>`);
        $("#TestiminieDiv").append(`<input type="hidden" name="TestiminieDetailVMs[` + (count - 1) + `].TitleAr"  value=` + TitleArDetail + `>`);
        $("#TestiminieDiv").append(`<input type="file" style="display:none" name="TestiminieDetailVMs[` + (count - 1) + `].TestiminieDetailImage"  id=image` + (count - 1) + `>`);
        let fileInputElement = document.getElementById('image' + (count - 1));
        fileInputElement.files = files;
        $("#table_id").append(`<tr><td>` + TitleEnDetail + `</td><td>` + TitleArDetail + `
                                   <td> 
                                       <button  type="button" class="btn btn-danger btn-sm" onclick="deleteCurrentRow(`+ (count) + `)"><i class="fas fa-times"></i></button></td>
                               </tr>`);

        $('#closeTestiminieDetail').click();

    }
    else {
        $("#TitleEnDetailValidation").show();
        $("#TitleArDetailValidation").show();
    }
})

function deleteCurrentRow(id) {
    debugger;
    swal({
        title: Resources.DeleteResource,
        text: Resources.DeleteConfirmResource,
        type: "info",
        showCancelButton: true,
        confirmButtonText: Resources.DeleteResource,
        cancelButtonText: Resources.CancelResource,
        closeOnConfirm: false,
        showLoaderOnConfirm: true
    }, function () {
        setTimeout(function () {
            $("#table_id tr:eq(" + id + ")").remove();
            swal({
                title: Resources.DeleteSuccessResource,
                confirmButtonText: Resources.DoneResource,
                type: "success"
            });
        }, 1000);
    });
}

function setImage(e) {
    debugger;
    var selectedFile = e.files[0];
    var reader = new FileReader();

    var imgtag = document.getElementById("testiminieImage");
    imgtag.title = selectedFile.name;

    reader.onload = function (Testiminie) {
        imgtag.src = Testiminie.target.result;
    };

    reader.readAsDataURL(selectedFile);
}

function setTestiminieDetailImage(e) {
    debugger;
    var selectedFile = e.files[0];
    var reader = new FileReader();

    var imgtag = document.getElementById("testiminieDetailImage");
    imgtag.title = selectedFile.name;

    reader.onload = function (Testiminie) {
        imgtag.src = Testiminie.target.result;
    };

    reader.readAsDataURL(selectedFile);
}