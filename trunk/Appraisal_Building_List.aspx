<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Appraisal_Building_List.aspx.vb" Inherits="Appraisal_Building_List" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register Assembly="Mytextbox" Namespace="Mytextbox" TagPrefix="cc1" %>
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>

    <script src="Js/jquery-1.4.2.min.js" type="text/javascript"></script>

    <script src="Js/common.js" type="text/javascript"></script>

    <style type="text/css">
        .TableWidth
        {
            width: 100%;
        }
        .headDetail
        {
            font-weight: bold;
            color: Blue;
            background-color: Yellow;
        }
        .expleanColour
        {
            background-color: Silver;
            width: 300px;
        }
        .fColor
        {
            color: red;
        }
        .expleanColour1
        {
            background-color: red;
        }
        .GrayedOut
        {
            background-color: Gray;
            filter: alpha(opacity=95);
            -moz-opacity: 0.5;
            -khtml-opacity: 0.5;
            opacity: 0.5;
        }
        .modalBox
        {
            background-color: #f5f5f5;
            border-width: 3px;
            border-style: solid;
            border-color: Blue;
            padding: 1px;
        }
        .modalBackground
        {
            background-color: #CCCCFF;
            filter: alpha(opacity=40);
            opacity: 0.5;
        }
        .ModalWindow
        {
            border: solid1px#c0c0c0;
            background: #f0f0f0;
            padding: 0px10px10px10px;
            position: absolute;
            top: -1000px;
        }
        .outerPopup
        {
            background-color: Gray;
            padding: 0px5px5px5px;
            border-style: solid;
            border-color: Yellow;
            border-width: 1px;
        }
        .innerPopup
        {
            background-color: #fff;
        }
        .modalBackground1
        {
            background-color: #000;
            filter: alpha(opacity=70);
            opacity: 0.7;
        }
        .style1
        {
            height: 116px;
        }
        .style2
        {
            color: #0000CC;
            font-weight: bold;
        }
    </style>

    <script type="text/javascript">

        function changeIframeSrcById(id, url, param) {
            var urlFull = "";
            //var popup = $find('mpeBehaviorBuilding');
            var iframe = document.getElementById(id);
            //alert(url);
            if (param) {
                urlFull = url + "?" + param;
            } else {
                urlFull = url;
            }
            //alert(encodeURI(urlFull));
            iframe.src = encodeURI(urlFull);
            //popup.show();
        }

        function concatParam(oldParam, addParamTag, addParamMyId, addParamKey) {
            var result = oldParam;
            var dom = null;

            if (addParamTag == "input") {
                dom = getEleByProperty(addParamTag, "myId", addParamMyId)
            } else if (addParamTag == "select") {

            }

            if (dom.value.length >= 1) {
                result = result + "&" + addParamKey + "=" + dom.value
            } else {
                //alert('โปรดตรวจสอบว่ามีรายละเอียดจังหวัด รายละเอียดอำเภอ แล้วหรือไม่');
            }
            //alert(result);
            return result;
        }


        function changeBuildingIframeSrc() {

            var myId = "IframeBuilding";
            var url = "Appraisal_Building.aspx";
            var param = "ID=" + '' + "&Temp_AID=" + '' + "&PopupModal=mpeBehaviorBuilding";
            //var param = "LandPrice=TextBoxLand&BuildingPrice=TextBoxBuilding&CondoPrice=TextBoxCondo&GrandTotal=TextBoxGrandTotal&PopupModal=mpeBehaviorLand";

            param = param + concatParam('', 'input', 'TextBoxReq_Id', 'Req_Id');
            param = param + concatParam('', 'input', 'TextBoxHub_Id', 'Hub_Id');
            param = param + concatParam('', 'input', 'TextBoxCif', 'Cif');
            param = param + concatParam('', 'input', 'TextBoxCifName', 'CifName');
            param = param + concatParam('', 'input', 'TextBoxAppraisal_Id', 'Appraisal_Id');
            //alert(param);
            changeIframeSrcById(myId
                , url
                , param
            );
        }
           
    </script>

</head>
<body>
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <div>
        <table width="100%" style="background-color: #FFC20E;">
            <tr>
                <td>
                    <table width="100%" style="margin-left: 0px">
                        <tr>
                            <td class="style1">
                                <table align="center" border="0" cellpadding="3" cellspacing="5" width="100%" style="background-color: #FFC20E;">
                                    <tr>
                                        <td style="width: 180px">
                                            เลขคำขอประเมิน
                                        </td>
                                        <td>
                                            <asp:TextBox ID="TextBoxReq_Id" runat="server" MaxLength="20" myId="TextBoxReq_Id"
                                                onfocus="this.blur();"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="width: 180px">
                                            รหัส Hub
                                        </td>
                                        <td>
                                            <asp:TextBox ID="TextBoxHub_Id" runat="server" MaxLength="20" myId="TextBoxHub_Id"
                                                onfocus="this.blur();"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="width: 120px">
                                            Cif
                                        </td>
                                        <td>
                                            <asp:TextBox ID="TextBoxCif" runat="server" MaxLength="20" myId="TextBoxCif" onfocus="this.blur();"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="width: 120px">
                                            Cif Name
                                        </td>
                                        <td>
                                            <asp:TextBox ID="TextBoxCifName" runat="server" MaxLength="20" myId="TextBoxCifName"
                                                onfocus="this.blur();" Width="250px"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="width: 120px">
                                            รหัส ผู้ประเมิน
                                        </td>
                                        <td>
                                            <asp:TextBox ID="TextBoxAppraisal_Id" runat="server" MaxLength="20" myId="TextBoxAppraisal_Id"
                                                onfocus="this.blur();"></asp:TextBox>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                            <td align="right" valign="top" style="background-color: #FFC20E;">
                                <asp:ImageButton ID="ImageButtonAddBuilding" runat="server" ImageUrl="Images/add_plus.jpg"
                                    Width="50" OnClientClick="changeBuildingIframeSrc(); return false;" ToolTip="เพิ่มที่ดินแปลงใหม่" />
                                <asp:HiddenField ID="HiddenReq_No" runat="server" />
                                <asp:HiddenField ID="HiddenHubId" runat="server" Value="104" />
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2" class="style2" style="background-image: url('Images/center_tile.gif')">
                                ::รายการที่สิ่งปลูกสร้าง::
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2">
                            <asp:GridView ID="GridView_Building" runat="server" AutoGenerateColumns="False" 
                                BackColor="LightGoldenrodYellow" BorderColor="Tan" BorderWidth="1px" 
                                CellPadding="2" ForeColor="Black" GridLines="None" 
                                style="font-size: small" ShowFooter="True" 
                                    DataSourceID="SqlDataSourceBuilding">
                                <Columns>
                                    <asp:TemplateField HeaderText="ID">
                                        <ItemTemplate>
                                            <asp:Label ID="lblID_building" runat="server" Text='<%# Bind("ID") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>                                     
                                    <asp:TemplateField HeaderText="ชื่อหลักประกัน">
                                        <ItemTemplate>
                                            <asp:HiddenField ID="hdfColltype_Id" runat="server" 
                                                Value='<%# Bind("Colltype_Id") %>' />
                                            <asp:Label ID="lblColltype_Name" runat="server" 
                                                Text='<%# Bind("Colltype_Name") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="เลขที่โฉนด">
                                        <ItemTemplate>
                                            <asp:Label ID="lblChanode" runat="server" Text='<%# Bind("Chanode") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="บ้านเลขที่">
                                        <ItemTemplate>
                                            <asp:Label ID="lblBuild_No" runat="server" Text='<%# Bind("Build_No") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="ขนาดพื้นที่">
                                        <ItemTemplate>
                                            <asp:Label ID="lblArea" runat="server" Text='<%# Bind("Area") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="ตรม. ละ">
                                        <ItemTemplate>
                                            <asp:Label ID="lblUnit_Price" runat="server" 
                                                Text='<%# eval("Unit_Price", "{0:N}") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="มูลค่าสร้างเสร็จ">
                                        <ItemTemplate>
                                            <asp:Label ID="lblValue_Price" runat="server" 
                                                Text='<%# Bind("Value_Price", "{0:N}") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="% สร้างเสร็จ">
                                        <ItemTemplate>
                                            <asp:Label ID="lblPercent_Finish" runat="server" 
                                                Text='<%# Bind("Percent_Finish") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="มูลค่าที่สร้างเสร็จ">
                                        <ItemTemplate>
                                            <asp:Label ID="lblFinish_Price" runat="server" 
                                                Text='<%# Bind("Finish_Price", "{0:N}") %>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Right" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="อายุใช้งาน">
                                        <ItemTemplate>
                                            <asp:Label ID="lblAge" runat="server" Text='<%# Bind("Age") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="ค่าเสื่อมต่อปี">
                                        <ItemTemplate>
                                            <asp:Label ID="lblPercent1" runat="server" Text='<%# Bind("Percent1") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="ค่าเสื่อมปรับปรุง">
                                        <ItemTemplate>
                                            <asp:Label ID="lblPercent2" runat="server" Text='<%# Bind("Percent2") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="ค่าเสื่อม เสื่อมโทรม">
                                        <ItemTemplate>
                                            <asp:Label ID="lblPercent3" runat="server" Text='<%# Bind("Percent3") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="รวมค่าเสื่อม">
                                        <ItemTemplate>
                                            <asp:Label ID="lblTotal_Percent" runat="server" 
                                                Text='<%# Bind("Total_Percent") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="มูลค่าค่าเสื่อม">
                                        <ItemTemplate>
                                            <asp:Label ID="lblDeteriorate" runat="server" 
                                                Text='<%# Bind("Deteriorate", "{0:N}") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="รวมเงิน">
                                        <ItemTemplate>
                                            <asp:Label ID="lblTotal_Building" runat="server" 
                                                Text='<%# Bind("Total_Building", "{0:N}") %>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Right" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="รวมเงินราคาตลาด">
                                        <ItemStyle HorizontalAlign="Right" Width="130px" />                                    
                                        <ItemTemplate>
                                            <asp:Label ID="lblMarketPrice" runat="server" 
                                                Text='<%# Bind("MarketPrice", "{0:N}") %>'></asp:Label>
                                        </ItemTemplate>
                                        <FooterTemplate>
                                                <cc1:mytext ID="TextBoxTotal" runat="server" AllowUserKey="num_Numeric" AutoCurrencyFormatOnKeyUp="True"
                                                    EnableTextAlignRight="True" myId="TextBoxTotal" ReadOnly="True" Width="110px" Text=''>0</cc1:mytext>
                                                <asp:Label ID="LabelBaht" runat="server" Text="บาท"></asp:Label>
                                        </FooterTemplate>
                                    </asp:TemplateField>                                    
                                        <asp:TemplateField HeaderText="">
                                            <ItemStyle Width="25px" />
                                            <ItemTemplate>
                                                <asp:ImageButton ID="imgDetail" runat="server" ImageUrl="~/Images/find1.jpg" Height="22px"
                                                    Width="22px" ToolTip="รายละเอียด" OnClientClick='<%# "changeEditLandIframeSrc("+Eval("ID").toString()+","""+Eval("Temp_AID").toString()+"""); return false;" %>' />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="">
                                            <ItemStyle VerticalAlign="Middle" Width="30px" />
                                            <ItemTemplate>
                                                <asp:ImageButton ID="ImgDelete" runat="server" ImageUrl="~/Images/cancel1.jpg" ToolTip="Delete"
                                                    Width="22px" Height="22px" CommandName="Delete" />
                                            </ItemTemplate>
                                            <FooterTemplate>
                                                <asp:Button ID="ButtonOK" runat="server" Text="ยืนยัน" OnClientClick='<%# "returnValue(); return false;" %>' />
                                            </FooterTemplate>
                                        </asp:TemplateField>                                   
                                </Columns>
                                <FooterStyle BackColor="Tan" />
                                <PagerStyle BackColor="PaleGoldenrod" ForeColor="DarkSlateBlue" 
                                    HorizontalAlign="Center" />
                                <SelectedRowStyle BackColor="DarkSlateBlue" ForeColor="GhostWhite" />
                                <HeaderStyle BackColor="Tan" Font-Bold="True" />
                                <AlternatingRowStyle BackColor="PaleGoldenrod" />
                            </asp:GridView>
                                <asp:SqlDataSource ID="SqlDataSourceBuilding" runat="server" ConnectionString="<%$ ConnectionStrings:AppraisalConn %>"
                                    SelectCommand="GET_PRICE2_50_BY_REQ_ID" SelectCommandType="StoredProcedure" DeleteCommand="DELETE_PRICE2_70_NEW"
                                    DeleteCommandType="StoredProcedure">
                                    <SelectParameters>
                                        <asp:ControlParameter ControlID="TextBoxReq_Id" Name="Req_Id" PropertyName="Text"
                                            Type="Int32" />
                                        <asp:ControlParameter ControlID="TextBoxHub_Id" Name="Hub_Id" PropertyName="Text"
                                            Type="Int32" />
                                    </SelectParameters>
                                    <DeleteParameters>
                                        <asp:Parameter Name="Req_Id" Type="Int32" />
                                        <asp:Parameter Name="Hub_Id" Type="Int32" />
                                        <asp:Parameter Name="Id" Type="Int32" />
                                    </DeleteParameters>
                                </asp:SqlDataSource>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
        
        <asp:Button ID="ButtonBuilding" runat="server" Style="display: none;" />
        <cc1:ModalPopupExtender ID="ModalPopupExtenderBuilding" runat="server" TargetControlID="ImageButtonAddBuilding"
            PopupControlID="panelBuilding" BackgroundCssClass="modalBackground1" BehaviorID="mpeBehaviorBuilding">
        </cc1:ModalPopupExtender>
        <cc1:RoundedCornersExtender ID="RoundedCornersExtenderBuilding" runat="server" TargetControlID="pnlInnerPopupBuilding"
            BorderColor="black" Radius="4">
        </cc1:RoundedCornersExtender>
        <asp:Panel ID="panelBuilding" runat="server" CssClass="outerPopup" Style="display: none;">
            <asp:Panel ID="pnlInnerPopupBuilding" runat="server" Width="1100px" CssClass="innerPopup">
                <iframe id="IframeBuilding" src="" width="1100" height="610" frameborder="0" scrolling="yes">
                </iframe>
            </asp:Panel>
        </asp:Panel>
        
    </div>
    </form>
</body>
</html>
