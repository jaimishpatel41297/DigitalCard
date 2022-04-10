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
using System.Net;
using System.Collections.Specialized;
using System.Text.RegularExpressions;

public partial class Default : System.Web.UI.Page
{
    Connection D = new Connection();
    SqlConnection cn = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["DigitalCardConnection"].ToString());

    private const string key = "AIzaSyBkK8MOoVRv8pcHPQc_2DtvkcA9fXrWTVg";
    protected void Page_Load(object sender, EventArgs e)
    {

        //save1.ServerClick += new EventHandler(lbVcf_Click);
        if (!IsPostBack)
        {
            //if (Request.QueryString["uid"] == null)
            //{
            //    Response.Redirect("Admin/Register.aspx");
            //}

            BindMeta();
            Bindprofileimg();
            Bindbasicdata();
            Bindabout();
            BindCompanyDetails();
            BindCompany();
            BindContact();
            BindSocial();
            BindService();
            BindSocial1();
            BindColor();
            BindOffer();

            //if (Request.Cookies["Userid"] == null)
            //{
            //    Response.Redirect("login.aspx");
            //}
        }

    }

    private void BindMeta()
    {
        string str = "";

        string id = Request.QueryString["uid"];

        string qry = "select * from Member where id=" + id;

        DataTable dt = D.GetData(qry);
        foreach (DataRow rows in dt.Rows)
        {
            str += "<meta name='description' content='Digital card | " + rows["Name"] + " | " + rows["Company"] + "'>" +
                   "<meta property='og:title' content='E-visiting card | " + rows["Name"] + " | " + rows["Company"] + "' />" +
                   "<meta property='og:url' content='http://digitalcard.co.in/?uid=" + id + " />" +
                   "<meta property='og:image' content='http://digitalcard.co.in/Admin/" + rows["Image"] + "'>" +
                   "<meta property='og:description' content='" + rows["Company"] + "'>";
        }

        Ltrmeta.Text = str;

    }

    private void BindService()
    {
        string str = "";

        //string id = "1";
        string id = Request.QueryString["uid"];

        DataTable dt = D.GetData("select top 3 * from Services where id='" + id + "' order by id desc");
        foreach (DataRow row in dt.Rows)
        {

            str += "<div class='col col-d-12 col-t-6 col-m-12 border-line-h'>" +
                   "<div class='service-item'>" +
                   "<div class='icon'><span class='ion ion-briefcase'></span></div>" +
                   "<div class='name'>" + row["Title"] + "</div>" +
                   "<p>" +
                   "" + row["Description"] + "" +
                   "</p>" +
                   "</div>" +
                   "</div>";
        }

        Ltrservice.Text = str;
    }

    private void Bindprofileimg()
    {
        string str = "";

        //string id = "1";
        string id = Request.QueryString["uid"];

        //SqlConnection con = new SqlConnection(cn);
        DataTable dt = D.GetData("select * from Member where id ='" + id + "'");
        foreach (DataRow row in dt.Rows)
        {

            str += " <div class='image'>" +
                    "	<img src='Admin/" + row["Image"] + "' alt='' / style='height: 140px;'>" +
                    "</div>";


            // "<img src='" + row["Image"] + "' alt='Upload Profile Image' height='70px' width='70px' class='img-circle peaktp'><br>" +              
        }

        Ltrimage.Text = str;

    }

    private void Bindbasicdata()
    {
        string str = "";

        //string id = "1";
        string id = Request.QueryString["uid"];

        //SqlConnection con = new SqlConnection(cn);
        DataTable dt = D.GetData("select * from Member where id ='" + id + "'");

        foreach (DataRow row in dt.Rows)
        {

            str += "<div class='title'>" + row["Name"] + "</div>" +
                    "<div class='subtitle'>" + row["Company"] + " - " + row["Role"] + "</div>";

        }

        Ltrbasic.Text = str;

    }

    private void Bindabout()
    {
        string str = "";

        //string id = "1";
        string id = Request.QueryString["uid"];

        DataTable dt = D.GetData("select * from Member where id ='" + id + "'");

        foreach (DataRow row in dt.Rows)
        {

            str += "	<div class='text-box'>" +
                                    "<p>" +
                                        "" + row["About"] + "" +
                                    "</p>" +
                            "	</div>" +
                            "	<div class='info-list'>" +

                                "</div>";
        }

        Ltrabout.Text = str;

    }

    private void BindCompanyDetails()
    {
        string str = "";

        //string id = "1";
        string id = Request.QueryString["uid"];

        DataTable dt = D.GetData("select * from Member where id ='" + id + "'");

        foreach (DataRow row in dt.Rows)
        {

            str += "	<div class='text-box'>" +
                                    "<p>" +
                                        "" +
                                    "</p>" +
                            "</div>" +
                            "<div class='info-list'>" +
                                "<ul>" +
                                "<li><strong>Company Name : </strong><br> " + row["Company"] + "</li>" +
                                   "<br>" +
                                     "<li><strong>Company Address : </strong> <br>" + row["CompanyAddress"] + "</li>" +
                                         "<br>" +
                                    "	<li><strong>Website : </strong><br> " + row["website"] + "</li>" +
                                    "</ul>" +
                                "</div>";
        }

        ltrcompanyd.Text = str;

    }
    private void BindCompany()
    {
        string str = "";

        //string id = "1";
        string id = Request.QueryString["uid"];

        DataTable dt = D.GetData("select * from Member where id ='" + id + "'");

        foreach (DataRow row in dt.Rows)
        {
            str += "<div class='info-list'>" +
                   "<ul>" +
                   "<li><strong><i class='fas fa-map-marker-alt'></i>&nbsp;Address</strong><br><a href='" + row["Map"] + "' target='_blank'>" + row["CompanyAddress"] + "</a></li>" +
                   "<br>" +
                   "<br>" +
                   "<li><strong><i class='fa fa-envelope' aria-hidden='true'></i>&nbsp;Company Email </strong><br><a href=" + row["CompanyEmail"] + ">" + row["CompanyEmail"] + "</a></li>" +
                   "<br>" +
                   "<br>" +
                   "<li><strong><i class='fa fa-phone' aria-hidden='true'></i>&nbsp;Company Phone </strong><br> " + row["CompanyPhone"] + "</li>" +
                   "<br>" +
                   "<br>" +
                   "<li><strong><i class='fa fa-at' aria-hidden='true'></i>&nbsp;WebSite </strong><br><a href='" + row["CompanyUrl"] + "' target='_blank'>" + row["CompanyUrl"] + "</a></li>" +
                   "</ul>" +
                   "</div>";
        }
        Ltrcompany.Text = str;
    }

    private void BindContact()
    {
        string str = "";
        string id = Request.QueryString["uid"];

        //string id = "1";

        DataTable dt = D.GetData("select * from Member where id ='" + id + "'");

        foreach (DataRow row in dt.Rows)
        {

            str += "<ul>" +
                "<li><strong><i class='fa fa-phone' aria-hidden='true'></i>&nbsp;Mobile</strong><br> " + row["Mobile"] + "</li>" +
                                       " <br>" +
                                      "  <br>" +
                                    "	<li><strong><i class='fa fa-envelope' aria-hidden='true'></i>&nbsp;Email </strong><br> " + row["Email"] + "</li>" +
                                     "   <br>" +
                                      "  <br>" +
                                        "<li><strong><i class='fab fa-whatsapp'></i>&nbsp;Whatsapp </strong><br> " + row["Whatsappno"] + "</li>" +
                                      "  <br>" +
                                      "  <br>" +
                                    "	<li><strong><i class='fab fa-facebook'></i>&nbsp;Facebook</strong><br>" + row["Facebooklink"] + "</li>" +
                                "	</ul>";
        }

        //Ltrcontact.Text = str;

    }
    private void BindSocial()
    {
        string str = "";

        //string id = "1";
        string id = Request.QueryString["uid"];

        DataTable dt = D.GetData("select * from Member where id ='" + id + "'");

        foreach (DataRow row in dt.Rows)
        {

            if (row["Facebooklink"] != "")
            {
                str += " <a target='_blank' href='" + row["Facebooklink"] + "'><span class='fab fa-facebook'></span></a> ";
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

        //Ltrsocial.Text = str;

    }

    private void BindSocial1()
    {
        string str = "";
        string id = Request.QueryString["uid"];

        //string id = "1";

        DataTable dt = D.GetData("select top 1 * from Member where id ='" + id + "'");

        foreach (DataRow row in dt.Rows)
        {

            str += "<div style='width: 170px; margin-top: 5px; margin-left: auto; margin-right: auto;'>" +
                   "<a href='' data-toggle='modal' data-target='#myModal3'><i class='fab fa-whatsapp' style='font-size:35px;'></i></a>" +
                   "&nbsp;&nbsp;" +
                   "<a href ='" + row["Facebooklink"] + "' target='_blank'><i class='fab fa-facebook' style='font-size: 35px;'></i></a>" +
                   "&nbsp;&nbsp;" +
                   "<a href ='" + row["LinkedIn"] + "' target='_blank'><i class='fab fa-linkedin' style='font-size: 35px;'></i></a>" +
                   "&nbsp;&nbsp;" +
                   "</div>";

        }
        Ltrsocial1.Text = str;
    }

    private void BindColor()
    {
        string str = "";

        string id = "1007";
        //string id = Request.QueryString["uid"];

        DataTable dt = D.GetData("select * from ThemeMaster where Cid ='" + id + "'");

        foreach (DataRow row in dt.Rows)
        {

            str += " <link rel='stylesheet' href='../css/template-colors/" + row["Color"] + ".css' /> " +
                    "<link rel='stylesheet' href='css/template-dark/" + row["Version"] + ".css'>";

        }

        Ltrtheme.Text = str;

    }

    private void BindOffer()
    {
        string str = "";

        //string id = "1";
        string id = Request.QueryString["uid"];

        DataTable dt = D.GetData("select * from Offer where id='" + id + "' order by id desc");
        foreach (DataRow row in dt.Rows)
        {
            str += "<div class='col col-d-12 col-t-6 col-m-12 border-line-h'>" +
                   "<div class='service-item'>" +
                   "<div class='name'>" + row["Title"] + "</div>" +
                   "<p>" +
                   "" + row["Descri"] + "" +
                   "</p>" +
                   "</div>" +
                   "</div>";
        }

        Ltroffer.Text = str;
    }

    protected void lbSend_Click(Object Sender, EventArgs e)
    {
        string res = "";
        string id = Request.QueryString["uid"];
        SqlCommand cmd = new SqlCommand();

        DataTable dt = D.GetData("select top 1 * from MessageMaster");
        DataTable dt2 = D.GetData("select * from Member where id ='" + id + "'");

        string str = dt.Rows[0]["Sms"].ToString();
        string str2 = str.Replace("{name}", dt2.Rows[0]["Name"].ToString());
        string msg = str2.Replace("{bcardurl}", "www.DigitalCard.co.in/Digitalcard.aspx?ID=" + id + "");

        SendSms sms = new SendSms();
        res = sms.sendotp(msg, Txtnumber.Text);


        //divSuccess.Visible = true;
        //divError.Visible = false;

        //Response.Redirect("AboutMe.aspx");
    }
    protected void lbSendwa_Click(Object Sender, EventArgs e)
    {
        string ress = "";

        //string id = "1";
        string id = Request.QueryString["uid"];
        SqlCommand cmd = new SqlCommand();

        DataTable dt = D.GetData("select top 1 * from MessageMaster");
        DataTable dt2 = D.GetData("select * from Member where id ='" + id + "'");

        string str = dt.Rows[0]["Whatsapp"].ToString();
        string msg = str.Replace("{name}", dt2.Rows[0]["Name"].ToString());
        msg = msg.Replace("{bcardurl}", " www.digitalCard.co.in/Digitalcard.aspx?ID%3D" + id);

        //System.Net.WebRequest req = System.Net.WebRequest.Create("www.digitalCard.co.in/Digitalcard.aspx");
        //req.Proxy = new System.Net.WebProxy(, true);
        //Add these, as we're doing a POST
        //req.ContentType = "application/x-www-form-urlencoded";
        //req.Method = "POST";


        //        var response = System.Net.WebRequestMethods.Http.Post("www.digitalCard.co.in/Digitalcard.aspx", new NameValueCollection() {
        //    { "ID", "+ id +" }

        //});


        msg = msg.Replace("\n", "");
        msg = msg.Replace("\r", "");
        //msg = msg.Replace("=", "&#61;");  
        //SendSms sms = new SendSms();
        //sms.sendotpPetPalace(msg, Txtwa.Text);

        // string str = dt.Rows[0]["Whatsapp"].ToString();

        string mob = Txtwa.Text;


        //HttpServerUtility s=null;

        //var server = HttpContext.Current.Server;
        //server.Transfer("https://api.whatsapp.com/send?phone=91" + Txtwa.Text + "&text='" + msg + "'", true);

        try
        {
            //var url = "http://www.digitalCard.co.in/Postdata.aspx";
            //var client = new WebClient();
            //var method = "POST"; // If your endpoint expects a GET then do it. 
            //var parameters = new NameValueCollection();
            //parameters.Add("ID", "1");
            //var response_data = client.UploadValues(url, method, parameters); // Parse the returned data (if any) if needed. 
            //var data = client.UploadValues(url,"POST",client.QueryString);
            //var responseString = UnicodeEncoding.UTF8.GetString(response_data);
            //var responseString = UnicodeEncoding.UTF8.GetString(data);
            //data = data.Replace("\n", "");
            //data = data.Replace("\r", "");
            Response.Redirect("https://api.whatsapp.com/send?phone=91" + mob + "&text=http://www.digitalCard.co.in?uid=" + id + "");
        }
        catch (Exception)
        {

            throw;
        }

        //Response.Redirect(" https://api.whatsapp.com/send?phone=" + Txtwa.Text +"&text="+ msg + "");

        //divSuccess.Visible = true;
        //divError.Visible = false;

        //Response.Redirect("AboutMe.aspx");
    }
    protected void lbVcf_Click(Object Sender, EventArgs e)
    {
        //string id = "1";
        string id = Request.QueryString["uid"];
        SqlCommand cmd = new SqlCommand();

        DataTable dt = D.GetData("select * from Member where id ='" + id + "'");
        DataTable dt2 = D.GetData("select * from companydetail where id ='" + id + "'");

        string name = dt.Rows[0]["Name"].ToString();
        //string nameTitle = "Mr";
        string email = dt.Rows[0]["Email"].ToString();
        string uRL = dt.Rows[0]["website"].ToString();
        string telephone = dt.Rows[0]["CompanyPhone"].ToString();
        //string fax = "(0) 1555 555555";
        string mobile = dt.Rows[0]["Mobile"].ToString();
        string company = dt.Rows[0]["Company"].ToString();
        //string department = "Owner";
        //string title = "Managing Director";
        string profession = dt.Rows[0]["Role"].ToString();
        //string office = "Bedroom";
        string addressTitle = dt.Rows[0]["CompanyAddress"].ToString();
        //string streetName = "25 Nowhere Str";
        //string city = "London";
        //string region = "Surrey";
        //string postCode = "GU30 7BZ";
        //string country = "ENGLAND";
        //string fileName = @"../User.vcf";

        string fileName = Server.MapPath("~/" + name + "_" + id + ".vcf");


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

            //Response.Write("<script>window.open ('" + fileName + "','_blank');</script>");
            //Response.Redirect(fileName);

        }
        catch (Exception Ex)
        {
            Console.WriteLine(Ex.ToString());
        }

        Response.ContentType = "application/octet-stream";
        Response.AppendHeader("Content-Disposition", "filename=" + name + "_" + id + ".vcf");
        Response.TransmitFile(fileName);
        Response.End();

    }


    protected void btnShare_Click(object sender, EventArgs e)
    {
        int jj = txtmobile.Text.Length;

        if (jj <= 10)
        {

            string ress = "";

            //string id = "1";
            string id = Request.QueryString["uid"];
            SqlCommand cmd = new SqlCommand();

            DataTable dt = D.GetData("select top 1 * from MessageMaster");
            DataTable dt2 = D.GetData("select * from Member where id ='" + id + "'");

            string str = dt.Rows[0]["Whatsapp"].ToString();
            string msg = str.Replace("{name}", dt2.Rows[0]["Name"].ToString());

            string url = "http://www.digitalCard.co.in?uid%3D" + id + "";

            //string finalurl = urlShorter(url);
            string finalurl = url;

            msg = msg.Replace("{bcardurl}", finalurl);

            msg = msg.Replace("\n", "");
            msg = msg.Replace("\r", "");

            string mob = Txtwa.Text;

            try
            {
                Response.Redirect("https://api.whatsapp.com/send?phone=91" + txtmobile.Text + "&text=" + msg);
            }
            catch
            {
            }
        }
        else
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Mobile No is more than 10 digits.')", true);
        }
    }


    public string urlShorter(string url)
    {
        string finalURL = "";
        string post = "{\"longUrl\": \"" + url + "\"}";
        string shortUrl = url;
        HttpWebRequest request = (HttpWebRequest)WebRequest.Create("https://www.googleapis.com/urlshortener/v1/url?key=" + key);
        try
        {
            request.ServicePoint.Expect100Continue = false;
            request.Method = "POST";
            request.ContentLength = post.Length;
            request.ContentType = "application/json";
            request.Headers.Add("Cache-Control", "no-cache");
            using (Stream requestStream = request.GetRequestStream())
            {
                byte[] postBuffer = Encoding.ASCII.GetBytes(post);
                requestStream.Write(postBuffer, 0, postBuffer.Length);
            }
            using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
            {
                using (Stream responseStream = response.GetResponseStream())
                {
                    using (StreamReader responseReader = new StreamReader(responseStream))
                    {
                        string json = responseReader.ReadToEnd();
                        finalURL = Regex.Match(json, @"""id"": ?""(?<id>.+)""").Groups["id"].Value;
                        //finalURL = Regex.Match(json, @"""id"": ?""(?.+)""").Groups["id"].Value;
                    }
                }
            }
        }
        catch (Exception ex)
        {

            // if Google's URL Shortener is down...
            System.Diagnostics.Debug.WriteLine(ex.Message);
            System.Diagnostics.Debug.WriteLine(ex.StackTrace);
        }
        return finalURL;
    }
}