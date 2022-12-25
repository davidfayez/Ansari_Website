﻿
$("#btnSubmit").on('click', function () {
    var TitleEnDetail = $("#TitleEnDetail").val();
    var TitleArDetail = $("#TitleArDetail").val();
    var OrderDetail = $("#OrderDetail").val();
    var count = $('#table_id tr').length;
    var num = count;

    if (TitleEnDetail != "" && TitleArDetail != "") {
        $("#TitleEnDetailValidation").hide();
        $("#TitleArDetailValidation").hide();

        $("#table_id").find(".dataTables_empty").parents('tbody').empty();

        $("#OfferDiv").append(`<input type="hidden" name="OfferDetailVMs[` + (count - 2) + `].TitleEn"  value=` + TitleEnDetail + `>`);
        $("#OfferDiv").append(`<input type="hidden" name="OfferDetailVMs[` + (count - 2) + `].TitleAr"  value=` + TitleArDetail + `>`);
        $("#OfferDiv").append(`<input type="hidden" name="OfferDetailVMs[` + (count - 2) + `].Order"  value=` + OrderDetail + `>`);

        $("#table_id").append(`<tr><td>` + TitleEnDetail + `</td><td>` + TitleArDetail + `</td><td>` + OrderDetail + `</td>
                                   <td><button  type="button" data-bs-toggle="modal" data-bs-target="#EditModal" class="btn btn-warning btn-sm"><i class="fa-regular fa-pen-to-square"></i></button> 
                                       <button  type="button" class="btn btn-danger btn-sm" onclick="deleteCurrentRow(`+ (count - 1) +`)"><i class="fas fa-times"></i></button></td>
                               </tr>`);
        
    }
    else {
        $("#TitleEnDetailValidation").show();
        $("#TitleArDetailValidation").show();
    }

});


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

function deleteDetail(id) {

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
            $.ajax({
                url: "/Offer/DeleteDetail?id=" + id,
                type: "Post",
                contentType: 'application/json; charset=utf-8',
                success: function (result) {
                    debugger;
                    if (result) {
                        $(this).closest('tr').remove();
                        swal({
                            title: Resources.DeleteSuccessResource,
                            confirmButtonText: Resources.DoneResource,
                            type: "success"
                        });
                    }
                    else {
                        swal({
                            title: Resources.DeleteFailedResource,
                            confirmButtonText: Resources.DoneResource,
                            type: "error"
                        });
                    }
                },
                error: function (err, xqr, txt) { }
            });

        }, 3000);
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
