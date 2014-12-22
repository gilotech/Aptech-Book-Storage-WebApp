using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Web.Configuration;

public partial class Student : System.Web.UI.Page
{
    string name;
    string id;
    string contact;
    string invoiceNo;
    string password;
    DateTime invoiceDate;
    int rows = 0;
    SqlConnection con = new SqlConnection("Data Source=.;Initial Catalog=aptech;Integrated Security=True");
    public void Save()
    {       

        string req = "INSERT INTO student_master VALUES('" + id + "','" + name + "','" + contact + "','"+password+"','"+invoiceNo+"','"+invoiceDate+"')";

        SqlCommand cmd = new SqlCommand(req);
        con.Open();
        cmd.Connection = con;
        rows = cmd.ExecuteNonQuery();
        con.Close();
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["user"] == null)
            Response.Redirect("Default.aspx");
    }

    protected void btnCreate_Click(object sender, EventArgs e)
    {
        id = txtbxID.Text.Trim();
        name = txtbxName.Text.Trim();
        password = txtbxPassword.Text.Trim();
        contact = txtbxContact.Text.Trim();
        invoiceNo = txtbxInvoice.Text.Trim();
        invoiceDate = Convert.ToDateTime(txtbxInvoiceDate.Text.Trim());
        Save();
        int[] indexes = lstbxCourses.GetSelectedIndices();
        int no = indexes.GetUpperBound(0);
        if (rows > 0)
        {
            if (no >= 0)
            {
                if (con.State != ConnectionState.Open)
                    con.Open();
                for (int i = 0; i <= indexes.GetUpperBound(0); i++)
                {
                    string ccode = lstbxCourses.Items[indexes[i]].Value;
                    string req = "INSERT INTO student_course VALUES('" + id + "','" + ccode + "')";

                    SqlCommand cmd = new SqlCommand(req);
                    cmd.Connection = con;
                    cmd.ExecuteNonQuery();
                }
                con.Close();
            }
        }
        else
            Response.Write("<script type='text/javascript'>alert('Error while updating the database. Check your entries !');</script>");
        Response.Redirect("Student.aspx");

    }
    protected void btnReset_Click(object sender, EventArgs e)
    {
        txtbxConfirmPassword.Text = null;
        txtbxContact.Text = null;
        txtbxID.Text = null;
        txtbxInvoice.Text = null;
        txtbxInvoiceDate.Text = null;
        txtbxPassword.Text = null;
    }
    protected void grdStudentList_SelectedIndexChanged(object sender, EventArgs e)
    {
    }
    protected void grdStudentList_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName.Equals("editStudent"))
        {
            string code = grdStudentList.Rows[Convert.ToInt32(e.CommandArgument)].Cells[1].Text;
            Response.Redirect("StudentUpdater.aspx?code=" + code);
        }
    }
}
