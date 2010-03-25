<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="Appraisal_Price2_New.aspx.vb" Inherits="Appraisal_Price2_New" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1"  %>
<%@ Register assembly="Mytextbox" namespace="Mytextbox" tagprefix="cc1" %>
<%@ Register assembly="Mytextbox" namespace="Mytextbox" tagprefix="cc11" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">

    <script src="Js/jquery.js" type="text/javascript"></script>
<script src="Js/common.js" type="text/javascript"></script>
    <style type="text/css">
         .GrayedOut
        { 
        background-color:Gray;
        filter:alpha(opacity=95);
        -moz-opacity:0.5;
        -khtml-opacity: 0.5;
        opacity: 0.5;        
        }
        .ModalPopup
        { 
        background-color:transparent;
        background: url('media/popup-bg.gif') no-repeat;
        background-position:center;
        padding:0;
        border: none;
        }
        .txtBox
        { 
        border:none;
         font-size:medium;
         font-weight:normal;
         background-color:Silver;
        }   
        .modalBackground 
        {
            background-color:Gray;
            filter:alpha(opacity=60);
            opacity:0.60;         
        }
        .updateProgress
        {
            border-width:1px; 
            border-style:solid; 
            background-color:#FFFFFF; 
            position:absolute; 
            width:350px; 
            height:50px;    
        }
        .updateProgressMessage
        {
            margin:3px; 
            font-family:Trebuchet MS; 
            font-size:small; 
            vertical-align: middle;
        }  
        .style1{
        }      
        .style2
        {
            font-weight: bold;
            text-decoration: underline;
        }
        .style3
        {
            text-decoration: underline;
            font-weight: 700;
        }
        .tableleft
        {
         text-align: left;
        }
        </style>
    <script type="text/javascript">
        var _popup;
        var _land;
        var _building;
        var _SubCollType;
        var _ProvinceCode;
        var _radiobutton;
        var _land_row;
        var _build_row;
        var _condo_row;
        var _reqId;
        var _hubId;
        var _create_user;

        function saveLand() {
            var approveId = document.getElementById('<%=HiddenField_ApproveId.ClientID%>').value;
            var oJSON_DataTable_DataHolder = document.getElementById('<%=JSON_DataTable_Land.ClientID%>');
            var oJSON = eval("(" + oJSON_DataTable_DataHolder.value + ")");
            var oHTMLTABLE = document.createElement("table");
            var MyArray = new Array();
            oHTMLTABLE.border = 1;

            for (var i = 0; i < oJSON.TABLE[0].ROW.length; i++) {
                var oTR = oHTMLTABLE.insertRow(i);

                for (var j = 0; j < oJSON.TABLE[0].ROW[i].COL.length; j++) {
                    var oTD = oTR.insertCell(j);

                    oTD.innerHTML = oJSON.TABLE[0].ROW[i].COL[j].DATA;
                    MyArray[j] = oTD.innerHTML
                    //alert(MyArray[j]);
                }
                //                    alert('Req_Id = '+ MyArray[0]);
                //                    alert('Hub_Id = ' + MyArray[1]);
                //                    alert('Colltype_Id = ' + MyArray[2]);
                //                    alert('Colltype_Name = ' + MyArray[3]);
                //                    alert('ProvinceCode = ' + MyArray[4]);
                //                    alert('ProvinceName = ' + MyArray[5]);
                //                    alert('⩹��Ţ��� = ' + MyArray[6]);
                //                    alert('Rai = ' + MyArray[7]);
                //                    alert('Ngan = ' + MyArray[8]);
                //                    alert('Wah = ' + MyArray[9]);
                //                    alert('Sub Unit ID = ' + MyArray[10]);
                //                    alert('Sub Unit Name= ' + MyArray[11]);
                //                    alert('�Ҥҵ��˹��� = ' + MyArray[12]);
                //                    alert('�Ҥ���� = ' + MyArray[13]);
                PageMethods.ValidateSaveLand(MyArray[0], MyArray[1], MyArray[2], MyArray[6], MyArray[4], MyArray[7], MyArray[8], MyArray[9], MyArray[10], MyArray[12], MyArray[13], approveId, this.callback_asset);
            }
        }

        function saveBuilding() {
            //alert('Begin save building');
            _build_row = document.getElementById('<%=lblBuildingRow.ClientID%>').innerHTML;
            if (_build_row == '0') {
                //alert('No Building Data to save');
            }
            else {
                    _reqId = document.getElementById('<%=lblReq_Id.ClientID%>').innerHTML;
                    //alert(_reqId);
                    _hubId = document.getElementById('<%=lblHub_Id.ClientID%>').innerHTML;
                    //alert(_hubId);
                    _SubCollType = document.getElementById('<%=DDLSubCollType.ClientID%>').value;
                    //alert(_SubCollType);
                    _ProvinceCode = document.getElementById('<%=ddlProvince.ClientID%>').value;
                    var approveId = document.getElementById('<%=HiddenField_ApproveId.ClientID%>').value;
                    var oJSON_DataTable_DataHolder = document.getElementById('<%=JSON_DataTable_Building.ClientID%>');
                    //alert(oJSON_DataTable_DataHolder);
                    var oJSON = eval("(" + oJSON_DataTable_DataHolder.value + ")");
                    //alert(oJSON).value;           
                    var oHTMLTABLE = document.createElement("table");
                    //alert(oHTMLTABLE);
                    var MyArray = new Array();

                    oHTMLTABLE.border = 1;
                    //alert('Before Start Loop save building');
                    //alert(oJSON.TABLE[0].ROW[i].COL.length);
                    for (var i = 0; i < oJSON.TABLE[0].ROW.length; i++) {
                        //alert(i);
                        var oTR = oHTMLTABLE.insertRow(i);

                        for (var j = 0; j < oJSON.TABLE[0].ROW[i].COL.length; j++) {
                            var oTD = oTR.insertCell(j);

                            oTD.innerHTML = oJSON.TABLE[0].ROW[i].COL[j].DATA;
                            //alert(oTD.innerHTML);
                            MyArray[j] = oTD.innerHTML;
                        }
//                                            alert('Colltype_Id ' + MyArray[0]);
//                                            alert('Colltype_Name ' + MyArray[1]);
//                                            alert('Chanode ' + MyArray[2]);
//                                            alert('Build_No ' + MyArray[3]);
//                                            alert('Area ' + MyArray[4]);
//                                            alert('Unit_Price ' + MyArray[5]);
//                                            alert('Value_Price ' + MyArray[6]);
//                                            alert('Percent_Finish ' + MyArray[7]);
//                                            alert('Finish_Price ' + MyArray[8]);
//                                            alert('Age ' + MyArray[9]);
                        //                    alert('Percent1 ' + MyArray[10]);
                        //                    alert('Percent2 ' + MyArray[11]);
                        //                    alert('Percent3 ' + MyArray[12]);
                        //                    alert('Total_Percent ' + MyArray[13]);
                        //                    alert('Deteriorate ' + MyArray[14]);
                        //                    alert('Total_Building ' + MyArray[15]);
                                                PageMethods.ValidateSaveDataBuilding(_reqId, _hubId, MyArray[0], MyArray[3], _ProvinceCode, MyArray[2], MyArray[4], MyArray[5], MyArray[6], MyArray[9], MyArray[10], MyArray[11], MyArray[12], MyArray[14], MyArray[7], MyArray[8], approveId, this.callback_asset);
                    }
                    alert('end save building');
                    }
        }

        function saveCondo() {
            _condo_row = document.getElementById('<%=lblCondoRow.ClientID%>').innerHTML;
            if (_condo_row == '0') {
                alert('No Condo Data to save');
            }
            else {
                _reqId = document.getElementById('<%=lblReq_Id.ClientID%>').innerHTML;
                _hubId = document.getElementById('<%=lblHub_Id.ClientID%>').innerHTML;
                _create_user = document.getElementById('<%=HiddenField_ApproveId.ClientID%>').value;
                var oJSON_DataTable_DataHolder = document.getElementById('<%=JSON_DataTable_Condo.ClientID%>');
                var oJSON = eval("(" + oJSON_DataTable_DataHolder.value + ")");
                var oHTMLTABLE = document.createElement("table");
                var MyArray = new Array();

                oHTMLTABLE.border = 1;

                for (var i = 0; i < oJSON.TABLE[0].ROW.length; i++) {
                    var oTR = oHTMLTABLE.insertRow(i);

                    for (var j = 0; j < oJSON.TABLE[0].ROW[i].COL.length; j++) {
                        var oTD = oTR.insertCell(j);

                        oTD.innerHTML = oJSON.TABLE[0].ROW[i].COL[j].DATA;
                        //alert(oTD.innerHTML);
                        MyArray[j] = oTD.innerHTML;
                    }
                    PageMethods.ValidateSaveDataCondo(_reqId, _hubId, MyArray[0], MyArray[1], MyArray[2], MyArray[3], MyArray[4], MyArray[5], MyArray[6], MyArray[7], _create_user, this.callback_asset);
                }
            } 
        } 

            function onOk() {
                document.getElementById('<%=lit_Status.ClientID%>').value = 'You clicked Ok.';
                document.getElementById('<%=lblMessageNotice_Building.ClientID%>').innerHTML = '';
            }

            function onOk_Building() {
                document.getElementById('<%=lit_Status.ClientID%>').value = 'You clicked Ok.';
//                _reqId = document.getElementById('<%=lblReq_Id.ClientID%>').innerHTML;
//                _hubId = document.getElementById('<%=lblHub_Id.ClientID%>').innerHTML;
//                var approveId = document.getElementById('<%=lblApprove_Id.ClientID%>').innerHTML;
//                var oJSON_DataTable_DataHolder = document.getElementById('<%=JSON_DataTable_Building.ClientID%>');
//                var oJSON = eval("(" + oJSON_DataTable_DataHolder.value + ")");
//                var oHTMLTABLE = document.createElement("table");
//                var MyArray = new Array();
//                
//                oHTMLTABLE.border = 1;

//                for (var i = 0; i < oJSON.TABLE[0].ROW.length; i++) {
//                    var oTR = oHTMLTABLE.insertRow(i);

//                    for (var j = 0; j < oJSON.TABLE[0].ROW[i].COL.length; j++) {
//                        var oTD = oTR.insertCell(j);

//                        oTD.innerHTML = oJSON.TABLE[0].ROW[i].COL[j].DATA;
//                        //alert(oTD.innerHTML);
//                        MyArray[j] = oTD.innerHTML 
//                    }
//                    alert('Colltype_Id ' + MyArray[0]);
//                    alert('Colltype_Name ' + MyArray[1]);
//                    alert('Chanode ' + MyArray[2]);
//                    alert('Build_No ' + MyArray[3]);
//                    alert('Area ' + MyArray[4]);
//                    alert('Unit_Price ' + MyArray[5]);
//                    alert('Value_Price ' + MyArray[6]);
//                    alert('Percent_Finish ' + MyArray[7]);
//                    alert('Finish_Price ' + MyArray[8]);
//                    alert('Age ' + MyArray[9]);
//                    alert('Percent1 ' + MyArray[10]);
//                    alert('Percent2 ' + MyArray[11]);
//                    alert('Percent3 ' + MyArray[12]);
//                    alert('Total_Percent ' + MyArray[13]);
//                    alert('Deteriorate ' + MyArray[14]);
//                    alert('Total_Building ' + MyArray[15]);
//                    PageMethods.ValidateSaveDataBuilding(_reqId, _hubId, MyArray[0], MyArray[2], MyArray[4], MyArray[7], MyArray[8], MyArray[9], MyArray[10], MyArray[12], MyArray[13], approveId, this.callback_asset);
//                }
            }

            function onOk_Condo() {
                document.getElementById('<%=lit_Status.ClientID%>').value = 'You clicked Ok.';
//                _reqId = document.getElementById('<%=lblReq_Id.ClientID%>').innerHTML;
//                _hubId = document.getElementById('<%=lblHub_Id.ClientID%>').innerHTML;
//                _create_user = document.getElementById('<%=lblApprove_Id.ClientID%>').innerHTML;
//                var oJSON_DataTable_DataHolder = document.getElementById('<%=JSON_DataTable_Condo.ClientID%>');
//                var oJSON = eval("(" + oJSON_DataTable_DataHolder.value + ")");
//                var oHTMLTABLE = document.createElement("table");
//                var MyArray = new Array();

//                oHTMLTABLE.border = 1;

//                for (var i = 0; i < oJSON.TABLE[0].ROW.length; i++) {
//                    var oTR = oHTMLTABLE.insertRow(i);

//                    for (var j = 0; j < oJSON.TABLE[0].ROW[i].COL.length; j++) {
//                        var oTD = oTR.insertCell(j);

//                        oTD.innerHTML = oJSON.TABLE[0].ROW[i].COL[j].DATA;
//                        //alert(oTD.innerHTML);
//                        MyArray[j] = oTD.innerHTML
//                    }
//                    PageMethods.ValidateSaveDataCondo(_reqId, _hubId, MyArray[0], MyArray[1], MyArray[2], MyArray[3], MyArray[4], MyArray[5], MyArray[6], MyArray[7], _create_user, this.callback_asset);
//                }
            }              
                        
            function onCancel() {
                document.getElementById('<%=lit_Status.ClientID%>').value = 'You clicked Cancel.';
                document.getElementById('<%=lblMessageNotice_Building.ClientID%>').innerHTML = '';
        }
            
            function validate() {
                //  find the popup behavior
                var _data = new Array();
                var _appraisal_type;
                //var colltype = document.getElementById('<%=lblCollType.ClientID%>').innerHTML;
                _popup = $find('mdlPopupBehavior');                
                if (document.getElementsByName("ctl00$ContentPlaceHolder1$rdbAppraisal_Type")[0].checked == true) {
                    alert('�ع'); 
                    // show the popup
                    this._popup.show();
                    // _land = $get('txtLandBehavior');
                    _land_row = document.getElementById('<%=lblLandRow.ClientID%>').innerHTML;
                    _build_row = document.getElementById('<%=lblBuildingRow.ClientID%>').innerHTML;
                    _appraisal_type = '2';
                    
                    if (_land_row == '0' || _build_row == '0') {
                        //��Ǩ�ͺ����բ����Ţͧ���Թ ��� ��觻�١���ҧ �������
                        alert('�س�������������´�������ҤҢͧ���Թ ���� ��觻�١���ҧ');
                        PageMethods.Cancel(this.callback);
                    }
                    else {
                        //�觢������ Save
                        //******************Call Function ************************************
                        //saveLand();
                        //saveBuilding()
                        //********************************************************************

                        _data[0] = document.getElementById('<%=lblReq_Id.ClientID%>').innerHTML;
                        //alert('Req_Id ' + _data[0]);
                        _data[1] = document.getElementById('<%=lblHub_Id.ClientID%>').innerHTML; 
                        //alert('Hub_Id ' + _data[1]);
                        _data[2] = document.getElementById('<%=lblCif.ClientID%>').innerHTML;
                        //alert('Cif ' + _data[2]);
                        _data[3] = document.getElementById('<%=txtLand.ClientID%>').value;
                        //alert('Land ' + _data[3]);
                        _data[4] = document.getElementById('<%=txtBuilding.ClientID%>').value;
                        //alert('Building ' + _data[4]);
                        _data[5] = document.getElementById('<%=txtCondo.ClientID%>').value;
                        //alert('Condo ' + _data[5]);
                        _data[6] = document.getElementById('<%=HiddenField_ApproveId.ClientID%>').value;
                        //alert('User Create ' + _data[6]);
                        //alert('Appraisal_type ' + _appraisal_type);                          
                        var IndexValueComment = $get('<%=ddlComment.ClientID %>').selectedIndex;
                        _data[7] = $get('<%=ddlComment.ClientID %>').options[IndexValueComment].value;

                        //alert('Comment ' + _data[7]);                        
                        var IndexValueWarning = $get('<%=ddlWarning.ClientID %>').selectedIndex;
                        _data[8] = $get('<%=ddlWarning.ClientID %>').options[IndexValueWarning].value;
                        //alert('Warning ' + _data[8]);

                        
                        //Call Code behind Web Method
                        PageMethods.ValidateSaveData(_data[0], _data[1], _data[2], _data[3], _data[4], _data[5], _appraisal_type, _data[7], _data[8], _data[6],  this.callback); 
                    }
                }
                else if (document.getElementsByName("ctl00$ContentPlaceHolder1$rdbAppraisal_Type")[1].checked == true) {
                alert('��˹��Ҥ��Ըյ�Ҵ ');
                //document.getElementById('<%=txtLand.ClientID%>').value = '0.00';
                    // show the popup
                    this._popup.show();
                    _land_row = document.getElementById('<%=lblLandRow.ClientID%>').innerHTML;
                    _build_row = document.getElementById('<%=lblBuildingRow.ClientID%>').innerHTML;
                    _condo_row = document.getElementById('<%=lblCondoRow.ClientID%>').innerHTML;
                    _appraisal_type = '1';
                    //******************Call Function ************************************
                    //saveLand();
                    //saveBuilding();
                    //saveCondo();
                    //********************************************************************

                    _data[0] = document.getElementById('<%=lblReq_Id.ClientID%>').innerHTML;
                    _data[1] = document.getElementById('<%=lblHub_Id.ClientID%>').innerHTML;
                    _data[2] = document.getElementById('<%=lblCif.ClientID%>').innerHTML;
                    _data[3] = document.getElementById('<%=txtLand.ClientID%>').value;
                    _data[4] = document.getElementById('<%=txtBuilding.ClientID%>').value;
                    _data[5] = document.getElementById('<%=txtCondo.ClientID%>').value;
                    _data[6] = document.getElementById('<%=HiddenField_ApproveId.ClientID%>').value;
                    var IndexValueComment = $get('<%=ddlComment.ClientID %>').selectedIndex;
                    _data[7] = $get('<%=ddlComment.ClientID %>').options[IndexValueComment].value;
                    var IndexValueWarning = $get('<%=ddlWarning.ClientID %>').selectedIndex;
                    _data[8] = $get('<%=ddlWarning.ClientID %>').options[IndexValueWarning].value;

                                        //alert('Req_Id ' + _data[0]);
                                        //alert('Hub_Id ' + _data[1]);
                                        //alert('Cif ' + _data[2]);
                                        //alert('Land ' + _data[3]);
                                        //alert('Building ' + _data[4]);
                                        //alert('Condo ' + _data[5]);
                                        //alert('User Create ' + _data[6]);
                                        //alert('Appraisal_type ' + _appraisal_type);                                      
                    //Call Code behind
                    PageMethods.ValidateSaveData(_data[0], _data[1], _data[2], _data[3], _data[4], _data[5], _appraisal_type, _data[7], _data[8], _data[6], this.callback);         
                }
                else {
                    alert('�س��������͡�Ըա������Ҥ�');
                    PageMethods.Cancel(this.callback);
                 }
            }

            function callback(result) {
                //  hide the popup
                this._popup.hide();

                //  let the user know if their credit card was validated
                if (result) {
                    alert('Save data compleate!');
                }
                else {
                    alert('Warning, Save not compleate!');
                }
            }

            function callback_asset(result) {
                //  hide the popup
                this._popup.hide();

                //  let the user know if their credit card was validated
                if (result) {
                    //alert('Save data compleate!');
                }
                else {
                    //alert('Warning, Save not compleate!');
                }
            }

            function CalSection_Land(sender, e) {
                //��ͧ��˹� ��Դ input type MyClintID ����� Control �ͧ���е�Ƿ����� ��Ъ��� Property  Name �ͧ Control ��� � ��͹
                var subunit_array = [0, 1, 1, 400, 1];  //��͸Ժ�� 400 ��� 400 ���., 1 ��� 1 ���.
                var txtrai = getEleByProperty("input", "MyClintID", "txtRai");
                var txtngan = getEleByProperty("input", "MyClintID", "txtNgan");
                var txtwah = getEleByProperty("input", "MyClintID", "txtWah");
                var txtsubunit = getEleByProperty("select", "MyClintID", "ddlSubUnit");  //dropdownlist
                var txtpricewah = getEleByProperty("input", "MyClintID", "txtPriceWah");
                var txtland_Price = getEleByProperty("input", "MyClintID", "txtTotal");

                var unitdiv = subunit_array[txtsubunit.options[txtsubunit.selectedIndex].value];
                //alert(unitdiv);
                var wah_rai = Number(txtrai.value) * 400;
                //alert(wah_rai);
                var wah_ngan = Number(txtngan.value) * 100;
                var wah = Number(txtwah.value);
                var totalwar = wah_rai + wah_ngan + wah;

                var unit_price = Number(txtpricewah.value);

                var land_price = (totalwar * unit_price) / unitdiv;

                //���ʴ��š�Ѻ���Ѻ Textbox �������˹�� Design
                txtland_Price.value = addCommas(land_price);
            }

            function CalSection_Building(sender, e) {
                //��ͧ��˹� ��Դ input type MyClintID ����� Control �ͧ���е�Ƿ����� ��Ъ��� Property  Name �ͧ Control ��� � ��͹
                var building_area = getEleByProperty("input", "MyClintID", "txtBuildingArea");
                var price_per_unit = getEleByProperty("input", "MyClintID", "txtBuildingUnitPrice");
                var txtbuildingPrice = getEleByProperty("input", "MyClintID", "txtBuildingPrice");
                var txtpercent_finish = getEleByProperty("input", "MyClintID", "txtFinishPercent");
                var txtprice_finish = getEleByProperty("input", "MyClintID", "txtPriceNotFinish");
                var txtBuildingAge = getEleByProperty("input", "MyClintID", "txtBuildingAge");
                var txtBuildingPersent1 = getEleByProperty("input", "MyClintID", "txtBuildingPersent1");
                var txtBuildingPersent2 = getEleByProperty("input", "MyClintID", "txtBuildingPersent2");
                var txtBuildingPersent3 = getEleByProperty("input", "MyClintID", "txtBuildingPersent3");
                var txtBuildingTotalDeteriorate = getEleByProperty("input", "MyClintID", "txtBuildingTotalDeteriorate");
                var txtBuildingPriceTotalDeteriorate = getEleByProperty("input", "MyClintID", "txtBuildingPriceTotalDeteriorate");
                var b_area = Number(building_area.value);
                //alert(b_area);
                var pp_unit = Number(price_per_unit.value);
                //alert(pp_unit);
                var percent_finish = Number(txtpercent_finish.value);
                //         alert(percent_finish);
                var buildingAge = Number(txtBuildingAge.value);
                //         alert(buildingAge);
                var BuildingPersent1 = Number(txtBuildingPersent1.value);
                //         alert(BuildingPersent1);
                var BuildingPersent2 = Number(txtBuildingPersent2.value);
                //         alert(BuildingPersent2);
                var BuildingPersent3 = Number(txtBuildingPersent3.value);

                var building_price = b_area * pp_unit;
                var building_price2 = building_price * (percent_finish / 100);
                txtbuildingPrice.value = addCommas(building_price);
                txtprice_finish.value = addCommas(building_price2);
                var percent_total = (buildingAge * BuildingPersent1) - BuildingPersent2 + BuildingPersent3;
                txtBuildingTotalDeteriorate.value = percent_total;
                var BuildingPriceTotalDeteriorate = addCommas(building_price2 * (percent_total / 100));
                txtBuildingPriceTotalDeteriorate.value = addCommas(BuildingPriceTotalDeteriorate);
            }
            
            function CalSection_Condo(sender, e) {
                //��ͧ��˹� ��Դ input type MyClintID ����� Control �ͧ���е�Ƿ����� ��Ъ��� Property  Name �ͧ Control ��� � ��͹
                var building_area = getEleByProperty("input", "MyClintID", "txtArea");
                var price_per_unit = getEleByProperty("input", "MyClintID", "txtUnitPrice");
                var txtCondo_Price = getEleByProperty("input", "MyClintID", "txtCondoPrice");
                var b_area = Number(building_area.value);
                //alert(b_area);
                var pp_unit = Number(price_per_unit.value);
                //alert(pp_unit);
                var Condo_price = b_area * pp_unit;
                txtCondo_Price.value = addCommas(Condo_price);
            }
            
            function addCommas(nStr) {
                nStr += '';
                x = nStr.split('.');
                x1 = x[0];
                x2 = x.length > 1 ? '.' + x[1] : '';
                var rgx = /(\d+)(\d{3})/;
                while (rgx.test(x1)) {
                    x1 = x1.replace(rgx, '$1' + ',' + '$2');
                }
                return x1 + x2;
            }

            function openlink() {
                var reqid = document.getElementById('<%=lblReq_Id.ClientID%>').innerHTML;
                //alert(reqid);
                var hubid = document.getElementById('<%=lblHub_Id.ClientID%>').innerHTML;
                //alert(hubid);
                var approve_id = document.getElementById('<%=HiddenField_ApproveId.ClientID%>').value;
                //alert(approve_id);                
                var temp_aid = 0;
                
                

                window.open('FileUpload_Price2.aspx?Req_Id=' + reqid + '&Hub_Id=' + hubid + '&User_Id=' + approve_id + '&Temp_AID=' + temp_aid, 'window', 'toolbar=no', 'menubar = no', 'scrollbars = yes');
            }   
            
            function MessageNotice(msg) {
                alert(msg);
            }
            
            function getDropDownListvalue() {
                var IndexValue = $get('<%=ddlComment.ClientID %>').selectedIndex;
                var SelectedVal = $get('<%=ddlComment.ClientID %>').options[IndexValue].value;
                alert(SelectedVal);
                var IndexValue1 = $get('<%=ddlWarning.ClientID %>').selectedIndex;
                var SelectedVal1 = $get('<%=ddlWarning.ClientID %>').options[IndexValue1].value;
                alert(SelectedVal1);
                var approve_id = document.getElementById('<%=HiddenField_ApproveId.ClientID%>').value;
                alert(approve_id);             
            }
              
    </script> 

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePageMethods="true">
    <Services>
    <asp:ServiceReference Path="~/Service.svc" />
    </Services>
    </asp:ScriptManager>
    <br />
    <br />
        <asp:UpdatePanel ID="UP1" runat="server">
            <ContentTemplate>
                <br />
                <br />
                <div align="center">
          <table bgcolor="Silver" class="tableleft">
            <tr>
                <td bgcolor="Yellow" colspan="2" style="font-weight: 700; text-align: center">
                    ��˹��Ҥҷ�� 2</td>
            </tr>
            <tr>
                <td>
                    �Ţ�Ӣͻ����Թ</td>
                <td>
                    <asp:Label ID="lblReq_Id" runat="server" MyClintID="lblReq_Id" 
                        style="font-weight: 700"></asp:Label>
                    <asp:Label ID="lblApprove_Id" runat="server" Visible="False"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    ���� Hub</td>
                <td>
                <asp:Label ID="lblHub_Id" runat="server" style="font-weight: 700"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    Cif</td>
                <td>
                <asp:Label ID="lblCif" runat="server" style="font-weight: 700" ></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    ��Դ��ѡ��Сѹ</td>
                <td>
                    <asp:Label ID="lblCollType" runat="server" style="font-weight: 700"></asp:Label>
                    <asp:Label ID="lblCollType_Name" runat="server" style="font-weight: 700"></asp:Label>
                </td>
            </tr>
              <tr>
                  <td>
                      �Ըա������Ҥ�</td>
                  <td>
                      <asp:RadioButtonList ID="rdbAppraisal_Type" runat="server" 
                          BehaviorID="rdbAppraisal_TypeBehavior" MyClintID="rdbAppraisal_Type" 
                          RepeatDirection="Horizontal">
                          <asp:ListItem Value="2">�Ըյ鹷ع</asp:ListItem>
                          <asp:ListItem Value="1">�Ըյ�Ҵ</asp:ListItem>
                      </asp:RadioButtonList>
                  </td>
              </tr>
            <tr>
                <td>
                    �Ҥҷ��Թ</td>
                <td>
                    <cc1:mytext ID="txtLand" runat="server" 
                        AllowUserKey="num_Numeric" BackColor="#FFFF66" EnableTextAlignRight="True" 
                        Width="110px">0.00</cc1:mytext>
                    &nbsp;�ӹǹ
                    <asp:Label ID="lblLandRow" runat="server">0</asp:Label>
                    &nbsp;��¡��
                    <asp:Button ID="btn_Land" runat="server" Text="��������´���Թ" Height="25px" 
                        Width="190px" />
                    <cc1:ModalPopupExtender ID="btn_Land_ModalPopupExtender" runat="server" 
                        BackgroundCssClass="GrayedOut" CancelControlID="btn_Cancel" 
                        OkControlID="btn_Ok" OnCancelScript="onCancel()" OnOkScript="onOk()" 
                        PopupControlID="panel_Popup" TargetControlID="btn_Land" />
                </td>
            </tr>
            <tr>
                <td>
                    �Ҥ���觻�١���ҧ</td>
                <td>
                    <cc1:mytext ID="txtBuilding" runat="server" AllowUserKey="num_Numeric" 
                        BackColor="#FFFF66" EnableTextAlignRight="True" 
                        Width="110px">0.00</cc1:mytext>
                    &nbsp;�ӹǹ
                    <asp:Label ID="lblBuildingRow" runat="server" Text="0"></asp:Label>
                    &nbsp;��¡��
                    <asp:Button ID="btn_Building" runat="server" Text="��������´��觻�١���ҧ" 
                        Width="190px" />
                    <cc1:ModalPopupExtender ID="btn_Building_ModalPopupExtender" runat="server" 
                        BackgroundCssClass="GrayedOut" CancelControlID="btn_Cancel_Building" 
                        OkControlID="btn_Ok_Building" OnCancelScript="onCancel()" OnOkScript="onOk_Building()" 
                        PopupControlID="panel_Building" TargetControlID="btn_Building" />
                </td>
            </tr>
            <tr>
                <td>
                    �ҤҤ͹�</td>
                <td>
                    <cc1:mytext ID="txtCondo" runat="server" AllowUserKey="num_Numeric" 
                        BackColor="#FFFF66" EnableTextAlignRight="True" 
                        Width="110px">0.00</cc1:mytext>
                    &nbsp;�ӹǹ
                    <asp:Label ID="lblCondoRow" runat="server" Text="0" ></asp:Label>
                    &nbsp;��¡��
                    <asp:Button ID="btn_Condo" runat="server" Text="��������´�͹�" 
                        Width="190px" />
                    <cc1:ModalPopupExtender ID="btn_Condo_ModalPopupExtender" runat="server" 
                        BackgroundCssClass="GrayedOut" CancelControlID="btn_Cancel_Condo" 
                        OkControlID="btn_Ok_Condo" OnCancelScript="onCancel()" OnOkScript="onOk_Condo()" 
                        PopupControlID="panel_Condo" TargetControlID="btn_Condo" />
                </td>
            </tr>
            <tr>
                <td>
                    �Ҥ����</td>
                <td>
                    <cc1:mytext ID="txtTotal" runat="server" AllowUserKey="num_Numeric" 
                        BackColor="#FFFF66" EnableTextAlignRight="True"
                        Width="110px">0.00</cc1:mytext>
                    �ҷ</td>
            </tr>
              <tr>
                  <td>
                      Comment</td>
                  <td>
                      <asp:DropDownList ID="ddlComment" runat="server" DataSourceID="SDSComment" 
                          DataTextField="Comment_Name" DataValueField="Comment_ID" 
                          BackColor="Yellow">
                      </asp:DropDownList>
                  </td>
              </tr>
              <tr>
                  <td>
                      Warning</td>
                  <td>
                      <asp:DropDownList ID="ddlWarning" runat="server" BackColor="#FFFF66" 
                          DataSourceID="SDSWarning" DataTextField="Warning_Name" 
                          DataValueField="Warning_ID">
                      </asp:DropDownList>
                  </td>
              </tr>
            <tr>
                <td bgcolor="Yellow">
                    <asp:ImageButton ID="btnSave0" runat="server" Font-Bold="True" Height="30px" 
                        ImageUrl="~/Images/save.jpg" OnClientClick="getDropDownListvalue(); return false;" 
                        Width="30px" Visible="False" />
                </td>
                <td bgcolor="Yellow">
                    <%--<asp:Button ID="btnSave" runat="server" Text="�ѹ�֡" Font-Bold="True" OnClientClick=" return ConfirmOnUpdate();" />--%>
           <asp:ImageButton 
                        ID="ImgBtnAttachment" runat="server" Height="30px" 
                        ImageUrl="~/Images/attachment.png" ToolTip="Ṻ���" Width="30px" OnClientClick=" return openlink();" />
&nbsp;<asp:ImageButton ID="btnSave" runat="server" Font-Bold="True" ImageUrl="~/Images/save.jpg"
                        OnClientClick="validate(); return false;" Width="30px" Height="30px" />
                    
<%--                    <cc1:ModalPopupExtender ID="btnSave_ModalPopupExtender" runat="server" 
                        BackgroundCssClass="GrayedOut"  
                        OkControlID="btnmessage" OnOkScript="onOk()" 
                        PopupControlID="panel_Message" TargetControlID="btnSave" />  --%>                  
                    <asp:TextBox ID="lit_Status" runat="server" BorderColor="White" 
                        CssClass="txtBox" Enabled="False" Width="200px" ForeColor="#0000CC" 
                        BackColor="Yellow" />
                </td>
            </tr>
    </table>              
                    <asp:HiddenField ID="HiddenField_ApproveId" runat="server" />
                    <asp:SqlDataSource ID="SDSComment" runat="server" 
                        ConnectionString="<%$ ConnectionStrings:AppraisalConn %>" 
                        SelectCommand="SELECT [Comment_ID], [Comment_Name] FROM [Comment]">
                    </asp:SqlDataSource>
                    <asp:SqlDataSource ID="SDSWarning" runat="server" 
                        ConnectionString="<%$ ConnectionStrings:AppraisalConn %>" 
                        SelectCommand="SELECT [Warning_ID], [Warning_Name] FROM [Warning]">
                    </asp:SqlDataSource>
                </div>


            <asp:Panel ID="panel_Popup" runat="server"> 
            <br /><br />
                <table style="background-color: #B5C7DE;">
                    <tr>
                        <td align="center" class="style2" colspan="2" bgcolor="Yellow">
                            ���Թ</td>
                    </tr>
                    <tr>
                        <td class="style1">
                            ��Դ��ѡ��Сѹ</td>
                        <td>
                            <asp:DropDownList ID="DDLSubCollTypeLand" runat="server" 
                                DataSourceID="sdsSubCollTypeLand" DataTextField="SubCollType_Name" 
                                DataValueField="MysubColl_ID">
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td class="style1">
                            ⩹��Ţ���</td>
                        <td>
                            <asp:TextBox ID="txtChanode" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="style1">
                            �ѧ��Ѵ�������ѡ��Сѹ</td>
                        <td>
                            <asp:DropDownList ID="ddlProvince" runat="server" DataSourceID="SDSProvince" 
                                DataTextField="PROV_NAME" DataValueField="PROV_CODE">
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td class="style1">
                            ���ͷ��</td>
                        <td>
                            <cc1:mytext ID="txtRai" runat="server" AllowUserKey="int_Integer" 
                                EnableTextAlignRight="True" MyClintID="txtRai" 
                                onkeyup="CalSection_Land(this,event);" Width="50px">0</cc1:mytext>
                            &nbsp;���
                            <cc1:mytext ID="txtNgan" runat="server" AllowUserKey="int_Integer" 
                                EnableTextAlignRight="True" MaxLength="1" MyClintID="txtNgan" 
                                onkeyup="CalSection_Land(this,event);" Width="50px">0</cc1:mytext>
                            &nbsp;�ҹ
                            <cc1:mytext ID="txtWah" runat="server" AllowUserKey="num_Numeric" 
                                EnableTextAlignRight="True" MaxLength="4" MyClintID="txtWah" 
                                onkeyup="CalSection_Land(this,event);" Width="50px">0</cc1:mytext>
                            &nbsp;���.</td>
                    </tr>
                    <tr>
                        <td class="style1">
                            ˹���</td>
                        <td>
                            <asp:DropDownList ID="ddlSubUnit" runat="server" DataSourceID="SDSSubUnit" 
                                DataTextField="SubUnit_Name" DataValueField="SubUnit_Id" MyClintID="ddlSubUnit" 
                                onkeyup="CalSection_Land(this,event);">
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td class="style1">
                            �Ҥҵ��˹���</td>
                        <td>
                            <cc11:mytext ID="txtPriceWah" runat="server" allowuserkey="num_Numeric" 
                                EnableTextAlignRight="True" MyClintID="txtPriceWah" 
                                onkeyup="CalSection_Land(this,event);" width="120px">0</cc11:mytext>
                        </td>
                    </tr>
                    <tr>
                        <td class="style1">
                            ���Թ</td>
                        <td>
                            <cc11:mytext ID="txtTotal0" runat="server" AllowUserKey="num_Numeric" 
                                AutoCurrencyFormatOnKeyUp="True" EnableTextAlignRight="True" 
                                MyClintID="txtTotal" Width="120px">0</cc11:mytext>
                        </td>
                    </tr>
                    <tr>
                        <td class="style1" bgcolor="Yellow">
                            &nbsp;</td>
                        <td bgcolor="Yellow">
                            <asp:Button ID="btn_ADD" runat="server" Text="ADD" BackColor="#CC3300" 
                                Width="150px" />
                        </td>
                    </tr>
                    <tr>
                        <td bgcolor="Yellow" class="style1" colspan="2">
                            <asp:GridView ID="GridView_Land" runat="server" AutoGenerateColumns="False" 
                                BackColor="LightGoldenrodYellow" BorderColor="Tan" BorderWidth="1px" 
                                CellPadding="2" ForeColor="Black" GridLines="None" 
                                style="font-size: small">
                                <Columns>
                                    <asp:TemplateField>
                                        <ItemTemplate>
                                            <asp:CheckBox ID="cb2" runat="server" />
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Center" />
                                        <HeaderStyle HorizontalAlign="Center" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="ID">
                                        <ItemTemplate>
                                            <asp:Label ID="lblID" runat="server" Text='<%# Bind("ID") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>                                       
                                    <asp:BoundField DataField="Req_Id" HeaderText="Req ID" />
                                    <asp:BoundField DataField="Hub_Id" HeaderText="Hub ID" />
                                    <asp:BoundField DataField="Colltype_Id" HeaderText="������ѡ��Сѹ" />
                                    <asp:BoundField DataField="Colltype_Name" HeaderText="������ѡ��Сѹ" />
                                    <asp:BoundField DataField="ProvinceCode" HeaderText="�ѧ��Ѵ" />
                                    <asp:BoundField DataField="ProvinceName" HeaderText="���ͨѧ��Ѵ" />
                                    <asp:TemplateField HeaderText="�Ţ���⩹�">
                                        <ItemTemplate>
                                            <asp:Label ID="lblChanode" runat="server" Text='<%# Bind("Chanode") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>                                    
<%--                                    <asp:BoundField DataField="Chanode" HeaderText="�Ţ���⩹�" />--%>
                                    <asp:BoundField DataField="Rai" HeaderText="���" />
                                    <asp:BoundField DataField="Ngan" HeaderText="�ҹ" />
                                    <asp:BoundField DataField="Wah" HeaderText="��" />
                                    <asp:BoundField DataField="SubUnit_Name" HeaderText="˹���" />
                                    <asp:BoundField DataField="Unitprice" HeaderText="�Ҥҵ��˹���">
                                        <ItemStyle HorizontalAlign="Right" />
                                    </asp:BoundField>
                                    <asp:TemplateField HeaderText="����Թ">
                                        <ItemTemplate>
                                            <asp:Label ID="lblTotal" runat="server" Text='<%# Bind("Total") %>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Right" />
                                    </asp:TemplateField>
                                    <asp:TemplateField ShowHeader="False">
                                        <ItemTemplate>
                                            <asp:Button ID="btnMove" runat="server" CausesValidation="false" 
                                                onclick="btnMove_Click" Text="Move" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                                <FooterStyle BackColor="Tan" />
                                <PagerStyle BackColor="PaleGoldenrod" ForeColor="DarkSlateBlue" 
                                    HorizontalAlign="Center" />
                                <SelectedRowStyle BackColor="DarkSlateBlue" ForeColor="GhostWhite" />
                                <HeaderStyle BackColor="Tan" Font-Bold="True" />
                                <AlternatingRowStyle BackColor="PaleGoldenrod" />
                            </asp:GridView>
                        </td>
                    </tr>                    
                    <tr>
                        <td style="background-color: #FFFFFF;" class="style1" colspan="2" align="right">
                            <b>
                            <asp:HiddenField ID="JSON_DataTable_Land" runat="server" />
                            �Ҥ���� :</b>
                            <cc11:mytext ID="txtLandTotal" runat="server" AllowUserKey="num_Numeric" 
                                AutoCurrencyFormatOnKeyUp="True" EnableTextAlignRight="True" 
                                MyClintID="txtTotal" ReadOnly="True" Width="120px">0</cc11:mytext>
                            &nbsp;<b>�ҷ</b></td>
                    </tr>
                    <tr>
                        <td bgcolor="Yellow" class="style1">
                            &nbsp;</td>
                        <td bgcolor="Yellow">
                            <asp:Button ID="btn_Ok" runat="server" Text="OK" />
                            &nbsp;<asp:Button ID="btn_Cancel" runat="server" Text="Cancel" />
                        </td>
                    </tr>

                </table>
                <br />
                <asp:SqlDataSource ID="SDSSubUnit" runat="server" 
                    ConnectionString="<%$ ConnectionStrings:AppraisalConn %>" 
                    SelectCommand="SELECT [SubUnit_Id], [SubUnit_Name] FROM [TB_SubUnit] WHERE ([SubUnit_Id] &lt;= @SubUnit_Id)">
                    <SelectParameters>
                        <asp:Parameter DefaultValue="3" Name="SubUnit_Id" Type="Int32" />
                    </SelectParameters>
                </asp:SqlDataSource>
                <asp:SqlDataSource ID="sdsSubCollTypeLand" runat="server" 
                    ConnectionString="<%$ ConnectionStrings:AppraisalConn %>" 
                    SelectCommand="SELECT SubCollType_Name, MysubColl_ID FROM CollType_All WHERE (CollType_ID = 50)">
                </asp:SqlDataSource>
                <asp:SqlDataSource ID="SDSProvince" runat="server" 
                    ConnectionString="<%$ ConnectionStrings:AppraisalConn %>" 
                    
                    SelectCommand="SELECT Appraisal_Request.province as PROV_CODE, Bay01.dbo.TB_PROVINCE.PROV_NAME FROM Appraisal_Request LEFT OUTER JOIN Bay01.dbo.TB_PROVINCE ON Appraisal_Request.province = Bay01.dbo.TB_PROVINCE.PROV_CODE WHERE (Appraisal_Request.Req_ID = @Req_Id)">
                    <SelectParameters>
                        <asp:ControlParameter ControlID="lblReq_Id" Name="Req_Id" PropertyName="Text" />
                    </SelectParameters>
                </asp:SqlDataSource>
            </asp:Panel>
            
            <asp:Panel ID="panel_Building" runat="server"> 
            <br /><br />
                <table style="background-color: #B5C7DE;">
            <tr>
                <td colspan="6" align="center" bgcolor="Yellow" class="style3">
                    <b>��觻�١���ҧ</b></td>
            </tr>
                    <tr>
                        <td>
                            ��Դ��ѡ��Сѹ</td>
                        <td colspan="5">
                            <asp:DropDownList ID="DDLSubCollType" runat="server" BackColor="#FFFF66" 
                                DataSourceID="sdsSubCollType" DataTextField="SubCollType_Name" 
                                DataValueField="MysubColl_ID">
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            ��١���ҧ��⩹��Ţ���</td>
                        <td>
                            <asp:TextBox ID="txtChanodeNo" runat="server" BackColor="#FFFF66" 
                                MyClintID="txtChanodeNo"></asp:TextBox>
                        </td>
                        <td>
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td>
                            ��ҹ�Ţ���</td>
                        <td>
                            <asp:TextBox ID="txtBuild_No" runat="server" BackColor="#FFFF66" 
                                MyClintID="txtBuild_No"></asp:TextBox>
                        </td>
                        <td>
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td>
                            ��鹷����觻�١���ҧ������</td>
                        <td>
                            <cc1:mytext ID="txtBuildingArea" runat="server" AllowUserKey="num_Numeric" 
                                BackColor="#FFFF66" EnableTextAlignRight="True" MaxLength="6" 
                                MyClintID="txtBuildingArea" onkeyup="CalSection_Building(this,event);" 
                                Width="35px">0</cc1:mytext>
                            ���.</td>
                        <td>
                            ���.(���ҧ����)</td>
                        <td>
                            <cc1:mytext ID="txtBuildingUnitPrice" runat="server" AllowUserKey="num_Numeric" 
                                BackColor="#FFFF66" EnableTextAlignRight="True" 
                                MyClintID="txtBuildingUnitPrice" onkeyup="CalSection_Building(this,event);" 
                                Width="110px">0.00</cc1:mytext>
                            �ҷ</td>
                        <td>
                            ��Ť��(���ҧ����)</td>
                        <td>
                            <cc1:mytext ID="txtBuildingPrice" runat="server" AllowUserKey="num_Numeric" 
                                AutoCurrencyFormatOnKeyUp="True" BackColor="#FFFF66" 
                                EnableTextAlignRight="True" MyClintID="txtBuildingPrice" Width="110px">0.00</cc1:mytext>
                            �ҷ</td>
                    </tr>
            <tr>
                <td>
                    �����繵����ҧ����</td>
                <td>
                    <cc1:mytext ID="txtFinishPercent" runat="server" AllowUserKey="num_Numeric" 
                        Width="35px" BackColor="#FFFF66" MaxLength="3" 
                        EnableTextAlignRight="True" 
                        MyClintID="txtFinishPercent"
                        onkeyup="CalSection_Building(this,event);" >100</cc1:mytext>
                    &nbsp;%</td>
                <td>
                                        ��Ť��</td>
                <td>
                    <cc1:mytext ID="txtPriceNotFinish" runat="server" AllowUserKey="num_Numeric" 
                        EnableTextAlignRight="True" Width="110px" BackColor="#FFFF66" 
                        AutoPostBack="True"
                        MyClintID="txtPriceNotFinish" >0.00</cc1:mytext>
                    �ҷ</td>
                <td>
                                        &nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td>
                    ���ء����ҹ</td>
                <td>
                    <cc1:mytext ID="txtBuildingAge" runat="server" AllowUserKey="num_Numeric" 
                        EnableTextAlignRight="True" MaxLength="2" Width="35px" BackColor="#FFFF66"
                        MyClintID="txtBuildingAge"
                        onkeyup="CalSection_Building(this,event);" >0</cc1:mytext>
                    ��</td>
                <td>
                                        �����������ͻ�</td>
                <td>
                    <cc1:mytext ID="txtBuildingPersent1" runat="server" AllowUserKey="num_Numeric" 
                        EnableTextAlignRight="True" MaxLength="5" Width="35px" BackColor="#FFFF66"
                        MyClintID="txtBuildingPersent1"
                        onkeyup="CalSection_Building(this,event);" >0</cc1:mytext>
                    %</td>
                <td>
                                        ��������������Ҿ��Ѻ��ا</td>
                <td>
                    <cc1:mytext ID="txtBuildingPersent2" runat="server" AllowUserKey="num_Numeric" 
                        EnableTextAlignRight="True" MaxLength="5" Width="35px" BackColor="#FFFF66"
                        MyClintID="txtBuildingPersent2"
                        onkeyup="CalSection_Building(this,event);" >0</cc1:mytext>
                    %</td>
            </tr>
            <tr>
                <td>
                                        ��������������Ҿ���������</td>
                <td >
                    <cc1:mytext ID="txtBuildingPersent3" runat="server" AllowUserKey="num_Numeric" 
                        EnableTextAlignRight="True" MaxLength="5" Width="35px" BackColor="#FFFF66"
                        MyClintID="txtBuildingPersent3"
                        onkeyup="CalSection_Building(this,event);" >0</cc1:mytext>
                    %</td>
                <td>
                    ������������</td>
                <td>
                    <cc1:mytext ID="txtBuildingTotalDeteriorate" runat="server" AllowUserKey="num_Numeric" 
                        EnableTextAlignRight="True" MaxLength="5" Width="35px" BackColor="#FFFF66"
                        MyClintID="txtBuildingTotalDeteriorate" 
                        onkeyup="CalSection_Building(this,event);" >0</cc1:mytext>
                    %</td>
                <td>
                    �������������Ҥ�</td>
                <td>
                    <cc1:mytext ID="txtBuildingPriceTotalDeteriorate" runat="server" AllowUserKey="num_Numeric" 
                        EnableTextAlignRight="True" Width="110px" BackColor="#FFFF66"
                        MyClintID="txtBuildingPriceTotalDeteriorate" >0.00</cc1:mytext>
                    �ҷ</td>
            </tr>                
                    <tr>
                        <td>
                            <asp:Label ID="lblMarketPrice" runat="server" Text="�Ҥҵ�Ҵ"></asp:Label>
                        </td>
                        <td>
                            <cc1:mytext ID="txtMarketPrice" runat="server" AllowUserKey="num_Numeric" 
                                BackColor="#FFFF66" EnableTextAlignRight="True" 
                                MyClintID="txtBuildingPrice" Width="110px" 
                                AutoCurrencyFormatOnKeyUp="True">0.00</cc1:mytext>
                        </td>
                        <td>
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
                        <td>
                            <asp:Button ID="btn_Add_Building" runat="server" Text="ADD" BackColor="#CC3300" 
                                Width="150px" />
                        </td>
                    </tr>
                    <tr>
                        <td colspan="6" style=" background-color:White">
                            <asp:GridView ID="GridView_Building" runat="server" AutoGenerateColumns="False" 
                                BackColor="LightGoldenrodYellow" BorderColor="Tan" BorderWidth="1px" 
                                CellPadding="2" ForeColor="Black" GridLines="None" style="font-size: small">
                                <Columns>
                                    <asp:TemplateField>
                                        <ItemTemplate>
                                            <asp:CheckBox ID="cb_building" runat="server" />
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Center" />
                                        <HeaderStyle HorizontalAlign="Center" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="ID">
                                        <ItemTemplate>
                                            <asp:Label ID="lblID_building" runat="server" Text='<%# Bind("ID") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>                                     
                                    <asp:TemplateField HeaderText="������ѡ��Сѹ">
                                        <ItemTemplate>
                                            <asp:HiddenField ID="hdfColltype_Id" runat="server" Value='<%# Bind("Colltype_Id") %>' />
                                            <asp:Label ID="lblColltype_Name" runat="server" Text='<%# Bind("Colltype_Name") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="�Ţ���⩹�">
                                        <ItemTemplate>
                                            <asp:Label ID="lblChanode" runat="server" Text='<%# Bind("Chanode") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="��ҹ�Ţ���">
                                        <ItemTemplate>
                                            <asp:Label ID="lblBuild_No" runat="server" Text='<%# Bind("Build_No") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="��Ҵ��鹷��">
                                        <ItemTemplate>
                                            <asp:Label ID="lblArea" runat="server" Text='<%# Bind("Area") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="���. ��">
                                        <ItemTemplate>
                                            <asp:Label ID="lblUnit_Price" runat="server" Text='<%# eval("Unit_Price", "{0:N}") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="��Ť�����ҧ����">
                                        <ItemTemplate>
                                            <asp:Label ID="lblValue_Price" runat="server" Text='<%# Bind("Value_Price", "{0:N}") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="% ���ҧ����">
                                        <ItemTemplate>
                                            <asp:Label ID="lblPercent_Finish" runat="server" Text='<%# Bind("Percent_Finish") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="��Ť�ҷ�����ҧ����">
                                        <ItemTemplate>
                                            <asp:Label ID="lblFinish_Price" runat="server" Text='<%# Bind("Finish_Price", "{0:N}") %>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Right" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="������ҹ">
                                        <ItemTemplate>
                                            <asp:Label ID="lblAge" runat="server" Text='<%# Bind("Age") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="�����������ͻ�">
                                        <ItemTemplate>
                                            <asp:Label ID="lblPercent1" runat="server" Text='<%# Bind("Percent1") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="�����������Ѻ��ا">
                                        <ItemTemplate>
                                            <asp:Label ID="lblPercent2" runat="server" Text='<%# Bind("Percent2") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="��������� ���������">
                                        <ItemTemplate>
                                            <asp:Label ID="lblPercent3" runat="server" Text='<%# Bind("Percent3") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="������������">
                                        <ItemTemplate>
                                            <asp:Label ID="lblTotal_Percent" runat="server" Text='<%# Bind("Total_Percent") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="��Ť�Ҥ��������">
                                        <ItemTemplate>
                                            <asp:Label ID="lblDeteriorate" runat="server" Text='<%# Bind("Deteriorate", "{0:N}") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="����Թ">
                                        <ItemTemplate>
                                            <asp:Label ID="lblTotal_Building" runat="server" Text='<%# Bind("Total_Building", "{0:N}") %>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Right" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="����Թ�Ҥҵ�Ҵ">
                                        <ItemTemplate>
                                            <asp:Label ID="lblMarketPrice" runat="server" Text='<%# Bind("MarketPrice", "{0:N}") %>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Right" />
                                    </asp:TemplateField>                                    
<%--                                    <asp:TemplateField ShowHeader="False">
                                        <ItemTemplate>
                                            <asp:Button ID="btnMove_Building" runat="server" CausesValidation="false" 
                                                onclick="btnMove_Building_Click" Text="Move" />
                                        </ItemTemplate>
                                    </asp:TemplateField>--%>
                                    <asp:TemplateField ShowHeader="False">
                                        <ItemTemplate>
                                            <asp:Button ID="btnMove_row" runat="server" CausesValidation="false" 
                                                Text="Move"  CommandName="Delete"/>
                                        </ItemTemplate>
                                    </asp:TemplateField>                                    
                                </Columns>
                                <FooterStyle BackColor="Tan" />
                                <PagerStyle BackColor="PaleGoldenrod" ForeColor="DarkSlateBlue" 
                                    HorizontalAlign="Center" />
                                <SelectedRowStyle BackColor="DarkSlateBlue" ForeColor="GhostWhite" />
                                <HeaderStyle BackColor="Tan" Font-Bold="True" />
                                <AlternatingRowStyle BackColor="PaleGoldenrod" />
                            </asp:GridView>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="6" style=" background-color:White; text-align:right;">
                            <b>
                            <asp:HiddenField ID="JSON_DataTable_Building" runat="server" />
                            �Ҥ����(�Ѵ���) :</b>&nbsp;<cc11:mytext ID="txtBuildingTotal_Price1" 
                                runat="server" AllowUserKey="num_Numeric" AutoCurrencyFormatOnKeyUp="True" 
                                EnableTextAlignRight="True" MyClintID="txtTotal" ReadOnly="True" 
                                style="text-align: left" Width="120px">0</cc11:mytext>
                            &nbsp;<b>�ҷ</b></td>
                    </tr>
                    <tr>
                        <td align="center" bgcolor="Yellow" colspan="6">
                            <asp:Label ID="lblMessageNotice_Building" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td align="center" bgcolor="Yellow" colspan="6">
                            <asp:Button ID="btn_Ok_Building" runat="server" Text="OK" />
                            &nbsp;<asp:Button ID="btn_Cancel_Building" runat="server" Text="Cancel" />
                        </td>
                    </tr>
                </table>
            <br />
                <asp:SqlDataSource ID="sdsSubCollType" runat="server" 
                    ConnectionString="<%$ ConnectionStrings:AppraisalConn %>" 
                    
                    SelectCommand="SELECT SubCollType_Name, MysubColl_ID FROM CollType_All WHERE (CollType_ID = 70)">
                </asp:SqlDataSource>
            </asp:Panel>
            
                        <asp:Panel ID="panel_Condo" runat="server"> 
            <br /><br />
                <table style="background-color: #B5C7DE;">
            <tr>
                <td colspan="6" align="center" bgcolor="Yellow" class="style3">
                    �͹�/��ͧ�ش</td>
            </tr>
                    <tr>
                        <td>
                            �Ţ������¹�Ҥ�êش</td>
                        <td colspan="5">
                            <cc11:mytext ID="txtRegister_No" runat="server" AllowUserKey="txt_Text" 
                                Width="130px"></cc11:mytext>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            �Ţ����Ҥ��</td>
                        <td bgcolor="#B5C7DE">
                            <cc11:mytext ID="txtBuild_Number" runat="server" AllowUserKey="txt_Text" 
                                EnableTextAlignRight="True" Width="50px"></cc11:mytext>
                        </td>
                        <td>
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td>
                            �Ţ�����ͧ</td>
                        <td>
                            <asp:TextBox ID="txtAddressNo" runat="server"></asp:TextBox>
                        </td>
                        <td>
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td>
                            �����ç����Ҥ�êش</td>
                        <td colspan="5">
                            <asp:TextBox ID="txtBuildingName" runat="server" Width="370px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            �ѧ��Ѵ�������ѡ��Сѹ</td>
                        <td>
                            <asp:DropDownList ID="ddlProvinceCondo" runat="server" 
                                DataSourceID="SDSProvince" DataTextField="PROV_NAME" DataValueField="PROV_CODE">
                            </asp:DropDownList>
                        </td>
                        <td>
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td>
                            ��鹷��</td>
                        <td>
                            <cc11:mytext ID="txtArea" runat="server" AllowUserKey="num_Numeric" 
                                EnableTextAlignRight="True" MyClintID="txtArea" 
                                onkeyup="CalSection_Condo(this,event);" Width="50px">0</cc11:mytext>
                            ���.</td>
                        <td>
                            ���.��</td>
                        <td>
                            <cc11:mytext ID="txtUnitPrice" runat="server" allowuserkey="num_Numeric" 
                                EnableTextAlignRight="True" MyClintID="txtUnitPrice" 
                                onkeyup="CalSection_Condo(this,event);" width="120px">0</cc11:mytext>
                            �ҷ</td>
                        <td>
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
                    </tr>
            <tr>
                <td >
                    �Ҥ�</td>
                <td>
                    <cc11:mytext ID="txtCondoPrice" runat="server" AllowUserKey="txt_Text" 
                        AutoCurrencyFormatOnKeyUp="True" EnableTextAlignRight="True" 
                        MyClintID="txtCondoPrice" Width="120px">0</cc11:mytext>
                    �ҷ</td>
                <td >
                </td>
                <td>
                    <asp:Button ID="btn_Add_Condo" runat="server" BackColor="#CC3300" 
                        Text="ADD" Width="150px" />
                </td>
                <td>
                                        &nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
                    <tr>
                        <td colspan="6">
                            <asp:GridView ID="GridView_Condo" runat="server" AutoGenerateColumns="False" 
                                BackColor="LightGoldenrodYellow" BorderColor="Tan" BorderWidth="1px" 
                                CellPadding="2" ForeColor="Black" GridLines="None" style="font-size: small">
                                <Columns>
                                    <asp:TemplateField>
                                        <ItemTemplate>
                                            <asp:CheckBox ID="cb_Condo" runat="server" />
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Center" />
                                        <HeaderStyle HorizontalAlign="Center" />
                                    </asp:TemplateField>                                
                                    <asp:TemplateField HeaderText="ID">
                                        <ItemTemplate>
                                            <asp:Label ID="lblID_Condo" runat="server" Text='<%# Bind("ID") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>                                 
                                    <asp:TemplateField HeaderText="�Ţ������¹�Ҥ�êش">
                                        <ItemTemplate>
                                            <asp:Label ID="lblRegister_No" runat="server" Text='<%# Bind("Register_No") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="�Ţ����Ҥ��">
                                        <ItemTemplate>
                                            <asp:Label ID="lblBuild_Number" runat="server" Text='<%# Bind("Building_Number") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="�Ţ�����ͧ">
                                        <ItemTemplate>
                                            <asp:Label ID="lblAddressNo" runat="server" Text='<%# Bind("AddressNo") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="�����ç����Ҥ�êش">
                                        <ItemTemplate>
                                            <asp:Label ID="lblBuildingName" runat="server" Text='<%# Bind("BuildingName") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="�ѧ��Ѵ�������ѡ��Сѹ">
                                        <ItemTemplate>
                                            <asp:Label ID="lblProvinceName" runat="server" Text='<%# Bind("ProvinceName") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>                                    
                                    <asp:TemplateField HeaderText="��鹷��(���.)">
                                        <ItemTemplate>
                                            <asp:Label ID="lalCondo_Area" runat="server" Text='<%# Bind("Condo_Area") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="�Ҥҵ��˹���">
                                        <ItemTemplate>
                                            <asp:Label ID="lblCondo_Unitprice" runat="server" Text='<%# Bind("UnitPrice") %>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Right" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="����Թ">
                                        <ItemTemplate>
                                            <asp:Label ID="lblCondoPrice" runat="server" Text='<%# Bind("CondoPrice") %>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Right" />
                                    </asp:TemplateField>
                                    <asp:TemplateField ShowHeader="False">
                                        <ItemTemplate>
                                            <asp:Button ID="btnMove_Condo" runat="server" CausesValidation="false" 
                                                Text="Move" CommandName="Delete" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                                <FooterStyle BackColor="Tan" />
                                <PagerStyle BackColor="PaleGoldenrod" ForeColor="DarkSlateBlue" 
                                    HorizontalAlign="Center" />
                                <SelectedRowStyle BackColor="DarkSlateBlue" ForeColor="GhostWhite" />
                                <HeaderStyle BackColor="Tan" Font-Bold="True" />
                                <AlternatingRowStyle BackColor="PaleGoldenrod" />
                            </asp:GridView>
                        </td>
                    </tr>
                    <tr>
                        <td align="right" colspan="6" bgcolor="White">
                            <b>
                            <asp:HiddenField ID="JSON_DataTable_Condo" runat="server" />
                            �Ҥ����</b><cc11:mytext ID="txtCondoTotal_Price" runat="server" 
                                AllowUserKey="num_Numeric" AutoCurrencyFormatOnKeyUp="True" 
                                EnableTextAlignRight="True" MyClintID="txtTotal" ReadOnly="True" 
                                style="text-align: left" Width="120px">0</cc11:mytext>
                            <b>�ҷ</b></td>
                    </tr>
                    <tr>
                        <td align="center" bgcolor="Yellow" colspan="6">
                            <asp:Button ID="btn_Ok_Condo" runat="server" Text="OK" />
                            &nbsp;<asp:Button ID="btn_Cancel_Condo" runat="server" Text="Cancel" />
                        </td>
                    </tr>
                </table>
            </asp:Panel>
            
            <cc1:ModalPopupExtender 
                ID="mdlPopup" runat="server" TargetControlID="btnSave" 
                PopupControlID="pnlPopup" BackgroundCssClass="modalBackground"
                BehaviorID="mdlPopupBehavior"  />   
                         
            <asp:Panel ID="pnlPopup" runat="server" CssClass="updateProgress" style="display:none">
                <div align="center" style="margin-top:10px;">
                    <img src="Images/progress.gif" alt="" />
                    <span class="updateProgressMessage">Please wait will be saving ...</span>
                </div>
            </asp:Panel>
                         
            </ContentTemplate>
        </asp:UpdatePanel> 

</asp:Content>

