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

public partial class StudentUpdater : System.Web.UI.Page
{
    string code;
    //string name;
    string invoiceNo;
    DateTime invoiceDate;
    string contact;
    string password;
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
            lstInvoiceNo.SelectedValue = code;
            lstStudentID.SelectedValue = code;
            lstStudentName.SelectedValue = code;
        }
        else
        {
            req = "SELECT scode FROM student_master";
            cmd = new SqlCommand(req);
            if (con.State != ConnectionState.Open)
                con.Open();
            cmd.Connection = con;
            set = cmd.ExecuteReader();
            if (set.Read())
            {
                code = set.GetValue(0).ToString();
            }
            con.Close();
        }

        AffectedBooks.SelectCommand += " WHERE issuance.scode='" + code + "' ORDER BY book_master.title";
        AffectedCourses.SelectCommand += " WHERE student_course.scode='" + code + "' ORDER BY course_master.cname";
        NotAffectedBooks.SelectCommand += " AND book_master.bcode NOT IN (SELECT bcode FROM issuance WHERE scode='" + code + "') ORDER BY book_master.title";
        NotAffectedCourses.SelectCommand += " WHERE course_master.ccode NOT IN (SELECT ccode FROM student_course WHERE scode='" + code + "') ORDER BY course_master.cname";
        req = "SELECT * FROM student_master WHERE scode='" + code + "'";
        cmd = new SqlCommand(req);
        if (con.State != ConnectionState.Open)
            con.Open();
        cmd.Connection = con;
        set = cmd.ExecuteReader();
        if (set.Read())
        {
            invoiceNo=(string)set.GetValue(4);
            invoiceDate=(DateTime)set.GetValue(5);
            password=(string)set.GetValue(3);
            contact = (string)set.GetValue(2);
            txtbxContact.Text = contact;
            txtbxInvoiceDate.Text = invoiceDate.ToShortDateString();
        }
        con.Close();
    }

    protected void Refresh()
    {
        lstStudentID.SelectedValue = code;
        lstStudentName.SelectedValue = code;
        lstInvoiceNo.SelectedValue = code;
        string req = "SELECT * FROM student_master WHERE scode='" + code + "'";
        SqlCommand cmd = new SqlCommand(req);
        if (con.State != ConnectionState.Open)
            con.Open();
        cmd.Connection = con;
        SqlDataReader set = cmd.ExecuteReader();
        if (set.Read())
        {
            invoiceNo = (string)set.GetValue(4);
            invoiceDate = (DateTime)set.GetValue(5);
            password = (string)set.GetValue(3);
            contact = (string)set.GetValue(2);
            txtbxContact.Text = contact;
            txtbxInvoiceDate.Text = invoiceDate.ToShortDateString();
        }
        con.Close();
        AffectedBooks.SelectCommand = "SELECT DISTINCT book_master.bcode, book_master.title FROM book_master INNER JOIN issuance ON book_master.bcode = issuance.bcode WHERE issuance.scode='" + code + "' ORDER BY book_master.title";
        AffectedCourses.SelectCommand = "SELECT DISTINCT course_master.ccode, course_master.cname FROM course_master INNER JOIN student_course ON course_master.ccode = student_course.ccode WHERE student_course.scode='" + code + "' ORDER BY course_master.cname";
        NotAffectedBooks.SelectCommand = "SELECT DISTINCT book_master.bcode, book_master.title FROM course_module INNER JOIN course_master ON course_module.ccode = course_master.ccode INNER JOIN module_master ON course_module.mcode = module_master.mcode INNER JOIN book_master INNER JOIN book_module ON book_master.bcode = book_module.bcode ON module_master.mcode = book_module.mcode INNER JOIN student_course ON course_master.ccode = student_course.ccode INNER JOIN student_master ON student_course.scode = student_master.scode WHERE (book_master.qty > 0) AND book_master.bcode NOT IN (SELECT bcode FROM issuance WHERE scode='" + code + "') ORDER BY book_master.title";
        NotAffectedCourses.SelectCommand = "SELECT ccode, cname FROM course_master WHERE course_master.ccode NOT IN (SELECT ccode FROM student_course WHERE scode='" + code + "') ORDER BY course_master.cname";
    }
    
    protected void btnAddBooks_Click(object sender, EventArgs e)
    {
        int[] indexes = lstbxNotAffectedBooks.GetSelectedIndices();
        SqlDataReader set = null;
        SqlCommand cmd = null;
        string req = null;
        int no = indexes.GetUpperBound(0);
        if (no >= 0)
        {
            code = lstStudentID.SelectedValue;
            password=txtbxPassword.Text;
            req = "SELECT scode FROM student_master WHERE scode='"+code+"' AND passwd='"+password+"'";
            cmd = new SqlCommand(req);
            if (con.State != ConnectionState.Open)
                con.Open();
            cmd.Connection = con;
            set = cmd.ExecuteReader();
            if (set.Read())
            {
                set.Close();
                for (int i = 0; i <= indexes.GetUpperBound(0); i++)
                {
                    string bcode = lstbxNotAffectedBooks.Items[indexes[i]].Value;
                    string issueDate = DateTime.Now.Month + "/" + DateTime.Now.Day + "/" + DateTime.Now.Year;
                    req = "INSERT INTO issuance VALUES('" + bcode + "','" + code + "','" + issueDate + "')";

                    cmd = new SqlCommand(req);
                    cmd.Connection = con;
                    cmd.ExecuteNonQuery();
                    //Updating the quantity of books in stock
                    req = "SELECT qty FROM book_master WHERE bcode='" + bcode + "'";
                    cmd = new SqlCommand(req);
                    cmd.Connection = con;
                    set = cmd.ExecuteReader();
                    set.Read();
                    int qty = Convert.ToInt32(set.GetValue(0));
                    int newQuantity = qty - 1;
                    set.Close();
                    req = "UPDATE book_master SET qty=" + newQuantity + " WHERE bcode='" + bcode + "'";
                    cmd = new SqlCommand(req);
                    cmd.Connection = con;
                    cmd.ExecuteNonQuery();
                }
                con.Close();
                Response.Redirect("StudentUpdater.aspx?code=" + code);
            }
            
            else
            {
                Response.Write("<script type='text/javascript'>alert('Entered password is incorrect. Please try again !');</script>");
            }
        }
        else
        {
            Response.Write("<script type='text/javascript'>alert('You should select at least one student on the right-side-List');</script>");
        }
    }

    protected void btnRemoveBooks_Click(object sender, EventArgs e)
    {
        int[] indexes = lstbxAffectedBooks.GetSelectedIndices();
        SqlDataReader set = null;
        SqlCommand cmd = null;
        string req = null;
        int no = indexes.GetUpperBound(0);
        if (no >= 0)
        {
            code = lstStudentID.SelectedValue;
            password = txtbxPassword.Text;
            req = "SELECT scode FROM student_master WHERE scode='" + code + "' AND passwd='" + password + "'";
            cmd = new SqlCommand(req);
            if (con.State != ConnectionState.Open)
                con.Open();
            cmd.Connection = con;
            set = cmd.ExecuteReader();
            if (set.Read())
            {
                set.Close();
                for (int i = 0; i <= indexes.GetUpperBound(0); i++)
                {
                    string bcode = lstbxAffectedBooks.Items[indexes[i]].Value;
                    req = "DELETE FROM issuance WHERE bcode='" + bcode + "' AND scode='" + code + "'";

                    cmd = new SqlCommand(req);
                    cmd.Connection = con;
                    cmd.ExecuteNonQuery();
                    //Updating the quantity of books in stock
                    req = "SELECT qty FROM book_master WHERE bcode='" + bcode + "'";
                    cmd = new SqlCommand(req);
                    cmd.Connection = con;
                    set = cmd.ExecuteReader();
                    set.Read();
                    int qty = Convert.ToInt32(set.GetValue(0));
                    int newQuantity = qty + 1;
                    set.Close();
                    req = "UPDATE book_master SET qty=" + newQuantity + " WHERE bcode='" + bcode + "'";
                    cmd = new SqlCommand(req);
                    cmd.Connection = con;
                    cmd.ExecuteNonQuery();
                }
                con.Close();
                Response.Redirect("StudentUpdater.aspx?code=" + code);
            }

            else
            {
                Response.Write("<script type='text/javascript'>alert('Entered password is incorrect. Please try again !');</script>");
            }
        }
        else
        {
            Response.Write("<script type='text/javascript'>alert('You should select at least one student on the left-side-List');</script>");
        }
    }

    protected void btnRemoveCourses_Click(object sender, EventArgs e)
    {
        int[] indexes = lstbxAffectedCourses.GetSelectedIndices();
        int no = indexes.GetUpperBound(0);
        code = lstStudentID.SelectedValue;
        if (no >= 0)
        {
            if (con.State != ConnectionState.Open)
                con.Open();
            for (int i = 0; i <= indexes.GetUpperBound(0); i++)
            {
                string ccode = lstbxAffectedCourses.Items[indexes[i]].Value;
                string req = "DELETE FROM student_course WHERE scode='" + code + "' AND ccode='" + ccode + "'";

                SqlCommand cmd = new SqlCommand(req);
                cmd.Connection = con;
                cmd.ExecuteNonQuery();
            }
            con.Close();
            Response.Redirect("StudentUpdater.aspx?code=" + code);
        }
        else
        {
            Response.Write("<script type='text/javascript'>alert('You should select at least one course on the left-side-List');</script>");
        }
    }

    protected void btnAddCourses_Click(object sender, EventArgs e)
    {
        int[] indexes = lstbxNotAffectedCourses.GetSelectedIndices();
        int no = indexes.GetUpperBound(0);
        if (no >= 0)
        {
            code = lstStudentID.SelectedValue;
            if (con.State != ConnectionState.Open)
                con.Open();
            for (int i = 0; i <= indexes.GetUpperBound(0); i++)
            {
                string ccode = lstbxNotAffectedCourses.Items[indexes[i]].Value;
                string req = "INSERT INTO student_course VALUES('" + code + "','" + ccode + "')";

                SqlCommand cmd = new SqlCommand(req);
                cmd.Connection = con;
                cmd.ExecuteNonQuery();
            }
            con.Close();
            Response.Redirect("StudentUpdater.aspx?code=" + code);
        }
        else
        {
            Response.Write("<script type='text/javascript'>alert('You should select at least one course on the right-side-List');</script>");
        }
    }
    protected void lstStudentID_SelectedIndexChanged(object sender, EventArgs e)
    {
        code = lstStudentID.SelectedValue;
        Refresh();
    }
    protected void lstStudentName_SelectedIndexChanged(object sender, EventArgs e)
    {
        code = lstStudentName.SelectedValue;
        Refresh();
    }
    protected void lstInvoiceNo_SelectedIndexChanged(object sender, EventArgs e)
    {
        code = lstInvoiceNo.SelectedValue;
        Refresh();
    }
}
