using System;
using System.IO;
using System.Collections;
using System.Drawing;
using System.Text;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Drawing;
using System.Web.UI.WebControls;
using System.Web.SessionState;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI.HtmlControls;

public partial class Digitalcard : System.Web.UI.Page
{
    Connection D = new Connection();
    SqlConnection cn = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["DigitalCardConnection"].ToString());
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Request.QueryString["ID"] == null)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Link Expired');window.location ='Default.aspx;", true);
            }
            Bindprofileimg();
            Bindbasic();
            Bindabout();
            BindCompany();
            BindContact();
            BindSocial();
            BindColor();

        }
    }
    private void Bindbasic()
    {
        string str = "";
        int IId = Convert.ToInt32(Request.QueryString["ID"]);
        //SqlConnection con = new SqlConnection(cn);
        DataTable dt = D.GetData("select * from Profile where Cid=" + IId);
        foreach (DataRow row in dt.Rows)
        {
            str +=" <div class='title'>" + row["Name"] + "</div> "+
					 "<div class='subtitle'>" + row["Company"] + " - " + row["Role"] + "</div>";
                
              
        }
         Ltrbasic.Text = str;

    }
    private void Bindprofileimg()
    {
        string str = "";
        int id = Convert.ToInt32(Request.QueryString["ID"]);

        //SqlConnection con = new SqlConnection(cn);
        DataTable dt = D.GetData("select * from Profile where Cid ='" + id + "'");
        foreach (DataRow row in dt.Rows)
        {

            str += " <div class='image'>" +
                    "	<img src='Admin/" + row["Image"] + "' alt='' / style='height: 140px;'>" +
                    "</div>";


            // "<img src='" + row["Image"] + "' alt='Upload Profile Image' height='70px' width='70px' class='img-circle peaktp'><br>" +              
        }

        Ltrimage.Text = str;

    }
    private void Bindabout()
    {
        string str = "";
        int id = Convert.ToInt32(Request.QueryString["ID"]);

        DataTable dt = D.GetData("select * from Profile where Cid ='" + id + "'");

        foreach (DataRow row in dt.Rows)
        {

            str += "	<div class='text-box'>" +
                                    "<p>" +
                                        "" + row["About"] + "" +
                                    "</p>" +
                            "	</div>" +
                            "	<div class='info-list'>" +
                                "	<ul>" +
                                "		<li><strong>Company Name . . .</strong>" + row["Company"] + "</li>" +
                                   "     <br>" +
                                     "	<li><strong>Website  . . . . . . . . . . . .</strong>" + row["website"] + "</li>" +

                                    "</ul>" +
                                "</div>";

            // "<div class='title'>" + row["Name"] + "</div>" +


        }

        Ltrabout.Text = str;

    }

    private void BindCompany()
    {
        string str = "";
        int id = Convert.ToInt32(Request.QueryString["ID"]);

        DataTable dt = D.GetData("select * from CompanyDetail where Cid ='" + id + "'");

        foreach (DataRow row in dt.Rows)
        {

            str += " <div class='info-list'> " +
                                    "<ul> " +
                                    "	<li><strong><i class='fas fa-map-marker-alt'></i>&nbsp;Address</strong><br> " + row["Address"] + "</li> " +
                                     "   <br>" +
                                     "   <br>" +
                                    "	<li><strong><i class='fa fa-envelope' aria-hidden='true'></i>&nbsp;Email </strong><br> " + row["Email"] + "</li>" +
                                     "   <br>" +
                                     "   <br>" +
                                    "	<li><strong><i class='fa fa-phone' aria-hidden='true'></i>&nbsp;Phone </strong><br> " + row["Phone"] + "</li>" +
                                    "    <br>" +
                                   "     <br>" +
                                    "	<li><strong><i class='fa fa-at' aria-hidden='true'></i>&nbsp;URL</strong><br> " + row["URL"] + "</li>" +
                                "	</ul>" +
                                "</div>" +
                               " <br></br>" +
                               " <div>" +
                                 "   <iframe src='" + row["Map"] + "' width='350' height='300' frameborder='0' style='border:0' allowfullscreen></iframe>" +


                                "</div>";

            // "<div class='title'>" + row["Name"] + "</div>" +


        }

        Ltrcompany.Text = str;

    }


    private void BindContact()
    {
        string str = "";
        int id = Convert.ToInt32(Request.QueryString["ID"]);

        DataTable dt = D.GetData("select * from ContactDetail where Cid ='" + id + "'");

        foreach (DataRow row in dt.Rows)
        {

            str += "<ul>" +
                                        "<li><strong><i class='fa fa-phone' aria-hidden='true'></i>&nbsp;Mobile</strong><br> " + row["Mobile"] + "</li>" +
                                       " <br>" +
                                      "  <br>" +
                                    "	<li><strong><i class='fa fa-envelope' aria-hidden='true'></i>&nbsp;Email </strong><br> " + row["Email"] + "</li>" +
                                     "   <br>" +
                                      "  <br>" +
                                        "<li><strong><i class='fab fa-whatsapp'></i>&nbsp;Whatsapp </strong><br> " + row["Whatsapp"] + "</li>" +
                                      "  <br>" +
                                      "  <br>" +
                                    "	<li><strong><i class='fab fa-facebook'></i>&nbsp;Facebook</strong><br>" + row["Facebook"] + "</li>" +
                                "	</ul>";

            // "<div class='title'>" + row["Name"] + "</div>" +


        }

        Ltrcontact.Text = str;

    }
    private void BindSocial()
    {
        string str = "";
        int id = Convert.ToInt32(Request.QueryString["ID"]);

        DataTable dt = D.GetData("select * from SocialLink where Cid ='" + id + "'");

        foreach (DataRow row in dt.Rows)
        {

            if (row["Facebook"] != "")
            {
                str += " <a target='_blank' href='" + row["Facebook"] + "'><span class='fab fa-facebook'></span></a> ";

            }
            if (row["Twitter"] != "")
            {
                str += " <a target='_blank' href='" + row["Twitter"] + "'><span class='fab fa-twitter'></span></a> ";
            }
            if (row["Google"] != "")
            {
                str += " <a target='_blank' href='" + row["Google"] + "'><span class='fab fa-google-plus-square'></span></a> ";
            }
            if (row["Linkedin"] != "")
            {
                str += " <a target='_blank' href='" + row["Linkedin"] + "'><span class='fab fa-linkedin'></span></a> ";
            }
            if (row["Youtube"] != "")
            {
                str += " <a target='_blank' href='" + row["Youtube"] + "'><span class='fab fa-youtube'></span></a> ";
            }
            if (row["Instagram"] != "")
            {
                str += " <a target='_blank' href='" + row["Instagram"] + "'><span class='fab fa-instagram'></span></a> ";
            }


        }

        Ltrsocial.Text = str;

    }

    private void BindColor()
    {
        string str = "";
        int id = Convert.ToInt32(Request.QueryString["ID"]);

        DataTable dt = D.GetData("select * from ThemeMaster where Cid ='" + id + "'");

        foreach (DataRow row in dt.Rows)
        {

            str += " <link rel='stylesheet' href='../css/template-colors/" + row["Color"] + ".css' /> " +
                    "<link rel='stylesheet' href='css/template-dark/" + row["Version"] + ".css'>";

        }

        Ltrtheme.Text = str;

    }

    protected void lbSend_Click(Object Sender, EventArgs e)
    {
        string res = "";
        int id = Convert.ToInt32(Request.QueryString["ID"]);
        SqlCommand cmd = new SqlCommand();

        DataTable dt = D.GetData("select * from MessageMaster where Cid ='" + id + "'");
        DataTable dt2 = D.GetData("select * from Profile where Cid ='" + id + "'");

        string str = dt.Rows[0]["Sms"].ToString();
        string str2 = str.Replace("{name}", dt2.Rows[0]["Name"].ToString());
        string msg = str2.Replace("{bcardurl}", "www.DigitalCard.co.in/Digitalcard.aspx/?ID='" + id + "'");



        SendSms sms = new SendSms();
        res = sms.sendotp(msg, Txtnumber.Text);


        //divSuccess.Visible = true;
        //divError.Visible = false;

        //Response.Redirect("AboutMe.aspx");
    }
    protected void lbSendwa_Click(Object Sender, EventArgs e)
    {
        string res = "";
        int id = Convert.ToInt32(Request.QueryString["ID"]);
        SqlCommand cmd = new SqlCommand();

        DataTable dt = D.GetData("select * from MessageMaster where Cid ='" + id + "'");
        DataTable dt2 = D.GetData("select * from Profile where Cid ='" + id + "'");

        string str = dt.Rows[0]["Whatsapp"].ToString();
        string msg = str.Replace("{name}", dt2.Rows[0]["Name"].ToString());

        //SendSms sms = new SendSms();
        //res = sms.sendotpPetPalace(msg, Txtwa.Text);

        //Response.Redirect(" https://api.whatsapp.com/send?phone=" + Txtwa.Text +"&text="+ msg + "");

        //divSuccess.Visible = true;
        //divError.Visible = false;

        //Response.Redirect("AboutMe.aspx");
    }
    protected void lbVcf_Click(Object Sender, EventArgs e)
    {

        int id = Convert.ToInt32(Request.QueryString["ID"]);
        SqlCommand cmd = new SqlCommand();

        DataTable dt = D.GetData("select * from profile as p left join contactdetail as con on con.Cid = p.Cid where p.Cid ='" + id + "'");
        DataTable dt2 = D.GetData("select * from companydetail where Cid ='" + id + "'");

        string name = dt.Rows[0]["Name"].ToString();
        //string nameTitle = "Mr";
        string email = dt.Rows[0]["Email"].ToString();
        string uRL = dt.Rows[0]["website"].ToString();
        string telephone = dt2.Rows[0]["Phone"].ToString();
        //string fax = "(0) 1555 555555";
        string mobile = dt.Rows[0]["Mobile"].ToString();
        string company = dt2.Rows[0]["Name"].ToString();
        //string department = "Owner";
        //string title = "Managing Director";
        string profession = dt.Rows[0]["Role"].ToString();
        //string office = "Bedroom";
        string addressTitle = dt2.Rows[0]["Address"].ToString();
        //string streetName = "25 Nowhere Str";
        //string city = "London";
        //string region = "Surrey";
        //string postCode = "GU30 7BZ";
        //string country = "ENGLAND";

        string fileName = @"G:\New Project\DigitalCard New\vcard\User.vcf";


        try
        {
            // Check if file already exists. If yes, delete it.
            if (File.Exists(fileName))
            {
                File.Delete(fileName);
            }

            // Create a new file 
            using (StreamWriter stringWrite = File.CreateText(fileName))
            {
                stringWrite.WriteLine("BEGIN:VCARD");
                stringWrite.WriteLine("VERSION:2.1");
                //Name
                stringWrite.WriteLine("N:" + name);
                //Full Name
                stringWrite.WriteLine("FN:" + name);
                //Organisation
                stringWrite.WriteLine("ORG:" + company);
                //URL
                stringWrite.WriteLine("URL;WORK:" + uRL);
                //Title
                stringWrite.WriteLine("TITLE:" + profession);
                //Profession
                stringWrite.WriteLine("ROLE:" + profession);
                //Telephone
                stringWrite.WriteLine("TEL;WORK;VOICE:" + telephone);
                //Fax
                //stringWrite.WriteLine("TEL;WORK;FAX:" + fax);
                //Mobile
                stringWrite.WriteLine("TEL;CELL;VOICE:" + mobile);
                //Email
                stringWrite.WriteLine("EMAIL;PREF;INTERNET:" + email);
            }

            // Write file contents on console. 
            using (StreamReader sr = File.OpenText(fileName))
            {
                string s = "";
                while ((s = sr.ReadLine()) != null)
                {
                    Console.WriteLine(s);
                }
            }
        }
        catch (Exception Ex)
        {
            Console.WriteLine(Ex.ToString());
        }

        Response.ContentType = "application/octet-stream";
        Response.AppendHeader("Content-Disposition", "filename=User.vcf");
        Response.TransmitFile(Server.MapPath("~/vcard/User.vcf"));
        Response.End();



    }
}