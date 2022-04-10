using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

public partial class Admin_Register : System.Web.UI.Page
{
    SqlConnection conn = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["DigitalCardConnection"].ConnectionString);
    GetData cls = new GetData();
    Connection con = new Connection();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {

            ClearAll();

        }
    }

    private void ClearAll()
    {

    }
    protected void lblSubmit_Click(Object sender, EventArgs e)
    {

        try
        {

            con.ExecuteQuery("insert into Registration(Name,Email,Mobile,Password) values('" + Txtname.Text + "','" + txtemail.Text + "','" + txtmobile.Text + "','" + txtpass.Text + "')");

            DataTable dt = cls.GetDataTable("select top 1 * from Registration order by id desc");

            
            if (dt.Rows.Count > 0)
            {
                string id = dt.Rows[0]["id"].ToString();
                string name = dt.Rows[0]["Name"].ToString();
                con.ExecuteQuery("insert into profile (Cid,Name) values('" + id + "','" + name + "')");

                con.ExecuteQuery("insert into ContactDetail (Cid,Email,Mobile) values('" + id + "','" + txtemail.Text + "','" + txtmobile.Text + "')");

            }



            //divError.Visible = false;
            //divSuccess.Visible = true;
            //BindData();
            ClearAll();
            Response.Redirect("Login.aspx");


        }
        catch (Exception ex)
        {
            //divError.Visible = true;
            //divSuccess.Visible = false;
        }

    }
}