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

public partial class Module : System.Web.UI.Page
{
    string name;
    string code;
    string comment;
    int rows=0;
    int duplicateError;
    SqlConnection con = new SqlConnection("Data Source=.;Initial Catalog=aptech;Integrated Security=True");
    public void Save()
    {
        con.Open();
        string req = "SELECT * FROM module_master WHERE mcode='"+code+"'";
        SqlCommand cmd = new SqlCommand(req);
        cmd.Connection = con;
        SqlDataReader set = cmd.ExecuteReader();
        if (!set.Read())
        {
            set.Close();
            con.Close();
            con.Open();
            req = "INSERT INTO module_master VALUES('" + code + "','" + name + "','" + comment + "')";
            cmd = new SqlCommand(req);
            cmd.Connection = con;
            rows = cmd.ExecuteNonQuery();
        }
        else
        {
            Response.Write("<script type='text/javascript'>alert('This Module has already been registered.');</script>");
            duplicateError++;
        }
        con.Close();
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["user"] == null)
            Response.Redirect("Default.aspx");
    }

    protected void btnCreate_Click(object sender, EventArgs e)
    {
        code = txtbxCode.Text.Trim();
        name = txtbxName.Text.Trim();
        comment = txtbxComment.Text.Trim();

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
                    string req = "INSERT INTO course_module VALUES('" + ccode + "','" + code + "')";

                    SqlCommand cmd = new SqlCommand(req);
                    cmd.Connection = con;
                    cmd.ExecuteNonQuery();
                }
                con.Close();
            }
        }
        else if(duplicateError==0)
            Response.Write("<script type='text/javascript'>alert('Error while updating the database. Check your entries !');</script>");
        if(rows>0)
        Response.Redirect("Module.aspx");

    }
    protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName.Equals("editModule"))
        {
            string code = GridView1.Rows[Convert.ToInt32(e.CommandArgument)].Cells[1].Text;
            Response.Redirect("ModuleUpdater.aspx?code=" + code);
        }
    }
}
