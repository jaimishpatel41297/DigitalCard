using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

public partial class Admin_Theme : System.Web.UI.Page
{
    Connection D = new Connection();
    SqlConnection cn = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["DigitalCardConnection"].ToString());
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
           
        }
        string id = Request.Cookies["Userid"].Value;
        DataTable dt = D.GetDataTable("select * from ThemeMaster where Cid ='" + id + "'");
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

    protected void lbSubmit_Click(Object Sender, EventArgs e)
    {
        string id = Request.Cookies["Userid"].Value;
        SqlCommand cmd = new SqlCommand();

        cmd.Connection = cn;
        cmd.CommandText = "insert into ThemeMaster (CID,Color,Version) values(" + id + ",'" + DropDownList1.SelectedValue.ToString() + "','"+ DropDownList2.SelectedValue.ToString() +"')";
        cn.Open();
        cmd.ExecuteNonQuery();
        cn.Close();

       
        divSuccess.Visible = true;
        divError.Visible = false;

        //Response.Redirect("Theme.aspx");
    }

    protected void lbUpdate_Click(Object Sender, EventArgs e)
    {
        try
        {
            string id = Request.Cookies["Userid"].Value;

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = cn;
            cmd.CommandText = "update ThemeMaster set Color = '" + DropDownList1.SelectedValue.ToString() + "',Version = '"+ DropDownList2.SelectedValue.ToString() +"' where Cid = " + id;
            cn.Open();
            cmd.ExecuteNonQuery();
            cn.Close();

           
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