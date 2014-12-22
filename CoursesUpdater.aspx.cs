using System;
using System.Collections;
using System.Collections.Specialized;
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

public partial class CoursesUpdater : System.Web.UI.Page
{
    string code;
    //string name;
    DateTime startDate;
    int duration;
    SqlConnection con = new SqlConnection("Data Source=.;Initial Catalog=aptech;Integrated Security=True");
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["user"] == null)
            Response.Redirect("Default.aspx");
        string req = null;
        SqlDataReader set=null;
        SqlCommand cmd = null;
        int n = Request.QueryString.Count;
        if (Request.Url.PathAndQuery.Contains("?code"))
        {
            code = Request.Params["code"];
            lstCoursesCode.SelectedValue = code;
            lstCoursesNames.SelectedValue = code;
        }
        else
        {
            req = "SELECT ccode FROM course_master";
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

        AffectedStudents.SelectCommand += " WHERE student_course.ccode='" + code + "' ORDER BY student_master.sname";
        AffectedModules.SelectCommand += " WHERE course_module.ccode='" + code + "' ORDER BY module_master.mname";
        NotAffectedStudents.SelectCommand += " WHERE student_master.scode NOT IN (SELECT scode FROM student_course WHERE ccode='" + code + "') ORDER BY student_master.sname";
        NotAffectedModules.SelectCommand += " WHERE module_master.mcode NOT IN (SELECT mcode FROM course_module WHERE ccode='" + code + "') ORDER BY module_master.mname";
        req = "SELECT * FROM course_master WHERE ccode='" + code + "'";
        cmd = new SqlCommand(req);
        if (con.State != ConnectionState.Open)
            con.Open();
        cmd.Connection = con;
        set = cmd.ExecuteReader();
        if (set.Read())
        {
            startDate = (DateTime)set.GetValue(2);
            duration = Convert.ToInt32(set.GetValue(3));
            txtbxDuration.Text = duration.ToString();
            txtbxStartingDate.Text = startDate.ToShortDateString();
        }
        con.Close();
    }
    protected void Refresh() {
        lstCoursesCode.SelectedValue = code;
        lstCoursesNames.SelectedValue = code;        
        string req = "SELECT * FROM course_master WHERE ccode='" + code + "'";
        SqlCommand cmd = new SqlCommand(req);
        if (con.State != ConnectionState.Open)
            con.Open();
        cmd.Connection = con;
        SqlDataReader set = cmd.ExecuteReader();
        if (set.Read())
        {
            startDate = (DateTime)set.GetValue(2);
            duration = Convert.ToInt32(set.GetValue(3));
            txtbxDuration.Text = duration.ToString();
            txtbxStartingDate.Text = startDate.ToShortDateString();
        }
        con.Close();
        AffectedStudents.SelectCommand = "SELECT DISTINCT student_master.scode, student_master.sname FROM student_course INNER JOIN student_master ON student_course.scode = student_master.scode WHERE student_course.ccode='" + code + "' ORDER BY student_master.sname";
        AffectedModules.SelectCommand = "SELECT DISTINCT module_master.mcode, module_master.mname FROM course_module INNER JOIN module_master ON course_module.mcode = module_master.mcode WHERE course_module.ccode='" + code + "' ORDER BY module_master.mname";
        NotAffectedStudents.SelectCommand = "SELECT DISTINCT sname, scode FROM student_master WHERE student_master.scode NOT IN (SELECT scode FROM student_course WHERE ccode='" + code + "') ORDER BY student_master.sname";
        NotAffectedModules.SelectCommand = "SELECT DISTINCT mcode, mname FROM module_master WHERE module_master.mcode NOT IN (SELECT mcode FROM course_module WHERE ccode='" + code + "') ORDER BY module_master.mname";
    }
    protected void btnAddStudents_Click(object sender, EventArgs e)
    {
        int[] indexes = lstbxNotAffectedStudents.GetSelectedIndices();
        int no = indexes.GetUpperBound(0);
        if (no >= 0)
        {
            code = lstCoursesCode.SelectedValue;
            if(con.State!=ConnectionState.Open)
                con.Open();
            for(int i=0; i<=indexes.GetUpperBound(0);i++){
                string scode=lstbxNotAffectedStudents.Items[indexes[i]].Value;
                string req = "INSERT INTO student_course VALUES(" + scode + ",'" + code + "')";

                SqlCommand cmd = new SqlCommand(req);
                cmd.Connection = con;
                cmd.ExecuteNonQuery();
                }
            con.Close();
            Response.Redirect("CoursesUpdater.aspx?code="+code);
        }
        else {
            Response.Write("<script type='text/javascript'>alert('You should select at least one student on the right-side-List');</script>");
        }
    }
    protected void btnRemoveStudents_Click(object sender, EventArgs e)
    {
        int[] indexes = lstbxAffectedStudents.GetSelectedIndices();
        int no = indexes.GetUpperBound(0);
        code = lstCoursesCode.SelectedValue;
        if (no >= 0)
        {
            if (con.State != ConnectionState.Open)
                con.Open();
            for (int i = 0; i <= indexes.GetUpperBound(0); i++)
            {
                string scode = lstbxAffectedStudents.Items[indexes[i]].Value;
                string req = "DELETE FROM student_course WHERE scode='"+scode+"' AND ccode='"+code+"'";
               
                SqlCommand cmd = new SqlCommand(req);
                cmd.Connection = con;
                cmd.ExecuteNonQuery();
            }
            con.Close();
            Response.Redirect("CoursesUpdater.aspx?code=" + code);
        }
        else
        {
            Response.Write("<script type='text/javascript'>alert('You should select at least one student on the left-side-List');</script>");
        }
    }
    protected void lstCoursesCode_SelectedIndexChanged(object sender, EventArgs e)
    {
        code = lstCoursesCode.SelectedValue;
        Refresh();
    }
    protected void lstCoursesNames_SelectedIndexChanged(object sender, EventArgs e)
    {
        code = lstCoursesNames.SelectedValue;
        Refresh();
    }
    protected void btnAddModules_Click(object sender, EventArgs e)
    {
        int[] indexes = lstNotAffectedModules.GetSelectedIndices();
        int no = indexes.GetUpperBound(0);
        if (no >= 0)
        {
            code = lstCoursesCode.SelectedValue;
            if (con.State != ConnectionState.Open)
                con.Open();
            for (int i = 0; i <= indexes.GetUpperBound(0); i++)
            {
                string mcode = lstNotAffectedModules.Items[indexes[i]].Value;
                string req = "INSERT INTO course_module VALUES('" + code + "','" + mcode + "')";

                SqlCommand cmd = new SqlCommand(req);
                cmd.Connection = con;
                cmd.ExecuteNonQuery();
            }
            con.Close();
            Response.Redirect("CoursesUpdater.aspx?code=" + code);
        }
        else
        {
            Response.Write("<script type='text/javascript'>alert('You should select at least one module on the right-side-List');</script>");
        }
    }
    protected void btnRemoveModules_Click(object sender, EventArgs e)
    {
        int[] indexes = lstAffectedModules.GetSelectedIndices();
        int no = indexes.GetUpperBound(0);
        code = lstCoursesCode.SelectedValue;
        if (no >= 0)
        {
            if (con.State != ConnectionState.Open)
                con.Open();
            for (int i = 0; i <= indexes.GetUpperBound(0); i++)
            {
                int mcode = Convert.ToInt32(lstAffectedModules.Items[indexes[i]].Value);
                string req = "DELETE FROM course_module WHERE mcode='" + mcode + "' AND ccode='" + code + "'";
              
                SqlCommand cmd = new SqlCommand(req);
                cmd.Connection = con;
                cmd.ExecuteNonQuery();
            }
            con.Close();
            Response.Redirect("CoursesUpdater.aspx?code=" + code);
        }
        else
        {
            Response.Write("<script type='text/javascript'>alert('You should select at least one module on the left-side-List');</script>");
        }
    }
}
