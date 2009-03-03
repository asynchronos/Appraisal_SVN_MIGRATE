<%@ Page Language="VB" AutoEventWireup="false" CodeFile="MapColleteral.aspx.vb" Inherits="MapColleteral" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Untitled Page</title>
    <script src="http://maps.google.com/maps?file=api&amp;v=2.x&amp;key=ABQIAAAAzr2EBOXUKnm_jVnk0OJI7xSosDVG8KKPE1-m51RBrvYughuyMxQ-i1QfUnH94QxWIa6N4U6MouMmBA" type="text/javascript"></script>
    <script type="text/javascript">
    var map = null;
    var geocoder = null;

    function initialize() {
      if (GBrowserIsCompatible()) {
        map = new GMap2(document.getElementById("map_canvas"));
        map.setCenter(new GLatLng(13.6758888, 100.54613888), 13);
        geocoder = new GClientGeocoder();
        map.addControl(new GLargeMapControl());
      }
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
              
              var center = new GLatLng(13.6758888, 100.54613888);
              var marker = new GMarker(point, {draggable: true});
              map.addOverlay(marker);
              
              marker.openInfoWindowHtml(address);
              GEvent.addListener(marker, "dragend", function() {
              var latlong=marker.getLatLng();
              var latText=document.getElementById("lat");
              var lngText=document.getElementById("lng");
   
              latText.value=latlong.lat();
              lngText.value=latlong.lng();
             
            });
             map.addOverlay(marker);
            }
          }
        );
      }
    }
    </script>
</head>
<body onload="initialize()" onunload="GUnload()">
    <form id="form1" runat ="server" action="#" onsubmit="showAddress(this.address.value); return false">
    <div>
        <div id="map_canvas" style="width: 788px; height: 450px">
        </div>
        <input type="text" size="60" name="address" value="1600 Amphitheatre Pky, Mountain View, CA" />
        <input type="submit" value="Go!" /><br/>
        <input type="text" id="lat" />
    long&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <input type="text" id="lng" />
</div>
    </form>
</body>
</html>
