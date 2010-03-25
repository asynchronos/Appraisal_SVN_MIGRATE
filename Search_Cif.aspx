<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Search_Cif.aspx.vb" Inherits="Search_Cif" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>

    <script src="Js/jquery-1.4.2.min.js" type="text/javascript"></script>
    <script src="Js/common.js" type="text/javascript"></script>
    <script type="text/javascript">

        function returnValue(cif, title, cifName, cifLastname) {
            //Cif=TxtCifColl&Title=ddlTitleColl&CifName=TxtCifNameColl&CifLastname=TxtCifLastNameColl&PopupModal=mpeBehaviorSearchCifColl
            //alert(1);
            var _Cif = getValueFromQueryString("Cif");
            //alert(_Cif);
            var _Title = getValueFromQueryString("Title");
            //alert(_Title);
            var _CifName = getValueFromQueryString("CifName");
            //alert(_CifName);
            var _CifLastName = getValueFromQueryString("CifLastname");
            //alert(_CifLastName);
            var _PopupModal = getValueFromQueryString("PopupModal");
            //alert(_PopupModal);
            
            window.parent.$("input[myId='"+_Cif+"']")[0].value = cif;
            setDataToDropdownList(_Title,title);
            window.parent.$("input[myId='"+_CifName+"']")[0].value = cifName;
            window.parent.$("input[myId='"+_CifLastName+"']")[0].value = cifLastname;
           //window.parent.$("input[myId='"+_Cif+"']")[0].value = cif;
            window.parent.$find(_PopupModal).hide();
        }

        function sendValue(cif, title, cifName, cifLastname) {
            //alert(cif);
            //alert(cifName);
            //alert(title);
            //alert(window.parent.$("input[myId='TxtCif']")[0].value);
            // หา textbox ในหน้าแม่ แล้วใส่ค่าให้กับ Textbox ที่หาเจอ


            window.parent.$("input[myId='TxtCif']")[0].value = cif;
            //window.parent.$("input[myId='TextBoxTitle']")[0].value = title;
            window.parent.$("input[myId='TxtCifName']")[0].value = cifName;
            window.parent.$("input[myId='TxtCifLastName']")[0].value = cifLastname;
            
            // หา ModalPopup ในหน้าแม่ โดยหาจาก BehaviorId แล้วสั่งให้มันซ่อน
            //var dropdown = window.parent.$("select[myId='ddlTitle']")[0];
            //var SelectedVal = window.parent.$("select[myId='ddlTitle']")[0].options[title].value;
            //alert(window.parent.$("select[myId='ddlTitle']")[0].value);
            
            //นำค่า คำนำหน้าที่เป็นตัวอักษร ไปแม็ทกับฐานข้อมูล
            setDataToDropdownList(title);
            
            var popup = window.parent.$find('mpeBehaviorSearchCif').hide();

            //var btnClose = parent.document.getElementById('btnCloseIframe');
            //var btnClose = window.parent.$("input[myId='btnCloseIframe']")[0];        
            //alert(btnClose);
            //btnClose.click();
            //return false;
        }

        function setDataToDropdownList(MyId,DropdownListText) {
            //หา Dropdown ที่อยู่ในหน้า Parent
            setDropDownList(window.parent.$("select[myId='"+MyId+"']")[0], DropdownListText);

        }

        function setDropDownList(elementRef, valueToSetTo) {

            var isFound = false;
            //นำค่าตัวอักษรที่ ส่งมา เปรียบเทียบกับค่าที่ หาได้จาก Dropdown ในหน้า Parent
            for (var i = 0; i < elementRef.options.length; i++) {
                //alert(i + ":" + elementRef.options[i].text);
                if (elementRef.options[i].text == valueToSetTo) {
                    elementRef.options[i].selected = true;
                    isFound = true;
//                    alert(i + ":" + elementRef.options[i].text + ":" + valueToSetTo);
                } else {
                    elementRef.options[i].selected = false;
                }
            }

            if (isFound == false) {
//                alert('unloop');
                elementRef.options[0].selected = true;
            }
        }


    </script>

</head>
<body>
    <form id="form1" runat="server">
    <div>
        <table>
            <tr>
                <td>
                    Cif :
                    <asp:TextBox ID="TextBoxCif" runat="server"></asp:TextBox>
                    &nbsp;<asp:Button ID="ButtonSearchCif" runat="server" Text="ค้นหา" />
                </td>
            </tr>
            <tr>
                <td>
                    <asp:GridView ID="GridViewCifList" runat="server" AutoGenerateColumns="False" DataSourceID="ObjectDataSourceSearchCif"
                        BackColor="LightGoldenrodYellow" BorderColor="Tan" BorderWidth="1px" CellPadding="2"
                        ForeColor="Black" GridLines="None">
                        <Columns>
                            <asp:TemplateField HeaderText="Cif" SortExpression="Cif">
                                <ItemStyle Width="110px" HorizontalAlign="Center" />
                                <EditItemTemplate>
                                    <asp:TextBox ID="TextBoxCif" runat="server" Text='<%# Bind("Cif") %>'></asp:TextBox>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="LabelCif" runat="server" Text='<%# Bind("Cif") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="คำนำหน้า" SortExpression="Cus_Title">
                                <ItemStyle Width="100px" />
                                <EditItemTemplate>
                                    <asp:TextBox ID="TextBoxCus_Title" runat="server" Text='<%# Bind("Cus_Title") %>'></asp:TextBox>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="LabelCus_Title" runat="server" Text='<%# Bind("Cus_Title") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Customer Name" SortExpression="cus_first">
                                <ItemStyle Width="220px" />
                                <EditItemTemplate>
                                    <asp:TextBox ID="TextBoxcus_first" runat="server" Text='<%# Bind("cus_first") %>'></asp:TextBox>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="Labelcus_first" runat="server" Text='<%# Bind("cus_first") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Customer Lastname" SortExpression="cus_last">
                                <ItemStyle Width="220px" />
                                <EditItemTemplate>
                                    <asp:TextBox ID="TextBoxcus_last" runat="server" Text='<%# Bind("cus_last") %>'></asp:TextBox>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="Labelcus_last" runat="server" Text='<%# Bind("cus_last") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <%--                            <asp:BoundField DataField="cifName" HeaderText="cifName" 
                                SortExpression="cifName" />
                            <asp:BoundField DataField="departName" HeaderText="departName" 
                                SortExpression="departName" />--%>
                            <asp:TemplateField ShowHeader="False">
                                <ItemTemplate>
                                    <asp:ImageButton ID="imgLocation" runat="server" ImageUrl="~/Images/Select_user.png"
                                        Height="22px" Width="22px" ToolTip="เลือกลูกค้า" OnClientClick='<%# "returnValue(" +Eval("cif").toString() +","""+ Eval("Cus_Title").toString() + ""","""+ Eval("cus_first").toString() + ""","""+Eval("cus_last").toString()+"""); return false;" %>' />
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                        <FooterStyle BackColor="Tan" />
                        <PagerStyle BackColor="PaleGoldenrod" ForeColor="DarkSlateBlue" HorizontalAlign="Center" />
                        <SelectedRowStyle BackColor="DarkSlateBlue" ForeColor="GhostWhite" />
                        <HeaderStyle BackColor="Tan" Font-Bold="True" />
                        <AlternatingRowStyle BackColor="PaleGoldenrod" />
                    </asp:GridView>
                    <asp:ObjectDataSource ID="ObjectDataSourceSearchCif" runat="server" SelectMethod="GetCifInfoNew"
                        TypeName="Cif_Mgr">
                        <SelectParameters>
                            <asp:ControlParameter ControlID="TextBoxCif" Name="Cif" PropertyName="Text" Type="Int32" />
                        </SelectParameters>
                    </asp:ObjectDataSource>
                </td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>
