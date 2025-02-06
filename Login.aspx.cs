using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.IO;

namespace cropPrediction
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)

                radiobtnAdmin.Checked = true;
        }

        protected void btnSignin_Click(object sender, EventArgs e)
        {
            try
            {
                BLL obj = new BLL();

                DataTable tabUser = new DataTable();
                tabUser = obj.CheckUserLogin(txtUserId.Value, txtPassword.Value);

                if (tabUser.Rows.Count > 0)
                {
                    if (radiobtnAdmin.Checked == true && tabUser.Rows[0]["UserType"].ToString().Equals("Admin"))
                    {
                        Session["AdminId"] = txtUserId.Value;
                        Response.Redirect("~/Admin/Staff.aspx");
                    }
                    else if (radiobtnStaff.Checked == true && tabUser.Rows[0]["UserType"].ToString().Equals("Staff"))
                    {
                        Session["StaffId"] = txtUserId.Value;
                        Response.Redirect("~/Staff/StaffHome.aspx");
                    }
                    else if (radioFarmer.Checked == true && tabUser.Rows[0]["UserType"].ToString().Equals("Farmer"))
                    {
                        Session["FarmerId"] = txtUserId.Value;
                        Response.Redirect("~/Farmer/FarmerHome.aspx");
                    }
                    else
                    {
                        ClientScript.RegisterStartupScript(GetType(), "key", "<script>alert('Invalid User!!!')</script>");
                    }
                }
                else
                {
                    ClientScript.RegisterStartupScript(GetType(), "key", "<script>alert('Invalid UserId/Password!!!')</script>");
                }
            }
            catch
            {
                ClientScript.RegisterStartupScript(GetType(), "key", "<script>alert('Server Error - Check the Database Connectivity!!!')</script>");
            }
        }
    }
}