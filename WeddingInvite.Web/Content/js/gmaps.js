function initMap() {
    var directionsDisplay = new google.maps.DirectionsRenderer;
    var directionsService = new google.maps.DirectionsService;
    var map = new google.maps.Map(document.getElementById('map'), {
        zoom: 9,
        center: { lat: 59.684129, lng: 18.608532 } // Länna Kyrka.
    });
    directionsDisplay.setMap(map);
    calculateAndDisplayRoute(directionsService, directionsDisplay);
}

function calculateAndDisplayRoute(directionsService, directionsDisplay) {
    directionsService.route({
        origin: '195 40 Märsta, Sweden', // Märsta Station
        destination: '190 45 Stockholm-Arlanda, Sweden', // Arlanda
        waypoints: [{ location: 'Stockholms Centralstation', stopover: true }, // Stockholm Central
                    { location: 'Lännaby, 761 93 Norrtälje, Sweden', stopover: true }, // Länna Kyrka
                    { location: 'Hotell Havsbaden i Grisslehamn', stopover: true }], // Hotell Havsbaden  
        optimizeWaypoints: false,
        travelMode: 'DRIVING'
    }, function (response, status) {
        if (status == 'OK') {
            directionsDisplay.setDirections(response);
        }
    });
}