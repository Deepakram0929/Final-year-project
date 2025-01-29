using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace cropPrediction.Admin
{
    public partial class Crops : System.Web.UI.Page
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
                    txtCrop.Focus();
                }

                LoadCrops();
            }
        }

        //function to retrive all types
        private void LoadTypes()
        {
            try
            {
                DataTable tab = new DataTable();
                BLL obj = new BLL();

                tab = obj.GetTypes();

                if (tab.Rows.Count > 0)
                {
                    DropDownListType.Items.Clear();

                    DropDownListType.DataSource = tab;
                    DropDownListType.DataTextField = "Type";
                    DropDownListType.DataValueField = "TypeId";
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

        //function to retrive crops
        private void LoadCrops()
        {
            try
            {
                int serialNo = 1;

                DataTable tab = new DataTable();
                BLL obj = new BLL();

                if (DropDownListType.SelectedIndex > 0)
                {
                    tab = obj.GetCropsByType(int.Parse(DropDownListType.SelectedValue));
                }
                else
                {
                    tab = obj.GetAllCrops();
                }

                if (tab.Rows.Count > 0)
                {
                    tableCrops.Rows.Clear();

                    tableCrops.BorderStyle = BorderStyle.Double;
                    tableCrops.GridLines = GridLines.Both;
                    tableCrops.BorderColor = System.Drawing.Color.DarkGray;

                    TableHeaderRow headerrow = new TableHeaderRow();
                    headerrow.Height = 30;
                    headerrow.ForeColor = System.Drawing.Color.WhiteSmoke;
                    headerrow.BackColor = System.Drawing.Color.SteelBlue;

                    TableCell cell1 = new TableCell();
                    cell1.Text = "<b>SLNo</b>";
                    headerrow.Controls.Add(cell1);

                    TableCell cell3 = new TableCell();
                    cell3.Text = "<b>Crop Type</b>";
                    headerrow.Controls.Add(cell3);

                    TableCell cell4 = new TableCell();
                    cell4.Text = "<b>Crop</b>";
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

                    tableCrops.Controls.Add(headerrow);

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
                        tabType = obj.GetTypeById(int.Parse(tab.Rows[cnt]["TypeId"].ToString()));

                        cellType.Text = tabType.Rows[0]["Type"].ToString();
                        row.Controls.Add(cellType);

                        TableCell cellSubType = new TableCell();
                        cellSubType.Width = 150;
                        cellSubType.Text = tab.Rows[cnt]["Crop"].ToString();
                        row.Controls.Add(cellSubType);

                        if (DropDownListType.SelectedIndex > 0)
                        {
                            TableCell cell_edit = new TableCell();
                            LinkButton lbtn_edit = new LinkButton();
                            lbtn_edit.ForeColor = System.Drawing.Color.Red;
                            lbtn_edit.Font.Bold = true;
                            lbtn_edit.Text = "Edit";
                            lbtn_edit.ID = "Edit~" + tab.Rows[cnt]["CropId"].ToString();
                            lbtn_edit.Click += new EventHandler(lbtn_edit_Click);
                            cell_edit.Controls.Add(lbtn_edit);
                            row.Controls.Add(cell_edit);

                            TableCell cell_delete = new TableCell();
                            LinkButton lbtn_delete = new LinkButton();
                            lbtn_delete.ForeColor = System.Drawing.Color.Red;
                            lbtn_delete.Text = "Delete";
                            lbtn_delete.Font.Bold = true;
                            lbtn_delete.ID = "Delete~" + tab.Rows[cnt]["CropId"].ToString();
                            lbtn_delete.OnClientClick = "return confirm('Are you sure want to delete this record?')";
                            lbtn_delete.Click += new EventHandler(lbtn_delete_Click);
                            cell_delete.Controls.Add(lbtn_delete);
                            row.Controls.Add(cell_delete);
                        }
                        else
                        {

                        }

                        tableCrops.Controls.Add(row);
                    }

                }
                else
                {
                    tableCrops.Rows.Clear();

                    tableCrops.BorderStyle = BorderStyle.None;
                    tableCrops.GridLines = GridLines.None;

                    TableHeaderRow row = new TableHeaderRow();
                    TableHeaderCell cell = new TableHeaderCell();
                    cell.ColumnSpan = 5;
                    cell.Font.Bold = true;
                    cell.ForeColor = System.Drawing.Color.Red;
                    cell.Text = "No Crops Found";
                    row.Controls.Add(cell);

                    tableCrops.Controls.Add(row);
                }
            }
            catch
            {

            }

        }

        //click event to delete crop
        void lbtn_delete_Click(object sender, EventArgs e)
        {
            try
            {
                LinkButton btn = (LinkButton)sender;
                string[] s = btn.ID.Split('~');

                BLL obj = new BLL();
                obj.DeleteCrop(int.Parse(s[1].ToString()));

                ClientScript.RegisterStartupScript(this.GetType(), "key", "<script>alert('Crop Deleted Successfully!!!')</script>");
                LoadCrops();
                ClearTextboxes();
                btnSubmit.Text = "Submit";
            }
            catch
            {
                ClientScript.RegisterStartupScript(this.GetType(), "key", "<script>alert('First Delete Related Data!!!')</script>");
            }
        }

        //click event to edit crop details
        void lbtn_edit_Click(object sender, EventArgs e)
        {
            try
            {
                LinkButton btn = (LinkButton)sender;
                string[] s = btn.ID.Split('~');

                DataTable tabCrop = new DataTable();
                BLL obj = new BLL();

                tabCrop = obj.GetCropById(int.Parse(s[1].ToString()));

                txtCrop.Value = tabCrop.Rows[0]["Crop"].ToString();

                int subtypeId = int.Parse(tabCrop.Rows[0]["CropId"].ToString());
                int typeId = int.Parse(tabCrop.Rows[0]["TypeId"].ToString());

                Session["CropId"] = null;
                Session["CropId"] = subtypeId;

                Session["Crop"] = null;
                Session["Crop"] = tabCrop.Rows[0]["Crop"].ToString();

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
                        if (obj.CheckCrop(int.Parse(DropDownListType.SelectedValue), txtCrop.Value))
                        {
                            obj.InsertCrop(int.Parse(DropDownListType.SelectedValue.ToString()), txtCrop.Value);
                            ClientScript.RegisterStartupScript(this.GetType(), "key", "<script>alert('New Crop Added Successfully')</script>");
                            ClearTextboxes();
                            DropDownListType_SelectedIndexChanged(sender, e);
                        }
                        else
                        {
                            ClientScript.RegisterStartupScript(this.GetType(), "key", "<script>alert('Crop Name Exists!!!')</script>");
                        }
                    }
                    else
                    {
                        ClientScript.RegisterStartupScript(this.GetType(), "key", "<script>alert('Select Type!!!')</script>");
                    }
                }
                else if (btnSubmit.Text == "Update")
                {
                    if (DropDownListType.SelectedIndex > 0)
                    {
                        if (Session["Crop"].Equals(txtCrop.Value))
                        {
                            obj.UpdateCrop(int.Parse(DropDownListType.SelectedValue), txtCrop.Value, int.Parse(Session["CropId"].ToString()));
                            ClientScript.RegisterStartupScript(this.GetType(), "Key", "<script>alert('Crop Updated Successfully')</script>");
                            ClearTextboxes();

                            btnSubmit.Text = "Submit";
                            DropDownListType_SelectedIndexChanged(sender, e);
                        }
                        else
                        {
                            if (obj.CheckCrop(int.Parse(DropDownListType.SelectedValue), txtCrop.Value))
                            {
                                obj.UpdateCrop(int.Parse(DropDownListType.SelectedValue.ToString()), txtCrop.Value, int.Parse(Session["CropId"].ToString()));
                                ClientScript.RegisterStartupScript(this.GetType(), "Key", "<script>alert('Crop Updated Successfully')</script>");
                                ClearTextboxes();

                                btnSubmit.Text = "Submit";
                                DropDownListType_SelectedIndexChanged(sender, e);
                            }
                            else
                            {
                                ClientScript.RegisterStartupScript(this.GetType(), "key", "<script>alert('Crop Name Exists!!!')</script>");
                            }
                        }

                    }
                    else
                    {
                        ClientScript.RegisterStartupScript(this.GetType(), "key", "<script>alert('Select Type!!!')</script>");
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
            txtCrop.Value = string.Empty;
            btnSubmit.Text = "Submit";
        }

        protected void DropDownListType_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadCrops();
        }
    }
}