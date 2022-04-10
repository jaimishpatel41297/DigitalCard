using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using System.Configuration;
using System.Globalization;
using System.Net;
using System.IO;
using System.Net.NetworkInformation;
using System.Web.Script.Serialization;
using System.Web.UI.WebControls;
using System.Text.RegularExpressions;

/// <summary>
/// Summary description for AppService
/// </summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
// To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
// [System.Web.Script.Services.ScriptService]
public class AppService : System.Web.Services.WebService {

    string websiteclient = "http://magikretail.com/";
    string website = "http://lifestyle.studyfield.com/";


    SqlConnection cn = new SqlConnection("Data Source=103.242.119.138;Initial Catalog=MagikRetail;uid=sa;pwd=tech@123;;");
    //string cn = System.Configuration.ConfigurationManager.ConnectionStrings["MagikRetailConnection"].ConnectionString;
    //SqlCommand cmd = new SqlCommand();
    GetData D = new GetData();
    Connection cc = new Connection();
    public AppService () {

        //Uncomment the following line if using designed components 
        //InitializeComponent(); 
    }

    // [WebMethod]
    // public string HelloWorld() {
        // return "Hello World";
    // }
    [WebMethod]
    public void login(string type, string Username, string password)
    {
        JavaScriptSerializer js = new JavaScriptSerializer();
        int i = 0;
        List<UserMaster> list = new List<UserMaster>();
        List<GeneralDataUser> g = new List<GeneralDataUser>();
        if (type == "login")
        {
            try
            {
                DataTable dt = D.GetDataTable("select * from SF_ADMIN_MASTER where USERNAME='" + Username + "' and PASSWORD='" + password + "'");
                if (dt.Rows.Count > 0)
                {
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
                    data.MESSAGE = "Wrong Data !";
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
    public void AddEmployee(string type, string Name, string Address, string Mobile,string email,string emptype)
    {
        JavaScriptSerializer js = new JavaScriptSerializer();
        List<GeneralData> g = new List<GeneralData>();
        if (type == "EmployeeData")
        {
            try
            {
                D.ExecuteQuery("insert into EmployeeMaster (E_Name,E_address,E_Mobile,E_email,Type) values('" + Name + "','" + Address + "','" + Mobile + "','" + email + "','" + emptype + "')");
                //DataTable dt = D.GetDataTable("select id from CustomerMaster where name = '" + Name + "' order by id desc");
                GeneralData data = new GeneralData();
                data.MESSAGE = "Successfully Inserted!";
                data.ORIGINAL_ERROR = "Successfully Inserted!";
                data.ERROR_STATUS = false;
                data.RECORDS = false;
                g.Add(data);
                Context.Response.Write(js.Serialize(g[0]));
            }
            catch (Exception ex)
            {
                GeneralData data = new GeneralData();
                data.MESSAGE = "Failed To Insert";
                data.ORIGINAL_ERROR = ex.Message;
                data.ERROR_STATUS = true;
                data.RECORDS = false;
                g.Add(data);
                Context.Response.Write(js.Serialize(g[0]));
            }
        }

    }
    [WebMethod]
    public void Updatecart(string itemid, string pick)
    {
        //int pick1 = Convert.ToInt32(pick) + 1;
        ReturnData data = new ReturnData();
        JavaScriptSerializer js = new JavaScriptSerializer();
        
            try
            {
                D.ExecuteQuery("UPDATE [dbo].[Cart] SET Pick = '" + pick + "' WHERE Id = " + itemid);
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
    public void UpdateItem(string type,string kgprice, string pcsprice, string id)
    {
        ReturnData data = new ReturnData();
        JavaScriptSerializer js = new JavaScriptSerializer();
        if (type == "updateitem")
        {
            try
            {
                D.ExecuteQuery("UPDATE [dbo].[ItemMaster] SET RetailKgPrice = '" + kgprice + "',RetailPcsPrice='" + pcsprice + "' WHERE Id = " + id);
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
    }

    [WebMethod]
    public void EditProfile(string type, string name, string wifemobile, string mobile, string email, string address, string flatno, string society, string building, string Area,string id)
    {
        ReturnData data = new ReturnData();
        JavaScriptSerializer js = new JavaScriptSerializer();
        if (type == "profile")
        {
            try
            {
                D.ExecuteQuery("UPDATE [dbo].[CustomerMaster] SET Name = '" + name + "',WifeMobile='" + wifemobile + "',Mobile='" + mobile + "',Email='" + email + "',Address='" + address + "',FlatNo='" + flatno + "',Society='" + society + "',Building='" + building + "',Area='" + Area +"'  WHERE Id = " + id);
                data.MESSAGE = "Successfully Updated!";
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
    public void AddOrderEntry(string type,string ordertype,string CID,string EID,string total,string status, string Data)
    {
        JavaScriptSerializer js = new JavaScriptSerializer();       
        List<GeneralData> g = new List<GeneralData>();
        string id = "";
        string unit = "";
        string qty = "";
        string amount = "";
        string date = DateTime.Now.ToString("yyyy-MM-dd");
        string time = DateTime.Now.ToString("hh:mm:ss");
        if (type == "order")
        {
            try
            {
                string url = "";
                JavaScriptSerializer _convert = new JavaScriptSerializer();
                url = Data;
                var _Items = _convert.Deserialize<OrderItem[]>(url);
                int cnt = _Items.Length;            
                D.ExecuteQuery("insert into OrderMaster (Type,Date,Time,CID,EID,Total,Status) values('" + ordertype + "','" + date + "','" + time + "','" + CID + "','" + EID + "','" + total + "','" + status + "')");
                DataTable dt = D.GetDataTable("select id from OrderMaster where CID = '" + CID + "' order by id desc");
                       for (int i = 0; i < cnt; i++)
                       {
                           id = (new System.Web.UI.WebControls.ListItem(_Items[i].ID).ToString());
                           unit = (new System.Web.UI.WebControls.ListItem(_Items[i].Unit).ToString());
                           qty = (new System.Web.UI.WebControls.ListItem(_Items[i].Qty).ToString());
                           amount = (new System.Web.UI.WebControls.ListItem(_Items[i].Amount).ToString());
                           string query = "insert into OrderItems(OID,IID,Unit,Qty,Amount) values('" + dt.Rows[0]["id"].ToString() + "','" + id + "','" + unit + "','" + qty + "','" + amount + "')";
                           D.ExecuteQuery(query);

                           string outkg = "1";
                           string outpcs = "1";
                           string kgqty = "0";
                           string pcsqty = "0";
                           if (unit == "G" || unit == "KG")
                           {
                               kgqty = qty;
                               outpcs = "0";
                           }
                           else
                           {
                               pcsqty = qty;
                               outkg = "0";
                           }
                           DataTable dt4 = D.GetDataTable("select * from Stock where iid = " + id);
                           if (dt4.Rows.Count == 0)
                           {
                               D.ExecuteQuery("insert into Stock (IID) values(" + id + ")");
                               D.ExecuteQuery("Update Stock set OutKg+=" + outkg + ",OutPcs+=" + outpcs + ",OnhandKg-=" + kgqty + ",OnhandPcs-=" + pcsqty + " where IID = " + id);
                           }
                           else
                           {
                               D.ExecuteQuery("Update Stock set OutKg+=" + outkg + ",OutPcs+=" + outpcs + ",OnhandKg-=" + kgqty + ",OnhandPcs-=" + pcsqty + " where IID = " + id);
                           }

                       }







                
                
                //DataTable dt = D.GetDataTable("select id from CustomerMaster where name = '" + Name + "' order by id desc");
                GeneralData data = new GeneralData();
                data.MESSAGE = "Successfully Inserted!";
                data.ORIGINAL_ERROR = "Successfully Inserted!";
                data.ERROR_STATUS = false;
                data.RECORDS = false;
                g.Add(data);
                Context.Response.Write(js.Serialize(g[0]));
            }
            catch (Exception ex)
            {
                GeneralData data = new GeneralData();
                data.MESSAGE = "Failed To Insert";
                data.ORIGINAL_ERROR = ex.Message;
                data.ERROR_STATUS = true;
                data.RECORDS = false;
                g.Add(data);
                Context.Response.Write(js.Serialize(g[0]));
            }
        }

    }
	[WebMethod]
    public void GetCategory(string type)
    {
        JavaScriptSerializer js = new JavaScriptSerializer();
        int i = 0;
        List<CustomerMaster> list = new List<CustomerMaster>();
        List<GeneralDataCustomer> g = new List<GeneralDataCustomer>();
        if (type == "category")
        {
            try
            {
                DataTable dt2 = D.GetDataTable("select * from CategoryMaster");
                if (dt2.Rows.Count != 0)
                {
                    for (i = 0; i <= dt2.Rows.Count - 1; i++)
                    {
                        CustomerMaster hc = new CustomerMaster();
                        hc.id = dt2.Rows[i]["Id"].ToString();
                        hc.name = dt2.Rows[i]["name"].ToString();
                        list.Add(hc);

                    }
                    GeneralDataCustomer data = new GeneralDataCustomer();
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
                    GeneralDataCustomer data = new GeneralDataCustomer();
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
                GeneralDataCustomer data = new GeneralDataCustomer();
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
    public void GetDashboard(string type)
    {
        JavaScriptSerializer js = new JavaScriptSerializer();
        int i = 0;
        List<DashboardMaster> list = new List<DashboardMaster>();
        List<GeneralDataDashboard> g = new List<GeneralDataDashboard>();
        if (type == "dashboard")
        {
            try
            {
                string year = DateTime.Now.ToString("yyyy");
                DataTable dt2 = D.GetDataTable("select (select sum(total) from OrderMaster where year(date) = '" + year + "') as total,(select count(*) as total from OrderMaster where year(date) = '" + year + "') as orders");
                if (dt2.Rows.Count != 0)
                {
                    for (i = 0; i <= dt2.Rows.Count - 1; i++)
                    {
                        DashboardMaster hc = new DashboardMaster();
                        hc.TotalBusiness = dt2.Rows[i]["total"].ToString();
                        hc.TotalOrder = dt2.Rows[i]["orders"].ToString();
                        list.Add(hc);

                    }
                    GeneralDataDashboard data = new GeneralDataDashboard();
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
                    GeneralDataDashboard data = new GeneralDataDashboard();
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
                GeneralDataDashboard data = new GeneralDataDashboard();
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
    public void TodayDashboard(string type)
    {
        JavaScriptSerializer js = new JavaScriptSerializer();
        int i = 0;
        List<TodayDashboard> list = new List<TodayDashboard>();
        List<GeneralDataDashboard2> g = new List<GeneralDataDashboard2>();
        if (type == "dashboard")
        {
            try
            {
                string today = DateTime.Now.ToString("yyyy-MM-dd");

                DataTable dt2 = D.GetDataTable("select Count(id) as TotalOrder,sum(Total) as TodaysBusiness from OrderMaster where date='" + today +"'");
                if (dt2.Rows.Count != 0)
                {
                    for (i = 0; i <= dt2.Rows.Count - 1; i++)
                    {
                        TodayDashboard hc = new TodayDashboard();
                        hc.TodaysBusiness = dt2.Rows[i]["TodaysBusiness"].ToString();
                        hc.TodayOrders = dt2.Rows[i]["TotalOrder"].ToString();
                        hc.date = DateTime.Now.ToString("yyyy-MM-dd");

                        list.Add(hc);

                    }
                    GeneralDataDashboard2 data = new GeneralDataDashboard2();
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
                    GeneralDataDashboard2 data = new GeneralDataDashboard2();
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
                GeneralDataDashboard2 data = new GeneralDataDashboard2();
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
    public void GetOrderSummary(string type, string date)
    {
        JavaScriptSerializer js = new JavaScriptSerializer();
        int i = 0;
        List<OrderSummary> list = new List<OrderSummary>();
        List<GeneralDataOrder> g = new List<GeneralDataOrder>();
        string qry = "";
        try
        {
            if (type == "pendingorder")
            {
                qry = "select i.engname,i.id,i.kgprice,i.pcsprice,i.RetailKgPrice,i.RetailPcsPrice,i.marginkg,i.marginpcs,case when sum(newkgqty) = 0 then cast(sum(newpcsqty) as varchar) + ' PCS' else cast(cast(sum(newkgqty) as float) / 1000 as varchar) + ' KG' end as Items,case when sum(newkgqty) = 0 then cast(sum(newpcsqty) as float) * i.RetailPcsPrice else cast(sum(newkgqty) as float) / 1000 * i.RetailKgPrice end as Total from [getorderitemlist] as g,ItemMaster as i where i.id = g.iid and g.date = '" + date + "' and g.iid not in (select iid from StockMaster where createddate = '" + date + "')  group by engname,kgprice,pcsprice,RetailKgPrice,RetailPcsPrice,i.id,marginkg,marginpcs";
            }
            else if (type == "completeorder")
            {
                qry = "select distinct i.engname,i.id,i.kgprice,i.pcsprice,i.RetailKgPrice,i.RetailPcsPrice,i.marginkg,i.marginpcs,'0' as items,'0' as total from StockMaster as ip,ItemMaster as i where ip.iid = i.id and ip.createddate = '" + date + "'";
            }
            else if (type == "allorder")
            {
                qry = "select *,'0' as items,'0' as total from ItemMaster where id not in (select iid from StockMaster where createddate = '" + date + "') and id not in (select iid from getorderitemlist where date = '" + date + "')";
            }
            else
            {
                GeneralDataOrder data = new GeneralDataOrder();
                data.MESSAGE = "Failed";
                data.ORIGINAL_ERROR = "Wrong Type..";
                data.ERROR_STATUS = true;
                data.RECORDS = false;
                g.Add(data);
                Context.Response.Write(js.Serialize(g[0]));
                return;
            }
            DataTable dt2 = D.GetDataTable(qry);
            if (dt2.Rows.Count != 0)
            {
                for (i = 0; i <= dt2.Rows.Count - 1; i++)
                {
                    OrderSummary hc = new OrderSummary();
                    hc.id = dt2.Rows[i]["Id"].ToString();
                    hc.name = dt2.Rows[i]["engname"].ToString();
                    hc.unit = dt2.Rows[i]["items"].ToString();
                    hc.kgholesaleprice = dt2.Rows[i]["kgprice"].ToString();
                    hc.pcsholesaleprice = dt2.Rows[i]["pcsprice"].ToString();
                    hc.kgmargin = dt2.Rows[i]["marginkg"].ToString();
                    hc.pcsmargin = dt2.Rows[i]["marginpcs"].ToString();
                    hc.kgretailprice = dt2.Rows[i]["RetailKgPrice"].ToString();
                    hc.pcsretailprice = dt2.Rows[i]["RetailPcsPrice"].ToString();
                    list.Add(hc);

                }
                GeneralDataOrder data = new GeneralDataOrder();
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
                GeneralDataOrder data = new GeneralDataOrder();
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
            GeneralDataOrder data = new GeneralDataOrder();
            data.MESSAGE = "Failed";
            data.ORIGINAL_ERROR = ex.Message;
            data.ERROR_STATUS = true;
            data.RECORDS = false;
            g.Add(data);
            Context.Response.Write(js.Serialize(g[0]));
        }

    }

    [WebMethod]
    public void GetCustomerData(string type)
    {
        JavaScriptSerializer js = new JavaScriptSerializer();
        int i = 0;
        List<CustomerMaster> list = new List<CustomerMaster>();
        List<GeneralDataCustomer> g = new List<GeneralDataCustomer>();
        if (type == "customer")
        {
            try
            {
                DataTable dt2 = D.GetDataTable(" select *,name + ' - ' + Mobile + ' - ' + Address as fullname from CustomerMaster");
                if (dt2.Rows.Count != 0)
                {
                    for (i = 0; i <= dt2.Rows.Count - 1; i++)
                    {
                        CustomerMaster hc = new CustomerMaster();
                        hc.id = dt2.Rows[i]["Id"].ToString();
                        hc.name = dt2.Rows[i]["fullname"].ToString();
                        list.Add(hc);

                    }
                    GeneralDataCustomer data = new GeneralDataCustomer();
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
                    GeneralDataCustomer data = new GeneralDataCustomer();
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
                GeneralDataCustomer data = new GeneralDataCustomer();
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
    public void GetCustomerAllData(string type)
    {
        JavaScriptSerializer js = new JavaScriptSerializer();
        int i = 0;
        List<CustomerAllMaster> list = new List<CustomerAllMaster>();
        List<GeneralDataCustomerAll> g = new List<GeneralDataCustomerAll>();
        if (type == "customer")
        {
            try
            {
                DataTable dt2 = D.GetDataTable(" select * from CustomerMaster ORDER BY Name");
                if (dt2.Rows.Count != 0)
                {
                    for (i = 0; i <= dt2.Rows.Count - 1; i++)
                    {
                        CustomerAllMaster hc = new CustomerAllMaster();
                        hc.id = dt2.Rows[i]["Id"].ToString();
                        hc.name = dt2.Rows[i]["name"].ToString();
                        hc.mobile = dt2.Rows[i]["mobile"].ToString();
                        hc.wmobile = dt2.Rows[i]["wifemobile"].ToString();
                        hc.email = dt2.Rows[i]["email"].ToString();
                        hc.address = dt2.Rows[i]["address"].ToString();
                        hc.flatno = dt2.Rows[i]["flatno"].ToString();
                        hc.society = dt2.Rows[i]["society"].ToString();
                        hc.building = dt2.Rows[i]["building"].ToString();
                        hc.area = dt2.Rows[i]["area"].ToString();
                        list.Add(hc);

                    }
                    GeneralDataCustomerAll data = new GeneralDataCustomerAll();
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
                    GeneralDataCustomerAll data = new GeneralDataCustomerAll();
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
                GeneralDataCustomerAll data = new GeneralDataCustomerAll();
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
    public void UserProfile(string type,string mobile)
    {
        JavaScriptSerializer js = new JavaScriptSerializer();
        int i = 0;
        List<CustomerAllMaster> list = new List<CustomerAllMaster>();
        List<GeneralDataCustomerAll> g = new List<GeneralDataCustomerAll>();
        if (type == "user")
        {
            try
            {
                DataTable dt2 = D.GetDataTable(" select * from CustomerMaster where Mobile='"+ mobile +"'");
                if (dt2.Rows.Count != 0)
                {
                    for (i = 0; i <= dt2.Rows.Count - 1; i++)
                    {
                        CustomerAllMaster hc = new CustomerAllMaster();
                        hc.id = dt2.Rows[i]["Id"].ToString();
                        hc.name = dt2.Rows[i]["Name"].ToString();
                        hc.mobile = dt2.Rows[i]["Mobile"].ToString();
                        hc.wmobile = dt2.Rows[i]["wifemobile"].ToString();
                        hc.email = dt2.Rows[i]["email"].ToString();
                        hc.address = dt2.Rows[i]["address"].ToString();
                        hc.flatno = dt2.Rows[i]["flatno"].ToString();
                        hc.society = dt2.Rows[i]["society"].ToString();
                        hc.building = dt2.Rows[i]["building"].ToString();
                        hc.area = dt2.Rows[i]["area"].ToString();
                        list.Add(hc);

                    }
                    GeneralDataCustomerAll data = new GeneralDataCustomerAll();
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
                    GeneralDataCustomerAll data = new GeneralDataCustomerAll();
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
                GeneralDataCustomerAll data = new GeneralDataCustomerAll();
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
    public void UpdateItemPrice(string type, string id, string date, string holesalekg, string holesalepcs, string marginkg, string marginpcs, string retailkg, string retailpcs, string kgqty, string pcsqty)
    {
        double amt = 0;
        double total = 0;
        List<GeneralData> g = new List<GeneralData>();
        JavaScriptSerializer js = new JavaScriptSerializer();
        if (type == "updateorder")
        {
            try
            {
                //string today = DateTime.Now.ToString("yyyy-MM-dd");
                D.ExecuteQuery("update ItemMaster set KgPrice = " + holesalekg + ",PcsPrice = " + holesalepcs + ",RetailKgPrice = " + retailkg + ",RetailPcsPrice = " + retailpcs + ",MarginKg = " + marginkg + ",MarginPcs = " + marginpcs + " where id = " + id);
                string inkg = "1";
                string inpcs = "1";
                if (kgqty == "" || kgqty == "0")
                {
                    inkg = "0";
                }
                if (pcsqty == "" || pcsqty == "0")
                {
                    inpcs = "0";
                }
                DataTable dt3 = D.GetDataTable("select * from Stock where iid = " + id);
                if (dt3.Rows.Count == 0)
                {
                    D.ExecuteQuery("insert into Stock (IID,OpeningStockKg,OpeningStockPcs,InKg,InPcs,OutKg,OutPcs,OnhandKg,OnhandPcs) values(" + id + "," + kgqty + "," + pcsqty + "," + inkg + "," + inpcs + ",0,0," + kgqty + "," + pcsqty + ")");
                }
                else
                {
                    D.ExecuteQuery("Update Stock set InKg+=" + inkg + ",InPcs+=" + inpcs + ",OnhandKg+=" + kgqty + ",OnhandPcs+=" + pcsqty + " where IID = " + id);
                }
                D.ExecuteQuery("insert into StockMaster (IID,KgQty,PcsQty,CreatedDate) values(" + id + "," + kgqty + "," + pcsqty + ",'" + date + "')");
                DataTable dt = D.GetDataTable("select oi.* from OrderItems as oi,OrderMaster as om where om.id = oi.oid and om.date = '" + date + "' and oi.iid = " + id);
                if (dt.Rows.Count > 0)
                {
                    for (int i = 0; i <= dt.Rows.Count - 1; i++)
                    {
                        if (dt.Rows[i]["Unit"].ToString() == "PCS")
                        {
                            amt = Convert.ToInt32(dt.Rows[i]["qty"]) * Convert.ToDouble(retailpcs);
                            D.ExecuteQuery("update OrderItems set amount = " + amt + " where OID = " + dt.Rows[i]["oid"].ToString() + " and iid = " + id);
                            total = Convert.ToDouble(retailpcs) - Convert.ToInt32(dt.Rows[i]["amount"]);
                            D.ExecuteQuery("update OrderMaster set total += " + total + " where ID = " + dt.Rows[i]["oid"].ToString() + "");
                        }
                        else if (dt.Rows[i]["Unit"].ToString() == "KG")
                        {
                            amt = Convert.ToInt32(dt.Rows[i]["qty"]) * Convert.ToDouble(retailkg);
                            D.ExecuteQuery("update OrderItems set amount = " + amt + " where OID = " + dt.Rows[i]["oid"].ToString() + " and iid = " + id);
                            total = Convert.ToDouble(retailkg) - Convert.ToInt32(dt.Rows[i]["amount"]);
                            D.ExecuteQuery("update OrderMaster set total += " + total + " where ID = " + dt.Rows[i]["oid"].ToString() + "");
                        }
                        else
                        {
                            amt = Convert.ToInt32(dt.Rows[i]["qty"]) * Convert.ToDouble(retailkg) / 1000;
                            D.ExecuteQuery("update OrderItems set amount = " + amt + " where OID = " + dt.Rows[i]["oid"].ToString() + " and iid = " + id);
                            total = (Convert.ToDouble(retailkg) / 1000) - Convert.ToInt32(dt.Rows[i]["amount"]);
                            D.ExecuteQuery("update OrderMaster set total += " + total + " where ID = " + dt.Rows[i]["oid"].ToString() + "");
                        }
                    }
                }
                GeneralData data = new GeneralData();
                data.MESSAGE = "Successfully!";
                data.ORIGINAL_ERROR = "Successfully Inserted!";
                data.ERROR_STATUS = false;
                data.RECORDS = false;
                g.Add(data);
                Context.Response.Write(js.Serialize(g[0]));
            }
            catch (Exception ex)
            {
                GeneralData data = new GeneralData();
                data.MESSAGE = "Failed To Insert";
                data.ORIGINAL_ERROR = ex.Message;
                data.ERROR_STATUS = true;
                data.RECORDS = false;
                g.Add(data);
                Context.Response.Write(js.Serialize(g[0]));
            }
        }
    }

    [WebMethod]
    public void InsertOrder(string type, string date, string customerid, string Total, string Data)
    {
        List<GeneralData> g = new List<GeneralData>();
        JavaScriptSerializer js = new JavaScriptSerializer();
        //Data=[{"ID":"1","Unit":"KG","Qty":"1","Amount":"100"}]
        string id = "";
        string unit = "";
        string qty = "";
        string amount = "";
        if (type == "order")
        {
            try
            {
                string url = "";
                JavaScriptSerializer _convert = new JavaScriptSerializer();
                url = Data;
                var _Items = _convert.Deserialize<OrderItem[]>(url);
                int cnt = _Items.Length;
                if (cnt > 0)
                {
                    DateTime insdate = DateTime.ParseExact(date, "dd-MM-yyyy",System.Globalization.CultureInfo.InvariantCulture);
                    date = Convert.ToDateTime(insdate).ToString("yyyy-MM-dd");

                    DataTable dt3 = D.GetDataTable("select id from OrderMaster where CID = '" + customerid + "' and Date = '" + date + "'");
                    if (dt3.Rows.Count == 0)
                    {

                        string time = DateTime.Now.ToString("hh:mm tt");
                        D.ExecuteQuery("insert into OrderMaster (Date,Time,CID,Total) values('" + date + "','" + time + "','" + customerid + "','" + Total + "')");
                        DataTable dt = D.GetDataTable("select id from OrderMaster where CID = '" + customerid + "' order by id desc");
                        for (int i = 0; i < cnt; i++)
                        {
                            id = (new System.Web.UI.WebControls.ListItem(_Items[i].ID).ToString());
                            unit = (new System.Web.UI.WebControls.ListItem(_Items[i].Unit).ToString());
                            qty = (new System.Web.UI.WebControls.ListItem(_Items[i].Qty).ToString());
                            amount = (new System.Web.UI.WebControls.ListItem(_Items[i].Amount).ToString());
                            string query = "insert into OrderItems(OID,IID,Unit,Qty,Amount) values('" + dt.Rows[0]["id"].ToString() + "','" + id + "','" + unit + "','" + qty + "','" + amount + "')";
                            D.ExecuteQuery(query);

                            string outkg = "1";
                            string outpcs = "1";
                            string kgqty = "0";
                            string pcsqty = "0";
                            if (unit == "G" || unit == "KG")
                            {
                                kgqty = qty;
                                outpcs = "0";
                            }
                            else
                            {
                                pcsqty = qty;
                                outkg = "0";
                            }
                            DataTable dt4 = D.GetDataTable("select * from Stock where iid = " + id);
                            if (dt4.Rows.Count == 0)
                            {
                                D.ExecuteQuery("insert into Stock (IID) values(" + id + ")");
                                D.ExecuteQuery("Update Stock set OutKg+=" + outkg + ",OutPcs+=" + outpcs + ",OnhandKg-=" + kgqty + ",OnhandPcs-=" + pcsqty + " where IID = " + id);
                            }
                            else
                            {
                                D.ExecuteQuery("Update Stock set OutKg+=" + outkg + ",OutPcs+=" + outpcs + ",OnhandKg-=" + kgqty + ",OnhandPcs-=" + pcsqty + " where IID = " + id);
                            }

                        }

                        GeneralData data = new GeneralData();
                        data.MESSAGE = "Successfully!";
                        data.ORIGINAL_ERROR = "Successfully Inserted!";
                        data.ERROR_STATUS = false;
                        data.RECORDS = false;
                        g.Add(data);
                        Context.Response.Write(js.Serialize(g[0]));
                    }
                    else
                    {
                        GeneralData data = new GeneralData();
                        data.MESSAGE = "This Customer Order Already Taken Today!";
                        data.ORIGINAL_ERROR = "This Customer Order Already Taken Today!";
                        data.ERROR_STATUS = false;
                        data.RECORDS = false;
                        g.Add(data);
                        Context.Response.Write(js.Serialize(g[0]));
                    }
                }
                else
                {
                    GeneralData data = new GeneralData();
                    data.MESSAGE = "Please Select The Item";
                    data.ORIGINAL_ERROR = "Please Select The Item";
                    data.ERROR_STATUS = true;
                    data.RECORDS = false;
                    g.Add(data);
                    Context.Response.Write(js.Serialize(g[0]));
                }


            }
            catch (Exception ex)
            {
                GeneralData data = new GeneralData();
                data.MESSAGE = "Failed To Show";
                data.ORIGINAL_ERROR = ex.Message;
                data.ERROR_STATUS = true;
                data.RECORDS = false;
                g.Add(data);
                Context.Response.Write(js.Serialize(g[0]));
            }



        }
    }


    [WebMethod]
    public void ViewOrder(string type, string date)
    {
        JavaScriptSerializer js = new JavaScriptSerializer();
        int i = 0;
        List<Order> list = new List<Order>();
        List<GeneralDataCustomerOrder> g = new List<GeneralDataCustomerOrder>();
        string qry = "";
        try
        {
            if (type == "order")
            {
                qry = "select o.id as oid,* from OrderMaster as o,CustomerMaster as c where o.cid = c.id and o.date = '" + date + "'";
                DataTable dt2 = D.GetDataTable(qry);
                if (dt2.Rows.Count != 0)
                {
                    for (i = 0; i <= dt2.Rows.Count - 1; i++)
                    {
                        Order hc = new Order();
                        hc.orderid = dt2.Rows[i]["oid"].ToString();
                        hc.customername = dt2.Rows[i]["name"].ToString();
                        hc.mobile = dt2.Rows[i]["mobile"].ToString();
                        hc.wmobile = dt2.Rows[i]["Wifemobile"].ToString();
                        hc.address = dt2.Rows[i]["address"].ToString();
                        hc.total = dt2.Rows[i]["total"].ToString();
                        List<OrderItem> itemlist = new List<OrderItem>();
                        DataTable dt = D.GetDataTable("select * from OrderItems as o,ItemMaster as i where o.iid = i.id and oid = " + dt2.Rows[i]["oid"].ToString());
                        if (dt.Rows.Count != 0)
                        {
                            for (int j = 0; j <= dt.Rows.Count - 1; j++)
                            {
                                OrderItem oi = new OrderItem();
                                oi.ID = dt.Rows[j]["iid"].ToString();
                                oi.Name = dt.Rows[j]["engname"].ToString();
                                if (dt.Rows[j]["image"].ToString() != "")
                                {
                                    oi.Image = website + dt.Rows[j]["image"].ToString();
                                }
                                else
                                {
                                    oi.Image = website + "Resources/Images/Default2.jpg";
                                }
                                oi.Unit = dt.Rows[j]["Unit"].ToString();
                                oi.Qty = dt.Rows[j]["Qty"].ToString();
                                oi.Amount = dt.Rows[j]["Amount"].ToString();
                                oi.Desc = dt.Rows[j]["description"].ToString();
                                itemlist.Add(oi);
                            }
                        }
                        hc.Items = itemlist;
                        list.Add(hc);

                    }
                    GeneralDataCustomerOrder data = new GeneralDataCustomerOrder();
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
                    GeneralDataCustomerOrder data = new GeneralDataCustomerOrder();
                    data.MESSAGE = "Data Not Available";
                    data.ORIGINAL_ERROR = "";
                    data.ERROR_STATUS = false;
                    data.RECORDS = false;
                    g.Add(data);
                    Context.Response.Write(js.Serialize(g[0]));
                }
            }
        }
        catch (Exception ex)
        {
            GeneralDataCustomerOrder data = new GeneralDataCustomerOrder();
            data.MESSAGE = "Failed";
            data.ORIGINAL_ERROR = ex.Message;
            data.ERROR_STATUS = true;
            data.RECORDS = false;
            g.Add(data);
            Context.Response.Write(js.Serialize(g[0]));
        }

    }

    [WebMethod]
    public void TrackOrder(string type, string mobile)
    {
        JavaScriptSerializer js = new JavaScriptSerializer();
        int i = 0;
        List<Order> list = new List<Order>();
        List<GeneralDataCustomerOrder> g = new List<GeneralDataCustomerOrder>();
        string qry = "";
        try
        {
            if (type == "order")
            {
                qry = "select CustomerMaster.Name,OrderMaster.* from CustomerMaster right join OrderMaster ON CustomerMaster.Id = OrderMaster.CID where Mobile='" + mobile + "'";
                DataTable dt2 = D.GetDataTable(qry);
                if (dt2.Rows.Count != 0)
                {
                    for (i = 0; i <= dt2.Rows.Count - 1; i++)
                    {
                        Order hc = new Order();
                        hc.orderid = dt2.Rows[i]["Id"].ToString();
                        hc.customername = dt2.Rows[i]["Name"].ToString();
                        hc.date = dt2.Rows[i]["Date"].ToString();
                        //hc.mobile = dt2.Rows[i]["mobile"].ToString();
                        //hc.wmobile = dt2.Rows[i]["Wifemobile"].ToString();
                        //hc.address = dt2.Rows[i]["address"].ToString();
                        hc.total = dt2.Rows[i]["Total"].ToString();
                        
                        //hc.Items = itemlist;
                        list.Add(hc);

                    }
                    GeneralDataCustomerOrder data = new GeneralDataCustomerOrder();
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
                    GeneralDataCustomerOrder data = new GeneralDataCustomerOrder();
                    data.MESSAGE = "Data Not Available";
                    data.ORIGINAL_ERROR = "";
                    data.ERROR_STATUS = false;
                    data.RECORDS = false;
                    g.Add(data);
                    Context.Response.Write(js.Serialize(g[0]));
                }
            }
        }
        catch (Exception ex)
        {
            GeneralDataCustomerOrder data = new GeneralDataCustomerOrder();
            data.MESSAGE = "Failed";
            data.ORIGINAL_ERROR = ex.Message;
            data.ERROR_STATUS = true;
            data.RECORDS = false;
            g.Add(data);
            Context.Response.Write(js.Serialize(g[0]));
        }

    }

    [WebMethod]
    public void TrackOrderitems(string type,string orderid)
    {
        JavaScriptSerializer js = new JavaScriptSerializer();
        int i = 0;
        List<OrderItem> list = new List<OrderItem>();
        List<GeneralDataCustomerOrder> g = new List<GeneralDataCustomerOrder>();
        string qry = "";
        try
        {
            if (type == "order")
            {
                qry = "select oi.*,i.engname,i.image,om.total from OrderItems as oi,ItemMaster as i,OrderMaster as om where i.id = oi.iid and oi.oid = om.id and oi.oid = '" + orderid + "'";
                DataTable dt2 = D.GetDataTable(qry);
                if (dt2.Rows.Count != 0)
                {
                    for (i = 0; i <= dt2.Rows.Count - 1; i++)
                    {
                        OrderItem hc = new OrderItem();
                        hc.ID = dt2.Rows[i]["IID"].ToString();
                        hc.Image = dt2.Rows[i]["image"].ToString();
                        hc.Name = dt2.Rows[i]["engname"].ToString();
                        hc.Unit = dt2.Rows[i]["Unit"].ToString();
                        hc.Qty = dt2.Rows[i]["Qty"].ToString();
                        hc.Amount = dt2.Rows[i]["Amount"].ToString();

                        list.Add(hc);

                    }
                    GeneralDataCustomerOrder data2 = new GeneralDataCustomerOrder();
                    data2.MESSAGE = "Successfully !";
                    data2.ORIGINAL_ERROR = "";
                    data2.ERROR_STATUS = false;
                    data2.RECORDS = true;
                    data2.Data2 = list;
                    g.Add(data2);
                    Context.Response.Write(js.Serialize(g[0]));
                }
                else
                {
                    GeneralDataCustomerOrder data = new GeneralDataCustomerOrder();
                    data.MESSAGE = "Data Not Available";
                    data.ORIGINAL_ERROR = "";
                    data.ERROR_STATUS = false;
                    data.RECORDS = false;
                    g.Add(data);
                    Context.Response.Write(js.Serialize(g[0]));
                }
            }
        }
        catch (Exception ex)
        {
            GeneralDataCustomerOrder data = new GeneralDataCustomerOrder();
            data.MESSAGE = "Failed";
            data.ORIGINAL_ERROR = ex.Message;
            data.ERROR_STATUS = true;
            data.RECORDS = false;
            g.Add(data);
            Context.Response.Write(js.Serialize(g[0]));
        }

    }

    [WebMethod]
    public void GetItemData(string type, string Search)
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
                if (Search == "")
                {
                    qry = "select *,engname as name from ItemMaster ORDER BY EngName";
                }
                else
                {
                    qry = "select *,engname as name from ItemMaster where engname like '%" + Search + "%'";
                }


                DataTable dt2 = D.GetDataTable(qry);
                if (dt2.Rows.Count != 0)
                {
                    for (i = 0; i <= dt2.Rows.Count - 1; i++)
                    {
                        ItemMaster hc = new ItemMaster();
                        hc.id = dt2.Rows[i]["Id"].ToString();
                        hc.name = dt2.Rows[i]["name"].ToString();
                        if (dt2.Rows[i]["kgprice"].ToString() == "0.00")
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
                        hc.kgprice = Convert.ToDouble(dt2.Rows[i]["Retailkgprice"].ToString());
                        hc.pcsprice = Convert.ToDouble(dt2.Rows[i]["Retailpcsprice"].ToString());
                        if (dt2.Rows[i]["image"].ToString() != "")
                        {
                            hc.image = website + dt2.Rows[i]["image"].ToString();
                        }
                        else
                        {
                            hc.image = website + "Resources/Images/Default2.jpg";
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
    public void GetItemDataByCat(string type, string Catname)
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

                qry = "SELECT i.*,i.engname as name FROM itemmaster as i left join CategoryMaster as c on c.id = i.cid where c.name = '" + Catname + "'";
                DataTable dt2 = D.GetDataTable(qry);
                if (dt2.Rows.Count != 0)
                {
                    for (i = 0; i <= dt2.Rows.Count - 1; i++)
                    {
                        ItemMaster hc = new ItemMaster();
                        hc.id = dt2.Rows[i]["Id"].ToString();
                        hc.name = dt2.Rows[i]["name"].ToString();
                        if (dt2.Rows[i]["kgprice"].ToString() == "0.00")
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
                        hc.kgprice = Convert.ToDouble(dt2.Rows[i]["Retailkgprice"].ToString());
                        hc.pcsprice = Convert.ToDouble(dt2.Rows[i]["Retailpcsprice"].ToString());
                        if (dt2.Rows[i]["image"].ToString() != "")
                        {
                            hc.image = website + dt2.Rows[i]["image"].ToString();
                        }
                        else
                        {
                            hc.image = website + "Resources/Images/Default2.jpg";
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
    public void GetBannerData(string type)
    {
        JavaScriptSerializer js = new JavaScriptSerializer();
        int i = 0;
        string qry = "";
        List<Banner> list = new List<Banner>();
        List<GeneralDataBanner2> g = new List<GeneralDataBanner2>();
        if (type == "banner")
        {
            try
            {
                qry = "select * from banner";
                DataTable dt2 = D.GetDataTable(qry);
                if (dt2.Rows.Count != 0)
                {
                    for (i = 0; i <= dt2.Rows.Count - 1; i++)
                    {
                        Banner hc = new Banner();
                        hc.image = websiteclient + dt2.Rows[i]["image"].ToString();

                        list.Add(hc);

                    }
                    GeneralDataBanner2 data = new GeneralDataBanner2();
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
                    GeneralDataBanner2 data = new GeneralDataBanner2();
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
                GeneralDataBanner2 data = new GeneralDataBanner2();
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
    public void GetBestSellerItemData(string type)
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

                qry = "select *,engname as name from ItemMaster where id in (select iid from Bestseller)";
                DataTable dt2 = D.GetDataTable(qry);
                if (dt2.Rows.Count != 0)
                {
                    for (i = 0; i <= dt2.Rows.Count - 1; i++)
                    {
                        ItemMaster hc = new ItemMaster();
                        hc.id = dt2.Rows[i]["Id"].ToString();
                        hc.name = dt2.Rows[i]["name"].ToString();
                        hc.kgprice = Convert.ToDouble(dt2.Rows[i]["Retailkgprice"].ToString());
                        hc.pcsprice = Convert.ToDouble(dt2.Rows[i]["Retailpcsprice"].ToString());
                        if (dt2.Rows[i]["image"].ToString() != "")
                        {
                            hc.image = website + dt2.Rows[i]["image"].ToString();
                        }
                        else
                        {
                            hc.image = website + "Resources/Images/Default2.jpg";
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
    public void GetNewProductData(string type)
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

                qry = "select *,engname as name from ItemMaster where id in (select iid from Bestseller)";
                DataTable dt2 = D.GetDataTable(qry);
                if (dt2.Rows.Count != 0)
                {
                    for (i = 0; i <= dt2.Rows.Count - 1; i++)
                    {
                        ItemMaster hc = new ItemMaster();
                        hc.id = dt2.Rows[i]["Id"].ToString();
                        hc.name = dt2.Rows[i]["name"].ToString();
                        hc.kgprice = Convert.ToDouble(dt2.Rows[i]["Retailkgprice"].ToString());
                        hc.pcsprice = Convert.ToDouble(dt2.Rows[i]["Retailpcsprice"].ToString());
                        if (dt2.Rows[i]["image"].ToString() != "")
                        {
                            hc.image = website + dt2.Rows[i]["image"].ToString();
                        }
                        else
                        {
                            hc.image = website + "Resources/Images/Default2.jpg";
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
    public void InsertItem(string type, string cid, string engname, string hndname, string gujname, string hkgprice, string hpcsprice, string rkgprice, string rpcsprice, string marginkg, string marginpcs, string imagecode)
    {
        List<GeneralData> g = new List<GeneralData>();
        JavaScriptSerializer js = new JavaScriptSerializer();

        if (type == "item")
        {
            try
            {
                string img_name = "";
                if (imagecode != "")
                {
                    Random rd = new Random();
                    int no = rd.Next();

                    imagecode = imagecode.Replace(" ", "");
                    byte[] imageBytes = Convert.FromBase64String(imagecode);
                    MemoryStream ms = new MemoryStream(imageBytes, 0, imageBytes.Length);
                    ms.Write(imageBytes, 0, imageBytes.Length);
                    System.Drawing.Image image = System.Drawing.Image.FromStream(ms, true);
                    string uplod_path = Server.MapPath("Resources/Profile/Img" + no + ".jpg");
                    image.Save(uplod_path);
                    //img = "Resources/Images/" + no + ext;
                    img_name = "Resources/Images/Img" + no + ".jpg";
                }
                SqlCommand cmd = new SqlCommand();
                cmd.Parameters.AddWithValue("@CID", cid);
                cmd.Parameters.AddWithValue("@ENG", engname);
                cmd.Parameters.AddWithValue("@HND", hndname);
                cmd.Parameters.AddWithValue("@GUJ", gujname);
                cmd.Parameters.AddWithValue("@KGPRICE", hkgprice);
                cmd.Parameters.AddWithValue("@PCSPRICE", hpcsprice);
                cmd.Parameters.AddWithValue("@RKGPRICE", rkgprice);
                cmd.Parameters.AddWithValue("@RPCSPRICE", rpcsprice);
                cmd.Parameters.AddWithValue("@MKG", marginkg);
                cmd.Parameters.AddWithValue("@MPCS", marginpcs);
                cmd.Parameters.AddWithValue("@FILE", img_name);
                cmd.Connection = cn;
                cmd.CommandText = "insert into ItemMaster (CID,EngName,HindiName,GujaratiName,kgprice,pcsprice,Image,RetailKgPrice,RetailPcsPrice,MarginKg,MarginPcs) values(@CID,@ENG,@HND,@GUJ,@KGPRICE,@PCSPRICE,@FILE,@RKGPRICE,@RPCSPRICE,@MKG,@MPCS)";
                cn.Open();
                cmd.ExecuteNonQuery();
                cn.Close();
                DataTable dt = new DataTable();
                dt = D.GetDataTable("select top 1 id from ItemMaster where engname = '" + engname + "' order by id desc");
                D.ExecuteQuery("insert into Stock (iid) values(" + dt.Rows[0]["id"].ToString() + ")");
                GeneralData data = new GeneralData();
                data.MESSAGE = "Successfully Inserted!";
                data.ORIGINAL_ERROR = "Successfully Inserted!";
                data.ERROR_STATUS = false;
                data.RECORDS = false;
                g.Add(data);
                Context.Response.Write(js.Serialize(g[0]));



            }
            catch (Exception ex)
            {
                GeneralData data = new GeneralData();
                data.MESSAGE = "Failed To Insert";
                data.ORIGINAL_ERROR = ex.Message;
                data.ERROR_STATUS = true;
                data.RECORDS = false;
                g.Add(data);
                Context.Response.Write(js.Serialize(g[0]));
            }



        }
    }
    [WebMethod]
    public void AddCustomer(string type, string Name, string Mobile, string WMobile, string email, string Address, string flatno, string society, string building, string area)
    {
        JavaScriptSerializer js = new JavaScriptSerializer();
        List<GeneralData> g = new List<GeneralData>();
        if (type == "customer")
        {
            try
            {
                D.ExecuteQuery("insert into CustomerMaster (Name,Mobile,WifeMobile,Email,Address,FlatNo,Society,Building,Area) values('" + Name + "','" + Mobile + "','" + WMobile + "','" + email + "','" + Address + "','" + flatno + "','" + society + "','" + building + "','" + area + "')");
                DataTable dt = D.GetDataTable("select id from CustomerMaster where name = '" + Name + "' order by id desc");
                GeneralData data = new GeneralData();
                data.MESSAGE = "Successfully Inserted!";
                data.ORIGINAL_ERROR = "Successfully Inserted!";
                data.ERROR_STATUS = false;
                data.RECORDS = false;
                g.Add(data);
                Context.Response.Write(js.Serialize(g[0]));
            }
            catch (Exception ex)
            {
                GeneralData data = new GeneralData();
                data.MESSAGE = "Failed To Insert";
                data.ORIGINAL_ERROR = ex.Message;
                data.ERROR_STATUS = true;
                data.RECORDS = false;
                g.Add(data);
                Context.Response.Write(js.Serialize(g[0]));
            }
        }

    }

    [WebMethod]
    public void RecentOrder(string type)
    {
        JavaScriptSerializer js = new JavaScriptSerializer();
        int i = 0;
        List<Order> list = new List<Order>();
        List<GeneralDataCustomerOrder> g = new List<GeneralDataCustomerOrder>();
        string qry = "";
        try
        {
            if (type == "order")
            {
                qry = "select top 5 o.id as oid,* from OrderMaster as o,CustomerMaster as c where o.cid = c.id order by o.id desc";
                DataTable dt2 = D.GetDataTable(qry);
                if (dt2.Rows.Count != 0)
                {
                    for (i = 0; i <= dt2.Rows.Count - 1; i++)
                    {
                        Order hc = new Order();
                        hc.orderid = dt2.Rows[i]["oid"].ToString();
                        hc.customername = dt2.Rows[i]["name"].ToString();
                        hc.mobile = dt2.Rows[i]["mobile"].ToString();
                        hc.wmobile = dt2.Rows[i]["Wifemobile"].ToString();
                        hc.address = dt2.Rows[i]["address"].ToString();
                        hc.total = dt2.Rows[i]["total"].ToString();
                        hc.status = dt2.Rows[i]["status"].ToString();
                        List<OrderItem> itemlist = new List<OrderItem>();
                        DataTable dt = D.GetDataTable("select * from OrderItems as o,ItemMaster as i where o.iid = i.id and oid = " + dt2.Rows[i]["oid"].ToString());
                        if (dt.Rows.Count != 0)
                        {
                            for (int j = 0; j <= dt.Rows.Count - 1; j++)
                            {
                                OrderItem oi = new OrderItem();
                                oi.ID = dt.Rows[j]["iid"].ToString();
                                oi.Name = dt.Rows[j]["engname"].ToString();
                                if (dt.Rows[j]["image"].ToString() != "")
                                {
                                    oi.Image = website + dt.Rows[j]["image"].ToString();
                                }
                                else
                                {
                                    oi.Image = website + "Resources/Images/Default2.jpg";
                                }
                                oi.Unit = dt.Rows[j]["Unit"].ToString();
                                oi.Qty = dt.Rows[j]["Qty"].ToString();
                                oi.Amount = dt.Rows[j]["Amount"].ToString();
                                oi.Desc = dt.Rows[j]["description"].ToString();
                                itemlist.Add(oi);
                            }
                        }
                        hc.Items = itemlist;
                        list.Add(hc);

                    }
                    GeneralDataCustomerOrder data = new GeneralDataCustomerOrder();
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
                    GeneralDataCustomerOrder data = new GeneralDataCustomerOrder();
                    data.MESSAGE = "Data Not Available";
                    data.ORIGINAL_ERROR = "";
                    data.ERROR_STATUS = false;
                    data.RECORDS = false;
                    g.Add(data);
                    Context.Response.Write(js.Serialize(g[0]));
                }
            }
        }
        catch (Exception ex)
        {
            GeneralDataCustomerOrder data = new GeneralDataCustomerOrder();
            data.MESSAGE = "Failed";
            data.ORIGINAL_ERROR = ex.Message;
            data.ERROR_STATUS = true;
            data.RECORDS = false;
            g.Add(data);
            Context.Response.Write(js.Serialize(g[0]));
        }

    }

    [WebMethod]
    public void ViewOrderNew(string type, string date, string customer)
    {
        JavaScriptSerializer js = new JavaScriptSerializer();
        int i = 0;
        List<Order> list = new List<Order>();
        List<GeneralDataCustomerOrder> g = new List<GeneralDataCustomerOrder>();
        string qry = "";
        string customerqry = "";
        if (customer != "0")
        {
            customerqry = " and c.id = " + customer;
        }
        try
        {
            if (type == "pendingorder")
            {

                qry = "select o.id as oid,* from OrderMaster as o,CustomerMaster as c where o.status = 0 and o.cid = c.id and o.date = '" + date + "'" + customerqry;
            }
            else if (type == "completeorder")
            {
                qry = "select o.id as oid,* from OrderMaster as o,CustomerMaster as c where o.status = 1 and o.cid = c.id and o.date = '" + date + "'" + customerqry;
            }
            else
            {
                return;
            }
            DataTable dt2 = D.GetDataTable(qry);
            if (dt2.Rows.Count != 0)
            {
                for (i = 0; i <= dt2.Rows.Count - 1; i++)
                {
                    Order hc = new Order();
                    hc.orderid = dt2.Rows[i]["oid"].ToString();
                    hc.customername = dt2.Rows[i]["name"].ToString();
                    hc.mobile = dt2.Rows[i]["mobile"].ToString();
                    hc.wmobile = dt2.Rows[i]["Wifemobile"].ToString();
                    hc.address = dt2.Rows[i]["address"].ToString();
                    hc.total = dt2.Rows[i]["total"].ToString();
                    hc.status = dt2.Rows[i]["status"].ToString();
                    List<OrderItem> itemlist = new List<OrderItem>();
                    DataTable dt = D.GetDataTable("select * from OrderItems as o,ItemMaster as i where o.iid = i.id and oid = " + dt2.Rows[i]["oid"].ToString());
                    if (dt.Rows.Count != 0)
                    {
                        for (int j = 0; j <= dt.Rows.Count - 1; j++)
                        {
                            OrderItem oi = new OrderItem();
                            oi.ID = dt.Rows[j]["iid"].ToString();
                            oi.Name = dt.Rows[j]["engname"].ToString();
                            if (dt.Rows[j]["image"].ToString() != "")
                            {
                                oi.Image = website + dt.Rows[j]["image"].ToString();
                            }
                            else
                            {
                                oi.Image = website + "Resources/Images/Default2.jpg";
                            }
                            oi.Unit = dt.Rows[j]["Unit"].ToString();
                            oi.Qty = dt.Rows[j]["Qty"].ToString();
                            oi.Amount = dt.Rows[j]["Amount"].ToString();
                            oi.Desc = dt.Rows[j]["description"].ToString();
                            itemlist.Add(oi);
                        }
                    }
                    hc.Items = itemlist;
                    list.Add(hc);

                }
                GeneralDataCustomerOrder data = new GeneralDataCustomerOrder();
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
                GeneralDataCustomerOrder data = new GeneralDataCustomerOrder();
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
            GeneralDataCustomerOrder data = new GeneralDataCustomerOrder();
            data.MESSAGE = "Failed";
            data.ORIGINAL_ERROR = ex.Message;
            data.ERROR_STATUS = true;
            data.RECORDS = false;
            g.Add(data);
            Context.Response.Write(js.Serialize(g[0]));
        }

    }

    [WebMethod]
    public void DeleteOrder(string type, string oid)
    {
        List<GeneralData> g = new List<GeneralData>();
        JavaScriptSerializer js = new JavaScriptSerializer();
        if (type == "order")
        {
            try
            {
                D.ExecuteQuery("delete from OrderItems where oid = " + oid);
                D.ExecuteQuery("delete from OrderMaster where id = " + oid);
                GeneralData data = new GeneralData();
                data.MESSAGE = "Successfully Deleted!";
                data.ORIGINAL_ERROR = "Successfully Deleted!";
                data.ERROR_STATUS = false;
                data.RECORDS = false;
                g.Add(data);
                Context.Response.Write(js.Serialize(g[0]));
            }
            catch (Exception ex)
            {
                GeneralData data = new GeneralData();
                data.MESSAGE = "Failed To Delete";
                data.ORIGINAL_ERROR = ex.Message;
                data.ERROR_STATUS = true;
                data.RECORDS = false;
                g.Add(data);
                Context.Response.Write(js.Serialize(g[0]));
            }
        }
    }
    [WebMethod]
    public void Deleteitem(string type, string itemid)
    {
        List<GeneralData> g = new List<GeneralData>();
        JavaScriptSerializer js = new JavaScriptSerializer();
        if (type == "delete")
        {
            try
            {
                D.ExecuteQuery("DELETE FROM Cart WHERE id = " + itemid);
                GeneralData data = new GeneralData();
                data.MESSAGE = "Successfully Deleted!";
                //data.ORIGINAL_ERROR = "Successfully Deleted!";
                data.ERROR_STATUS = false;
                data.RECORDS = false;
                g.Add(data);
                Context.Response.Write(js.Serialize(g[0]));
            }
            catch (Exception ex)
            {
                GeneralData data = new GeneralData();
                data.MESSAGE = "Failed To Delete";
                data.ORIGINAL_ERROR = ex.Message;
                data.ERROR_STATUS = true;
                data.RECORDS = false;
                g.Add(data);
                Context.Response.Write(js.Serialize(g[0]));
            }
        }
    }
    [WebMethod]
    public void Deleteallitem(string type)
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
        if (type == "delete")
        {
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

    }
	[WebMethod]
    public void AddCartData(string itemkgprice,string unit,string itemid,string Qty,Int32 pick)
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

    public void AddCartData2(string itempcsprice, string unit, string itemid, string Qty,Int32 pick)
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

            data.MESSAGE = "Successfully Inserted!";
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
                            hc.pick = dt2.Rows[i]["Pick"].ToString();
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
 public void CartCount(string type)
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

     //List<ItemMaster> list = new List<ItemMaster>();
     List<ItemCount> list = new List<ItemCount>();
     List<GeneralDataItem2> g = new List<GeneralDataItem2>();
     if (type == "count")
     {
         try
         {
             DataTable dt2 = D.GetDataTable("select COUNT(id) AS count from cart where ipaddress='" + Ipadd + "'");

             //DataTable dt2 = D.GetDataTable(qry);

             if (dt2.Rows.Count != 0)
             {

                 for (i = 0; i <= dt2.Rows.Count - 1; i++)
                 {
                     ItemCount hc = new ItemCount();

                    
                     hc.count = dt2.Rows[i]["count"].ToString();
                    
                     list.Add(hc);

                 }


                 GeneralDataItem2 data = new GeneralDataItem2();
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
                 GeneralDataItem2 data = new GeneralDataItem2();
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
             GeneralDataItem2 data = new GeneralDataItem2();
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
    public void placeorder(string mob,string grandtotal)
    {
      
        JavaScriptSerializer js = new JavaScriptSerializer();
        int i = 0;
        string qry = "";
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
    public void placeorder2(string mob, string name, string address, string grandtotal)
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
                D.ExecuteQuery("insert into OrderMaster (Date,Time,CID,Total) values('" + date + "','" + time + "','" + hc.cid + "','" + hc.total + "')");


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
    

}
 




