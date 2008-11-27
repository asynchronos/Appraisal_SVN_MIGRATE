<%@ Page Language="VB" AutoEventWireup="false" CodeFile="colldetail.aspx.vb" Inherits="colldetail" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
    <script src="http://maps.google.com/maps?file=api&amp;v=2.x&amp;key=ABQIAAAAzr2EBOXUKnm_jVnk0OJI7xSosDVG8KKPE1-m51RBrvYughuyMxQ-i1QfUnH94QxWIa6N4U6MouMmBA" 
            type="text/javascript"></script>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>กำหนดราคาประเมินครั้งที่ 1</title>
    
</head>
<body onunload="GUnload()">
  <form id="form1">
   <table class="style3">
       <tr>
           <td class="style4">
               <input type="button" id="btnAddMark" value="Create New Marker" onclick="btnAddMark_onclick()" />
             </td>
           <td>
               &nbsp;</td>
       </tr>
       <tr>
           <td class="style4">
                 <div id="map" style="width: 800px; height: 600px" ></div>
                     </td>
           <td valign="top"> <div id="formMark">
                <div id="side_bar"></div></div>
           </td>
       </tr>
   </table>
&nbsp;</form>
 <p style="font-family: 'ms sans Serif'; font-size: x-small">
        * ความเร็วในการแสดงแผนที่ขึ้นอยู่กับความเร็วของเครือข่ายและสัญญานอินเตอร์เน็ต</p>
</body>
</html>

    <script type="text/javascript">
    //<![CDATA[
    
    if (GBrowserIsCompatible()) {
      // this variable will collect the html which will eventualkly be placed in the side_bar
      var side_bar_html = "";
    
      // arrays to hold copies of the markers used by the side_bar
      // because the function closure trick doesnt work there
      var gmarkers = [];
 
    
      // A function to create the marker and set up the event window
  
      
      function createMarker(point,name,html,icons) {
        var blueIcon = new GIcon();
        blueIcon.image = "images/colour086.png";
        blueIcon.shadow = "images/fingershadow.png";
        blueIcon.iconSize = new GSize(20, 34);
        blueIcon.shadowSize = new GSize(37, 34);
        blueIcon.iconAnchor = new GPoint(9, 34);
        blueIcon.infoWindowAnchor = new GPoint(9, 2);
        blueIcon.infoShadowAnchor = new GPoint(18, 25);
        // blueIcon.transparent = "http://www.google.com/intl/en_ALL/mapfiles/markerTransparent.png";
        // blueIcon.printImage = "coldmarkerie.gif";
        // blueIcon.mozPrintImage = "coldmarkerff.gif";
       var icons = blueIcon;  
        var  marker = new GMarker(point,icons); 
         GEvent.addListener(marker, "click", function() {
          //marker.openInfoWindowHtml(html);
          var label1="Information";
          var label2="Picture";
          var html2="<a href='images/maps_results_logo.gif' target='_blank'><img src='images/maps_results_logo.gif'border='0'></a>";
          marker.openInfoWindowTabsHtml([new GInfoWindowTab(label1,html), new GInfoWindowTab(label2,html2)]);
           
        });
        // save the info we need to use later for the side_bar
        gmarkers.push(marker);
        // add a line to the side_bar html
        side_bar_html += '<a href="javascript:myclick(' + (gmarkers.length-1) + ')">' + name + '</a><br>';
        return marker;
      }  //   function createMarker(point,name,html,icons) {

      // This function picks up the click and opens the corresponding info window
      function myclick(i) {
        GEvent.trigger(gmarkers[i], "click");
      }


      // create the map
      var map = new GMap2(document.getElementById("map"));
      map.addControl(new GLargeMapControl());
      map.addControl(new GMapTypeControl());
      map.setCenter( new GLatLng(13.6758888, 100.54613888),10);
 
      loadMark()// โหลดครั้งแรก
       
      function loadMark() {
      // Read the data from example.xml
         var file ="GmapDB.aspx?action=1";
            GDownloadUrl(file, function(doc) {
             var xmlDoc = GXml.parse(doc);
            //alert(doc);
             var markers = xmlDoc.documentElement.getElementsByTagName("Gmap");
            //alert(markers.length);  
        for (var i = 0; i < markers.length; i++) {
          // obtain the attribues of each marker
         // var lat = parseFloat(markers[i].getAttribute("lat"));
         // var lng = parseFloat(markers[i].getAttribute("lng"));
         // var point = new GLatLng(lat,lng);
         // var html = markers[i].getAttribute("html");
         // var label = markers[i].getAttribute("label");
          // create the marker
        var cid = markers[i].getElementsByTagName("COLL_ID")[0];  
        var lat = markers[i].getElementsByTagName("Lat")[0];  
        var lng =    markers[i].getElementsByTagName("Lng")[0];  
        var price1 = markers[i].getElementsByTagName("Price1")[0];  
        var name = markers[i].getElementsByTagName("Name")[0];
       //alert(price1);
        //var nlat = parseFloat(lat.firstChild.nodeValue);
        //var nlng = parseFloat(lng.firstChild.nodeValue);
        var ncid = cid.firstChild.nodeValue;
        var nlat = lat.firstChild.nodeValue;
        var nlng = lng.firstChild.nodeValue;
        var nprice1= price1.firstChild.nodeValue;
        var nname=name.firstChild.nodeValue;
        //alert(nprice1);
        var point = new GLatLng(nlat,nlng);
         
          var html ="<b>Marker information</b><br>" 
          html+="<table>";
          html+="<tr><td>Coll_id :</td><td><b>"+ ncid +"</b><input type='hidden' value='" + ncid +"' id='txtCidMark' name='txtCid'></td><tr>"
          html+="<tr><td>Name :</td><td><input type='text' value='" + nname +"' id='txtNameMark' name='txtName'></td><tr>"
          html+="<tr><td>Lat :</td><td><input type='text' value='" + nlat +"' id='txtLat' name='txtLat'></td><tr>";
          html+="<tr><td>Lng :</td><td><input type='text' value='" + nlng +"' id='txtLng' name='txtLng'></td><tr>";
          html+="<tr><td>Price:</td><td> <input type='text' id='txtPrice' value='" + nprice1 +"' name='txtPrice'></td><tr>"
          html+="<tr><td colspan=2><input type='button' onclick='updateName("+ nlat +","+ nlng +")' value='Update Marker'> ";
          html+="<input type='button' onclick='cancelUpdate()' value='Cancel'></td><tr>";
           
          var marker = createMarker(point,name,html);
          map.addOverlay(marker);
          gmarkers.push(marker);
            }
              // put the assembled side_bar_html contents into the side_bar div
             document.getElementById("side_bar").innerHTML = side_bar_html;  });
         }
        }

   else {
      alert("Sorry, the Google Maps API is not compatible with this browser");
   }

   
    function btnAddMark_onclick() {
       document.getElementById("btnAddMark").style.display="none"; 
      // This icon is a different shape, so we need our own settings       

     // point = new GLatLng(13.6758888,100.54613888);
     // map.addOverlay(createMarker(point,"AddNew","",icons));
 
        
       // var center = new GLatLng(13.6888888, 100.54613888);
        var center = map.getCenter() ;
        var marker = new GMarker(center,{draggable:true});     
        //marker.setCenter();
          GEvent.addListener(marker, "dragend", function() {
          var latlong=marker.getLatLng();
         // var txtLat= document.getElementById("txtLat");
         // var txtLng = document.getElementById("txtLng");
         // txtLat.value=latlong.lat();
         // txtLng.value=latlong.lng();
          var html ="<b>Please Insert Detail </b><br>" 
          html+="<table>";   
          html+="<tr><td>Coll_id :</td><td> <input type='text' id='txtCidMark' name='txtCid'></td><tr>"
          html+="<tr><td>Name :</td><td><input type='text' id='txtNameMark' name='txtName'></td><tr>"
          html+="<tr><td>Lat :</td><td><input type='text' value='" + latlong.lat() +"' id='txtLat' name='txtLat'></td><tr>";
          html+="<tr><td>Lng :</td><td><input type='text' value='" + latlong.lng() +"' id='txtLng' name='txtLng'></td><tr>";
          html+="<tr><td>Price:</td><td> <input type='text' id='txtPrice' name='txtPrice'></td><tr>"
          html+="<tr><td colspan=2><input type='button' onclick='saveName("+ latlong.lat() +","+ latlong.lng() +")' value='Add Marker'> ";
          html+="<input type='button' onclick='cancelAdd()' value='Cancel'></td><tr>";
         marker.openInfoWindowHtml(html);
        });
        var html="You can move this.";
        
        map.addOverlay(marker); 
        gmarkers.push(marker);
        marker.openInfoWindowHtml("<b>You can move now.<b>");
      
    }
    function cancelAdd() {
       document.getElementById("btnAddMark").style.display="inline"; 
    
        map.removeOverlay(gmarkers[gmarkers.length-1])
       // qmarkers.pop();
    }
    function updateName(lat,lng){
    //
      var err=false;
       var name = document.getElementById("txtNameMark").value;
       var cid =  document.getElementById("txtCidMark").value;
       var price =  document.getElementById("txtPrice").value;
       if (name=='') {err=true;}
       if (cid=='') {err=true;}
       if (price=='') {err=true;}
       
       if (err) {
        alert("Please insert completed data.");
       } else {
       var file = "GmapDB.aspx"
       var req= "action=4&cid=" + cid + "&name=" + name + "&lat=" + lat + "&lng=" + lng + "&price=" + price
        // alert(file);
        //btnCancel_onlick();
       
        document.getElementById("btnAddMark").style.display="inline"; 
        side_bar_html = "";
        map.clearOverlays();   
       
        GDownloadUrl(file,function a(){},req); 
        map.openInfoWindow(new GLatLng(lat,lng),document.createTextNode("Update complete."));
        loadMark()
       }
    }
    function cancelUpdate(){
    //
    map.closeInfoWindow()
    }
    function saveName(lat,lng) {
       var err=false;
       var name = document.getElementById("txtNameMark").value;
       var cid =  document.getElementById("txtCidMark").value;
       var price =  document.getElementById("txtPrice").value;
       if (name=='') {err=true;}
       if (cid=='') {err=true;}
       if (price=='') {err=true;}
       
       if (err) {
        alert("Please insert completed data.");
       } else {
       var file = "GmapDB.aspx"
       var req= "action=3&cid=" + cid + "&name=" + name + "&lat=" + lat + "&lng=" + lng + "&price=" + price
        // alert(file);
        //btnCancel_onlick();
       
        document.getElementById("btnAddMark").style.display="inline"; 
        side_bar_html = "";
        map.clearOverlays();   
       
        GDownloadUrl(file,function a(){},req); 
        map.openInfoWindow(new GLatLng(lat,lng),document.createTextNode("Add complete."));
        loadMark()
       }
    }
    
 //]]>/// จบ google map
     
     
</script>
    