using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

public partial class Admin_Contact : System.Web.UI.Page
{
    Connection D = new Connection();
    SqlConnection cn = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["DigitalCardConnection"].ToString());
    protected void Page_Load(object sender, EventArgs e)
    {
        string id = Request.Cookies["Userid"].Value;
        if (!IsPostBack)
        {
            BindData();
        }
        DataTable dt = D.GetDataTable("select * from CompanyDetail where Cid ='" + id + "'");
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

    protected void BindData()
    {
        try
        {
            string id = Request.Cookies["Userid"].Value;

            DataTable dt = D.GetDataTable("select * from CompanyDetail where Cid ='" + id + "'");

            Txtname.Text = dt.Rows[0]["Name"].ToString();
            Txtadd.Text = dt.Rows[0]["Address"].ToString();
            Txtphone.Text = dt.Rows[0]["Phone"].ToString();
            Txturl.Text = dt.Rows[0]["URL"].ToString();
            Txtemail.Text = dt.Rows[0]["Email"].ToString();
            Txtmap.Text = dt.Rows[0]["Map"].ToString();


        }
        catch { }
    }
    protected void lbSubmit_Click(Object Sender, EventArgs e)
    {
        string id = Request.Cookies["Userid"].Value;
        SqlCommand cmd = new SqlCommand();

        cmd.Connection = cn;
        cmd.CommandText = "insert into CompanyDetail (Cid,Name,Address,Phone,URL,Email,Map) values('"+ id +"','" + Txtname.Text + "','" + Txtadd.Text + "','" + Txtphone.Text + "','" + Txturl.Text + "','" + Txtemail.Text + "','" + Txtmap.Text + "')";
        cn.Open();
        cmd.ExecuteNonQuery();
        cn.Close();

        Txtname.Text = "";
        Txtemail.Text = "";
        Txtadd.Text = "";
        Txtmap.Text = "";
        Txtphone.Text = "";
        Txturl.Text = "";

        divSuccess.Visible = true;
        divError.Visible = false;

        Response.Redirect("Company.aspx");
    }

    protected void lbUpdate_Click(Object Sender, EventArgs e)
    {
        try
        {
            string id = Request.Cookies["Userid"].Value;

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = cn;
            cmd.CommandText = "update CompanyDetail set Name = '" + Txtname.Text + "',Address = '" + Txtadd.Text + "',Phone = '" + Txtphone.Text + "',URL = '" + Txturl.Text + "',Email = '" + Txtemail.Text + "',Map = '" + Txtmap.Text + "' where Cid = " + id;
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