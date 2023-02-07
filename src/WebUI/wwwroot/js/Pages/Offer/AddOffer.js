
$(document).on('click', '#btnSubmitOfferDetail', function () {
    $("#table_id").find(".dataTables_empty").parents('tbody').empty();

    var TitleEnDetail = $("#TitleEnDetail").val();
    var TitleArDetail = $("#TitleArDetail").val();
    var OrderDetail = $("#OrderDetail").val();
    var count = $('#table_id tr').length;
    var num = count;
    debugger;
    if (TitleEnDetail != "" && TitleArDetail != "") {
        $("#TitleEnDetailValidation").hide();
        $("#TitleArDetailValidation").hide();

        $("#OfferDiv").append(`<input type="hidden" name="OfferDetailVMs[` + (count - 1) + `].TitleEn"  value="` + TitleEnDetail + `">`);
        $("#OfferDiv").append(`<input type="hidden" name="OfferDetailVMs[` + (count - 1) + `].TitleAr"  value="` + TitleArDetail + `">`);
        $("#OfferDiv").append(`<input type="hidden" name="OfferDetailVMs[` + (count - 1) + `].Order"  value="` + OrderDetail + `">`);

        $("#table_id").append(`<tr><td>` + TitleEnDetail + `</td><td>` + TitleArDetail + `</td><td>` + OrderDetail + `</td>
                                   <td> 
                                       <button  type="button" class="btn btn-danger btn-sm" onclick="deleteCurrentRow(`+ (count) + `)"><i class="fas fa-times"></i></button></td>
                               </tr>`);

        $('#closeOfferDetail').click();

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

    var imgtag = document.getElementById("offerImage");
    imgtag.title = selectedFile.name;

    reader.onload = function (event) {
        imgtag.src = event.target.result;
    };

    reader.readAsDataURL(selectedFile);
}
