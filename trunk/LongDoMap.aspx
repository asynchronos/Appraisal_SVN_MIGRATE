<%@ Page Language="VB" AutoEventWireup="false" CodeFile="LongDoMap.aspx.vb" Inherits="LongDoMap" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>กำหนดหมุด เพื่อให้ราคาที่ 1</title>

    <script src="Js/clsAjax.js" type="text/javascript"></script>
    <script src="Js/jquery.js" type="text/javascript"></script>
    <script src="Js/common.js" type="text/javascript"></script>
    <script src="Js/longdoMap.js" type="text/javascript"></script>
<%--<script type="text/javascript" src="http://mmmap15.longdo.com/mmmap/mmmap.php?key=d9c8884535ae82504c4962ce47a4cae4"></script>--%>
<%--<script type="text/javascript" src="http://mmmap15.longdo.com/mmmap/mmmap.php?key=facc727173929e3e8ead17e04f1379c7"></script>--%>
    

    <%--        <style type="text/css">
            #mmMapDiv{
                position:absolute;
            }
        </style> --%>

    <script type="text/javascript">
    var mmmap;
    var VMid;
    var obj = new clsAjax();
    var markArray = new Array();
    
    function initMap() {
        var mmmap_div = document.getElementById("mmMapDiv");
        mmmap = new MMMap(mmmap_div, 13.6758888, 100.54613888, 8, "normal");
        //mmmap.showOOITag("hospital");
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
        createMarker();
    }
    
        function createMarker() {

        //document.getElementById('mmMapDiv').innerHTML = "loading...";
        obj.create();
        obj.url = "Longdo_Data.aspx";
        obj.method = "post";
        //obj.addParam("emp_id", document.getElementById('data').value);
        //obj.addParam("EMP_ID", "249987");
        obj.function_name = "loaddata()";
        obj.send();
    }
    
        function loaddata() {
        //alert(obj.responseText)
        var jsonobj = eval(obj.responseText);
              
        for (i = 0; i < jsonobj.length; i++) {
            markArray[i] = createUserDivImage(jsonobj[i].Lat, jsonobj[i].Lng,"Images/red_button_16.gif","Request Id:"+jsonobj[i].Req_Id,testclick);
        }
    }
    
    //function createUserDivImage เพื่อสร้าง user-defined div ที่มีรูปภาพอยู่ภายใน
            function createUserDivImage(latitude, longitude, imageURL, description, onClickHandle){
                //สร้าง div element
                var divElement = document.createElement("div");
                divElement.onclick = onClickHandle;
                divElement.setAttribute("latitude",latitude);
                divElement.setAttribute("longitude",longitude);
                //สร้าง img element
                var imgElement = document.createElement("img");
                imgElement.setAttribute("src", imageURL);
                divElement.appendChild(imgElement);
                // **** เรียกใช้ method drawCustomDiv ของ map object (mmmap) เพื่อวาด user-defined div ลงบนแผนที่
                //และเก็บค่า id ของ user-defined div ไว้ในตัวแปร userDivId
                var userDivId = mmmap.drawCustomDiv(divElement,latitude, longitude,description);
                return userDivId;
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
        mmmap.setMouseMoveHandlerNoDelay(f);
        //mmmap.setMouseDownHandler(f);
        
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





    function AddMark(lat,lng) {
                   // alert(lat);
                    //alert(lng);
                    //mmmap.moveTo(lat, lng);
        var truck = document.createElement('div');
        truck.innerHTML = '<img src="Images/red_button_16.gif">';
        //mmmap.drawCustomDiv(truck, mmmap.centerLat(), mmmap.centerLong(), "Current Position");
        //VMid = mmmap.createMarker(mmmap.centerLat(), mmmap.centerLong(), '', '');
        mmmap.drawCustomDiv(truck, lat, lng, "Current Position");
        truck.onclick = testclick;
        VMid = mmmap.createMarker(lat, lng, '', '');
    }
    
    function testclick()​
    {
        var popup_params = {
                link : "http://longdo.com", 
                width : 350, 
                height: 300,
                fixpopupsize : true 
                // if true, the width and height will be exactly as given, otherwise they will be LESS THAN OR EQUAL to the given values
        };
      mmmap.showPopUp(this.latitude, this.longitude, "what is this?", "this is a pop-up",popup_params);
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
<body onload="initMap();" style="margin-left: 0; margin-top: 0;">
    <form id="form1" runat="server">
    <div id="mmMapDiv">
    </div>
    Lat :&nbsp;
    <asp:TextBox ID="TxtLat" runat="server" MyClintID="TxtLat"></asp:TextBox>
    <br />
    Lng :
    <asp:TextBox ID="TxtLng" runat="server" MyClintID="TxtLng"></asp:TextBox>
    <br />
    <input type="button" id="btnAddMark" value="Create New Marker" onclick="btnAddMark_onclick()" />
    <input type="button" id="btnAddMark0" value="Delete Marker" onclick="removeMarker()" />
    <asp:Button ID="BtnOk" runat="server" Text="Ok" />
    </form>
</body>
</html>
