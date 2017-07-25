$(document).ready(function () {

    $("#class_list").blur(function() {
        
        var studentClasses = $(this).val();

        $.ajax({ 
            url: "/Teacher/AvailableSubjectsForClass",
            type: 'POST',
            dataType: "json",
            data: JSON.stringify(studentClasses),
            contentType: 'application/json',
            success: function (response) {
                var $el = $("#subject_list");
                $el.empty();

                $.each(response, function (key, text) {
                    $el.append($("<option></option>")
                        .attr("value", text).text(text));
                });
            }
        });
    });

});