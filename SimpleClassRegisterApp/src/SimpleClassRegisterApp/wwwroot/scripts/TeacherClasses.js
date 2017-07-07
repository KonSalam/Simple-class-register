
$(document).ready(function () {

    $(document).on('click', '.to-choose', function (evt) {
        evt.preventDefault(); 
        var identification = $(this).text().trim();

        $.ajax({
            url: "/TeacherClasses/Classes",
            type: 'POST',
            dataType: "json",
            data: JSON.stringify(identification),
            contentType: 'application/json',
            success: function (data) {
                window.location.href = data;
            }
        });
    });

});