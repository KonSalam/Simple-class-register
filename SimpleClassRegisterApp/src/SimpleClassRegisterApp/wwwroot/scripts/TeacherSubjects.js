
$(document).ready(function () {

    $(document).on('click', '.to-choose', function (evt) {
        evt.preventDefault();
        var subjectName = $(this).text().trim();

        $.ajax({
            url: "/Teacher/Subjects",
            type: 'POST',
            dataType: "json",
            data: JSON.stringify(subjectName),
            contentType: 'application/json',
            success: function (data) {
                window.location.href = data;
            }
        });
    });
});