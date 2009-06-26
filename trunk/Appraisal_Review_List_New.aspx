<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="Appraisal_Review_List_New.aspx.vb" Inherits="Appraisal_Review_List_New" UICulture="th-TH" Culture="th-TH" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <br />
<br />

        <asp:GridView ID="GridView_Review_List" runat="server" AutoGenerateColumns="False" 
            CellPadding="2" DataKeyNames="APPS_ID" DataSourceID="SqlDataSource1" 
            ForeColor="Black" GridLines="Horizontal" BackColor="LightGoldenrodYellow" 
            BorderColor="Tan" BorderWidth="1px" ShowFooter="True" 
        style="font-size: small" AllowPaging="True" PageSize="15">
            <FooterStyle BackColor="Tan" />
            <Columns>
                            <asp:TemplateField>
                    <HeaderTemplate>
                        <asp:CheckBox runat="server" ID="cb1" AutoPostBack="true" 
                            OnCheckedChanged="cb1_Checked"/> 
                    </HeaderTemplate>
                   <ItemTemplate>
                     <asp:CheckBox runat="server" ID="cb2"/>  
                   </ItemTemplate> 
                <ItemStyle HorizontalAlign="Center" />
                <HeaderStyle HorizontalAlign="Center" />
             </asp:TemplateField> 
                            <asp:TemplateField HeaderText="APPRAISAL ID" SortExpression="APPS_ID">
                                <ItemTemplate>
                                    <asp:Label ID="lblAPPS_ID" runat="server" Text='<%# Bind("APPS_ID") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="CIF" SortExpression="CIF">
                                <ItemStyle Width="80px" />
                                <ItemTemplate>
                                    <asp:Label ID="lblCIF" runat="server" Text='<%# Bind("CIF") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="CIF NAME" SortExpression="CIF NAME">
                                <ItemStyle Width="300px" />
                                <ItemTemplate>
                                    <asp:Label ID="lblCIFNAME" runat="server" Text='<%# Bind("Cifname") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Class">
                                <ItemStyle HorizontalAlign="Center" Width="80px" />
                                <ItemTemplate>
                                    <asp:Label ID="lblClass" runat="server" Text='<%# Bind("Class") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField> 
                            <asp:TemplateField HeaderText="COLLVAL">
                                <ItemStyle HorizontalAlign="Right" Width="120px" />
                                <ItemTemplate>
                                    <asp:Label ID="lblCOLLVAL" runat="server" Text='<%# Bind("COLLVAL", "{0:N}") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField> 
                            <asp:TemplateField HeaderText="APPRAISAL DATE" >
                                <ItemStyle HorizontalAlign="Center" Width="200px" />
                                <ItemTemplate>
                                    <asp:Label ID="lblVALDATE" runat="server" Text='<%# string.Format( "{0:dd/MM/yyyy}",EVAL("VALDATE")) %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
<%--                            <asp:TemplateField HeaderText="Notice Date" >
                                <ItemStyle HorizontalAlign="Center" Width="200px" />
                                <ItemTemplate>
                                    <asp:Label ID="lblNoticeDate" runat="server" Text='<%# Bind("NoticeDate") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField> --%>  
                            <asp:TemplateField HeaderText="Review Date" >
                                <ItemStyle HorizontalAlign="Center" Width="200px" />
                                <ItemTemplate>
                                    <asp:Label ID="lblReviewDate" runat="server" Text='<%# string.Format( "{0:dd/MM/yyyy}",EVAL("ReviewDate")) %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>                                                                                     <%--                            <asp:TemplateField HeaderText="Notice Date" >
                                <ItemStyle HorizontalAlign="Center" Width="200px" />
                                <ItemTemplate>
                                    <asp:Label ID="lblNoticeDate" runat="server" Text='<%# Bind("NoticeDate") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>  --%>                          
<%--                            <asp:TemplateField>
								    <ItemTemplate>
								            <asp:button runat="server" id="AddFileButton" Text="Add File"
                                            type="button" value="Add File" />
								    </ItemTemplate>
							</asp:TemplateField>--%>
                            <asp:TemplateField HeaderText="">
                                <ItemStyle Width="25px" />
                                <ItemTemplate>
                                    <asp:ImageButton ID="imgCid" runat="server" 
                                        ImageUrl="~/Images/building.png" Height="22px" Width="22px" 
                                        ToolTip="ชิ้นทรัพย์หลักประกัน" CommandName="Select" OnClick="imgCid_Click" />
                                </ItemTemplate>                              
                            </asp:TemplateField>			
            </Columns>
            <PagerStyle BackColor="PaleGoldenrod" ForeColor="DarkSlateBlue" 
                HorizontalAlign="Center" />
            <SelectedRowStyle BackColor="DarkSlateBlue" ForeColor="GhostWhite" />
            <HeaderStyle BackColor="Tan" Font-Bold="True" />
            <AlternatingRowStyle BackColor="PaleGoldenrod" />
        </asp:GridView>
     <asp:Button ID="btnReview" runat="server" Text="REVIEW AUTO" />       
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" > 
      </asp:SqlDataSource>
    

    
</asp:Content>

