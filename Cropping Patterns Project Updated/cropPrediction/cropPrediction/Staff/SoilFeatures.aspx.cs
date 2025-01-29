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
    public partial class SoilFeatures : System.Web.UI.Page
    {
        public static OleDbConnection oledbConn;
        DataTable dt = new DataTable();
        DataTable dtDistinct = new DataTable();
        static ArrayList _arrayPatientsCnt = new ArrayList();
        DataTable dt_Vectors = new DataTable();

        protected void Page_Load(object sender, EventArgs e)
        {
            //if (Session["StaffId"] == null)
            //{
            //    Session.Abandon();
            //    Response.Redirect("~/Login.aspx");
            //}
            //else
            //{
                //if (!this.IsPostBack)
                //{
                //    BLL obj = new BLL();
                //    DataTable tabPatient = new DataTable();
                //    tabPatient = obj.GetFarmerById(int.Parse(Request.QueryString["farmerId"].ToString()));
                //    txtName.Value = tabPatient.Rows[0]["FarmerName"].ToString();
                //    txtName.Disabled = true;

                //    LoadTypes();                   
                //}

                //LoadAttributes();

               

           // }

            count1 = 0; count2 = 0; count3 = 0;
            Response.Redirect("_LVQResults.aspx");
        }

        //function to retrive the farmer attributes
        private bool LoadFarmerAttributes()
        {
            DataTable tabfarmerAttributes = new DataTable();
            BLL obj = new BLL();
            tabfarmerAttributes = obj.GetFarmerFeatures(int.Parse(Request.QueryString["farmerId"].ToString()));

            if (tabfarmerAttributes.Rows.Count > 0)
            {
                return true;
            }

            return false;
        }

        //function to retrive all types
        private void LoadTypes()
        {
            DataTable tab = new DataTable();
            BLL obj = new BLL();

            tab = obj.GetTypes();

            if (tab.Rows.Count > 0)
            {
                DropdownListTypes.Items.Clear();

                DropdownListTypes.DataSource = tab;
                DropdownListTypes.DataTextField = "Type";
                DropdownListTypes.DataValueField = "TypeId";
                DropdownListTypes.DataBind();

                DropdownListTypes.Items.Insert(0, "Select");
            }
            else
            {
                DropdownListTypes.Items.Clear();
                DropdownListTypes.Items.Insert(0, "Input Types");
            }
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
                //btnPrediction.Visible = false;
                ClientScript.RegisterStartupScript(this.GetType(), "Key", "<Script>alert('No Training Dataset!!!')</script>");
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

        ArrayList output = new ArrayList();
        ArrayList mul = new ArrayList();
        public static int count1 = 0;
        public static int count2 = 0;
        public static int count3 = 0;

        public string _LVQAlgorithmprogram(string[] values)
        {
            if (Session["StaffId"].ToString().Equals("mysore") || Session["StaffId"].ToString().Equals("Mysore"))
            {                
                if (count1 <= 0)
                {
                    try
                    {
                        TrainingDS();
                    }
                    catch
                    {

                    }

                    count1++;
                }
            }
            else if (Session["StaffId"].ToString().Equals("mandya") || Session["StaffId"].ToString().Equals("Mandya"))
            {               
                if (count2 <= 0)
                {
                    try
                    {
                        TrainingDS();
                    }
                    catch
                    {

                    }

                    count2++;
                }
            }
            else if (Session["StaffId"].ToString().Equals("theerthHalli") || Session["StaffId"].ToString().Equals("TheerthHalli"))
            {
                if (count3 <= 0)
                {
                    try
                    {
                        TrainingDS();
                    }
                    catch
                    {

                    }

                    count3++;
                }
            }

           

            ArrayList _Distance = new ArrayList();
            ArrayList _RecordId = new ArrayList();

            ArrayList s = new ArrayList();
            output.Clear();

            //try
            //{
            s = GetSubject();

            int m = 35; //k value

            //finding the distance between the objects
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                double _val = 0.0;

                for (int j = 0; j < values.Length; j++)
                {
                    string _valluee = dt.Rows[i][j].ToString();

                    if (_valluee.Equals("?") || values[j].ToString().Equals("?") ||
                        _valluee.Equals("") || values[j].ToString().Equals(""))
                    {

                    }
                    else
                    {
                        _val += Math.Pow(double.Parse(dt.Rows[i][j].ToString()) - double.Parse(values[j].ToString()), 2);
                    }
                }

                _val = Math.Sqrt(_val);

                _Distance.Add(Math.Round(_val, 1));
                _RecordId.Add(i);
            }

            ArrayList temp = new ArrayList();
            ArrayList arrayRecords = new ArrayList();

            ArrayList arrayExists = new ArrayList();
            int d = 0;

            for (int x = 0; x < _Distance.Count; x++)
            {
                temp.Add(_Distance[x]);
            }

            temp.Sort();

            for (int y = 0; y < m; y++)
            {
                d = 0;

                for (int z = 0; z < _Distance.Count; z++)
                {
                    if (_Distance[z].Equals(temp[y]))
                    {
                        if (d == 0 && !arrayExists.Contains(_RecordId[z]))
                        {
                            arrayRecords.Add(_RecordId[z]);

                            arrayExists.Add(_RecordId[z]);

                            ++d;
                        }
                    }
                }
            }

            string _output = null;

            if (arrayRecords.Count > 0)
            {
                int cnt;

                ArrayList arrayCnt = new ArrayList();
                ArrayList arrayOutcome = new ArrayList();

                for (int i = 0; i < s.Count; i++)
                {
                    cnt = 0;

                    for (int j = 0; j < arrayRecords.Count; j++)
                    {
                        if (dt.Rows[int.Parse(arrayRecords[j].ToString())]["Crop"].ToString().Equals(s[i]))
                        {
                            ++cnt;
                        }
                    }

                    arrayCnt.Add(cnt);
                    arrayOutcome.Add(s[i]);
                }

                ArrayList temp1 = new ArrayList();

                for (int x = 0; x < arrayCnt.Count; x++)
                {
                    temp1.Add(arrayCnt[x]);
                }

                temp1.Sort();
                temp1.Reverse();



                for (int y = 0; y < arrayCnt.Count; y++)
                {
                    if (arrayCnt[y].Equals(temp1[0]))
                    {
                        _output = s[y].ToString();

                        //if (_output.Equals("0"))
                        //{
                        //    _output = "No";
                        //}
                        //else
                        //{
                        //    _output = "Yes";
                        //}

                        return _output;

                    }
                }
            }

            return _output;
        }
                
        //function to load attributes and its values
        private void LoadAttributes()
        {
            int serialNo = 1;

            DataTable tab = new DataTable();
            BLL obj = new BLL();

            DataTable tabFarmerAttributes = new DataTable();
            tabFarmerAttributes = obj.GetFarmerFeatures(int.Parse(Request.QueryString["farmerId"].ToString()));

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
                cell3.Text = "<b>Constraint</b>";
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

                if (tabFarmerAttributes.Rows.Count > 0)
                {
                    ArrayList arrayPValues = new ArrayList();

                    for (int a = 0; a < tabFarmerAttributes.Rows.Count; a++)
                    {
                        arrayPValues.Add(tabFarmerAttributes.Rows[a]["FeatureId"].ToString());
                    }


                    for (int i = 0; i < arrayPValues.Count; i++)
                    {
                        DataTable tabAValues = new DataTable();
                        tabAValues = obj.GetFeaturesByType(int.Parse(tab.Rows[i]["FeatureTypeId"].ToString()));

                        int num = serialNo + i;

                        DropDownList dropdownlistValue = (DropDownList)tableAttributes.FindControl(num.ToString());

                        ArrayList arrayValues = new ArrayList();

                        for (int b = 0; b < tabAValues.Rows.Count; b++)
                        {
                            arrayValues.Add(tabAValues.Rows[b]["FeatureId"].ToString());
                        }

                        for (int j = 0; j < tabAValues.Rows.Count; j++)
                        {
                            if (arrayPValues.Contains(arrayValues[j]))
                            {
                                string valueText = dropdownlistValue.Items.FindByValue(arrayValues[j].ToString()).ToString();

                                ListItem itemValue = new ListItem(valueText, tabFarmerAttributes.Rows[i]["FeatureId"].ToString());
                                int Index = dropdownlistValue.Items.IndexOf(itemValue);

                                if (Index != -1)

                                    dropdownlistValue.SelectedIndex = Index;
                            }
                        }
                    }

                    DataTable tabCrop = new DataTable();
                    tabCrop = obj.GetFarmerById(int.Parse(Request.QueryString["farmerId"].ToString()));

                    if (tabCrop.Rows[0]["CropId"].ToString().Equals(""))
                    {

                    }
                    else
                    {
                        DataTable tabGetType = new DataTable();
                        tabGetType = obj.GetCropById(int.Parse(tabCrop.Rows[0]["CropId"].ToString()));

                        LoadCrops(int.Parse(tabGetType.Rows[0]["TypeId"].ToString()));

                        string SubtypeText = DropdownListCrops.Items.FindByValue(tabCrop.Rows[0]["CropId"].ToString()).ToString();

                        ListItem ItemSubtype = new ListItem(SubtypeText, tabCrop.Rows[0]["CropId"].ToString());
                        int Index2 = DropdownListCrops.Items.IndexOf(ItemSubtype);

                        if (Index2 != -1)

                            DropdownListCrops.SelectedIndex = Index2;
                        DropdownListCrops.Enabled = false;

                        DataTable tabType = new DataTable();
                        tabType = obj.GetCropById(int.Parse(tabCrop.Rows[0]["CropId"].ToString()));

                        string typeText = DropdownListTypes.Items.FindByValue(tabType.Rows[0]["TypeId"].ToString()).ToString();

                        ListItem Itemtype = new ListItem(typeText, tabType.Rows[0]["TypeId"].ToString());
                        int Index1 = DropdownListTypes.Items.IndexOf(Itemtype);

                        if (Index1 != -1)

                            DropdownListTypes.SelectedIndex = Index1;
                        DropdownListTypes.Enabled = false;
                        
                    }
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
                cell.Text = "No Feature Types Found";

                row.Controls.Add(cell);
                tableAttributes.Controls.Add(row);

            }
        }
                             
        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            BLL obj = new BLL();
            DataTable tab = new DataTable();
            int serialNo = 1;

            tab = obj.GetFarmerFeatures(int.Parse(Request.QueryString["farmerId"].ToString()));

            if (tab.Rows.Count > 0)
            {
                obj.DeleteFarmerFeatures(int.Parse(Request.QueryString["farmerId"].ToString()));

                for (int i = 0; i < tableAttributes.Rows.Count - 1; i++)
                {
                    int num = serialNo + i;
                    DropDownList dropdownlistValue = (DropDownList)tableAttributes.FindControl(num.ToString());
                    obj.InsertFarmerFeature(int.Parse(Request.QueryString["farmerId"].ToString()), int.Parse(dropdownlistValue.SelectedValue.ToString()));
                }

                obj.UpdateFarmerCrop(int.Parse(DropdownListCrops.SelectedValue),  int.Parse(Request.QueryString["farmerId"].ToString()));
                ClientScript.RegisterStartupScript(this.GetType(), "key", "<script>alert('Constraints Uploaded Successfully')</script>");
            }
            else
            {
                for (int i = 0; i < tableAttributes.Rows.Count - 1; i++)
                {
                    int num = serialNo + i;
                    DropDownList dropdownlistValue = (DropDownList)tableAttributes.FindControl(num.ToString());
                    obj.InsertFarmerFeature(int.Parse(Request.QueryString["farmerId"].ToString()), int.Parse(dropdownlistValue.SelectedValue.ToString()));
                }

                obj.UpdateFarmerCrop(int.Parse(DropdownListCrops.SelectedValue),  int.Parse(Request.QueryString["farmerId"].ToString()));
                ClientScript.RegisterStartupScript(this.GetType(), "key", "<script>alert('Constraints Uploaded Successfully')</script>");
            }
        }
         
        protected void btnDelete_Click(object sender, EventArgs e)
        {
            BLL obj = new BLL();
            DataTable tab = new DataTable();

            tab = obj.GetFarmerFeatures(int.Parse(Request.QueryString["farmerId"].ToString()));

            if (tab.Rows.Count > 0)
            {
                obj.DeleteFarmerFeatures(int.Parse(Request.QueryString["farmerId"].ToString()));
                LoadAttributes();
                DropdownListTypes_SelectedIndexChanged(sender, e);
                DropdownListTypes.SelectedIndex = 0;
                DropdownListCrops.SelectedIndex = 0;
                DropdownListTypes.Enabled = true;
                DropdownListCrops.Enabled = true;
                ClientScript.RegisterStartupScript(this.GetType(), "key", "<script>alert('Constraints Deleted Successfully')</script>");
            }
            else
            {
                ClientScript.RegisterStartupScript(this.GetType(), "key", "<script>alert('First Set the Farmer Features!!!')</script>");
            }
        }     

        protected void DropdownListTypes_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadCrops(int.Parse(DropdownListTypes.SelectedValue));
        }
       
        //function to load crops based on type
        private void LoadCrops(int typeId)
        {
            DataTable tab = new DataTable();
            BLL obj = new BLL();

            tab = obj.GetCropsByType(typeId);

            if (tab.Rows.Count > 0)
            {
                DropdownListCrops.Items.Clear();

                DropdownListCrops.DataSource = tab;
                DropdownListCrops.DataTextField = "Crop";
                DropdownListCrops.DataValueField = "CropId";

                DropdownListCrops.DataBind();
                DropdownListCrops.Items.Insert(0, "Select");
            }
            else
            {
                DropdownListCrops.Items.Clear();
                DropdownListCrops.Items.Insert(0, "Input Crops");
            }
        }        

    }
}