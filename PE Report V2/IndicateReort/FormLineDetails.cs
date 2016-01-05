using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;
using Indicate.Data;
using IndicateReort.Properties;
using IndicateReort.Service;

namespace IndicateReort
{
    public partial class FormLineDetails : Form
    {
        private readonly LineService _lineService;
        private readonly CustomerService _customerService;
        private readonly ProcessService _processService;
        private readonly ModelService _modelService;
        private readonly ShowResultService _showResultService;
        private readonly ShiftService _shiftService;


        private readonly Line _line;
        private readonly Line_status _lineStatus;
        public FormLineDetails(string lineId)
        {
            InitializeComponent();
            _lineService = new LineService();
            _customerService = new CustomerService();
            _processService = new ProcessService();
            _modelService = new ModelService();
            _showResultService = new ShowResultService();
            _shiftService = new ShiftService();


            _line = _lineService.GetLineByName(lineId);
            _lineStatus = _modelService.GetLineStatusByLineAndCustomer(_line.Id_line, _line.Id_customer);
        }

        private void FormLineDetails_Load(object sender, System.EventArgs e)
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

            //int setplan = Convert.ToInt32(model.Set_plan);
            //int pass = Convert.ToInt32(strPass);
            //int balenced = setplan - pass;

            //if (pass > setplan)
            //{
            //    lblBalenced.Text = Math.Abs(balenced).ToString(CultureInfo.InvariantCulture);
            //}
            //else
            //{
            //    lblBalenced.Text = @"- " + balenced.ToString(CultureInfo.InvariantCulture);
            //}


            var processPanels = new List<ProcessDetailControl>();
            var getProcessByLineId = _processService.GetAllProcesseses(_line.Id_line);
            for (int i = 0; i < getProcessByLineId.Count; i++)
            {
                var processes = getProcessByLineId.ElementAtOrDefault(i);
                var processFirst = getProcessByLineId.ElementAtOrDefault(i-1);
                var mp = new ProcessDetailControl();
                string processName = null;
                int x = 293;
                int y = 32;
                if (processes != null)
                {       
                    processName = processes.Id_process;
                    processPanels.Add(mp);
                    mp.ProcessName = processName;
                    mp.Name = "Panel" + processName + i;
                    mp.Location = new Point(x * i, y);
                }
                if (processFirst!=null)
                {
                    if (processName == processFirst.Id_process)
                    {
                        mp.Location = new Point(x*(i - 1), y);
                    }
                    else
                    {
                        mp.Location = new Point(x * (i - 1), y);
                    }
                }

                //if (i < 4)
                //{
                //    //MessageBox.Show("OK");
                //    panelControl1.Left = (this.ClientSize.Width - panelControl1.Width) / 2;
                //    panelControl1.Top = (this.ClientSize.Height - panelControl1.Height) / 2;
                //}
                //else
                //{
                //    mp.Location = new Point(300 * i, 32);
                //}
                string shift = null;
                if (_lineStatus.Shift != null)
                {
                    shift = _shiftService.GetSheetProductionsById((int) _lineStatus.Shift).Name_sheet_production;
                }
                string date = DateTime.Now.Date.ToString("MM-dd-yyyy");
                string id = string.Format("{0}_{1}_{2}_{3}_{4}_{5}_{6}", _line.Id_customer, _line.Id_line, model.Id_model, processName, date, shift, 0);
                var result = _showResultService.GetShowResultById(id);
                if (result != null)
                {
                    mp.Total = result.Total.ToString();
                    mp.Pass = result.Pass.ToString();
                    mp.OperatorCode = result.Operator_code;
                }

                if (i == getProcessByLineId.Count - 1)
                {
                    mp.pictureEdit1.Visible = false;
    
                }

                processPanels.Add(mp);
            }

            foreach (var p in processPanels)
            {
                panelControl1.SuspendLayout();
                panelControl1.Controls.Add(p);
                panelControl1.ResumeLayout();
            }

            
        }

        private void timerRunAuto_Tick(object sender, EventArgs e)
        {
            //LoadData();
        }


        //public void GetDetailProcess(string customerId, int lineId, string modelId, string processId, string date,
        //    string shift, int sort)
        //{
        //    string id = string.Format("{0}_{1}_{2}_{3}_{4}_{5}_{6}", customerId, lineId, modelId, processId, date, shift, sort);
        //    var result = _showResultService.GetShowResultById(id);
        //} 

    }
}
