//const { relativeTimeRounding } = require("../adminlte/plugins/moment/moment-with-locales");


window.onload = initMap;

var map;
var marker;
var dto = [];

//iniciarMapa
function initMap() {

    var currentPoly = [];
    const centro = { lat: 39.866667, lng: -4.033333 };
    map = new google.maps.Map(document.getElementById('map'), {
        zoom: 14,
        center: centro,
        mapTypeId: "roadmap",
    });

    document.getElementById("smBut").addEventListener("click", addPackage);

    handleResponse();
}

//funciones auxiliares
function setMapOnAll(map) {
    for (let i = 0; i < markers.length; i++) {
        markers[i].setMap(map);
    }
}

function clearMarkers() {
    setMapOnAll(null);
}

function showMarkers() {
    setMapOnAll(map);
}

function deleteMarkers() {
    clearMarkers();
    markers = [];
}

function removeLine(name) {

    name.setMap(null);
}

function showArrays(event) {

    if (marker != undefined) {
        marker.setMap(null);
    }
    const polygon = this;
    const vertices = polygon.getPath();
    const nombre = polygon.name;
    const id = polygon.id;
    let contentString =
        "<b>Zona: " + nombre + "</b><br>" +
        "Esta Ubicación: <br>" +
        event.latLng.lat() +
        "," +
        event.latLng.lng() +
        "<br>";


    marker = new google.maps.Marker({
        position: event.latLng,
        map,
        animation: google.maps.Animation.DROP,
        title: "Ubicación",
    });

    const consult = google.maps.geometry.poly.containsLocation(
        event.latLng,
        polygon
    )
        ? true
        : false;

    if (consult) {

        idZona = id;
        lat = event.latLng.lat();
        long = event.latLng.lng();

        dto = { id: idZona, latitud: lat, longitud: long };

    }

}


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
    var distance = 100;
    if (dto.id != undefined) {

        var jSon = {
            IdClient: IdClient, IdRecipient: IdRecipient, Height: Height, Width: Width, Weight: Weight, Length: Length, Type: Type,
            Latitude: dto.latitud, Longitude: dto.longitud, IdDeliveryArea: dto.id, Distance: distance, Address: Address
        }

        $.ajax({
            type: 'POST',
            data: jSon,
            url: 'AddPackage',
            success: function (respuesta) {
                hideDivMap();
                document.getElementById("IdClient").value="";
                document.getElementById("IdRecipient").value = "";
                document.getElementById("Address").value = "";
                document.getElementById("Height").value = "";
                document.getElementById("Width").value = "";
                document.getElementById("Weight").value = "";
                document.getElementById("Length").value = "";
                document.getElementById("selectValue").value = "";
            },
            error: function (respuesta) {

            }
        })
    } else {

        alert("Debe ingresar la ubicación de Destino.");

    }
}

function createPoly(coordinates) {

    var coords = [];
    for (let i = 0; i < coordinates.length; i++) {

        let latitude = parseFloat(coordinates[i].getPosition().lat().toFixed(6));
        let long = parseFloat(coordinates[i].getPosition().lng().toFixed(6));
        let singleCoord = { lat: latitude, lng: long };
        coords.push(singleCoord);

    }

    var color = document.getElementById("colorPicker").value;
    //var name = document.getElementById("zoneColor").value;

    const polyCoords = coords;
    // Construct the polygon.
    const polygon = new google.maps.Polygon({
        paths: polyCoords,
        strokeColor: color,
        strokeOpacity: 0.8,
        strokeWeight: 3,
        fillColor: color,
        fillOpacity: 0.90,
        editable: true

    });
    polygon.setMap(map);

    deleteMarkers();


    polygon.addListener("click", showArrays);
    infoWindow = new google.maps.InfoWindow();

    document.getElementById("btn1").addEventListener("click", function () {
        getZona(polygon)
    });

    return polygon;
}


//imprimir zonas

function handleResponse() {

    $.ajax({
        type: 'GET',

        url: 'PopulatePolygons',
        success: function (response) {
            for (let i = 0; i < response.length; i++) {

                zonesPopulate(response[i]);
                console.log(response[i]);
            }

        },
        error: function (response) {

        }
    })

}
function zonesPopulate(item) {

    var coords = [];
    var orderVerts = item.colVexels.sort((a, b) => {
        return a.ordenNumber - b.ordenNumber;
    });

    for (let i = 0; i < orderVerts.length; i++) {

        let longitude = parseFloat(item.colVexels[i].longitude);
        let latitude = parseFloat(item.colVexels[i].latitude);
        let singleCoord = { lat: latitude, lng: longitude };
        coords.push(singleCoord);

    }

    var color = item.color;
    var nombre = item.name;
    var rActivos = item.reclamosActivos;
    var id = item.id;

    const polyCoords = coords;
    // Construct the polygon.
    const polygon = new google.maps.Polygon({
        id: id,
        name: nombre,
        count: rActivos,
        paths: polyCoords,
        strokeColor: color,
        strokeOpacity: 0.5,
        strokeWeight: 3,
        fillColor: color,
        fillOpacity: 0.2,


    });
    polygon.setMap(map);


    polygon.addListener("click", showArrays);
    infoWindow = new google.maps.InfoWindow();

}

function createPoint(map) {

    // creates a draggable marker to the given coords
    var vMarker = new google.maps.Marker({
        position: new google.maps.LatLng(39.866667, -4.033333),
        draggable: true
    });
    google.maps.event.addListener(vMarker, 'dragend', function (evt) {
        map.panTo(evt.latLng);
    });

    map.setCenter(vMarker.position);

    // adds the marker on the map
    vMarker.setMap(map);
    var latitude = vMarker.getPosition().lat().toFixed(6);
    var long = vMarker.getPosition().lng().toFixed(6);
    var marcador = { latitud: latitude, longitud: long };

    return marcador;
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

function hideDivMap() {

    var x = document.getElementById("map");
    if (x.style.display === "none") {
        x.style.display = "block";
    } else {
        x.style.display = "none";
    }
}


//function distance(map) {
//    // initialize services
//    const geocoder = new google.maps.Geocoder();
//    const service = new google.maps.DistanceMatrixService();
//    // build request
//    const origin = { lat: 39.866667, lng: -4.033333 };

//    const destination = { lat: 50.087, lng: 14.421 };
//    const request = {
//        origins: [origin],
//        destinations: [destination],
//        travelMode: google.maps.TravelMode.DRIVING,
//        unitSystem: google.maps.UnitSystem.METRIC,
//        avoidHighways: false,
//        avoidTolls: false,
//    };

//    var originList;
//    var destinationList;
//    var distanceList;

//    // put request on page
//    document.getElementById("request").innerText = JSON.stringify(
//        request,
//        null,
//        2
//    );
//    // get distance matrix response
//    service.getDistanceMatrix(request).then((response) => {
//        // put response
//        document.getElementById("response").innerText = JSON.stringify(
//            response,
//            null,
//            2
//        );

//        // show on map
//        const originList = response.originAddresses;
//        const destinationList = response.destinationAddresses;



//        const showGeocodedAddressOnMap = (asDestination) => {
//            const handler = ({ results }) => {
//                map.fitBounds(bounds.extend(results[0].geometry.location));
//                markersArray.push(
//                    new google.maps.Marker({
//                        map,
//                        position: results[0].geometry.location,
//                        label: asDestination ? "D" : "O",
//                    })
//                );
//            };
//            return handler;
//        };

//        for (let i = 0; i < originList.length; i++) {
//            const results = response.rows[i].elements;

//            geocoder
//                .geocode({ address: originList[i] })
//                .then(showGeocodedAddressOnMap(false));

//            for (let j = 0; j < results.length; j++) {
//                geocoder
//                    .geocode({ address: destinationList[j] })
//                    .then(showGeocodedAddressOnMap(true));
//            }
//        }
//    });

//    // show on map

//    originList = response.originAddresses;
//    destinationList = response.destinationAddresses;
//    distanceList = response.rows[0].elements[0].distance.value;

//    // show on map


//    return distanceList;
//}
//var service = new google.maps.DistanceMatrixService();
//function calculateDistance() {
//    var origin = { lat: 39.866667, lng: -4.033333 };
//    var destination = { lat: 40.866667, lng: -5.033333 };
//    service.getDistanceMatrix(
//        {
//            origins: [origin],
//            destinations: [destination],
//            travelMode: google.maps.TravelMode.DRIVING,
//            avoidHighways: false,
//            avoidTolls: false,
//            unitSystem: google.maps.UnitSystem.IMPERIAL
//        },
//        callback
//    );
//}
//function callback(response, status) {
//    var orig = { lat: 39.866667, lng: -4.033333 },
//        dest = { lat: 40.866667, lng: -5.033333 },
//        dist = "";

//    if (status == "OK") {
//        orig.value = response.originAddresses[0];
//        dest.value = response.destinationAddresses[0];
//        dist.value = response.rows[0].elements[0].distance.text;
//    } else {
//        alert("Error: " + status);
//    }
//}
//google.maps.event.addDomListener(window, "load", calculateDistance);