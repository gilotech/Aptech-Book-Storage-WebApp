<%@ Page Language="C#" AutoEventWireup="true" CodeFile="CoursesUpdater.aspx.cs" Inherits="CoursesUpdater" MasterPageFile="~/MasterPage.master"%>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>
<asp:Content ID="Content1" runat="server" 
    contentplaceholderid="ContentPlaceHolder1">
    <div id="body" 
        style="border-color: #3D3A40; margin: auto; width: 768px; border-right-style: solid; border-left-style: solid;">
    
    
    
        <div class="style6">
            <span class="style7">Update Courses</span><br class="style8" />
        </div>
        <table style="width:100%;">
            <tr>
                <td class="style1" colspan="4">
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style9">
                    Course Code</td>
                <td class="style12">
                    <asp:DropDownList ID="lstCoursesCode" runat="server" 
                        DataSourceID="CoursesNames" DataTextField="ccode" DataValueField="ccode" 
                        AutoPostBack="True" 
                        onselectedindexchanged="lstCoursesCode_SelectedIndexChanged"
                        style="font-family: 'Microsoft Sans Serif'; font-size: small">
                    </asp:DropDownList>
                </td>
                <td class="style5">
                    Starting Date</td>
                <td>
                    <asp:TextBox ID="txtbxStartingDate" runat="server" Enabled="False" 
                        
                        style="font-family: 'Microsoft Sans Serif'; text-align: center; font-weight: 700; font-size: small" 
                        Width="107px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="style9">
                    Course Name</td>
                <td class="style12">
                    <asp:DropDownList ID="lstCoursesNames" runat="server" 
                        DataSourceID="CoursesNames" DataTextField="cname" DataValueField="ccode" 
                        
                        style="margin-left: 0px; font-family: 'Microsoft Sans Serif'; font-size: small;" AutoPostBack="True" 
                        onselectedindexchanged="lstCoursesNames_SelectedIndexChanged">
                    </asp:DropDownList>
                </td>
                <td class="style5">
                    Duration (Hours)</td>
                <td>
                    <asp:TextBox ID="txtbxDuration" runat="server" Enabled="False" 
                        
                        style="font-family: 'Microsoft Sans Serif'; text-align: center; font-weight: 700; font-size: small" 
                        Width="107px"></asp:TextBox>
                </td>
            </tr>
        </table>
        <asp:SqlDataSource ID="CoursesNames" runat="server" 
            ConnectionString="<%$ ConnectionStrings:aptechConnectionString %>" 
            
            SelectCommand="SELECT [ccode], [cname] FROM [course_master] ORDER BY [cname]">
        </asp:SqlDataSource>
        <cc1:TabContainer ID="TabContainer1" runat="server" ActiveTabIndex="0" 
            Width="100%">
            <cc1:TabPanel runat="server" HeaderText="Add / Remove Modules" ID="tabModules">
 
                <ContentTemplate><br /><table style="width:100%;"><tr><td class="style11" 
                        align="center">Select the Modules to <b>Remove</b></td><td class="style10">&#160;</td><td 
                        style="text-align: center">Select the Modules to <b>Add</b></td></tr><tr><td rowspan="4" 
                        valign="top" class="style11"><asp:ListBox ID="lstAffectedModules" 
                        runat="server" Height="290px" 
                                    Width="310px" DataSourceID="AffectedModules" 
                        DataTextField="mname" DataValueField="mcode" 
                        style="font-family: 'Microsoft Sans Serif'; font-size: small" 
                        SelectionMode="Multiple"></asp:ListBox><asp:SqlDataSource ID="AffectedModules" runat="server" 
                        ConnectionString="<%$ ConnectionStrings:aptechConnectionString %>" 
                        SelectCommand="SELECT module_master.mcode, module_master.mname FROM course_module INNER JOIN module_master ON course_module.mcode = module_master.mcode"></asp:SqlDataSource></td><td class="style10">&#160;</td><td rowspan="4" valign="top" 
                        style="text-align: center"><asp:ListBox ID="lstNotAffectedModules" 
                        runat="server" Height="290px" 
                                    Width="310px" DataSourceID="NotAffectedModules" 
                        DataTextField="mname" DataValueField="mcode" 
                        style="font-family: 'Microsoft Sans Serif'; font-size: small" 
                        SelectionMode="Multiple"></asp:ListBox>
                        <asp:SqlDataSource ID="NotAffectedModules" runat="server" 
                        ConnectionString="<%$ ConnectionStrings:aptechConnectionString %>" 
                        SelectCommand="SELECT [mcode], [mname] FROM [module_master]"></asp:SqlDataSource></td></tr><tr><td align="center" class="style10"><asp:Button ID="btnAddModules" 
                            runat="server" Text="Add Selected" Height="26px" 
                                    Width="116px" OnClick="btnAddModules_Click" /></td></tr><tr><td style="text-align: center" class="style10"><asp:Button ID="btnRemoveModules" 
                                runat="server" Text="Remove Selected" 
                                    Height="26px" Width="116px" OnClick="btnRemoveModules_Click" /></td></tr><tr><td class="style10">&#160;</td></tr><tr><td class="style11">&#160;</td><td class="style10">&#160;</td><td>&#160;</td></tr></table>
                </ContentTemplate>
 
            </cc1:TabPanel>
            <cc1:TabPanel ID="tabStudents" runat="server" HeaderText="Add / Remove Students">
                <ContentTemplate><br /><table style="width:100%;"><tr>
                    <td style="text-align: center">Select the Students to <b>Remove</b></td><td>&#160;</td>
                    <td style="text-align: center">Select the Students to <b>Add</b></td></tr><tr><td rowspan="4" valign="top"><asp:ListBox 
                        ID="lstbxAffectedStudents" runat="server" 
                                    DataSourceID="AffectedStudents" DataTextField="sname" DataValueField="scode" 
                                    Height="290px" 
                        style="font-family: 'Microsoft Sans Serif'; font-size: small" 
                        Width="310px" SelectionMode="Multiple"></asp:ListBox><asp:SqlDataSource 
                        ID="AffectedStudents" runat="server" 
                                    ConnectionString="<%$ ConnectionStrings:aptechConnectionString %>" 
                                    
                        SelectCommand="SELECT DISTINCT student_master.scode, student_master.sname FROM student_course INNER JOIN student_master ON student_course.scode = student_master.scode"></asp:SqlDataSource></td><td>&#160;</td><td rowspan="4" valign="top"><asp:ListBox 
                        ID="lstbxNotAffectedStudents" runat="server" 
                                    DataSourceID="NotAffectedStudents" DataTextField="sname" DataValueField="scode" 
                                    Height="290px" style="font-family: 'Microsoft Sans Serif'; font-size: small" 
                        Width="310px" SelectionMode="Multiple"></asp:ListBox>
                    <asp:SqlDataSource 
                        ID="NotAffectedStudents" runat="server" 
                                    ConnectionString="<%$ ConnectionStrings:aptechConnectionString %>" 
                                    
                        SelectCommand="SELECT [sname], [scode] FROM [student_master]"></asp:SqlDataSource></td></tr><tr><td align="center"><asp:Button ID="btnAddStudents" runat="server" Height="26px" 
                                    onclick="btnAddStudents_Click" Text="Add Selected" Width="116px" /></td></tr><tr><td style="text-align: center"><asp:Button 
                            ID="btnRemoveStudents" runat="server" Height="27px" 
                                    Text="Remove Selected" Width="115px" 
                            onclick="btnRemoveStudents_Click" /></td></tr><tr><td>&#160;</td></tr><tr><td>&#160;</td><td>&#160;</td><td>&#160;</td></tr></table>
                </ContentTemplate>
            </cc1:TabPanel>
        </cc1:TabContainer>
    
    
    
    </div>
</asp:Content>
<asp:Content ID="Content2" runat="server" contentplaceholderid="head">

    <style type="text/css">
        .style1
        {
        }
        .style3
        {
            width: 531px;
        }
    .style5
    {
            width: 147px;
            font-family: Calibri;
            font-size: medium;
        }
    .style6
    {
        text-align: center;
    }
    .style7
    {
        font-size: xx-large;
        font-weight: bold;
        font-family: Georgia;
        color: #808080;
    }
    .style8
    {
        color: #808080;
    }
    .style9
    {
            font-size: medium;
            font-family: Calibri;
            width: 127px;
        }
    .style10
    {
        width: 97px;
    }
    .style11
    {
        width: 103px;
    }
    .style12
    {
        width: 375px;
    }
    </style>

</asp:Content>

