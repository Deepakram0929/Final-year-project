using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.OleDb;
using System.Data;
using System.IO;
using System.Collections;
using System.Threading;
using System.Configuration;

namespace cropPrediction.Farmer
{
    public partial class FarmerHome : System.Web.UI.Page
    {
        public static OleDbConnection oledbConn;
        static DataTable dt = new DataTable();
        static DataTable dtDistinct = new DataTable();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                loadQueries();
            }
        }

        private void loadQueries()
        {
            try
            {
                DataTable tab = new DataTable();
                BLL obj = new BLL();

                int serialNo = 1;

                tab = obj.GetQueryiesBYUserId(Session["FarmerId"].ToString());

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


        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                BLL obj = new BLL();

                string photoName = System.IO.Path.GetFileName(fileuploadPhoto.PostedFile.FileName);

                int index = photoName.LastIndexOf('.');
                string ext = photoName.Substring(index + 1);

                string photoPath = Server.MapPath("~/Farmer/Files/" + photoName);
                fileuploadPhoto.PostedFile.SaveAs(photoPath);

                string dbPath = @"/Farmer/Files/" + photoName;

                obj.InsertQuery(Session["FarmerId"].ToString(), txtQuery.Text, DateTime.Now, dbPath);
                ClientScript.RegisterStartupScript(GetType(), "key", "<script>alert('Query Posted to Admin Successfully')</script>");
                loadQueries();
                txtQuery.Text = string.Empty;
            }
            catch
            {

            }
        }
             

    }
}