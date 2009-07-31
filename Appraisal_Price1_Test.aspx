<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="Appraisal_Price1_Test.aspx.vb" Inherits="Test_Appraisal_Price1_Test" %>

<%@ Register assembly="Mytextbox" namespace="Mytextbox" tagprefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
<script src="Js/jquery.js" type="text/javascript"></script>
<script src="Js/common.js" type="text/javascript"></script>
    <style type="text/css">
        .style1
        {
            width: 78%;
        }
        .style2
        {
            width: 208px;
        }
        .style3
        {
            width: 208px;
            height: 25px;
        }
        .style4
        {
            height: 25px;
        }
        .style5
        {
            width: 873px;
        }
    </style>
            <style type="text/css">
            #mmMapDiv{
                position:absolute;
            }
        </style>
<script type="text/javascript" 
	src="http://mmmap15.longdo.com/mmmap/mmmap.php?key=d9c8884535ae82504c4962ce47a4cae4">
</script>
    
<script type="text/javascript">
    var mmmap;
    function initMap() {
        //var div_map = getEleByProperty("div", "MyClintID", "mmMapDiv");


        var mmmap_div = document.getElementById("mmMapDiv");
        mmmap = new MMMap(mmmap_div, 13.6758888, 100.54613888, 3, "normal");
        //alert(mmmap.centerLat());
        //alert(mmmap.centerLong());

        //เรียกใช้ function adJustMapSize ให้ปรับขนาดของแผนที่
        //ให้พอดีกับหน้าต่าง browser
        adJustMapSize();

        //ผูก function adJustMapSize เข้ากับ event onresize
        //ของ window ซึ่งก็คือ browser นั่นเอง
        window.onresize = adJustMapSize;

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
        var marker_id = mmmap.createMarker(mmmap.mouseCursorLat(), mmmap.mouseCursorLong(),'','');
    }
    
    function f() {
        //alert(mmmap.centerLat());
        //alert(mmmap.centerLong());
        var txtlat = getEleByProperty("input", "MyClintID", "TxtLat");
        var txtlng = getEleByProperty("input", "MyClintID", "TxtLng");
        txtlat.value = mmmap.mouseCursorLat();
        txtlng.value = mmmap.mouseCursorLong();
        //alert("Current location is " + latitude + ", " + longitude);
    };
    
</script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<br />
<br />
    <table width="100%">
        <tr>
            <td class="style5">
    <table class="style1">
        <tr>
            <td class="style2">
                Req ID</td>
            <td>
                <asp:Label ID="lblReq_Id" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="style2">
                Hub ID</td>
            <td>
                <asp:Label ID="lblHub_Id" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="style2">
                Cif</td>
            <td>
                <asp:Label ID="lblCif" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="style2">
                Lat</td>
            <td>
                <asp:TextBox ID="TxtLat" runat="server" MyClintID="TxtLat"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="style3">
                Lng</td>
            <td class="style4">
                <asp:TextBox ID="TxtLng" runat="server" MyClintID="TxtLng"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="style2">
                ตรว.ละ / ตรม ละ.</td>
            <td>

                                            <cc1:mytext runat="server" AllowUserKey="num_Numeric" EnableTextAlignRight="True" Width="120px" ID="txtPriceWah" MyClintID="txtPriceWah" onkeyup="CalSection_Land(this,event);">0</cc1:mytext>

                                        &nbsp;บาท</td>
        </tr>
        <tr>
            <td class="style2">
                ราคา</td>
            <td>
                                            <cc1:mytext runat="server" AutoCurrencyFormatOnKeyUp="True" AllowUserKey="num_Numeric" EnableTextAlignRight="True" Width="120px" ID="txtTotal" MyClintID="txtTotal">0</cc1:mytext>

                                        &nbsp;บาท</td>
        </tr>
        <tr>
            <td class="style2">
                รูปแผนที่หลักประกัน</td>
            <td>
   <input id="File1" type="file" runat="server" size="60" /></td>
        </tr>
        <tr>
            <td class="style2">
                &nbsp;</td>
            <td>
                <asp:Button ID="BtnConfirm" runat="server" Text="กำหนดราคาที่ 1" />
            &nbsp;<input type="button" id="btnAddMark" value="Create New Marker" onclick="btnAddMark_onclick()" /></td>
        </tr>
    </table>
            </td>
            <td valign="top">

            </td>
        </tr>
    </table>
                <div id="mmMapDiv" MyClintID="mmMapDiv" >
                </div>
<script type="text/javascript">
    initMap();
</script>
</asp:Content>

