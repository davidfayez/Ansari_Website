
$(document).on('click', '#btnSubmitOurValue', function () {
    $("#table_id").find(".dataTables_empty").parents('tbody').empty();

    var TitleEnDetail = $("#TitleEnDetail").val();
    var TitleArDetail = $("#TitleArDetail").val();
    var IconNameDetail = $("#IconNameDetail").val();
    var count = $('#table_id tr').length;
    var num = count;

    if (TitleEnDetail != "" && TitleArDetail != "") {
        $("#TitleEnDetailValidation").hide();
        $("#TitleArDetailValidation").hide();

        $("#AboutUsDiv").append(`<input type="hidden" name="OurValueVMs[` + (count - 1) + `].TitleEn"  value=` + TitleEnDetail + `>`);
        $("#AboutUsDiv").append(`<input type="hidden" name="OurValueVMs[` + (count - 1) + `].TitleAr"  value=` + TitleArDetail + `>`);
        $("#AboutUsDiv").append(`<input type="hidden" name="OurValueVMs[` + (count - 1) + `].IconName"  value=` + IconNameDetail + `>`);

        $("#table_id").append(`<tr><td>` + TitleEnDetail + `</td><td>` + TitleArDetail + `</td><td>` + IconNameDetail + `</td>
                                   <td> 
                                       <button  type="button" class="btn btn-danger btn-sm" onclick="deleteCurrentRow(`+ (count) + `)"><i class="fas fa-times"></i></button></td>
                               </tr>`);

        $('#closeOurValue').click();

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

    var imgtag = document.getElementById("aboutUsImage");
    imgtag.title = selectedFile.name;

    reader.onload = function (event) {
        imgtag.src = event.target.result;
    };

    reader.readAsDataURL(selectedFile);
}
