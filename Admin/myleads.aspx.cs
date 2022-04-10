using System;
using System.IO;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Text;


public partial class Admin_myleads : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
       // cmpVCard.VCard(Response);
       
        string nameFirst = "pratik";
        string nameLast = "solanki";
        string nameMiddle = "J S";
        string nameTitle = "Mr";
        string email = "pratik@gmail.com";
        string uRL = "www.chemlock.co.uk";
        string telephone = "(0) 1555 555555";
        string fax = "(0) 1555 555555";
        string mobile = "(0) 7555 555555";
        string company = "Chemlock";
        string department = "Owner";
        string title = "Managing Director";
        string profession = "Developer";
        string office = "Bedroom";
        string addressTitle = "Chemlock";
        string streetName = "25 Nowhere Str";
        string city = "London";
        string region = "Surrey";
        string postCode = "GU30 7BZ";
        string country = "ENGLAND";
      
        string fileName = @"G:\New Project\DigitalCard New\new.vcf";


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
                stringWrite.WriteLine("N:" + nameLast + ";" + nameFirst +
                                      ";" + nameMiddle + ";" + nameTitle);
                //Full Name
                stringWrite.WriteLine("FN:" + nameFirst + " " +
                                      nameMiddle + " " + nameLast);
                //Organisation
                stringWrite.WriteLine("ORG:" + company + ";" + department);
                //URL
                stringWrite.WriteLine("URL;WORK:" + uRL);
                //Title
                stringWrite.WriteLine("TITLE:" + title);
                //Profession
                stringWrite.WriteLine("ROLE:" + profession);
                //Telephone
                stringWrite.WriteLine("TEL;WORK;VOICE:" + telephone);
                //Fax
                stringWrite.WriteLine("TEL;WORK;FAX:" + fax);
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
    }

    override protected void OnInit(EventArgs e)
    {
        //
        // CODEGEN: This call is required by the ASP.NET Web Form Designer.
        //
        InitializeComponent();
        base.OnInit(e);
    }

    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
        this.Load += new System.EventHandler(this.Page_Load);
    }



    public class cmpVCard : System.ComponentModel.Component
    {
        #region Attributes
        private const string nameFirst = "Chris";
        private const string nameLast = "Davey";
        private const string nameMiddle = "J S";
        private const string nameTitle = "Mr";
        private const string email = "chris.davey@chemlock.co.uk";
        private const string uRL = "www.chemlock.co.uk";
        private const string telephone = "(0) 1555 555555";
        private const string fax = "(0) 1555 555555";
        private const string mobile = "(0) 7555 555555";
        private const string company = "Chemlock";
        private const string department = "Owner";
        private const string title = "Managing Director";
        private const string profession = "Developer";
        private const string office = "Bedroom";
        private const string addressTitle = "Chemlock";
        private const string streetName = "25 Nowhere Str";
        private const string city = "London";
        private const string region = "Surrey";
        private const string postCode = "GU30 7BZ";
        private const string country = "ENGLAND";
        #endregion Attributes

        #region Component Designer generated code
        public cmpVCard(System.ComponentModel.IContainer Container)
        {
            //Required for Windows.Forms Class Composition Designer support
            Container.Add(this);
        }

        public cmpVCard()
        {
            //This call is required by the Component Designer.
            InitializeComponent();
            //Add any initialization after the InitializeComponent() call
        }

        //Component overrides dispose to clean up the component list.
        protected override void Dispose(Boolean disposing)
        {
            if (disposing)
            {
                if (components != null)
                {
                    components.Dispose();
                }
            }
            base.Dispose(disposing);
        }
        //Required by the Component Designer
        private System.ComponentModel.IContainer components;

        //NOTE: The following procedure is required by the Component Designer
        //It can be modified using the Component Designer.
        //Do not modify it using the code editor.
        [System.Diagnostics.DebuggerStepThrough()]
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
        }
        #endregion

        public static void VCard(HttpResponse response)
        {

            string path = @"G:\New Project\DigitalCard New\new.vcf";

          
            //clear response.object
        //    response.Clear();
       //     response.Charset = "";
            //set the response mime type for vCard

        //    response.ContentType = "text/x-vCard";
            //create a string writer

            StreamWriter stringWrite = File.CreateText(path);
            //System.IO.StringWriter stringWrite = new System.IO.StringWriter();
            //create an htmltextwriter which uses the stringwriter

           // System.Web.UI.HtmlTextWriter htmlWrite = new HtmlTextWriter(stringWrite);
            //vCard Begin
            stringWrite.WriteLine("BEGIN:VCARD");
            stringWrite.WriteLine("VERSION:2.1");
            //Name
            stringWrite.WriteLine("N:" + nameLast + ";" + nameFirst +
                                  ";" + nameMiddle + ";" + nameTitle);
            //Full Name
            stringWrite.WriteLine("FN:" + nameFirst + " " +
                                  nameMiddle + " " + nameLast);
            //Organisation
            stringWrite.WriteLine("ORG:" + company + ";" + department);
            //URL
            stringWrite.WriteLine("URL;WORK:" + uRL);
            //Title
            stringWrite.WriteLine("TITLE:" + title);
            //Profession
            stringWrite.WriteLine("ROLE:" + profession);
            //Telephone
            stringWrite.WriteLine("TEL;WORK;VOICE:" + telephone);
            //Fax
            stringWrite.WriteLine("TEL;WORK;FAX:" + fax);
            //Mobile
            stringWrite.WriteLine("TEL;CELL;VOICE:" + mobile);
            //Email
            stringWrite.WriteLine("EMAIL;PREF;INTERNET:" + email);
            //Address
            stringWrite.WriteLine("ADR;WORK;ENCODING=QUOTED-PRINTABLE:" + ";" +
                                  office + ";" + addressTitle + "=0D" +
                                  streetName + ";" + city + ";" +
                                  region + ";" + postCode + ";" + country);

            //Revision Date
            //Not needed
            //stringWrite.WriteLine("REV:" + DateTime.Today.Year.ToString() +
            //            DateTime.Today.Month.ToString() + DateTime.Today.Day.ToString() + "T" +
            //            DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + 
            //            DateTime.Now.Second.ToString() + "Z");
            //vCard End
            stringWrite.WriteLine("END:VCARD");
         //   response.Write(stringWrite.ToString());
         //   response.End();




        }
    }
}



