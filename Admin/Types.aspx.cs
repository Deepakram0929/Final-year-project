using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace cropPrediction.Admin
{
    public partial class Types : System.Web.UI.Page
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

                    txtType.Focus();

                LoadTypes();
            }         
        }

        //function to load all types
        private void LoadTypes()
        {
            try
            {
                DataTable tab = new DataTable();
                BLL obj = new BLL();

                int serialNo = 1;

                tab = obj.GetTypes();

                if (tab.Rows.Count > 0)
                {
                    tableTypes.Rows.Clear();

                    tableTypes.BorderStyle = BorderStyle.Double;
                    tableTypes.GridLines = GridLines.Both;
                    tableTypes.BorderColor = System.Drawing.Color.DarkGray;

                    TableHeaderRow mainrow = new TableHeaderRow();
                    mainrow.Height = 30;
                    mainrow.ForeColor = System.Drawing.Color.WhiteSmoke;

                    mainrow.BackColor = System.Drawing.Color.SteelBlue;

                    TableCell cell1 = new TableCell();
                    cell1.Text = "<b>SerialNo</b>";
                    mainrow.Controls.Add(cell1);

                    TableCell cell2 = new TableCell();
                    cell2.Text = "<b>Crop Type</b>";
                    mainrow.Controls.Add(cell2);

                    TableCell cell3 = new TableCell();
                    cell3.Text = "<b>Edit</b>";
                    mainrow.Controls.Add(cell3);

                    TableCell cell4 = new TableCell();
                    cell4.Text = "<b>Delete</b>";
                    mainrow.Controls.Add(cell4);

                    tableTypes.Controls.Add(mainrow);

                    for (int i = 0; i < tab.Rows.Count; i++)
                    {
                        TableRow row = new TableRow();

                        TableCell cellSerialNo = new TableCell();
                        cellSerialNo.Width = 50;
                        cellSerialNo.Text = serialNo + i + ".";
                        row.Controls.Add(cellSerialNo);

                        TableCell cellType = new TableCell();
                        cellType.Width = 250;
                        cellType.Text = tab.Rows[i]["Type"].ToString();
                        row.Controls.Add(cellType);

                        TableCell cell_edit = new TableCell();
                        LinkButton lbtn_edit = new LinkButton();
                        lbtn_edit.ForeColor = System.Drawing.Color.Red;
                        lbtn_edit.Text = "Edit";
                        lbtn_edit.ID = "Edit~" + tab.Rows[i]["TypeId"].ToString();
                        lbtn_edit.Click += new EventHandler(lbtn_edit_Click);
                        cell_edit.Controls.Add(lbtn_edit);
                        row.Controls.Add(cell_edit);

                        TableCell cell_delete = new TableCell();
                        LinkButton lbtn_delete = new LinkButton();
                        lbtn_delete.ForeColor = System.Drawing.Color.Red;
                        lbtn_delete.Text = "Delete";

                        lbtn_delete.ID = "Delete~" + tab.Rows[i]["TypeId"].ToString();
                        lbtn_delete.OnClientClick = "return confirm('Are you sure want to delete this record?')";
                        lbtn_delete.Click += new EventHandler(lbtn_delete_Click);
                        cell_delete.Controls.Add(lbtn_delete);
                        row.Controls.Add(cell_delete);

                        tableTypes.Controls.Add(row);
                    }
                }
                else
                {
                    tableTypes.Rows.Clear();

                    tableTypes.BorderStyle = BorderStyle.None;
                    tableTypes.GridLines = GridLines.None;

                    TableHeaderRow rno = new TableHeaderRow();
                    TableHeaderCell cellno = new TableHeaderCell();
                    cellno.ForeColor = System.Drawing.Color.Red;
                    cellno.Text = "No Crop Types Found";

                    rno.Controls.Add(cellno);
                    tableTypes.Controls.Add(rno);
                }
            }
            catch
            {

            }
        }

        //event to delete cacner type
        void lbtn_delete_Click(object sender, EventArgs e)
        {
            BLL obj = new BLL();
            LinkButton lbtn = (LinkButton)sender;
            string[] s = lbtn.ID.ToString().Split('~');

            try
            {
                obj.DeleteType(int.Parse(s[1].ToString()));

                ClientScript.RegisterStartupScript(this.GetType(), "Key", "<Script>alert('Crop Type Deleted Successfully')</script>");
                LoadTypes();
                txtType.Value = string.Empty;
            }
            catch
            {
                ClientScript.RegisterStartupScript(this.GetType(), "Key", "<Script>alert('First Delete Crops,features,farmers!!!')</script>");
            }
        }

        //click event to edit the cancer type details
        void lbtn_edit_Click(object sender, EventArgs e)
        {
            try
            {
                BLL obj = new BLL();
                LinkButton lbtn = (LinkButton)sender;
                string[] s = lbtn.ID.ToString().Split('~');

                Session["typeId"] = null;
                Session["typeId"] = s[1];

                DataTable tab = new DataTable();
                tab = obj.GetTypeById(int.Parse(s[1].ToString()));

                if (tab.Rows.Count > 0)
                {
                    Session["type"] = null;
                    Session["type"] = tab.Rows[0]["Type"].ToString();

                    txtType.Value = tab.Rows[0]["Type"].ToString();
                }

                btnSubmit.Text = "Update";
            }
            catch
            {

            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            BLL obj = new BLL();

            if (btnSubmit.Text.Equals("Submit"))
            {
                try
                {
                    if (obj.CheckType(txtType.Value))
                    {
                        obj.InsertType(txtType.Value);

                        ClientScript.RegisterStartupScript(this.GetType(), "Key", "<Script>alert('New Crop Type Added Successfully')</script>");
                        txtType.Value = string.Empty;
                        LoadTypes();
                    }
                    else
                    {
                        ClientScript.RegisterStartupScript(this.GetType(), "Key", "<Script>alert('Crop Type Exists!!!')</script>");
                    }
                }
                catch
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "Key", "<Script>alert('Server Error!')</script>");
                }
            }
            else if (btnSubmit.Text.Equals("Update"))
            {
                if (txtType.Value.Equals(Session["type"].ToString()))
                {
                    try
                    {
                        obj.UpdateType(txtType.Value, int.Parse(Session["typeId"].ToString()));

                        ClientScript.RegisterStartupScript(this.GetType(), "Key", "<Script>alert('Crop Type Updated Successfully')</script>");
                        txtType.Value = string.Empty;
                        LoadTypes();

                        btnSubmit.Text = "Submit";
                    }
                    catch
                    {
                        ClientScript.RegisterStartupScript(this.GetType(), "Key", "<Script>alert('Server Error!')</script>");
                    }
                }
                else
                {
                    if (obj.CheckType(txtType.Value))
                    {
                        try
                        {
                            obj.UpdateType(txtType.Value, int.Parse(Session["typeId"].ToString()));

                            ClientScript.RegisterStartupScript(this.GetType(), "Key", "<Script>alert('Crop Type Updated Successfully')</script>");
                            txtType.Value = string.Empty;
                            LoadTypes();

                            btnSubmit.Text = "Submit";
                        }
                        catch
                        {
                            ClientScript.RegisterStartupScript(this.GetType(), "Key", "<Script>alert('Server Error!')</script>");
                        }
                    }
                    else
                    {
                        ClientScript.RegisterStartupScript(this.GetType(), "Key", "<Script>alert('Crop Type Exists')</script>");
                    }
                }
            }
        }

    }
}