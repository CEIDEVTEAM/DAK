function getTrackingRequest() {

    var trackingNumber = document.getElementById("trackingNumber").value;
    

    var mandatoryInputs = {
        trackingNumber: trackingNumber
    }

    var check = validateInputs(mandatoryInputs);
    if (check) {
        var jSon = {
            trackingNumber: trackingNumber
        }

        $.ajax({
            type: 'POST',
            data: jSon,
            url: 'GetTrackingRequest',
            success: function (respuesta) {
                document.getElementById("trackingParcial").innerHTML = respuesta;
            },
            error: function (respuesta) {

            }
        })
    } else {

        alert("Debe completar todos los campos.");

    }
}


function validateInputs(inputs) {

    for (var input in inputs) {
        if (inputs[input] == null || inputs[input] == "")
            return false;
    }
    return true;
}
