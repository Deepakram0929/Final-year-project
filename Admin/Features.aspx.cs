using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace cropPrediction.Admin
{
    public partial class Features : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["AdminId"] == null)
            {
                Session.Abandon();
                Response.Redirect("~/Login.aspx");
            }
            else
            {
                if (!this.IsPostBack)
                {
                    LoadTypes();
                    txtFeature.Focus();
                }

                LoadFeatures();
            }
        }

        //function to retrive all types
        private void LoadTypes()
        {
            try
            {
                DataTable tab = new DataTable();
                BLL obj = new BLL();

                tab = obj.GetAllFeatureTypes();

                if (tab.Rows.Count > 0)
                {
                    DropDownListType.Items.Clear();

                    DropDownListType.DataSource = tab;
                    DropDownListType.DataTextField = "FeatureType";
                    DropDownListType.DataValueField = "FeatureTypeId";
                    DropDownListType.DataBind();

                    DropDownListType.Items.Insert(0, "All");
                }
                else
                {
                    DropDownListType.Items.Clear();
                    DropDownListType.Items.Insert(0, "Input Types");
                }
            }
            catch
            {

            }

        }

        //function to retrive features
        private void LoadFeatures()
        {
            try
            {
                int serialNo = 1;

                DataTable tab = new DataTable();
                BLL obj = new BLL();

                if (DropDownListType.SelectedIndex > 0)
                {
                    tab = obj.GetFeaturesByType(int.Parse(DropDownListType.SelectedValue));
                }
                else
                {
                    tab = obj.GetAllFetures();
                }

                if (tab.Rows.Count > 0)
                {
                    tableFeatures.Rows.Clear();

                    tableFeatures.BorderStyle = BorderStyle.Double;
                    tableFeatures.GridLines = GridLines.Both;
                    tableFeatures.BorderColor = System.Drawing.Color.DarkGray;

                    TableHeaderRow headerrow = new TableHeaderRow();
                    headerrow.Height = 30;
                    headerrow.ForeColor = System.Drawing.Color.WhiteSmoke;
                    headerrow.BackColor = System.Drawing.Color.SteelBlue;

                    TableCell cell1 = new TableCell();
                    cell1.Text = "<b>SLNo</b>";
                    headerrow.Controls.Add(cell1);

                    TableCell cell3 = new TableCell();
                    cell3.Text = "<b>Constraint</b>";
                    headerrow.Controls.Add(cell3);

                    TableCell cell4 = new TableCell();
                    cell4.Text = "<b>Value</b>";
                    headerrow.Controls.Add(cell4);

                    if (DropDownListType.SelectedIndex > 0)
                    {
                        TableCell cell6 = new TableCell();
                        cell6.Text = "<b>Edit</b>";
                        headerrow.Controls.Add(cell6);

                        TableCell cell7 = new TableCell();
                        cell7.Text = "<b>Delete</b>";
                        headerrow.Controls.Add(cell7);
                    }
                    else
                    {

                    }

                    tableFeatures.Controls.Add(headerrow);

                    for (int cnt = 0; cnt < tab.Rows.Count; cnt++)
                    {
                        TableRow row = new TableRow();
                        row.Height = 30;

                        TableCell cellSerialNo = new TableCell();
                        cellSerialNo.Width = 10;
                        cellSerialNo.Font.Size = 10;
                        cellSerialNo.Text = serialNo + cnt + ".";
                        row.Controls.Add(cellSerialNo);

                        TableCell cellType = new TableCell();
                        cellType.Width = 150;

                        DataTable tabType = new DataTable();
                        tabType = obj.GetFeatureTypeById(int.Parse(tab.Rows[cnt]["FeatureTypeId"].ToString()));

                        cellType.Text = tabType.Rows[0]["FeatureType"].ToString();
                        row.Controls.Add(cellType);

                        TableCell cellSubType = new TableCell();
                        cellSubType.Width = 150;
                        cellSubType.Text = tab.Rows[cnt]["Feature"].ToString();
                        row.Controls.Add(cellSubType);

                        if (DropDownListType.SelectedIndex > 0)
                        {
                            TableCell cell_edit = new TableCell();
                            LinkButton lbtn_edit = new LinkButton();
                            lbtn_edit.ForeColor = System.Drawing.Color.Red;
                            lbtn_edit.Font.Bold = true;
                            lbtn_edit.Text = "Edit";
                            lbtn_edit.ID = "Edit~" + tab.Rows[cnt]["FeatureId"].ToString();
                            lbtn_edit.Click += new EventHandler(lbtn_edit_Click);
                            cell_edit.Controls.Add(lbtn_edit);
                            row.Controls.Add(cell_edit);

                            TableCell cell_delete = new TableCell();
                            LinkButton lbtn_delete = new LinkButton();
                            lbtn_delete.ForeColor = System.Drawing.Color.Red;
                            lbtn_delete.Text = "Delete";
                            lbtn_delete.Font.Bold = true;
                            lbtn_delete.ID = "Delete~" + tab.Rows[cnt]["FeatureId"].ToString();
                            lbtn_delete.OnClientClick = "return confirm('Are you sure want to delete this record?')";
                            lbtn_delete.Click += new EventHandler(lbtn_delete_Click);
                            cell_delete.Controls.Add(lbtn_delete);
                            row.Controls.Add(cell_delete);
                        }
                        else
                        {

                        }

                        tableFeatures.Controls.Add(row);
                    }

                }
                else
                {
                    tableFeatures.Rows.Clear();

                    tableFeatures.BorderStyle = BorderStyle.None;
                    tableFeatures.GridLines = GridLines.None;

                    TableHeaderRow row = new TableHeaderRow();
                    TableHeaderCell cell = new TableHeaderCell();
                    cell.ColumnSpan = 5;
                    cell.Font.Bold = true;
                    cell.ForeColor = System.Drawing.Color.Red;
                    cell.Text = "No Values Found";
                    row.Controls.Add(cell);

                    tableFeatures.Controls.Add(row);
                }
            }
            catch
            {

            }

        }

        //click event to delete disease
        void lbtn_delete_Click(object sender, EventArgs e)
        {
            try
            {
                LinkButton btn = (LinkButton)sender;
                string[] s = btn.ID.Split('~');

                BLL obj = new BLL();
                obj.DeleteFeature(int.Parse(s[1].ToString()));

                ClientScript.RegisterStartupScript(this.GetType(), "key", "<script>alert('Value Deleted Successfully!!!')</script>");
                LoadFeatures();
                ClearTextboxes();
                btnSubmit.Text = "Submit";
            }
            catch
            {
                ClientScript.RegisterStartupScript(this.GetType(), "key", "<script>alert('First Delete Related Constraint!!!')</script>");
            }
        }

        //click event to edit disease details
        void lbtn_edit_Click(object sender, EventArgs e)
        {
            try
            {
                LinkButton btn = (LinkButton)sender;
                string[] s = btn.ID.Split('~');

                DataTable tabFeature = new DataTable();
                BLL obj = new BLL();

                tabFeature = obj.GetFeatureById(int.Parse(s[1].ToString()));

                txtFeature.Value = tabFeature.Rows[0]["Feature"].ToString();

                int subtypeId = int.Parse(tabFeature.Rows[0]["FeatureId"].ToString());
                int typeId = int.Parse(tabFeature.Rows[0]["FeatureTypeId"].ToString());

                Session["FeatureId"] = null;
                Session["FeatureId"] = subtypeId;

                Session["Feature"] = null;
                Session["Feature"] = tabFeature.Rows[0]["Feature"].ToString();

                string dataTextField = DropDownListType.Items.FindByValue(typeId.ToString()).ToString();

                ListItem item = new ListItem(dataTextField, typeId.ToString());
                int index = DropDownListType.Items.IndexOf(item);

                if (index != -1)

                    DropDownListType.SelectedIndex = index;

                DropDownListType_SelectedIndexChanged(sender, e);
                btnSubmit.Text = "Update";
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

                if (btnSubmit.Text == "Submit")
                {
                    if (DropDownListType.SelectedIndex > 0)
                    {
                        if (obj.CheckFeature(int.Parse(DropDownListType.SelectedValue), txtFeature.Value))
                        {
                            obj.InsertFeature(int.Parse(DropDownListType.SelectedValue.ToString()), txtFeature.Value);
                            ClientScript.RegisterStartupScript(this.GetType(), "key", "<script>alert('New Value Added Successfully')</script>");
                            ClearTextboxes();
                            DropDownListType_SelectedIndexChanged(sender, e);
                        }
                        else
                        {
                            ClientScript.RegisterStartupScript(this.GetType(), "key", "<script>alert('Value Exists!!!')</script>");
                        }
                    }
                    else
                    {
                        ClientScript.RegisterStartupScript(this.GetType(), "key", "<script>alert('Select Constraint!!!')</script>");
                    }
                }
                else if (btnSubmit.Text == "Update")
                {
                    if (DropDownListType.SelectedIndex > 0)
                    {
                        if (Session["Feature"].Equals(txtFeature.Value))
                        {
                            obj.UpdateFeature(int.Parse(DropDownListType.SelectedValue), txtFeature.Value, int.Parse(Session["FeatureId"].ToString()));
                            ClientScript.RegisterStartupScript(this.GetType(), "Key", "<script>alert('Value Updated Successfully')</script>");
                            ClearTextboxes();

                            btnSubmit.Text = "Submit";
                            DropDownListType_SelectedIndexChanged(sender, e);
                        }
                        else
                        {
                            if (obj.CheckFeature(int.Parse(DropDownListType.SelectedValue), txtFeature.Value))
                            {
                                obj.UpdateFeature(int.Parse(DropDownListType.SelectedValue.ToString()), txtFeature.Value, int.Parse(Session["FeatureId"].ToString()));
                                ClientScript.RegisterStartupScript(this.GetType(), "Key", "<script>alert('Value Updated Successfully')</script>");
                                ClearTextboxes();

                                btnSubmit.Text = "Submit";
                                DropDownListType_SelectedIndexChanged(sender, e);
                            }
                            else
                            {
                                ClientScript.RegisterStartupScript(this.GetType(), "key", "<script>alert('Value Exists!!!')</script>");
                            }
                        }

                    }
                    else
                    {
                        ClientScript.RegisterStartupScript(this.GetType(), "key", "<script>alert('Select Constraint!!!')</script>");
                    }
                }
            }
            catch
            {

            }
        }

        //function to clear the textboxes
        private void ClearTextboxes()
        {
            txtFeature.Value = string.Empty;
            btnSubmit.Text = "Submit";
        }

        protected void DropDownListType_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadFeatures();
        }

    }
}