﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace cropPrediction.Admin
{
    public partial class Account : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["AdminId"] == null)
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

                tab = obj.GetUserById(Session["AdminId"].ToString());
                string oldPassword = tab.Rows[0]["Password"].ToString();

                if (txtOldPassword.Value.Equals(oldPassword))
                {
                    obj.UpdateUserPassword(Session["AdminId"].ToString(), txtNewPassword.Value);
                    ClientScript.RegisterStartupScript(this.GetType(), "key", "<script>alert('Admin Password changed successfully')</script>");
                }
                else
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "key", "<script>alert('Admin Old password incorrect')</script>");
                }
            }
            catch
            {
                ClientScript.RegisterStartupScript(GetType(), "key", "<script>alert('Server Error - Check the Database Connectivity!!!')</script>");
            }
        }

    }
}