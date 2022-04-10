﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;


public class Connection
{
    SqlConnection cnn = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["DigitalCardConnection"].ConnectionString.ToString());
    public Connection()
    {
    }
    public int GetMaxId(string SqlQuery)
    {
        int id = 0;
        DataTable dt = new DataTable();
        try
        {
            SqlCommand cm = new SqlCommand(SqlQuery, cnn);
            cnn.Open();
            cm.ExecuteNonQuery();
            cnn.Close();
            SqlDataAdapter da = new SqlDataAdapter(cm);
            da.Fill(dt);
            if (dt.Rows.Count != 0)
            {
                id = Convert.ToInt32(dt.Rows[0][0].ToString());
            }
        }
        catch (System.Data.SqlClient.SqlException ex)
        {
            string msg = "Fetch Error:";
            msg += ex.Message;
            throw new Exception(msg);
        }
        return id;
    }
    public DataTable GetDataTable(string strqry)
    {
        DataTable dt = new DataTable();
        try
        {
            SqlCommand cm = new SqlCommand(strqry, cnn);
            cnn.Close();
            cnn.Open();
            cm.ExecuteNonQuery();
            SqlDataAdapter da = new SqlDataAdapter(cm);
            da.Fill(dt);
        }
        catch (System.Data.SqlClient.SqlException ex)
        {
            string msg = "Fetch Error:";
            msg += ex.Message;
            if (msg.Contains("Connection Timeout Expired"))
            {
                HttpContext.Current.Response.Redirect("~/Admin/500.html", false);
            }
            else
            {
                throw new Exception(msg);
            }


        }
        finally
        {
            cnn.Close();
        }
        return dt;
    }
    public void ExecuteQuery(string qry)
    {
        cnn.Open();
        SqlCommand cmd = new SqlCommand();
        cmd.Connection = cnn;
        cmd.CommandText = qry;
        cmd.ExecuteNonQuery();
        cnn.Close();
    }
	 public void ExecuteQueryBySP(SqlCommand scmd)
    {
        cnn.Open();
        SqlCommand cmd = scmd;
        cmd.Connection = cnn;
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.ExecuteNonQuery();
        cnn.Close();
    }

    public DataTable GetData(string qry)
    {
        DataTable dt = new DataTable();
        try
        {
            cnn.Open();
            SqlCommand cmd = new SqlCommand(qry, cnn);
            SqlDataAdapter da = new SqlDataAdapter();
            cmd.ExecuteNonQuery();
            da.SelectCommand = cmd;
            da.Fill(dt);
            cnn.Close();

        }
        catch (Exception ex)
        {

        }
        return dt;

    }
}
public class getnotificationdata
{
    public string success { get; set; }
    public string failure { get; set; }
}

public class GeneralDataCylinder
{
    public string MESSAGE { get; set; }
    public string ORIGINAL_ERROR { get; set; }
    public Boolean ERROR_STATUS { get; set; }
    //public int STATUS { get; set; }
    public Boolean RECORDS { get; set; }

    public List<CylinderMaster> Data { get; set; }
}
public class CylinderMaster
{
    public string id { get; set; }
    public string CylinderNo { get; set; }
    
}
public class GeneralDataCustomer
{
    public string MESSAGE { get; set; }
    public string ORIGINAL_ERROR { get; set; }
    public Boolean ERROR_STATUS { get; set; }
    //public int STATUS { get; set; }
    public Boolean RECORDS { get; set; }

    public List<CustomerMaster> Data { get; set; }
}

public class GeneralData
{
    public string MESSAGE { get; set; }
    public string ORIGINAL_ERROR { get; set; }
    public Boolean ERROR_STATUS { get; set; }
    //public int STATUS { get; set; }
    public Boolean RECORDS { get; set; }
}

public class GeneralDataUser
{
    public string MESSAGE { get; set; }
    public string ORIGINAL_ERROR { get; set; }
    public Boolean ERROR_STATUS { get; set; }
    //public int STATUS { get; set; }
    public Boolean RECORDS { get; set; }

    public List<UserMaster> Data { get; set; }
}
public class UserMaster
{
    public string clientid { get; set; }
    public string name { get; set; }
    public string mobile { get; set; }
    public string email { get; set; }
    public string username { get; set; }
    public string password { get; set; }
    public string stateid { get; set; }
    public string state { get; set; }
    public string cityid { get; set; }
    public string city { get; set; }
    public string logintype { get; set; }
    public string verificationstatus { get; set; }



}

public class OrderItem
{
    public string ID { get; set; }
    public string Name { get; set; }
    public string Image { get; set; }
    public string Unit { get; set; }
    public string Qty { get; set; }
    public string Amount { get; set; }
    public string Desc { get; set; }
}

public class GeneralDataReviewData
{
    public string MESSAGE { get; set; }
    public string ORIGINAL_ERROR { get; set; }
    public Boolean ERROR_STATUS { get; set; }
    //public int STATUS { get; set; }
    public Boolean RECORDS { get; set; }

    public List<ReviewData> Data { get; set; }
}
public class ReviewData
{
    public string reviewid { get; set; }
    public string schoolname { get; set; }
    public string reviewer { get; set; }
    public string designation { get; set; }
    public string stateid { get; set; }
    public string state { get; set; }
    public string cityid { get; set; }
    public string city { get; set; }

    public string review { get; set; }
    public string ratingbox { get; set; }
    public string noofstudent { get; set; }
    public string date { get; set; }



}

public class GeneralDataCity
{
    public string MESSAGE { get; set; }
    public string ORIGINAL_ERROR { get; set; }
    public Boolean ERROR_STATUS { get; set; }
    //public int STATUS { get; set; }
    public Boolean RECORDS { get; set; }

    public List<CityMaster> Data { get; set; }
}
public class CityMaster
{
    public string id { get; set; }
    public string city { get; set; }
    public string stateid { get; set; }
}
public class GeneralDataState
{
    public string MESSAGE { get; set; }
    public string ORIGINAL_ERROR { get; set; }
    public Boolean ERROR_STATUS { get; set; }
    //public int STATUS { get; set; }
    public Boolean RECORDS { get; set; }

    public List<StateMaster> Data { get; set; }
}
public class StateMaster
{
    public string stateid { get; set; }
    public string name { get; set; }
    public string type { get; set; }
}


public class GeneralDataTour
{
    public string MESSAGE { get; set; }
    public string ORIGINAL_ERROR { get; set; }
    public Boolean ERROR_STATUS { get; set; }
    //public int STATUS { get; set; }
    public Boolean RECORDS { get; set; }

    public List<Tour> Data { get; set; }
}
public class Tour
{
    public string visiontitle { get; set; }
    public string visiondesc { get; set; }
    public string schooltitle { get; set; }
    public string schooldesc { get; set; }
    public string prospecttitle { get; set; }
    public string prospectdesc { get; set; }


}
public class GeneralDataStory
{
    public string MESSAGE { get; set; }
    public string ORIGINAL_ERROR { get; set; }
    public Boolean ERROR_STATUS { get; set; }
    //public int STATUS { get; set; }
    public Boolean RECORDS { get; set; }

    public List<Story> Data { get; set; }
}
public class Story
{
    public string storyid { get; set; }
    public string Title { get; set; }
    public string storydesc { get; set; }
    public string image { get; set; }
    public string link { get; set; }
    public string favourite { get; set; }
}
public class GeneralDataVideo
{
    public string MESSAGE { get; set; }
    public string ORIGINAL_ERROR { get; set; }
    public Boolean ERROR_STATUS { get; set; }
    //public int STATUS { get; set; }
    public Boolean RECORDS { get; set; }

    public List<Video> Data { get; set; }
}
public class Video
{
    public string videoid { get; set; }
    public string categoryid { get; set; }
    public string categoryname { get; set; }
    public string videotitle { get; set; }
    public string videourl { get; set; }
    public string favourite { get; set; }

}
public class GeneralDataVideoCategory
{
    public string MESSAGE { get; set; }
    public string ORIGINAL_ERROR { get; set; }
    public Boolean ERROR_STATUS { get; set; }
    //public int STATUS { get; set; }
    public Boolean RECORDS { get; set; }

    public List<VideoCategory> Data { get; set; }
}
public class VideoCategory
{
    public string categoryid { get; set; }
    public string categoryname { get; set; }
    public string categoryimg { get; set; }

}
public class GeneralDataQuotes
{
    public string MESSAGE { get; set; }
    public string ORIGINAL_ERROR { get; set; }
    public Boolean ERROR_STATUS { get; set; }
    //public int STATUS { get; set; }
    public Boolean RECORDS { get; set; }

    public List<Quotes> Data { get; set; }
}
public class Quotes
{
    public string quotesid { get; set; }
    public string title { get; set; }
    public string img { get; set; }
    public string favourite { get; set; }

}
public class GeneralDataaboutus
{
    public string MESSAGE { get; set; }
    public string ORIGINAL_ERROR { get; set; }
    public Boolean ERROR_STATUS { get; set; }
    //public int STATUS { get; set; }
    public Boolean RECORDS { get; set; }

    public List<aboutus> Data { get; set; }
}
public class aboutus
{
    public string mission { get; set; }
    public string vision { get; set; }
    public string expertise { get; set; }

}
public class GeneralDataContactUs
{
    public string MESSAGE { get; set; }
    public string ORIGINAL_ERROR { get; set; }
    public Boolean ERROR_STATUS { get; set; }
    //public int STATUS { get; set; }
    public Boolean RECORDS { get; set; }

    public List<ContactUs> Data { get; set; }
}
public class ContactUs
{
    public string Address { get; set; }
    public List<ContactUsNumber> Numbers { get; set; }

}
public class ContactUsNumber
{
    public string Id { get; set; }
    public string Name { get; set; }
    public string No { get; set; }
}
public class GeneralDataAlbum
{
    public string MESSAGE { get; set; }
    public string ORIGINAL_ERROR { get; set; }
    public Boolean ERROR_STATUS { get; set; }
    //public int STATUS { get; set; }
    public Boolean RECORDS { get; set; }

    public List<Album> Data { get; set; }
}
public class Album
{
    public string id { get; set; }
    public string name { get; set; }
    public string image { get; set; }

}
public class GeneralDataEvent
{
    public string MESSAGE { get; set; }
    public string ORIGINAL_ERROR { get; set; }
    public Boolean ERROR_STATUS { get; set; }
    //public int STATUS { get; set; }
    public Boolean RECORDS { get; set; }

    public List<Event> Data { get; set; }
}
public class Event
{
    public string id { get; set; }
    public string title { get; set; }
    public string image { get; set; }
    public string location { get; set; }
    public string date { get; set; }
    public string type { get; set; }
    public string latitude { get; set; }
    public string longitude { get; set; }
    public string address { get; set; }
    public string description { get; set; }
    public string favourite { get; set; }

}
public class GeneralDataEventDetail
{
    public string MESSAGE { get; set; }
    public string ORIGINAL_ERROR { get; set; }
    public Boolean ERROR_STATUS { get; set; }
    //public int STATUS { get; set; }
    public Boolean RECORDS { get; set; }
    public string Day { get; set; }
    public string Month { get; set; }
    public string Year { get; set; }
    public List<EventDetail> Data { get; set; }
}
public class EventDetail
{
    public string id { get; set; }
    public string name { get; set; }
    public string time { get; set; }
    public string price { get; set; }

}

public class GeneralDataBanner
{
    public string MESSAGE { get; set; }
    public string ORIGINAL_ERROR { get; set; }
    public Boolean ERROR_STATUS { get; set; }
    //public int STATUS { get; set; }
    public Boolean RECORDS { get; set; }

    //public List<Banner> Data { get; set; }
    public List<DetailData> Data { get; set; }
}
public class GeneralDataBanner2
{
    public string MESSAGE { get; set; }
    public string ORIGINAL_ERROR { get; set; }
    public Boolean ERROR_STATUS { get; set; }
    //public int STATUS { get; set; }
    public Boolean RECORDS { get; set; }

    public List<Banner> Data { get; set; }
    //public List<DetailData> Data { get; set; }
}
public class DetailData
{
    public List<Banner> BannerData { get; set; }
    public List<MenuDataDetail> MenuData { get; set; }


}
public class Banner
{
    public string id { get; set; }
    public string img { get; set; }
	 public string image { get; set; }
}
public class MenuDataDetail
{
    public string id { get; set; }
    public string name { get; set; }
    public string image { get; set; }
    public string bgimage { get; set; }
    public string sequence { get; set; }
    public string parentid { get; set; }
}

public class GeneralDataMenu
{
    public string MESSAGE { get; set; }
    public string ORIGINAL_ERROR { get; set; }
    public Boolean ERROR_STATUS { get; set; }
    //public int STATUS { get; set; }
    public Boolean RECORDS { get; set; }

    public List<Menu> Data { get; set; }
}
public class Menu
{
    public string id { get; set; }
    public string name { get; set; }
    public string image { get; set; }
    public string bgimage { get; set; }
    public string sequence { get; set; }
    public string parentid { get; set; }
    public List<MenuData> Detail { get; set; }

}
public class MenuData
{
    public string id { get; set; }
    public string name { get; set; }
    public string desc { get; set; }
    public string image { get; set; }
    public string link { get; set; }
    public string location { get; set; }
    public string date { get; set; }
    public string address { get; set; }


}
public class GeneralDataNgo
{
    public string MESSAGE { get; set; }
    public string ORIGINAL_ERROR { get; set; }
    public Boolean ERROR_STATUS { get; set; }
    //public int STATUS { get; set; }
    public Boolean RECORDS { get; set; }

    public List<Ngo> Data { get; set; }
}
public class Ngo
{
    public string id { get; set; }
    public string title { get; set; }
    public string totalschools { get; set; }
    public string totalstudents { get; set; }
    public string video { get; set; }
    public string ngotitle { get; set; }
    public string description { get; set; }
    public List<CalculateRate> Rates { get; set; }
    public List<ReviewDetail> Review { get; set; }
    public List<NgoDetail> Detail { get; set; }

}
public class NgoDetail
{
    public string detailid { get; set; }
    public string listname { get; set; }

}
public class CalculateRate
{
    public string star { get; set; }
    public string total { get; set; }

}
public class ReviewDetail
{
    public string reviewid { get; set; }
    public string userid { get; set; }
    public string name { get; set; }
    public string rating { get; set; }
    public string date { get; set; }
    public string description { get; set; }

}
public class GeneralDataReviewDetail
{
    public string MESSAGE { get; set; }
    public string ORIGINAL_ERROR { get; set; }
    public Boolean ERROR_STATUS { get; set; }
    //public int STATUS { get; set; }
    public Boolean RECORDS { get; set; }

    public List<ReviewDetail> Data { get; set; }
}
public class GeneralDataRecentTask
{
    public string MESSAGE { get; set; }
    public string ORIGINAL_ERROR { get; set; }
    public Boolean ERROR_STATUS { get; set; }
    //public int STATUS { get; set; }
    public Boolean RECORDS { get; set; }

    public List<RecentTask> Data { get; set; }
}
public class RecentTask
{
    public string id { get; set; }
    public string date { get; set; }
    public string title { get; set; }
    public string image { get; set; }
    public string shortdesc { get; set; }

}
public class GeneralDataRecentTaskDetail
{
    public string MESSAGE { get; set; }
    public string ORIGINAL_ERROR { get; set; }
    public Boolean ERROR_STATUS { get; set; }
    //public int STATUS { get; set; }
    public Boolean RECORDS { get; set; }

    public List<RecentTaskDetail> Data { get; set; }
}
public class RecentTaskDetail
{
    public string id { get; set; }
    public string date { get; set; }
    public string title { get; set; }
    public string image { get; set; }
    public string shortdesc { get; set; }
    public string longdesc { get; set; }

}
public class GeneralDataJustFacts
{
    public string MESSAGE { get; set; }
    public string ORIGINAL_ERROR { get; set; }
    public Boolean ERROR_STATUS { get; set; }
    //public int STATUS { get; set; }
    public Boolean RECORDS { get; set; }

    public List<JustFacts> Data { get; set; }
}
public class GeneralDataItem
{
    public string MESSAGE { get; set; }
    public string ORIGINAL_ERROR { get; set; }
    public Boolean ERROR_STATUS { get; set; }
    public string Date { get; set; }
    public Boolean RECORDS { get; set; }

    public List<ItemMaster> Data { get; set; }
}
public class GeneralDataItem2
{
    public string MESSAGE { get; set; }
    public string ORIGINAL_ERROR { get; set; }
    public Boolean ERROR_STATUS { get; set; }
    public string Date { get; set; }
    public Boolean RECORDS { get; set; }

    public List<ItemCount> Data { get; set; }
}
public class ItemMaster
{
    public string id { get; set; }
    public string name { get; set; }
    public string inkg { get; set; }
    public string inpcs { get; set; }
    public Double kgprice { get; set; }
    public Double pcsprice { get; set; }
    public string image { get; set; }
    public string unit { get; set; }

    public string Qty { get; set; }

    public string count { get; set; }

    public Double total { get; set; }

    public Double price { get; set; }

    public Double Amount { get; set; }

    public string pick { get; set; }
}

public class ItemCount
{
    public string count { get; set; }

   
}

public class CustomerMaster
{
    public string id { get; set; }
    public string name { get; set; }
    public string email { get; set; }
    public string mobile { get; set; }

    public string address { get; set; }
    public string cid { get; set; }

    public string oid { get; set; }
    public Double total { get; set; }

    public string unit { get; set; }

    public Double Qty { get; set; }

    public Double price { get; set; }
    public Double Amount { get; set; }

}
public class ReturnData
{
    public string MESSAGE { get; set; }
    public Boolean ERROR_STATUS { get; set; }
    public dynamic Data { get; set; }
}
public class GeneralDataDashboard
{
    public string MESSAGE { get; set; }
    public string ORIGINAL_ERROR { get; set; }
    public Boolean ERROR_STATUS { get; set; }
    //public int STATUS { get; set; }
    public Boolean RECORDS { get; set; }

    public List<DashboardMaster> Data { get; set; }
}
public class DashboardMaster
{
    public string TotalBusiness { get; set; }
    public string TotalOrder { get; set; }
  
}
public class GeneralDataDashboard2
{
    public string MESSAGE { get; set; }
    public string ORIGINAL_ERROR { get; set; }
    public Boolean ERROR_STATUS { get; set; }
    //public int STATUS { get; set; }
    public Boolean RECORDS { get; set; }

    public List<TodayDashboard> Data { get; set; }
}
public class TodayDashboard
{
    public string TodaysBusiness { get; set; }
    public string TodayOrders { get; set; }
    public string date { get; set; }

}
public class GeneralDataCustomerAll
{
    public string MESSAGE { get; set; }
    public string ORIGINAL_ERROR { get; set; }
    public Boolean ERROR_STATUS { get; set; }
    //public int STATUS { get; set; }
    public Boolean RECORDS { get; set; }

    public List<CustomerAllMaster> Data { get; set; }
}
public class CustomerAllMaster
{
    public string id { get; set; }
    public string name { get; set; }
    public string mobile { get; set; }
    public string wmobile { get; set; }
    public string email { get; set; }
    public string address { get; set; }
    public string flatno { get; set; }
    public string society { get; set; }
    public string building { get; set; }
    public string area { get; set; }

}
public class GeneralDataOrder
{
    public string MESSAGE { get; set; }
    public string ORIGINAL_ERROR { get; set; }
    public Boolean ERROR_STATUS { get; set; }
    //public int STATUS { get; set; }
    public Boolean RECORDS { get; set; }

    public List<OrderSummary> Data { get; set; }
}
public class OrderSummary
{
    public string id { get; set; }
    public string name { get; set; }
    public string unit { get; set; }
    public string kgholesaleprice { get; set; }
    public string pcsholesaleprice { get; set; }
    public string kgmargin { get; set; }
    public string pcsmargin { get; set; }
    public string kgretailprice { get; set; }
    public string pcsretailprice { get; set; }

}
public class OutwardItem
{
    public string IID { get; set; }
    public string ItemName { get; set; }
    public string CID { get; set; }
    public string CNo { get; set; }
    public string Unit { get; set; }
    public string QTY { get; set; }
}
public class TestCertificateItem
{
    public string CID { get; set; }
    public string CNo { get; set; }
    public string OWEIGHT { get; set; }
    public string CWEIGHT { get; set; }
    public string LWEIGHT { get; set; }
    public string PWEIGHT { get; set; }
    public string WATER { get; set; }
    public string PRESSURE { get; set; }
    public string TEXP { get; set; }
    public string PEXP { get; set; }
    public string STRESS { get; set; }
    public string CONCLUSION { get; set; }
}
public class GeneralDataItemPrice
{
    public string MESSAGE { get; set; }
    public string ORIGINAL_ERROR { get; set; }
    public Boolean ERROR_STATUS { get; set; }
    public string category { get; set; }
    public string ename { get; set; }
    public string hname { get; set; }
    public string gname { get; set; }
    public Double kghprice { get; set; }
    public Double kgmargin { get; set; }
    public Double kgrprice { get; set; }
    public Double pcshprice { get; set; }
    public Double pcsmargin { get; set; }
    public Double pcsrprice { get; set; }
    public Boolean RECORDS { get; set; }

    public List<ItemMaster> Data { get; set; }
}
public class GeneralChallanNo
{
    public string MESSAGE { get; set; }
    public string ORIGINAL_ERROR { get; set; }
    public Boolean ERROR_STATUS { get; set; }
    //public int STATUS { get; set; }
    public Boolean RECORDS { get; set; }

    public List<ChallanNo> Data { get; set; }
}
public class ChallanNo
{
    public string id { get; set; }
    public string no { get; set; }

}
public class GeneralBillNo
{
    public string MESSAGE { get; set; }
    public string ORIGINAL_ERROR { get; set; }
    public Boolean ERROR_STATUS { get; set; }
    //public int STATUS { get; set; }
    public Boolean RECORDS { get; set; }
    public string BillNo { get; set; }
    public string Today { get; set; }
}
public class GeneralChallanItem
{
    public string MESSAGE { get; set; }
    public string ORIGINAL_ERROR { get; set; }
    public Boolean ERROR_STATUS { get; set; }
    //public int STATUS { get; set; }
    public Boolean RECORDS { get; set; }

    public List<BillItem> Data { get; set; }
    public string ChllanDate { get; set; }
    public string itemid { get; set; }
    public string Address { get; set; }
    public string billno { get; set; }
}
public class BillItem
{
    
    public string CID { get; set; }
    public string CNo { get; set; }
    public string Unit { get; set; }
    public string Qty { get; set; }
    public string Rate { get; set; }
    public string Amount { get; set; }
}
public class GeneralChallanData
{
    public string MESSAGE { get; set; }
    public string ORIGINAL_ERROR { get; set; }
    public Boolean ERROR_STATUS { get; set; }
    //public int STATUS { get; set; }
    public Boolean RECORDS { get; set; }

    public List<ChallanItem> Data { get; set; }
    public string ChllanDate { get; set; }
    public string customerid { get; set; }
    public string itemid { get; set; }
    public string challanno { get; set; }
    public string Transport { get; set; }
    public string LRNo { get; set; }
    public string FoundOK { get; set; }
    public string RequirementOK { get; set; }
}
public class ChallanItem
{

    public string CID { get; set; }
    public string CNo { get; set; }
    public string Unit { get; set; }
    public int QTY { get; set; }
}

public class GeneralBillData
{
    public string MESSAGE { get; set; }
    public string ORIGINAL_ERROR { get; set; }
    public Boolean ERROR_STATUS { get; set; }
    //public int STATUS { get; set; }
    public Boolean RECORDS { get; set; }

    public List<BillItem> Data { get; set; }
    public string Date { get; set; }
    public string Billno { get; set; }
    public string CustomerId { get; set; }
    public string ChallanId { get; set; }
    public string ItemId { get; set; }
    public string ChallanDate { get; set; }
    public Boolean OFR { get; set; }
    public Boolean DFT { get; set; }
    public Boolean TFS { get; set; }
    public Boolean IGST { get; set; }
    public string Billto { get; set; }
    public string Consignee { get; set; }
    public string PNO { get; set; }
    public string PDATE { get; set; }
    public string Terms { get; set; }
    public string SubTotal { get; set; }
    public string cgst { get; set; }
    public string sgst { get; set; }
    public string igst { get; set; }
    public string TotalGST { get; set; }
    public string Total { get; set; }
}
public class GeneralDataCustomerOrder
{
    public string MESSAGE { get; set; }
    public string ORIGINAL_ERROR { get; set; }
    public Boolean ERROR_STATUS { get; set; }
    //public int STATUS { get; set; }
    public Boolean RECORDS { get; set; }

    public List<Order> Data { get; set; }

    public List<OrderItem> Data2 { get; set; }
}
public class Order
{
    public string orderid { get; set; }
    public string customername { get; set; }
    public string mobile { get; set; }
    public string wmobile { get; set; }
    public string address { get; set; }
    public string total { get; set; }

    public string date { get; set; }
    public string status { get; set; }
    public List<OrderItem> Items { get; set; }

}
public class GeneralDataOrderData
{
    public string MESSAGE { get; set; }
    public string ORIGINAL_ERROR { get; set; }
    public Boolean ERROR_STATUS { get; set; }
    //public int STATUS { get; set; }
    public Boolean RECORDS { get; set; }
    public string Date { get; set; }
    public string Total { get; set; }
    public string CID { get; set; }
    public List<OrderItem> Data { get; set; }
}
public class GeneralDataInward
{
    public string MESSAGE { get; set; }
    public string ORIGINAL_ERROR { get; set; }
    public Boolean ERROR_STATUS { get; set; }
    //public int STATUS { get; set; }
    public Boolean RECORDS { get; set; }

    public List<Inward> Data { get; set; }
}
public class Inward
{
    public string IID { get; set; }
    public string Type { get; set; }
    public string ItemName { get; set; }
    public string Date { get; set; }
    public string Qty { get; set; }

}
public class GeneralDataOutward
{
    public string MESSAGE { get; set; }
    public string ORIGINAL_ERROR { get; set; }
    public Boolean ERROR_STATUS { get; set; }
    //public int STATUS { get; set; }
    public Boolean RECORDS { get; set; }

    public List<Outward> Data { get; set; }
}
public class Outward
{
    public string IID { get; set; }
    public string Type { get; set; }
    public string Orderid { get; set; }
    public string customername { get; set; }
    public string ItemName { get; set; }
    public string Date { get; set; }
    public string Qty { get; set; }

}
public class JustFacts
{
    public string id { get; set; }
    public string hashid { get; set; }
    public string text { get; set; }
    public string favourite { get; set; }

}

