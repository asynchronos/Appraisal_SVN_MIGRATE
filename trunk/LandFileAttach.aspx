<%@ Page Language="VB" AutoEventWireup="false" CodeFile="LandFileAttach.aspx.vb" Inherits="LandFileAttach" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .tableWidht {
             width:100%
        }
        .ceterColumnHeader {
            text-align:center;
            text-decoration:blink;
            font-weight:bold;
        }
        .TextSizeBold {
            font-weight:bold;
        }
        .RightMargin {
            
        }
    </style>
    <script type="text/javascript" language="javascript">
        function windowPrint() {
            window.print();
        }   
    </script>
        <style type="text/css" media="print">
        .NotshowOnPrint
            {
                display:none;
            }
        </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <table class ="tableWidht">
            <tr>
                <td align="right">
                    <table>
                        <tr >
                            <td class="NotshowOnPrint">
                                <asp:ImageButton ID="ImageButtonPrint" runat="server" Height="25px" 
                                    ImageUrl="~/Images/printer.png" OnClientClick="windowPrint();" 
                                    ToolTip="พิมพ์หน้านี้" Width="25px" />
                            </td>
                        </tr>
                    </table>                
                </td>
            </tr>
            <tr class="ceterColumnHeader">
                <td>
                    <asp:Label ID="LabelHeader" runat="server" Text="รายละเอียดที่ดินแนบท้าย"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="LabelReqId" runat="server" Text="REQ ID : " CssClass="TextSizeBold"></asp:Label>
                    <asp:Label ID="LabelReqIdValue" runat="server"></asp:Label>
                    <asp:Label ID="LabelHubId" runat="server" Text=" HUB ID : " 
                        CssClass="TextSizeBold"></asp:Label>
                    <asp:Label ID="LabelHubIdValue" runat="server"></asp:Label>
                    <asp:Label ID="LabelHubNameValue" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="LabelCif" runat="server" Text="CIF : " CssClass="TextSizeBold"></asp:Label>
                    <asp:Label ID="LabelCifValue" runat="server"></asp:Label>
                    <asp:Label ID="LabelCifName" runat="server" Text=" ชื่อ - สกุล ลูกค้า " CssClass="TextSizeBold"></asp:Label>
                    <asp:Label ID="LabelCifNameValue" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:GridView ID="GridViewLandList" runat="server" AutoGenerateColumns="False" 
                        DataSourceID="SqlDataSourceLandList" Width="100%">
                        <Columns>
                            <asp:BoundField DataField="SubCollType_Name" HeaderText="ชนิดหลักประกัน" 
                                SortExpression="SubCollType_Name" />
                            <asp:BoundField DataField="Address_No" HeaderText="เลขที่" 
                                SortExpression="Address_No" />
                            <asp:BoundField DataField="Tumbon" HeaderText="ตำบล" 
                                SortExpression="Tumbon" />
                            <asp:BoundField DataField="Amphur" HeaderText="อำเภอ" 
                                SortExpression="Amphur" />
                            <asp:BoundField DataField="PROV_NAME" HeaderText="ชื่อจังหวัด" 
                                SortExpression="PROV_NAME" />                                
                            <asp:BoundField DataField="Rai" HeaderText="ไร่" SortExpression="Rai" />
                            <asp:BoundField DataField="Ngan" HeaderText="งาน" SortExpression="Ngan" />
                            <asp:BoundField DataField="Rawang" HeaderText="วา" 
                                SortExpression="Rawang" />
                            <asp:BoundField DataField="LandNumber" HeaderText="เลขที่ดิน" 
                                SortExpression="LandNumber" />
                            <asp:BoundField DataField="DocNo" HeaderText="หนังสือเล่มที่" SortExpression="DocNo" />     
                            <asp:BoundField DataField="PageNo" HeaderText="หน้าที่" 
                                SortExpression="PageNo" />                                                       
                            <asp:BoundField DataField="Surway" HeaderText="หน้าสำรวจเลขที่" 
                                SortExpression="Surway" />
                            <asp:BoundField DataField="Ownership" HeaderText="เจ้าของกรรมสิทธิ" 
                                SortExpression="Ownership" />
                            <asp:BoundField DataField="Obligation" HeaderText="ภาระผูกพัน" 
                                SortExpression="Obligation" />
                        </Columns>
                    </asp:GridView>
                </td>
            </tr>
            <tr>
                <td>&nbsp;</td>
            </tr>
        </table>
    </div>
    <asp:SqlDataSource ID="SqlDataSourceLandList" runat="server" 
        ConnectionString="<%$ ConnectionStrings:AppraisalConn %>" 
        SelectCommand="GET_PRICE3_50_BY_REQID" SelectCommandType="StoredProcedure">
        <SelectParameters>
            <asp:ControlParameter ControlID="LabelReqIdValue" Name="Req_Id" 
                PropertyName="Text" Type="Int32" />
        </SelectParameters>
    </asp:SqlDataSource>
    </form>
</body>
</html>
