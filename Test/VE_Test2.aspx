<%@ Page Language="VB" AutoEventWireup="false" CodeFile="VE_Test2.aspx.vb" Inherits="Test_VE_Test2" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script type="text/javascript" src="http://ecn.dev.virtualearth.net/mapcontrol/mapcontrol.ashx?v=6.2"></script>      
    <script language="javascript" type="text/javascript">
        var map = null;
        var pinid = 0;
        var moving = false;
        var marker = null;
        var pinIconHTML = '<div style=\'position:relative;top:-20px;\'><img src=\'images/PushPin.png\'></div>'
        var moveIconHTML = '<div style=\'position:relative;top:-30px;\'><img src=\'images/movePushPin.png\'></div>'
        function GetMap() {
            map = new VEMap('MapDiv');
            map.LoadMap();
            map.SetMapStyle(VEMapStyle.Shaded);
            map.SetMouseWheelZoomToCenter(false);
            map.SetCenterAndZoom(new VELatLong(13.6758888, 100.54613888), 10);

            //Add Marker
            marker = new VEShape(VEShapeType.Pushpin, map.GetCenter());
            marker.SetTitle('Draggable Marker');
            marker.SetDescription('Hold down the right mouse button to drag me. ');
            map.AddShape(marker);

            // Attach the event handlers to the mouse 
            map.AttachEvent("onmousemove", mouseMoveHandler);
            map.AttachEvent("onmousedown", mouseDownHandler);
            map.AttachEvent("onmouseup", mouseUpHandler);
        }

        function AddPushpin() {

            var shapenew = new VEShape(VEShapeType.Pushpin, map.GetCenter());
            shapenew.SetTitle('Draggable Marker Add New');
                //map.SetMouseWheelZoomToCenter(false);

            //            shape.SetDescription('This is shape number ' + pinid); pinid++;
            //map.SetCenterAndZoom(new VELatLong(13.6758888, 100.54613888), 10);
            map.AddShape(shapenew);
                
                map.AttachEvent("onmousemove", mouseMoveHandler);
                map.AttachEvent("onmousedown", mouseDownHandler);
                map.AttachEvent("onmouseup", mouseUpHandler);
        }

        function load() {
            //Create Map
            map = new VEMap('MapDiv');
            map.LoadMap();
            map.SetMapStyle(VEMapStyle.Shaded);
            map.SetMouseWheelZoomToCenter(false);
            map.SetCenterAndZoom(new VELatLong(13.6758888, 100.54613888), 10);

            //Add Marker
            marker = new VEShape(VEShapeType.Pushpin, map.GetCenter());
            marker.SetTitle('Draggable Marker');
            marker.SetDescription('Hold down the right mouse button to drag me. ');
            map.AddShape(marker);

            // Attach the event handlers to the mouse 
            map.AttachEvent("onmousemove", mouseMoveHandler);
            map.AttachEvent("onmousedown", mouseDownHandler);
            map.AttachEvent("onmouseup", mouseUpHandler);


        }

        //onmousedown handler
        function mouseDownHandler(e) {
            if (e.rightMouseButton && e.elementID) {
                currentShape = map.GetShapeByID(e.elementID);
                if (currentShape.GetType() == VEShapeType.Pushpin) {
                    currentShape.SetCustomIcon(moveIconHTML);
                    currentShape.SetPoints(map.PixelToLatLong(new VEPixel(e.mapX, e.mapY)));
                    moving = true;
                    map.vemapcontrol.EnableGeoCommunity(true);
                    document.getElementById("MapDiv").style.cursor = 'crosshair';
                } else {
                    currentShape = null;
                }
            }
        }

        //onmousemove handler
        function mouseMoveHandler(e) {
            clearTimeout(resetArrows);
            var loc = map.PixelToLatLong(new VEPixel(e.mapX, e.mapY));
            var latVariance = 0;
            var longVariance = 0;
            var panAmount = 10;
            var movingDirection = '';

            document.getElementById("MouseLat").innerHTML = loc.Latitude.toFixed(4);
            document.getElementById("MouseLng").innerHTML = loc.Longitude.toFixed(4);
            if (moving) {
                document.getElementById("MarkerLat").innerHTML = loc.Latitude.toFixed(4);
                document.getElementById("MarkerLng").innerHTML = loc.Longitude.toFixed(4);
                map.HideInfoBox(currentShape);
                currentShape.SetPoints(loc);

                //determine direction
                if (previousLoc) {
                    latVariance = loc.Latitude - previousLoc.Latitude
                    longVariance = loc.Longitude - previousLoc.Longitude

                    if (latVariance > 0) {
                        document.getElementById("NIndicator").style.color = 'red';
                        document.getElementById("SIndicator").style.color = '';
                        movingDirection = 'north';

                    } else if (latVariance < 0) {
                        document.getElementById("SIndicator").style.color = 'red';
                        document.getElementById("NIndicator").style.color = '';
                        movingDirection = 'south';
                    }

                    if (longVariance > 0) {
                        document.getElementById("EIndicator").style.color = 'red';
                        document.getElementById("WIndicator").style.color = '';
                        movingDirection = 'east';
                    } else if (longVariance < 0) {
                        document.getElementById("WIndicator").style.color = 'red';
                        document.getElementById("EIndicator").style.color = '';
                        movingDirection = 'west';
                    }

                    resetArrows = setTimeout("resetCompass()", 50);
                }

                //pan map
                if ((loc.Latitude < southBound) && movingDirection == 'south') { map.Pan(0, panAmount); }
                if ((loc.Latitude > northBound) && movingDirection == 'north') { map.Pan(0, panAmount * -1); }
                if ((loc.Longitude < westBound) && movingDirection == 'west') { map.Pan(panAmount * -1, 0); }
                if ((loc.Longitude > eastBound) && movingDirection == 'east') { map.Pan(panAmount, 0); }
                previousLoc = loc;
            }
        }

        //onmouseup handler
        function mouseUpHandler(e) {
            if (moving && e.rightMouseButton) {
                currentShape.SetCustomIcon(pinIconHTML);
                currentShape = null;
                moving = false;
                map.vemapcontrol.EnableGeoCommunity(false);
                document.getElementById("MapDiv").style.cursor = '';
            }
        }           
    </script>
<%--        <script type="text/javascript" language="javascript">
            function showpresence(presence) {
                alert(presence)
                var LivePresence = document.getElementById('LivePresence');

                var statusIcon = document.createElement('img');
                statusIcon.style.border = 'none';
                statusIcon.align = 'absmiddle';
                statusIcon.src = presence.icon.url;
                statusIcon.width = presence.icon.width;
                statusIcon.height = presence.icon.height;
                statusIcon.alt = presence.statusText;
                statusIcon.title = presence.statusText;

                LivePresence.appendChild(statusIcon);
                LivePresence.innerHTML += ' ' + presence.statusText + '&nbsp;&nbsp;&nbsp;';
            }
    </script>--%>
<%--    <script type="text/javascript">
        var gaJsHost = (("https:" == document.location.protocol) ? "https://ssl." : "http://www.");
        document.write(unescape("%3Cscript src='" + gaJsHost + "google-analytics.com/ga.js' type='text/javascript'%3E%3C/script%3E"));
    </script>
    <script type="text/javascript">
        var pageTracker = _gat._getTracker("UA-3959433-1");
        pageTracker._initData();
        pageTracker._trackPageview();
    </script>--%>

</head>
<body onload="GetMap();">
    <form id="form1" runat="server">
    <div>
        <div id='MapDiv' style="position:relative; width:400px; height:400px;"></div>
        <asp:Label ID="MouseLat" runat="server"></asp:Label>
        <br />
        <asp:Label ID="MouseLng" runat="server"></asp:Label>
        <br />
        <asp:Label ID="MarkerLat" runat="server"></asp:Label>
        <br />
        <asp:Label ID="MarkerLng" runat="server"></asp:Label>
        <br />
        <input id="Button1" type="button" value="button" onclick ="AddPushpin()" /></div>
    </form>
</body>
</html>
