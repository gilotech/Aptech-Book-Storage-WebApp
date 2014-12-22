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

public partial class Book : System.Web.UI.Page
{
    string title;
    string code;
    int ROL;
    int qty;
    int rows;
    int duplicateError=0;
    SqlConnection con = new SqlConnection("Data Source=.;Initial Catalog=aptech;Integrated Security=True");
    public void Save()
    {        
        con.Open();
        string req = "SELECT * FROM book_master WHERE bcode='"+code+"'";
        SqlCommand cmd = new SqlCommand(req);
        cmd.Connection = con;
        SqlDataReader set = cmd.ExecuteReader();
        if (!set.Read())
        {
            set.Close();
            con.Close();
            con.Open();
            req = "INSERT INTO book_master VALUES('" + code + "','" + title + "'," + qty + "," + ROL + ")";

            cmd = new SqlCommand(req);
            cmd.Connection = con;
            rows = cmd.ExecuteNonQuery();
        }
        else {
            Response.Write("<script type='text/javascript'>alert('This Book has already been registered.');</script>");
            duplicateError++;
        }
        con.Close();
    }

    protected void btnCreate_Click(object sender, EventArgs e)
    {
        code = txtbxCode.Text.Trim();
        title = txtbxTitle.Text.Trim();
        qty = Convert.ToInt32(txtbxQuantity.Text.Trim());
        ROL = 0;

        Save();
        int[] indexes = lstbxModules.GetSelectedIndices();
        int no = indexes.GetUpperBound(0);
        if(rows>0){
            if (no >= 0)
            {
                if (con.State != ConnectionState.Open)
                    con.Open();
                for (int i = 0; i <= indexes.GetUpperBound(0); i++)
                {
                    string mcode = lstbxModules.Items[indexes[i]].Value;
                    string req = "INSERT INTO book_module VALUES('" + code + "','" + mcode + "')";

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
            Response.Redirect("Book.aspx");
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["user"] == null)
            Response.Redirect("Default.aspx");
    }


    protected void GridView2_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        string code = GridView2.Rows[Convert.ToInt32(e.CommandArgument)].Cells[1].Text;

        //Response.Redirect("BooksUpdater.aspx?code="+code);

    }
    protected void GridView2_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void btnReset_Click(object sender, EventArgs e)
    {
        txtbxCode.Text = null;
        txtbxQuantity.Text = null;
        txtbxTitle.Text = null;
    }
}
