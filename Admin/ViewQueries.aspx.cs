using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace cropPrediction.Admin
{
    public partial class ViewQueries : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            loadQueries();
        }

        private void loadQueries()
        {
            try
            {
                DataTable tab = new DataTable();
                BLL obj = new BLL();

                int serialNo = 1;

                tab = obj.GetAllQueries();

                if (tab.Rows.Count > 0)
                {
                    Table1.Rows.Clear();

                    Table1.BorderStyle = BorderStyle.Double;
                    Table1.GridLines = GridLines.Both;
                    Table1.BorderColor = System.Drawing.Color.DarkGray;

                    TableRow mainrow = new TableRow();
                    mainrow.Height = 30;
                    mainrow.ForeColor = System.Drawing.Color.WhiteSmoke;

                    mainrow.BackColor = System.Drawing.Color.SteelBlue;

                    TableCell cell1 = new TableCell();
                    cell1.Text = "<b>SerialNo</b>";
                    mainrow.Controls.Add(cell1);

                    TableCell cell11 = new TableCell();
                    cell11.Text = "<b>Photo</b>";
                    mainrow.Controls.Add(cell11);


                    TableCell cell2 = new TableCell();
                    cell2.Text = "<b>Query</b>";
                    mainrow.Controls.Add(cell2);

                    TableCell cell3 = new TableCell();
                    cell3.Text = "<b>Posted Date</b>";
                    mainrow.Controls.Add(cell3);

                    TableCell cell4 = new TableCell();
                    cell4.Text = "<b>Reply</b>";
                    mainrow.Controls.Add(cell4);

                    TableCell cell5 = new TableCell();
                    cell5.Text = "<b>ReplyDate</b>";
                    mainrow.Controls.Add(cell5);

                    TableCell cell51 = new TableCell();
                    cell51.Text = "<b>Reply</b>";
                    mainrow.Controls.Add(cell51);

                    TableCell cell6 = new TableCell();
                    cell6.Text = "<b>Delete</b>";
                    mainrow.Controls.Add(cell6);

                    Table1.Controls.Add(mainrow);

                    for (int i = 0; i < tab.Rows.Count; i++)
                    {
                        TableRow row = new TableRow();

                        TableCell cellSerialNo = new TableCell();
                        cellSerialNo.Width = 50;
                        cellSerialNo.Text = serialNo + i + ".";
                        row.Controls.Add(cellSerialNo);

                        TableCell cellPic = new TableCell();
                        cellPic.Width = 100;
                        Image imgPic = new Image();
                        imgPic.ImageUrl = tab.Rows[i]["Photo"].ToString();
                        cellPic.Controls.Add(imgPic);
                        row.Controls.Add(cellPic);

                        TableCell cellUserId = new TableCell();
                        cellUserId.Width = 350;
                        cellUserId.Text = tab.Rows[i]["Query"].ToString();
                        row.Controls.Add(cellUserId);

                        TableCell cellPassword = new TableCell();
                        cellPassword.Width = 150;
                        cellPassword.Text = tab.Rows[i]["PostedDate"].ToString();
                        row.Controls.Add(cellPassword);

                        TableCell cellEmailId = new TableCell();
                        cellEmailId.Width = 200;
                        cellEmailId.Text = tab.Rows[i]["Reply"].ToString();
                        row.Controls.Add(cellEmailId);

                        TableCell cellEmailId1 = new TableCell();
                        cellEmailId1.Width = 200;
                        cellEmailId1.Text = tab.Rows[i]["ReplyDate"].ToString();
                        row.Controls.Add(cellEmailId1);

                        TableCell cell_edit = new TableCell();
                        LinkButton lbtn_edit = new LinkButton();
                        lbtn_edit.ForeColor = System.Drawing.Color.SteelBlue;
                        lbtn_edit.Font.Bold = true;
                        lbtn_edit.Text = "SendReply";
                        lbtn_edit.ID = "Edit~" + tab.Rows[i]["QueryId"].ToString();
                        lbtn_edit.Click += new EventHandler(lbtn_edit_Click);
                        cell_edit.Controls.Add(lbtn_edit);
                        row.Controls.Add(cell_edit);

                        TableCell cell_delete = new TableCell();
                        LinkButton lbtn_delete = new LinkButton();
                        lbtn_delete.ForeColor = System.Drawing.Color.Red;
                        lbtn_delete.Font.Bold = true;
                        lbtn_delete.Text = "Delete";

                        lbtn_delete.ID = "Delete~" + tab.Rows[i]["QueryId"].ToString();
                        lbtn_delete.OnClientClick = "return confirm('Are you sure want to delete this record?')";
                        lbtn_delete.Click += new EventHandler(lbtn_delete_Click);
                        cell_delete.Controls.Add(lbtn_delete);
                        row.Controls.Add(cell_delete);

                        Table1.Controls.Add(row);
                    }
                }
                else
                {
                    Table1.Rows.Clear();

                    TableHeaderRow rno = new TableHeaderRow();
                    TableHeaderCell cellno = new TableHeaderCell();
                    cellno.ForeColor = System.Drawing.Color.Red;
                    cellno.Text = "No Queries Found!!!";

                    rno.Controls.Add(cellno);
                    Table1.Controls.Add(rno);
                }
            }
            catch
            {

            }

        }        

        void lbtn_delete_Click(object sender, EventArgs e)
        {
            BLL obj = new BLL();
            LinkButton lbtn = (LinkButton)sender;
            string[] s = lbtn.ID.ToString().Split('~');

            try
            {
                obj.deleteQuery(int.Parse(s[1]));

                ClientScript.RegisterStartupScript(this.GetType(), "Key", "<Script>alert('Staff Deleted Successfully')</script>");
                loadQueries();

            }
            catch
            {
                ClientScript.RegisterStartupScript(this.GetType(), "Key", "<Script>alert('Server Error!!!')</script>");
            }
        }

        //click event to edit the details
        void lbtn_edit_Click(object sender, EventArgs e)
        {
            BLL obj = new BLL();
            LinkButton lbtn = (LinkButton)sender;
            string[] s = lbtn.ID.ToString().Split('~');

            try
            {
                Response.Redirect(string.Format("Replypage.aspx?Id={0}", s[1]));
            }
            catch
            {
                ClientScript.RegisterStartupScript(this.GetType(), "Key", "<Script>alert('Server Error!!!')</script>");
            }
        }
    }
}