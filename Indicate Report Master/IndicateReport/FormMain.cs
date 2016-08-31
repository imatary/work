using System;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;
using IndicateReport.Services;

namespace IndicateReport
{
    public partial class FormMain : Form
    {
        private readonly ReportMasterService _reportMasterService;
        private readonly IndicateReportService _indicateReportService;
        private readonly ActualModelService _actualModelService;
        private readonly ProcessService _processService;
        public FormMain()
        {
            InitializeComponent();
            _reportMasterService = new ReportMasterService();
            _indicateReportService = new IndicateReportService();
            _actualModelService = new ActualModelService();
            _processService = new ProcessService();
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            GetDataWip21();
            GetDataWip23();
            GetDataWip22();
        }

        private void timerRunAuto_Tick(object sender, EventArgs e)
        {
            //new Thread(new ThreadStart(GetDataWip21)).Start();
            //new Thread(new ThreadStart(GetDataWip23)).Start();
            //new Thread(new ThreadStart(GetDataWip22)).Start();
            GetDataWip21();
            GetDataWip23();
            GetDataWip22();
        }


        private void GetDataWip21()
        {
            var report = _indicateReportService.GetIndicateReportById(GetReportID(1));
            if (report != null)
            {
                lblOperatorWip21.Text = @"Operator:" + report.OperatorCode;
                lblProcessWip21.Text = report.ProcessID;
                string model = report.ModelID;
                lblTotalWip21.Text = report.Total.ToString(CultureInfo.InvariantCulture);
                lblPassWip21.Text = report.Pass.ToString(CultureInfo.InvariantCulture);
                var notgood = (int)(report.Total - report.Pass);
                lblNotGoodWip21.Text = Math.Abs(notgood).ToString(CultureInfo.InvariantCulture);

                float ng = (float.Parse(lblNotGoodWip21.Text) / float.Parse(lblTotalWip21.Text)) * 100;

                //if (ng > 0)
                //{
                    lblTotalNGWip21.Text = string.Format("{0:0.0} %", Math.Round(ng, 3));
                //}
            }
        }

        

        /// <summary>
        /// WIP 23
        /// </summary>
        private void GetDataWip23()
        {
            var report = _indicateReportService.GetIndicateReportById(GetReportID(2));
            if (report != null)
            {
                lblOperatorWip23.Text = @"Operator:" + report.OperatorCode;
                lblProcessWip23.Text = report.ProcessID;
                string model = report.ModelID;
                lblTotalWip23.Text = report.Total.ToString(CultureInfo.InvariantCulture);
                lblPassWip23.Text = report.Pass.ToString(CultureInfo.InvariantCulture);
                var notgood = (int)(report.Total - report.Pass);
                lblNotGoodWip23.Text = Math.Abs(notgood).ToString(CultureInfo.InvariantCulture);

                float ng = (float.Parse(notgood.ToString(CultureInfo.InvariantCulture))/
                            float.Parse(report.Total.ToString(CultureInfo.InvariantCulture))) * 100;

                //if (ng > 0)
                //{
                    lblTotalNGWip23.Text = string.Format("{0:0.0} %", Math.Round(ng, 3));
                //}
            }
        }

        /// <summary>
        /// WIP 22
        /// </summary>
        private void GetDataWip22()
        {
            var report = _indicateReportService.GetIndicateReportById(GetReportID(3));
            if (report != null)
            {
                GetScheduleMaster(report.ReportID);

                string strOperator = @"Operator:" + report.OperatorCode;
                string strProcess = report.ProcessID;
                string model = report.ModelID;
                string strTotal = report.Total.ToString(CultureInfo.InvariantCulture);
                string strPass = report.Pass.ToString(CultureInfo.InvariantCulture);
                string actual = report.Pass.ToString(CultureInfo.InvariantCulture);

                lblOperatorWip22.Text = strOperator;
                lblProcessWip22.Text = strProcess;
                lblTotalWip22.Text = strTotal;
                lblPassWip22.Text = strPass;
                lblActual.Text = actual;
                lblModelName.Text = model;
                int notgood = Convert.ToInt32(strTotal) - Convert.ToInt32(strPass);
                lblNotGoodWip22.Text = Math.Abs(notgood).ToString(CultureInfo.InvariantCulture);
                int value = Convert.ToInt32(strPass);
                if (value >= 750)
                {
                    progressBar1.Value = 750;
                    lblBalenced.ForeColor = Color.Green;
                    labelBalenced.ForeColor = Color.Green;
                }
                else
                {
                    progressBar1.Value = value;
                    lblBalenced.ForeColor = Color.Red;
                    labelBalenced.ForeColor = Color.Red;
                }

                int setplan = Convert.ToInt32(lblSetPlan.Text);
                int pass = Convert.ToInt32(strPass);
                int balenced = setplan - pass;

                if (pass > setplan)
                {
                    lblBalenced.Text = Math.Abs(balenced).ToString(CultureInfo.InvariantCulture);
                }
                else
                {
                    lblBalenced.Text = @"- " + balenced.ToString(CultureInfo.InvariantCulture);
                }

                float ng = (float.Parse(lblNotGoodWip22.Text)/float.Parse(strTotal))*100;
                //if (ng > 0.0)
                //{
                    lblTotalNGWip22.Text = string.Format("{0:0.0} %", Math.Round(ng, 3));
                //}
            }
        }

        private void GetScheduleMaster(string reportId)
        {
            var report = _reportMasterService.GetIndicateReportById(reportId);

            int time8 = _reportMasterService.SumPassByTime(report.ReportID, 8, 05, 9, 01);
            int time9 = _reportMasterService.SumPassByTime(report.ReportID, 9, 01, 9, 30);
            int time940 = _reportMasterService.SumPassByTime(report.ReportID, 9, 31, 11, 20);
            int time12 = _reportMasterService.SumPassByTime(report.ReportID, 11, 21, 13, 00);
            int time13 = _reportMasterService.SumPassByTime(report.ReportID, 13, 01, 14, 30);
            int time14 = _reportMasterService.SumPassByTime(report.ReportID, 14, 31, 16, 00);
            int time16 = _reportMasterService.SumPassByTime(report.ReportID, 16, 01, 16, 55);
            int timeOvertime = _reportMasterService.SumPassByTime(report.ReportID, 17, 56, 20, 00);

            if (time8 > 0)
            {
                int sum8 = time8 - GetNumberForText(textEditTime8_9.Text);
                ChenhLech8.Text = sum8.ToString(CultureInfo.InvariantCulture);
                ChenhLech8.ForeColor = sum8 >= 0 ? Color.Green : Color.Red;
            }

            if (time9 > 0)
            {
                int sum9 = time9 - GetNumberForText(textEditTime9_9_30.Text);
                ChenhLech9.Text = sum9.ToString(CultureInfo.InvariantCulture);
                ChenhLech9.ForeColor = sum9 >= 0 ? Color.Green : Color.Red;
            }

            if (time940 > 0)
            {
                int sum940 = time940 - GetNumberForText(textEditTime9_11.Text);
                ChenhLech940.Text = sum940.ToString(CultureInfo.InvariantCulture);
                ChenhLech940.ForeColor = sum940 >= 0 ? Color.Green : Color.Red;
            }

            if (time12 > 0)
            {
                int sum12 = time12 - GetNumberForText(textEditTime12_13.Text);
                ChenhLech12.Text = sum12.ToString(CultureInfo.InvariantCulture);
                ChenhLech12.ForeColor = sum12 >= 0 ? Color.Green : Color.Red;
            }

            if (time13 > 0)
            {
                int sum13 = time13 - GetNumberForText(textEditTime13_14.Text);
                ChenhLech13.Text = sum13.ToString(CultureInfo.InvariantCulture);
                ChenhLech13.ForeColor = sum13 >= 0 ? Color.Green : Color.Red;
            }



            if (time14 > 0)
            {
                int sum14 = time14 - GetNumberForText(textEditTime14_16.Text);
                ChenhLech14.Text = sum14.ToString(CultureInfo.InvariantCulture);
                ChenhLech14.ForeColor = sum14 >= 0 ? Color.Green : Color.Red;
            }

            if (time16 > 0)
            {
                int sum16 = time16 - GetNumberForText(textEditTime16_17.Text);
                ChenhLech16.Text = sum16.ToString(CultureInfo.InvariantCulture);
                ChenhLech16.ForeColor = sum16 >= 0 ? Color.Green : Color.Red;
            }

            if (timeOvertime > 0)
            {
                int sumOvertime = timeOvertime - GetNumberForText(textEditOvertime.Text);
                ChenhLechOvertime.Text = sumOvertime.ToString(CultureInfo.InvariantCulture);
                ChenhLechOvertime.ForeColor = sumOvertime >= 0 ? Color.Green : Color.Red;
            }
            
   

            ThucTe_8.Text = time8.ToString(CultureInfo.InvariantCulture);
            ThucTe_9.Text = time9.ToString(CultureInfo.InvariantCulture);
            ThucTe_940.Text = time940.ToString(CultureInfo.InvariantCulture);
            ThucTe_12.Text = time12.ToString(CultureInfo.InvariantCulture);
            ThucTe_13.Text = time13.ToString(CultureInfo.InvariantCulture);
            ThucTe_14.Text = time14.ToString(CultureInfo.InvariantCulture);
            ThucTe_16.Text = time16.ToString(CultureInfo.InvariantCulture);
            ThucTe_Overtime.Text = timeOvertime.ToString(CultureInfo.InvariantCulture);

        }



        private int GetNumberForText(string str)
        {
            string[] strSpit = str.Split('/');
            return Convert.ToInt32(strSpit[0]);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        private string GetReportID(int id){
            var actualModel = _actualModelService.GetActualModelById(id);
            var process = _processService.GetProcessById(actualModel.Id_model);
            string date = DateTime.Now.ToString("yyyyMMdd");
            string reportId = string.Format("{0}_{1}_{2}", process.Name_process, actualModel.Name_actual_model, date);
            return reportId;
        }

        private void label11_Click(object sender, EventArgs e)
        {

        }
    }
}
