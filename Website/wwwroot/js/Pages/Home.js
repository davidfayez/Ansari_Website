function AddComplaint() {
    debugger;
    var ComplaintMessage = $("#ComplaintMessage").val();
    var PhoneNumber = $("#PhoneNumber").val();

    if (ComplaintMessage == "")
        $("#ComplaintMessageValidation").show();
    else
        $("#ComplaintMessageValidation").hide();

    if (PhoneNumber == "")
        $("#PhoneNumberValidation").show();
    else
        $("#PhoneNumberValidation").hide();

    var e = window.event;

    if (ComplaintMessage == "" || PhoneNumber == "") {
        e.stopPropagation();
        e.preventDefault();
    }
    else {
        var model = {
            complaintNo: 0,
            complaintMessage: ComplaintMessage,
            phoneNumber: PhoneNumber
            }
        $.ajax({
            url: "/Home/Complaint",
            data: {command : model},
            type: "POST",
            dataType: "json",
            success: function (data) {
                if (data) {
                    $('#close').click();
                    //location.reload(true);

                }
                else {
                }

            }
        });
        //$('#ComplaintForm').submit();
    }
}

