<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Define_SecondPrice.aspx.vb" Inherits="Define_SecondPrice" %>

<%@ Register assembly="Mytextbox" namespace="Mytextbox" tagprefix="cc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>DEFINE SECOND PRICE</title>
        <style type="text/css">
        .style1
        {
            width: 914px;
        }
        .style2
        {
            width: 28%;
        }
        .fstyle
        {
            font-size: medium;
            color: Blue;
            font-weight: bold;
        }
        .fstyle1
        {
            font-size: small;
            color: Blue;
            font-weight: bold;
        }
        .Fcolor
        {                color: #FF0000;
            }
            </style>
</head>
<body style="margin-top:0px; margin-left:0px; margin-right:0px; background-image:url(Images/imagesCAMBBQTW.jpg);">
    <form id="form1" runat="server">
    <div>
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <table border="0" cellspacing="0" cellpadding="0" width="100%" style="height: 80px">
            <tr>
                <td align="left" style="background-color: #FFCE40" class="style1">
                    <img alt="" src="Images/logo_bay.gif" style="" /><br />
                </td>
                <td style="height: 50px; background-color: #FFCE40;" valign="top">
                    <table class="style2">
                        <tr>
                            <td class="fstyle">
                                User ID&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; :
                            </td>
                            <td>
                                <asp:Label ID="lblUserID" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td class="fstyle">
                                User Name&nbsp;&nbsp; :
                            </td>
                            <td>
                                <asp:Label ID="lblUserName" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td class="fstyle">
                                Position&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; :
                            </td>
                            <td>
                                <asp:Label ID="lblPostion" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td class="fstyle">
                                Date&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;:
                            </td>
                            <td>
                                <asp:Label ID="lblDate" runat="server"></asp:Label>
                            </td>
                        </tr>
                    </table>
                    QUEUE ID&nbsp; :
                    <asp:Label CssClass="Fcolor" ID="lblQueueID" runat="server" Font-Bold="True" Font-Size="Large"></asp:Label>
                </td>
            </tr>
        </table>
        <br />
        <br />
        <br />
           <br />
        <br />
        <br />
        <div style="text-align:center;">
            
            <table class="style2" style="border-color:Blue; border-width:15px;">
                <tr>
                    <td style="text-align:left;">
                    CIF</td>
                    <td style="text-align:left;">
                    <asp:Label ID="lblCif" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td style="text-align:left;">
                    ชื่อสกุล
                    </td>
                    <td style="text-align:left;">
                    <asp:Label ID="lblCifName" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td style="text-align:left;">
                    สาขา/ฝ่ายงาน
                    </td>
                    <td style="text-align:left;">
                    <asp:Label ID="lblDepartName" runat="server"></asp:Label>
                    </td>
                </tr>                
                <tr>
                    <td style="text-align:left;">
                    หมายเลขกลุ่มประเมิน</td>
                    <td style="text-align:left;">
                    <asp:DropDownList ID="ddlGroup_TempAID" runat="server" DataSourceID="SDSGroup_TempAID"
                        DataTextField="TEMP_AID" DataValueField="TEMP_AID" AutoPostBack="True">
                    </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td style="text-align:left;">
                    กลุ่มหลักประกัน</td>
                    <td style="text-align:left;">
    
                    <asp:DropDownList ID="DDLCollType" runat="server" DataSourceID="sdsCollType" DataTextField="CollType_Name"
                        DataValueField="CollType_ID">
                    </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td style="text-align:left;">
                    <asp:ImageButton ID="ImgBtFind" runat="server" ImageUrl="~/Images/e02.gif" 
                            style="height: 15px" Visible="False" />
                    </td>
                    <td style="text-align:left;">
                    <asp:ImageButton ID="ImgBtFind0" runat="server" ImageUrl="~/Images/book_blue_view.png" 
                            Height="25px" Width="28px" />
                    &nbsp;
                    <asp:ImageButton ID="ImgBtnPrint" runat="server" ImageUrl="~/Images/printer.png" 
                            Height="25px" Width="28px" />
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                        <asp:Label ID="lblMessage" runat="server" 
                            style="color: #FF0000; font-weight: 700"></asp:Label>
                    </td>
                </tr>
            </table>
            
        </div>
    </div>
    <asp:SqlDataSource ID="SDSGroup_TempAID" runat="server" 
        ConnectionString="<%$ ConnectionStrings:AppraisalConn %>" 
        SelectCommand="GET_TEMP_AID_FROM_DETAIL" SelectCommandType="StoredProcedure">
        <SelectParameters>
            <asp:ControlParameter ControlID="lblQueueID" Name="Q_ID" PropertyName="Text" 
                Type="Int32" />
        </SelectParameters>
    </asp:SqlDataSource>
    <asp:SqlDataSource ID="SDSRoad_Detail" runat="server" ConnectionString="<%$ ConnectionStrings:AppraisalConn %>"
        SelectCommand="SELECT [Road_Detail_ID], [Road_Detail_Name] FROM [Road_Detail]">
    </asp:SqlDataSource>
    <asp:SqlDataSource ID="SDSLand_State" runat="server" ConnectionString="<%$ ConnectionStrings:AppraisalConn %>"
        SelectCommand="SELECT [Land_State_Id], [Land_State_Name] FROM [Land_State]">
    </asp:SqlDataSource>
    <asp:SqlDataSource ID="SDSRoad_Forntoff" runat="server" ConnectionString="<%$ ConnectionStrings:AppraisalConn %>"
        SelectCommand="SELECT [Road_Frontoff_ID], [Road_Frontoff_Name] FROM [Road_Frontoff]">
    </asp:SqlDataSource>
    <asp:SqlDataSource ID="SDSSite" runat="server" ConnectionString="<%$ ConnectionStrings:AppraisalConn %>"
        SelectCommand="SELECT [Site_ID], [Site_Name] FROM [Site]"></asp:SqlDataSource>
    <asp:SqlDataSource ID="sdsCollType" runat="server" ConnectionString="<%$ ConnectionStrings:AppraisalConn %>"
        
        SelectCommand="SELECT D.Q_ID, LEFT (D.Coll_ID, 2) AS CollType_ID, C.CollType_Name FROM Sent_Appraisal_Detail AS D INNER JOIN CollType AS C ON LEFT (D.Coll_ID, 2) = C.CollType_ID WHERE (D.PreAID = @Temp_AID) AND (D.Q_ID = @Q_ID) GROUP BY D.Q_ID, LEFT (D.Coll_ID, 2), C.CollType_Name">
        <SelectParameters>
            <asp:ControlParameter ControlID="ddlGroup_TempAID" DefaultValue="" 
                Name="Temp_AID" PropertyName="SelectedValue" />
            <asp:ControlParameter ControlID="lblQueueID" Name="Q_ID" PropertyName="Text" />
        </SelectParameters>
    </asp:SqlDataSource>
    </form>
</body>
</html>
