using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using System.Configuration;
using System.Net;
using System.IO;
using System.Net.NetworkInformation;
using System.Web.Script.Serialization;
using System.Web.UI.WebControls;
using System.Text.RegularExpressions;
/// <summary>
/// Summary description for Service
/// </summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
// To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
// [System.Web.Script.Services.ScriptService]
public class Service : System.Web.Services.WebService
{
    SqlConnection cnn = new SqlConnection("Data Source=103.242.119.138;Initial Catalog=MagikRetail;uid=sa;pwd=tech@123;;");
    string cn = System.Configuration.ConfigurationManager.ConnectionStrings["MagikRetailConnection"].ConnectionString;
    //SqlCommand cmd = new SqlCommand();
    GetData D = new GetData();
    Connection cc = new Connection();
    Double total = 0;
    public Service()
    {

        //Uncomment the following line if using designed components 
        //InitializeComponent(); 
    }

    [WebMethod]
    public void login(string type, string email, string password)
    {
        JavaScriptSerializer js = new JavaScriptSerializer();
        int i = 0;
        List<UserMaster> list = new List<UserMaster>();
        List<GeneralDataUser> g = new List<GeneralDataUser>();
        if (type == "login")
        {
            try
            {
                DataTable dt = cc.GetData("select * from ClientMaster where Email = '" + email + "'");
                if (dt.Rows.Count != 0)
                {
                    DataTable dt2 = cc.GetData("select um.*,sm.name as statename,cm.city as cityname from ClientMaster as um,[StateMaster] as sm,[CityMaster] as cm where um.stateid = sm.stateid and um.cityid = cm.id and um.Email = '" + email + "' and um.Password = '" + password + "'");
                    if (dt2.Rows.Count != 0)
                    {

                        for (i = 0; i <= dt2.Rows.Count - 1; i++)
                        {
                            UserMaster hc = new UserMaster();


                            hc.clientid = dt2.Rows[i]["Id"].ToString();
                            hc.name = dt2.Rows[i]["Name"].ToString();
                            hc.mobile = dt2.Rows[i]["Mobile"].ToString();
                            hc.email = dt2.Rows[i]["Email"].ToString();
                            hc.password = dt2.Rows[i]["password"].ToString();
                            hc.stateid = dt2.Rows[i]["stateid"].ToString();
                            hc.state = dt2.Rows[i]["Statename"].ToString();
                            hc.cityid = dt2.Rows[i]["cityid"].ToString();
                            hc.city = dt2.Rows[i]["Cityname"].ToString();
                            hc.logintype = dt2.Rows[i]["logintype"].ToString();

                            //if (dt2.Rows[i]["dob"].ToString() != "")
                            //{

                            //    hc.dob = Convert.ToDateTime(dt2.Rows[i]["dob"].ToString()).ToString("dd-MM-yyyy");
                            //    hc.time = Convert.ToDateTime(dt2.Rows[i]["date"].ToString()).ToString("hh:mm tt");
                            //}



                            hc.verificationstatus = dt2.Rows[i]["VerificationStatus"].ToString();
                            list.Add(hc);

                        }
                        GeneralDataUser data = new GeneralDataUser();
                        data.MESSAGE = "Successfully !";
                        data.ORIGINAL_ERROR = "";
                        data.ERROR_STATUS = false;
                        data.RECORDS = true;
                        data.Data = list;
                        g.Add(data);
                        Context.Response.Write(js.Serialize(g[0]));
                    }
                    else
                    {

                        GeneralDataUser data = new GeneralDataUser();
                        data.MESSAGE = "Wrong Password !";
                        data.ORIGINAL_ERROR = "";
                        data.ERROR_STATUS = false;
                        data.RECORDS = false;
                        data.Data = list;
                        g.Add(data);
                        Context.Response.Write(js.Serialize(g[0]));
                    }
                }
                else
                {
                    GeneralDataUser data = new GeneralDataUser();
                    data.MESSAGE = "Wrong Email !";
                    data.ORIGINAL_ERROR = "";
                    data.ERROR_STATUS = false;
                    data.RECORDS = false;
                    data.Data = list;
                    g.Add(data);
                    Context.Response.Write(js.Serialize(g[0]));
                }

            }
            catch (Exception ex)
            {
                GeneralDataUser data = new GeneralDataUser();
                data.MESSAGE = "Failed";
                data.ORIGINAL_ERROR = ex.Message;
                data.ERROR_STATUS = true;
                data.RECORDS = false;
                g.Add(data);
                Context.Response.Write(js.Serialize(g[0]));
            }
        }
    }
    [WebMethod]

    public void GetItemDataforWeb(string type)
    {
        JavaScriptSerializer js = new JavaScriptSerializer();
        int i = 0;
        string qry = "";
        List<ItemMaster> list = new List<ItemMaster>();
        List<GeneralDataItem> g = new List<GeneralDataItem>();
        if (type == "item")
        {
            try
            {

                qry = "select *,engname + ' - ' + hindiname + ' - ' + gujaratiname as name from ItemMaster where CID=3";



                DataTable dt2 = D.GetDataTable(qry);
                if (dt2.Rows.Count != 0)
                {
                    for (i = 0; i <= dt2.Rows.Count - 1; i++)
                    {
                        ItemMaster hc = new ItemMaster();
                        hc.id = dt2.Rows[i]["Id"].ToString();
                        hc.name = dt2.Rows[i]["name"].ToString();
                        if (dt2.Rows[i]["KgPrice"].ToString() == "0.00")
                        {
                            hc.inkg = "0";
                        }
                        else
                        {
                            hc.inkg = "1";
                        }
                        if (dt2.Rows[i]["pcsprice"].ToString() == "0.00")
                        {
                            hc.inpcs = "0";
                        }
                        else
                        {
                            hc.inpcs = "1";
                        }
                        hc.kgprice = Convert.ToDouble(dt2.Rows[i]["RetailKgPrice"].ToString());
                        hc.pcsprice = Convert.ToDouble(dt2.Rows[i]["RetailPcsPrice"].ToString());
                        if (dt2.Rows[i]["image"].ToString() != "")
                        {
                            //hc.image = websitepath + dt2.Rows[i]["image"].ToString();
                            hc.image = dt2.Rows[i]["image"].ToString();
                        }
                        else
                        {
                            //hc.image = websitepath + "Resources/Images/Default2.jpg";
                            hc.image = "Resources/Images/Default2.jpg";
                        }

                        list.Add(hc);

                    }
                    GeneralDataItem data = new GeneralDataItem();
                    data.MESSAGE = "Successfully !";
                    data.ORIGINAL_ERROR = "";
                    string today = DateTime.Now.ToString("dd-MM-yyyy");
                    data.Date = today;
                    data.ERROR_STATUS = false;
                    data.RECORDS = true;
                    data.Data = list;
                    g.Add(data);
                    Context.Response.Write(js.Serialize(g[0]));
                }
                else
                {
                    GeneralDataItem data = new GeneralDataItem();
                    data.MESSAGE = "Data Not Available";
                    data.ORIGINAL_ERROR = "";
                    data.ERROR_STATUS = false;
                    data.RECORDS = false;
                    g.Add(data);
                    Context.Response.Write(js.Serialize(g[0]));
                }
            }
            catch (Exception ex)
            {
                GeneralDataItem data = new GeneralDataItem();
                data.MESSAGE = "Failed";
                data.ORIGINAL_ERROR = ex.Message;
                data.ERROR_STATUS = true;
                data.RECORDS = false;
                g.Add(data);
                Context.Response.Write(js.Serialize(g[0]));
            }
        }
    }
    [WebMethod]

    public void GetAllDataforWeb(string type)
    {
        JavaScriptSerializer js = new JavaScriptSerializer();
        int i = 0;
        string qry = "";
        List<ItemMaster> list = new List<ItemMaster>();
        List<GeneralDataItem> g = new List<GeneralDataItem>();
        if (type == "item")
        {
            try
            {

                qry = "select *,engname + ' - ' + hindiname + ' - ' + gujaratiname as name from ItemMaster";
                DataTable dt2 = D.GetDataTable(qry);
                if (dt2.Rows.Count != 0)
                {
                    for (i = 0; i <= dt2.Rows.Count - 1; i++)
                    {
                        ItemMaster hc = new ItemMaster();
                        hc.id = dt2.Rows[i]["Id"].ToString();
                        //hc.image = dt2.Rows[i]["image"].ToString();
                        hc.name = dt2.Rows[i]["name"].ToString();
                        if (dt2.Rows[i]["KgPrice"].ToString() == "0.00")
                        {
                            hc.inkg = "0";
                        }
                        else
                        {
                            hc.inkg = "1";
                        }
                        if (dt2.Rows[i]["pcsprice"].ToString() == "0.00")
                        {
                            hc.inpcs = "0";
                        }
                        else
                        {
                            hc.inpcs = "1";
                        }
                        hc.kgprice = Convert.ToDouble(dt2.Rows[i]["RetailKgPrice"].ToString());
                        hc.pcsprice = Convert.ToDouble(dt2.Rows[i]["RetailPcsPrice"].ToString());
                        if (dt2.Rows[i]["image"].ToString() != "")
                        {
                            //hc.image = websitepath + dt2.Rows[i]["image"].ToString();
                            hc.image = dt2.Rows[i]["image"].ToString();
                        }
                        else
                        {
                            //hc.image = websitepath + "Resources/Images/Default2.jpg";
                            hc.image = "Resources/Images/Default2.jpg";
                        }

                        list.Add(hc);

                    }
                    GeneralDataItem data = new GeneralDataItem();
                    data.MESSAGE = "Successfully !";
                    data.ORIGINAL_ERROR = "";
                    string today = DateTime.Now.ToString("dd-MM-yyyy");
                    data.Date = today;
                    data.ERROR_STATUS = false;
                    data.RECORDS = true;
                    data.Data = list;
                    g.Add(data);
                    Context.Response.Write(js.Serialize(g[0]));
                }
                else
                {
                    GeneralDataItem data = new GeneralDataItem();
                    data.MESSAGE = "Data Not Available";
                    data.ORIGINAL_ERROR = "";
                    data.ERROR_STATUS = false;
                    data.RECORDS = false;
                    g.Add(data);
                    Context.Response.Write(js.Serialize(g[0]));
                }
            }
            catch (Exception ex)
            {
                GeneralDataItem data = new GeneralDataItem();
                data.MESSAGE = "Failed";
                data.ORIGINAL_ERROR = ex.Message;
                data.ERROR_STATUS = true;
                data.RECORDS = false;
                g.Add(data);
                Context.Response.Write(js.Serialize(g[0]));
            }
        }
    }

    [WebMethod]

    public void productdata(string type, string id)
    {
        JavaScriptSerializer js = new JavaScriptSerializer();
        int i = 0;
        string qry = "";
        //int Iid = Convert.ToInt32(Request.QueryString["ID"]);
        List<ItemMaster> list = new List<ItemMaster>();
        List<GeneralDataItem> g = new List<GeneralDataItem>();
        if (type == "item")
        {
            try
            {

                qry = "select *,engname + ' - ' + hindiname + ' - ' + gujaratiname as name from ItemMaster where id=" +id;
                DataTable dt2 = D.GetDataTable(qry);
                if (dt2.Rows.Count != 0)
                {
                    for (i = 0; i <= dt2.Rows.Count - 1; i++)
                    {
                        ItemMaster hc = new ItemMaster();
                        hc.id = dt2.Rows[i]["Id"].ToString();
                        hc.name = dt2.Rows[i]["EngName"].ToString();
                        if (dt2.Rows[i]["KgPrice"].ToString() == "0.00")
                        {
                            hc.inkg = "0";
                        }
                        else
                        {
                            hc.inkg = "1";
                        }
                        if (dt2.Rows[i]["pcsprice"].ToString() == "0.00")
                        {
                            hc.inpcs = "0";
                        }
                        else
                        {
                            hc.inpcs = "1";
                        }
                        hc.kgprice = Convert.ToDouble(dt2.Rows[i]["RetailKgPrice"].ToString());
                        hc.pcsprice = Convert.ToDouble(dt2.Rows[i]["RetailPcsPrice"].ToString());
                        if (dt2.Rows[i]["image"].ToString() != "")
                        {
                            //hc.image = websitepath + dt2.Rows[i]["image"].ToString();
                            hc.image = dt2.Rows[i]["image"].ToString();
                        }
                        else
                        {
                            //hc.image = websitepath + "Resources/Images/Default2.jpg";
                            hc.image = "Resources/Images/Default2.jpg";
                        }

                        list.Add(hc);

                    }
                    GeneralDataItem data = new GeneralDataItem();
                    data.MESSAGE = "Successfully !";
                    data.ORIGINAL_ERROR = "";
                    string today = DateTime.Now.ToString("dd-MM-yyyy");
                    data.Date = today;
                    data.ERROR_STATUS = false;
                    data.RECORDS = true;
                    data.Data = list;
                    g.Add(data);
                    Context.Response.Write(js.Serialize(g[0]));
                }
                else
                {
                    GeneralDataItem data = new GeneralDataItem();
                    data.MESSAGE = "Data Not Available";
                    data.ORIGINAL_ERROR = "";
                    data.ERROR_STATUS = false;
                    data.RECORDS = false;
                    g.Add(data);
                    Context.Response.Write(js.Serialize(g[0]));
                }
            }
            catch (Exception ex)
            {
                GeneralDataItem data = new GeneralDataItem();
                data.MESSAGE = "Failed";
                data.ORIGINAL_ERROR = ex.Message;
                data.ERROR_STATUS = true;
                data.RECORDS = false;
                g.Add(data);
                Context.Response.Write(js.Serialize(g[0]));
            }
        }
    }

    [WebMethod]
    public void GetCartData(string itemkgprice,string unit,string itemid,string Qty,Int32 pick)
    {
        
        string Ipadd = string.Empty;
        if (HttpContext.Current.Request.ServerVariables["HTTP_X__FORWARDER_FOR"] != null)
        {

            Ipadd = HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDER_FOR"].ToString();
        }
        else if (HttpContext.Current.Request.UserHostAddress.Length != 0)
        {

            Ipadd = HttpContext.Current.Request.UserHostAddress;
        }
        //Label1.Text = "Your Ip Address is: " + Ipadd;
        
        ReturnData data = new ReturnData();
        JavaScriptSerializer js = new JavaScriptSerializer();
        try
        {
            D.ExecuteQuery("insert into [Cart] (Iid,Rate,Unit,Quantity,Pick,Ipaddress) values('"+ itemid +"','" + itemkgprice + "','"+ unit +"','"+ Qty +"','"+ pick +"','"+ Ipadd + "')");

            data.MESSAGE = "Successfully Inserted In Cart! Check Your Cart";
            data.ERROR_STATUS = false;
            Context.Response.Write(js.Serialize(data));
        }
        catch (Exception error)
        {
            data.MESSAGE = error.Message;
            data.ERROR_STATUS = true;
            Context.Response.Write(js.Serialize(data));
        }
       
    }
    [WebMethod]

    public void GetCartData2(string itempcsprice, string unit, string itemid, string Qty,Int32 pick)
    {
        
        string Ipadd = string.Empty;
        if (HttpContext.Current.Request.ServerVariables["HTTP_X__FORWARDER_FOR"] != null)
        {

            Ipadd = HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDER_FOR"].ToString();
        }
        else if (HttpContext.Current.Request.UserHostAddress.Length != 0)
        {

            Ipadd = HttpContext.Current.Request.UserHostAddress;
        }
        
        ReturnData data = new ReturnData();
        JavaScriptSerializer js = new JavaScriptSerializer();
        try
        {
            D.ExecuteQuery("insert into [Cart] (Iid,Rate,Unit,Quantity,Pick,Ipaddress) values('" + itemid + "','" + itempcsprice + "','" + unit + "','" + Qty + "','"+ pick +"','" + Ipadd + "')");

            data.MESSAGE = "Successfully Inserted In Cart! Check Your Cart";
            data.ERROR_STATUS = false;
            Context.Response.Write(js.Serialize(data));
        }
        catch (Exception error)
        {

            data.MESSAGE = error.Message;
            data.ERROR_STATUS = true;
            Context.Response.Write(js.Serialize(data));
        }

    }

    [WebMethod]
    public void findcustomer(string mob)
    {
        List<CustomerMaster> list = new List<CustomerMaster>();
        int i = 0;
        ReturnData data = new ReturnData();
        JavaScriptSerializer js = new JavaScriptSerializer();
        try
        {
                
                DataTable dt = D.GetDataTable("select * from CustomerMaster where Mobile ='" + mob +"'");
                foreach (DataRow row in dt.Rows)
                {
                      if (dt.Rows.Count != 0)
                      {
                            for (i = 0; i <= dt.Rows.Count - 1; i++)
                            {
                             DataTable dt2 = D.GetDataTable("select * from CustomerMaster");
                             
                             CustomerMaster hc = new CustomerMaster();
                             //hc.mobile = Convert.ToInt64(dt2.Rows[i]["Mobile"]);
                             //hc.mobile = dt2.Rows[i]["Mobile"].ToString();
                             hc.name = dt2.Rows[i]["Name"].ToString();
                             //hc.add = dt2.Rows[i]["Address"].ToString();
                             
                             list.Add(hc);
                            }
                            
                      }
                    else
                    {
                     //D.ExecuteQuery("insert into CustomerMaster (Mobile,Name,Address) values('" + Mobile + "','" + Name + "','" + Address + "')");
                     data.MESSAGE = "Successfully Inserted!";
                     data.ERROR_STATUS = false;
                     Context.Response.Write(js.Serialize(data));
                    
                 }
             }
        }
        catch (Exception error)
        {

               data.MESSAGE = error.Message;
               data.ERROR_STATUS = true;
               Context.Response.Write(js.Serialize(data));
         }
        
    
    }

    [WebMethod]
    public void findcustomer2(string mob)
    {
        JavaScriptSerializer js = new JavaScriptSerializer();
        int i = 0;
        string qry = "";
        List<CustomerMaster> list = new List<CustomerMaster>();
        ReturnData data = new ReturnData();
       
            try
            {
                qry = "select * from CustomerMaster where Mobile ='" + mob + "'";
                DataTable dt2 = D.GetDataTable(qry);
                if (dt2.Rows.Count != 0)
                {
                    for (i = 0; i <= dt2.Rows.Count - 1; i++)
                    {
                        CustomerMaster hc = new CustomerMaster();
                        hc.cid = dt2.Rows[i]["ID"].ToString();
                        hc.name = dt2.Rows[i]["Name"].ToString();
                        hc.address = dt2.Rows[i]["Address"].ToString();

                        list.Add(hc);
                    }
                    
                    data.MESSAGE = "Successfully !";

                    data.ERROR_STATUS = false;
                    data.Data = list;
                    Context.Response.Write(js.Serialize(data));
                }
                else
                {

                    data.MESSAGE = "Data Not Available";
                    data.ERROR_STATUS = false;
                    data.Data = null;
                    Context.Response.Write(js.Serialize(data));
                }
            }
            catch (Exception ex)
            {
                data.MESSAGE = ex.Message;
                data.ERROR_STATUS = true;
                Context.Response.Write(js.Serialize(data));
            }    
    }

    [WebMethod]
    public void insertorder(string mob, string name, string address, string grandtotal)
    {
      
        JavaScriptSerializer js = new JavaScriptSerializer();
        int i = 0;
        string qry = "";
        string res = "";
        string date = DateTime.Now.ToString("yyyy-MM-dd");
        string time = DateTime.Now.ToString("hh:mm:ss");
        
        List<CustomerMaster> list = new List<CustomerMaster>();
        
        ReturnData data = new ReturnData();

        try
        {
            CustomerMaster hc = new CustomerMaster();
            qry = "select * from CustomerMaster where Mobile ='" + mob + "'";
            DataTable dt2 = D.GetDataTable(qry);
            if (dt2.Rows.Count == 0)
            {
                
                for (i = 0; i <= dt2.Rows.Count - 1; i++)
                {
                    
                    hc.cid = dt2.Rows[i]["ID"].ToString();
                    hc.name = dt2.Rows[i]["Name"].ToString();
                    hc.address = dt2.Rows[i]["Address"].ToString();

                    list.Add(hc);
                }


                data.MESSAGE = "Your Mobile Number Is Not Registered!";
                data.ERROR_STATUS = false;
                data.Data = null;
                Context.Response.Write(js.Serialize(data));
            }
            else
            {
                DataTable dt = D.GetDataTable("SELECT SUM(Rate) AS Total FROM Cart");
                //hc.total = Convert.ToDouble(dt.Rows[0]["Total"].ToString());
                hc.Amount = Convert.ToDouble(dt.Rows[0]["Total"].ToString());
                hc.cid = dt2.Rows[i]["ID"].ToString();
                D.ExecuteQuery("insert into OrderMaster (Date,Time,CID,Total) values('" + date + "','" + time + "','" + hc.cid + "','" + grandtotal + "')");

                DataTable dt4 = D.GetDataTable("select id from OrderMaster where CID = '" + hc.cid + "' order by id desc");

                DataTable dt3 = D.GetDataTable("select ItemMaster.Engname,ItemMaster.Image,Cart.* from ItemMaster Right Join Cart ON ItemMaster.Id = Cart.Iid");
                for (i = 0; i <= dt3.Rows.Count - 1; i++)
                {
                    hc.id = dt3.Rows[i]["Iid"].ToString();
                    hc.unit = dt3.Rows[i]["Unit"].ToString();
                    hc.Qty = Convert.ToDouble(dt3.Rows[i]["Quantity"].ToString());
                    hc.price = Convert.ToDouble(dt3.Rows[i]["Rate"].ToString());
                    hc.oid = dt4.Rows[0]["Id"].ToString();

                    if (hc.unit == "GM")
                    {
                        Double amt = 0;
                        double rate = 0;
                        amt = Convert.ToInt32(hc.Qty) * Convert.ToInt32(dt3.Rows[i]["Pick"]);
                        if (amt > 999)
                        {
                            hc.unit = "KG";
                            amt = amt / 1000;
                            hc.Qty = Convert.ToDouble(amt);
                        }
                        else
                        {
                            hc.unit = "G";
                            hc.Qty = Convert.ToDouble(amt);
                        }
                        rate = Convert.ToInt32(dt3.Rows[i]["Pick"]) * Convert.ToDouble(dt3.Rows[i]["Rate"]);
                        hc.price = rate;
                    }
                    else
                    {
                        int amt = 0;
                        double rate = 0;
                        amt = Convert.ToInt32(hc.Qty) * Convert.ToInt32(dt3.Rows[i]["Pick"]);
                        hc.Qty = Convert.ToDouble(dt3.Rows[i]["Quantity"].ToString());
                        rate = Convert.ToInt32(dt3.Rows[i]["Pick"]) * Convert.ToDouble(dt3.Rows[i]["Rate"]);
                        hc.price = rate;
 
                    }

                    D.ExecuteQuery("insert into OrderItems(OID,IID,Unit,Qty,Amount) values('" + hc.oid + "','" + hc.id + "','" + hc.unit + "','" + hc.Qty + "','" + hc.price + "')");

                    SendSms sms = new SendSms();
                    res = sms.sendotp("Your Total Amount is :  " + grandtotal, dt2.Rows[0]["Mobile"].ToString());

                    list.Add(hc);
                }


                D.ExecuteQuery("DELETE FROM Cart");

                //data.MESSAGE = "Successfully Inserted!";
                //data.ERROR_STATUS = false;
                //Context.Response.Write(js.Serialize(data));
                data.MESSAGE = "Thank You For shopping With Us!";

                data.ERROR_STATUS = false;
                data.Data = list;
                Context.Response.Write(js.Serialize(data));
               
            }
        }
        catch (Exception ex)
        {
            data.MESSAGE = ex.Message;
            data.ERROR_STATUS = true;
            Context.Response.Write(js.Serialize(data));
        }
       
                 
               
    }
    [WebMethod]
    public void insertorder2(string mob, string name, string address, string grandtotal)
    {
        JavaScriptSerializer js = new JavaScriptSerializer();
        int i = 0;
        string qry = "";
        string date = DateTime.Now.ToString("yyyy-MM-dd");
        string time = DateTime.Now.ToString("hh:mm:ss");
        
        List<CustomerMaster> list = new List<CustomerMaster>();
        
        ReturnData data = new ReturnData();
        CustomerMaster hc = new CustomerMaster();

         D.ExecuteQuery("insert into CustomerMaster (Mobile,Name,Address) values('" + mob + "','" + name + "','" + address + "')");

                DataTable dt = D.GetDataTable("SELECT SUM(Rate) AS Total FROM Cart");
                hc.total = Convert.ToDouble(dt.Rows[0]["Total"].ToString());
                

                DataTable dt5 = D.GetDataTable("select id from CustomerMaster order by id desc");
                hc.cid = dt5.Rows[0]["Id"].ToString();
                D.ExecuteQuery("insert into OrderMaster (Date,Time,CID,Total) values('" + date + "','" + time + "','" + hc.cid + "','" + grandtotal + "')");


                DataTable dt4 = D.GetDataTable("select id from OrderMaster where CID = '" + hc.cid + "' order by id desc");


                DataTable dt3 = D.GetDataTable("select ItemMaster.Engname,ItemMaster.Image,Cart.* from ItemMaster Right Join Cart ON ItemMaster.Id = Cart.Iid");
                for (i = 0; i <= dt3.Rows.Count - 1; i++)
                {
                    hc.id = dt3.Rows[i]["Iid"].ToString();
                    hc.unit = dt3.Rows[i]["Unit"].ToString();
                    hc.Qty = Convert.ToDouble(dt3.Rows[i]["Quantity"].ToString());
                    hc.price = Convert.ToDouble(dt3.Rows[i]["Rate"].ToString());
                    hc.oid = dt4.Rows[0]["Id"].ToString();
                    //int amount = Convert.ToInt32(hc.Qty) * Convert.ToInt32(hc.price);

                    if (hc.unit == "GM")
                    {
                        Double amt = 0;
                        double rate = 0;
                        amt = Convert.ToInt32(hc.Qty) * Convert.ToInt32(dt3.Rows[i]["Pick"]);
                        if (amt > 999)
                        {
                            hc.unit = "KG";
                            amt = amt / 1000;
                            hc.Qty = Convert.ToDouble(amt);
                        }
                        else
                        {
                            hc.unit = "G";
                            hc.Qty = Convert.ToDouble(amt);
                        }
                        rate = Convert.ToInt32(dt3.Rows[i]["Pick"]) * Convert.ToDouble(dt3.Rows[i]["Rate"]);
                        hc.price = rate;
                    }
                    else
                    {
                        int amt = 0;
                        double rate = 0;
                        amt = Convert.ToInt32(hc.Qty) * Convert.ToInt32(dt3.Rows[i]["Pick"]);
                        hc.Qty = Convert.ToDouble(dt3.Rows[i]["Quantity"].ToString());
                        rate = Convert.ToInt32(dt3.Rows[i]["Pick"]) * Convert.ToDouble(dt3.Rows[i]["Rate"]);
                        hc.price = rate;
                    }

                    D.ExecuteQuery("insert into OrderItems(OID,IID,Unit,Qty,Amount) values('" + hc.oid + "','" + hc.id + "','" + hc.unit + "','" + hc.Qty + "','" + hc.price + "')");

                    list.Add(hc);
                }
                
                D.ExecuteQuery("DELETE FROM Cart");
                //data.MESSAGE = "Data Not Available";
                data.MESSAGE = "Thank You For shopping With Us!";
                data.ERROR_STATUS = false;
                Context.Response.Write(js.Serialize(data));
        

    }

    [WebMethod]
    public void Updatecart(string itemid, string pick)
    {
        int pick1 = Convert.ToInt32(pick) + 1;
        ReturnData data = new ReturnData();
        JavaScriptSerializer js = new JavaScriptSerializer();
        try
        {
            D.ExecuteQuery("UPDATE [dbo].[Cart] SET Pick = '"+ pick1 +"' WHERE Id = " + itemid);
            data.MESSAGE = "Successfully Edited!";
            data.ERROR_STATUS = false;
            Context.Response.Write(js.Serialize(data));
        }
        catch (Exception error)
        {

            data.MESSAGE = error.Message;
            data.ERROR_STATUS = true;
            Context.Response.Write(js.Serialize(data));
        }
    }

    [WebMethod]
    public void Deleteitem(string type, string itemid)
    {

        ReturnData data = new ReturnData();
        JavaScriptSerializer js = new JavaScriptSerializer();
        if (type == "item")
        {
            try
            {
                D.ExecuteQuery("DELETE FROM Cart WHERE id = " + itemid);

                data.MESSAGE = "Successfully Deleted!";
                data.ERROR_STATUS = false;
                Context.Response.Write(js.Serialize(data));
            }
            catch (Exception error)
            {

                data.MESSAGE = error.Message;
                data.ERROR_STATUS = true;
                Context.Response.Write(js.Serialize(data));
            }
        }
    }
    [WebMethod]
    public void Deleteallitem()
    {
        string Ipadd = string.Empty;
        if (HttpContext.Current.Request.ServerVariables["HTTP_X__FORWARDER_FOR"] != null)
        {

            Ipadd = HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDER_FOR"].ToString();
        }
        else if (HttpContext.Current.Request.UserHostAddress.Length != 0)
        {

            Ipadd = HttpContext.Current.Request.UserHostAddress;
        }

        ReturnData data = new ReturnData();
        JavaScriptSerializer js = new JavaScriptSerializer();
        
            try
            {
                D.ExecuteQuery("DELETE FROM Cart where ipaddress='" + Ipadd + "'");

                data.MESSAGE = "Successfully Deleted!";
                data.ERROR_STATUS = false;
                Context.Response.Write(js.Serialize(data));
            }
            catch (Exception error)
            {

                data.MESSAGE = error.Message;
                data.ERROR_STATUS = true;
                Context.Response.Write(js.Serialize(data));
            }
        
    }
     [WebMethod]
    public void GetItemDataforWeb2(string type)
    {
        JavaScriptSerializer js = new JavaScriptSerializer();
        int i = 0;
        string qry = "";
        List<ItemMaster> list = new List<ItemMaster>();
        List<GeneralDataItem> g = new List<GeneralDataItem>();
        if (type == "item")
        {
            try
            {

                qry = "select *,engname + ' - ' + hindiname + ' - ' + gujaratiname as name from ItemMaster where CID=1";

                DataTable dt2 = D.GetDataTable(qry);
                if (dt2.Rows.Count != 0)
                {
                    for (i = 0; i <= dt2.Rows.Count - 1; i++)
                    {
                        ItemMaster hc = new ItemMaster();
                        hc.id = dt2.Rows[i]["Id"].ToString();
                        hc.name = dt2.Rows[i]["name"].ToString();
                        if (dt2.Rows[i]["KgPrice"].ToString() == "0.00")
                        {
                            hc.inkg = "0";
                        }
                        else
                        {
                            hc.inkg = "1";
                        }
                        if (dt2.Rows[i]["pcsprice"].ToString() == "0.00")
                        {
                            hc.inpcs = "0";
                        }
                        else
                        {
                            hc.inpcs = "1";
                        }
                        hc.kgprice = Convert.ToDouble(dt2.Rows[i]["RetailKgPrice"].ToString());
                        hc.pcsprice = Convert.ToDouble(dt2.Rows[i]["RetailPcsPrice"].ToString());

                        if (dt2.Rows[i]["image"].ToString() != "")
                        {
                            //hc.image = websitepath + dt2.Rows[i]["image"].ToString();
                            hc.image = dt2.Rows[i]["image"].ToString();
                        }
                        else
                        {
                            //hc.image = websitepath + "Resources/Images/Default2.jpg";
                            hc.image = "Resources/Images/Default2.jpg";
                        }

                        list.Add(hc);

                    }
                    GeneralDataItem data = new GeneralDataItem();
                    data.MESSAGE = "Successfully !";
                    data.ORIGINAL_ERROR = "";
                    string today = DateTime.Now.ToString("dd-MM-yyyy");
                    data.Date = today;
                    data.ERROR_STATUS = false;
                    data.RECORDS = true;
                    data.Data = list;
                    g.Add(data);
                    Context.Response.Write(js.Serialize(g[0]));
                }
                else
                {
                    GeneralDataItem data = new GeneralDataItem();
                    data.MESSAGE = "Data Not Available";
                    data.ORIGINAL_ERROR = "";
                    data.ERROR_STATUS = false;
                    data.RECORDS = false;
                    g.Add(data);
                    Context.Response.Write(js.Serialize(g[0]));
                }
            }
            catch (Exception ex)
            {
                GeneralDataItem data = new GeneralDataItem();
                data.MESSAGE = "Failed";
                data.ORIGINAL_ERROR = ex.Message;
                data.ERROR_STATUS = true;
                data.RECORDS = false;
                g.Add(data);
                Context.Response.Write(js.Serialize(g[0]));
            }
        }
    }
    [WebMethod]

    public void GetCartItems(string type)
    {
        string Ipadd = string.Empty;
        if (HttpContext.Current.Request.ServerVariables["HTTP_X__FORWARDER_FOR"] != null)
        {

            Ipadd = HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDER_FOR"].ToString();
        }
        else if (HttpContext.Current.Request.UserHostAddress.Length != 0)
        {
            Ipadd = HttpContext.Current.Request.UserHostAddress;
        }

        JavaScriptSerializer js = new JavaScriptSerializer();
        int i = 0;
        string qry = "";
        string qry2 = "";
        
        List<ItemMaster> list = new List<ItemMaster>();
        List<GeneralDataItem> g = new List<GeneralDataItem>();
        if (type == "item")
        {
            try
            {
                qry = "select ItemMaster.Engname,ItemMaster.Image,Cart.* from ItemMaster Right Join Cart ON ItemMaster.Id = Cart.Iid where ipaddress='" + Ipadd + "'";
                    //qry = "select * from Cart";

                DataTable dt = D.GetDataTable("SELECT SUM(Rate) AS Total FROM Cart where ipaddress='" + Ipadd + "'");        
                
                //total = Convert.ToDouble(dt.Rows[i]["Total"].ToString());    
                
                    DataTable dt2 = D.GetDataTable(qry);
                   
                    if (dt2.Rows.Count != 0)
                    {
                        
                        for (i = 0; i <= dt2.Rows.Count - 1; i++)
                        {
                            ItemMaster hc = new ItemMaster();
                            
                            hc.price = Convert.ToDouble(dt2.Rows[i]["Rate"].ToString());
                            hc.id = dt2.Rows[i]["Id"].ToString();
                            hc.name = dt2.Rows[i]["EngName"].ToString();
                            hc.image = dt2.Rows[i]["Image"].ToString();
                            hc.unit = dt2.Rows[i]["Unit"].ToString();
                            hc.Qty = dt2.Rows[i]["Quantity"].ToString();
                            //hc.pick = dt2.Rows[i]["Pick"].ToString();
                            hc.total = Convert.ToDouble(dt.Rows[0]["Total"].ToString());
                            hc.Amount = Convert.ToDouble(dt2.Rows[i]["Rate"].ToString());
                            //total = total + hc.price;
                            //hc.total = total;

                            list.Add(hc);

                        }
                        GeneralDataItem data = new GeneralDataItem();
                        data.MESSAGE = "Successfully !";
                        data.ORIGINAL_ERROR = "";
                        string today = DateTime.Now.ToString("dd-MM-yyyy");
                        data.Date = today;
                        //data.Data = total;
                        data.ERROR_STATUS = false;
                        data.RECORDS = true;
                        data.Data = list;
                        g.Add(data);
                        Context.Response.Write(js.Serialize(g[0]));
                    }
                    else
                    {
                        GeneralDataItem data = new GeneralDataItem();
                        data.MESSAGE = "Data Not Available";
                        data.ORIGINAL_ERROR = "";
                        data.ERROR_STATUS = false;
                        data.RECORDS = false;
                        g.Add(data);
                        Context.Response.Write(js.Serialize(g[0]));
                    }
                    
                
            }
            catch (Exception ex)
            {
                GeneralDataItem data = new GeneralDataItem();
                data.MESSAGE = "Failed";
                data.ORIGINAL_ERROR = ex.Message;
                data.ERROR_STATUS = true;
                data.RECORDS = false;
                g.Add(data);
                Context.Response.Write(js.Serialize(g[0]));
            }
        }
    }
    [WebMethod]
    public void GetItemDataforWeb3(string type)
    {
        JavaScriptSerializer js = new JavaScriptSerializer();
        
        int i = 0;
        
        string qry = "";
        List<ItemMaster> list = new List<ItemMaster>();
        List<GeneralDataItem> g = new List<GeneralDataItem>();
        if (type == "item")
        {
            try
            {
                qry = "select ItemMaster.EngName,ItemMaster.Image,ItemMaster.RetailKgPrice,ItemMaster.RetailPcsPrice,Bestseller.* from ItemMaster right join Bestseller ON ItemMaster.Id = Bestseller.Iid";

                DataTable dt2 = D.GetDataTable(qry);
                if (dt2.Rows.Count != 0)
                {
                    for (i = 0; i <= dt2.Rows.Count - 1; i++)
                    {
                        ItemMaster hc = new ItemMaster();
                        hc.id = dt2.Rows[i]["Iid"].ToString();
                        hc.name = dt2.Rows[i]["EngName"].ToString();
                        if (dt2.Rows[i]["RetailKgPrice"].ToString() == "0.00")
                        {
                            hc.inkg = "0";
                        }
                        else
                        {
                            hc.inkg = "1";
                        }
                        if (dt2.Rows[i]["RetailPcsPrice"].ToString() == "0.00")
                        {
                            hc.inpcs = "0";
                        }
                        else
                        {
                            hc.inpcs = "1";
                        }
                        hc.kgprice = Convert.ToDouble(dt2.Rows[i]["RetailKgPrice"].ToString());
                        hc.pcsprice = Convert.ToDouble(dt2.Rows[i]["RetailPcsPrice"].ToString());
                        if (dt2.Rows[i]["Image"].ToString() != "")
                        {
                            //hc.image = websitepath + dt2.Rows[i]["image"].ToString();
                            hc.image = dt2.Rows[i]["Image"].ToString();
                        }
                        else
                        {
                            //hc.image = websitepath + "Resources/Images/Default2.jpg";
                            hc.image = "Resources/Images/Default2.jpg";
                        }

                        list.Add(hc);

                    }
                    GeneralDataItem data = new GeneralDataItem();
                    data.MESSAGE = "Successfully !";
                    data.ORIGINAL_ERROR = "";
                    string today = DateTime.Now.ToString("dd-MM-yyyy");
                    data.Date = today;
                    data.ERROR_STATUS = false;
                    data.RECORDS = true;
                    data.Data = list;
                    g.Add(data);
                    Context.Response.Write(js.Serialize(g[0]));
                }
                else
                {
                    GeneralDataItem data = new GeneralDataItem();
                    data.MESSAGE = "Data Not Available";
                    data.ORIGINAL_ERROR = "";
                    data.ERROR_STATUS = false;
                    data.RECORDS = false;
                    g.Add(data);
                    Context.Response.Write(js.Serialize(g[0]));
                }
            }
            catch (Exception ex)
            {
                GeneralDataItem data = new GeneralDataItem();
                data.MESSAGE = "Failed";
                data.ORIGINAL_ERROR = ex.Message;
                data.ERROR_STATUS = true;
                data.RECORDS = false;
                g.Add(data);
                Context.Response.Write(js.Serialize(g[0]));
            }
        }
    }

    [WebMethod]
    public void InsertFCMToken(string type, string fcmtoken, string userid)
    {
        JavaScriptSerializer js = new JavaScriptSerializer();
        List<GeneralData> g = new List<GeneralData>();
        if (type == "fcmtoken")
        {
            try
            {


                //fcmtoken = HttpUtility.UrlDecode(fcmtoken);

                cc.ExecuteQuery("Update ClientMaster set FcmToken = '" + fcmtoken + "' where Id = '" + userid + "'");
                GeneralData data = new GeneralData();
                data.MESSAGE = "Successfully !";
                data.ORIGINAL_ERROR = "";
                data.ERROR_STATUS = false;
                data.RECORDS = true;

                g.Add(data);
                Context.Response.Write(js.Serialize(g[0]));
            }
            catch (Exception ex)
            {
                GeneralData data = new GeneralData();
                data.MESSAGE = "Failed";
                data.ORIGINAL_ERROR = ex.Message;
                data.ERROR_STATUS = true;
                data.RECORDS = false;
                g.Add(data);
                Context.Response.Write(js.Serialize(g[0]));
            }

        }
    }

    [WebMethod]
    public void ForgotPassword(string type, string email)
    {
        JavaScriptSerializer js = new JavaScriptSerializer();
        List<GeneralData> g = new List<GeneralData>();
        string res = "";
        if (type == "forgotpassword")
        {
            try
            {
                //Check user mobile exist or not
                string query = "select * from ClientMaster where email='" + email + "'";
                DataTable dt = cc.GetData(query);
                if (dt.Rows.Count != 0)
                {

                    string password = "";
                    //Check password empty or not.If password empty new generate and send to user
                    if (dt.Rows[0]["Password"] == "")
                    {
                        Random rng = new Random();
                        // Assume there'd be more logic here really
                        int random_password = rng.Next(1000, 9999);
                        password = random_password.ToString();
                        query = "update ClientMaster set Password='" + password + "' where email='" + email + "'";
                        cc.ExecuteQuery(query);
                    }
                    else
                    {
                        password = dt.Rows[0]["Password"].ToString();
                    }

                    SendSms sms = new SendSms();
                    res = sms.sendotp("Your  I learn app  password is :  " + password, dt.Rows[0]["Mobile"].ToString());
                    if (res.Equals("ok"))
                    {
                        GeneralData data = new GeneralData();
                        data.MESSAGE = "Successfully !";
                        data.ORIGINAL_ERROR = "";
                        data.ERROR_STATUS = false;
                        data.RECORDS = false;
                        g.Add(data);
                        Context.Response.Write(js.Serialize(g[0]));
                    }
                    else
                    {
                        GeneralData data = new GeneralData();
                        data.MESSAGE = "Failed";
                        data.ORIGINAL_ERROR = res;
                        data.ERROR_STATUS = true;
                        data.RECORDS = false;
                        g.Add(data);
                        Context.Response.Write(js.Serialize(g[0]));
                    }
                }
                else
                {
                    GeneralData data = new GeneralData();
                    data.MESSAGE = "Email id not exist";
                    data.ORIGINAL_ERROR = "";
                    data.ERROR_STATUS = true;
                    data.RECORDS = false;
                    g.Add(data);
                    Context.Response.Write(js.Serialize(g[0]));
                }
            }
            catch (Exception ex)
            {
                GeneralData data = new GeneralData();
                data.MESSAGE = "Failed";
                data.ORIGINAL_ERROR = ex.Message;
                data.ERROR_STATUS = true;
                data.RECORDS = false;
                g.Add(data);
                Context.Response.Write(js.Serialize(g[0]));
            }
        }
    }



    [WebMethod]
    public void VerificationService(string type, string code, string mobile)
    {
        JavaScriptSerializer js = new JavaScriptSerializer();
        List<GeneralData> g = new List<GeneralData>();
        string res = "";
        if (type == "verification")
        {
            try
            {
                SendSms sms = new SendSms();
                res = sms.sendotp("you Verification Code is " + code, mobile);

                if (res.Equals("ok"))
                {
                    GeneralData data = new GeneralData();
                    data.MESSAGE = "Successfully !";
                    data.ORIGINAL_ERROR = "";
                    data.ERROR_STATUS = false;
                    data.RECORDS = true;

                    g.Add(data);
                    Context.Response.Write(js.Serialize(g[0]));
                }
                else
                {
                    GeneralData data = new GeneralData();
                    data.MESSAGE = "Failed";
                    data.ORIGINAL_ERROR = res;
                    data.ERROR_STATUS = true;
                    data.RECORDS = false;
                    g.Add(data);
                    Context.Response.Write(js.Serialize(g[0]));
                }
            }
            catch (Exception ex)
            {
                GeneralData data = new GeneralData();
                data.MESSAGE = "Failed";
                data.ORIGINAL_ERROR = ex.Message;
                data.ERROR_STATUS = true;
                data.RECORDS = false;
                g.Add(data);
                Context.Response.Write(js.Serialize(g[0]));
            }
        }
    }

    [WebMethod]
    public void VerificationStatus(string type, string mobile)
    {
        JavaScriptSerializer js = new JavaScriptSerializer();
        List<GeneralData> g = new List<GeneralData>();
        if (type == "status")
        {
            try
            {
                //fcmtoken = HttpUtility.UrlDecode(fcmtoken);
                cc.ExecuteQuery("Update ClientMaster set VerificationStatus = '1' where Mobile = '" + mobile + "'");
                GeneralData data = new GeneralData();
                data.MESSAGE = "Successfully !";
                data.ORIGINAL_ERROR = "";
                data.ERROR_STATUS = false;
                data.RECORDS = true;

                g.Add(data);
                Context.Response.Write(js.Serialize(g[0]));
            }
            catch (Exception ex)
            {
                GeneralData data = new GeneralData();
                data.MESSAGE = "Failed";
                data.ORIGINAL_ERROR = ex.Message;
                data.ERROR_STATUS = true;
                data.RECORDS = false;
                g.Add(data);
                Context.Response.Write(js.Serialize(g[0]));
            }
        }
    }

    [WebMethod(Description = "Get States Data")]
    public void GetStatesData(string action)
    {
        JavaScriptSerializer js = new JavaScriptSerializer();
        List<GeneralDataState> g = new List<GeneralDataState>();
        if (action == "state")
        {
            int i = 0;
            DataTable dt = cc.GetData("select * from StateMaster");
            List<StateMaster> list = new List<StateMaster>();
            if (dt.Rows.Count > 0)
            {
                for (i = 0; i <= dt.Rows.Count - 1; i++)
                {
                    StateMaster state = new StateMaster();
                    state.stateid = dt.Rows[i]["stateid"].ToString();
                    state.name = dt.Rows[i]["name"].ToString();
                    state.type = dt.Rows[i]["type"].ToString();
                    list.Add(state);
                }
            }
            GeneralDataState data = new GeneralDataState();
            data.MESSAGE = "Successfull";
            data.ORIGINAL_ERROR = "";
            data.ERROR_STATUS = false;
            data.RECORDS = true;
            data.Data = list;
            g.Add(data);
            Context.Response.Write(js.Serialize(g[0]));
        }
    }

    [WebMethod(Description = "Get City Data By States")]
    public void GetCityData(string action, string stateid)
    {
        JavaScriptSerializer js = new JavaScriptSerializer();
        List<GeneralDataCity> g = new List<GeneralDataCity>();
        if (action == "city")
        {
            int i = 0;
            int sid = Convert.ToInt32(stateid);
            DataTable dt = cc.GetData("select * from CityMaster where stateid = " + stateid);
            List<CityMaster> list = new List<CityMaster>();
            if (dt.Rows.Count > 0)
            {
                for (i = 0; i <= dt.Rows.Count - 1; i++)
                {
                    CityMaster city = new CityMaster();
                    city.id = dt.Rows[i]["ID"].ToString();
                    city.city = dt.Rows[i]["city"].ToString();
                    city.stateid = dt.Rows[i]["stateid"].ToString();
                    list.Add(city);
                }
                GeneralDataCity data = new GeneralDataCity();
                data.MESSAGE = "Successfull";
                data.ORIGINAL_ERROR = "";
                data.ERROR_STATUS = false;
                data.RECORDS = true;
                data.Data = list;
                g.Add(data);
                Context.Response.Write(js.Serialize(g[0]));

            }
            else
            {
                GeneralDataCity data = new GeneralDataCity();
                data.MESSAGE = "Recored Not Found";
                data.ORIGINAL_ERROR = "";
                data.ERROR_STATUS = false;
                data.RECORDS = false;
                g.Add(data);
                Context.Response.Write(js.Serialize(g[0]));
            }
        }
    }
    [WebMethod]
    public void InsertClient(string type, string name, string email, string password, string mobile, string stateid, string cityid)
    {
        JavaScriptSerializer js = new JavaScriptSerializer();

        List<GeneralData> g = new List<GeneralData>();

        try
        {
            DataTable dt = cc.GetData("select * from ClientMaster where Mobile = '" + mobile + "'");
            if (dt.Rows.Count == 0)
            {
                DataTable dt2 = cc.GetData("select * from ClientMaster where Email = '" + email + "'");
                if (dt2.Rows.Count == 0)
                {
                    name = HttpUtility.UrlDecode(name);
                    email = HttpUtility.UrlDecode(email);
                    password = HttpUtility.UrlDecode(password);

                    cc.ExecuteQuery("insert into ClientMaster (Name,Email,Password,Mobile,StateId,CityId,VerificationStatus,logintype) values('" + name + "','" + email + "','" + password + "','" + mobile + "','" + stateid + "','" + cityid + "','0','0')");
                    GeneralData data = new GeneralData();
                    data.MESSAGE = "Successfully !";
                    data.ORIGINAL_ERROR = "";
                    data.ERROR_STATUS = false;
                    data.RECORDS = true;

                    g.Add(data);
                    Context.Response.Write(js.Serialize(g[0]));
                }
                else
                {
                    GeneralData data = new GeneralData();
                    data.MESSAGE = "Email Already Exists ";
                    data.ORIGINAL_ERROR = "";
                    data.ERROR_STATUS = true;
                    data.RECORDS = false;
                    g.Add(data);
                    Context.Response.Write(js.Serialize(g[0]));
                }
            }
            else
            {
                GeneralData data = new GeneralData();
                data.MESSAGE = "Mobile No Already Exists";
                data.ORIGINAL_ERROR = "";
                data.ERROR_STATUS = true;
                data.RECORDS = false;
                g.Add(data);
                Context.Response.Write(js.Serialize(g[0]));
            }


        }
        catch (Exception ex)
        {
            GeneralData data = new GeneralData();
            data.MESSAGE = "Failed";
            data.ORIGINAL_ERROR = ex.Message;
            data.ERROR_STATUS = true;
            data.RECORDS = false;
            g.Add(data);
            Context.Response.Write(js.Serialize(g[0]));
        }

    }
    [WebMethod]
    public void FBGmailService(string type, string name, string email)
    {
        name = HttpUtility.UrlDecode(name);
        email = HttpUtility.UrlDecode(email);
        JavaScriptSerializer js = new JavaScriptSerializer();
        List<UserMaster> list = new List<UserMaster>();
        List<GeneralDataUser> g2 = new List<GeneralDataUser>();
        if (type == "fbgmail")
        {
            DataTable dt2 = cc.GetData("select * from ClientMaster where Email = '" + email + "'");
            if (dt2.Rows.Count != 0)
            {
                for (int i = 0; i <= dt2.Rows.Count - 1; i++)
                {
                    UserMaster hc = new UserMaster();


                    hc.clientid = dt2.Rows[i]["Id"].ToString();
                    hc.name = dt2.Rows[i]["Name"].ToString();
                    hc.mobile = dt2.Rows[i]["Mobile"].ToString();
                    hc.email = dt2.Rows[i]["Email"].ToString();
                    hc.logintype = dt2.Rows[i]["logintype"].ToString();
                    hc.verificationstatus = dt2.Rows[i]["VerificationStatus"].ToString();
                    list.Add(hc);

                }
                GeneralDataUser data = new GeneralDataUser();
                data.MESSAGE = "Successfully Login !";
                data.ORIGINAL_ERROR = "";
                data.ERROR_STATUS = false;
                data.RECORDS = true;
                data.Data = list;
                g2.Add(data);
                Context.Response.Write(js.Serialize(g2[0]));
            }
            else
            {
                cc.ExecuteQuery("insert into ClientMaster (Name,Email,VerificationStatus,logintype) values('" + name + "','" + email + "','0','0')");
                DataTable dt = cc.GetData("select * from ClientMaster where Email = '" + email + "'");

                for (int i = 0; i <= dt.Rows.Count - 1; i++)
                {
                    UserMaster hc = new UserMaster();


                    hc.clientid = dt.Rows[i]["Id"].ToString();
                    hc.name = dt.Rows[i]["Name"].ToString();
                    hc.mobile = dt.Rows[i]["Mobile"].ToString();
                    hc.email = dt.Rows[i]["Email"].ToString();
                    hc.logintype = dt2.Rows[i]["logintype"].ToString();
                    hc.verificationstatus = dt.Rows[i]["VerificationStatus"].ToString();
                    list.Add(hc);

                }
                GeneralDataUser data = new GeneralDataUser();
                data.MESSAGE = "Successfully Login !";
                data.ORIGINAL_ERROR = "";
                data.ERROR_STATUS = false;
                data.RECORDS = true;
                data.Data = list;
                g2.Add(data);
                Context.Response.Write(js.Serialize(g2[0]));
            }


        }
    }

    [WebMethod]
    public void UpdateMobile(string type, string clientid, string mobile)
    {
        JavaScriptSerializer js = new JavaScriptSerializer();
        List<UserMaster> list = new List<UserMaster>();
        List<GeneralDataUser> g = new List<GeneralDataUser>();
        if (type == "updatemobile")
        {
            try
            {
                DataTable dt = cc.GetData("select * from ClientMaster where Mobile = '" + mobile + "'");
                if (dt.Rows.Count == 0)
                {
                    cc.ExecuteQuery("update ClientMaster set Mobile = '" + mobile + "' where id =" + clientid);
                    DataTable dt2 = cc.GetData("select * from ClientMaster where id = '" + clientid + "'");

                    for (int i = 0; i <= dt2.Rows.Count - 1; i++)
                    {
                        UserMaster hc = new UserMaster();


                        hc.clientid = dt2.Rows[i]["Id"].ToString();
                        hc.name = dt2.Rows[i]["Name"].ToString();
                        hc.mobile = dt2.Rows[i]["Mobile"].ToString();
                        hc.email = dt2.Rows[i]["Email"].ToString();
                        hc.logintype = dt2.Rows[i]["logintype"].ToString();
                        hc.verificationstatus = dt2.Rows[i]["VerificationStatus"].ToString();
                        list.Add(hc);

                    }
                    GeneralDataUser data = new GeneralDataUser();
                    data.MESSAGE = "Successfully !";
                    data.ORIGINAL_ERROR = "";
                    data.ERROR_STATUS = false;
                    data.RECORDS = true;
                    data.Data = list;
                    g.Add(data);
                    Context.Response.Write(js.Serialize(g[0]));

                }
                else
                {
                    GeneralDataUser data = new GeneralDataUser();
                    data.MESSAGE = "Mobile No Already Existsin ";
                    data.ORIGINAL_ERROR = "";
                    data.ERROR_STATUS = true;
                    data.RECORDS = false;
                    g.Add(data);
                    Context.Response.Write(js.Serialize(g[0]));
                }


            }
            catch (Exception ex)
            {
                GeneralDataUser data = new GeneralDataUser();
                data.MESSAGE = "Failed";
                data.ORIGINAL_ERROR = ex.Message;
                data.ERROR_STATUS = true;
                data.RECORDS = false;
                g.Add(data);
                Context.Response.Write(js.Serialize(g[0]));
            }
        }

    }

    [WebMethod]
    public void InsertSchool(string type, string schoolname, string address, string email, string password, string principlename, string mobile, string stateid, string cityid, string noofstudent)
    {
        JavaScriptSerializer js = new JavaScriptSerializer();
        List<GeneralData> g = new List<GeneralData>();
        if (type == "school")
        {

            try
            {
                DataTable dt = cc.GetData("select * from SchoolMaster where Mobile = '" + mobile + "'");
                if (dt.Rows.Count == 0)
                {
                    DataTable dt2 = cc.GetData("select * from SchoolMaster where Email = '" + email + "'");
                    if (dt2.Rows.Count == 0)
                    {
                        schoolname = HttpUtility.UrlDecode(schoolname);
                        address = HttpUtility.UrlDecode(address);
                        principlename = HttpUtility.UrlDecode(principlename);
                        email = HttpUtility.UrlDecode(email);
                        password = HttpUtility.UrlDecode(password);

                        cc.ExecuteQuery("insert into SchoolMaster (SchoolName,Address,Email,Password,StateId,CityId,PrincipleName,Mobile,NoOfStudent,VerificationStatus) values('" + schoolname + "','" + address + "','" + email + "','" + password + "','" + stateid + "','" + cityid + "','" + principlename + "','" + mobile + "','" + noofstudent + "','0')");
                        GeneralData data = new GeneralData();
                        data.MESSAGE = "Successfully !";
                        data.ORIGINAL_ERROR = "";
                        data.ERROR_STATUS = false;
                        data.RECORDS = true;

                        g.Add(data);
                        Context.Response.Write(js.Serialize(g[0]));
                    }
                    else
                    {
                        GeneralData data = new GeneralData();
                        data.MESSAGE = "Email Already Exists";
                        data.ORIGINAL_ERROR = "";
                        data.ERROR_STATUS = true;
                        data.RECORDS = false;
                        g.Add(data);
                        Context.Response.Write(js.Serialize(g[0]));
                    }
                }
                else
                {
                    GeneralData data = new GeneralData();
                    data.MESSAGE = "Mobile No Already Exists";
                    data.ORIGINAL_ERROR = "";
                    data.ERROR_STATUS = true;
                    data.RECORDS = false;
                    g.Add(data);
                    Context.Response.Write(js.Serialize(g[0]));
                }


            }
            catch (Exception ex)
            {
                GeneralData data = new GeneralData();
                data.MESSAGE = "Failed";
                data.ORIGINAL_ERROR = ex.Message;
                data.ERROR_STATUS = true;
                data.RECORDS = false;
                g.Add(data);
                Context.Response.Write(js.Serialize(g[0]));
            }
        }
    }


    [WebMethod]
    public void GetTourData(string type)
    {
        JavaScriptSerializer js = new JavaScriptSerializer();
        List<GeneralDataTour> g = new List<GeneralDataTour>();
        if (type == "tour")
        {
            try
            {
                int i = 0;
                DataTable dt = cc.GetData("select * from [dbo].[TourMaster]");
                List<Tour> list = new List<Tour>();
                if (dt.Rows.Count > 0)
                {
                    for (i = 0; i <= dt.Rows.Count - 1; i++)
                    {
                        Tour tr = new Tour();
                        tr.visiontitle = dt.Rows[i]["VisionTitle"].ToString();
                        tr.visiondesc = dt.Rows[i]["VisionDesc"].ToString();
                        tr.schooltitle = dt.Rows[i]["SchoolTitle"].ToString();
                        tr.schooldesc = dt.Rows[i]["SchoolDesc"].ToString();
                        tr.prospecttitle = dt.Rows[i]["ProspectTitle"].ToString();
                        tr.prospectdesc = dt.Rows[i]["ProspectDesc"].ToString();

                        list.Add(tr);
                    }
                    GeneralDataTour data = new GeneralDataTour();
                    data.MESSAGE = "Successfull";
                    data.ORIGINAL_ERROR = "";
                    data.ERROR_STATUS = false;
                    data.RECORDS = true;
                    data.Data = list;
                    g.Add(data);
                    Context.Response.Write(js.Serialize(g[0]));
                }
                else
                {
                    GeneralDataTour data = new GeneralDataTour();
                    data.MESSAGE = "No Data Found";
                    data.ORIGINAL_ERROR = "";
                    data.ERROR_STATUS = false;
                    data.RECORDS = false;
                    g.Add(data);
                    Context.Response.Write(js.Serialize(g[0]));
                }

            }
            catch (Exception ex)
            {
                GeneralDataTour data = new GeneralDataTour();
                data.MESSAGE = "Failed";
                data.ORIGINAL_ERROR = ex.Message;
                data.ERROR_STATUS = true;
                data.RECORDS = false;
                g.Add(data);
                Context.Response.Write(js.Serialize(g[0]));
            }

        }
    }

    [WebMethod]
    public void GetStoriesData(string type, string catid, string userid)
    {
        JavaScriptSerializer js = new JavaScriptSerializer();
        List<GeneralDataStory> g = new List<GeneralDataStory>();
        if (type == "story")
        {
            try
            {
                int i = 0;
                //DataTable dt = cc.GetData("select * from [dbo].[StoriesMaster]");
                DataTable dt = cc.GetData("select sm.*, CASE WHEN fm.Id IS NULL THEN '0' ELSE '1' END as IS_FAVOURITE from StoriesMaster as sm left outer join FavouriteMaster as fm on fm.ItemId=sm.Id and fm.CategoryId='" + catid + "' and fm.Userid='" + userid + "'");
                List<Story> list = new List<Story>();
                if (dt.Rows.Count > 0)
                {
                    for (i = 0; i <= dt.Rows.Count - 1; i++)
                    {
                        Story tr = new Story();
                        tr.storyid = dt.Rows[i]["Id"].ToString();
                        tr.Title = dt.Rows[i]["Title"].ToString();
                        tr.favourite = dt.Rows[i]["IS_FAVOURITE"].ToString();
                        string story = dt.Rows[i]["Description"].ToString();

                        //Regex re = new Regex("[\r\n;\\/:*\"<>|\n',(-)]");
                        //string ques = story
                        //    .Replace("\n", " ")
                        //    .Replace(".", "")
                        //    .Replace(@"\s+", " ")
                        //    .Replace(Environment.NewLine, " ")
                        //    .Replace("‘", "")
                        //    .Replace("’", "")
                        //    .Replace("`", "")
                        //    .Replace("\r", " ");

                        //ques = re.Replace(ques, " ");


                        ////ques = Regex.Replace(ques, "'", "dns");
                        //string qu = WebUtility.HtmlEncode(ques);

                        tr.storydesc = story;
                        if (dt.Rows[i]["img"].ToString() != "")
                        {
                            tr.image = "http://inceptionlearning.com/A" + dt.Rows[i]["img"].ToString();
                        }
                        else
                        {
                            tr.image = "";
                        }
                        tr.link = dt.Rows[i]["link"].ToString();

                        list.Add(tr);
                    }
                    GeneralDataStory data = new GeneralDataStory();
                    data.MESSAGE = "Successfull";
                    data.ORIGINAL_ERROR = "";
                    data.ERROR_STATUS = false;
                    data.RECORDS = true;
                    data.Data = list;
                    g.Add(data);
                    Context.Response.Write(js.Serialize(g[0]));
                }
                else
                {
                    GeneralDataStory data = new GeneralDataStory();
                    data.MESSAGE = "No Data Found";
                    data.ORIGINAL_ERROR = "";
                    data.ERROR_STATUS = false;
                    data.RECORDS = false;
                    g.Add(data);
                    Context.Response.Write(js.Serialize(g[0]));
                }

            }
            catch (Exception ex)
            {
                GeneralDataStory data = new GeneralDataStory();
                data.MESSAGE = "Failed";
                data.ORIGINAL_ERROR = ex.Message;
                data.ERROR_STATUS = true;
                data.RECORDS = false;
                g.Add(data);
                Context.Response.Write(js.Serialize(g[0]));
            }

        }
    }

    [WebMethod]
    public void GetVideoData(string type, string categoryid, string catid, string userid)
    {
        JavaScriptSerializer js = new JavaScriptSerializer();
        List<GeneralDataVideo> g = new List<GeneralDataVideo>();
        if (type == "video")
        {
            try
            {
                int i = 0;
                DataTable dt = cc.GetData("select sm.*,vc.Category, CASE WHEN fm.Id IS NULL THEN '0' ELSE '1' END as IS_FAVOURITE from [VideoCategoryMaster] as vc, VideoMaster as sm left outer join FavouriteMaster as fm on fm.ItemId=sm.Id and  sm.vcid =" + categoryid + " and fm.CategoryId=" + catid + " and fm.Userid=" + userid + " where sm.vcid = " + categoryid + " and sm.vcid = vc.id");
                //DataTable dt = cc.GetData("select sm.*,CASE WHEN fm.Id IS NULL THEN '0' ELSE '1' END as IS_FAVOURITE ,v.*,vc.Category from StoriesMaster as sm left outer join FavouriteMaster as fm on fm.ItemId=sm.Id, VideoMaster as v ,VideoCategoryMaster as vc where v.vcid = vc.id and v.vcid ='" + categoryid + "' OR fm.CategoryId='" + catid + "' and fm.Userid='" + userid + "'");
                //DataTable dt = cc.GetData("select sm.*,CASE WHEN fm.Id IS NULL THEN '0' ELSE '1' END as IS_FAVOURITE ,v.*,vc.Category from StoriesMaster as sm left outer join FavouriteMaster as fm on fm.ItemId=sm.Id, VideoMaster as v , VideoCategoryMaster as vc where v.vcid = vc.id and v.vcid ='" + categoryid + "' and fm.CategoryId='" + catid + "' and fm.Userid='" + userid + "'");
                //DataTable dt = cc.GetData("select v.*,vc.Category from  VideoMaster as v ,[VideoCategoryMaster] as vc where v.vcid = vc.id and v.vcid = " + categoryid);
                List<Video> list = new List<Video>();
                if (dt.Rows.Count > 0)
                {
                    for (i = 0; i <= dt.Rows.Count - 1; i++)
                    {
                        Video tr = new Video();
                        tr.videoid = dt.Rows[i]["Id"].ToString();
                        tr.categoryid = dt.Rows[i]["vcid"].ToString();
                        tr.categoryname = dt.Rows[i]["Category"].ToString();
                        tr.videotitle = dt.Rows[i]["Title"].ToString();
                        tr.videourl = dt.Rows[i]["Url"].ToString();
                        tr.favourite = dt.Rows[i]["IS_FAVOURITE"].ToString();
                        list.Add(tr);
                    }
                    GeneralDataVideo data = new GeneralDataVideo();
                    data.MESSAGE = "Successfull";
                    data.ORIGINAL_ERROR = "";
                    data.ERROR_STATUS = false;
                    data.RECORDS = true;
                    data.Data = list;
                    g.Add(data);
                    Context.Response.Write(js.Serialize(g[0]));
                }
                else
                {
                    GeneralDataVideo data = new GeneralDataVideo();
                    data.MESSAGE = "No Data Found";
                    data.ORIGINAL_ERROR = "";
                    data.ERROR_STATUS = false;
                    data.RECORDS = false;
                    g.Add(data);
                    Context.Response.Write(js.Serialize(g[0]));
                }

            }
            catch (Exception ex)
            {
                GeneralDataVideo data = new GeneralDataVideo();
                data.MESSAGE = "Failed";
                data.ORIGINAL_ERROR = ex.Message;
                data.ERROR_STATUS = true;
                data.RECORDS = false;
                g.Add(data);
                Context.Response.Write(js.Serialize(g[0]));
            }

        }
    }

    [WebMethod]
    public void GetVideoCategoryData(string type)
    {
        JavaScriptSerializer js = new JavaScriptSerializer();
        List<GeneralDataVideoCategory> g = new List<GeneralDataVideoCategory>();
        if (type == "videocategory")
        {
            try
            {
                int i = 0;
                DataTable dt = cc.GetData("select * from [dbo].[VideoCategoryMaster]");
                List<VideoCategory> list = new List<VideoCategory>();
                if (dt.Rows.Count > 0)
                {
                    for (i = 0; i <= dt.Rows.Count - 1; i++)
                    {
                        VideoCategory tr = new VideoCategory();

                        tr.categoryid = dt.Rows[i]["id"].ToString();
                        tr.categoryname = dt.Rows[i]["Category"].ToString();
                        if (dt.Rows[i]["img"].ToString() != "")
                        {
                            tr.categoryimg = "http://inceptionlearning.com/A" + dt.Rows[i]["img"].ToString();
                        }
                        else
                        {
                            tr.categoryimg = "";
                        }
                        list.Add(tr);
                    }
                    GeneralDataVideoCategory data = new GeneralDataVideoCategory();
                    data.MESSAGE = "Successfull";
                    data.ORIGINAL_ERROR = "";
                    data.ERROR_STATUS = false;
                    data.RECORDS = true;
                    data.Data = list;
                    g.Add(data);
                    Context.Response.Write(js.Serialize(g[0]));
                }
                else
                {
                    GeneralDataVideoCategory data = new GeneralDataVideoCategory();
                    data.MESSAGE = "No Data Found";
                    data.ORIGINAL_ERROR = "";
                    data.ERROR_STATUS = false;
                    data.RECORDS = false;
                    g.Add(data);
                    Context.Response.Write(js.Serialize(g[0]));
                }

            }
            catch (Exception ex)
            {
                GeneralDataVideoCategory data = new GeneralDataVideoCategory();
                data.MESSAGE = "Failed";
                data.ORIGINAL_ERROR = ex.Message;
                data.ERROR_STATUS = true;
                data.RECORDS = false;
                g.Add(data);
                Context.Response.Write(js.Serialize(g[0]));
            }

        }
    }
    [WebMethod]
    public void GetQuotesData(string type, string catid, string userid)
    {
        JavaScriptSerializer js = new JavaScriptSerializer();
        List<GeneralDataQuotes> g = new List<GeneralDataQuotes>();
        if (type == "quotes")
        {
            try
            {
                int i = 0;
                DataTable dt = cc.GetData("select sm.*, CASE WHEN fm.Id IS NULL THEN '0' ELSE '1' END as IS_FAVOURITE from Quotes as sm left outer join FavouriteMaster as fm on fm.ItemId=sm.Id and fm.CategoryId='" + catid + "' and fm.Userid='" + userid + "'");
                //DataTable dt = cc.GetData("select * from [dbo].[Quotes]");
                List<Quotes> list = new List<Quotes>();
                if (dt.Rows.Count > 0)
                {
                    for (i = 0; i <= dt.Rows.Count - 1; i++)
                    {
                        Quotes tr = new Quotes();

                        tr.quotesid = dt.Rows[i]["id"].ToString();
                        tr.title = dt.Rows[i]["title"].ToString();
                        tr.favourite = dt.Rows[i]["IS_FAVOURITE"].ToString();
                        if (dt.Rows[i]["img"].ToString() != "")
                        {
                            tr.img = "http://inceptionlearning.com/A" + dt.Rows[i]["img"].ToString();
                        }
                        else
                        {
                            tr.img = "";
                        }
                        //tr.img = dt.Rows[i]["Category"].ToString();
                        list.Add(tr);
                    }
                    GeneralDataQuotes data = new GeneralDataQuotes();
                    data.MESSAGE = "Successfull";
                    data.ORIGINAL_ERROR = "";
                    data.ERROR_STATUS = false;
                    data.RECORDS = true;
                    data.Data = list;
                    g.Add(data);
                    Context.Response.Write(js.Serialize(g[0]));
                }
                else
                {
                    GeneralDataQuotes data = new GeneralDataQuotes();
                    data.MESSAGE = "No Data Found";
                    data.ORIGINAL_ERROR = "";
                    data.ERROR_STATUS = false;
                    data.RECORDS = false;
                    g.Add(data);
                    Context.Response.Write(js.Serialize(g[0]));
                }

            }
            catch (Exception ex)
            {
                GeneralDataQuotes data = new GeneralDataQuotes();
                data.MESSAGE = "Failed";
                data.ORIGINAL_ERROR = ex.Message;
                data.ERROR_STATUS = true;
                data.RECORDS = false;
                g.Add(data);
                Context.Response.Write(js.Serialize(g[0]));
            }

        }
    }

    [WebMethod]
    public void GetAboutUsData(string type)
    {
        JavaScriptSerializer js = new JavaScriptSerializer();
        List<GeneralDataaboutus> g = new List<GeneralDataaboutus>();
        if (type == "aboutus")
        {
            try
            {
                int i = 0;
                DataTable dt = cc.GetData("select * from [dbo].[AboutUs]");
                List<aboutus> list = new List<aboutus>();
                if (dt.Rows.Count > 0)
                {
                    for (i = 0; i <= dt.Rows.Count - 1; i++)
                    {
                        aboutus tr = new aboutus();

                        tr.mission = dt.Rows[i]["Mission"].ToString();
                        tr.vision = dt.Rows[i]["Vision"].ToString();
                        tr.expertise = dt.Rows[i]["Expertise"].ToString();
                        //tr.img = dt.Rows[i]["Category"].ToString();
                        list.Add(tr);
                    }
                    GeneralDataaboutus data = new GeneralDataaboutus();
                    data.MESSAGE = "Successfull";
                    data.ORIGINAL_ERROR = "";
                    data.ERROR_STATUS = false;
                    data.RECORDS = true;
                    data.Data = list;
                    g.Add(data);
                    Context.Response.Write(js.Serialize(g[0]));
                }
                else
                {
                    GeneralDataaboutus data = new GeneralDataaboutus();
                    data.MESSAGE = "No Data Found";
                    data.ORIGINAL_ERROR = "";
                    data.ERROR_STATUS = false;
                    data.RECORDS = false;
                    g.Add(data);
                    Context.Response.Write(js.Serialize(g[0]));
                }

            }
            catch (Exception ex)
            {
                GeneralDataaboutus data = new GeneralDataaboutus();
                data.MESSAGE = "Failed";
                data.ORIGINAL_ERROR = ex.Message;
                data.ERROR_STATUS = true;
                data.RECORDS = false;
                g.Add(data);
                Context.Response.Write(js.Serialize(g[0]));
            }

        }
    }

    [WebMethod]
    public void GetContactUsData(string type)
    {
        JavaScriptSerializer js = new JavaScriptSerializer();
        List<GeneralDataContactUs> g = new List<GeneralDataContactUs>();
        if (type == "contactus")
        {
            try
            {
                int i = 0;
                DataTable dt = cc.GetData("select * from [dbo].[ContactUs]");
                List<ContactUs> list = new List<ContactUs>();
                if (dt.Rows.Count > 0)
                {
                    for (i = 0; i <= dt.Rows.Count - 1; i++)
                    {
                        ContactUs tr = new ContactUs();

                        tr.Address = dt.Rows[i]["Address"].ToString();
                        DataTable dt2 = cc.GetData("select * from [dbo].[ContactUsNumbers]");
                        List<ContactUsNumber> list2 = new List<ContactUsNumber>();
                        if (dt2.Rows.Count > 0)
                        {
                            for (int j = 0; j <= dt2.Rows.Count - 1; j++)
                            {
                                ContactUsNumber cu = new ContactUsNumber();

                                cu.Id = dt2.Rows[j]["id"].ToString();
                                cu.Name = dt2.Rows[j]["name"].ToString();
                                cu.No = dt2.Rows[j]["mobile"].ToString();
                                list2.Add(cu);
                            }
                        }
                        tr.Numbers = list2;
                        //tr.img = dt.Rows[i]["Category"].ToString();
                        list.Add(tr);
                    }
                    GeneralDataContactUs data = new GeneralDataContactUs();
                    data.MESSAGE = "Successfull";
                    data.ORIGINAL_ERROR = "";
                    data.ERROR_STATUS = false;
                    data.RECORDS = true;
                    data.Data = list;
                    g.Add(data);
                    Context.Response.Write(js.Serialize(g[0]));
                }
                else
                {
                    GeneralDataContactUs data = new GeneralDataContactUs();
                    data.MESSAGE = "No Data Found";
                    data.ORIGINAL_ERROR = "";
                    data.ERROR_STATUS = false;
                    data.RECORDS = false;
                    g.Add(data);
                    Context.Response.Write(js.Serialize(g[0]));
                }

            }
            catch (Exception ex)
            {
                GeneralDataContactUs data = new GeneralDataContactUs();
                data.MESSAGE = "Failed";
                data.ORIGINAL_ERROR = ex.Message;
                data.ERROR_STATUS = true;
                data.RECORDS = false;
                g.Add(data);
                Context.Response.Write(js.Serialize(g[0]));
            }

        }
    }
    [WebMethod]
    public void InsertTopicData(string type, string clientid, string subname, string description)
    {
        JavaScriptSerializer js = new JavaScriptSerializer();
        List<GeneralData> g = new List<GeneralData>();
        if (type == "topic")
        {
            try
            {
                subname = HttpUtility.UrlDecode(subname);
                description = HttpUtility.UrlDecode(description);

                cc.ExecuteQuery("insert into Topic (userid,subname,description) values('" + clientid + "','" + subname + "','" + description + "')");
                GeneralData data = new GeneralData();
                data.MESSAGE = "Successfully !";
                data.ORIGINAL_ERROR = "";
                data.ERROR_STATUS = false;
                data.RECORDS = true;

                g.Add(data);
                Context.Response.Write(js.Serialize(g[0]));
            }
            catch (Exception ex)
            {
                GeneralData data = new GeneralData();
                data.MESSAGE = "Failed";
                data.ORIGINAL_ERROR = ex.Message;
                data.ERROR_STATUS = true;
                data.RECORDS = false;
                g.Add(data);
                Context.Response.Write(js.Serialize(g[0]));
            }
        }
    }
    [WebMethod]
    public void InsertFeedbackData(string type, string clientid, string ftype, string description)
    {
        JavaScriptSerializer js = new JavaScriptSerializer();
        List<GeneralData> g = new List<GeneralData>();
        if (type == "feedback")
        {
            try
            {
                description = HttpUtility.UrlDecode(description);

                cc.ExecuteQuery("insert into Feedback (userid,Type,description) values('" + clientid + "','" + ftype + "','" + description + "')");
                GeneralData data = new GeneralData();
                data.MESSAGE = "Successfully !";
                data.ORIGINAL_ERROR = "";
                data.ERROR_STATUS = false;
                data.RECORDS = true;

                g.Add(data);
                Context.Response.Write(js.Serialize(g[0]));
            }
            catch (Exception ex)
            {
                GeneralData data = new GeneralData();
                data.MESSAGE = "Failed";
                data.ORIGINAL_ERROR = ex.Message;
                data.ERROR_STATUS = true;
                data.RECORDS = false;
                g.Add(data);
                Context.Response.Write(js.Serialize(g[0]));
            }
        }
    }

    [WebMethod]
    public void GetAlbumData(string type)
    {
        JavaScriptSerializer js = new JavaScriptSerializer();
        List<GeneralDataAlbum> g = new List<GeneralDataAlbum>();
        if (type == "album")
        {
            try
            {
                int i = 0;
                DataTable dt = cc.GetData("select * from [dbo].[AlbumMaster]");
                List<Album> list = new List<Album>();
                if (dt.Rows.Count > 0)
                {
                    for (i = 0; i <= dt.Rows.Count - 1; i++)
                    {
                        Album tr = new Album();

                        tr.id = dt.Rows[i]["Id"].ToString();
                        tr.name = dt.Rows[i]["Name"].ToString();
                        if (dt.Rows[i]["img"].ToString() != "")
                        {
                            tr.image = "http://inceptionlearning.com/A" + dt.Rows[i]["img"].ToString();
                        }
                        else
                        {
                            tr.image = "";
                        }
                        //tr.img = dt.Rows[i]["Category"].ToString();
                        list.Add(tr);
                    }
                    GeneralDataAlbum data = new GeneralDataAlbum();
                    data.MESSAGE = "Successfull";
                    data.ORIGINAL_ERROR = "";
                    data.ERROR_STATUS = false;
                    data.RECORDS = true;
                    data.Data = list;
                    g.Add(data);
                    Context.Response.Write(js.Serialize(g[0]));
                }
                else
                {
                    GeneralDataAlbum data = new GeneralDataAlbum();
                    data.MESSAGE = "No Data Found";
                    data.ORIGINAL_ERROR = "";
                    data.ERROR_STATUS = false;
                    data.RECORDS = false;
                    g.Add(data);
                    Context.Response.Write(js.Serialize(g[0]));
                }

            }
            catch (Exception ex)
            {
                GeneralDataAlbum data = new GeneralDataAlbum();
                data.MESSAGE = "Failed";
                data.ORIGINAL_ERROR = ex.Message;
                data.ERROR_STATUS = true;
                data.RECORDS = false;
                g.Add(data);
                Context.Response.Write(js.Serialize(g[0]));
            }

        }
    }
    [WebMethod]
    public void GetSubAlbumData(string type, string albumid)
    {
        JavaScriptSerializer js = new JavaScriptSerializer();
        List<GeneralDataAlbum> g = new List<GeneralDataAlbum>();
        if (type == "subalbum")
        {
            try
            {
                int i = 0;
                DataTable dt = cc.GetData("select * from [dbo].[SubAlbum] where albumid = " + albumid);
                List<Album> list = new List<Album>();
                if (dt.Rows.Count > 0)
                {
                    for (i = 0; i <= dt.Rows.Count - 1; i++)
                    {
                        Album tr = new Album();

                        tr.id = dt.Rows[i]["Id"].ToString();
                        tr.name = dt.Rows[i]["Name"].ToString();
                        if (dt.Rows[i]["img"].ToString() != "")
                        {
                            tr.image = "http://inceptionlearning.com/A" + dt.Rows[i]["img"].ToString();
                        }
                        else
                        {
                            tr.image = "";
                        }
                        //tr.img = dt.Rows[i]["Category"].ToString();
                        list.Add(tr);
                    }
                    GeneralDataAlbum data = new GeneralDataAlbum();
                    data.MESSAGE = "Successfull";
                    data.ORIGINAL_ERROR = "";
                    data.ERROR_STATUS = false;
                    data.RECORDS = true;
                    data.Data = list;
                    g.Add(data);
                    Context.Response.Write(js.Serialize(g[0]));
                }
                else
                {
                    GeneralDataAlbum data = new GeneralDataAlbum();
                    data.MESSAGE = "No Data Found";
                    data.ORIGINAL_ERROR = "";
                    data.ERROR_STATUS = false;
                    data.RECORDS = false;
                    g.Add(data);
                    Context.Response.Write(js.Serialize(g[0]));
                }

            }
            catch (Exception ex)
            {
                GeneralDataAlbum data = new GeneralDataAlbum();
                data.MESSAGE = "Failed";
                data.ORIGINAL_ERROR = ex.Message;
                data.ERROR_STATUS = true;
                data.RECORDS = false;
                g.Add(data);
                Context.Response.Write(js.Serialize(g[0]));
            }

        }
    }
    [WebMethod]
    public void GetEventData(string type, string catid, string userid)
    {
        JavaScriptSerializer js = new JavaScriptSerializer();
        List<GeneralDataEvent> g = new List<GeneralDataEvent>();
        if (type == "event")
        {
            try
            {
                int i = 0;
                DataTable dt = cc.GetData("select sm.*,cm.city as cityname, CASE WHEN fm.Id IS NULL THEN '0' ELSE '1' END as IS_FAVOURITE from CityMaster as cm,EventMaster as sm left outer join FavouriteMaster as fm on fm.ItemId=sm.Id and fm.CategoryId='" + catid + "' and fm.Userid='" + userid + "' where cm.id = sm.location");
                //DataTable dt = cc.GetData("select * from [dbo].[EventMaster]");
                List<Event> list = new List<Event>();
                if (dt.Rows.Count > 0)
                {
                    for (i = 0; i <= dt.Rows.Count - 1; i++)
                    {
                        Event tr = new Event();

                        tr.id = dt.Rows[i]["Id"].ToString();
                        tr.title = dt.Rows[i]["Title"].ToString();
                        tr.favourite = dt.Rows[i]["IS_FAVOURITE"].ToString();
                        if (dt.Rows[i]["img"].ToString() != "")
                        {
                            tr.image = "http://inceptionlearning.com/A" + dt.Rows[i]["img"].ToString();
                        }
                        else
                        {
                            tr.image = "";
                        }
                        tr.location = dt.Rows[i]["cityname"].ToString();
                        if (dt.Rows[i]["Date"].ToString() != "")
                        {

                            tr.date = Convert.ToDateTime(dt.Rows[i]["Date"].ToString()).ToString("dd-MM-yyyy");
                            //hc.time = Convert.ToDateTime(dt2.Rows[i]["date"].ToString()).ToString("hh:mm tt");
                        }

                        tr.type = dt.Rows[i]["Type"].ToString();
                        tr.latitude = dt.Rows[i]["Latitude"].ToString();
                        tr.longitude = dt.Rows[i]["Longitude"].ToString();
                        tr.address = dt.Rows[i]["Address"].ToString();
                        tr.description = dt.Rows[i]["Description"].ToString();
                        //tr.img = dt.Rows[i]["Category"].ToString();
                        list.Add(tr);
                    }
                    GeneralDataEvent data = new GeneralDataEvent();
                    data.MESSAGE = "Successfull";
                    data.ORIGINAL_ERROR = "";
                    data.ERROR_STATUS = false;
                    data.RECORDS = true;
                    data.Data = list;
                    g.Add(data);
                    Context.Response.Write(js.Serialize(g[0]));
                }
                else
                {
                    GeneralDataEvent data = new GeneralDataEvent();
                    data.MESSAGE = "No Data Found";
                    data.ORIGINAL_ERROR = "";
                    data.ERROR_STATUS = false;
                    data.RECORDS = false;
                    g.Add(data);
                    Context.Response.Write(js.Serialize(g[0]));
                }

            }
            catch (Exception ex)
            {
                GeneralDataEvent data = new GeneralDataEvent();
                data.MESSAGE = "Failed";
                data.ORIGINAL_ERROR = ex.Message;
                data.ERROR_STATUS = true;
                data.RECORDS = false;
                g.Add(data);
                Context.Response.Write(js.Serialize(g[0]));
            }

        }
    }

    [WebMethod]
    public void GetEventDetailData(string type, string eventid)
    {
        JavaScriptSerializer js = new JavaScriptSerializer();
        List<GeneralDataEventDetail> g = new List<GeneralDataEventDetail>();
        if (type == "eventdetail")
        {
            try
            {
                int i = 0;
                DataTable dt = cc.GetData("select * from [dbo].[EventPasses] where eventid =" + eventid);
                DataTable dt2 = cc.GetData("select * from [dbo].[EventMaster] where id =" + eventid);
                List<EventDetail> list = new List<EventDetail>();
                if (dt.Rows.Count > 0)
                {
                    for (i = 0; i <= dt.Rows.Count - 1; i++)
                    {
                        EventDetail tr = new EventDetail();

                        tr.id = dt.Rows[i]["Id"].ToString();
                        tr.name = dt.Rows[i]["Name"].ToString();
                        if (dt.Rows[i]["Time"].ToString() != "")
                        {

                            //tr.date = Convert.ToDateTime(dt.Rows[i]["Date"].ToString()).ToString("dd-MM-yyyy");
                            tr.time = Convert.ToDateTime(dt.Rows[i]["Time"].ToString()).ToString("hh:mm tt");
                        }
                        else
                        {
                            tr.time = "";
                        }

                        tr.price = dt.Rows[i]["Price"].ToString();
                        list.Add(tr);
                    }
                    GeneralDataEventDetail data = new GeneralDataEventDetail();
                    data.MESSAGE = "Successfull";
                    data.ORIGINAL_ERROR = "";
                    data.ERROR_STATUS = false;
                    data.RECORDS = true;
                    if (dt2.Rows[0]["Date"].ToString() != "")
                    {

                        data.Day = Convert.ToDateTime(dt2.Rows[0]["Date"].ToString()).ToString("dd");
                        data.Month = Convert.ToDateTime(dt2.Rows[0]["Date"].ToString()).ToString("MM");
                        data.Year = Convert.ToDateTime(dt2.Rows[0]["Date"].ToString()).ToString("yyyy");
                        //tr.time = Convert.ToDateTime(dt.Rows[i]["Time"].ToString()).ToString("hh:mm tt");
                    }
                    else
                    {
                        data.Day = "";
                        data.Month = "";
                        data.Year = "";
                    }
                    data.Data = list;
                    g.Add(data);
                    Context.Response.Write(js.Serialize(g[0]));
                }
                else
                {
                    GeneralDataEventDetail data = new GeneralDataEventDetail();
                    data.MESSAGE = "No Data Found";
                    data.ORIGINAL_ERROR = "";
                    data.ERROR_STATUS = false;
                    data.RECORDS = false;
                    g.Add(data);
                    Context.Response.Write(js.Serialize(g[0]));
                }

            }
            catch (Exception ex)
            {
                GeneralDataEventDetail data = new GeneralDataEventDetail();
                data.MESSAGE = "Failed";
                data.ORIGINAL_ERROR = ex.Message;
                data.ERROR_STATUS = true;
                data.RECORDS = false;
                g.Add(data);
                Context.Response.Write(js.Serialize(g[0]));
            }

        }
    }

    [WebMethod]
    public void InsertSchoolReviewData(string type, string userid, string schoolname, string reviewer, string designation, string stateid, string cityid, string review, string ratingbox, string noofstudent)
    {
        JavaScriptSerializer js = new JavaScriptSerializer();
        List<GeneralData> g = new List<GeneralData>();
        if (type == "schoolreview")
        {
            try
            {
                schoolname = HttpUtility.UrlDecode(schoolname);
                reviewer = HttpUtility.UrlDecode(reviewer);
                review = HttpUtility.UrlDecode(review);
                designation = HttpUtility.UrlDecode(designation);
                ratingbox = HttpUtility.UrlDecode(ratingbox);
                string today = DateTime.Now.ToString("yyyy/MM/dd");
                cc.ExecuteQuery("insert into SchoolReview (Userid,Schoolname,Reviewer,Designation,Stateid,Cityid,Review,RatingBox,NoOfStudent,Date,Status) values('" + userid + "','" + schoolname + "','" + reviewer + "','" + designation + "','" + stateid + "','" + cityid + "','" + review + "','" + ratingbox + "','" + noofstudent + "','" + today + "','0')");
                GeneralData data = new GeneralData();
                data.MESSAGE = "Successfully !";
                data.ORIGINAL_ERROR = "";
                data.ERROR_STATUS = false;
                data.RECORDS = false;

                g.Add(data);
                Context.Response.Write(js.Serialize(g[0]));
            }
            catch (Exception ex)
            {
                GeneralData data = new GeneralData();
                data.MESSAGE = "Failed";
                data.ORIGINAL_ERROR = ex.Message;
                data.ERROR_STATUS = true;
                data.RECORDS = false;
                g.Add(data);
                Context.Response.Write(js.Serialize(g[0]));
            }
        }
    }

    [WebMethod]
    public void InsertEventDetailData(string type, string userid, string eventid, string fname, string lname, string email, string mobile, string whatsapp, string stateid, string cityid)
    {
        JavaScriptSerializer js = new JavaScriptSerializer();
        List<GeneralData> g = new List<GeneralData>();
        if (type == "eventdetail")
        {
            try
            {
                fname = HttpUtility.UrlDecode(fname);
                lname = HttpUtility.UrlDecode(lname);
                email = HttpUtility.UrlDecode(email);
                cc.ExecuteQuery("insert into EventDetail (Userid,Eventid,Firstname,Lastname,Email,Mobile,WhatsappNo,stateid,Cityid) values('" + userid + "','" + eventid + "','" + fname + "','" + lname + "','" + email + "','" + mobile + "','" + whatsapp + "','" + stateid + "','" + cityid + "')");
                GeneralData data = new GeneralData();
                data.MESSAGE = "Successfully !";
                data.ORIGINAL_ERROR = "";
                data.ERROR_STATUS = false;
                data.RECORDS = false;

                g.Add(data);
                Context.Response.Write(js.Serialize(g[0]));
            }
            catch (Exception ex)
            {
                GeneralData data = new GeneralData();
                data.MESSAGE = "Failed";
                data.ORIGINAL_ERROR = ex.Message;
                data.ERROR_STATUS = true;
                data.RECORDS = false;
                g.Add(data);
                Context.Response.Write(js.Serialize(g[0]));
            }
        }
    }

    [WebMethod]
    public void GetBannerData(string type)
    {
        JavaScriptSerializer js = new JavaScriptSerializer();
        List<GeneralDataBanner> g = new List<GeneralDataBanner>();
        if (type == "banner")
        {
            try
            {
                int i = 0;


                List<DetailData> list = new List<DetailData>();
                DetailData tr = new DetailData();
                List<Banner> list2 = new List<Banner>();
                DataTable dt = cc.GetData("select * from [dbo].[Banner]");
                if (dt.Rows.Count > 0)
                {
                    for (i = 0; i <= dt.Rows.Count - 1; i++)
                    {
                        Banner bd = new Banner();

                        bd.id = dt.Rows[i]["Id"].ToString();
                        if (dt.Rows[i]["img"].ToString() != "")
                        {
                            bd.img = "http://inceptionlearning.com/A" + dt.Rows[i]["img"].ToString();
                        }
                        else
                        {
                            bd.img = "";
                        }

                        list2.Add(bd);
                    }

                }
                List<MenuDataDetail> list3 = new List<MenuDataDetail>();
                DataTable dt2 = cc.GetData("select * from [dbo].[MenuMasterAnd]");
                if (dt2.Rows.Count > 0)
                {
                    for (i = 0; i <= dt2.Rows.Count - 1; i++)
                    {
                        MenuDataDetail bd = new MenuDataDetail();

                        bd.id = dt2.Rows[i]["Id"].ToString();
                        bd.name = dt2.Rows[i]["Name"].ToString();
                        if (dt2.Rows[i]["image"].ToString() != "")
                        {
                            bd.image = "http://inceptionlearning.com/A" + dt2.Rows[i]["image"].ToString();
                        }
                        else
                        {
                            bd.image = "";
                        }
                        if (dt2.Rows[i]["bgimage"].ToString() != "")
                        {
                            bd.bgimage = "http://inceptionlearning.com/A" + dt2.Rows[i]["bgimage"].ToString();
                        }
                        else
                        {
                            bd.bgimage = "";
                        }
                        bd.sequence = dt2.Rows[i]["Sequence"].ToString();
                        bd.parentid = dt2.Rows[i]["parentid"].ToString();
                        list3.Add(bd);
                    }

                }

                tr.BannerData = list2;
                tr.MenuData = list3;
                list.Add(tr);
                GeneralDataBanner data = new GeneralDataBanner();
                data.MESSAGE = "Successfull";
                data.ORIGINAL_ERROR = "";
                data.ERROR_STATUS = false;
                data.RECORDS = true;
                data.Data = list;
                g.Add(data);
                Context.Response.Write(js.Serialize(g[0]));
            }
            catch (Exception ex)
            {
                GeneralDataBanner data = new GeneralDataBanner();
                data.MESSAGE = "Failed";
                data.ORIGINAL_ERROR = ex.Message;
                data.ERROR_STATUS = true;
                data.RECORDS = false;
                g.Add(data);
                Context.Response.Write(js.Serialize(g[0]));
            }

        }
    }

    //[WebMethod]
    //public void GetMenuData(string type)
    //{
    //    JavaScriptSerializer js = new JavaScriptSerializer();
    //    List<GeneralDataMenu> g = new List<GeneralDataMenu>();
    //    if (type == "menus")
    //    {
    //        try
    //        {
    //            int i = 0;
    //            DataTable dt = cc.GetData("select * from [dbo].[MenuMaster] order by rank");
    //            List<Menu> list = new List<Menu>();
    //            if (dt.Rows.Count > 0)
    //            {
    //                for (i = 0; i <= dt.Rows.Count - 1; i++)
    //                {
    //                    Menu tr = new Menu();

    //                    tr.id = dt.Rows[i]["Id"].ToString();
    //                    tr.name = dt.Rows[i]["name"].ToString();
    //                    if (dt.Rows[i]["image"].ToString() != "")
    //                    {
    //                        tr.image = "http://inceptionlearning.com/A" + dt.Rows[i]["image"].ToString();
    //                    }
    //                    else
    //                    {
    //                        tr.image = "";
    //                    }
    //                    tr.color = dt.Rows[i]["Color"].ToString();
    //                    tr.rank = dt.Rows[i]["Rank"].ToString();
    //                    list.Add(tr);
    //                }
    //                GeneralDataMenu data = new GeneralDataMenu();
    //                data.MESSAGE = "Successfull";
    //                data.ORIGINAL_ERROR = "";
    //                data.ERROR_STATUS = false;
    //                data.RECORDS = true;
    //                data.Data = list;
    //                g.Add(data);
    //                Context.Response.Write(js.Serialize(g[0]));
    //            }
    //            else
    //            {
    //                GeneralDataMenu data = new GeneralDataMenu();
    //                data.MESSAGE = "No Data Found";
    //                data.ORIGINAL_ERROR = "";
    //                data.ERROR_STATUS = false;
    //                data.RECORDS = false;
    //                g.Add(data);
    //                Context.Response.Write(js.Serialize(g[0]));
    //            }

    //        }
    //        catch (Exception ex)
    //        {
    //            GeneralDataMenu data = new GeneralDataMenu();
    //            data.MESSAGE = "Failed";
    //            data.ORIGINAL_ERROR = ex.Message;
    //            data.ERROR_STATUS = true;
    //            data.RECORDS = false;
    //            g.Add(data);
    //            Context.Response.Write(js.Serialize(g[0]));
    //        }

    //    }
    //}

   
    [WebMethod]
    public void ViewSingleReviewData(string type, string reviewid)
    {
        JavaScriptSerializer js = new JavaScriptSerializer();
        int i = 0;
        List<ReviewData> list = new List<ReviewData>();
        List<GeneralDataReviewData> g = new List<GeneralDataReviewData>();
        if (type == "review")
        {
            try
            {
                DataTable dt2 = cc.GetData("select sr.*,sm.name as statename,cm.city as cityname from [dbo].[SchoolReview] as sr,[dbo].[StateMaster] as sm,[dbo].[CityMaster] as cm where sr.stateid = sm.stateid and cm.id = sr.cityid and sr.Id = '" + reviewid + "'");
                if (dt2.Rows.Count != 0)
                {

                    for (i = 0; i <= dt2.Rows.Count - 1; i++)
                    {
                        ReviewData hc = new ReviewData();


                        hc.reviewid = dt2.Rows[i]["Id"].ToString();
                        hc.schoolname = dt2.Rows[i]["Schoolname"].ToString();
                        hc.reviewer = dt2.Rows[i]["Reviewer"].ToString();
                        hc.designation = dt2.Rows[i]["Designation"].ToString();
                        hc.stateid = dt2.Rows[i]["stateid"].ToString();
                        hc.state = dt2.Rows[i]["statename"].ToString();
                        hc.cityid = dt2.Rows[i]["cityid"].ToString();
                        hc.city = dt2.Rows[i]["cityname"].ToString();
                        hc.review = dt2.Rows[i]["Review"].ToString();
                        hc.ratingbox = dt2.Rows[i]["RatingBox"].ToString();
                        hc.noofstudent = dt2.Rows[i]["NoOfStudent"].ToString();


                        if (dt2.Rows[i]["Date"].ToString() != "")
                        {

                            hc.date = Convert.ToDateTime(dt2.Rows[i]["Date"].ToString()).ToString("dd-MM-yyyy");
                            //hc.time = Convert.ToDateTime(dt2.Rows[i]["date"].ToString()).ToString("hh:mm tt");
                        }



                        list.Add(hc);

                    }
                    GeneralDataReviewData data = new GeneralDataReviewData();
                    data.MESSAGE = "Successfully !";
                    data.ORIGINAL_ERROR = "";
                    data.ERROR_STATUS = false;
                    data.RECORDS = true;
                    data.Data = list;
                    g.Add(data);
                    Context.Response.Write(js.Serialize(g[0]));
                }
                else
                {

                    GeneralDataReviewData data = new GeneralDataReviewData();
                    data.MESSAGE = "No Record Found !";
                    data.ORIGINAL_ERROR = "";
                    data.ERROR_STATUS = false;
                    data.RECORDS = false;
                    data.Data = list;
                    g.Add(data);
                    Context.Response.Write(js.Serialize(g[0]));
                }



            }
            catch (Exception ex)
            {
                GeneralDataReviewData data = new GeneralDataReviewData();
                data.MESSAGE = "Failed";
                data.ORIGINAL_ERROR = ex.Message;
                data.ERROR_STATUS = true;
                data.RECORDS = false;
                g.Add(data);
                Context.Response.Write(js.Serialize(g[0]));
            }
        }
    }
    [WebMethod]
    public void UpdateProfile(string type, string userid, string name, string email, string password, string mobile, string stateid, string cityid)
    {
        JavaScriptSerializer js = new JavaScriptSerializer();
        int i = 0;
        List<UserMaster> list = new List<UserMaster>();
        List<GeneralDataUser> g = new List<GeneralDataUser>();
        if (type == "profile")
        {
            try
            {
                DataTable dt = cc.GetData("select * from ClientMaster where Mobile = '" + mobile + "' and id = " + userid);
                DataTable dt2 = cc.GetData("select * from ClientMaster where Mobile = '" + mobile + "' and id != " + userid);
                if (dt.Rows.Count != 0)
                {
                    DataTable dt4 = cc.GetData("select * from ClientMaster where Email = '" + email + "' and id = " + userid);
                    DataTable dt5 = cc.GetData("select * from ClientMaster where Email = '" + email + "' and id != " + userid);
                    if (dt4.Rows.Count != 0)
                    {
                        cc.ExecuteQuery("update ClientMaster set name = '" + name + "' , Email = '" + email + "', Password = '" + password + "', Mobile = '" + mobile + "', StateId = '" + stateid + "', CityId = '" + cityid + "' where id = " + userid);
                        DataTable dt3 = cc.GetData("select um.*,sm.name as statename,cm.city as cityname from ClientMaster as um,[StateMaster] as sm,[CityMaster] as cm where um.stateid = sm.stateid and um.cityid = cm.id and um.id = " + userid);
                        if (dt3.Rows.Count != 0)
                        {

                            for (i = 0; i <= dt3.Rows.Count - 1; i++)
                            {
                                UserMaster hc = new UserMaster();


                                hc.clientid = dt3.Rows[i]["Id"].ToString();
                                hc.name = dt3.Rows[i]["Name"].ToString();
                                hc.mobile = dt3.Rows[i]["Mobile"].ToString();
                                hc.email = dt3.Rows[i]["Email"].ToString();
                                hc.password = dt3.Rows[i]["Password"].ToString();
                                hc.stateid = dt3.Rows[i]["stateid"].ToString();
                                hc.state = dt3.Rows[i]["Statename"].ToString();
                                hc.cityid = dt3.Rows[i]["cityid"].ToString();
                                hc.city = dt3.Rows[i]["Cityname"].ToString();
                                hc.logintype = dt3.Rows[i]["logintype"].ToString();


                                //if (dt3.Rows[i]["dob"].ToString() != "")
                                //{

                                //    hc.dob = Convert.ToDateTime(dt3.Rows[i]["dob"].ToString()).ToString("dd-MM-yyyy");
                                //    hc.time = Convert.ToDateTime(dt3.Rows[i]["date"].ToString()).ToString("hh:mm tt");
                                //}



                                hc.verificationstatus = dt3.Rows[i]["VerificationStatus"].ToString();
                                list.Add(hc);

                            }
                            GeneralDataUser data = new GeneralDataUser();
                            data.MESSAGE = "Successfully !";
                            data.ORIGINAL_ERROR = "";
                            data.ERROR_STATUS = false;
                            data.RECORDS = true;
                            data.Data = list;
                            g.Add(data);
                            Context.Response.Write(js.Serialize(g[0]));
                        }
                        else
                        {

                            GeneralDataUser data = new GeneralDataUser();
                            data.MESSAGE = "Wrong UserId !";
                            data.ORIGINAL_ERROR = "";
                            data.ERROR_STATUS = false;
                            data.RECORDS = false;
                            data.Data = list;
                            g.Add(data);
                            Context.Response.Write(js.Serialize(g[0]));
                        }
                    }
                    else if (dt5.Rows.Count == 0)
                    {
                        cc.ExecuteQuery("update ClientMaster set name = '" + name + "' , Email = '" + email + "', Password = '" + password + "', Mobile = '" + mobile + "', StateId = '" + stateid + "', CityId = '" + cityid + "' where id = " + userid);
                        DataTable dt3 = cc.GetData("select um.*,sm.name as statename,cm.city as cityname from ClientMaster as um,[StateMaster] as sm,[CityMaster] as cm where um.stateid = sm.stateid and um.cityid = cm.id and um.id = " + userid);
                        if (dt3.Rows.Count != 0)
                        {

                            for (i = 0; i <= dt3.Rows.Count - 1; i++)
                            {
                                UserMaster hc = new UserMaster();


                                hc.clientid = dt3.Rows[i]["Id"].ToString();
                                hc.name = dt3.Rows[i]["Name"].ToString();
                                hc.mobile = dt3.Rows[i]["Mobile"].ToString();
                                hc.email = dt3.Rows[i]["Email"].ToString();
                                hc.password = dt3.Rows[i]["Password"].ToString();
                                hc.stateid = dt3.Rows[i]["stateid"].ToString();
                                hc.state = dt3.Rows[i]["Statename"].ToString();
                                hc.cityid = dt3.Rows[i]["cityid"].ToString();
                                hc.city = dt3.Rows[i]["Cityname"].ToString();
                                hc.logintype = dt3.Rows[i]["logintype"].ToString();

                                //if (dt3.Rows[i]["dob"].ToString() != "")
                                //{

                                //    hc.dob = Convert.ToDateTime(dt3.Rows[i]["dob"].ToString()).ToString("dd-MM-yyyy");
                                //    hc.time = Convert.ToDateTime(dt3.Rows[i]["date"].ToString()).ToString("hh:mm tt");
                                //}



                                hc.verificationstatus = dt3.Rows[i]["VerificationStatus"].ToString();
                                list.Add(hc);

                            }
                            GeneralDataUser data = new GeneralDataUser();
                            data.MESSAGE = "Successfully !";
                            data.ORIGINAL_ERROR = "";
                            data.ERROR_STATUS = false;
                            data.RECORDS = true;
                            data.Data = list;
                            g.Add(data);
                            Context.Response.Write(js.Serialize(g[0]));
                        }
                        else
                        {

                            GeneralDataUser data = new GeneralDataUser();
                            data.MESSAGE = "Wrong UserId !";
                            data.ORIGINAL_ERROR = "";
                            data.ERROR_STATUS = false;
                            data.RECORDS = false;
                            data.Data = list;
                            g.Add(data);
                            Context.Response.Write(js.Serialize(g[0]));
                        }
                    }
                    else
                    {
                        GeneralDataUser data = new GeneralDataUser();
                        data.MESSAGE = "Email Id Already Exists !";
                        data.ORIGINAL_ERROR = "";
                        data.ERROR_STATUS = false;
                        data.RECORDS = false;
                        data.Data = list;
                        g.Add(data);
                        Context.Response.Write(js.Serialize(g[0]));
                    }

                }
                else if (dt2.Rows.Count == 0)
                {
                    DataTable dt4 = cc.GetData("select * from ClientMaster where Email = '" + email + "' and id = " + userid);
                    DataTable dt5 = cc.GetData("select * from ClientMaster where Email = '" + email + "' and id != " + userid);
                    if (dt4.Rows.Count != 0)
                    {
                        cc.ExecuteQuery("update ClientMaster set name = '" + name + "' , Email = '" + email + "', Password = '" + password + "', Mobile = '" + mobile + "', StateId = '" + stateid + "', CityId = '" + cityid + "', VerificationStatus = '0' where id = " + userid);
                        DataTable dt3 = cc.GetData("select um.*,sm.name as statename,cm.city as cityname from ClientMaster as um,[StateMaster] as sm,[CityMaster] as cm where um.stateid = sm.stateid and um.cityid = cm.id and um.id = " + userid);
                        if (dt3.Rows.Count != 0)
                        {

                            for (i = 0; i <= dt3.Rows.Count - 1; i++)
                            {
                                UserMaster hc = new UserMaster();


                                hc.clientid = dt3.Rows[i]["Id"].ToString();
                                hc.name = dt3.Rows[i]["Name"].ToString();
                                hc.mobile = dt3.Rows[i]["Mobile"].ToString();
                                hc.email = dt3.Rows[i]["Email"].ToString();
                                hc.password = dt3.Rows[i]["Password"].ToString();
                                hc.stateid = dt3.Rows[i]["stateid"].ToString();
                                hc.state = dt3.Rows[i]["Statename"].ToString();
                                hc.cityid = dt3.Rows[i]["cityid"].ToString();
                                hc.city = dt3.Rows[i]["Cityname"].ToString();
                                hc.logintype = dt3.Rows[i]["logintype"].ToString();


                                //if (dt3.Rows[i]["dob"].ToString() != "")
                                //{

                                //    hc.dob = Convert.ToDateTime(dt3.Rows[i]["dob"].ToString()).ToString("dd-MM-yyyy");
                                //    hc.time = Convert.ToDateTime(dt3.Rows[i]["date"].ToString()).ToString("hh:mm tt");
                                //}



                                hc.verificationstatus = dt3.Rows[i]["VerificationStatus"].ToString();
                                list.Add(hc);

                            }
                            GeneralDataUser data = new GeneralDataUser();
                            data.MESSAGE = "Successfully !";
                            data.ORIGINAL_ERROR = "";
                            data.ERROR_STATUS = false;
                            data.RECORDS = true;
                            data.Data = list;
                            g.Add(data);
                            Context.Response.Write(js.Serialize(g[0]));
                        }
                        else
                        {

                            GeneralDataUser data = new GeneralDataUser();
                            data.MESSAGE = "Wrong UserId !";
                            data.ORIGINAL_ERROR = "";
                            data.ERROR_STATUS = false;
                            data.RECORDS = false;
                            data.Data = list;
                            g.Add(data);
                            Context.Response.Write(js.Serialize(g[0]));
                        }
                    }
                    else if (dt5.Rows.Count == 0)
                    {
                        cc.ExecuteQuery("update ClientMaster set name = '" + name + "' , Email = '" + email + "', Password = '" + password + "', Mobile = '" + mobile + "', StateId = '" + stateid + "', CityId = '" + cityid + "', VerificationStatus = '0' where id = " + userid);
                        DataTable dt3 = cc.GetData("select um.*,sm.name as statename,cm.city as cityname from ClientMaster as um,[StateMaster] as sm,[CityMaster] as cm where um.stateid = sm.stateid and um.cityid = cm.id and um.id = " + userid);
                        if (dt3.Rows.Count != 0)
                        {

                            for (i = 0; i <= dt3.Rows.Count - 1; i++)
                            {
                                UserMaster hc = new UserMaster();


                                hc.clientid = dt3.Rows[i]["Id"].ToString();
                                hc.name = dt3.Rows[i]["Name"].ToString();
                                hc.mobile = dt3.Rows[i]["Mobile"].ToString();
                                hc.email = dt3.Rows[i]["Email"].ToString();
                                hc.password = dt3.Rows[i]["Password"].ToString();
                                hc.stateid = dt3.Rows[i]["stateid"].ToString();
                                hc.state = dt3.Rows[i]["Statename"].ToString();
                                hc.cityid = dt3.Rows[i]["cityid"].ToString();
                                hc.city = dt3.Rows[i]["Cityname"].ToString();
                                hc.logintype = dt3.Rows[i]["logintype"].ToString();

                                //if (dt3.Rows[i]["dob"].ToString() != "")
                                //{

                                //    hc.dob = Convert.ToDateTime(dt3.Rows[i]["dob"].ToString()).ToString("dd-MM-yyyy");
                                //    hc.time = Convert.ToDateTime(dt3.Rows[i]["date"].ToString()).ToString("hh:mm tt");
                                //}



                                hc.verificationstatus = dt3.Rows[i]["VerificationStatus"].ToString();
                                list.Add(hc);

                            }
                            GeneralDataUser data = new GeneralDataUser();
                            data.MESSAGE = "Successfully !";
                            data.ORIGINAL_ERROR = "";
                            data.ERROR_STATUS = false;
                            data.RECORDS = true;
                            data.Data = list;
                            g.Add(data);
                            Context.Response.Write(js.Serialize(g[0]));
                        }
                        else
                        {

                            GeneralDataUser data = new GeneralDataUser();
                            data.MESSAGE = "Wrong UserId !";
                            data.ORIGINAL_ERROR = "";
                            data.ERROR_STATUS = false;
                            data.RECORDS = false;
                            data.Data = list;
                            g.Add(data);
                            Context.Response.Write(js.Serialize(g[0]));
                        }
                    }
                    else
                    {
                        GeneralDataUser data = new GeneralDataUser();
                        data.MESSAGE = "Email Id Already Exists !";
                        data.ORIGINAL_ERROR = "";
                        data.ERROR_STATUS = false;
                        data.RECORDS = false;
                        data.Data = list;
                        g.Add(data);
                        Context.Response.Write(js.Serialize(g[0]));
                    }

                }
                else
                {
                    GeneralDataUser data = new GeneralDataUser();
                    data.MESSAGE = "Mobile No Already Exists !";
                    data.ORIGINAL_ERROR = "";
                    data.ERROR_STATUS = false;
                    data.RECORDS = false;
                    data.Data = list;
                    g.Add(data);
                    Context.Response.Write(js.Serialize(g[0]));
                }

            }
            catch (Exception ex)
            {
                GeneralDataUser data = new GeneralDataUser();
                data.MESSAGE = "Failed";
                data.ORIGINAL_ERROR = ex.Message;
                data.ERROR_STATUS = true;
                data.RECORDS = false;
                g.Add(data);
                Context.Response.Write(js.Serialize(g[0]));
            }
        }
    }
    [WebMethod]
    public void InsertFavouriteData(string type, string userid, string categoryid, string itemid)
    {
        JavaScriptSerializer js = new JavaScriptSerializer();
        List<GeneralData> g = new List<GeneralData>();
        if (type == "favourite")
        {
            try
            {
                DataTable dt = cc.GetData("select * from FavouriteMaster where userid = " + userid + " and itemid = " + itemid + " and categoryid = " + categoryid);
                if (dt.Rows.Count == 0)
                {
                    //name = HttpUtility.UrlDecode(name);
                    //email = HttpUtility.UrlDecode(email);
                    //message = HttpUtility.UrlDecode(message);
                    string today = DateTime.Now.ToString("yyyy/MM/dd");
                    cc.ExecuteQuery("insert into FavouriteMaster (Categoryid,Userid,ItemId,Date) values('" + categoryid + "','" + userid + "','" + itemid + "','" + today + "')");
                    GeneralData data = new GeneralData();
                    data.MESSAGE = "Successfully !";
                    data.ORIGINAL_ERROR = "";
                    data.ERROR_STATUS = false;
                    data.RECORDS = false;

                    g.Add(data);
                    Context.Response.Write(js.Serialize(g[0]));
                }
                else
                {
                    GeneralData data = new GeneralData();
                    data.MESSAGE = "You Already Favourite this Data";
                    data.ORIGINAL_ERROR = "";
                    data.ERROR_STATUS = false;
                    data.RECORDS = false;
                    g.Add(data);
                    Context.Response.Write(js.Serialize(g[0]));
                }

            }
            catch (Exception ex)
            {
                GeneralData data = new GeneralData();
                data.MESSAGE = "Failed";
                data.ORIGINAL_ERROR = ex.Message;
                data.ERROR_STATUS = true;
                data.RECORDS = false;
                g.Add(data);
                Context.Response.Write(js.Serialize(g[0]));
            }
        }
    }
    [WebMethod]
    public void DeleteFavouriteData(string type, string userid, string itemid, string categoryid)
    {
        JavaScriptSerializer js = new JavaScriptSerializer();
        List<GeneralData> g = new List<GeneralData>();
        if (type == "deletefavourite")
        {
            try
            {
                //name = HttpUtility.UrlDecode(name);
                //email = HttpUtility.UrlDecode(email);
                //message = HttpUtility.UrlDecode(message);
                string today = DateTime.Now.ToString("yyyy/MM/dd");
                cc.ExecuteQuery("delete from [dbo].[FavouriteMaster] where userid = " + userid + " and itemid = " + itemid + " and categoryid = " + categoryid);
                GeneralData data = new GeneralData();
                data.MESSAGE = "Successfully !";
                data.ORIGINAL_ERROR = "";
                data.ERROR_STATUS = false;
                data.RECORDS = false;

                g.Add(data);
                Context.Response.Write(js.Serialize(g[0]));
            }
            catch (Exception ex)
            {
                GeneralData data = new GeneralData();
                data.MESSAGE = "Failed";
                data.ORIGINAL_ERROR = ex.Message;
                data.ERROR_STATUS = true;
                data.RECORDS = false;
                g.Add(data);
                Context.Response.Write(js.Serialize(g[0]));
            }
        }


    }

    [WebMethod]
    public void GetFavouriteData(string type, string userid, string categoryid)
    {
        JavaScriptSerializer js = new JavaScriptSerializer();
        List<GeneralDataMenu> g = new List<GeneralDataMenu>();
        List<Menu> list = new List<Menu>();
        if (type == "favourite")
        {
            try
            {
                int i = 0;
                //DataTable dt = cc.GetData("select distinct categoryid from [dbo].[FavouriteMaster] where userid = " + userid);
                //if (dt.Rows.Count > 0)
                //{

                //    for (i = 0; i <= dt.Rows.Count - 1; i++)
                //    {

                DataTable dt2 = cc.GetData("select * from [dbo].[MenuMasterAnd] where id = " + categoryid);
                if (dt2.Rows.Count > 0)
                {


                    for (int j = 0; j <= dt2.Rows.Count - 1; j++)
                    {
                        Menu tr = new Menu();

                        tr.id = dt2.Rows[j]["Id"].ToString();
                        tr.name = dt2.Rows[j]["name"].ToString();
                        if (dt2.Rows[j]["image"].ToString() != "")
                        {
                            tr.image = "http://inceptionlearning.com/A" + dt2.Rows[j]["image"].ToString();
                        }
                        else
                        {
                            tr.image = "";
                        }
                        if (dt2.Rows[j]["bgimage"].ToString() != "")
                        {
                            tr.bgimage = "http://inceptionlearning.com/A" + dt2.Rows[j]["bgimage"].ToString();
                        }
                        else
                        {
                            tr.bgimage = "";
                        }
                        tr.sequence = dt2.Rows[j]["sequence"].ToString();
                        tr.parentid = dt2.Rows[j]["parentid"].ToString();
                        List<MenuData> list2 = new List<MenuData>();
                        if (dt2.Rows[j]["Id"].ToString() == "3")
                        {
                            //List<MenuData> list2 = new List<MenuData>();
                            DataTable dt3 = cc.GetData("select sm.* from [dbo].[StoriesMaster] as sm,FavouriteMaster as fm where fm.categoryid = 3 and fm.itemid = sm.id");
                            for (int k = 0; k <= dt3.Rows.Count - 1; k++)
                            {
                                MenuData md = new MenuData();
                                md.id = dt3.Rows[k]["Id"].ToString();
                                md.name = dt3.Rows[k]["title"].ToString();
                                md.desc = dt3.Rows[k]["description"].ToString();
                                if (dt3.Rows[k]["img"].ToString() != "")
                                {
                                    md.image = "http://inceptionlearning.com/A" + dt3.Rows[k]["img"].ToString();
                                }
                                else
                                {
                                    md.image = "";
                                }
                                md.link = dt3.Rows[k]["link"].ToString();
                                md.location = "";
                                md.date = "";
                                md.address = "";
                                list2.Add(md);
                            }
                        }
                        if (dt2.Rows[j]["Id"].ToString() == "4")
                        {
                            //List<MenuData> list2 = new List<MenuData>();
                            DataTable dt3 = cc.GetData("select sm.* from [dbo].[EventMaster] as sm,FavouriteMaster as fm where fm.categoryid = 4 and fm.itemid = sm.id");
                            for (int k = 0; k <= dt3.Rows.Count - 1; k++)
                            {
                                MenuData md = new MenuData();
                                md.id = dt3.Rows[k]["Id"].ToString();
                                md.name = dt3.Rows[k]["title"].ToString();
                                md.desc = dt3.Rows[k]["description"].ToString();
                                if (dt3.Rows[k]["img"].ToString() != "")
                                {
                                    md.image = "http://inceptionlearning.com/A" + dt3.Rows[k]["img"].ToString();
                                }
                                else
                                {
                                    md.image = "";
                                }
                                md.link = "";
                                md.location = dt3.Rows[k]["location"].ToString();
                                //md.date = dt3.Rows[k]["location"].ToString();
                                if (dt3.Rows[k]["date"].ToString() != "")
                                {

                                    md.date = Convert.ToDateTime(dt3.Rows[k]["date"].ToString()).ToString("dd-MM-yyyy");

                                }
                                else
                                {
                                    md.date = "";
                                }
                                md.address = dt3.Rows[k]["address"].ToString();
                                list2.Add(md);
                            }
                        }
                        if (dt2.Rows[j]["Id"].ToString() == "5")
                        {
                            //List<MenuData> list2 = new List<MenuData>();
                            DataTable dt3 = cc.GetData("select sm.* from [dbo].[VideoMaster] as sm,FavouriteMaster as fm where fm.categoryid = 5 and fm.itemid = sm.id");
                            for (int k = 0; k <= dt3.Rows.Count - 1; k++)
                            {
                                MenuData md = new MenuData();
                                md.id = dt3.Rows[k]["Id"].ToString();
                                md.name = dt3.Rows[k]["title"].ToString();
                                md.desc = "";
                                //if (dt3.Rows[k]["img"].ToString() != "")
                                //{
                                //    md.image = "http://inceptionlearning.com/A" + dt3.Rows[k]["img"].ToString();
                                //}
                                //else
                                //{
                                //    md.image = "";
                                //}
                                md.image = "";
                                md.link = dt3.Rows[k]["url"].ToString();
                                md.location = "";
                                md.date = "";
                                md.address = "";
                                list2.Add(md);
                            }
                        }
                        if (dt2.Rows[j]["Id"].ToString() == "6")
                        {
                            //List<MenuData> list2 = new List<MenuData>();
                            DataTable dt3 = cc.GetData("select sm.* from [dbo].[Quotes] as sm,FavouriteMaster as fm where fm.categoryid = 6 and fm.itemid = sm.id");
                            for (int k = 0; k <= dt3.Rows.Count - 1; k++)
                            {
                                MenuData md = new MenuData();
                                md.id = dt3.Rows[k]["Id"].ToString();
                                md.name = dt3.Rows[k]["title"].ToString();
                                md.desc = "";
                                if (dt3.Rows[k]["img"].ToString() != "")
                                {
                                    md.image = "http://inceptionlearning.com/A" + dt3.Rows[k]["img"].ToString();
                                }
                                else
                                {
                                    md.image = "";
                                }
                                md.link = "";
                                md.location = "";
                                md.date = "";
                                md.address = "";
                                list2.Add(md);
                            }
                        }
                        if (dt2.Rows[j]["Id"].ToString() == "9" || dt2.Rows[j]["Id"].ToString() == "10" || dt2.Rows[j]["Id"].ToString() == "11" || dt2.Rows[j]["Id"].ToString() == "12" || dt2.Rows[j]["Id"].ToString() == "13" || dt2.Rows[j]["Id"].ToString() == "14" || dt2.Rows[j]["Id"].ToString() == "15" || dt2.Rows[j]["Id"].ToString() == "16")
                        {

                            //List<MenuData> list2 = new List<MenuData>();
                            DataTable dt3 = cc.GetData("select sm.* from [dbo].[JustFactsMaster] as sm,FavouriteMaster as fm where fm.categoryid = " + dt2.Rows[j]["Id"].ToString() + " and fm.itemid = sm.id and  sm.dykid = fm.categoryid");
                            for (int k = 0; k <= dt3.Rows.Count - 1; k++)
                            {
                                MenuData md = new MenuData();
                                md.id = dt3.Rows[k]["Id"].ToString();
                                md.name = dt3.Rows[k]["text"].ToString();
                                md.desc = "#" + dt3.Rows[k]["factid"].ToString();
                                //if (dt3.Rows[k]["img"].ToString() != "")
                                //{
                                //    md.image = "http://inceptionlearning.com/A" + dt3.Rows[k]["img"].ToString();
                                //}
                                //else
                                //{
                                //    md.image = "";
                                //}
                                md.image = "";
                                md.link = "";
                                md.location = "";
                                md.date = "";
                                md.address = "";
                                list2.Add(md);
                            }
                        }
                        tr.Detail = list2;
                        list.Add(tr);

                    }
                    GeneralDataMenu data = new GeneralDataMenu();
                    data.MESSAGE = "Successfull";
                    data.ORIGINAL_ERROR = "";
                    data.ERROR_STATUS = false;
                    data.RECORDS = true;
                    data.Data = list;
                    g.Add(data);
                    Context.Response.Write(js.Serialize(g[0]));
                }
                else
                {
                    GeneralDataMenu data = new GeneralDataMenu();
                    data.MESSAGE = "No Data Found";
                    data.ORIGINAL_ERROR = "";
                    data.ERROR_STATUS = false;
                    data.RECORDS = false;
                    g.Add(data);
                    Context.Response.Write(js.Serialize(g[0]));
                }

                //    }


                //}
                //else
                //{
                //    GeneralDataMenu data = new GeneralDataMenu();
                //    data.MESSAGE = "No Data Found";
                //    data.ORIGINAL_ERROR = "";
                //    data.ERROR_STATUS = false;
                //    data.RECORDS = false;
                //    g.Add(data);
                //    Context.Response.Write(js.Serialize(g[0]));
                //}

            }
            catch (Exception ex)
            {
                GeneralDataMenu data = new GeneralDataMenu();
                data.MESSAGE = "Failed";
                data.ORIGINAL_ERROR = ex.Message;
                data.ERROR_STATUS = true;
                data.RECORDS = false;
                g.Add(data);
                Context.Response.Write(js.Serialize(g[0]));
            }

        }
    }
}
