
$(document).ready(function () {

    $(document).on('click', '.to-choose', function (evt) {
        evt.preventDefault(); 
        var identification = $(this).text().trim();

        $.ajax({
            url: "/StudentClasses/Index",
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