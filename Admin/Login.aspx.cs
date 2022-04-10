using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

public partial class Admin_Login : System.Web.UI.Page
{
    Connection D = new Connection();
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btnLogin_Click(object sender, EventArgs e)
    {

        DataTable dt = D.GetDataTable("select * from Registration where Email='" + Txtemail.Text.ToString() + "' and PASSWORD='" + Txtpass.Text.ToString() + "'");
        if (dt.Rows.Count > 0)
        {
            //Response.Cookies["AdminId"].Value = txtUserName.Text.ToString();
            //Session["AdminId"] = "1";
            //Response.Cookies["Username"].Value = dt.Rows[0]["name"].ToString();
            Response.Cookies["Userid"].Value = dt.Rows[0]["id"].ToString();
            Response.Redirect("Profile.aspx");
        }
        else
        {
            Txtpass.Text = "";
            Page.ClientScript.RegisterStartupScript(this.GetType(), "Suceess", "alert('Wrong Email or Password');", true);
        }
    }
}



