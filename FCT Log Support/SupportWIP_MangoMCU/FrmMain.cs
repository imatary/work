using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using Lib.Core;

namespace SupportWIP_MangoMCU
{
    public partial class FrmMain : Form
    {
        System.Windows.Forms.Timer v_Timer = null;
        System.Windows.Forms.Timer v_TimerEditNotify = null;
        private System.IO.FileSystemWatcher fileSystemWatcherLogs;
        private bool v_IsWatching;
        private bool v_Dirty;
        FileInfo v_FileInput;
        int v_Total = Convert.ToInt32(ConfigurationManager.AppSettings["TOTAL"].ToString());
        int v_Pass = Convert.ToInt32(ConfigurationManager.AppSettings["PASS"].ToString());
        int v_NG = Convert.ToInt32(ConfigurationManager.AppSettings["NG"].ToString());
        DateTime v_TimeCurrent = DateTime.Now;
        public FrmMain()
        {
            InitializeComponent();
            v_Timer = new System.Windows.Forms.Timer();
            v_Timer.Interval = 1000;
            v_Timer.Tick += new EventHandler(timer1_Tick);
            v_Timer.Enabled = true;

            v_TimerEditNotify = new System.Windows.Forms.Timer();
            v_TimerEditNotify.Interval = 1000;
            v_TimerEditNotify.Tick += new EventHandler(tmrEditNotify_Tick);
            v_TimerEditNotify.Enabled = true;
            //Cbx_Station.Enabled = false;
            tabControl1.Controls.Remove(tabPage1);
            tabControl1.Controls.Remove(tabPage3);
            tabControl1.Controls.Remove(tabPage4);
            F_LoadTotalPCS();
        }


        #region EVENTS--------------------------------------
        private void Chb_EnableEdit_CheckedChanged(object sender, EventArgs e)
        {
            if (Chb_EnableEdit.Checked)
            {
                //Tbx_Login.Visible = true;
                //tabControl1.Controls.Add(tabPage1);
                //Cbx_Station.Enabled = true;
                tabControl1.Controls.Add(tabPage3);
                tabControl1.Controls.Add(tabPage4);
                //F_LoadTabModel();
                F_LoadTabStation();
                F_LoadTabConfig();
            }
            else
            {
                //Cbx_Station.Enabled = false;
                Tbx_Login.Text = "";
                Tbx_Login.Visible = false;

                //tabControl1.Controls.Remove(tabPage1);
                tabControl1.Controls.Remove(tabPage3);
                tabControl1.Controls.Remove(tabPage4);
                //Btn_ResetTotal.Visible = false;
            }
        }
        private void FrmMain_Load(object sender, EventArgs e)
        {
            F_LoadTabLog();
            v_IsWatching = false;
            v_Dirty = false;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Lbl_Timer.Text = DateTime.Now.ToString("yyyy/MM/dd  HH:mm:ss tt");
        }

        #region Tab Logs------------
        private void tmrEditNotify_Tick(object sender, EventArgs e)
        {
            if (v_Dirty)
            {
                v_Dirty = false;
                Tbx_BarCode.Text = "";
                Panel_Result.BackColor = System.Drawing.Color.Blue;
                Lbl_Result.BackColor = System.Drawing.Color.Blue;
                Lbl_Result.Text = "";
                F_SaveLog();
            }
        }

        public void F_LoadTabLog()
        {
            //the path in which XML file is saved
            string v_Path = Application.StartupPath + @"\Databases\T_Model.xml";
            DataSet v_DS = new DataSet();
            //Reading XML file and copying to dataset
            v_DS.ReadXml(v_Path);

            DataView v_DV = v_DS.Tables[0].DefaultView;
            v_DV.Sort = "Name ASC";
            //Cbx_Models.DataSource = v_DV.ToTable();
            //Cbx_Models.DisplayMember = "Name";
            //Cbx_Models.ColumnWidthCollection[0] = 200;

            //the path in which XML file is saved
            v_Path = Application.StartupPath + @"\Databases\T_Station.xml";
            v_DS = new DataSet();
            //Reading XML file and copying to dataset
            v_DS.ReadXml(v_Path);

            //Cbx_Station.DataSource = v_DS.Tables[0];
            //Cbx_Station.DisplayMember = "Code";
            //Cbx_Station.ValueMember = "Code";
            //Cbx_Station.ColumnWidthCollection[0] = 130;
            //Cbx_Station.ColumnWidthCollection[1] = 200;
        }

        private void Btn_AutoRun_Click(object sender, EventArgs e)
        {
            if (v_IsWatching)
            {
                v_IsWatching = false;
                fileSystemWatcherLogs.EnableRaisingEvents = false;
                fileSystemWatcherLogs.Dispose();
                Btn_AutoRun.BackColor = Color.Blue;
                Btn_AutoRun.Text = "Start Scan";

            }
            else
            {
                v_IsWatching = true;
                Btn_AutoRun.BackColor = Color.Red;
                Btn_AutoRun.Text = "Stop Scan";
                fileSystemWatcherLogs = new System.IO.FileSystemWatcher();
                string v_FolderInput = ConfigurationManager.AppSettings["PathInput"].ToString();
                fileSystemWatcherLogs.Filter = "*.*";
                fileSystemWatcherLogs.Path = v_FolderInput + "\\";


                fileSystemWatcherLogs.NotifyFilter = NotifyFilters.LastAccess | NotifyFilters.LastWrite
                                         | NotifyFilters.FileName | NotifyFilters.DirectoryName;
                fileSystemWatcherLogs.Changed += new FileSystemEventHandler(OnChanged);
                //fileSystemWatcherLogs.Created += new FileSystemEventHandler(OnChanged);
                //fileSystemWatcherLogs.Deleted += new FileSystemEventHandler(OnChanged);
                //fileSystemWatcherLogs.Renamed += new RenamedEventHandler(OnRenamed);
                fileSystemWatcherLogs.EnableRaisingEvents = true;
            }
        }

        private void OnChanged(object sender, FileSystemEventArgs e)
        {
            if (!v_Dirty)
            {
                if (e.ChangeType.ToString().Trim().ToUpper() == "CHANGED")
                {
                    v_Dirty = true;
                }
            }
        }

        private void OnRenamed(object sender, RenamedEventArgs e)
        {

        }

        public void F_SaveLog()
        {
            //Read FILE LOG_Source
            v_FileInput = new DirectoryInfo(ConfigurationManager.AppSettings["PathInput"].ToString()).GetFiles().OrderByDescending(f => f.LastWriteTime).First();
            if (v_FileInput.Extension != ".csv")
                return;
            DataTable v_DT_Result = new DataTable();
            v_DT_Result.Columns.Add("Times", typeof(string));
            v_DT_Result.Columns.Add("Model", typeof(string));
            v_DT_Result.Columns.Add("Status", typeof(string));
            List<string> columns = new List<string>();
            CsvFileReader v_Reader = WriteDatatableToFileCSV.ReadFile(v_FileInput.FullName);
            while (v_Reader.ReadRow(columns))
            {
                if (columns[0].Trim().Length > 0 && columns[1].Trim().Length > 0)
                {
                    DataRow v_Dr = v_DT_Result.NewRow();
                    v_Dr[0] = columns[1].Trim();
                    v_Dr[1] = columns[5].Trim();
                    v_Dr[2] = columns[3].Trim();
                    v_DT_Result.Rows.Add(v_Dr);
                }
            }
            v_Reader.Dispose();
            v_DT_Result.Rows.RemoveAt(0);
            v_DT_Result.Rows.RemoveAt(0);
            //Get PASS OR FAIL
            string v_Status = "F";
            string v_Model = string.Empty;
            string v_Serial = string.Empty;
            string v_Station = string.Empty;

            //GET Model
            v_Model = v_DT_Result.Rows[v_DT_Result.Rows.Count - 1][1].ToString().Trim().Split('_')[1];

            //GET Serial
            v_Serial = v_DT_Result.Rows[v_DT_Result.Rows.Count - 1][1].ToString().Trim().Split('_')[0];

            //Get Status
            try
            {
                if (v_DT_Result.Rows[v_DT_Result.Rows.Count - 1][2].ToString().Trim() == "OK")
                    v_Status = "P";
                else
                    v_Status = "F";
            }
            catch { v_Status = "F"; }

            //Get Station
            try
            {
                //v_Station = Cbx_Station.SelectedValue.ToString();
            }
            catch { }


            Tbx_BarCode.Text = v_Serial + "_" + v_Model;
            Tbx_BarCode.ForeColor = Color.Green;
            string v_TimeCurrent = DateTime.Now.ToString("yyMMddHHmmss");
            string v_FileContent = v_Model + "|" + v_Serial + "_" + v_Model + "|" + v_TimeCurrent + "|" + v_Status + "|" + v_Station;

            //Delete OLD File log
            try
            {
                bool v_StatusOld = false;
                List<string> v_ListPaths = Directory.GetFiles(ConfigurationManager.AppSettings["PathOutput"].ToString(), "*.txt", SearchOption.AllDirectories).ToList();
                string v_PathPASS = "";
                string v_PathNG = "";
                try
                {
                    v_PathPASS = v_ListPaths.Where(p => File.ReadAllLines(p).Any(line => line.IndexOf(v_Serial + "_" + v_Model) >= 0 && line.IndexOf("|P|") >= 0 && line.IndexOf(v_Station) >= 0)).First();
                }
                catch { }
                try
                {
                    v_PathNG = v_ListPaths.Where(p => File.ReadAllLines(p).Any(line => line.IndexOf(v_Serial + "_" + v_Model) >= 0 && line.IndexOf("|F|") >= 0 && line.IndexOf(v_Station) >= 0)).First();
                }
                catch { }
                if (v_PathPASS.Trim().Length > 0)
                {
                    ControlFile.F_DeleteFile(v_PathPASS);
                    v_Total = v_Total - 1;
                    if (v_Status == "P")
                    {
                        v_Pass = v_Pass - 1;
                    }
                    else if (v_Status == "F")
                    {
                        v_Pass = v_Pass - 1;
                        v_NG = v_NG;
                    }
                    if (v_Total < 0)
                        v_Total = 0;
                    if (v_Pass < 0)
                        v_Pass = 0;
                    if (v_NG < 0)
                        v_NG = 0;
                }
                else if (v_PathNG.Trim().Length > 0)
                {
                    ControlFile.F_DeleteFile(v_PathNG);
                    v_Total = v_Total - 1;
                    if (v_Status == "P")
                    {
                        v_Pass = v_Pass;
                        v_NG = v_NG - 1;
                    }
                    else if (v_Status == "F")
                    {
                        v_NG = v_NG - 1;
                    }
                    if (v_Total < 0)
                        v_Total = 0;
                    if (v_Pass < 0)
                        v_Pass = 0;
                    if (v_NG < 0)
                        v_NG = 0;
                }
            }
            catch { }
            //Create NEW File log
            ControlFile.F_CreateAndWriteFile(ConfigurationManager.AppSettings["PathOutput"].ToString() + "\\" + v_TimeCurrent + "_" + v_Model.Replace(" ", "").Substring(0, 9) + ".txt", v_FileContent);

            if (v_Status == "P")
            {
                Panel_Result.BackColor = System.Drawing.Color.Blue;
                Lbl_Result.BackColor = System.Drawing.Color.Blue;
                Lbl_Result.Text = "PASS";
            }
            else if (v_Status == "F")
            {
                Panel_Result.BackColor = System.Drawing.Color.Red;
                Lbl_Result.BackColor = System.Drawing.Color.Red;
                Lbl_Result.Text = "FAIL";
            }

            //Count PCS
            F_CountModelsChecked(v_Status);
            F_LoadTotalPCS();
        }

        private void Btn_ResetTotal_Click(object sender, EventArgs e)
        {
            SettingConfiguration.F_UpdateKey("PASS", 0.ToString());
            Tbx_Pass.Text = Convert.ToDecimal(0).ToString("N0") + " ";
            SettingConfiguration.F_UpdateKey("NG", 0.ToString());
            Tbx_NG.Text = Convert.ToDecimal(0).ToString("N0") + " ";
            SettingConfiguration.F_UpdateKey("TOTAL", 0.ToString());
            Tbx_Total.Text = Convert.ToDecimal(0).ToString("N0") + " ";
            v_Total = v_Pass = v_NG = 0;
        }
        #endregion

        #region Tab Model-----------
        public void F_LoadTabModel()
        {
            //the path in which XML file is saved
            string v_Path = Application.StartupPath + @"\Databases\T_Model.xml";
            DataSet v_DS = new DataSet();
            //Reading XML file and copying to dataset
            v_DS.ReadXml(v_Path);
            DGV_Model.DataSource = v_DS;
            DGV_Model.DataMember = "Table1";
            DGV_Model.Sort(DGV_Model.Columns[0], ListSortDirection.Ascending);
            DGV_Model.Columns[0].Width = 380;
            DGV_Model.Columns[1].Width = 150;
            DGV_Model.Columns[2].Width = 105;
        }

        private void Btn_Save_Click(object sender, EventArgs e)
        {
            //path of XML file
            string v_Path = Application.StartupPath + @"\Databases\T_Model.xml";
            DataSet v_DS = new DataSet();
            DataTable v_DT = new DataTable();
            //Adding columns to datatable
            foreach (DataGridViewColumn i_Col in DGV_Model.Columns)
            {
                v_DT.Columns.Add(i_Col.DataPropertyName, i_Col.ValueType);
            }
            //adding new rows
            foreach (DataGridViewRow i_Row in DGV_Model.Rows)
            {
                if (i_Row.Cells[0].Value != null && i_Row.Cells[0].Value.ToString().Trim().Length > 0)
                {
                    DataRow v_Dr = v_DT.NewRow();
                    for (int i = 0; i < DGV_Model.ColumnCount; i++)
                    {
                        //if value exists add that value else add Null for that field
                        v_Dr[i] = (i_Row.Cells[i].Value == null ? DBNull.Value : i_Row.Cells[i].Value);
                    }
                    v_DT.Rows.Add(v_Dr);
                }
            }
            //Copying from datatable to dataset
            v_DS.Tables.Add(v_DT);
            //writing new values to XML
            v_DS.WriteXml(v_Path);

            DataView v_DV = v_DS.Tables[0].DefaultView;
            v_DV.Sort = "Name ASC";
            //Cbx_Models.DataSource = v_DV.ToTable();
            //Cbx_Models.DisplayMember = "Name";
            //Cbx_Models.Text = "";
            MessageBox.Show("Save successfully", "Success");
            //this.Close();
        }

        private void Btn_Search_Click(object sender, EventArgs e)
        {
            foreach (System.Windows.Forms.DataGridViewRow i_Row in DGV_Model.Rows)
            {
                try
                {
                    if ((i_Row.Cells[0].Value).ToString().ToUpper().Contains(Tbx_Search.Text.ToUpper())
                        || (i_Row.Cells[1].Value).ToString().ToUpper().Contains(Tbx_Search.Text.ToUpper())
                        || (i_Row.Cells[2].Value).ToString().ToUpper().Contains(Tbx_Search.Text.ToUpper())
                        || (i_Row.Cells[3].Value).ToString().ToUpper().Contains(Tbx_Search.Text.ToUpper())
                        || (i_Row.Cells[4].Value).ToString().ToUpper().Contains(Tbx_Search.Text.ToUpper())
                        )
                    {
                        DGV_Model.Rows[i_Row.Index].Visible = true;
                        DGV_Model.Rows[i_Row.Index].Selected = true;
                    }
                    else
                    {
                        DGV_Model.CurrentCell = null;
                        DGV_Model.Rows[i_Row.Index].Visible = false;
                    }
                }
                catch { }
            }
        }

        private void Tbx_Search_TextChanged(object sender, EventArgs e)
        {
            foreach (System.Windows.Forms.DataGridViewRow i_Row in DGV_Model.Rows)
            {
                try
                {
                    if ((i_Row.Cells[0].Value).ToString().ToUpper().Contains(Tbx_Search.Text.ToUpper())
                        )
                    {
                        DGV_Model.Rows[i_Row.Index].Visible = true;
                        DGV_Model.Rows[i_Row.Index].Selected = true;
                    }
                    else
                    {
                        DGV_Model.CurrentCell = null;
                        DGV_Model.Rows[i_Row.Index].Visible = false;
                    }
                }
                catch { }
            }
        }
        #endregion

        #region Tab Station---------
        public void F_LoadTabStation()
        {
            //the path in which XML file is saved
            string v_Path = Application.StartupPath + @"\Databases\T_Station.xml";
            DataSet v_DS = new DataSet();
            //Reading XML file and copying to dataset
            v_DS.ReadXml(v_Path);
            DGV_Station.DataSource = v_DS;
            DGV_Station.DataMember = "Table1";
            DGV_Station.Sort(DGV_Station.Columns[0], ListSortDirection.Ascending);
            DGV_Station.Columns[0].Width = 100;
            DGV_Station.Columns[1].Width = 350;
        }

        private void Btn_SearchStation_Click(object sender, EventArgs e)
        {
            foreach (System.Windows.Forms.DataGridViewRow i_Row in DGV_Station.Rows)
            {
                try
                {
                    if ((i_Row.Cells[0].Value).ToString().ToUpper().Contains(Tbx_SearchStation.Text.ToUpper())
                        || (i_Row.Cells[1].Value).ToString().ToUpper().Contains(Tbx_SearchStation.Text.ToUpper())
                        )
                    {
                        DGV_Station.Rows[i_Row.Index].Visible = true;
                        DGV_Station.Rows[i_Row.Index].Selected = true;
                    }
                    else
                    {
                        DGV_Station.CurrentCell = null;
                        DGV_Station.Rows[i_Row.Index].Visible = false;
                    }
                }
                catch { }
            }
        }

        private void Btn_SaveStation_Click(object sender, EventArgs e)
        {
            //path of XML file
            string v_Path = Application.StartupPath + @"\Databases\T_Station.xml";
            DataSet v_DS = new DataSet();
            DataTable v_DT = new DataTable();
            //Adding columns to datatable
            foreach (DataGridViewColumn i_Col in DGV_Station.Columns)
            {
                v_DT.Columns.Add(i_Col.DataPropertyName, i_Col.ValueType);
            }
            //adding new rows
            foreach (DataGridViewRow i_Row in DGV_Station.Rows)
            {
                if (i_Row.Cells[0].Value != null && i_Row.Cells[0].Value.ToString().Trim().Length > 0)
                {
                    DataRow v_Dr = v_DT.NewRow();
                    for (int i = 0; i < DGV_Station.ColumnCount; i++)
                    {
                        //if value exists add that value else add Null for that field
                        v_Dr[i] = (i_Row.Cells[i].Value == null ? DBNull.Value : i_Row.Cells[i].Value);
                    }
                    v_DT.Rows.Add(v_Dr);
                }
            }
            //Copying from datatable to dataset
            v_DS.Tables.Add(v_DT);
            //writing new values to XML
            v_DS.WriteXml(v_Path);

            DataView v_DV = v_DS.Tables[0].DefaultView;
            v_DV.Sort = "Code ASC";
            //Cbx_Station.DataSource = v_DV.ToTable();
            //Cbx_Station.DisplayMember = "Code";
            //Cbx_Station.ValueMember = "Name";
            MessageBox.Show("Save successfully", "Success");
            //this.Close();
        }

        private void Tbx_SearchStation_TextChanged(object sender, EventArgs e)
        {
            foreach (System.Windows.Forms.DataGridViewRow i_Row in DGV_Station.Rows)
            {
                try
                {
                    if ((i_Row.Cells[0].Value).ToString().ToUpper().Contains(Tbx_SearchStation.Text.ToUpper())
                        || (i_Row.Cells[1].Value).ToString().ToUpper().Contains(Tbx_SearchStation.Text.ToUpper())
                        )
                    {
                        DGV_Station.Rows[i_Row.Index].Visible = true;
                        DGV_Station.Rows[i_Row.Index].Selected = true;
                    }
                    else
                    {
                        DGV_Station.CurrentCell = null;
                        DGV_Station.Rows[i_Row.Index].Visible = false;
                    }
                }
                catch { }
            }
        }
        #endregion

        #region Tab Confige---------
        public void F_LoadTabConfig()
        {
            Lbl_PathFolderInput.Text = ConfigurationManager.AppSettings["PathInput"].ToString();
            Lbl_PathFolderOutput.Text = ConfigurationManager.AppSettings["PathOutput"].ToString();

        }

        private void Btn_OpenFolderInput_Click(object sender, EventArgs e)
        {
            this.folderBrowserDialog_FolderInput.RootFolder = System.Environment.SpecialFolder.MyComputer;
            this.folderBrowserDialog_FolderInput.ShowNewFolderButton = false;
            DialogResult result = this.folderBrowserDialog_FolderInput.ShowDialog();
            if (result == DialogResult.OK)
            {
                // retrieve the name of the selected folder
                string foldername = this.folderBrowserDialog_FolderInput.SelectedPath;

                // print the folder name on a label
                this.Lbl_PathFolderInput.Text = foldername;
            }
        }

        private void Btn_OpenFolderOutput_Click(object sender, EventArgs e)
        {
            this.folderBrowserDialog_FolderOutput.RootFolder = System.Environment.SpecialFolder.MyComputer;
            this.folderBrowserDialog_FolderOutput.ShowNewFolderButton = false;
            DialogResult result = this.folderBrowserDialog_FolderOutput.ShowDialog();
            if (result == DialogResult.OK)
            {
                // retrieve the name of the selected folder
                string foldername = this.folderBrowserDialog_FolderOutput.SelectedPath;

                // print the folder name on a label
                this.Lbl_PathFolderOutput.Text = foldername;
            }
        }

        private void Btn_SavePath_Click(object sender, EventArgs e)
        {
            if (Lbl_PathFolderInput.Text.Trim().Trim().Length > 0)
                SettingConfiguration.F_UpdateKey("PathInput", Lbl_PathFolderInput.Text.Trim());
            if (Lbl_PathFolderOutput.Text.Trim().Trim().Length > 0)
                SettingConfiguration.F_UpdateKey("PathOutput", Lbl_PathFolderOutput.Text.Trim());
        }

        #endregion
        #endregion


        #region FUNCTIONS-----------------------------------
        private void F_CountModelsChecked(string i_Status)
        {
            if (i_Status == "P")
            {
                v_Pass = v_Pass + 1;
                SettingConfiguration.F_UpdateKey("PASS", v_Pass.ToString());
                Tbx_Pass.Text = Convert.ToDecimal(v_Pass).ToString("N0") + " ";
            }
            else if (i_Status == "F")
            {
                v_NG = v_NG + 1;
                SettingConfiguration.F_UpdateKey("NG", v_NG.ToString());
                Tbx_NG.Text = Convert.ToDecimal(v_NG).ToString("N0") + " ";
            }
            v_Total = v_Total + 1;
            SettingConfiguration.F_UpdateKey("TOTAL", v_Total.ToString());
            Tbx_Total.Text = Convert.ToDecimal(v_Total).ToString("N0") + " ";
        }

        private void F_LoadTotalPCS()
        {
            try
            {
                Tbx_Total.Text = Convert.ToDecimal(v_Total).ToString("N0") + " ";
            }
            catch { Tbx_Total.Text = "0 "; }
            try
            {
                Tbx_Pass.Text = Convert.ToDecimal(v_Pass).ToString("N0") + " ";
            }
            catch { Tbx_Pass.Text = "0 "; }
            try
            {
                Tbx_NG.Text = Convert.ToDecimal(v_NG).ToString("N0") + " ";
            }
            catch { Tbx_NG.Text = "0 "; }
        }
        #endregion

        private void Tbx_Login_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                tabControl1.Controls.Remove(tabPage1);
                tabControl1.Controls.Remove(tabPage3);
                tabControl1.Controls.Remove(tabPage4);
                Btn_ResetTotal.Visible = false;
                if (Tbx_Login.Text == "adminumcvn")
                {
                    tabControl1.Controls.Add(tabPage1);
                    tabControl1.Controls.Add(tabPage3);
                    tabControl1.Controls.Add(tabPage4);
                    Btn_ResetTotal.Visible = true;

                    F_LoadTabModel();
                    F_LoadTabStation();
                    F_LoadTabConfig();
                }
                else
                {
                    MessageBox.Show("Login fail!", "Message");
                }
            }
        }
    }
}
