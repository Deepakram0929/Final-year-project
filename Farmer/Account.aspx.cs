using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace cropPrediction.Farmer
{
    public partial class Account : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["FarmerId"] == null)
            {
                Session.Abandon();
                Response.Redirect("~/Login.aspx");
            }
        }

       
      
        protected void btnChange_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable tab = new DataTable();
                BLL obj = new BLL();
                tab.Rows.Clear();

                tab = obj.GetUserById(Session["FarmerId"].ToString());
                string oldPassword = tab.Rows[0]["Password"].ToString();

                if (txtOldPassword.Value.Equals(oldPassword))
                {
                    obj.UpdateUserPassword(txtNewPassword.Value, Session["FarmerId"].ToString());
                    ClientScript.RegisterStartupScript(this.GetType(), "key", "<script>alert('Farmer Password changed successfully')</script>");
                }
                else
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "key", "<script>alert('Farmer Old password incorrect')</script>");
                }
            }
            catch
            {
                ClientScript.RegisterStartupScript(GetType(), "key", "<script>alert('Server Error - Check the Database Connectivity!!!')</script>");
            }
        }

    }
}