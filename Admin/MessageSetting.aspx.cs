using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

public partial class Admin_MessageSetting : System.Web.UI.Page
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
        DataTable dt = D.GetDataTable("select * from MessageMaster where Cid ='" + id + "'");
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

            DataTable dt = D.GetDataTable("select * from MessageMaster where Cid ='" + id + "'");

            Txtwa.Text = dt.Rows[0]["Whatsapp"].ToString();
            Txtsms.Text = dt.Rows[0]["Sms"].ToString();

        }
        catch { }
    }
    protected void Bindhindi(Object Sender, EventArgs e)
    {
        try
        {
            string id = Request.Cookies["Userid"].Value;

            DataTable dt = D.GetDataTable("select * from MessageMaster where Cid ='" + id + "'");

            Txtwa.Text = dt.Rows[0]["Wa_hindi"].ToString();
            Txtsms.Text = dt.Rows[0]["sms_hindi"].ToString();

        }
        catch { }
    }
    protected void Bindguj(Object Sender, EventArgs e)
    {
        try
        {
            string id = Request.Cookies["Userid"].Value;

            DataTable dt = D.GetDataTable("select * from MessageMaster where Cid ='" + id + "'");

            Txtwa.Text = dt.Rows[0]["wa_guj"].ToString();
            Txtsms.Text = dt.Rows[0]["sms_guj"].ToString();

        }
        catch { }
    }
    protected void lbSubmit_Click(Object Sender, EventArgs e)
    {
        string id = Request.Cookies["Userid"].Value;
        SqlCommand cmd = new SqlCommand();

        cmd.Connection = cn;
        cmd.CommandText = "insert into MessageMaster (CID,Whatsapp,Sms) values(" + id + ",'" + Txtwa.Text + "','" + Txtsms.Text + "')";

        cn.Open();
        cmd.ExecuteNonQuery();
        cn.Close();

       
        //divSuccess.Visible = true;
        //divError.Visible = false;

        Response.Redirect("MessageSetting.aspx");
    }

    protected void lbUpdate_Click(Object Sender, EventArgs e)
    {
        try
        {
            string id = Request.Cookies["Userid"].Value;

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = cn;
            cmd.CommandText = "update MessageMaster set Whatsapp = '" + Txtwa.Text + "',Sms = '" + Txtsms.Text + "' where Cid = " + id;
            cn.Open();
            cmd.ExecuteNonQuery();
            cn.Close();

            //txtmobile.Text = "";
            BindData();
            //divSuccess.Visible = true;
            //divError.Visible = false;
        }
        catch
        {
            //divSuccess.Visible = false;
            //divError.Visible = true;
        }
    }

    protected void lbSubmit_Click1(object sender, EventArgs e)
    {
        string id = Request.Cookies["Userid"].Value;
        SqlCommand cmd = new SqlCommand();

        cmd.Connection = cn;
        cmd.CommandText = "insert into MessageMaster (CID,Whatsapp,Sms) values(" + id + ",'" + Txtwa.Text + "','" + Txtsms.Text + "')";

        cn.Open();
        cmd.ExecuteNonQuery();
        cn.Close();


        //divSuccess.Visible = true;
        //divError.Visible = false;

        Response.Redirect("MessageSetting.aspx");
    }
    protected void lbUpdate_Click1(object sender, EventArgs e)
    {
        try
        {
            string id = Request.Cookies["Userid"].Value;

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = cn;
            cmd.CommandText = "update MessageMaster set Whatsapp = '" + Txtwa.Text + "',Sms = '" + Txtsms.Text + "' where Cid = " + id;
            cn.Open();
            cmd.ExecuteNonQuery();
            cn.Close();

            //txtmobile.Text = "";
            BindData();
            //divSuccess.Visible = true;
            //divError.Visible = false;
        }
        catch
        {
            //divSuccess.Visible = false;
            //divError.Visible = true;
        }
    }
}