$(document).ready(function () {
    document.addEventListener("reloadstart", e => {
        showLoader();
    });
    document.addEventListener("reloadend", e => {
        hideLoader();
    });
});

function showLoader() {
    let loaderWrap = $('.loader-wrapper');
    if (!loaderWrap.hasClass('loader-wrapper--active')) {
        loaderWrap.addClass('loader-wrapper--active');
    }
}

function hideLoader() {
    let loaderWrap = $('.loader-wrapper');
    if (loaderWrap.hasClass('loader-wrapper--active')) {
        loaderWrap.removeClass('loader-wrapper--active');
    }
}

$(document).ajaxStart(function () {
    showLoader();
    //$("#overlay").fadeIn(300);
})
$(document).ajaxComplete(function () {
    //$.validator.unobtrusive.parse(document);
    hideLoader();
    //$("#overlay").fadeOut(100);
});

$(document).ajaxError(function (event, jqXHR, ajaxSettings, thrownError) {

    hideLoader();
    var msg = "";
    var errorObj = JSON.parse(jqXHR.responseText);
    var isDevelopment = errorObj.isDevelopment;
    if (isDevelopment) {
        msg = errorObj.error;
    }
    else {
        if (jqXHR.status === 0) {
            msg = 'Not connect. Verify Network.';
        } else if (jqXHR.status == 404) {
            msg = 'Requested page not found. [404]';
        } else if (jqXHR.status == 500) {
            msg = 'Internal Server Error [500].';
        }
        else if (jqXHR.status == 401) {
            location.href = "/";
            return;
        }
        else if (textStatus === 'parsererror') {
            msg = 'Requested JSON parse failed.';
        } else if (textStatus === 'timeout') {
            msg = 'Time out error.';
        } else if (textStatus === 'abort') {
            msg = 'Ajax request aborted.';
        } else {
            try {
                msg = JSON.parse(jqXHR.responseText);
            }
            catch (ers) {
                msg = jqXHR.responseText;
            }
        }
    }

    Swal.fire({
        icon: 'error',
        title: 'Un expected error',
        text: msg
    })

});



function editCardItem(id, controller, action, modalId, updateDialogId) {
    //showLoader();
    var e = window.event;
    e.stopPropagation();
    e.preventDefault();
    var data = { id: id };
    common.getPartialViewModal('/' + controller + '/' + action, data, modalId, updateDialogId);
    //hideLoader();

}


function deleteDetail(controller, action, id, rowId) {

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
                url: "/" + controller + "/" + action + "?id=" + id,
                type: "Post",
                contentType: 'application/json; charset=utf-8',
                success: function (result) {
                    debugger;
                    if (result) {
                        $(this).closest('tr').remove();
                        $('#' + rowId).remove();
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


