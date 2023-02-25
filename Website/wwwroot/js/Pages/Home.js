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


function AddSurvey() {
    debugger;
    var Feedback = $("#Feedback").val();
    var Rate = $("#Rate").val();

    if (Feedback == "")
        $("#FeedbackValidation").show();
    else
        $("#FeedbackValidation").hide();

    if (Rate == "")
        $("#RateValidation").show();
    else
        $("#RateValidation").hide();

    var e = window.event;

    if (Feedback == "" || Rate == "") {
        e.stopPropagation();
        e.preventDefault();
    }
    else {
        var SurveyQuestionAnswerVMs = [];
        $('input[type=radio].questionAnswers:checked').each(function (index, item) {
            var obj = {
                QuestionId: $(item).attr("name"),
                AnswerId: $(item).attr("value")
            }
            SurveyQuestionAnswerVMs.push(obj);
        });

        var model = {
            Feedback: Feedback,
            Rate: Rate,
            SurveyQuestionAnswerVMs: SurveyQuestionAnswerVMs
        }
        $.ajax({
            url: "/Home/Survey",
            data: { command: model },
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

