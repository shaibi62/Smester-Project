using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection.Emit;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Reviews_Website
{
    public partial class SiteMaster : MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.Url.AbsolutePath.EndsWith("/Login", StringComparison.InvariantCultureIgnoreCase) ||
                Request.Url.AbsolutePath.EndsWith("/Login.aspx", StringComparison.InvariantCultureIgnoreCase))
            {
                MyNavbar.Visible = false;
                //Debug.WriteLine("Navbar hidden on the login page.");
            }
            else
            {
                MyNavbar.Visible = true;
                //Debug.WriteLine("Navbar visible on other pages.");
            }
            if (Session["UserName"] != null)
            {
                Admin.Visible = true;
                LoginLink.Visible = false;
            }
            else 
            {
                Admin.Visible = false;
                LoginLink.Visible = true;
            }
        }


    }
}