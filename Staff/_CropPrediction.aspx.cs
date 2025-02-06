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
    public partial class _CropPrediction : System.Web.UI.Page
    {
        public static OleDbConnection oledbConn;
        DataTable dt = new DataTable();
        DataTable dtDistinct = new DataTable();
        static ArrayList _arrayPatientsCnt = new ArrayList();

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                TrainingDS();
                TestingDS();
            }
            catch
            {

            }
        }

        private void TestingDS()
        {
            string FileName = "CropTestingDataset_" + Session["StaffId"].ToString() + ".xls";

            string Extension = ".xls";

            string FolderPath = ConfigurationManager.AppSettings["FolderPath"];

            string _Location = "CropTestingDataset_" + Session["StaffId"].ToString() + "";

            string FilePath = Server.MapPath(FolderPath + FileName);

            ImportTestingDS(FilePath, Extension, _Location);
        }

        private void ImportTestingDS(string FilePath, string Extension, string _Location)
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

            OleDbDataAdapter oda = new OleDbDataAdapter();

            DataTable dt = new DataTable();

            cmdExcel.Connection = connExcel;

            //Get the name of First Sheet

            connExcel.Open();

            DataTable dtExcelSchema;

            dtExcelSchema = connExcel.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);

            string SheetName = dtExcelSchema.Rows[0]["TABLE_NAME"].ToString();

            connExcel.Close();



            //Read Data from First Sheet

            connExcel.Open();

            cmdExcel.CommandText = "SELECT * From [" + SheetName + "]";

            oda.SelectCommand = cmdExcel;

            oda.Fill(dt);

            //BLL obj = new BLL();

            if (dt.Rows.Count > 0)
            {

                //Bind Data to GridView

                GridView1.Caption = Path.GetFileName(FilePath);

                GridView1.DataSource = dt;

                GridView1.DataBind();

            }
            else
            {
                ClientScript.RegisterStartupScript(this.GetType(), "Key", "<Script>alert('No Testing Dataset Found!!!')</script>");
            }



            connExcel.Close();





        }

        private void TrainingDS()
        {
            string FileName = "CropTrainingDataset_" + Session["StaffId"].ToString() + ".xls";

            string Extension = ".xls";

            string FolderPath = ConfigurationManager.AppSettings["FolderPath"];

            string _Location = "CropTrainingDataset_" + Session["StaffId"].ToString() + "";

            string FilePath = Server.MapPath(FolderPath + FileName);

            ImportTrainingDS(FilePath, Extension, _Location);
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
            OleDbCommand cmdPatientsCnt = new OleDbCommand();

            OleDbDataAdapter oda = new OleDbDataAdapter();
            OleDbDataAdapter odaDistinct = new OleDbDataAdapter();

            cmdExcel.Connection = connExcel;
            cmdDistinct.Connection = connExcel;
            cmdPatientsCnt.Connection = connExcel;
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
                string FileName = "CropTestingDataset_" + Session["StaffId"].ToString() + ".xls";

                string Extension = ".xls";

                string FolderPath = ConfigurationManager.AppSettings["FolderPath"];

                string _Location = "CropTestingDataset_" + Session["StaffId"].ToString() + "";

                string FilePath = Server.MapPath(FolderPath + FileName);

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

                OleDbDataAdapter oda = new OleDbDataAdapter();

                DataTable tabData = new DataTable();

                cmdExcel.Connection = connExcel;

                //Get the name of First Sheet

                connExcel.Open();

                DataTable dtExcelSchema;

                dtExcelSchema = connExcel.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);

                string SheetName = dtExcelSchema.Rows[0]["TABLE_NAME"].ToString();

                connExcel.Close();



                //Read Data from First Sheet

                connExcel.Open();

                cmdExcel.CommandText = "SELECT * From [" + SheetName + "]";

                oda.SelectCommand = cmdExcel;

                oda.Fill(tabData);

                //BLL obj = new BLL();

                int slNo = 1;

                if (tabData.Rows.Count > 0)
                {
                    Session["Output"] = null;
                    string _Predictedoutput = null;
                    string _timeNB = null;

                    tablePrediction.Rows.Clear();

                    tablePrediction.BorderStyle = BorderStyle.Double;
                    tablePrediction.GridLines = GridLines.Both;
                    tablePrediction.BorderColor = System.Drawing.Color.Black;

                    TableRow mainrow = new TableRow();
                    mainrow.Height = 30;
                    mainrow.ForeColor = System.Drawing.Color.WhiteSmoke;
                    mainrow.BackColor = System.Drawing.Color.SteelBlue;

                    // "PH","organic carbon(oC)", "nitrogen(n)" , "phosphorus(p)", "potassium(k)",
                    //               "sulphur(s)","zinc(zn)","iron(fe)","Temperature","Rainfall"

                    TableCell cell0 = new TableCell();
                    cell0.Width = 100;
                    cell0.Text = "<b>SlNo</b>";
                    mainrow.Controls.Add(cell0);

                    TableCell cell1 = new TableCell();
                    cell1.Width = 100;
                    cell1.Text = "<b>PH</b>";
                    mainrow.Controls.Add(cell1);

                    TableCell cell2 = new TableCell();
                    cell2.Text = "<b>organic carbon(oC)</b>";
                    mainrow.Controls.Add(cell2);

                    TableCell cell3 = new TableCell();
                    cell3.Text = "<b>nitrogen(n)</b>";
                    mainrow.Controls.Add(cell3);

                    TableCell cell4 = new TableCell();
                    cell4.Text = "<b>phosphorus(p)</b>";
                    mainrow.Controls.Add(cell4);

                    TableCell cell5 = new TableCell();
                    cell5.Text = "<b>potassium(k)</b>";
                    mainrow.Controls.Add(cell5);

                    TableCell cell6 = new TableCell();
                    cell6.Text = "<b>sulphur(s)</b>";
                    mainrow.Controls.Add(cell6);

                    TableCell cell7 = new TableCell();
                    cell7.Text = "<b>zinc(zn)</b>";
                    mainrow.Controls.Add(cell7);

                    TableCell cell8 = new TableCell();
                    cell8.Text = "<b>iron(fe)</b>";
                    mainrow.Controls.Add(cell8);

                    TableCell cell9 = new TableCell();
                    cell9.Text = "<b>Temperature</b>";
                    mainrow.Controls.Add(cell9);

                    TableCell cell10 = new TableCell();
                    cell10.Text = "<b>Rainfall</b>";
                    mainrow.Controls.Add(cell10);


                    TableCell cell25 = new TableCell();
                    cell25.Text = "<b>Result</b>";
                    mainrow.Controls.Add(cell25);

                    tablePrediction.Controls.Add(mainrow);

                    var watch = System.Diagnostics.Stopwatch.StartNew();

                    for (int i = 0; i < tabData.Rows.Count; i++)
                    {

                        string _data = tabData.Rows[i]["PH"].ToString() + "," + tabData.Rows[i]["organic carbon(oC)"].ToString() + "," +
                            tabData.Rows[i]["nitrogen(n)"].ToString() + "," + tabData.Rows[i]["phosphorus(p)"].ToString() + "," +
                            tabData.Rows[i]["potassium(k)"].ToString() + "," + tabData.Rows[i]["sulphur(s)"].ToString() + "," +
                            tabData.Rows[i]["zinc(zn)"].ToString() + "," + tabData.Rows[i]["iron(fe)"].ToString() + "," +
                            tabData.Rows[i]["Temperature"].ToString() + "," + tabData.Rows[i]["Rainfall"].ToString();


                        string[] values = _data.Split(',');

                        string _output = NaiveBayes(values);

                        TableRow row = new TableRow();

                        TableCell _cell0 = new TableCell();
                        _cell0.Text = slNo + i + ".";
                        row.Controls.Add(_cell0);

                        TableCell _cell1 = new TableCell();
                        _cell1.Text = tabData.Rows[i]["PH"].ToString();
                        row.Controls.Add(_cell1);

                        TableCell _cell2 = new TableCell();
                        _cell2.Text = tabData.Rows[i]["organic carbon(oC)"].ToString();
                        row.Controls.Add(_cell2);

                        TableCell _cell3 = new TableCell();
                        _cell3.Text = tabData.Rows[i]["nitrogen(n)"].ToString();
                        row.Controls.Add(_cell3);

                        TableCell _cell4 = new TableCell();
                        _cell4.Text = tabData.Rows[i]["phosphorus(p)"].ToString();
                        row.Controls.Add(_cell4);

                        TableCell _cell5 = new TableCell();
                        _cell5.Text = tabData.Rows[i]["potassium(k)"].ToString();
                        row.Controls.Add(_cell5);

                        TableCell _cell6 = new TableCell();
                        _cell6.Text = tabData.Rows[i]["sulphur(s)"].ToString();
                        row.Controls.Add(_cell6);

                        TableCell _cell7 = new TableCell();
                        _cell7.Text = tabData.Rows[i]["zinc(zn)"].ToString();
                        row.Controls.Add(_cell7);

                        TableCell _cell8 = new TableCell();
                        _cell8.Text = tabData.Rows[i]["iron(fe)"].ToString();
                        row.Controls.Add(_cell8);

                        TableCell _cell24 = new TableCell();
                        _cell24.Text = tabData.Rows[i]["Temperature"].ToString();
                        row.Controls.Add(_cell24);

                        TableCell _cell9 = new TableCell();
                        _cell9.Text = tabData.Rows[i]["Rainfall"].ToString();
                        row.Controls.Add(_cell9);



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
                    }

                    watch.Stop();
                    var elapsedMs = watch.ElapsedMilliseconds;
                    _timeNB = elapsedMs.ToString();

                    Session["Output"] = _timeNB + "," + _Predictedoutput.Substring(0, _Predictedoutput.Length - 1);
                }
            }
            catch
            {

            }
        }

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

        protected void btnResults_Click(object sender, EventArgs e)
        {
            btnPrediction_Click(sender, e);
            Response.Redirect("ResultAnalysis.aspx");
        }               
      
    }
}