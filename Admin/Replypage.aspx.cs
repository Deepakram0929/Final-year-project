using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace cropPrediction.Admin
{
    public partial class Replypage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                loadQuery();
                txtQuery.Focus();
            }
        }

        private void loadQuery()
        {
            try
            {
                BLL obj = new BLL();
                DataTable tab = new DataTable();

                tab = obj.GetQueryById(int.Parse(Request.QueryString["Id"].ToString()));

                if (tab.Rows.Count > 0)
                {
                    txtQuery.Text = tab.Rows[0]["Query"].ToString();
                }

            }
            catch
            {

            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                BLL obj = new BLL();
                obj.UpdateQuery(txtReply.Text, DateTime.Now, int.Parse(Request.QueryString["Id"].ToString()));
                ClientScript.RegisterStartupScript(GetType(), "key", "<script>alert('Reply Sent Successfully')</script>");
            }
            catch
            {

            }
        }
    }
}