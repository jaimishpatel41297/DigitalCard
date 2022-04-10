using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

public partial class Admin_Services : System.Web.UI.Page
{
    Connection D = new Connection();
    SqlConnection cn = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["DigitalCardConnection"].ToString());
    protected void Page_Load(object sender, EventArgs e)
    {
        string id = Request.Cookies["Userid"].Value;
        try
        {

            if (!IsPostBack)
            {
                BindData();
            }

            DataTable dt = D.GetDataTable("select * from Services where Cid ='" + id + "'");
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
        catch (Exception e33)
        {


        }

    }

    private void BindData()
    {
        try
        {
            string id = Request.Cookies["Userid"].Value;

            DataTable dt = D.GetDataTable("select * from Services where Cid ='" + id + "'");

            Txttitle.Text = dt.Rows[0]["Title"].ToString();
            Txtdes.Text = dt.Rows[0]["Description"].ToString();

        }
        catch { }
    }
  
    protected void lbSubmit_Click1(object sender, EventArgs e)
    {
        string id = Request.Cookies["Userid"].Value;
        SqlCommand cmd = new SqlCommand();

        cmd.Connection = cn;
        cmd.CommandText = "insert into Services (Cid,Title,Description) values('" + id + "','" + Txttitle.Text + "','" + Txtdes.Text + "')";
        cn.Open();
        cmd.ExecuteNonQuery();
        cn.Close();


        Response.Redirect("profile.aspx");
    }
    protected void lbUpdate_Click1(object sender, EventArgs e)
    {
        try
        {
            string id = Request.Cookies["Userid"].Value;

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = cn;
            cmd.CommandText = "update Services set Title = '" + Txttitle.Text + "',Description = '" + Txtdes.Text + "' where Cid = " + id;
            cn.Open();
            cmd.ExecuteNonQuery();
            cn.Close();

            //txtmobile.Text = "";
            BindData();

        }
        catch
        {

        }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        string id = Request.Cookies["Userid"].Value;
        SqlCommand cmd = new SqlCommand();

        cmd.Connection = cn;
        cmd.CommandText = "insert into Services (Cid,Title,Title) values('" + id + "','" + Txttitle.Text + "','" + Txtdes.Text + "')";
        cn.Open();
        cmd.ExecuteNonQuery();
        cn.Close();


        Response.Redirect("profile.aspx");
    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        try
        {
            string id = Request.Cookies["Userid"].Value;

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = cn;
            cmd.CommandText = "update Services set Title = '" + Txttitle.Text + "',Title = '" + Txtdes.Text + "' where Cid = " + id;
            cn.Open();
            cmd.ExecuteNonQuery();
            cn.Close();

            //txtmobile.Text = "";
            BindData();

        }
        catch
        {

        }
    }
}