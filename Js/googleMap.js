function initialize() {
  var message = ["This","is","the","secret","message"];
  var map = null;
  var geocoder = null;
  
  if (GBrowserIsCompatible()) {
    map = new GMap2(document.getElementById("map_canvas"));
    map.setCenter(new GLatLng(13.6758888, 100.54613888), 13);
    //บ้านต้ม 13.623517754668153,100.60284733772278
    map.addControl(new GLargeMapControl());
    geocoder = new GClientGeocoder();
    
    // Creates a marker at the given point
    // Clicking the marker will hide it
    
    //function createMarker(latlng, number) {
    //  var marker = new GMarker(latlng);
    //  marker.value = number;
    //  GEvent.addListener(marker,"click", function() {
   //     var myHtml = "<b>#" + number + "</b><br/>" + message[number -1];
    //    map.openInfoWindowHtml(latlng, myHtml);
    //  });
    //  return marker;
	//}

    // Add 5 markers to the map at random locations
    // Note that we don't add the secret message to the marker's instance data
    
    //var bounds = map.getBounds();
    //var southWest = bounds.getSouthWest();
    //var northEast = bounds.getNorthEast();
    //var lngSpan = northEast.lng() - southWest.lng();
    //var latSpan = northEast.lat() - southWest.lat();
    //var latlng = new GLatLng(13.6758888, 100.54613888);
    //map.addOverlay(createMarker(latlng,1));   
    
    // for (var i = 0; i < 5; i++) {
    //  var latlng = new GLatLng(southWest.lat() + latSpan * Math.random(),
	//    southWest.lng() + lngSpan * Math.random());
	//map.addOverlay(createMarker(latlng, i + 1));
    //}
  }
      function showAddress(address) {
      if (geocoder) {
        geocoder.getLatLng(
          address,
          function(point) {
            if (!point) {
              alert(address + " not found");
            } else {
              map.setCenter(point, 13);
              var marker = new GMarker(point);
              map.addOverlay(marker);
              marker.openInfoWindowHtml(address);
            }
          }
        );
      }
    }
}
