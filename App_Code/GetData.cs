using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Net;
using System.IO;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;

/// <summary>
/// Summary description for GetData
/// </summary>
/// 

public class GetData
{

    //public static String GET_ERROR_PATH = "D://Inetpub//vhosts//studyfield.com//ims.studyfield.com//IMSError//";
    public static String GET_ERROR_PATH = @"IMSError//";
    public static String DEMO_CLIENT = "10001";
    public static String WEBSITE = "http://lions.tech9teen.com/";
    public SqlConnection conn;
    public SqlConnection conn1;
   
    public GetData()
    {
        //Connection String
        conn = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["DigitalCardConnection"].ConnectionString);
        conn1 = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["DigitalCardConnection"].ConnectionString);
    }

    public string APPEND_COLUMN(string[] fields, string client, string where)
    {
        string cl = where;
        if (fields.Length <= 0)
        {
            return " " + where + " ClientId=" + client;
        }
        else
        {
            string cl1 = " and ";

            int i = 1;
            int k = 0;
            int n = fields.Length;
            int flag = 0;
            for (int j = 0; j < n; j++)
            {

                if (flag == 1)
                {
                    flag = 0;
                    k = 0;
                }
                if (i % 3 == 0)
                {
                    if (cl.ToString().EndsWith("="))
                        cl = cl.Remove(cl.Length - 1, 1);
                    cl += " and ";
                    n++;
                    //k = 0;
                    flag = 1;
                }
                else if (i == 5)
                {
                    if (cl.ToString().EndsWith("="))
                        cl = cl.Remove(cl.Length - 1, 1);
                    cl += " and ";
                    n++;
                    //k = 0;
                    flag = 1;
                    i++;
                }
                i++;
                cl += " " + fields[k] + ".ClientId=";
                k++;

            }
            if (cl.ToString().EndsWith("="))
                cl = cl.Remove(cl.Length - 1, 1);
            cl += " and " + fields[0].ToString() + ".ClientId=" + client;
        }
        return cl;
    }
    public void ExecuteQuery(string SqlQuery, SqlConnection gConn)
    {
        try
        {

            SqlCommand cm = new SqlCommand(SqlQuery, gConn);
            gConn.Open();
            cm.ExecuteNonQuery();
            gConn.Close();
        }
        catch
        {
            //string msg = "Fetch Error:";
            //msg += ex.Message;
            //throw new Exception(msg);
        }
    }

    public DataTable GetDataTable(string strqry, SqlConnection gConn)
    {
        DataTable dt = new DataTable();
        try
        {
            SqlCommand cm = new SqlCommand(strqry, gConn);
            gConn.Open();
            cm.ExecuteNonQuery();
            gConn.Close();
            SqlDataAdapter da = new SqlDataAdapter(cm);
            da.Fill(dt);
        }
        catch
        {
            //string msg = "Fetch Error:";
            //msg += ex.Message;
            //throw new Exception(msg);
        }
        return dt;
    }
    public DataTable GetDataTable(string strqry)
    {
        DataTable dt = new DataTable();
        try
        {
            SqlCommand cm = new SqlCommand(strqry, conn);
            conn.Open();
            cm.ExecuteNonQuery();
            conn.Close();
            SqlDataAdapter da = new SqlDataAdapter(cm);
            da.Fill(dt);
        }
        catch (System.Data.SqlClient.SqlException ex)
        {
            string msg = "Fetch Error:";
            msg += ex.Message;
            //HttpContext.Current.Response.Redirect("~/404.html", false);
            throw new Exception(msg);
        }
        return dt;
    }

    public String GetName(string tableName, string NameField, string codeField, int whereField)
    {
        String strqry = "Select " + NameField + " from " + tableName + " where " + codeField + "=" + whereField + "";
        DataTable dt = new DataTable();
        try
        {
            SqlCommand cm = new SqlCommand(strqry, conn);
            conn.Open();
            cm.ExecuteNonQuery();
            conn.Close();
            SqlDataAdapter da = new SqlDataAdapter(cm);
            da.Fill(dt);

            if (dt.Rows.Count > 0)
            {
                return dt.Rows[0][0].ToString();
            }
            else
            {
                return "";
            }
        }
        catch (System.Data.SqlClient.SqlException ex)
        {
            string msg = "Fetch Error:";
            msg += ex.Message;
            throw new Exception(msg);
        }
        return "";
    }

    public DataTable GetAPIDataTable(string strqry)
    {
        DataTable dt = new DataTable();
        try
        {
            SqlCommand cm = new SqlCommand(strqry, conn1);
            conn1.Open();
            cm.ExecuteNonQuery();
            conn1.Close();
            SqlDataAdapter da = new SqlDataAdapter(cm);
            da.Fill(dt);
        }
        catch (System.Data.SqlClient.SqlException ex)
        {
            string msg = "Fetch Error:";
            msg += ex.Message;
            throw new Exception(msg);
        }
        return dt;
    }

    public int GetMaxId(string SqlQuery)
    {
        int id = 0;
        DataTable dt = new DataTable();
        try
        {
            SqlCommand cm = new SqlCommand(SqlQuery, conn);
            conn.Open();
            cm.ExecuteNonQuery();
            conn.Close();
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
    //public DataTable GetAPIDataTable(string strqry)
    //{
    //    DataTable dt = new DataTable();
    //    try
    //    {
    //        SqlCommand cm = new SqlCommand(strqry, conn1);
    //        conn1.Open();
    //        cm.ExecuteNonQuery();
    //        conn1.Close();
    //        SqlDataAdapter da = new SqlDataAdapter(cm);
    //        da.Fill(dt);
    //    }
    //    catch (System.Data.SqlClient.SqlException ex)
    //    {
    //        string msg = "Fetch Error:";
    //        msg += ex.Message;
    //        throw new Exception(msg);
    //    }
    //    return dt;
    //}
    public void ExecuteQuery(string SqlQuery)
    {
        try
        {
            SqlCommand cm = new SqlCommand(SqlQuery, conn);
            conn.Open();
            cm.ExecuteNonQuery();
            conn.Close();
        }
        catch (System.Data.SqlClient.SqlException ex)
        {
            string msg = "Fetch Error:";
            msg += ex.Message;
            throw new Exception(msg);
        }
    }

    #region  SMSFunctions
    public DataTable GetSMSSettings()
    {
        DataTable dt = new DataTable();
        dt = GetDataTable("SELECT CDMAHeader, Id, Password, SenderId, Username FROM SMSSettings WHERE (Id = 1)");
        return dt;
    }
    public string fun_sendsms(string Vmessage, string Vmobno)
    {
        //DataTable dt = GetSMSSettings();
        //if (dt.Rows.Count == 0)
        //    return null;
        //string Username = dt.Rows[0]["Username"].ToString();
        //string Password = dt.Rows[0]["Password"].ToString();
        //string SenderId = dt.Rows[0]["SenderId"].ToString();

        string outputBuffer = "where=46038";
        HttpWebRequest req = (HttpWebRequest)WebRequest.Create("http://bulksms.dnsitexperts.com/sendsms.jsp?user=iclass&password=dns@123&mobiles=" + Vmobno + "&senderid=ICLASS&sms=" + Vmessage + "");

        req.Method = "POST";
        req.ContentLength = outputBuffer.Length;
        req.ContentType = "application/x-www-form-urlencoded";
        StreamWriter swOut = new StreamWriter(req.GetRequestStream());
        swOut.Write(outputBuffer);
        swOut.Close();
        HttpWebResponse resp = (HttpWebResponse)req.GetResponse();
        StreamReader sr = new StreamReader(resp.GetResponseStream());
        string buffer = sr.ReadToEnd();
        return buffer;

    }
    public string GetAPIStrings()
    {
        DataTable dt = GetSMSSettings();
        if (dt.Rows.Count == 0)
            return null;
        string Username = dt.Rows[0]["Username"].ToString();
        string Password = dt.Rows[0]["Password"].ToString();
        string SenderId = dt.Rows[0]["SenderId"].ToString();

        string outputBuffer = "where=46038";
        // Remove comment form below
        HttpWebRequest req = (HttpWebRequest)WebRequest.Create("http://newsms.dnsitexperts.com/smscredit.jsp?user=" + Username + "&password=" + Password);

        req.Method = "POST";
        req.ContentLength = outputBuffer.Length;
        req.ContentType = "application/x-www-form-urlencoded";
        StreamWriter swOut = new StreamWriter(req.GetRequestStream());
        swOut.Write(outputBuffer);
        swOut.Close();
        HttpWebResponse resp = (HttpWebResponse)req.GetResponse();
        StreamReader sr = new StreamReader(resp.GetResponseStream());
        string buffer = sr.ReadToEnd();
        return buffer;

    }

    #endregion




}