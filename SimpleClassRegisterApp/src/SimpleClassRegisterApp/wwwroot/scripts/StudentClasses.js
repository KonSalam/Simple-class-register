

$(document).on('click', '.list-group-item', function (evt) {
    var identification = $(this).text().trim();
    setClass(identification.toString());
});

function setClass(value) {
    $.ajax({
        url: "/StudentClasses/Index",
        type: 'POST',
        dataType: "json",
        data: JSON.stringify(value),
        contentType: 'application/json',
        success: function (obj) {
            alert('Suceeded');
        }
    });
}