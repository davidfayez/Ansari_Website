$("#btnSubmitAnswer").on('click', function (e) {
    debugger;
    //e.preventDefault();

    var NameAr = $("#NameAr").val();
    var NameEn = $("#NameEn").val();
    debugger
    if (NameAr != "" && NameEn != "") {
        $("#NameArValidation").hide();
        $("#NameEnValidation").hide();
        //$('#answerForm').submit();
    }
    else {
        $("#NameArValidation").show();
        $("#NameEnValidation").show();
        e.preventDefault();

    }

});
