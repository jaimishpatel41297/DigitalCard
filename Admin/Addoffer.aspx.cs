using System;
using System.IO;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;


public partial class Admin_Addoffer : System.Web.UI.Page
{
    Connection D = new Connection();
    SqlConnection cn = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["DigitalCardConnection"].ToString());
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BindData();
        }
        string id = Request.Cookies["Userid"].Value;
        DataTable dt = D.GetDataTable("select * from Offer where Cid ='" + id + "'");
        if (dt.Rows.Count > 0)
        {

            lbSubmit.Visible = false;
            lbUpdate.Visible = true;

        }
        else
        {
            lbSubmit.Visible = true;
            lbUpdate.Visible = false;
        }
    }

    private void BindData()
    {
        try
        {
            string id = Request.Cookies["Userid"].Value;

            DataTable dt = D.GetDataTable("select * from Offer where Cid ='" + id + "'");

            Txtname.Text = dt.Rows[0]["Title"].ToString();
            Txtcompany.Text = dt.Rows[0]["Descri"].ToString();
            
     


        }

        catch (Exception e22)
        { }
    }
    protected void lbSubmit_Click(object sender, EventArgs e)
    {
        string id = Request.Cookies["Userid"].Value;
        SqlCommand cmd = new SqlCommand();

        cmd.Connection = cn;
        cmd.CommandText = "insert into Offer (CID,Title,Descri) values(" + id + ",'" + Txtname.Text + "','" + Txtcompany.Text + "')";

        cn.Open();
        cmd.ExecuteNonQuery();
        cn.Close();

        Txtname.Text = "";
        Txtcompany.Text = "";

        divSuccess.Visible = true;
        divError.Visible = false;

        Response.Redirect("Addoffer.aspx");
    }
    protected void lbUpdate_Click(object sender, EventArgs e)
    {
        try
        {
            string id = Request.Cookies["Userid"].Value;

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = cn;
            cmd.CommandText = "update Offer set Title = '" + Txtname.Text + "',Descri = '" + Txtcompany.Text + "' where Cid = " + id;
            cn.Open();
            cmd.ExecuteNonQuery();
            cn.Close();

            //txtmobile.Text = "";
            BindData();
            divSuccess.Visible = true;
            divError.Visible = false;
        }
        catch
        {
            divSuccess.Visible = false;
            divError.Visible = true;
        }
    }
    protected void lbSubmit_Click1(object sender, EventArgs e)
    {

        string id = Request.Cookies["Userid"].Value;
        SqlCommand cmd = new SqlCommand();

        cmd.Connection = cn;
        cmd.CommandText = "insert into Offer (CID,Title,Descri) values(" + id + ",'" + Txtname.Text + "','" + Txtcompany.Text + "')";

        cn.Open();
        cmd.ExecuteNonQuery();
        cn.Close();

        Txtname.Text = "";
        Txtcompany.Text = "";

        divSuccess.Visible = true;
        divError.Visible = false;

        Response.Redirect("Addoffer.aspx");
    }
    protected void lbUpdate_Click1(object sender, EventArgs e)
    {
        try
        {
            string id = Request.Cookies["Userid"].Value;

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = cn;
            cmd.CommandText = "update Offer set Title = '" + Txtname.Text + "',Descri = '" + Txtcompany.Text + "' where Cid = " + id;
            cn.Open();
            cmd.ExecuteNonQuery();
            cn.Close();

            //txtmobile.Text = "";
            BindData();
            divSuccess.Visible = true;
            divError.Visible = false;
        }
        catch
        {
            divSuccess.Visible = false;
            divError.Visible = true;
        }
    }
}