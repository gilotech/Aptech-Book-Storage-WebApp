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

public partial class ModuleUpdater : System.Web.UI.Page
{
    string code;
    //string name;
    string description;
    SqlConnection con = new SqlConnection("Data Source=.;Initial Catalog=aptech;Integrated Security=True");
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["user"] == null)
            Response.Redirect("Default.aspx");
        string req = null;
        SqlDataReader set = null;
        SqlCommand cmd = null;
        int n = Request.QueryString.Count;
        if (Request.Url.PathAndQuery.Contains("?code"))
        {
            code = Request.Params["code"];
            lstModulesCode.SelectedValue = code;            
            lstModulesNames.SelectedValue = code;
        }
        else
        {
            req = "SELECT mcode FROM module_master";
            cmd = new SqlCommand(req);
            if (con.State != ConnectionState.Open)
                con.Open();
            cmd.Connection = con;
            set = cmd.ExecuteReader();
            if (set.Read())
            {
                code = (string)set.GetValue(0);
            }
            con.Close();
        }

        AffectedBooks.SelectCommand += " WHERE book_module.mcode='" + code + "' ORDER BY book_master.title";
        AffectedCourses.SelectCommand += " WHERE course_module.mcode='" + code + "' ORDER BY course_master.cname";
        NotAffectedBooks.SelectCommand += " WHERE book_master.bcode NOT IN (SELECT bcode FROM book_module WHERE mcode='" + code + "')";
        NotAffectedCourses.SelectCommand += " WHERE course_master.ccode NOT IN (SELECT ccode FROM course_module WHERE mcode='" + code + "') ORDER BY course_master.cname";
        req = "SELECT comment FROM module_master WHERE mcode='" + code + "'";
        cmd = new SqlCommand(req);
        if (con.State != ConnectionState.Open)
            con.Open();
        cmd.Connection = con;
        set = cmd.ExecuteReader();
        if (set.Read())
        {
            description = (string)set.GetValue(0);
            txtbxDescription.Text = description;
        }
        con.Close();
    }
    protected void Refresh()
    {
        lstModulesCode.SelectedValue = code;
        lstModulesNames.SelectedValue = code;
        string req = "SELECT * FROM course_master WHERE ccode='" + code + "'";
        SqlCommand cmd = new SqlCommand(req);
        if (con.State != ConnectionState.Open)
            con.Open();
        cmd.Connection = con;
        SqlDataReader set = cmd.ExecuteReader();
        if (set.Read())
        {
            description = (string)set.GetValue(0);
            txtbxDescription.Text = description;
        }
        con.Close();
        AffectedBooks.SelectCommand = "SELECT DISTINCT book_master.bcode, book_master.title FROM book_master INNER JOIN book_module ON book_master.bcode = book_module.bcode WHERE book_module.mcode='" + code + "' ORDER BY book_master.title";
        AffectedCourses.SelectCommand = "SELECT DISTINCT course_master.ccode, course_master.cname FROM course_master INNER JOIN course_module ON course_master.ccode = course_module.ccode WHERE course_module.mcode='" + code + "' ORDER BY course_master.cname";
        NotAffectedBooks.SelectCommand = "SELECT DISTINCT title, bcode FROM book_master WHERE book_master.bcode NOT IN (SELECT bcode FROM book_module WHERE mcode='" + code + "') ORDER BY book_master.title";
        NotAffectedCourses.SelectCommand = "SELECT DISTINCT ccode, cname FROM course_master  WHERE course_master.ccode NOT IN (SELECT ccode FROM course_module WHERE mcode='" + code + "') ORDER BY course_master.cname";
    }
    protected void btnAddCourses_Click(object sender, EventArgs e)
    {
        int[] indexes = lstNotAffectedCourses.GetSelectedIndices();
        int no = indexes.GetUpperBound(0);
        if (no >= 0)
        {
            code = lstModulesCode.SelectedValue;
            if (con.State != ConnectionState.Open)
                con.Open();
            for (int i = 0; i <= indexes.GetUpperBound(0); i++)
            {
                string ccode = lstNotAffectedCourses.Items[indexes[i]].Value;
                string req = "INSERT INTO course_module VALUES('" + ccode + "','" + code + "')";

                SqlCommand cmd = new SqlCommand(req);
                cmd.Connection = con;
                cmd.ExecuteNonQuery();
            }
            con.Close();
            Response.Redirect("ModuleUpdater.aspx?code=" + code);
        }
        else
        {
            Response.Write("<script type='text/javascript'>alert('You should select at least one course on the right-side-List');</script>");
        }
    }
    protected void btnRemoveCourses_Click(object sender, EventArgs e)
    {
        int[] indexes = lstAffectedCourses.GetSelectedIndices();
        int no = indexes.GetUpperBound(0);
        code = lstModulesCode.SelectedValue;
        if (no >= 0)
        {
            if (con.State != ConnectionState.Open)
                con.Open();
            for (int i = 0; i <= indexes.GetUpperBound(0); i++)
            {
                int ccode = Convert.ToInt32(lstAffectedCourses.Items[indexes[i]].Value);
                string req = "DELETE FROM course_module WHERE mcode='" + code + "' AND ccode='" + ccode + "'";

                SqlCommand cmd = new SqlCommand(req);
                cmd.Connection = con;
                cmd.ExecuteNonQuery();
            }
            con.Close();
            Response.Redirect("ModuleUpdater.aspx?code=" + code);
        }
        else
        {
            Response.Write("<script type='text/javascript'>alert('You should select at least one course on the left-side-List');</script>");
        }
    }
    protected void btnAddBooks_Click(object sender, EventArgs e)
    {
        int[] indexes = lstbxNotAffectedBooks.GetSelectedIndices();
        int no = indexes.GetUpperBound(0);
        if (no >= 0)
        {
            code = lstModulesCode.SelectedValue;
            if (con.State != ConnectionState.Open)
                con.Open();
            for (int i = 0; i <= indexes.GetUpperBound(0); i++)
            {
                string bcode = lstbxNotAffectedBooks.Items[indexes[i]].Value;
                string req = "INSERT INTO book_module VALUES('" + bcode + "','" + code + "')";

                SqlCommand cmd = new SqlCommand(req);
                cmd.Connection = con;
                cmd.ExecuteNonQuery();
            }
            con.Close();
            Response.Redirect("ModuleUpdater.aspx?code=" + code);
        }
        else
        {
            Response.Write("<script type='text/javascript'>alert('You should select at least one student on the right-side-List');</script>");
        }
    }
    protected void btnRemoveBooks_Click(object sender, EventArgs e)
    {
        int[] indexes = lstbxAffectedBooks.GetSelectedIndices();
        int no = indexes.GetUpperBound(0);
        code = lstModulesCode.SelectedValue;
        if (no >= 0)
        {
            if (con.State != ConnectionState.Open)
                con.Open();
            for (int i = 0; i <= indexes.GetUpperBound(0); i++)
            {
                int bcode = Convert.ToInt32(lstbxAffectedBooks.Items[indexes[i]].Value);
                string req = "DELETE FROM book_module WHERE bcode='" + bcode + "' AND mcode='" + code + "'";

                SqlCommand cmd = new SqlCommand(req);
                cmd.Connection = con;
                cmd.ExecuteNonQuery();
            }
            con.Close();
            Response.Redirect("ModuleUpdater.aspx?code=" + code);
        }
        else
        {
            Response.Write("<script type='text/javascript'>alert('You should select at least one book on the left-side-List');</script>");
        }
    }
    protected void lstModulesCode_SelectedIndexChanged(object sender, EventArgs e)
    {
        code = lstModulesCode.SelectedValue;
        Refresh();
    }
    protected void lstModulesNames_SelectedIndexChanged(object sender, EventArgs e)
    {
        code = lstModulesNames.SelectedValue;
        Refresh();
    }
}
