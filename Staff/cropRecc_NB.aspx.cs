using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Collections;


namespace cropPrediction.Staff
{
    public partial class cropRecc_NB : System.Web.UI.Page
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
                loadParameters();
            }
        }

        //function to load parameters and its values
        private void loadParameters()
        {
            int serialNo = 1;

            DataTable tab = new DataTable();
            BLL obj = new BLL();

            DataTable tabAttri = new DataTable();
            tab = obj.GetAllFeatureTypes();

            if (tab.Rows.Count > 0)
            {
                tableAttributes.Rows.Clear();

                tableAttributes.BorderStyle = BorderStyle.Double;
                tableAttributes.GridLines = GridLines.Both;
                tableAttributes.BorderColor = System.Drawing.Color.DarkGray;

                TableHeaderRow headerrow = new TableHeaderRow();
                headerrow.Height = 30;
                headerrow.ForeColor = System.Drawing.Color.WhiteSmoke;
                headerrow.BackColor = System.Drawing.Color.SteelBlue;

                TableCell cell1 = new TableCell();
                cell1.Text = "<b>SLNo</b>";
                headerrow.Controls.Add(cell1);

                TableCell cell3 = new TableCell();
                cell3.Text = "<b>Parameter</b>";
                headerrow.Controls.Add(cell3);

                TableCell cell4 = new TableCell();
                cell4.Text = "<b>Value</b>";
                headerrow.Controls.Add(cell4);

                tableAttributes.Controls.Add(headerrow);

                for (int cnt = 0; cnt < tab.Rows.Count; cnt++)
                {
                    TableRow row = new TableRow();
                    row.Height = 30;

                    TableCell cellSerialNo = new TableCell();
                    cellSerialNo.Width = 10;
                    cellSerialNo.Font.Size = 10;
                    cellSerialNo.Text = serialNo + cnt + ".";
                    row.Controls.Add(cellSerialNo);

                    TableCell cellAttribute = new TableCell();
                    cellAttribute.Width = 150;

                    DataTable tabAttribute = new DataTable();
                    tabAttribute = obj.GetFeatureTypeById(int.Parse(tab.Rows[cnt]["FeatureTypeId"].ToString()));

                    cellAttribute.Text = tabAttribute.Rows[0]["FeatureType"].ToString();
                    row.Controls.Add(cellAttribute);

                    DataTable tabvalues = new DataTable();
                    tabvalues = obj.GetFeaturesByType(int.Parse(tab.Rows[cnt]["FeatureTypeId"].ToString()));

                    TableCell cellvalue = new TableCell();

                    DropDownList dropdownlistValue = new DropDownList();
                    dropdownlistValue.Width = 200;
                    int num = serialNo + cnt;
                    dropdownlistValue.ID = num.ToString();

                    if (tabvalues.Rows.Count > 0)
                    {
                        for (int i = 0; i < tabvalues.Rows.Count; i++)
                        {
                            ListItem item = new ListItem(tabvalues.Rows[i]["Feature"].ToString(), tabvalues.Rows[i]["FeatureId"].ToString());
                            dropdownlistValue.Items.Add(item);
                        }
                    }
                    else
                    {
                        ListItem item = new ListItem("Value Notset", "Notset");
                        dropdownlistValue.Items.Add(item);
                    }

                    cellvalue.Controls.Add(dropdownlistValue);
                    row.Controls.Add(cellvalue);
                    tableAttributes.Controls.Add(row);
                }
            }
            else
            {
                tableAttributes.Rows.Clear();
                tableAttributes.BorderStyle = BorderStyle.None;

                TableHeaderRow row = new TableHeaderRow();
                TableHeaderCell cell = new TableHeaderCell();
                cell.ColumnSpan = 5;
                cell.Font.Bold = true;
                cell.ForeColor = System.Drawing.Color.Red;
                cell.Text = "No Parameters Found!!!";

                row.Controls.Add(cell);
                tableAttributes.Controls.Add(row);

            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            BLL obj = new BLL();
            DataTable tabTrainingSet = new DataTable();

            tabTrainingSet = GetTrainingDataset();

            if (tabTrainingSet.Rows.Count > 0)
            {
                NB();
            }
            else
            {
                ClientScript.RegisterStartupScript(GetType(), "key", "<script>alert('Dataset Not Found!!!')</script>");
            }

        }

        double pi;
        int nc, n;
        double result;
        ArrayList output = new ArrayList();
        ArrayList mul = new ArrayList();

        //function which contains the algorithm steps
        private void NB()
        {
            BLL obj = new BLL();
            ArrayList s = new ArrayList();

            try
            {
                s = GetSubject();

                ArrayList features = new ArrayList();
                DataTable tabFeatures = new DataTable();

                tabFeatures = obj.GetAllFeatureTypes();

                int m = tabFeatures.Rows.Count;
                double numer = 1.0;
                double dino = double.Parse(s.Count.ToString());
                double p = numer / dino;

                if (tabFeatures.Rows.Count > 0)
                {
                    for (int i = 0; i < tabFeatures.Rows.Count; i++)
                    {
                        features.Add(tabFeatures.Rows[i]["FeatureType"].ToString());
                    }
                }

                ArrayList classify = new ArrayList();
                int serialNo = 1;

                for (int i = 0; i < tableAttributes.Rows.Count - 1; i++)
                {
                    int num = serialNo + i;
                    DropDownList dropdownlistValue = (DropDownList)tableAttributes.FindControl(num.ToString());
                    classify.Add(dropdownlistValue.SelectedItem.Text);
                }

                DataTable tabTrainingSet = new DataTable();
                tabTrainingSet = GetTrainingDataset();

                for (int i = 0; i < s.Count; i++)
                {
                    mul.Clear();

                    for (int j = 0; j < features.Count; j++)
                    {
                        n = 0;
                        nc = 0;

                        for (int d = 0; d < tabTrainingSet.Rows.Count; d++)
                        {
                            if (tabTrainingSet.Rows[d][j + 1].ToString().Equals(classify[j]))
                            {
                                ++n;

                                if (tabTrainingSet.Rows[d][m + 1].ToString().Equals(s[i]))

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

                DisplayOutput(s);
            }
            catch
            {

            }
        }

        //function to display the output
        private void DisplayOutput(ArrayList s)
        {
            ArrayList list1 = new ArrayList();

            for (int x = 0; x < s.Count; x++)
            {
                list1.Add(output[x]);
            }

            list1.Sort();
            list1.Reverse();

            for (int y = 0; y < s.Count; y++)
            {
                if (output[y].Equals(list1[0]))
                {
                    txtRecc.Font.Bold = true;
                    txtRecc.Font.Size = 16;
                    txtRecc.ForeColor = System.Drawing.Color.ForestGreen;
                    txtRecc.Text = "Suitable Crop: " + s[y].ToString();

                    return;
                }
            }


        }

        //function to load training data set
        public DataTable GetTrainingDataset()
        {
            BLL obj = new BLL();

            DataTable tabNewAttributes = new DataTable();
            DataTable tabAttributes = new DataTable();

            tabAttributes = obj.GetAllFeatureTypes();

            if (tabAttributes.Rows.Count > 0)
            {
                tabNewAttributes.Columns.Add("FarmerName");

                for (int i = 0; i < tabAttributes.Rows.Count; i++)
                {
                    tabNewAttributes.Columns.Add(tabAttributes.Rows[i]["FeatureType"].ToString());
                }

                tabNewAttributes.Columns.Add("Crop");
            }

            DataTable tab = new DataTable();
            tab = obj.GetFarmersByLoc(Session["StaffId"].ToString());

            if (tab.Rows.Count > 0)
            {
                for (int i = 0; i < tab.Rows.Count; i++)
                {
                    DataTable tab1 = new DataTable();
                    tab1 = obj.GetFarmerFeatures(int.Parse(tab.Rows[i]["FarmerId"].ToString()));

                    if (tab1.Rows.Count > 0)
                    {
                        DataRow row = tabNewAttributes.NewRow();

                        row[tabNewAttributes.Columns[0].ToString()] = tab.Rows[i]["FarmerName"].ToString();

                        for (int j = 0; j < tab1.Rows.Count; j++)
                        {
                            DataTable tabValue = new DataTable();
                            tabValue = obj.GetFeatureById(int.Parse(tab1.Rows[j]["FeatureId"].ToString()));
                            row[tabNewAttributes.Columns[j + 1].ToString()] = tabValue.Rows[0]["Feature"].ToString();
                        }

                        DataTable tabCropp = new DataTable();
                        tabCropp = obj.GetCropById(int.Parse(tab.Rows[i]["CropId"].ToString()));

                        row[tabNewAttributes.Columns[tabAttributes.Rows.Count + 1].ToString()] = tabCropp.Rows[0]["Crop"].ToString();

                        tabNewAttributes.Rows.Add(row);
                    }
                }
            }

            return tabNewAttributes;
        }

        //function to load subject
        public ArrayList GetSubject()
        {
            ArrayList s = new ArrayList();

            DataTable tab = new DataTable();
            BLL obj = new BLL();

            tab = obj.GetDistinctCropIdByLoc(Session["StaffId"].ToString());

            if (tab.Rows.Count > 0)
            {
                for (int i = 0; i < tab.Rows.Count; i++)
                {
                    DataTable tabCropp = new DataTable();
                   
                    if (tab.Rows[i]["CropId"].ToString().Equals(""))
                    {

                    }

                    else
                    {
                        tabCropp = obj.GetCropById(int.Parse(tab.Rows[i]["CropId"].ToString()));
                        s.Add(tabCropp.Rows[0]["Crop"].ToString());
                    }
                }
            }

            return s;
        }
               
    }
}