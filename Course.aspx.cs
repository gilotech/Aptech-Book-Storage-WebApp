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

public partial class Course : System.Web.UI.Page
{
    string name;
    string code;
    DateTime date;
    int duration;
    int rows = 0;
    int duplicateError;
    SqlConnection con = new SqlConnection("Data Source=.;Initial Catalog=aptech;Integrated Security=True");
    public void Save() {
        
        con.Open();
        string req = "SELECT * FROM course_master WHERE ccode='"+code+"'";
        SqlCommand cmd = new SqlCommand(req);
        cmd.Connection = con;
        SqlDataReader set = cmd.ExecuteReader();
        if (!set.Read())
        {
            set.Close();
            con.Close();
            con.Open();
            //Response.Write("<script type='text/javascript'>alert('IN.');</script>");
            req = "INSERT INTO course_master VALUES('" + code + "','" + name + "','" + date + "'," + duration + ")";
            cmd = new SqlCommand(req);
            cmd.Connection = con;
            rows=cmd.ExecuteNonQuery();            
        }
        else{
            Response.Write("<script type='text/javascript'>alert('This Course has already been registered.');</script>");
            duplicateError++;
        }
        con.Close();
    }

    protected void btnCreate_Click(object sender, EventArgs e)
    {
        code = txtbxCode.Text.Trim();
        name = txtbxName.Text.Trim();
        duration = Convert.ToInt32(txtbxDuration.Text);
        date = Convert.ToDateTime(txtbxStartDate.Text.Trim());

        Save();

        int[] indexes = lstbxModules.GetSelectedIndices();
        int no = indexes.GetUpperBound(0);
        if (rows > 0)
        {
            if (no >= 0)
            {
                if (con.State != ConnectionState.Open)
                    con.Open();
                for (int i = 0; i <= indexes.GetUpperBound(0); i++)
                {
                    string mcode = lstbxModules.Items[indexes[i]].Value;
                    string req = "INSERT INTO course_module VALUES('" + code + "','" + mcode + "')";

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
            Response.Redirect("Course.aspx");
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["user"] == null)
            Response.Redirect("Default.aspx");
    }

    protected void gvwCourses_RowCommand(object sender, GridViewCommandEventArgs e) { 
        if(e.CommandName.Equals("editCourse")){
            string code = gvwCourses.Rows[Convert.ToInt32(e.CommandArgument)].Cells[1].Text;

            Response.Redirect("CoursesUpdater.aspx?code=" + code);
        }
    }

    protected void btnReset_Click(object sender, EventArgs e)
    {
        txtbxCode.Text = null;
        txtbxDuration.Text = null;
        txtbxName.Text = null;
        txtbxStartDate.Text=null;
    }
}
