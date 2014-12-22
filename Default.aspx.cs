using System;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;

public partial class _Default : System.Web.UI.Page 
{
    string username = "admin";
    string password = "admin";
    protected void Page_Load(object sender, EventArgs e)
    {
        lblError.Visible = false;
    }
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        lblError.Visible = false;
        string u = txtbxUsername.Text.Trim();
        string p = txtbxPassword.Text.Trim();
        if (u.Equals(username) && p.Equals(password))
        {
            Session.Add("User", "Admin");
            Response.Redirect("Student.aspx");
        }
        else {
            lblError.Visible = true;
        }
    }
}
