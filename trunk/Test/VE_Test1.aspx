<%@ Page Language="VB" AutoEventWireup="false" CodeFile="VE_Test1.aspx.vb" Inherits="Test_VE_Test1" %>

<%@ Register assembly="Microsoft.Live.ServerControls.VE" namespace="Microsoft.Live.ServerControls.VE" tagprefix="ve" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html>
   <head>
      <title>VEMap.AddShape, VEMap.DeleteShape, VEMap.Clear, VEShape.Hide, VEShape.Show</title>
      <meta http-equiv="Content-Type" content="text/html; charset=utf-8">

      <script type="text/javascript" src="http://ecn.dev.virtualearth.net/mapcontrol/mapcontrol.ashx?v=6.2"></script>

      <script type="text/javascript">
         var map     = null;

         var shape   = null;
         var c1Shape = null;
         var c2Shape = null;
         var c3Shape = null;
         var c4Shape = null;

         var cornerOne   = new VELatLong(45.01188,-111.06687);
         var cornerTwo   = new VELatLong(45.01534,-104.06324);
         var cornerThree = new VELatLong(41.01929,-104.06);
         var cornerFour  = new VELatLong(41.003,-111.05878);
         
         function GetMap()
         {
            map = new VEMap('myMap');
            map.LoadMap();

            // Set initial button states.
            btnDeleteShape.disabled = "disabled";
            btnAddShape.disabled = 0;
            btnHideShape.disabled = "disabled";
            btnShowShape.disabled = "disabled";
         }
         
         function AddShape()
         {
            // Create pushpins at each corner
            c1Shape = new VEShape(VEShapeType.Pushpin, cornerOne);
            c2Shape = new VEShape(VEShapeType.Pushpin, cornerTwo);
            c3Shape = new VEShape(VEShapeType.Pushpin, cornerThree);
            c4Shape = new VEShape(VEShapeType.Pushpin, cornerFour);

            // Create the VEShape object and assign parameters.
            var points = new Array(cornerOne, cornerTwo, cornerThree, cornerFour);
            
            shape = new VEShape(VEShapeType.Polygon, points);
            shape.SetLineWidth(3);
            shape.SetLineColor(new VEColor(0,150,100,1.0));
            shape.SetFillColor(new VEColor(0,150,100,0.5));

            // Add the shapes to the map
            map.AddShape(shape);
            map.AddShape(c1Shape);
            map.AddShape(c2Shape);
            map.AddShape(c3Shape);
            map.AddShape(c4Shape);
            
            // Set the map view to the same points used by the shape.
            map.SetMapView(points);
            
            // Toggle button states.
            btnDeleteShape.disabled = 0;
            btnAddShape.disabled = "disabled";
            btnHideShape.disabled = 0;
            btnShowShape.disabled = "disabled";
         }
         
         function DeleteShape()
         {
            // Delete the shape.
            map.DeleteShape(shape);

            // Toggle button states.
            btnDeleteShape.disabled = "disabled";
            btnAddShape.disabled = 0;
            btnHideShape.disabled = "disabled";
            btnShowShape.disabled = "disabled";
         }
         
         function HideShape()
         {
            // Hide the shape from view.
            shape.Hide();

            // Toggle button states.
            btnDeleteShape.disabled = 0;
            btnAddShape.disabled = "disabled";
            btnHideShape.disabled = "disabled";
            btnShowShape.disabled = 0;
         }
         
         function ShowShape()
         {
            // Make the shape visible again.
            shape.Show();

            // Toggle button states.
            btnDeleteShape.disabled = 0;
            btnAddShape.disabled = "disabled";
            btnHideShape.disabled = 0;
            btnShowShape.disabled = "disabled";
         }

         function ClearMap()
         {
            map.Clear();
         }
      </script>
   </head>
   <body onload="GetMap();">
      <div id='myMap' style="position:relative; width:400px; height:400px;"></div>
       <input id="btnAddShape" type="button" value="Click to Add a Shape" 
       name="addshape" onclick="AddShape()"><br />
       <input id="btnDeleteShape" type="button" value="Click to Delete the Shape" 
       name="deleteshape" onclick="DeleteShape()"><br />
       <input id="btnHideShape" type="button" value="Click to Hide the Shape" 
       name="hideshape" onclick="HideShape()"><br />
       <input id="btnShowShape" type="button" value="Click to Show the Shape" 
       name="showshape" onclick="ShowShape()"><br />
       <input id=btnClear" type="button" value="Click to clear the map"
       name="clearmap" onclick="ClearMap()">
   </body>
</html>

