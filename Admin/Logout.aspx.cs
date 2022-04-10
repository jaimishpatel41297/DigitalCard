using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_Logout : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (!IsPostBack)
            {
                //Response.Cookies["AdminId"].Expires = DateTime.Now.AddSeconds(-1);
                Response.Cookies["Userid"].Expires = DateTime.Now.AddSeconds(-1);
                Session.Clear();
                Session.Abandon();
            }
            Response.Redirect("Login.aspx", true);
        }

    }
}