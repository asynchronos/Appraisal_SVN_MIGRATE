<%@ Page Language="VB" AutoEventWireup="false" CodeFile="CollDetail_Edit_Position.aspx.vb" Inherits="CollDetail_Edit_Position" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
    <script src="http://maps.google.com/maps?file=api&amp;v=2.x&amp;key=ABQIAAAAzr2EBOXUKnm_jVnk0OJI7xSosDVG8KKPE1-m51RBrvYughuyMxQ-                   i1QfUnH94QxWIa6N4U6MouMmBA" type="text/javascript">
    </script>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>แก้ไขจุด Lat และ Lng</title>
        <style type="text/css">
        .style1
        {
            height: 15px;
            
        }
    </style>
</head>
<body onunload="GUnload()">
    <form id="form1" runat="server">
   <table>
       <tr>
           <td class="style1">
               <input type="button" id="btnAddMark" value="Create New Marker" onclick="btnAddMark_onclick()" /><asp:HiddenField 
                   ID="hdfReq_Id" runat="server" />
               <asp:HiddenField ID="hdfHub_Id" runat="server" />
             </td>
           <td>
               </td>
       </tr>
       <tr>
           <td>
                 <div id="map" style="width: 800px; height: 600px" ></div>
                     </td>
           <td valign="top"> <div id="formMark">
                <div id="side_bar" style="display:none";></div></div>
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


            function createMarker(point, name, nReq_id, nHub_id, ncif, nlat, nlng, ncreate_date) {
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
                var center = point //map.getCenter();
                var marker = new GMarker(point, { draggable: true });

                //var marker = new GMarker(point, icons);
                GEvent.addListener(marker, "dragend", function() {
                    //marker.openInfoWindowHtml(html);
                    var newlatlong = marker.getLatLng();
                    var label1 = "Information";
                    var label2 = "Picture";

                    var html2 = "<a href='images/maps_results_logo.gif' target='_blank'><img src='images/maps_results_logo.gif'border='0'></a>";
                    var html = "<b>Marker information</b><br>"
                    html += "<table>";
                    html += "<tr><td>REQ ID :</td><td><b>" + nReq_id + "</b><input type='hidden' value='" + nReq_id + "' id='txtReq_Id' name='txtReq_Id'></td><tr>"
                    html += "<tr><td>HUB ID :</td><td><b>" + nHub_id + "</b><input type='hidden' value='" + nHub_id + "' id='txtHub_Id' name='txtHub_Id'></td><tr>"
                    html += "<tr><td>CIF :</td><td><b>" + ncif + "</b><input type='hidden' value='" + ncif + "' id='txtCif' name='txtCif'></td><tr>"
                    html += "<tr><td>Lat :</td><td><b>" + nlat + "</b><input type='hidden' value='" + nlat + "' id='txtLat' name='txtLat'></td><tr>";
                    html += "<tr><td>Lng :</td><td><b>" + nlng + "</b><input type='hidden' value='" + nlng + "' id='txtLng' name='txtLng'></td><tr>";
                    html += "<tr><td>Lat New :</td><td><input type='text' value='" + newlatlong.lat() + "' id='txtLatnew' name='txtLatnew'></td><tr>";
                    html += "<tr><td>Lng New :</td><td><input type='text' value='" + newlatlong.lng() + "' id='txtLngnew' name='txtLngnew'></td><tr>";
                    html += "<tr><td>วันที่ประเมิน:</td><td> <input type='text' id='txtCreate_Date' value='" + ncreate_date + "' name='txtCreate_Date'></td><tr>"
                    html += "<tr><td colspan=2><input type='button' onclick='updateName(" + nReq_id + "," + nHub_id + "," + newlatlong.lat() + "," + newlatlong.lng() + ")' value='Update Marker'> ";
                    html += "<input type='button' onclick='cancelUpdate()' value='Cancel'></td><tr>";
                    //alert(newlatlong.lat());
                    //alert(newlatlong.lng());
                    marker.openInfoWindowTabsHtml([new GInfoWindowTab(label1, html), new GInfoWindowTab(label2, html2)]);
                    //document.getElementById("txtLatnew").value = newlatlong.lat();
                    //document.getElementById("txtLngnew").value = newlatlong.lng();
                    //var a = html;
                    //alert(a.getElementById("txtLngnew").value);

                });
                
             
                // save the info we need to use later for the side_bar
                gmarkers.push(marker);
                // add a line to the side_bar html
                side_bar_html += '<a href="javascript:myclick(' + (gmarkers.length - 1) + ')">' + name + '</a><br>';
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
            //map.setCenter(new GLatLng(13.6758888, 100.54613888), 10);

            loadMark()// โหลดครั้งแรก

            function loadMark() {
                // Read the data from example.xml
                //var file ="GmapDB.aspx?action=1";


                
                var reqid = document.getElementById("hdfReq_Id").value;
                var hubid = document.getElementById("hdfHub_Id").value;
                var file = "Price3DB.aspx?action=5&Req_Id=" + reqid + "&Hub_Id=" + hubid;
                GDownloadUrl(file, function(doc) {
                    var xmlDoc = GXml.parse(doc);
                    //alert(doc);
                    var markers = xmlDoc.documentElement.getElementsByTagName("Price1_Master");
                    //alert(markers.length);
                    if ((markers.length) > 0) {
                        for (var i = 0; i < markers.length; i++) {
                            // obtain the attribues of each marker
                            // create the marker
                            //ert('loop');                     
                            var req_id = markers[i].getElementsByTagName("Req_Id")[0];
                            var hub_id = markers[i].getElementsByTagName("Hub_Id")[0];
                            var cif = markers[i].getElementsByTagName("Cif")[0];
                            var cifname = markers[i].getElementsByTagName("CifName")[0];
                            var lat = markers[i].getElementsByTagName("Lat")[0];
                            var lng = markers[i].getElementsByTagName("Lng")[0];
                            var pricewah = markers[i].getElementsByTagName("PriceWah")[0];
                            var totalprice = markers[i].getElementsByTagName("Price")[0];
                            var create_date = markers[i].getElementsByTagName("Create_Date")[0];
                            var nReq_id = req_id.firstChild.nodeValue;
                            var nHub_id = hub_id.firstChild.nodeValue;
                            //alert(nReq_id);
                            //alert(nHub_id);
                            var ncif = cif.firstChild.nodeValue;
                            //alert(ncif);
                            var nCifName = cifname.firstChild.nodeValue;
                            //alert(nCifName);
                            var nlat = lat.firstChild.nodeValue;
                            //alert(nlat);
                            var nlng = lng.firstChild.nodeValue;
                            //alert(nlng);
                            var ncreate_date = create_date.firstChild.nodeValue;
                            //alert(ncreate_date);
                            var point = new GLatLng(nlat, nlng);
                            //alert(point);

                            map.setCenter(new GLatLng(nlat, nlng), 13);
                            var marker = createMarker(point, nCifName, nReq_id, nHub_id, ncif, nlat, nlng, ncreate_date);
                            //alert(marker);

                            map.addOverlay(marker);
                            gmarkers.push(marker);
                        }
                    } else {
                        //                var map = new GMap2(document.getElementById("map"));
                        //                map.addControl(new GLargeMapControl());
                        //                map.addControl(new GMapTypeControl());
                        //                map.setCenter(new GLatLng(13.6758888, 100.54613888), 13)
                                        //alert('No Data');
                    }

                    // put the assembled side_bar_html contents into the side_bar div
                    document.getElementById("side_bar").innerHTML = side_bar_html;
                });
            }
        }

        else {
            alert("Sorry, the Google Maps API is not compatible with this browser");
        }


        function btnAddMark_onclick() {
            document.getElementById("btnAddMark").style.display = "none";
            // This icon is a different shape, so we need our own settings       

            // point = new GLatLng(13.6758888,100.54613888);
            // map.addOverlay(createMarker(point,"AddNew","",icons));


            // var center = new GLatLng(13.6888888, 100.54613888);
            var center = map.getCenter();
            var marker = new GMarker(center, { draggable: true });
            //marker.setCenter();
            GEvent.addListener(marker, "dragend", function() {
                var latlong = marker.getLatLng();
                var reqid = document.getElementById("HiddenField1");
                var hubid = document.getElementById("HiddenField2");
                var cif = document.getElementById("HiddenField4");
                var userid = document.getElementById("HiddenField3");

                var html = "<b>Please Insert Detail </b><br>"
                html += "<table>";
                html += "<tr><td>Req Id :</td><td> <input type='text' value='" + reqid.value + "' id='txtReqId' name='txtCid'></td><tr>"
                html += "<tr><td>Hub Id :</td><td> <input type='text' value='" + hubid.value + "' id='txtHubId' name='txtHubId'></td><tr>"
                html += "<tr><td>Cif :</td><td> <input type='text' value='" + cif.value + "' id='txtCif' name='txtCif'></td><tr>"
                html += "<tr><td>Lat :</td><td><input type='text' value='" + latlong.lat() + "' id='txtLat' name='txtLat'></td><tr>";
                html += "<tr><td>Lng :</td><td><input type='text' value='" + latlong.lng() + "' id='txtLng' name='txtLng'></td><tr>";
                html += "<tr><td>ตรว.ละ</td><td> <input type='text' id='txtPricewah' name='txtPricewah'></td><tr>"
                html += "<tr><td>Price:</td><td> <input type='text' id='txtPrice' name='txtPrice'></td><tr>"
                html += "<tr><td colspan=2><input type='button' onclick='saveName(" + latlong.lat() + "," + latlong.lng() + ")' value='กำหนดราคาที่ 1'> ";
                html += "<input type='button' onclick='cancelAdd()' value='Cancel'></td><tr>";
                marker.openInfoWindowHtml(html);
            });
            var html = "You can move this.";

            map.addOverlay(marker);
            gmarkers.push(marker);
            marker.openInfoWindowHtml("<b>You can move now.<b>");

        }
        function cancelAdd() {
            document.getElementById("btnAddMark").style.display = "inline";

            map.removeOverlay(gmarkers[gmarkers.length - 1])
            // qmarkers.pop();
        }

        function updateName(nReq_Id,nHub_Id,lat, lng) {
            //
            var err = false;
//            var req_id = document.getElementById("txtReq_Id").value;
//            var hub_id = document.getElementById("txtHub_Id").value;
//            var lat = document.getElementById("txtLatnew").value;
//            var lng = document.getElementById("txtLngnew").value;
            if (lat == '') { err = true; }
            if (lng == '') { err = true; }

            if (err) {
                alert("Please insert completed data.");
            } else {
                var file = "Price3DB.aspx"
                var req = "action=4&req_id=" + nReq_Id + "&hub_id=" + nHub_Id + "&lat=" + lat + "&lng=" + lng
                // alert(file);
                //btnCancel_onlick();

                document.getElementById("btnAddMark").style.display = "inline";
                side_bar_html = "";
                map.clearOverlays();

                GDownloadUrl(file, function a() { }, req);
                loadMark()               
                map.openInfoWindow(new GLatLng(lat, lng), document.createTextNode("Update complete."));

            }
        }
        function cancelUpdate() {
            //
            map.closeInfoWindow()
        }
        function saveName(lat, lng) {
            var err = false;
            //var name = document.getElementById("txtNameMark").value;
            //var cid =  document.getElementById("txtCidMark").value;
            //var price =  document.getElementById("txtPrice").value;

            var reqid = document.getElementById("txtReqId").value;
            var hubid = document.getElementById("txtHubId").value;
            var cif = document.getElementById("txtCif").value;
            var userid = document.getElementById("HiddenField3").value;
            var pricewah = document.getElementById("txtPricewah").value;
            var price = document.getElementById("txtPrice").value;

            if (reqid == '') { err = true; }
            if (hubid == '') { err = true; }
            if (cif == '') { err = true; }
            if (pricewah == '') { err = true; }
            if (price == '') { err = true; }

            if (err) {
                alert("คุณยังกรอกข้อมูลไม่ครบตามที่ระบบกำหนด.");
            } else {
                //var file = "GmapDB.aspx"
                var file = "Price3DB.aspx"
                var req = "action=3&Req_Id=" + reqid + "&Hub_Id=" + hubid + "&cif=" + cif + "&lat=" + lat + "&lng=" + lng + "&pricewah=" + pricewah + "&price=" + price + "&userid=" + userid
                // alert(file);
                //btnCancel_onlick();

                document.getElementById("btnAddMark").style.display = "inline";
                side_bar_html = "";
                map.clearOverlays();

                GDownloadUrl(file, function a() { }, req);
                map.openInfoWindow(new GLatLng(lat, lng), document.createTextNode("Add complete."));

                //window.opener.location.href = window.opener.location.href + "";
                window.opener.location.href = window.opener.location;
                //window.opener.location.reload("Appraisal_List_By_Hub.aspx");
                window.close();

            }
        }

        //]]>/// จบ google map
</script>
