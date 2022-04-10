using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

public partial class Admin_AdminMaster : System.Web.UI.MasterPage
{
    Connection D = new Connection();
    SqlConnection cn = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["DigitalCardConnection"].ToString());
    HttpCookie cookie;
    protected void Page_Load(object sender, EventArgs e)
    {
        //cookie =
        if (!IsPostBack)
        {

            if (Request.Cookies["Userid"] == null)
            {
                Response.Redirect("login.aspx");
            }
            Bindpic();
            Bindcard();
        }
    }

    private void Bindcard()
    {
        string str = "";
        string id = Request.Cookies["Userid"].Value;

        //SqlConnection con = new SqlConnection(cn);
        DataTable dt = D.GetData("select * from Profile where Cid ='" + id + "'");
        foreach (DataRow row in dt.Rows)
        {


            str += "<a href='../Default.aspx?uid=" + id + "' target='_blank'>" +
                      "<div class='btn btn-flat '>" +
                      "<span class='btn-title'>See DBCard</span>" +
                   "<i class='fa fa-id-card' aria-hidden='true'></i>" +
                      "</div>" +
                        "</a>";
        }

        ltrid.Text = str;
    }
    private void Bindpic()
    {
        string str = "";
        string id = Request.Cookies["Userid"].Value;

        //SqlConnection con = new SqlConnection(cn);
        DataTable dt = D.GetData("select * from Profile where Cid ='" + id + "'");
        foreach (DataRow row in dt.Rows)
        {

            str += "<img src='" + row["Image"] + "' alt='Upload Profile Image' height='70px' width='70px' class='img-circle peaktp'><br>" +

                                   " <span class='peak' style='color:#fff;'></span> ";


            //" <img class='uploadcard' width='200' height='190' src='" + row["Image"] + "' style='padding-top: 0%;'>";




        }

        Ltrpic.Text = str;

    }





}
