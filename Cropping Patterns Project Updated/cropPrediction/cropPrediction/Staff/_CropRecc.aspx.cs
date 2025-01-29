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

namespace cropPrediction.Staff
{
    public partial class _CropRecc : System.Web.UI.Page
    {
        public static OleDbConnection oledbConn;
        static DataTable dt = new DataTable();
        static DataTable dtDistinct = new DataTable();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                LoadLocs();
                //loadParameterValues();
            }
        }

        private void LoadLocs()
        {
            try
            {
                BLL obj = new BLL();
                DataTable tab = new DataTable();

                tab = obj.GetUsersByType("Staff");

                if (tab.Rows.Count > 0)
                {
                    ddlLoc.Items.Clear();
                    ddlLoc.DataSource = tab;
                    ddlLoc.DataTextField = "UserId";
                    ddlLoc.DataValueField = "UserId";

                    ddlLoc.DataBind();

                    string _fID = Session["StaffId"].ToString();

                    DataTable tabDetails = new DataTable();
                    tabDetails = obj.GetUserById(_fID);

                    string dataTextField = ddlLoc.Items.FindByValue(tabDetails.Rows[0]["UserId"].ToString()).ToString();

                    ListItem item = new ListItem(dataTextField, dataTextField);
                    int index = ddlLoc.Items.IndexOf(item);

                    if (index != -1)

                        ddlLoc.SelectedIndex = index;

                    ddlLoc.Enabled = false;

                }
            }
            catch
            {

            }
        }

        private void loadParameterValues()
        {
            txtPH.Text = "7.2";
            txtOrganicCarbon.Text = "6";
            txtNitrogen.Text = "127.4";
            txtPhosphorus.Text = "6";
            txtPotassium.Text = "6.3";

            txtSulphur.Text = "110";
            txtZinc.Text = "158";
            txtIron.Text = "7.2";
            txtTemperature.Text = "26.12";
            txtRainfall.Text = "68.21";            
        }

        private void TrainingDS()
        {
            if (ddlLoc.SelectedItem.Text.Equals("mysore") || ddlLoc.SelectedItem.Text.Equals("mandya") || ddlLoc.SelectedItem.Text.Equals("theerthHalli") ||
                ddlLoc.SelectedItem.Text.Equals("Mysore") || ddlLoc.SelectedItem.Text.Equals("Mandya") || ddlLoc.SelectedItem.Text.Equals("TheerthHalli"))
            {
                string FileName = "CropTrainingDataset_" + Session["StaffId"].ToString() + ".xls";

                string Extension = ".xls";

                string FolderPath = ConfigurationManager.AppSettings["FolderPath"];

                string _Location = "CropTrainingDataset_" + Session["StaffId"].ToString() + "";

                string FilePath = Server.MapPath(FolderPath + FileName);

                ImportTrainingDS(FilePath, Extension, _Location);
            }
            else
            {
                btnPrediction.Visible = false;
                ClientScript.RegisterStartupScript(this.GetType(), "Key", "<Script>alert('No Training Dataset!!!')</script>");
            }
        }

        private void ImportTrainingDS(string FilePath, string Extension, string _Location)
        {
            string conStr = "";

            switch (Extension)
            {
                case ".xls": //Excel 97-03

                    conStr = ConfigurationManager.ConnectionStrings["Excel03ConString"]

                             .ConnectionString;

                    break;

                case ".xlsx": //Excel 07

                    conStr = ConfigurationManager.ConnectionStrings["Excel07ConString"]

                              .ConnectionString;

                    break;

            }

            conStr = String.Format(conStr, FilePath, _Location);

            OleDbConnection connExcel = new OleDbConnection(conStr);

            OleDbCommand cmdExcel = new OleDbCommand();
            OleDbCommand cmdDistinct = new OleDbCommand();

            OleDbDataAdapter oda = new OleDbDataAdapter();
            OleDbDataAdapter odaDistinct = new OleDbDataAdapter();

            cmdExcel.Connection = connExcel;
            cmdDistinct.Connection = connExcel;

            //Get the name of First Sheet

            connExcel.Open();

            DataTable dtExcelSchema;

            dtExcelSchema = connExcel.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);

            string SheetName = dtExcelSchema.Rows[0]["TABLE_NAME"].ToString();

            connExcel.Close();

            //Read Data from First Sheet

            connExcel.Open();

            cmdExcel.CommandText = "SELECT * From [" + SheetName + "]";

            cmdDistinct.CommandText = "SELECT DISTINCT(Crop) From [" + SheetName + "]";

            oda.SelectCommand = cmdExcel;
            odaDistinct.SelectCommand = cmdDistinct;

            dt.Rows.Clear();
            dtDistinct.Rows.Clear();

            oda.Fill(dt);
            odaDistinct.Fill(dtDistinct);

            //BLL obj = new BLL();

            if (dt.Rows.Count > 0)
            {
                //if (dtDistinct.Rows.Count > 0)
                //{
                //    for (int i = 0; i < dtDistinct.Rows.Count; i++)
                //    {
                //        cmdPatientsCnt.CommandText = "SELECT COUNT(*) From [" + SheetName + "] where RESULT=" + dtDistinct.Rows[i]["RESULT"].ToString() + "";
                //        _arrayPatientsCnt.Add(cmdPatientsCnt.ExecuteScalar());
                //    }
                //}

                connExcel.Close();

            }
            else
            {
                btnPrediction.Visible = false;
                ClientScript.RegisterStartupScript(this.GetType(), "Key", "<Script>alert('No Training Dataset!!!')</script>");
            }
        }

        protected void btnPrediction_Click(object sender, EventArgs e)
        {
            try
            {
                TrainingDS();

                Session["Output"] = null;
                string _Predictedoutput = null;
                string _timeNB = null;

                tablePrediction.Rows.Clear();

                tablePrediction.BorderStyle = BorderStyle.Double;
                tablePrediction.GridLines = GridLines.Both;
                tablePrediction.BorderColor = System.Drawing.Color.Black;

                TableRow mainrow = new TableRow();
                mainrow.Height = 30;
                mainrow.ForeColor = System.Drawing.Color.White;
                mainrow.BackColor = System.Drawing.Color.SteelBlue;


                TableCell cell16 = new TableCell();
                cell16.Text = "<b>Result(Suitable Crop)(rs)</b>";
                mainrow.Controls.Add(cell16);

                tablePrediction.Controls.Add(mainrow);

                var watch = System.Diagnostics.Stopwatch.StartNew();


                //P1, P2, P3, P4
                string _data = txtPH.Text + "," + txtOrganicCarbon.Text + "," +
                            txtNitrogen.Text + "," + txtPhosphorus.Text + "," +
                           txtPotassium.Text + "," + txtSulphur.Text + "," +
                            txtZinc.Text + "," + txtIron.Text + "," +
                            txtTemperature.Text + "," + txtRainfall.Text + ",";

                string[] values = _data.Split(',');

                string _output = NaiveBayes(values);

                TableRow row = new TableRow();

                TableCell cellResult = new TableCell();
                cellResult.Width = 250;
                cellResult.Text = _output;
                row.Controls.Add(cellResult);

                tablePrediction.Controls.Add(row);

                //if (_output.Equals("0"))
                //{
                //    ++_array0Res;
                //}
                //else if (_output.Equals("1"))
                //{
                //    ++_array1Res;
                //}         

                _Predictedoutput += _output + ",";


                watch.Stop();
                var elapsedMs = watch.ElapsedMilliseconds;
                _timeNB = elapsedMs.ToString();

                Session["Output"] = _timeNB + "," + _Predictedoutput.Substring(0, _Predictedoutput.Length - 1);

            }
            catch
            {

            }
        }

        //function to load subject
        public ArrayList GetSubject()
        {
            ArrayList s = new ArrayList();

            if (dtDistinct.Rows.Count > 0)
            {
                for (int i = 0; i < dtDistinct.Rows.Count; i++)
                {
                    s.Add(dtDistinct.Rows[i]["Crop"].ToString());
                }
            }

            return s;
        }

        //protected void btnResults_Click(object sender, EventArgs e)
        //{
        //    btnPrediction_Click(sender, e);
        //    Response.Redirect("Results.aspx");
        //}

        double pi;
        int nc, n;
        double result;
        ArrayList output = new ArrayList();
        ArrayList mul = new ArrayList();


        //function which contains the algorithm steps
        private string NaiveBayes(string[] values)
        {
            ArrayList s = new ArrayList();
            output.Clear();

            //try
            //{
            s = GetSubject();

            int m = 10;
            double numer = 1.0;
            double dino = double.Parse(s.Count.ToString());
            double p = numer / dino;

            string[] features = { "PH","organic carbon(oC)", "nitrogen(n)" , "phosphorus(p)", "potassium(k)",
                                    "sulphur(s)","zinc(zn)","iron(fe)","Temperature","Rainfall" };

            for (int i = 0; i < s.Count; i++)
            {
                mul.Clear();

                for (int j = 0; j < features.Length; j++)
                {
                    n = 0;
                    nc = 0;

                    for (int d = 0; d < dt.Rows.Count; d++)
                    {
                        if (dt.Rows[d][j].ToString().Equals(values[j]))
                        {
                            ++n;

                            if (dt.Rows[d][m].ToString().Equals(s[i]))

                                ++nc;
                        }
                    }

                    double x = m * p;
                    double y = n + m;
                    double z = nc + x;

                    pi = z / y;
                    mul.Add(Math.Abs(pi));
                }

                double mulres = 1.0;

                for (int z = 0; z < mul.Count; z++)
                {
                    mulres *= double.Parse(mul[z].ToString());
                }

                result = mulres * p;
                output.Add(Math.Abs(result));
            }

            ArrayList list1 = new ArrayList();

            for (int x = 0; x < s.Count; x++)
            {
                list1.Add(output[x]);
            }

            list1.Sort();
            list1.Reverse();

            string _output = null;

            for (int y = 0; y < s.Count; y++)
            {
                if (output[y].Equals(list1[0]))
                {
                    _output = s[y].ToString();
                    return _output;
                }
            }
            //}
            //catch
            //{

            //}

            return _output;
        }
    }
}