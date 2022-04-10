using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;


public partial class Admin_SocialLink : System.Web.UI.Page
{
    Connection D = new Connection();
    SqlConnection cn = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["DigitalCardConnection"].ToString());
    HttpCookie cookie;
    protected void Page_Load(object sender, EventArgs e)
    {
        
        string id = Request.Cookies["Userid"].Value;
        if (!IsPostBack)
        { 
                BindData();
           
            
        }
        DataTable dt = D.GetDataTable("select * from SocialLink where Cid ='" + id + "'");
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

            DataTable dt = D.GetDataTable("select * from SocialLink where Cid ='" + id + "'");

            Txtfb.Text = dt.Rows[0]["Facebook"].ToString();
            Txttw.Text = dt.Rows[0]["Twitter"].ToString();
            Txtgoogle.Text = dt.Rows[0]["Google"].ToString();
            Txtlink.Text = dt.Rows[0]["Linkedin"].ToString();
            Txtyou.Text = dt.Rows[0]["Youtube"].ToString();
            Txtinsta.Text = dt.Rows[0]["Instagram"].ToString();


        }
        catch { }
    }
    protected void lbSubmit_Click(Object Sender, EventArgs e)
    {
        string id = Request.Cookies["Userid"].Value;
        SqlCommand cmd = new SqlCommand();

        cmd.Connection = cn;
        cmd.CommandText = "insert into SocialLink (Cid,Facebook,Twitter,Google,Linkedin,Youtube,Instagram) values('" + id + "','" + Txtfb.Text + "','" + Txttw.Text + "','" + Txtgoogle.Text + "','" + Txtlink.Text + "','" + Txtyou.Text + "','" + Txtinsta.Text + "')";
        cn.Open();
        cmd.ExecuteNonQuery();
        cn.Close();

        divSuccess.Visible = true;
        divError.Visible = false;

        Response.Redirect("SocialLink.aspx");
    }

    protected void lbUpdate_Click(Object Sender, EventArgs e)
    {
        try
        {
            string id = Request.Cookies["Userid"].Value;

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = cn;
            cmd.CommandText = "update SocialLink set Facebook = '" + Txtfb.Text + "',Twitter = '" + Txttw.Text + "',Google = '" + Txtgoogle.Text + "',Linkedin = '" + Txtlink.Text + "',Youtube = '" + Txtyou.Text + "',Instagram = '" + Txtinsta.Text + "' where Cid = " + id;
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