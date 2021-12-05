//nuevo paquete
function addPackage() {

    var IdClient = document.getElementById("IdClient").value;
    var IdRecipient = document.getElementById("IdRecipient").value;
    var Address = document.getElementById("Address").value;
    var Height = document.getElementById("Height").value;
    var Width = document.getElementById("Width").value;
    var Weight = document.getElementById("Weight").value;
    var Length = document.getElementById("Length").value;
    var Type = document.getElementById("selectValue").value;
    var city = document.getElementById("selectValueCity").value;

    var mandatoryInputs = {
        IdClient: IdClient, IdRecipient: IdRecipient, Address: Address, City: city, Type: Type}
    var check = validateInputs(mandatoryInputs);
    if (check) {
        var jSon = {
            IdClient: IdClient, IdRecipient: IdRecipient, Height: Height, Width: Width, Weight: Weight, Length: Length, Type: Type,
            Address: Address, IdCity:city
        }

        $.ajax({
            type: 'POST',
            data: jSon,
            url: 'AddPackage',
            success: function (respuesta) {
                var url = "/CashIn/CashIn";
                window.location.href = url;
                
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


function hideDivDimensions(value) {
    var x = document.getElementById("dimensions");
    if (value == "PACKAGE") {
        if (x.style.display === "none") {
            x.style.display = "block";
        }
    } else {
        x.style.display = "none";
    }
}
