using System;
using System.Drawing;
using System.Globalization;
using Indicate.Data;
using IndicateReort.Properties;
using IndicateReort.Service;

namespace IndicateReort
{
    public partial class FormLineCanon : DevExpress.XtraEditors.XtraForm
    {

        private readonly LineService _lineService;
        private readonly CustomerService _customerService;
        private readonly ProcessService _processService;
        private readonly ModelService _modelService;
        private readonly ShowResultService _showResultService;
        private readonly ShiftService _shiftService;
        private readonly TimingService _timingService;
        private readonly LineProcessService _lineProcessService;

        private Line _line;
        private Line_status _lineStatus;
        public FormLineCanon()
        {
            InitializeComponent();

            _lineService = new LineService();
            _customerService = new CustomerService();
            _processService = new ProcessService();
            _modelService = new ModelService();
            _showResultService = new ShowResultService();
            _shiftService = new ShiftService();
            _timingService = new TimingService();
            _lineProcessService = new LineProcessService();
        }

        private void FormLineDetails_Load(object sender, EventArgs e)
        {
            _line = _lineService.GetLineByName("RM2-8050/51");
            _lineStatus = _modelService.GetLineStatusByLineAndCustomer(_line.Id_line, _line.Id_customer);
            LoadData();
        }

        private void timerRunAuto_Tick(object sender, EventArgs e)
        {
            LoadData();
        }

        private void LoadData()
        {

            lblCustomer.Text = Resources.CustomerName + _customerService.GetCustomerById(_line.Id_customer).Name_customer;
            string modelId = _modelService.GetLineStatusByLineAndCustomer(_line.Id_line, _line.Id_customer).Current_model;
            var model = _modelService.GetModelById(modelId);
            lblModelName.Text = model.Name_model;
            lblSetPlan.Text = model.Set_plan.ToString();
            string shift = null;
            if (_lineStatus.Shift != null)
            {
                shift = _shiftService.GetSheetProductionsById((int) _lineStatus.Shift).Name_sheet_production;
            }
            const string assembly = "Assembly";
            const string hipot = "Hipot";
            const string vi2 = "VI2";

            GetDataForProcessAssembly(_line.Id_customer, _line.Id_line, model.Id_model, assembly, shift);
            GetDataForProcessHipot(_line.Id_customer, _line.Id_line, model.Id_model, hipot, shift);
            GetDataForProcessVi2(_line.Id_customer, _line.Id_line, model.Id_model, vi2, shift);
        }

        

        /// <summary>
        /// 
        /// </summary>
        /// <param name="customerId"></param>
        /// <param name="lineId"></param>
        /// <param name="modelId"></param>
        /// <param name="processName"></param>
        /// <param name="shift"></param>      
        private void GetDataForProcessAssembly(string customerId, int lineId, string modelId, string processName, string shift)
        {
            // CS005_1_RM2-8050_Assembly_10-19-2015_Ca_Ngay_0

            //CS005_1_RM2-8051_Assembly_10-21-2015_Ca_Dem_0
            string id = null;
            foreach (var lineProcess in _lineProcessService.GetLinesProcesseses(_line.Id_line))
            {
                if (lineProcess.Id_process == processName)
                {
                    //id = string.Format("{0}_{1}_{2}_{3}_{4}_{5}_{6}", customerId, lineId, modelId, processName, date, shift, lineProcess.lever_of_process);
                    if (lineProcess.lever_of_process != null)
                    {
                        id = ReportID(customerId, lineId, modelId, processName, shift, (int) lineProcess.lever_of_process);
                    }
                }
                else
                {
                    //id = string.Format("{0}_{1}_{2}_{3}_{4}_{5}_{6}", customerId, lineId, modelId, processName, date, shift, lineProcess.lever_of_process);
                    if (lineProcess.lever_of_process != null)
                    {
                        id = ReportID(customerId, lineId, modelId, processName, shift, (int)lineProcess.lever_of_process);
                    }
                }

                var result = _showResultService.GetShowResultById(id);
                if (result != null)
                {
                    lblProcessAssembly.Text = processName;
                    lblTotalAssembly.Text = result.Total.ToString();
                    lblPassAssembly.Text = result.Pass.ToString();
                    lblOperatorAssembly.Text = result.Operator_code;
                    lblNGAssembly.Text = result.NG.ToString();
                    float ng = 0;
                    if (result.NG > 0 || result.Total > 0)
                    {
                        ng = (float.Parse(result.NG.ToString()) / float.Parse(result.Total.ToString())) * 100;

                    }
                    lblNGCountAssembly.Text = string.Format("{0:0} %", Math.Round(ng, 3));

                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="customerId"></param>
        /// <param name="lineId"></param>
        /// <param name="modelId"></param>
        /// <param name="processName"></param>
        /// <param name="shift"></param>
        private void GetDataForProcessHipot(string customerId, int lineId, string modelId, string processName, string shift)
        {

            string id = null;
            foreach (var lineProcess in _lineProcessService.GetLinesProcesseses(_line.Id_line))
            {
                if (lineProcess.Id_process == processName)
                {
                    //id = string.Format("{0}_{1}_{2}_{3}_{4}_{5}_{6}", customerId, lineId, modelId, processName, date, shift, lineProcess.lever_of_process);
                    if (lineProcess.lever_of_process != null)
                    {
                        id = ReportID(customerId, lineId, modelId, processName, shift, (int)lineProcess.lever_of_process);
                    }
                }
                else
                {
                    //id = string.Format("{0}_{1}_{2}_{3}_{4}_{5}_{6}", customerId, lineId, modelId, processName, date, shift, lineProcess.lever_of_process);
                    if (lineProcess.lever_of_process != null)
                    {
                        id = ReportID(customerId, lineId, modelId, processName, shift, (int)lineProcess.lever_of_process);
                    }
                }

                var result = _showResultService.GetShowResultById(id);
                if (result != null)
                {
                    lblProcessHipot.Text = processName;
                    lblTotalHipot.Text = result.Total.ToString();
                    lblPassHipot.Text = result.Pass.ToString();
                    lblOperatorHipot.Text = result.Operator_code;
                    lblNGHipot.Text = result.NG.ToString();

                    float ng = 0;
                    if (result.NG > 0 || result.Total > 0)
                    {
                        ng = (float.Parse(result.NG.ToString()) / float.Parse(result.Total.ToString())) * 100;
                    }
                    lblNGCountHipot.Text = string.Format("{0:0} %", Math.Round(ng, 3));

                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="customerId"></param>
        /// <param name="lineId"></param>
        /// <param name="modelId"></param>
        /// <param name="processName"></param>
        /// <param name="shift"></param>
        private void GetDataForProcessVi2(string customerId, int lineId, string modelId, string processName, string shift)
        {

            string id = null;
            foreach (var lineProcess in _lineProcessService.GetLinesProcesseses(_line.Id_line))
            {
                if (lineProcess.Id_process == processName)
                {
                    //id = string.Format("{0}_{1}_{2}_{3}_{4}_{5}_{6}", customerId, lineId, modelId, processName, date,
                    //    shift, lineProcess.lever_of_process);
                    if (lineProcess.lever_of_process != null)
                    {
                        id = ReportID(customerId, lineId, modelId, processName, shift, (int)lineProcess.lever_of_process);
                    }
                }
                else
                {
                    //id = string.Format("{0}_{1}_{2}_{3}_{4}_{5}_{6}", customerId, lineId, modelId, processName, date,
                    //    shift, lineProcess.lever_of_process);
                    if (lineProcess.lever_of_process != null)
                    {
                        id = ReportID(customerId, lineId, modelId, processName, shift, (int)lineProcess.lever_of_process);
                    }
                }
                var result = _showResultService.GetShowResultById(id);
                if (result != null)
                {
                    lblProcessVI2.Text = processName;
                    lblTotalVI2.Text = result.Total.ToString();
                    lblPassVI2.Text = result.Pass.ToString();
                    lblOperatorVI2.Text = result.Operator_code;
                    lblNGVI2.Text = result.NG.ToString();
                    lblActual.Text = result.Pass.ToString();
                    float ng = 0;
                    if (result.NG > 0 && result.Total > 0)
                    {
                        ng = (float.Parse(result.NG.ToString())/float.Parse(result.Total.ToString()))*100;

                    }
                    lblNGCountVI2.Text = string.Format("{0:0} %", Math.Round(ng, 3));

                    //int value = Convert.ToInt32(result.Pass);
                    //if (value >= 750)
                    //{
                    //    progressBar1.Value = 750;
                    //    lblBalenced.ForeColor = Color.Green;
                    //    labelBalenced.ForeColor = Color.Green;
                    //}
                    //else
                    //{
                    //    progressBar1.Value = value;
                    //    lblBalenced.ForeColor = Color.Red;
                    //    labelBalenced.ForeColor = Color.Red;
                    //}

                    //int setplan = Convert.ToInt32(lblSetPlan.Text);

                    //int balenced = setplan - value;

                    //if (value > setplan)
                    //{
                    //    lblBalenced.Text = Math.Abs(balenced).ToString(CultureInfo.InvariantCulture);
                    //}
                    //else
                    //{
                    //    lblBalenced.Text = @"N- " + balenced.ToString(CultureInfo.InvariantCulture);
                    //}

                    if (_lineStatus.Shift != null) 
                        GetScheduleMaster((int) _lineStatus.Shift);
                }
            }
        }

        private void GetScheduleMaster(int shift)
        {
            gridControl1.DataSource = _timingService.GetScheduleViews(shift);
            var time = new TimeSpan(DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second);

            foreach (var timing in _timingService.GetTimings(shift))
            {

                if (time >= timing.StartTime && time <= timing.EndTime)
                {
                    int chenhlenh = (int) (timing.Products_current_hour - timing.SetPlan);
                    if (chenhlenh > 0)
                    {
                        lblBalenced.ForeColor = Color.Green;
                        labelBalenced.ForeColor = Color.Green;
                    }
                    else
                    {
                        lblBalenced.ForeColor = Color.Red;
                        labelBalenced.ForeColor = Color.Red;
                    }
                    lblBalenced.Text = chenhlenh.ToString();

                }
            }

        }

        private string ReportID(string customerId, int lineId, string modelId, string processName, string shift, int level)
        {
            //CS005_1_RM2-8051_Assembly_10-21-2015_Ca_Dem_0
            string id = null;
            string dateReport = DateTime.Now.ToString("MM-dd-yyyy");
            DateTime currentDate = DateTime.Now;
            if (shift == "Ca_Dem")
            {
                if (currentDate.Hour >= 19 && currentDate.Hour <= 23)
                {
                    id = string.Format("{0}_{1}_{2}_{3}_{4}_{5}_{6}", customerId, lineId, modelId, processName, dateReport, shift, level);
                }
                else if (currentDate.Hour >= 0 && currentDate.Hour <= 7)
                {
                    if (currentDate.Day > 1)
                    {
                        dateReport = string.Format("{0}-{1}-{2}", currentDate.Month, currentDate.Day - 1, currentDate.Year);
                        id = string.Format("{0}_{1}_{2}_{3}_{4}_{5}_{6}", customerId, lineId, modelId, processName, dateReport, shift, level);
                    }
                    else
                    {
                        switch (currentDate.Month - 1)
                        {
                            case 1:
                            case 3:
                            case 5:
                            case 7:
                            case 8:
                            case 10:
                            case 12:
                                dateReport = string.Format("{0}-{1}-{2}", currentDate.Month - 1, "31", currentDate.Year);
                                id = string.Format("{0}_{1}_{2}_{3}_{4}_{5}_{6}", customerId, lineId, modelId, processName, dateReport, shift, level);
                                break;
                            case 4:
                            case 6:
                            case 9:
                            case 11:
                                dateReport = string.Format("{0}-{1}-{2}", currentDate.Month, "30", currentDate.Year);
                                id = string.Format("{0}_{1}_{2}_{3}_{4}_{5}_{6}", customerId, lineId, modelId, processName, dateReport, shift, level);
                                break;

                            case 2:
                                if (((currentDate.Year%4 == 0) && (currentDate.Year%100 != 0)) || (currentDate.Year%400 == 0))
                                {
                                    dateReport = string.Format("{0}-{1}-{2}", "02", "29", currentDate.Year);
                                    id = string.Format("{0}_{1}_{2}_{3}_{4}_{5}_{6}", customerId, lineId, modelId, processName, dateReport, shift, level);
                                }
                                else
                                {
                                    dateReport = string.Format("{0}-{1}-{2}", "02", "28", currentDate.Year);
                                    id = string.Format("{0}_{1}_{2}_{3}_{4}_{5}_{6}", customerId, lineId, modelId, processName, dateReport, shift, level);
                                }
                                break;
                            default:
                                id = string.Format("{0}_{1}_{2}_{3}_{4}_{5}_{6}", customerId, lineId, modelId, processName, dateReport, shift, level);
                                break;
                        }
                    }
                }
            }
            else
            {
                id = string.Format("{0}_{1}_{2}_{3}_{4}_{5}_{6}", customerId, lineId, modelId, processName, dateReport, shift, level);
            }
            return id;
        }
    }
}