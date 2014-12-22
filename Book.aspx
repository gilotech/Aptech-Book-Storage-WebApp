﻿<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Book.aspx.cs" Inherits="Book" MasterPageFile="~/MasterPage.master" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>



<asp:Content ID="Content1" runat="server" 
    contentplaceholderid="ContentPlaceHolder1">
        
         <div id="body" 
    style="border-color: #3D3A40; margin: auto; width:768px; border-right-style: solid; border-left-style: solid;">
        <br />
        
        <div style="font-weight: 700; text-align: center; font-family: Georgia; font-size: xx-large; color: #49464B">Create new 
            Books</div>
        
        <br />
        <fieldset>
        <legend style="padding: 3px; font-family: Rockwell; color: #FFFFFF; background-color: #808080">
            Enter new Book informations</legend>
        
        <table style="width:100%;">
            <tr>
                <td class="style5">
                    Code
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" 
                        ControlToValidate="txtbxCode" ErrorMessage="*" 
                        ValidationExpression="[\w-]{1,8}"></asp:RegularExpressionValidator>
                </td>
                <td class="style6">
                    <asp:TextBox ID="txtbxCode" runat="server"></asp:TextBox>
                </td>
                <td rowspan="3" valign="top" align="center" 
                    style="font-family: 'Microsoft Sans Serif'; font-size: small">
                    Select the modules related to the new book (Optional)<br />
                    <asp:ListBox ID="lstbxModules" runat="server" DataSourceID="Modules" 
                        DataTextField="mname" DataValueField="mcode" Height="104px" Width="352px" 
                        style="font-family: 'Lucida Sans Unicode'; font-size: small">
                    </asp:ListBox>
                    <asp:SqlDataSource ID="Modules" runat="server" 
                        ConnectionString="<%$ ConnectionStrings:aptechConnectionString %>" 
                        
                        SelectCommand="SELECT [mcode], [mname] FROM [module_master] ORDER BY [mname]">
                    </asp:SqlDataSource>
                </td>
            </tr>
            <tr>
                <td class="style3">
                    Title
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" 
                        ControlToValidate="txtbxTitle" ErrorMessage="*" ValidationExpression=".{20,}"></asp:RegularExpressionValidator>
                </td>
                <td class="style4">
                    <asp:TextBox ID="txtbxTitle" runat="server" Width="297px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="style3">
                    Quantity
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" 
                        ControlToValidate="txtbxQuantity" ErrorMessage="*" 
                        ValidationExpression="\d{1,3}"></asp:RegularExpressionValidator>
                </td>
                <td class="style4">
                    <asp:TextBox ID="txtbxQuantity" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="style2" colspan="2">
                    <asp:Button ID="btnReset" runat="server" Text="Reset" 
                        onclick="btnReset_Click" Width="100px" />
                </td>
                <td align="right">
                    <asp:Button ID="btnCreate" runat="server" onclick="btnCreate_Click" 
                        style="height: 26px" Text="Create" Width="102px" />
                </td>
            </tr>
        </table>
        </fieldset>
        <br />
             
        <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" 
            AutoGenerateDeleteButton="True" AutoGenerateEditButton="True" CellPadding="4" 
            DataKeyNames="bcode" DataSourceID="BookList" ForeColor="#333333" 
            GridLines="None" style="text-align: center; font-family: 'Microsoft Sans Serif'; font-size: small;" 
            Width="100%" AllowPaging="True" onrowcommand="GridView2_RowCommand" 
                 onselectedindexchanged="GridView2_SelectedIndexChanged" 
                 AllowSorting="True">
            <RowStyle BackColor="#E3EAEB" />
            <Columns>
                <asp:BoundField DataField="bcode" HeaderText="Code" ReadOnly="True" 
                    SortExpression="bcode" />
                <asp:BoundField DataField="title" HeaderText="Title" SortExpression="title" />
                <asp:BoundField DataField="qty" HeaderText="Quantity" SortExpression="qty" />
                <asp:BoundField DataField="ROL" HeaderText="ROL" SortExpression="ROL" />
                <asp:ButtonField ButtonType="Button" Text="Modules - Students" 
                    CommandName="editBook" />
            </Columns>
            <FooterStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#666666" ForeColor="White" HorizontalAlign="Center" />
            <SelectedRowStyle BackColor="#C5BBAF" Font-Bold="True" ForeColor="#333333" />
            <HeaderStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
            <EditRowStyle BackColor="#7C6F57" />
            <AlternatingRowStyle BackColor="White" />
        </asp:GridView>
        <asp:SqlDataSource ID="BookList" runat="server" 
            ConnectionString="<%$ ConnectionStrings:aptechConnectionString %>" 
            SelectCommand="SELECT * FROM [book_master] ORDER BY [title]" 
                 DeleteCommand="DELETE FROM [book_master] WHERE [bcode] = @bcode" 
                 InsertCommand="INSERT INTO [book_master] ([bcode], [title], [qty], [ROL]) VALUES (@bcode, @title, @qty, @ROL)" 
                 UpdateCommand="UPDATE [book_master] SET [title] = @title, [qty] = @qty, [ROL] = @ROL WHERE [bcode] = @bcode">
            <DeleteParameters>
                <asp:Parameter Name="bcode" Type="String" />
            </DeleteParameters>
            <UpdateParameters>
                <asp:Parameter Name="title" Type="String" />
                <asp:Parameter Name="qty" Type="Int32" />
                <asp:Parameter Name="ROL" Type="Int32" />
                <asp:Parameter Name="bcode" Type="String" />
            </UpdateParameters>
            <InsertParameters>
                <asp:Parameter Name="bcode" Type="String" />
                <asp:Parameter Name="title" Type="String" />
                <asp:Parameter Name="qty" Type="Int32" />
                <asp:Parameter Name="ROL" Type="Int32" />
            </InsertParameters>
             </asp:SqlDataSource>
    
    </div>
    <style type="text/css">
        .style1
        {
            width: 324px;
        }
        .style2
        {
        }
        .style3
        {
            width: 62px;
            font-family: "Microsoft Sans Serif";
            font-size: small;
        }
        .style4
        {
            font-family: "Arial Black";
            font-size: small;
            width: 320px;
        }
    .style5
    {
        width: 62px;
        font-family: "Microsoft Sans Serif";
        font-size: small;
        height: 42px;
    }
    .style6
    {
        font-family: "Arial Black";
        font-size: small;
        width: 320px;
        height: 42px;
    }
    </style>


</asp:Content>


