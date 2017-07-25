$(document).ready(function () {

    $(document).on('click', '.to-choose', function (evt) {
        evt.preventDefault(); 
        var studentClasses = $(this).text().trim();

        $.ajax({
            url: "/StudentClasses/Index",
            type: 'POST',
            dataType: "json",
            data: JSON.stringify(studentClasses),
            contentType: 'application/json',
            success: function (data) {
                window.location.href = data;
            }
        });
    });
});