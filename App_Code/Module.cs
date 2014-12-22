using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;

/// <summary>
/// Summary description for module
/// </summary>
public class Module
{
    string name;
    string code;
    string comment;
	public Module(string c, string n, string d)
	{
        code=c;
        name = n;
        comment = d;
    }

    public void Save() {
        SqlConnection con = new SqlConnection("Data Source=.;Initial Catalog=aptech;Integrated Security=True");
        
        string req = "INSERT INTO modules VALUES('"+code+"','"+name+"','"+comment+"')";

        SqlCommand cmd = new SqlCommand(req);

        cmd.ExecuteNonQuery();

        con.Close();
    }
}
