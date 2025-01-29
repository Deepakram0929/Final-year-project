using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.IO;

namespace cropPrediction.Admin
{
    public partial class Search : System.Web.UI.Page
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

                    txtName.Focus();

                if (!txtName.Value.Equals(""))
                {
                    LoadFarmers(("%" + txtName.Value + "%"));
                }
            }
        }


        //function to load all farmers
        private void LoadFarmers(string parameter)
        {
            try
            {
                DataTable tab = new DataTable();
                BLL obj = new BLL();

                tab = obj.GetFarmersByName(parameter);

                if (tab.Rows.Count > 0)
                {
                    tableFarmers.Rows.Clear();

                    tableFarmers.BorderStyle = BorderStyle.Double;
                    tableFarmers.GridLines = GridLines.Both;
                    tableFarmers.BorderColor = System.Drawing.Color.DarkGray;

                    TableRow mainrow = new TableRow();
                    mainrow.Height = 30;
                    mainrow.ForeColor = System.Drawing.Color.WhiteSmoke;

                    mainrow.BackColor = System.Drawing.Color.DarkGray;
                                       
                    TableCell cell2 = new TableCell();
                    cell2.Text = "<b>Farmer Name</b>";
                    mainrow.Controls.Add(cell2);

                    TableCell cell3 = new TableCell();
                    cell3.Text = "<b>Age</b>";
                    mainrow.Controls.Add(cell3);

                    TableCell cell4 = new TableCell();
                    cell4.Text = "<b>Gender</b>";
                    mainrow.Controls.Add(cell4);

                    TableCell cell5 = new TableCell();
                    cell5.Text = "<b>Marital</b>";
                    mainrow.Controls.Add(cell5);

                    //TableCell cell6 = new TableCell();
                    //cell6.Text = "<b>Occupation</b>";
                    //mainrow.Controls.Add(cell6);

                    TableCell cell7 = new TableCell();
                    cell7.Text = "<b>Address</b>";
                    mainrow.Controls.Add(cell7);

                    TableCell cell8 = new TableCell();
                    cell8.Text = "<b>ContactNo</b>";
                    mainrow.Controls.Add(cell8);

                    //TableCell cell9 = new TableCell();
                    //cell9.Text = "<b>EmailId</b>";
                    //mainrow.Controls.Add(cell9);

                    TableCell cell10 = new TableCell();
                    cell10.Text = "<b>AdmittedDate</b>";
                    mainrow.Controls.Add(cell10);

                    TableCell cell12 = new TableCell();
                    cell12.Text = "<b>Delete</b>";
                    mainrow.Controls.Add(cell12);

                    TableCell cell13 = new TableCell();
                    cell13.Text = "<b>AddAttribute</b>";
                    mainrow.Controls.Add(cell13);

                    tableFarmers.Controls.Add(mainrow);

                    for (int i = 0; i < tab.Rows.Count; i++)
                    {
                        TableRow row = new TableRow();
                                                
                        TableCell cellName = new TableCell();
                        cellName.Width = 150;
                        cellName.Text = tab.Rows[i]["FarmerName"].ToString();
                        row.Controls.Add(cellName);

                        TableCell cellAge = new TableCell();
                        cellAge.Width = 20;
                        cellAge.Text = tab.Rows[i]["Age"].ToString();
                        row.Controls.Add(cellAge);

                        TableCell cellGender = new TableCell();
                        cellGender.Width = 100;
                        cellGender.Text = tab.Rows[i]["Gender"].ToString();
                        row.Controls.Add(cellGender);

                        TableCell cellMaritalStatus = new TableCell();
                        cellMaritalStatus.Width = 100;
                        cellMaritalStatus.Text = tab.Rows[i]["MaritalStatus"].ToString();
                        row.Controls.Add(cellMaritalStatus);

                        //TableCell cellOccupation = new TableCell();
                        //cellOccupation.Width = 100;
                        //cellOccupation.Text = tab.Rows[i]["Occupation"].ToString();
                        //row.Controls.Add(cellOccupation);

                        TableCell cellAddress = new TableCell();
                        cellAddress.Width = 150;
                        cellAddress.Text = tab.Rows[i]["Address"].ToString();
                        row.Controls.Add(cellAddress);

                        TableCell cellContactNo = new TableCell();
                        cellContactNo.Width = 100;
                        cellContactNo.Text = tab.Rows[i]["ContactNo"].ToString();
                        row.Controls.Add(cellContactNo);

                        //TableCell cellEmailId = new TableCell();
                        //cellEmailId.Width = 100;
                        //cellEmailId.Text = tab.Rows[i]["EmailId"].ToString();
                        //row.Controls.Add(cellEmailId);

                        TableCell cellAdmittedDate = new TableCell();
                        cellAdmittedDate.Width = 100;
                        string[] s = tab.Rows[i]["AdmittedDate"].ToString().Split(' ');
                        cellAdmittedDate.Text = s[0];
                        row.Controls.Add(cellAdmittedDate);

                        TableCell cell_delete = new TableCell();
                        LinkButton lbtn_delete = new LinkButton();
                        lbtn_delete.ForeColor = System.Drawing.Color.Red;
                        lbtn_delete.Text = "Delete";

                        lbtn_delete.ID = "Delete~" + tab.Rows[i]["FarmerId"].ToString();
                        lbtn_delete.OnClientClick = "return confirm('Are you sure want to delete this record?')";
                        lbtn_delete.Click += new EventHandler(lbtn_delete_Click);
                        cell_delete.Controls.Add(lbtn_delete);
                        row.Controls.Add(cell_delete);


                        TableCell cellAttributes = new TableCell();
                        LinkButton lbtnAttributes = new LinkButton();
                        lbtnAttributes.ForeColor = System.Drawing.Color.Red;
                        lbtnAttributes.Text = "Attributes";

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
                    cellno.Text = "No Farmer Records Found for the specified input";

                    rno.Controls.Add(cellno);
                    tableFarmers.Controls.Add(rno);
                }
            }
            catch
            {

            }
        }

        void lbtnAttributes_Click(object sender, EventArgs e)
        {
            LinkButton lbtn = (LinkButton)sender;
            string[] s = lbtn.ID.ToString().Split('~');

            Response.Redirect(string.Format("SoilFeatures.aspx?farmerId={0}", s[1]));
        }

        //event to delete farmer
        void lbtn_delete_Click(object sender, EventArgs e)
        {
            BLL obj = new BLL();
            LinkButton lbtn = (LinkButton)sender;
            string[] s = lbtn.ID.ToString().Split('~');

            try
            {
                obj.DeleteFarmer(int.Parse(s[1].ToString()));

                ClientScript.RegisterStartupScript(this.GetType(), "Key", "<Script>alert('Farmer Deleted Successfully')</script>");
                LoadFarmers(("%" + txtName.Value + "%"));

            }
            catch
            {
                ClientScript.RegisterStartupScript(this.GetType(), "Key", "<Script>alert('Server Error!!!')</script>");
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            LoadFarmers(("%" + txtName.Value + "%"));
        }

    }
}