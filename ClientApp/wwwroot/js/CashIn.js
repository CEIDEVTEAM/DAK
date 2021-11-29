function handleResponse() {

    $.ajax({
        type: 'GET',

        url: 'PopulatePolygons',
        success: function (response) {

        },
        error: function (response) {

        }
    })

}
function handleChash() {

    var id = document.createElement("id").value;
    var price = 10;
    var JSON = { PackageId: id, Amount: price };
    $.ajax({
        type: 'POST',
        data: JSON,
        url: 'ProcessCash',
        success: function (response) {

        },
        error: function (response) {

        }
    })

}