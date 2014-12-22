<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Student.aspx.cs" Inherits="Student" MasterPageFile="~/MasterPage.master"%>


<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>


<asp:Content ID="Content1" runat="server" 
    contentplaceholderid="ContentPlaceHolder1">
    
    <div id="body" 
    style="border-color: #3D3A40; margin: auto; width:768px; border-right-style: solid; border-left-style: solid;">
        <br />
        
        <div style="font-weight: 700; text-align: center; font-family: Georgia; font-size: xx-large; color: #49464B">Create new 
            Students</div>
        
        <br />
        <fieldset>
        <legend style="padding: 3px; font-family: Rockwell; color: #FFFFFF; background-color: #808080; font-size: medium;">
            Enter new Student informations</legend>
        <table style="width:100%;">
            <tr>
                <td class="style5">
                    ID
                    <asp:RegularExpressionValidator ID="revID" runat="server" 
                        ControlToValidate="txtbxID" ErrorMessage="*" ValidationExpression="\w{1,}"></asp:RegularExpressionValidator>
                </td>
                <td class="style2">
                    <asp:TextBox ID="txtbxID" runat="server" Width="149px"></asp:TextBox>
                </td>
                <td rowspan="7" valign="top" align="center">
                    <span class="style7">Select the course of the new student (Optional)</span><br />
                    <asp:ListBox ID="lstbxCourses" runat="server" DataSourceID="CoursesList" 
                        DataTextField="cname" DataValueField="ccode" Height="192px" 
                        SelectionMode="Multiple" style="font-family: 'Lucida Sans Unicode'; font-size: small" 
                        Width="352px"></asp:ListBox>
                    <asp:SqlDataSource ID="CoursesList" runat="server" 
                        ConnectionString="<%$ ConnectionStrings:aptechConnectionString %>" 
                        
                        SelectCommand="SELECT [ccode], [cname] FROM [course_master] ORDER BY [cname]">
                    </asp:SqlDataSource>
                </td>
            </tr>
            <tr>
                <td class="style6">
                    Name
                    <asp:RegularExpressionValidator ID="revName" runat="server" 
                        ControlToValidate="txtbxName" ErrorMessage="*" 
                        ValidationExpression="[\w ]{5,200}"></asp:RegularExpressionValidator>
                </td>
                <td class="style2">
                    <asp:TextBox ID="txtbxName" runat="server" Width="267px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="style6">
                    Contact
                    <asp:RegularExpressionValidator ID="revContact" runat="server" 
                        ControlToValidate="txtbxContact" ErrorMessage="*" 
                        ValidationExpression="[\d+()]{,15}"></asp:RegularExpressionValidator>
                </td>
                <td class="style2">
                    <asp:TextBox ID="txtbxContact" runat="server" Width="151px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="style6">
                    Invoice no
                    <asp:RegularExpressionValidator ID="revInvoiceNo" runat="server" 
                        ControlToValidate="txtbxInvoice" ErrorMessage="*" 
                        ValidationExpression="\w{1,10}"></asp:RegularExpressionValidator>
                </td>
                <td class="style2">
                    <asp:TextBox ID="txtbxInvoice" runat="server" Width="149px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="style7">
                    Invoice date </td>
                <td class="style2">
                    <asp:TextBox ID="txtbxInvoiceDate" runat="server" Width="151px"></asp:TextBox>
                    <cc1:CalendarExtender ID="CalendarExtender1" runat="server" 
                        TargetControlID="txtbxInvoiceDate" Format="dd-MM-yyyy">
                    </cc1:CalendarExtender>
                </td>
            </tr>
            <tr>
                <td class="style7">
                    Password
                    <asp:RegularExpressionValidator ID="revPassword" runat="server" 
                        ControlToValidate="txtbxPassword" ErrorMessage="*" 
                        ValidationExpression="\w{5,150}"></asp:RegularExpressionValidator>
                </td>
                <td class="style2">
                    <asp:TextBox ID="txtbxPassword" runat="server" Width="151px" 
                        TextMode="Password"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="style6">
                    Confirm
                    <asp:CompareValidator ID="cvConfirm" runat="server" 
                        ControlToCompare="txtbxPassword" ControlToValidate="txtbxConfirmPassword" 
                        ErrorMessage="*"></asp:CompareValidator>
                </td>
                <td class="style2">
                    <asp:TextBox ID="txtbxConfirmPassword" runat="server" Width="151px" 
                        TextMode="Password"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="style3">
                    <asp:Button ID="btnReset" runat="server" Text="Reset" 
                        onclick="btnReset_Click" />
                </td>
                <td class="style4">
                    </td>
                <td align="right" >
                    <asp:Button ID="btnCreate" runat="server" Text="Create" 
                        onclick="btnCreate_Click" />
                    </td>
            </tr>
            </table>
        </fieldset>
        <br />
        <asp:GridView ID="grdStudentList" runat="server" AllowPaging="True" 
            AutoGenerateColumns="False" AutoGenerateDeleteButton="True" 
            AutoGenerateEditButton="True" CellPadding="4" DataKeyNames="scode" 
            DataSourceID="StudentsList" ForeColor="#333333" GridLines="None" 
            OnRowCommand="grdStudentList_RowCommand"
            style="font-family: 'Microsoft Sans Serif'; text-align: center; font-size: small;" Width="100%" 
            AllowSorting="True" 
            onselectedindexchanged="grdStudentList_SelectedIndexChanged">
            <RowStyle BackColor="#E3EAEB" />
            <Columns>
                <asp:BoundField DataField="scode" HeaderText="ID" 
                    SortExpression="scode" ReadOnly="True" />
                <asp:BoundField DataField="invoiceno" HeaderText="Invoice No" 
                    SortExpression="invoiceno" />
                <asp:BoundField DataField="sname" HeaderText="Name" 
                    SortExpression="sname" />
                <asp:BoundField DataField="passwd" HeaderText="Password" 
                    SortExpression="passwd" DataFormatString="xxxxx" />
                <asp:BoundField DataField="invoicedate" HeaderText="Invoice Date" 
                    SortExpression="invoicedate" DataFormatString="{0:d}" />
                <asp:ButtonField ButtonType="Button" CommandName="editStudent" 
                    Text="Books - Courses" />
            </Columns>
            <FooterStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#666666" ForeColor="White" HorizontalAlign="Center" />
            <SelectedRowStyle BackColor="#C5BBAF" Font-Bold="True" ForeColor="#333333" />
            <HeaderStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
            <EditRowStyle BackColor="#7C6F57" />
            <AlternatingRowStyle BackColor="White" />
        </asp:GridView>
        <asp:SqlDataSource ID="StudentsList" runat="server" 
            ConnectionString="<%$ ConnectionStrings:aptechConnectionString %>" 
            
            SelectCommand="SELECT * FROM [student_master] ORDER BY [sname]" 
            DeleteCommand="DELETE FROM [student_master] WHERE [scode] = @scode" 
            InsertCommand="INSERT INTO [student_master] ([scode], [sname], [contact], [passwd], [invoiceno], [invoicedate]) VALUES (@scode, @sname, @contact, @passwd, @invoiceno, @invoicedate)" 
            UpdateCommand="UPDATE [student_master] SET [sname] = @sname, [contact] = @contact, [passwd] = @passwd, [invoiceno] = @invoiceno, [invoicedate] = @invoicedate WHERE [scode] = @scode">
            <DeleteParameters>
                <asp:Parameter Name="scode" Type="String" />
            </DeleteParameters>
            <UpdateParameters>
                <asp:Parameter Name="sname" Type="String" />
                <asp:Parameter Name="contact" Type="String" />
                <asp:Parameter Name="passwd" Type="String" />
                <asp:Parameter Name="invoiceno" Type="String" />
                <asp:Parameter DbType="Date" Name="invoicedate" />
                <asp:Parameter Name="scode" Type="String" />
            </UpdateParameters>
            <InsertParameters>
                <asp:Parameter Name="scode" Type="String" />
                <asp:Parameter Name="sname" Type="String" />
                <asp:Parameter Name="contact" Type="String" />
                <asp:Parameter Name="passwd" Type="String" />
                <asp:Parameter Name="invoiceno" Type="String" />
                <asp:Parameter DbType="Date" Name="invoicedate" />
            </InsertParameters>
        </asp:SqlDataSource>
    
    </div>
        
        

    </form>

    <style type="text/css">

        .style1
        {
            width: 129px;
        }
        .style2
        {
            width: 212px;
        }
        .style3
        {
            width: 141px;
            height: 30px;
        }
        .style4
        {
            width: 212px;
            height: 30px;
        }
        .style5
        {
            width: 141px;
            font-family: "Microsoft Sans Serif";
        font-size: small;
    }
        .style6
        {
            font-family: "Microsoft Sans Serif";
            font-size: small;
            width: 141px;
        }
        .style7
    {
        font-family: "Microsoft Sans Serif";
        font-size: small;
    }
        </style>    
        

</asp:Content>
