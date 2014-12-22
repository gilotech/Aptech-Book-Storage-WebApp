<%@ Page Language="C#" AutoEventWireup="true"  CodeFile="Default.aspx.cs" Inherits="_Default"%>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Authentication</title>
    <style type="text/css">
        .hoverLink
        {
        	font-weight:normal;
        	padding:5px;
        	text-decoration:none;
        }
        .popUpMenu
        {
            background-color:#2b292d;	
            color:Black;
            display:block;
            padding:0px;
        }
        
        .style1
        {
            height: 24px;
            text-align: center;
        }
        .style2
        {
            text-align: center;
        }
        
        .style3
        {
            width: 124px;
        }
        .style4
        {
            height: 24px;
            width: 124px;
        }
        
        </style>
</head>
<body>    
    <form id="form1" runat="server">
    <div id="body" 
    
        
        style="margin: auto; width:450px; height:300px; background-color: #5b5b5b; margin-top: 150px;">
    
        <br />
        <asp:Image ID="Image1" runat="server" Height="79px" 
            ImageUrl="~/images/logo.jpg" Width="172px" />
        <br />
        <table align="center" style="width: 80%; font-family: 'Microsoft Sans Serif';">
            <tr>
                <td class="style3">
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style3">
                    &nbsp;&nbsp;&nbsp;
                    Username</td>
                <td class="style2">
                    <asp:TextBox ID="txtbxUsername" runat="server" Height="25px" Width="160px" 
                        style="text-align: center"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="style3">
                    &nbsp;&nbsp;&nbsp;
                    Password</td>
                <td class="style2">
                    <asp:TextBox ID="txtbxPassword" runat="server" Height="25px" 
                        TextMode="Password" Width="160px" style="text-align: center"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="style3">
                    &nbsp;</td>
                <td style="font-family: 'Microsoft Sans Serif'; text-align: center">
                    <asp:Label ID="lblError" runat="server" 
                        style="color: #FF0000; font-weight: 700; font-size: small; text-align: center" 
                        Text="Incorrect username or password"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="style4">
                </td>
                <td class="style1">
                    <asp:Button ID="btnSubmit" runat="server" onclick="btnSubmit_Click" 
                        Text="Submit" Width="102px" Height="28px" />
                </td>
            </tr>
        </table>
    
     </div>
    </form>
</body>
</html>
