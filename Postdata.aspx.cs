using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Postdata : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string s = Request.Form["ID"];
        Response.Redirect("Digitalcard.aspx?ID="+s);
    }
}