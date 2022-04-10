using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

public partial class Admin_UploadImage : System.Web.UI.Page
{
    Connection D = new Connection();
    SqlConnection cn = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["DigitalCardConnection"].ToString());
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Bindimage();
        }
    }
    protected void lbSubmit_Click(Object Sender, EventArgs e)
    {
        string img = "";
        string id = Request.Cookies["Userid"].Value;
        SqlCommand cmd = new SqlCommand();

        string filestr = System.IO.Path.Combine(Server.MapPath("~/Admin/img/"), File.FileName);
        File.SaveAs(filestr);
        img = "img/" + File.FileName;

        
        cmd.Connection = cn;
        cmd.CommandText = "update Profile set Image = '" + img + "' where Cid = " + id;
        cn.Open();
        cmd.ExecuteNonQuery();
        cn.Close();

        divSuccess.Visible = true;
        divError.Visible = false;

        Response.Redirect("UploadImage.aspx");
    }

    private void Bindimage()
    {
        string str = "";
        string id = Request.Cookies["Userid"].Value;

        //SqlConnection con = new SqlConnection(cn);
        DataTable dt = D.GetData("select * from Profile where Cid ='" + id + "'");
        foreach (DataRow row in dt.Rows)
        {

            str += " <img class='uploadcard' width='200' height='190' src='" + row["Image"] + "' style='padding-top: 0%;'>";
                //"<li><img src='" + row["Image"] + "' alt=''></li>";

           

        }

        Ltrimage.Text = str;
        
    }


}