

$('select[name = "DepartmentId"]').on('change', function () {
    var departmentId = $(this).val();
    debugger;

    if (departmentId) {
        $.ajax({
            url: "/Blog/GetAllDoctorsByDepartmentId?departmentId=" + departmentId,
            type: "GET",
            dataType: "json",
            success: function (data) {
                $('#DoctorId').prop('disabled', false)
                $('#DoctorId').empty();
                $('select[name = "DoctorId"]').append('<option selected value="">' + Resources.ChooseResource + '</option>');
                $.each(data, function (key, value) {

                    $('select[name = "DoctorId"]').append('<option value="' + value.id + '">' + value.fullName + '</option>');
                });
            }
        });
    } else {

        $('#DoctorId').prop('disabled', true);
        $('select[name = "DoctorId"]').empty();
        $('select[name = "DoctorId"]').append('<option value="">' + Resources.ChooseResource + '</option>');


    }
});


function setImage(e) {
    debugger;
    var selectedFile = e.files[0];
    var reader = new FileReader();

    var imgtag = document.getElementById("blogImage");
    imgtag.title = selectedFile.name;

    reader.onload = function (event) {
        imgtag.src = event.target.result;
    };

    reader.readAsDataURL(selectedFile);
}
