<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Appraisal_Collateral_Picture.aspx.vb" Inherits="Appraisal_Collateral_Picture" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
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
        .divCol
        {
            font-weight: bold;
            color: blue;
            float: left;
            width: 140px;
            text-align: left;
            margin-right: 30px;
            white-space: nowrap;
        }
        .modalBox
        {
            background-color: #f5f5f5;
            border-width: 3px;
            border-style: solid;
            border-color: Blue;
            padding: 3px;
        }
        .modalBox caption
        {
            background-image: url(images/window_titlebg.gif);
            background-repeat: repeat-x;
        }
        .divColLast
        {
            float: left;
            white-space: nowrap;
        }
        .clearer
        {
            clear: both;
            overflow: hidden;
            background-color: transparent;
            filter: alpha(opacity=0);
            opacity: 0.0;
            height: 1px;
            margin: 1px 1px 1px 1px;
            max-height: 2px;
        }
        .Timg
        {
            margin: 10px 10px 10px 10px;
            padding: 4px;
            border-top: 1px solid #ddd;
            border-left: 1px solid #ddd;
            border-bottom: 1px solid #c0c0c0;
            border-right: 1px solid #c0c0c0;
            background: #fff;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div style="text-align:center;">

                    <asp:ListView ID="lvShowPicture_P1" runat="server" GroupItemCount="3">
                        <LayoutTemplate>
                            <table id="groupPlaceholderContainer" runat="server" border="0" cellpadding="0" cellspacing="0">
                                <tr id="groupPlaceholder" runat="server">
                                </tr>
                            </table>
                        </LayoutTemplate>
                        <GroupTemplate>
                            <tr id="itemPlaceholderContainer" runat="server">
                                <td id="itemPlaceholder" runat="server">
                                </td>
                            </tr>
                        </GroupTemplate>
                        <ItemTemplate>
                            <td id="Td1" runat="server" align="center" style="background-color: #e8e8e8; color: #333333;">
                                <a href='<%# Eval("Pic_Path") %>' target="_blank">
                                    <asp:Image CssClass="Timg" runat="server" ID="imPhotop1" Width="100px" ImageUrl='<%# Eval("Pic_Path") %>' />
                                </a>
                            </td>
                        </ItemTemplate>
                    </asp:ListView>

                    <asp:Label ID="LabelMessage" runat="server" 
                        style="font-weight: 700; color: #FF0000"></asp:Label>

                <asp:SqlDataSource ID="sdsPictureList_Price1" runat="server" 
                    ConnectionString="<%$ ConnectionStrings:AppraisalConn %>">
                </asp:SqlDataSource>

    </div>
    </form>
</body>
</html>
