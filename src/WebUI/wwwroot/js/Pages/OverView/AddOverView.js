
$(document).on('click', '#btnSubmitOverViewDetail', function () {
    $("#table_id").find(".dataTables_empty").parents('tbody').empty();

    var TitleEnDetail = $("#TitleEnDetail").val();
    var TitleArDetail = $("#TitleArDetail").val();
    var ValueDetail = $("#ValueDetail").val();
    var count = $('#table_id tr').length;
    debugger;
    if (TitleEnDetail != "" && TitleArDetail != "" && ValueDetail != "") {
        $("#TitleEnDetailValidation").hide();
        $("#TitleArDetailValidation").hide();


        $("#OverViewDiv").append(`<input type="hidden" name="OverViewDetailVMs[` + (count - 1) + `].TitleEn"  value="` + TitleEnDetail + `">`);
        $("#OverViewDiv").append(`<input type="hidden" name="OverViewDetailVMs[` + (count - 1) + `].TitleAr"  value="` + TitleArDetail + `">`);
        $("#OverViewDiv").append(`<input type="hidden" name="OverViewDetailVMs[` + (count - 1) + `].Value"  value="` + ValueDetail + `">`);

        $("#table_id").append(`<tr><td>` + TitleEnDetail + `</td><td>` + TitleArDetail + `</td><td>` + ValueDetail + `</td>
                                   <td> 
                                       <button  type="button" class="btn btn-danger btn-sm" onclick="deleteCurrentRow(`+ (count) + `)"><i class="fas fa-times"></i></button></td>
                               </tr>`);

        $('#closeOverViewDetail').click();

    }
    else {
        $("#TitleEnDetailValidation").show();
        $("#TitleArDetailValidation").show();
        $("#ValueDetailValidation").show();
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

    var imgtag = document.getElementById("overViewImage");
    imgtag.title = selectedFile.name;

    reader.onload = function (event) {
        imgtag.src = event.target.result;
    };

    reader.readAsDataURL(selectedFile);
}
