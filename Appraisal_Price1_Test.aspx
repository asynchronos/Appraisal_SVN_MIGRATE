<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="Appraisal_Price1_Test.aspx.vb" Inherits="Test_Appraisal_Price1_Test" %>

<%@ Register assembly="Mytextbox" namespace="Mytextbox" tagprefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
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
                <asp:TextBox ID="TxtLat" runat="server" ></asp:TextBox>
            &nbsp;<asp:Button ID="BtnLatLng" runat="server" Text="หาค่า Lat,Lng" />
            </td>
        </tr>
        <tr>
            <td class="style3">
                Lng</td>
            <td class="style4">
                <asp:TextBox ID="TxtLng" runat="server" ></asp:TextBox>
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
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style2">
                &nbsp;</td>
            <td>
                <asp:Button ID="BtnConfirm" runat="server" Text="กำหนดราคาที่ 1" />
            </td>
        </tr>
    </table>
            </td>
            <td valign="top">

            </td>
        </tr>
    </table>
</asp:Content>

