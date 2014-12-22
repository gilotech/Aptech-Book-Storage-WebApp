<%@ Page Language="C#" AutoEventWireup="true" CodeFile="StudentUpdater.aspx.cs" Inherits="StudentUpdater" MasterPageFile="~/MasterPage.master" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>
<asp:Content ID="Content1" runat="server" 
    contentplaceholderid="ContentPlaceHolder1">
    <div id="body" 
        style="border-color: #3D3A40; margin: auto; width: 768px; border-right-style: solid; border-left-style: solid;">
 
    <div class="style7">
        Update Students</div>
    <table style="width:100%;">
        <tr>
            <td class="style2">
                Invoice no</td>
            <td class="style8">
                <asp:DropDownList ID="lstInvoiceNo" runat="server" DataSourceID="StudentsList" 
                    DataTextField="invoiceno" DataValueField="scode" 
                    style="font-family: 'Microsoft Sans Serif'" 
                    onselectedindexchanged="lstInvoiceNo_SelectedIndexChanged" 
                    AutoPostBack="True">
                </asp:DropDownList>
                            </td>
            <td class="style9">
                Invoice date</td>
            <td>
                <asp:TextBox ID="txtbxInvoiceDate" runat="server" 
                    
                    style="font-family: 'Microsoft Sans Serif'; font-weight: 700; text-align: center" 
                    Enabled="False"></asp:TextBox>
                            </td>
        </tr>
        <tr>
            <td class="style2">
                Student ID</td>
            <td class="style8">
                <asp:DropDownList ID="lstStudentID" runat="server" 
                    style="font-family: 'Microsoft Sans Serif'" DataSourceID="StudentsList" 
                    DataTextField="scode" DataValueField="scode" AutoPostBack="True" 
                    onselectedindexchanged="lstStudentID_SelectedIndexChanged">
                </asp:DropDownList>
            </td>
            <td class="style9">
                Contact</td>
            <td>
                <asp:TextBox ID="txtbxContact" runat="server" 
                    style="font-weight: 700; text-align: center; font-family: 'Microsoft Sans Serif'" 
                    Width="169px" Enabled="False"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="style2">
                Student Name</td>
            <td class="style8">
                <asp:DropDownList ID="lstStudentName" runat="server" 
                    style="font-family: 'Microsoft Sans Serif'" DataSourceID="StudentsList" 
                    DataTextField="sname" DataValueField="scode" AutoPostBack="True" 
                    onselectedindexchanged="lstStudentName_SelectedIndexChanged">
                </asp:DropDownList>
            </td>
            <td class="style9">
                Signature</td>
            <td>
                <asp:TextBox ID="txtbxPassword" runat="server" TextMode="Password" 
                    Width="169px" ToolTip="Enter student's password"></asp:TextBox>
            </td>
        </tr>
        </table>
    <asp:SqlDataSource ID="StudentsList" runat="server" 
        ConnectionString="<%$ ConnectionStrings:aptechConnectionString %>" 
        
            SelectCommand="SELECT [scode], [sname], [invoiceno] FROM [student_master] ORDER BY [sname]">
    </asp:SqlDataSource>
    <cc1:TabContainer ID="TabContainer1" runat="server" ActiveTabIndex="0" 
        Width="100%">
        <cc1:TabPanel runat="server" HeaderText="Issue / Cancel Books" ID="tabBooks"><ContentTemplate>
<br />
<table style="width:100%;">
    <tr>
<td align="center">Select the Books to 
<b>Cancel</b></td>
        <td>
            &#160;</td>
<td align="center">Select the Books to
    <b>Deliver</b></td>
    </tr>
    <tr>
        <td rowspan="4" valign="top">
            <asp:ListBox ID="lstbxAffectedBooks" runat="server" Height="290px" 
                style="font-family: 'Microsoft Sans Serif'; font-size: small" 
                Width="310px" DataSourceID="AffectedBooks" DataTextField="title" 
                DataValueField="bcode" SelectionMode="Multiple"></asp:ListBox>

            <asp:SqlDataSource ID="AffectedBooks" runat="server" 
                ConnectionString="<%$ ConnectionStrings:aptechConnectionString %>" 
                SelectCommand="SELECT DISTINCT book_master.bcode, book_master.title FROM book_master INNER JOIN issuance ON book_master.bcode = issuance.bcode">
            </asp:SqlDataSource>

        </td>
        <td>
            &#160;</td>
        <td align="center" rowspan="4" style="text-align: left" valign="top">
            <asp:ListBox ID="lstbxNotAffectedBooks" runat="server" Height="290px" 
                style="font-family: 'Microsoft Sans Serif'; font-size: small" 
                Width="310px" DataSourceID="NotAffectedBooks" DataTextField="title" 
                DataValueField="bcode" SelectionMode="Multiple"></asp:ListBox>

            <asp:SqlDataSource ID="NotAffectedBooks" runat="server" 
                ConnectionString="<%$ ConnectionStrings:aptechConnectionString %>" 
                SelectCommand="SELECT DISTINCT book_master.bcode, book_master.title FROM course_module INNER JOIN course_master ON course_module.ccode = course_master.ccode INNER JOIN module_master ON course_module.mcode = module_master.mcode INNER JOIN book_master INNER JOIN book_module ON book_master.bcode = book_module.bcode ON module_master.mcode = book_module.mcode INNER JOIN student_course ON course_master.ccode = student_course.ccode INNER JOIN student_master ON student_course.scode = student_master.scode WHERE (book_master.qty > 0)">
            </asp:SqlDataSource>

        </td>
    </tr>
    <tr>
        <td align="center">
            <asp:Button ID="btnAddBooks" runat="server" Height="26px" 
                style="text-align: center" Text="Issue Selected" Width="111px" 
                onclick="btnAddBooks_Click" />

        </td>
    </tr>
    <tr>
        <td align="center">
            <asp:Button ID="btnRemoveBooks" runat="server" Height="26px" Text="Cancel Selected" 
                Width="114px" onclick="btnRemoveBooks_Click" />

        </td>
    </tr>
    <tr>
        <td>
            &#160;</td>
    </tr>
    <tr>
        <td>
            &#160;</td>
        <td>
            &#160;</td>
        <td>
            &#160;</td>
    </tr>
</table>
        
        
        
        
        
        
        </ContentTemplate>
        


</cc1:TabPanel>
        <cc1:TabPanel ID="tabCourses" runat="server" HeaderText="Add / Remove from Courses"><ContentTemplate>
<br />
<table style="width:100%;">
    <tr>
<td align="center">Select the Courses to 
<b>Remove</b></td>
        <td>
            &#160;</td>
<td align="center">Select the Courses to
    <b>Add</b></td>
    </tr>
    <tr>
        <td rowspan="4" valign="top">
            <asp:ListBox ID="lstbxAffectedCourses" runat="server" Height="290px" 
                style="font-family: 'Microsoft Sans Serif'; font-size: small" 
                Width="310px" DataSourceID="AffectedCourses" DataTextField="cname" 
                DataValueField="ccode" SelectionMode="Multiple"></asp:ListBox>

            <asp:SqlDataSource ID="AffectedCourses" runat="server" 
                ConnectionString="<%$ ConnectionStrings:aptechConnectionString %>" 
                SelectCommand="SELECT DISTINCT course_master.ccode, course_master.cname FROM course_master INNER JOIN student_course ON course_master.ccode = student_course.ccode">
            </asp:SqlDataSource>

        </td>
        <td>
            &#160;</td>
        <td align="center" rowspan="4" style="text-align: left" valign="top">
            <asp:ListBox ID="lstbxNotAffectedCourses" runat="server" Height="290px" 
                style="font-family: 'Microsoft Sans Serif'; font-size: small" 
                Width="310px" DataSourceID="NotAffectedCourses" DataTextField="cname" 
                DataValueField="ccode" SelectionMode="Multiple"></asp:ListBox>

            <asp:SqlDataSource ID="NotAffectedCourses" runat="server" 
                ConnectionString="<%$ ConnectionStrings:aptechConnectionString %>" 
                SelectCommand="SELECT [ccode], [cname] FROM [course_master]">
            </asp:SqlDataSource>

        </td>
    </tr>
    <tr>
        <td align="center">
            <asp:Button ID="btnAddCourses" runat="server" style="text-align: center" 
               Text="Add Selected" OnClick="btnAddCourses_Click" />

        </td>
    </tr>
    <tr>
        <td align="center">
            <asp:Button ID="btnRemoveCourses" runat="server" Height="26px" Text="Remove Selected" 
               OnClick="btnRemoveCourses_Click" Width="114px" />

        </td>
    </tr>
    <tr>
        <td>
            &#160;</td>
    </tr>
    <tr>
        <td>
            &#160;</td>
        <td>
            &#160;</td>
        <td>
            &#160;</td>
    </tr>
</table>
        
        
        
        
        
        
        </ContentTemplate>
        


</cc1:TabPanel>
    </cc1:TabContainer>
 
 </div>
</asp:Content>
<asp:Content ID="Content2" runat="server" contentplaceholderid="head">

    <style type="text/css">
        .style2
        {
            width: 111px;
        }
        .style3
        {
            text-align: left;
        }
        .style4
        {
            width: 376px;
        }
    .style7
    {
        font-size: xx-large;
        font-weight: bold;
        font-family: Georgia;
        color: #808080;
            text-align: center;
        }
    .style8
    {
        width: 369px;
        height: 38px;
    }
    .style9
    {
        text-align: left;
        width: 98px;
    }
    </style>

</asp:Content>

