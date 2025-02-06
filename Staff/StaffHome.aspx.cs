using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace cropPrediction.Staff
{
    public partial class StaffHome : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["StaffId"] == null)
            {
                Session.Abandon();
                Response.Redirect("~/Loginpage.aspx");
            }
            else
            {
                lblDept.ForeColor = System.Drawing.Color.ForestGreen;
                lblDept.Font.Bold = true;
                lblDept.Font.Size = 16;

                if (DateTime.Now.Hour < 12)
                {
                    lblDept.Text = "Welcome : " + Session["StaffId"].ToString() + ", Good Morning";
                }
                else if (DateTime.Now.Hour < 16)
                {
                    lblDept.Text = "Welcome : " + Session["StaffId"].ToString() + ", Good Afternoon";
                }
                else
                {
                    lblDept.Text = "Welcome : " + Session["StaffId"].ToString() + ", Good Evening";
                }

            }
        }
    }
}