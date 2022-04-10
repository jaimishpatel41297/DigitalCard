using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

public partial class Admin_ContactDetail : System.Web.UI.Page
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
        DataTable dt = D.GetDataTable("select * from ContactDetail where Cid ='" + id + "'");
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

            DataTable dt = D.GetDataTable("select * from ContactDetail where Cid ='" + id + "'");

            Txtmob.Text = dt.Rows[0]["Mobile"].ToString();
            Txtemail.Text = dt.Rows[0]["Email"].ToString();
            Txtwhatsapp.Text = dt.Rows[0]["Whatsapp"].ToString();
            Txtfb.Text = dt.Rows[0]["Facebook"].ToString();


        }
        catch { }
    }
    protected void lbSubmit_Click(Object Sender, EventArgs e)
    {

        string id = Request.Cookies["Userid"].Value;

        //D.ExecuteQuery("update ContactDetails set Mobile='"+Txtmob.Text+"',Email='"+Txtemail.Text+"',Whatsapp='"+Txtwhatsapp.Text+"',Facebook='"+Txtfb.Text+"'")

        SqlCommand cmd = new SqlCommand();

        cmd.Connection = cn;
        cmd.CommandText = "insert into ContactDetail (Cid,Mobile,Email,Whatsapp,Facebook) values('"+ id +"','" + Txtmob.Text + "','" + Txtemail.Text + "','" + Txtwhatsapp.Text + "','" + Txtfb.Text + "')";
        cn.Open();
        cmd.ExecuteNonQuery();
        cn.Close();

        Txtmob.Text = "";
        Txtemail.Text = "";
        Txtfb.Text = "";
        Txtwhatsapp.Text = "";

        divSuccess.Visible = true;
        divError.Visible = false;

        Response.Redirect("ContactDetail.aspx");
    }

    protected void lbUpdate_Click(Object Sender, EventArgs e)
    {
        try
        {
            string id = Request.Cookies["Userid"].Value;

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = cn;
            cmd.CommandText = "update ContactDetail set Mobile = '" + Txtmob.Text + "',Email = '" + Txtemail.Text + "',Whatsapp = '" + Txtwhatsapp.Text + "',Facebook = '" + Txtfb.Text + "' where Cid = " + id;
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