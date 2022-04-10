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


public partial class Admin_AboutMe : System.Web.UI.Page
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
        DataTable dt = D.GetDataTable("select * from Profile where Cid ='" + id + "'");
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

            DataTable dt = D.GetDataTable("select * from Profile where Cid ='" + id + "'");

            Txtname.Text = dt.Rows[0]["Name"].ToString();
            Txtcompany.Text = dt.Rows[0]["Company"].ToString();
            Txtabout.Text = dt.Rows[0]["About"].ToString();
            Txtrole.Text = dt.Rows[0]["Role"].ToString();
            Txtweb.Text = dt.Rows[0]["website"].ToString();



        }

        catch (Exception e22)
        { }
    }

    protected void lbSubmit_Click(Object Sender, EventArgs e)
    {
        string id = Request.Cookies["Userid"].Value;
        SqlCommand cmd = new SqlCommand();

        cmd.Connection = cn;
        cmd.CommandText = "insert into Profile (CID,Name,Company,Role,website,About) values(" + id + ",'" + Txtname.Text + "','" + Txtcompany.Text + "','" + Txtrole.Text + "','" + Txtweb.Text + "','" + Txtabout.Text + "')";

        cn.Open();
        cmd.ExecuteNonQuery();
        cn.Close();

        Txtname.Text = "";
        Txtcompany.Text = "";
        Txtabout.Text = "";
        Txtrole.Text = "";
        Txtweb.Text = "";

        divSuccess.Visible = true;
        divError.Visible = false;

        Response.Redirect("AboutMe.aspx");
    }

    protected void lbUpdate_Click(Object Sender, EventArgs e)
    {
        try
        {
            string id = Request.Cookies["Userid"].Value;

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = cn;
            cmd.CommandText = "update Profile set Name = '" + Txtname.Text + "',Company = '" + Txtcompany.Text + "',Role = '" + Txtrole.Text + "',website = '" + Txtweb.Text + "',About = '" + Txtabout.Text + "' where Cid = " + id;
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

    protected void lbVcf_Click(Object Sender, EventArgs e)
    {

        string id = Request.Cookies["Userid"].Value;
        SqlCommand cmd = new SqlCommand();

        DataTable dt = D.GetData("select * from Profile where Cid ='" + id + "'");



        //response.ContentType = "text/x-vCard";
        //create a string writer

        System.IO.StringWriter stringWrite = new System.IO.StringWriter();
        //create an htmltextwriter which uses the stringwriter

        System.Web.UI.HtmlTextWriter htmlWrite = new HtmlTextWriter(stringWrite);
        //vCard Begin
        stringWrite.WriteLine("BEGIN:VCARD");
        stringWrite.WriteLine("VERSION:2.1");
        //Name
        stringWrite.WriteLine("N:" + dt.Rows[0]["Name"].ToString());
        //Full Name



        //vCard End
        stringWrite.WriteLine("END:VCARD");
        //response.Write(stringWrite.ToString());
        //response.End();



    }
    protected void lbVcf2_Click(Object Sender, EventArgs e)
    {

        string id = Request.Cookies["Userid"].Value;
        SqlCommand cmd = new SqlCommand();

        DataTable dt = D.GetData("select * from Profile where Cid ='" + id + "'");

        string path = @"G:\New Project\DigitalCard New\new.vcf";
        //G:\New Project\DigitalCard New

        using (FileStream fs = File.Create(path))
        {
            Byte[] info = new UTF8Encoding(true).GetBytes("This is some text in the file.");
            // Add some information to the file.
            fs.Write(info, 0, info.Length);
        }

    }


}