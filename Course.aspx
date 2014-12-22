﻿<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Course.aspx.cs" Inherits="Course" MasterPageFile="~/MasterPage.master"%>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>
<asp:Content ID="Content1" runat="server" 
    contentplaceholderid="ContentPlaceHolder1">
    
    
    <div id="body" 
    style="border-color: #3D3A40; margin: auto; width:768px; border-right-style: solid; border-left-style: solid;">
    <div>
        <br />
        
        <div style="font-weight: 700; text-align: center; font-family: Georgia; font-size: xx-large; color: #49464B">Create new Courses</div>
        
        <br />
        <fieldset>
        <legend style="padding: 3px; font-family: Rockwell; color: #FFFFFF; background-color: #808080">
            &nbsp;Enter new&nbsp; Course informations </legend>
        <table style="width:100%;">
            <tr>
                <td class="style4">
                    Code<asp:RegularExpressionValidator ID="RegularExpressionValidator1" 
                        runat="server" ControlToValidate="txtbxCode" ErrorMessage="*" 
                        ValidationExpression="\w{1,6}"></asp:RegularExpressionValidator></td>
                <td class="style2">
                    <asp:TextBox ID="txtbxCode" runat="server"></asp:TextBox>
                </td>
                <td rowspan="4" valign="top" 
                    style="text-align: center; font-family: 'Microsoft Sans Serif'; font-size: small">
                    Select the modules of the new course (Optional)<br />
                    <asp:ListBox ID="lstbxModules" runat="server" DataSourceID="ModulesList" 
                        DataTextField="mname" DataValueField="mcode" Height="118px" 
                        SelectionMode="Multiple" 
                        style="font-family: 'Lucida Sans Unicode'; font-size: small" Width="352px" 
                        ToolTip="Select related modules (optional)">
                    </asp:ListBox>
                    <asp:SqlDataSource ID="ModulesList" runat="server" 
                        ConnectionString="<%$ ConnectionStrings:aptechConnectionString %>" 
                        
                        SelectCommand="SELECT [mcode], [mname] FROM [module_master] ORDER BY [mname]">
                    </asp:SqlDataSource>
                </td>
            </tr>
            <tr>
                <td class="style4">
                    Name<asp:RegularExpressionValidator ID="RegularExpressionValidator2" 
                        runat="server" ControlToValidate="txtbxName" ErrorMessage="*" 
                        ValidationExpression="[\w ]{10,150}"></asp:RegularExpressionValidator></td>
                <td class="style2">
                    <asp:TextBox ID="txtbxName" runat="server" Width="240px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="style4">
                    Start date</td>
                <td class="style2">
                    <asp:TextBox ID="txtbxStartDate" runat="server"></asp:TextBox>
                    <cc1:CalendarExtender ID="CalendarExtender1" runat="server" 
                        TargetControlID="txtbxStartDate" Format="dd-MM-yyyy">
                    </cc1:CalendarExtender>
                </td>
            </tr>
            <tr>
                <td class="style4">
                    Duration (hours)<asp:RegularExpressionValidator 
                        ID="RegularExpressionValidator4" runat="server" 
                        ControlToValidate="txtbxDuration" ErrorMessage="*" 
                        ValidationExpression="\d{1,4}"></asp:RegularExpressionValidator></td>
                <td class="style2">
                    <asp:TextBox ID="txtbxDuration" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="style3" colspan="2">
                    <asp:Button ID="btnReset" runat="server" Text="Reset" Width="104px" 
                        onclick="btnReset_Click" />
                </td>
                <td align="right">
                    <asp:Button ID="btnCreate" runat="server" onclick="btnCreate_Click" 
                        Text="Create" style="height: 26px" Width="100px" />
                </td>
            </tr>
        </table>
        </fieldset>
    </div>
    <br />
    <asp:GridView ID="gvwCourses" runat="server" AllowPaging="True" 
        AutoGenerateColumns="False" AutoGenerateDeleteButton="True" 
        AutoGenerateEditButton="True" CellPadding="4" 
        DataKeyNames="ccode" DataSourceID="CoursesList" ForeColor="#333333" 
        GridLines="None" 
        Width="760px" style="font-family: 'Lucida Sans Unicode'; font-size: small; text-align: center"
         OnRowCommand="gvwCourses_RowCommand" AllowSorting="True">
        <RowStyle BackColor="#E3EAEB" />
        <Columns>
            <asp:BoundField DataField="ccode" HeaderText="Code" ReadOnly="True" 
                SortExpression="ccode" />
            <asp:BoundField DataField="cname" HeaderText="Name" SortExpression="cname" />
            <asp:BoundField DataField="startdate" HeaderText="Start Date" 
                SortExpression="startdate" />
            <asp:BoundField DataField="duration" HeaderText="Duration" 
                SortExpression="duration" />
            <asp:ButtonField ButtonType="Button" CommandName="editCourse" 
                Text="Modules - Students" />
        </Columns>
        <FooterStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="#666666" ForeColor="White" HorizontalAlign="Center" />
        <SelectedRowStyle BackColor="#C5BBAF" Font-Bold="True" ForeColor="#333333" />
        <HeaderStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
        <EditRowStyle BackColor="#7C6F57" />
        <AlternatingRowStyle BackColor="White" />
    </asp:GridView>
    <asp:SqlDataSource ID="CoursesList" runat="server" 
        ConnectionString="<%$ ConnectionStrings:aptechConnectionString %>" 
        SelectCommand="SELECT * FROM [course_master] ORDER BY [cname]" 
            DeleteCommand="DELETE FROM [course_master] WHERE [ccode] = @ccode" 
            InsertCommand="INSERT INTO [course_master] ([ccode], [cname], [startdate], [duration]) VALUES (@ccode, @cname, @startdate, @duration)" UpdateCommand="UPDATE [course_master] SET [cname] = @cname, [startdate] = @startdate, [duration] = @duration WHERE [ccode] = @ccode"
        >
        <DeleteParameters>
            <asp:Parameter Name="ccode" Type="String" />
        </DeleteParameters>
        <UpdateParameters>
            <asp:Parameter Name="cname" Type="String" />
            <asp:Parameter DbType="Date" Name="startdate" />
            <asp:Parameter Name="duration" Type="Int32" />
            <asp:Parameter Name="ccode" Type="String" />
        </UpdateParameters>
        <InsertParameters>
            <asp:Parameter Name="ccode" Type="String" />
            <asp:Parameter Name="cname" Type="String" />
            <asp:Parameter DbType="Date" Name="startdate" />
            <asp:Parameter Name="duration" Type="Int32" />
        </InsertParameters>
    </asp:SqlDataSource>
    </div>
    <style type="text/css">
       
        .style2
        {
            width: 247px;
        }
       
        .style3
        {
        }
        .style4
        {
            width: 133px;
            font-family: "Microsoft Sans Serif";
            font-size: small;
        }
               
    </style>
        
        

</asp:Content>