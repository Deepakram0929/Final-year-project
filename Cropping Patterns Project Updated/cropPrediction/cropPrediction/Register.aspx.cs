using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace cropPrediction
{
    public partial class Register : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                txtLoginId.Focus();
            }
        }
               

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            BLL obj = new BLL();


            try
            {
                if (obj.CheckUserId(txtLoginId.Text))
                {
                    obj.InsertUser(txtLoginId.Text, txtPassword.Text, "Farmer", ddlLoc.SelectedItem.Text);

                    ClientScript.RegisterStartupScript(this.GetType(), "Key", "<Script>alert('Registered Successfully')</script>");
                    txtPassword.Text = string.Empty;
                    txtLoginId.Text = string.Empty;

                }
                else
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "Key", "<Script>alert('UserId Exists!!!')</script>");
                }
            }
            catch
            {
                ClientScript.RegisterStartupScript(this.GetType(), "Key", "<Script>alert('Server Error!')</script>");
            }


        }
    }
}