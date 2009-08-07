<%@ Page Language="VB" AutoEventWireup="false" CodeFile="LongDoMap.aspx.vb" Inherits="LongDoMap" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>กำหนดหมุด เพื่อให้ราคาที่ 1</title>
<script src="Js/jquery.js" type="text/javascript"></script>
<script src="Js/common.js" type="text/javascript"></script>    
<script type="text/javascript" 
	src="http://mmmap15.longdo.com/mmmap/mmmap.php?key=d9c8884535ae82504c4962ce47a4cae4">
</script>
<%--        <style type="text/css">
            #mmMapDiv{
                position:absolute;
            }
        </style> --%>
<script type="text/javascript">
    var mmmap;
    var VMid;
    function initMap() {
        //var div_map = getEleByProperty("div", "MyClintID", "mmMapDiv");


        var mmmap_div = document.getElementById("mmMapDiv");
        mmmap = new MMMap(mmmap_div, 13.6758888, 100.54613888, 3, "normal");
        var canvas = mmmap.addControl("canvas");
        canvas.addButton('measure');
        canvas.addButton('poly');
        canvas.addButton('clear');
        canvas.setSaveURL('shape/add');

        //alert(mmmap.centerLat());
        //alert(mmmap.centerLong());
        //ผูก function adJustMapSize เข้ากับ event onresize
        //ของ window ซึ่งก็คือ browser นั่นเอง        
        window.onresize = adJustMapSize;
        //เรียกใช้ function adJustMapSize ให้ปรับขนาดของแผนที่
        //ให้พอดีกับหน้าต่าง browser
        adJustMapSize();




    }

    //function สำหรับปรับขนาดของแผนที่ให้เต็มหน้าต่าง browser โดยอัตโนมัติ
    function adJustMapSize() {
        //เรียกใช้ function chkWinSize เพื่อเก็บขนาดของหน้าต่าง browser
        //โดยเก็บความกว้างไว้ในตัวแปร ww และความยาวไว้ในตัวแปร wh
        chkWinSize();

        //ใช้ function parstInt เพื่อแปลงข้อมูลเป็นจำนวนเต็ม
        var newwidth = parseInt(ww) - 5 - 5;
        var newheight = parseInt(wh) - 85 - 5;

        //เรียกใช้ method setSize และ rePaint เพื่อปรับขนาดของแผนที่
        mmmap.setSize(newwidth, newheight);
        mmmap.rePaint();

        //mmmap.setMouseMoveHandler(f);
        mmmap.setMouseDownHandler(f);
    }

    function btnAddMark_onclick() {
        //mmmap.centerLat() and mmmap.centerLong
        //alert(mmmap.centerLat());
        //alert(mmmap.centerLong());
        var txtlat = getEleByProperty("input", "MyClintID", "TxtLat");
        var txtlng = getEleByProperty("input", "MyClintID", "TxtLng");
        txtlat.value = mmmap.centerLat();
        txtlng.value = mmmap.centerLong();

        var truck = document.createElement('div');
        truck.innerHTML = '<img src="Images/red_button_16.gif">';
        mmmap.drawCustomDiv(truck, mmmap.centerLat(), mmmap.centerLong(), "Current Position");
        VMid = mmmap.createMarker(mmmap.centerLat(), mmmap.centerLong(), '', '');
    }

    function removeMarker() {
        mmmap.deleteMarker(VMid);
        mmmap.clearCustomDivs();
    }
    
    function f() {
        //alert(mmmap.centerLat());
        //alert(mmmap.centerLong());
        var txtlat = getEleByProperty("input", "MyClintID", "TxtLat");
        var txtlng = getEleByProperty("input", "MyClintID", "TxtLng");
        txtlat.value = mmmap.centerLat();
        txtlng.value = mmmap.centerLong();
        //alert("Current location is " + latitude + ", " + longitude);
    };
</script>   

</head>
<body onload="initMap();" style="margin-left:0;margin-top:0;">
    <form id="form1" runat="server">
    <div id="mmMapDiv">
    </div>
    Lat :&nbsp;
    <asp:TextBox ID="TxtLat" runat="server" MyClintID="TxtLat"></asp:TextBox>
    <br />
    Lng :     <asp:TextBox ID="TxtLng" runat="server" MyClintID="TxtLng"></asp:TextBox>
    <br />
    <input type="button" id="btnAddMark" value="Create New Marker" onclick="btnAddMark_onclick()" />
    <input type="button" id="btnAddMark0" value="Delete Marker" 
        onclick="removeMarker()" />
    <asp:Button ID="BtnOk" runat="server" Text="Ok" />
    </form>
</body>
</html>
