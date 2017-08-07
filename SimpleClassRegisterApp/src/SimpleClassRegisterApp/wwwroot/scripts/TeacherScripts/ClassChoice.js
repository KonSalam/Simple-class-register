$(document).ready(function () {

    $("#class_list").change(function () {

        $.ajax({
            url: "/Teacher/AvailableSubjectsForClass",
            type: 'POST',
            dataType: "json",
            data: JSON.stringify($('#class_list').val()),
            contentType: 'application/json',
            success: function (response) {
                var $el = $("#subject_list");
                $el.empty();

                $.each(response, function (i, item) {
                    $el.append($('<option>', {
                        value: item.subjectID,
                        text: item.name
                    }));
                });
            }
        });
    });

    $("#submit").click(function () {

        $.ajax({
            url: "/Teacher/Marks",
            type: 'POST',
            dataType: "html",
            data: { classId: $('#class_list').val(), subjectId: $('#subject_list').val() },
            success: function (response) {
                $("#student_list").html(response);
            }
        });

    });

    $(document).on('click', '.addMark', function (evt) {
        console.log($(this).attr('id'))

        $.ajax({
            url: "/Teacher/AddMarkShowModal",
            type: 'POST',
            dataType: "html",
            data: { subjectCardId: $(this).attr('id') },
            success: function (response) {
                $("#addMarkModal").html(response);
                $('#myModal').modal('show');
            }
        });
    });

});