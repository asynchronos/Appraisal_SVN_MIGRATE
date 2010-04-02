<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Search_Collateral.aspx.vb"
    Inherits="Search_Collateral" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register Src="UserControl_Dynamic_Field.ascx" TagName="UserControl_Dynamic_Field"
    TagPrefix="uc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

    <script src="http://maps.google.com/maps?file=api&amp;v=2.x&amp;key=ABQIAAAA2pTpsfNw5p2cqy7r1ODOYhQ8tiLEqIyOFitEP16Hz4nJoYb9TRQ86f7bOrH9e2vS_KPstvn2ELik-Q" 
            type="text/javascript"></script>
<%--    <script src="http://maps.google.com/maps?file=api&amp;v=2.x&amp;key=ABQIAAAAzr2EBOXUKnm_jVnk0OJI7xSosDVG8KKPE1-m51RBrvYughuyMxQ-i1QfUnH94QxWIa6N4U6MouMmBA" 
            type="text/javascript"></script>   --%>  

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        div.demo
        {
            width: auto;
            float: left;
            padding: 10px;
            margin: 0px;
            border: solid black 1px;
            font-size: small;
        }
        .style1
        {
        }
        .caption, table caption
        {
            background-color: #aaa;
            background-image: url('images/tilebg_tablecaption.gif');
            color: #000;
            font-size: 16pt;
            font-weight: bold;
            border: 0;
            border-bottom: solid 1px #737373;
            white-space: nowrap;
            text-align: center;
        }
        .divCol{
	    font-weight:bold;
	    float:left; 
	    width:140px;
	    text-align:left;
	    margin-right:30px; 
	    white-space:nowrap;
        }
        .modalBox {
	        background-color : #f5f5f5;
	        border-width: 3px;
	        border-style: solid;
	        border-color: Blue;
	        padding: 3px;
        }
        .modalBox caption {
	        background-image: url(images/window_titlebg.gif);
	        background-repeat:repeat-x;
        }        
        .style4
        {
            width: 100%;
        }
        .style5
        {
            width: 463px;
        }
        .style6
        {
            width: 85px;
        }
        .style7
        {
            width: 240px;
        }
    </style>

    <script src="Js/jquery.js" type="text/javascript"></script>

    <script src="Js/common.js" type="text/javascript"></script>

    <link href="CSS/popupstyle.css" rel="stylesheet" type="text/css" />

    <script type="text/javascript">
        var map;
        //var gmarkers = [];
        
        function onCancel() {

        }
        function onOk() {
        }

        function initialize() {
            if (GBrowserIsCompatible()) {
                var map = new GMap2(document.getElementById("map_canvas"), { size: new GSize(800, 600) });
                map.setCenter(new GLatLng(13.6758888, 100.54613888), 14); 
                map.setUIToDefault();
            }
        }

        function alertMessage(msg) {
            alert('ไม่สามารถดูแผนที่หลักประกันได้เนื่องจาก ' + msg);
        }

        function loadMark_Location_By_Condition(where_condition) {
            //var where_condition = document.getElementById('lblWhere').innerHTML;

            //alert(where_condition);
            //var where_condition2 = document.getElementById('<%=ltlValues.ClientID%>').innerHTML;
            //alert(where_condition2);

            var side_bar_html = "";

            // arrays to hold copies of the markers used by the side_bar
            // because the function closure trick doesnt work there
            var gmarkers = [];

            // create the map
            var map = new GMap2(document.getElementById("map_canvas"), { size: new GSize(800, 600) });

            var customUI = map.getDefaultUI();
            customUI.controls.scalecontrol = true;

            map.setUI(customUI);
            var wherecondition = where_condition
            loadMark(wherecondition) // โหลดครั้งแรก

            function loadMark(wherecondition) {
                // Read the data from example.xml

                //alert('funtion loadmark');
                //alert(wherecondition);
                var userid = '0';
                var file = "Price3DB.aspx?action=10&where_condition=" + wherecondition;
                GDownloadUrl(file, function(doc) {
                    var xmlDoc = GXml.parse(doc);
                    //alert(xmlDoc);
                    var markers = xmlDoc.documentElement.getElementsByTagName("Table");
                    //alert(markers.length);
                    if ((markers.length) > 0) {
                        for (var i = 0; i < markers.length; i++) {
                            // obtain the attribues of each marker
                            // create the marker
                            var req_id = markers[i].getElementsByTagName("Req_ID")[0];
                            //var temp_aid = markers[i].getElementsByTagName("Temp_AID")[0];
                            var cif = markers[i].getElementsByTagName("Cif")[0];
                            var lat = markers[i].getElementsByTagName("Lat")[0];
                            var lng = markers[i].getElementsByTagName("Lng")[0];
                            //var pricewah = markers[i].getElementsByTagName("PriceWah")[0];
                            //var totalprice = markers[i].getElementsByTagName("Price")[0];
                            //var create_date = markers[i].getElementsByTagName("Create_Date")[0];
                            var nReq_id = req_id.firstChild.nodeValue;
                            //var nTemp_AID = temp_aid.firstChild.nodeValue;
                            //alert(nReq_id);
                            //alert(nHub_id);
                            var ncif = cif.firstChild.nodeValue;
                            //alert(ncif);
                            var nlat = lat.firstChild.nodeValue;
                            //alert(nlat);
                            var nlng = lng.firstChild.nodeValue;
                            //alert(nlng);
                            //var ncreate_date = create_date.firstChild.nodeValue;
                            //alert(ncreate_date);
                            var point = new GLatLng(nlat, nlng);
                            //alert(point);

                            map.setCenter(new GLatLng(nlat, nlng), 9);
                            var marker = createMarker(point, nReq_id, ncif, nlat, nlng, userid);

                            map.addOverlay(marker);
                            gmarkers.push(marker);

                        }
                    } else {
                        //alert('No Data');
                    }

                    // put the assembled side_bar_html contents into the side_bar div
                    //document.getElementById("side_bar").innerHTML = side_bar_html;
                });
            }

            // A function to create the marker and set up the event window
            function createMarker(point, nReq_id, ncif, nlat, nlng, userid) {
                var blueIcon = new GIcon();
                blueIcon.image = "images/colour086.png";
                blueIcon.shadow = "images/fingershadow.png";
                blueIcon.iconSize = new GSize(20, 34);
                blueIcon.shadowSize = new GSize(37, 34);
                blueIcon.iconAnchor = new GPoint(9, 34);
                blueIcon.infoWindowAnchor = new GPoint(9, 2);
                blueIcon.infoShadowAnchor = new GPoint(18, 25);

                var icons = blueIcon;
                var center = point //map.getCenter();
                //var marker = new GMarker(point, { draggable: false });

                //var marker = new GMarker(point, icons);
                var marker = new GMarker(point, { draggable: false });
                GEvent.addListener(marker, "click", function() {
                    //marker.openInfoWindowHtml(html);
                    var newlatlong = marker.getLatLng();
                    var label1 = "Information";
                    var label2 = "Picture";

                    var html2 = "<a href='images/maps_results_logo.gif' target='_blank'><img src='images/maps_results_logo.gif'border='0'></a>";
                    var html = "<b>Marker information</b><br>"
                    html += "<table>";
                    html += "<tr><td>REQ ID :</td><td><b>" + nReq_id + "</b><input type='hidden' value='" + nReq_id + "' id='txtReq_Id' name='txtReq_Id'></td><tr>"
                    html += "<tr><td>CIF :</td><td><b>" + ncif + "</b><input type='hidden' value='" + ncif + "' id='txtCif' name='txtCif'></td><tr>"
                    html += "<tr><td>Lat :</td><td><b>" + nlat + "</b><input type='hidden' value='" + nlat + "' id='txtLat' name='txtLat'></td><tr>";
                    html += "<tr><td>Lng :</td><td><b>" + nlng + "</b><input type='hidden' value='" + nlng + "' id='txtLng' name='txtLng'></td><tr>";
                    //alert(newlatlong.lat());
                    //alert(newlatlong.lng());
                    marker.openInfoWindowTabsHtml([new GInfoWindowTab(label1, html), new GInfoWindowTab(label2, html2)]);
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
        }
        
        function loadMark_Location(Req_Id) {
            
            var reqid = Req_Id;
            //alert(reqid);
            //var file = "Price3DB.aspx?action=9&Req_Id=" + reqid;
            //alert(file);
            var side_bar_html = "";

            // arrays to hold copies of the markers used by the side_bar
            // because the function closure trick doesnt work there
            var gmarkers = [];

            // create the map
            var map = new GMap2(document.getElementById("map_canvas"), { size: new GSize(800, 600) });

            var customUI = map.getDefaultUI();
            customUI.controls.scalecontrol = true;
 
            map.setUI(customUI);
            loadMark()// โหลดครั้งแรก

            function loadMark() {
                // Read the data from example.xml

                //alert('funtion loadmark');
                var userid = '0';
                var file = "Price3DB.aspx?action=9&Req_Id=" + reqid;
                GDownloadUrl(file, function(doc) {
                    var xmlDoc = GXml.parse(doc);
                    //alert(xmlDoc);
                    var markers = xmlDoc.documentElement.getElementsByTagName("Price3_Master");
                    //alert(markers.length);
                    if ((markers.length) > 0) {
                        for (var i = 0; i < markers.length; i++) {
                            // obtain the attribues of each marker
                            // create the marker
                            var req_id = markers[i].getElementsByTagName("Req_Id")[0];
                            var temp_aid = markers[i].getElementsByTagName("Temp_AID")[0];
                            var cif = markers[i].getElementsByTagName("Cif")[0];
                            var lat = markers[i].getElementsByTagName("Lat")[0];
                            var lng = markers[i].getElementsByTagName("Lng")[0];
                            var pricewah = markers[i].getElementsByTagName("PriceWah")[0];
                            var totalprice = markers[i].getElementsByTagName("Price")[0];
                            var create_date = markers[i].getElementsByTagName("Create_Date")[0];
                            var nReq_id = req_id.firstChild.nodeValue;
                            var nTemp_AID = temp_aid.firstChild.nodeValue;
                            //alert(nReq_id);
                            //alert(nHub_id);
                            var ncif = cif.firstChild.nodeValue;
                            //alert(ncif);
                            var nlat = lat.firstChild.nodeValue;
                            //alert(nlat);
                            var nlng = lng.firstChild.nodeValue;
                            //alert(nlng);
                            var ncreate_date = create_date.firstChild.nodeValue;
                            //alert(ncreate_date);
                            var point = new GLatLng(nlat, nlng);
                            //alert(point);

                            map.setCenter(new GLatLng(nlat, nlng), 16);
                            var marker = createMarker(point, nReq_id, nTemp_AID, ncif, nlat, nlng, userid, ncreate_date);

                            map.addOverlay(marker);
                            gmarkers.push(marker);

                        }
                    } else {
                        //alert('No Data');
                    }

                    // put the assembled side_bar_html contents into the side_bar div
                    //document.getElementById("side_bar").innerHTML = side_bar_html;
                });
            }

            // A function to create the marker and set up the event window
            function createMarker(point, nReq_id, nTemp_AID, ncif, nlat, nlng, userid, ncreate_date) {
                var blueIcon = new GIcon();
                blueIcon.image = "images/colour086.png";
                blueIcon.shadow = "images/fingershadow.png";
                blueIcon.iconSize = new GSize(20, 34);
                blueIcon.shadowSize = new GSize(37, 34);
                blueIcon.iconAnchor = new GPoint(9, 34);
                blueIcon.infoWindowAnchor = new GPoint(9, 2);
                blueIcon.infoShadowAnchor = new GPoint(18, 25);

                var icons = blueIcon;
                var center = point //map.getCenter();
                //var marker = new GMarker(point, { draggable: false });

                //var marker = new GMarker(point, icons);
                var marker = new GMarker(point, { draggable: false });
                GEvent.addListener(marker, "click", function() {
                    //marker.openInfoWindowHtml(html);
                    var newlatlong = marker.getLatLng();
                    var label1 = "Information";
                    var label2 = "Picture";

                    var html2 = "<a href='images/maps_results_logo.gif' target='_blank'><img src='images/maps_results_logo.gif'border='0'></a>";
                    var html = "<b>Marker information</b><br>"
                    html += "<table>";
                    html += "<tr><td>REQ ID :</td><td><b>" + nReq_id + "</b><input type='hidden' value='" + nReq_id + "' id='txtReq_Id' name='txtReq_Id'></td><tr>"
                    html += "<tr><td>CIF :</td><td><b>" + ncif + "</b><input type='hidden' value='" + ncif + "' id='txtCif' name='txtCif'></td><tr>"
                    html += "<tr><td>Lat :</td><td><b>" + nlat + "</b><input type='hidden' value='" + nlat + "' id='txtLat' name='txtLat'></td><tr>";
                    html += "<tr><td>Lng :</td><td><b>" + nlng + "</b><input type='hidden' value='" + nlng + "' id='txtLng' name='txtLng'></td><tr>";
                    html += "<tr><td>Lat New :</td><td><input type='text' value='" + newlatlong.lat() + "' id='txtLatnew' name='txtLatnew'></td><tr>";
                    html += "<tr><td>Lng New :</td><td><input type='text' value='" + newlatlong.lng() + "' id='txtLngnew' name='txtLngnew'></td><tr>";
                    html += "<tr><td>วันที่ประเมิน:</td><td> <input type='text' id='txtCreate_Date' value='" + ncreate_date + "' name='txtCreate_Date'></td><tr>"
                    //alert(newlatlong.lat());
                    //alert(newlatlong.lng());
                    marker.openInfoWindowTabsHtml([new GInfoWindowTab(label1, html), new GInfoWindowTab(label2, html2)]);
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
        }
    </script>

</head>
<body onunload="GUnload()" style="margin-left: 0; margin-top: 0;">
    <form id="form1" runat="server">
    <asp:ScriptManager ID="sm1" runat="server" />
    <table border="0" cellspacing="0" cellpadding="0" width="100%" style="height: 80px;">
        <tr>
            <td align="left" style="background-color: #FFC20E" class="style1">
                <img alt="" src="Images/logo.jpg" style="" /><br />
            </td>
            <td style="height: 50px; background-color: #FFC20E;" valign="top">
                &nbsp;
            </td>
        </tr>
    </table>
    
    <%--Collateral Location Popup Display--%>
    <asp:Button id="btnShowPopup" runat="server" style="display:none" />
    <cc1:ModalPopupExtender ID="mdlPopup" runat="server" TargetControlID="btnShowPopup" PopupControlID="pnlCities"
        CancelControlID="btnClose" BackgroundCssClass="modalBackground"></cc1:ModalPopupExtender>
     
    <asp:Panel ID="pnlCities" runat="server" CssClass="modalBox" Style="display: none;" Width="800px">
		<asp:Panel ID="Panel2" runat="server" CssClass="caption" Style="margin-bottom: 0px; cursor: hand;">
			แผนที่หลักประกัน</asp:Panel>
		<asp:HiddenField ID="HiddenField1" runat="server" Value="-1" />
        <div id="map_canvas"  style="width: 640px; height: 340px; position: relative;"></div>
        <div style="white-space: nowrap; text-align: center;">
            <asp:Button ID="btnClose" runat="server" Text="Close" Width="50px" />
        </div>
    </asp:Panel>
    
    <asp:UpdatePanel ID="up1" runat="server" UpdateMode="Conditional">
        <Triggers>
			<asp:AsyncPostBackTrigger ControlID="GridView1" EventName="Sorting" />
		</Triggers>
        <ContentTemplate>
            <div class="demo">
                <asp:PlaceHolder ID="ph1" runat="server" />
                <asp:Button ID="btnAdd" runat="server" Text="กด เพื่อเลือกเงื่อนไขการค้นหา" />
                <br />
                <br />
                <asp:Literal ID="ltlValues" runat="server" />
                <br />
                <asp:Button ID="btnDisplayValues" runat="server" Text="ค้นหา ข้อมูลการประเมิน" />
                <br />
                <br />
                <br />
                <asp:Label ID="Label1" runat="server" Text="กรองข้อมูลจากเงื่อนไขที่ค้นหา" 
                    style="font-weight: 700; color: #3333CC"></asp:Label>
                    <table class="style4">
                    <tr>
                        <td class="style5">
                            <asp:RadioButtonList ID="RadioButtonList1" runat="server" AutoPostBack="True" 
                                RepeatDirection="Horizontal" Style="font-size: small" Width="405px">
                                <asp:ListItem Selected="True" Value="0">ทั้งหมด</asp:ListItem>
                                <asp:ListItem Value="1">ที่ดินเปล่า</asp:ListItem>
                                <asp:ListItem Value="2">ที่ดิน + สิ่งปลูกสร้าง</asp:ListItem>
                                <asp:ListItem Value="3">คอนโด/ห้องชุด</asp:ListItem>
                            </asp:RadioButtonList>
                        </td>
                        <td class="style6">
                            เลือกช่วงราคา</td>
                        <td class="style7">
                            <asp:DropDownList ID="ddlPrice_Length" runat="server" AutoPostBack="True">
                                <asp:ListItem Value="0">ทุกช่วงราคา</asp:ListItem>
                                <asp:ListItem Value="1">0 บาท  - 500,000 บาท</asp:ListItem>
                                <asp:ListItem Value="3">500,001 บาท  - 1,000,000 บาท</asp:ListItem>
                                <asp:ListItem Value="3">1,000,001 บาท  - 3,000-000 บาท</asp:ListItem>
                                <asp:ListItem Value="4">3,000,001 บาท  - 5,000-000 บาท</asp:ListItem>
                                <asp:ListItem Value="5">5,000,001 บาท  - 10,000-000 บาท</asp:ListItem>
                                <asp:ListItem Value="6">มากกว่า 10,000,000 บาท</asp:ListItem>
                            </asp:DropDownList>
                        </td>
                        <td>
                            <asp:Button ID="btnMapLocationAll" runat="server" Text="แผนที่หลักประกัน" 
                                Enabled="False" />
                        </td>
                    </tr>
                </table>
                <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataSourceID="SqlDataSource_SearchCondition"
                    Width="100%" BackColor="White" BorderColor="#E7E7FF" BorderStyle="None" BorderWidth="1px"
                    CellPadding="3" GridLines="Horizontal" AllowPaging="True" Style="font-size: small"
                    OnSelectedIndexChanging="GridView1_SelectedIndexChanging" 
                    DataKeyNames="Req_Id">
                    <RowStyle BackColor="#E7E7FF" ForeColor="#4A3C8C" />
                    <Columns>
                        <asp:TemplateField HeaderText="Req ID" SortExpression="Req_ID">
                            <ItemTemplate>
                                <asp:Label ID="lblReq_Id" runat="server" Text='<%# Bind("Req_ID") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="Cif" HeaderText="Cif" SortExpression="Cif" />
                        <asp:BoundField DataField="Cifname" HeaderText="Cifname" ReadOnly="True" SortExpression="Cifname" />
                        <asp:TemplateField HeaderText="Status_Name">
                            <ItemTemplate>
                                <asp:HiddenField ID="HiddenStatus_Id" runat="server" Value='<%# Bind("Status_Id") %>' />
                                <asp:Label ID="lblStatus_Name" runat="server" Text='<%# Bind("Status_Name") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="AID" HeaderText="AID" SortExpression="AID" />
<%--                        <asp:TemplateField HeaderText="Lat">
                            <ItemTemplate>
                                <asp:Label ID="lblLat" runat="server" Text='<%# Bind("Lat") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Lng">
                            <ItemTemplate>
                                <asp:Label ID="lblLng" runat="server" Text='<%# Bind("Lng") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>  --%>                                                
                        <asp:BoundField DataField="Appraisal_Price" HeaderText="Appraisal_Price" ReadOnly="True"
                            SortExpression="Appraisal_Price" />
                        <asp:BoundField DataField="Road" HeaderText="Road" SortExpression="Road" />
                        <asp:BoundField DataField="Tumbon" HeaderText="Tumbon" SortExpression="Tumbon" />
                        <asp:BoundField DataField="Amphur" HeaderText="Amphur" SortExpression="Amphur" />
                        <asp:BoundField DataField="Province_Name" HeaderText="Province_Name" SortExpression="Province_Name" />                     
                        <asp:BoundField DataField="Subcolltype_Name" HeaderText="Subcolltype_Name" SortExpression="Subcolltype_Name" />
                        <asp:TemplateField HeaderText="">
                            <ItemStyle Width="25px" />
                            <ItemTemplate>
                                <asp:ImageButton ID="imgLocation" runat="server" ImageUrl="~/Images/viewmap.jpg"
                                    Height="22px" Width="22px" ToolTip="แผนที่หลักประกัน" 
                                    CommandName="Select" />
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                    <FooterStyle BackColor="#B5C7DE" ForeColor="#4A3C8C" />
                    <PagerStyle BackColor="#E7E7FF" ForeColor="#4A3C8C" HorizontalAlign="Right" />
                    <SelectedRowStyle BackColor="#738A9C" Font-Bold="True" ForeColor="#F7F7F7" />
                    <HeaderStyle BackColor="#4A3C8C" Font-Bold="True" ForeColor="#F7F7F7" />
                    <AlternatingRowStyle BackColor="#F7F7F7" />
                </asp:GridView>
            </div>
            <br />
            <br />

        </ContentTemplate>
    </asp:UpdatePanel>
    

    <!--The text value determines how many items are initially displayed on the page-->
    <asp:Literal ID="ltlCount" runat="server" Text="0" Visible="false" />
    <asp:Literal ID="ltlRemoved" runat="server" Visible="false" />
    <asp:Label ID="lblWhere" runat="server"></asp:Label>
    <asp:Label ID="lblWhere2" runat="server"></asp:Label>
    <asp:SqlDataSource ID="SqlDataSource_SearchCondition" runat="server" ConnectionString="<%$ ConnectionStrings:AppraisalConn %>"
        SelectCommand="GET_APPRAISAL_SEARCH" SelectCommandType="StoredProcedure">
        <SelectParameters>
            <asp:ControlParameter ControlID="lblWhere2" Name="WhereString" PropertyName="Text"
                Type="String" />
        </SelectParameters>
    </asp:SqlDataSource>
    
  
    <asp:Label ID="lblReqId" runat="server"></asp:Label>
 
    </form>
</body>
</html>
