using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace cropPrediction.Staff
{
    public partial class Farmers : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["StaffId"] == null)
            {
                Session.Abandon();
                Response.Redirect("~/Login.aspx");
            }
            else
            {

                if (!this.IsPostBack)

                    txtFarmerName.Focus();

                LoadFarmers();

                cropPrediction.Staff.JQueryUtils.RegisterTextBoxForDatePicker1(Page, txtDate);               
            }
        }

        //function to load all farmers
        private void LoadFarmers()
        {
            DataTable tab = new DataTable();
            BLL obj = new BLL();

            tab = obj.GetFarmersByLoc(Session["StaffId"].ToString());

            if (tab.Rows.Count > 0)
            {
                tableFarmers.Rows.Clear();

                tableFarmers.BorderStyle = BorderStyle.Double;
                tableFarmers.GridLines = GridLines.Both;
                tableFarmers.BorderColor = System.Drawing.Color.DarkGray;

                TableHeaderRow mainrow = new TableHeaderRow();
                mainrow.Height = 30;
                mainrow.ForeColor = System.Drawing.Color.WhiteSmoke;

                mainrow.BackColor = System.Drawing.Color.SteelBlue;

                TableCell cell2 = new TableCell();
                cell2.Text = "<b>Farmer Name</b>";
                mainrow.Controls.Add(cell2);
                                
                TableCell cell7 = new TableCell();
                cell7.Text = "<b>Address</b>";
                mainrow.Controls.Add(cell7);

                TableCell cell8 = new TableCell();
                cell8.Text = "<b>ContactNo</b>";
                mainrow.Controls.Add(cell8);

                TableCell cell10 = new TableCell();
                cell10.Text = "<b>Date</b>";
                mainrow.Controls.Add(cell10);

                TableCell cell11 = new TableCell();
                cell11.Text = "<b>Edit</b>";
                mainrow.Controls.Add(cell11);

                TableCell cell12 = new TableCell();
                cell12.Text = "<b>Delete</b>";
                mainrow.Controls.Add(cell12);

                TableCell cell13 = new TableCell();
                cell13.Text = "<b>Parameters</b>";
                mainrow.Controls.Add(cell13);

                tableFarmers.Controls.Add(mainrow);

                for (int i = 0; i < tab.Rows.Count; i++)
                {
                    TableRow row = new TableRow();

                    TableCell cellName = new TableCell();
                    cellName.Width = 150;
                    cellName.Text = tab.Rows[i]["FarmerName"].ToString();
                    row.Controls.Add(cellName);
                                       
                    TableCell cellAddress = new TableCell();
                    cellAddress.Width = 150;
                    cellAddress.Text = tab.Rows[i]["Address"].ToString();
                    row.Controls.Add(cellAddress);

                    TableCell cellContactNo = new TableCell();
                    cellContactNo.Width = 100;
                    cellContactNo.Text = tab.Rows[i]["ContactNo"].ToString();
                    row.Controls.Add(cellContactNo);

                    TableCell cellAdmittedDate = new TableCell();
                    cellAdmittedDate.Width = 100;
                    string[] s = tab.Rows[i]["Date"].ToString().Split(' ');
                    cellAdmittedDate.Text = s[0];
                    row.Controls.Add(cellAdmittedDate);

                    TableCell cell_edit = new TableCell();
                    LinkButton lbtn_edit = new LinkButton();
                    lbtn_edit.ForeColor = System.Drawing.Color.Red;
                    lbtn_edit.Text = "Edit";
                    lbtn_edit.Font.Bold = true;
                    lbtn_edit.ID = "Edit~" + tab.Rows[i]["FarmerId"].ToString();
                    lbtn_edit.Click += new EventHandler(lbtn_edit_Click);
                    cell_edit.Controls.Add(lbtn_edit);
                    row.Controls.Add(cell_edit);

                    TableCell cell_delete = new TableCell();
                    LinkButton lbtn_delete = new LinkButton();
                    lbtn_delete.ForeColor = System.Drawing.Color.Red;
                    lbtn_delete.Text = "Delete";
                    lbtn_delete.Font.Bold = true;
                    lbtn_delete.ID = "Delete~" + tab.Rows[i]["FarmerId"].ToString();
                    lbtn_delete.OnClientClick = "return confirm('Are you sure want to delete this record?')";
                    lbtn_delete.Click += new EventHandler(lbtn_delete_Click);
                    cell_delete.Controls.Add(lbtn_delete);
                    row.Controls.Add(cell_delete);

                    TableCell cellAttributes = new TableCell();
                    LinkButton lbtnAttributes = new LinkButton();
                    lbtnAttributes.ForeColor = System.Drawing.Color.SteelBlue;
                    lbtnAttributes.Text = "Set Parameters";
                    lbtnAttributes.Font.Bold = true;
                    lbtnAttributes.ID = "Attribute~" + tab.Rows[i]["FarmerId"].ToString();
                    lbtnAttributes.Click += new EventHandler(lbtnAttributes_Click);
                    cellAttributes.Controls.Add(lbtnAttributes);
                    row.Controls.Add(cellAttributes);

                    tableFarmers.Controls.Add(row);
                }
            }
            else
            {
                tableFarmers.Rows.Clear();
                tableFarmers.GridLines = GridLines.None;
                tableFarmers.BorderStyle = BorderStyle.None;

                TableHeaderRow rno = new TableHeaderRow();
                TableHeaderCell cellno = new TableHeaderCell();
                cellno.ForeColor = System.Drawing.Color.Red;
                cellno.Text = "No Farmers Found!!!";

                rno.Controls.Add(cellno);
                tableFarmers.Controls.Add(rno);
            }
        }

        //event to delete Farmer
        void lbtn_delete_Click(object sender, EventArgs e)
        {
            BLL obj = new BLL();
            LinkButton lbtn = (LinkButton)sender;
            string[] s = lbtn.ID.ToString().Split('~');

            try
            {
                obj.DeleteFarmerFeatures(int.Parse(s[1].ToString()));
                obj.DeleteFarmer(int.Parse(s[1].ToString()));

                ClientScript.RegisterStartupScript(this.GetType(), "Key", "<Script>alert('Farmer Deleted Successfully!!!')</script>");
                LoadFarmers();

            }
            catch
            {
                ClientScript.RegisterStartupScript(this.GetType(), "Key", "<Script>alert('Server Error!!!')</script>");
            }
        }

        //click event to edit the farmer details
        void lbtn_edit_Click(object sender, EventArgs e)
        {
            BLL obj = new BLL();
            LinkButton lbtn = (LinkButton)sender;
            string[] s = lbtn.ID.ToString().Split('~');

            Session["farmerId"] = null;
            Session["farmerId"] = s[1];

            DataTable tab = new DataTable();
            tab = obj.GetFarmerById(int.Parse(s[1]));

            if (tab.Rows.Count > 0)
            {
                txtFarmerName.Value = tab.Rows[0]["FarmerName"].ToString();               
                txtAddress.Value = tab.Rows[0]["Address"].ToString();
                txtContactNo.Value = tab.Rows[0]["ContactNo"].ToString();
                txtDate.Text = tab.Rows[0]["Date"].ToString();                           
            }

            btnSubmit.Text = "Update";
        }

        //function to clear the textbox contents
        private void ClearTxtboxes()
        {
            txtAddress.Value = string.Empty;           
            txtContactNo.Value = string.Empty;
            txtFarmerName.Value = string.Empty;
            txtDate.Text = string.Empty;
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            BLL obj = new BLL();

            if (btnSubmit.Text.Equals("Submit"))
            {
                try
                {
                    obj.InsertFarmer(txtFarmerName.Value, txtAddress.Value, txtContactNo.Value, DateTime.Parse(txtDate.Text) , Session["StaffId"].ToString());

                    ClientScript.RegisterStartupScript(this.GetType(), "Key", "<Script>alert('New Farmer Added Successfully!!!')</script>");
                    ClearTxtboxes();
                    LoadFarmers();
                }
                catch
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "Key", "<Script>alert('Server Error!')</script>");
                }
            }
            else if (btnSubmit.Text.Equals("Update"))
            {

                obj.UpdateFarmer(txtFarmerName.Value, txtAddress.Value, txtContactNo.Value, DateTime.Parse(txtDate.Text), Session["StaffId"].ToString(), int.Parse(Session["farmerId"].ToString()));


                btnSubmit.Text = "Submit";
                ClearTxtboxes();
                LoadFarmers();
                ClientScript.RegisterStartupScript(this.GetType(), "Key", "<script>alert('Farmer Updated Successfully!!!')</script>");
            }
        }

        void lbtnAttributes_Click(object sender, EventArgs e)
        {
            LinkButton lbtn = (LinkButton)sender;
            string[] s = lbtn.ID.ToString().Split('~');

            Response.Redirect(string.Format("SoilFeatures.aspx?farmerId={0}", s[1]));
        }
    }
}