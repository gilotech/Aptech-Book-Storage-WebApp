<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ModuleUpdater.aspx.cs" Inherits="ModuleUpdater" MasterPageFile="~/MasterPage.master"%>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>
<asp:Content ID="Content1" runat="server" 
    contentplaceholderid="ContentPlaceHolder1">
    <div id="body" 
        style="border-color: #3D3A40; margin: auto; width: 768px; border-right-style: solid; border-left-style: solid;">
    
    
    
        <div class="style6">
            <span class="style7">Update Modules</span><br class="style8" />
        </div>
        <table style="width:100%;">
            <tr>
                <td class="style10" colspan="4">
                    </td>
            </tr>
            <tr>
                <td class="style9">
                    Module Code</td>
                <td class="style3">
                    <asp:DropDownList ID="lstModulesCode" runat="server" 
                        DataSourceID="CoursesNames" DataTextField="mcode" DataValueField="mcode" 
                        AutoPostBack="True" 
                        
                        style="font-family: 'Microsoft Sans Serif'; font-size: small" 
                        onselectedindexchanged="lstModulesCode_SelectedIndexChanged">
                    </asp:DropDownList>
                </td>
                <td class="style5">
                    Description</td>
                <td rowspan="2" valign="top">
                    <asp:TextBox ID="txtbxDescription" runat="server" Height="67px" Width="262px" 
                        Enabled="False" TextMode="MultiLine"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="style14">
                    Module Name</td>
                <td class="style12">
                    <asp:DropDownList ID="lstModulesNames" runat="server" 
                        DataSourceID="CoursesNames" DataTextField="mname" DataValueField="mcode" 
                        
                        
                        
                        
                        style="margin-left: 0px; font-family: 'Microsoft Sans Serif'; font-size: small;" 
                        AutoPostBack="True" onselectedindexchanged="lstModulesNames_SelectedIndexChanged" 
                        >
                    </asp:DropDownList>
                </td>
                <td class="style13">
                    </td>
            </tr>
        </table>
        <asp:SqlDataSource ID="CoursesNames" runat="server" 
            ConnectionString="<%$ ConnectionStrings:aptechConnectionString %>" 
            
            SelectCommand="SELECT [mcode], [mname] FROM [module_master] ORDER BY [mname]">
        </asp:SqlDataSource>
        <cc1:TabContainer ID="TabContainer1" runat="server" ActiveTabIndex="0" 
            Width="100%">
            <cc1:TabPanel runat="server" HeaderText="Add To/ Remove From Courses" ID="tabModules">
 
                <ContentTemplate>
                    <br /><table style="width:100%;">
<tr>
<td 
                        align="center">Select the Courses for 
<b>Removing</b></td><td class="style10">&nbsp;</td>
                            
<td style="text-align: center">Select the Courses for 
<b>Adding</b></td></tr>
<tr>
<td class="style11" rowspan="4" valign="top">
                                <asp:ListBox ID="lstAffectedCourses" runat="server" 
                                    DataSourceID="AffectedCourses" 
        DataTextField="cname" DataValueField="ccode" 
                                    Height="290px" SelectionMode="Multiple" 
                                    
        style="font-family: 'Microsoft Sans Serif'; font-size: small" Width="310px"></asp:ListBox>


                                
                                <asp:SqlDataSource ID="AffectedCourses" runat="server" 
                                    ConnectionString="<%$ ConnectionStrings:aptechConnectionString %>" 
                                    
        SelectCommand="SELECT course_master.ccode, course_master.cname FROM course_master INNER JOIN course_module ON course_master.ccode = course_module.ccode"></asp:SqlDataSource>


                                
                            </td><td class="style10">&#160;</td>
<td rowspan="4" style="text-align: center" valign="top">

                                <asp:ListBox ID="lstNotAffectedCourses" runat="server" 
                                    DataSourceID="NotAffectedCourses" 
        DataTextField="cname" DataValueField="ccode" 
                                    Height="290px" SelectionMode="Multiple" 
                                    
        style="font-family: 'Microsoft Sans Serif'; font-size: small" Width="310px"></asp:ListBox>


                                


                                <asp:SqlDataSource ID="NotAffectedCourses" runat="server" 
                                    ConnectionString="<%$ ConnectionStrings:aptechConnectionString %>" 
                                    
        SelectCommand="SELECT [cname], [ccode] FROM [course_master]"></asp:SqlDataSource>


                                
                            </td></tr><tr><td align="center" class="style10">
                            <asp:Button ID="btnAddCourses" 
                            runat="server" Text="Add Selected" Height="26px" 
                                    Width="116px" onclick="btnAddCourses_Click" />


                            </td></tr><tr>
        <td style="text-align: center" class="style10">
                            <asp:Button ID="btnRemoveCourses" 
                                runat="server" Text="Remove Selected" 
                                    Height="26px" Width="116px" 
                onclick="btnRemoveCourses_Click"/>


                            </td></tr><tr><td class="style10">&#160;</td></tr>
<tr>
<td class="style11">
</td>
<td class="style10">
</td>
<td></td></tr></table>
                    
            
                    
            
            </ContentTemplate>
 

</cc1:TabPanel>
            <cc1:TabPanel ID="tabStudents" runat="server" HeaderText="Add / Remove Books">
                <ContentTemplate>
                    <br /><table style="width:100%;">
<tr>
<td style="text-align: center">Select the Books to 
<b>Remove</b></td><td>&#160;</td>
                            
<td style="text-align: center">Select the Books to 
<b>Add</b></td></tr>
<tr>
<td rowspan="4" valign="top">
                                <asp:ListBox ID="lstbxAffectedBooks" runat="server" 
        DataSourceID="AffectedBooks" DataTextField="title" DataValueField="bcode" 
        Height="290px" SelectionMode="Multiple" 
        style="font-family: 'Microsoft Sans Serif'; font-size: small" Width="310px"></asp:ListBox>




                                
                                <asp:SqlDataSource ID="AffectedBooks" 
        runat="server" 
        ConnectionString="<%$ ConnectionStrings:aptechConnectionString %>" 
        SelectCommand="SELECT book_master.bcode, book_master.title FROM book_master INNER JOIN book_module ON book_master.bcode = book_module.bcode"></asp:SqlDataSource>




                                
                            </td><td>&#160;</td>
<td rowspan="4" valign="top">

                                <asp:ListBox ID="lstbxNotAffectedBooks" 
        runat="server" DataSourceID="NotAffectedBooks" DataTextField="title" 
        DataValueField="bcode" Height="290px" SelectionMode="Multiple" 
        style="font-family: 'Microsoft Sans Serif'; font-size: small" Width="310px"></asp:ListBox>




                                


                                <asp:SqlDataSource ID="NotAffectedBooks" 
        runat="server" 
        ConnectionString="<%$ ConnectionStrings:aptechConnectionString %>" 
        SelectCommand="SELECT [bcode], [title] FROM [book_master]"></asp:SqlDataSource>




                                
                            </td></tr><tr><td align="center">
                            <asp:Button ID="btnAddBooks" runat="server" Height="26px" 
                                Text="Add Selected" Width="116px" onclick="btnAddBooks_Click"></asp:Button>




                            </td></tr><tr>
        <td style="text-align: center">
                            <asp:Button 
                            ID="btnRemoveBooks" runat="server" Height="27px" 
                                    Text="Remove Selected" Width="115px" onclick="btnRemoveBooks_Click" 
                 />




                            </td></tr><tr>
        <td>&#160;</td></tr>
<tr>
<td>
    &#160;</td>
<td>
    &#160;</td>
<td>&#160;</td></tr></table>
            
            
            
            
            
            
            
            
            
            
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
            width: 363px;
        }
    .style5
    {
            width: 147px;
            font-size: medium;
            text-align: right;
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
            width: 153px;
        }
        .style10
        {
            font-family: "Arial Black";
            font-size: small;
            height: 22px;
        }
        .style11
        {
            font-size: medium;
            font-family: Calibri;
            width: 153px;
            height: 35px;
        }
        .style12
        {
            width: 363px;
            height: 35px;
        }
        .style13
        {
            width: 147px;
            font-family: Calibri;
            font-size: medium;
            text-align: right;
            height: 35px;
        }
    .style14
    {
        font-size: medium;
        width: 153px;
        height: 35px;
    }
    </style>

</asp:Content>
