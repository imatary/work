using DevExpress.XtraEditors;
using Lib.Core;
using Lib.Core.Helpers;
using Lib.Data;
using System;
using System.Configuration;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;
using TableDependency.Enums;
using TableDependency.EventArgs;
using TableDependency.Mappers;
using TableDependency.SqlClient;

namespace ReportsMaster
{
    public partial class FormMain : Form
    {
        private SqlTableDependency<LineStatus> tableDependency;
        delegate void SetCallBack(LabelControl control, string tex);
        delegate void SetColorCallBack(Color c, LabelControl control);
        delegate void SetCallBackColor(LabelControl lblRun, LabelControl lblPause, LabelControl lblStop, int statusLine);

        public FormMain()
        {
            InitializeComponent();
            lblVersion.Text = StringHelper.GetRunningVersion();
            Ultils.RegisterInStartup(true, Application.ExecutablePath);
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            splashScreenManager1.ShowWaitForm();
            var connectionString = ConfigurationManager.ConnectionStrings["MasterDbContext"].ConnectionString;

            var mapper = new ModelToTableMapper<LineStatus>();
            mapper.AddMapping(c => c.NameLine, "NameLine");

            tableDependency = new SqlTableDependency<LineStatus>(connectionString, "LineStatus", mapper);

            tableDependency.OnStatusChanged += TableDependency_OnStatusChanged;
            tableDependency.OnChanged += TableDependency_Changed;
            tableDependency.OnError += TableDependency_OnError;
            tableDependency.Start();
            splashScreenManager1.CloseWaitForm();
        }

        private void TableDependency_OnStatusChanged(object sender, StatusChangedEventArgs e)
        {
            Console.WriteLine(@"Status: " + e.Status);
        }

        private void TableDependency_OnError(object sender, ErrorEventArgs e)
        {
            Console.WriteLine(e.Error.Message);
        }

        private void TableDependency_Changed(object sender, RecordChangedEventArgs<LineStatus> e)
        {
            if (e.ChangeType != ChangeType.None)
            {
                var changedEntity = e.Entity;

                if (changedEntity.IdLine == 1)
                {
                    if (changedEntity.ProductionPlan >= 0 && changedEntity.ProductionActual >= 0)
                    {
                        var balenced = ((double)changedEntity.ProductionActual / changedEntity.ProductionPlan) * 100;
                        if (balenced <= 100)
                        {
                            SetText(lineUserControl1.lblBalenced, $"{Math.Round(balenced, 2)} %");
                        }
                        else
                        {
                            SetText(lineUserControl1.lblBalenced, "N/A");
                        }
                    }
                    else
                    {
                        SetText(lineUserControl1.lblBalenced, "0 %");
                    }

                    SetText(lineUserControl1.lblLineName, $"Tên Line: {changedEntity.NameLine}");
                    SetText(lineUserControl1.lblPerson, changedEntity.CountPerson.ToString());
                    SetText(lineUserControl1.lblModel, changedEntity.ModelCurrent);
                    SetText(lineUserControl1.lblPlan, changedEntity.ProductionPlan.ToString());
                    SetText(lineUserControl1.lblActual, changedEntity.ProductionActual.ToString());
                    SetText(lineUserControl1.lblComment, changedEntity.Comment);

                    SetBackgourdIsRun(lineUserControl1.lblRun, lineUserControl1.lblPause, lineUserControl1.lblStop, changedEntity.StatusLine);
                    SetBackgourdIsPause(lineUserControl1.lblRun, lineUserControl1.lblPause, lineUserControl1.lblStop, changedEntity.StatusLine);
                    SetBackgourdIsStop(lineUserControl1.lblRun, lineUserControl1.lblPause, lineUserControl1.lblStop, changedEntity.StatusLine);

                    //IsRunCallBackColorPause(true);
                }
                else if(changedEntity.IdLine == 2)
                {
                    if (changedEntity.ProductionPlan >= 0 && changedEntity.ProductionActual >= 0)
                    {
                        var balenced = ((double)changedEntity.ProductionActual / changedEntity.ProductionPlan) * 100;
                        if (balenced <= 100)
                        {
                            SetText(lineUserControl2.lblBalenced, $"{Math.Round(balenced, 2)} %");
                        }
                        else
                        {
                            SetText(lineUserControl2.lblBalenced, "N/A");
                        }
                    }
                    else
                    {
                        SetText(lineUserControl2.lblBalenced, "0 %");
                    }

                    SetText(lineUserControl2.lblLineName, $"Tên Line: {changedEntity.NameLine}");
                    SetText(lineUserControl2.lblPerson, changedEntity.CountPerson.ToString());
                    SetText(lineUserControl2.lblModel, changedEntity.ModelCurrent);
                    SetText(lineUserControl2.lblPlan, changedEntity.ProductionPlan.ToString());
                    SetText(lineUserControl2.lblActual, changedEntity.ProductionActual.ToString());
                    SetText(lineUserControl2.lblComment, changedEntity.Comment);

                    SetBackgourdIsRun(lineUserControl2.lblRun, lineUserControl2.lblPause, lineUserControl2.lblStop, changedEntity.StatusLine);
                    SetBackgourdIsPause(lineUserControl2.lblRun, lineUserControl2.lblPause, lineUserControl2.lblStop, changedEntity.StatusLine);
                    SetBackgourdIsStop(lineUserControl2.lblRun, lineUserControl2.lblPause, lineUserControl2.lblStop, changedEntity.StatusLine);
                }
                else if(changedEntity.IdLine == 3)
                {
                    if (changedEntity.ProductionPlan >= 0 && changedEntity.ProductionActual >= 0)
                    {
                        var balenced = ((double)changedEntity.ProductionActual / changedEntity.ProductionPlan) * 100;
                        if (balenced <= 100)
                        {
                            SetText(lineUserControl3.lblBalenced, $"{Math.Round(balenced, 2)} %");
                        }
                        else
                        {
                            SetText(lineUserControl3.lblBalenced, "N/A");
                        }
                    }
                    else
                    {
                        SetText(lineUserControl3.lblBalenced, "0 %");
                    }

                    SetText(lineUserControl3.lblLineName, $"Tên Line: {changedEntity.NameLine}");
                    SetText(lineUserControl3.lblPerson, changedEntity.CountPerson.ToString());
                    SetText(lineUserControl3.lblModel, changedEntity.ModelCurrent);
                    SetText(lineUserControl3.lblPlan, changedEntity.ProductionPlan.ToString());
                    SetText(lineUserControl3.lblActual, changedEntity.ProductionActual.ToString());
                    SetText(lineUserControl3.lblComment, changedEntity.Comment);

                    SetBackgourdIsRun(lineUserControl3.lblRun, lineUserControl3.lblPause, lineUserControl3.lblStop, changedEntity.StatusLine);
                    SetBackgourdIsPause(lineUserControl3.lblRun, lineUserControl3.lblPause, lineUserControl3.lblStop, changedEntity.StatusLine);
                    SetBackgourdIsStop(lineUserControl3.lblRun, lineUserControl3.lblPause, lineUserControl3.lblStop, changedEntity.StatusLine);
                }
            }
        }

        /// <summary>
        /// Color
        /// </summary>
        /// <param name="c"></param>
        /// <param name="control"></param>
        public void ChangeControlColor(Color c, LabelControl control)
        {
            if (control.InvokeRequired)
            {
                SetColorCallBack d = new SetColorCallBack(ChangeControlColor);
                control.Invoke(d, new object[] { c, control });
            }
            else
            {
                control.BackColor = c;
                control.BringToFront();
                control.Refresh();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="control"></param>
        /// <param name="t"></param>
        private void SetText(LabelControl control, string t)
        {
            if (control.InvokeRequired)
            {
                SetCallBack d = SetText;
                this.Invoke(d, new object[] { control, t });
            }
            else
            {
                control.Text = t;
            }
        }

        /// <summary>
        /// RUN BACKGOURD
        /// </summary>
        /// <param name="lblRun"></param>
        /// <param name="lblPause"></param>
        /// <param name="lblStop"></param>
        /// <param name="StatusLine"></param>
        private void SetBackgourdIsRun(LabelControl lblRun, LabelControl lblPause, LabelControl lblStop, int StatusLine)
        {
            if (StatusLine == 2)
            {
                // RUN
                if (lblRun.InvokeRequired)
                {
                    SetCallBackColor d = SetBackgourdIsRun;
                    Invoke(d, new object[] { lblRun, lblPause, lblStop, StatusLine });

                    lblRun.BackColor = Color.Lime;
                    lblRun.Text = "R";
                }
                else
                {
                    lblRun.BackColor = Color.Lime;
                    lblRun.Text = "R";
                }

                // PAUSE
                if (lblPause.InvokeRequired)
                {
                    SetCallBackColor d = SetBackgourdIsRun;
                    Invoke(d, new object[] { lblRun, lblPause, lblStop, StatusLine });

                    lblPause.BackColor = Color.FromArgb(255, 224, 192);
                    lblPause.Text = string.Empty;
                }
                else
                {
                    lblPause.BackColor = Color.FromArgb(255, 224, 192);
                    lblPause.Text = string.Empty;
                }

                // STOP
                if (lblStop.InvokeRequired)
                {
                    SetCallBackColor d = SetBackgourdIsRun;
                    Invoke(d, new object[] { lblRun, lblPause, lblStop, StatusLine });

                    lblStop.BackColor = Color.Maroon;
                    lblStop.Text = string.Empty;
                }
                else
                {
                    lblStop.BackColor = Color.Maroon;
                    lblStop.Text = string.Empty;
                }
            }

        }


        /// <summary>
        /// PAUSE BACKGOURD
        /// </summary>
        /// <param name="lblRun"></param>
        /// <param name="lblPause"></param>
        /// <param name="lblStop"></param>
        /// <param name="StatusLine"></param>
        private void SetBackgourdIsPause(LabelControl lblRun, LabelControl lblPause, LabelControl lblStop, int StatusLine)
        {
            if (StatusLine == 1)
            {
                // RUN
                if (lblRun.InvokeRequired)
                {
                    SetCallBackColor d = SetBackgourdIsPause;
                    Invoke(d, new object[] { lblRun, lblPause, lblStop, StatusLine });

                    lblRun.BackColor = Color.FromArgb(0, 64, 64);
                    lblRun.Text = string.Empty;
                }
                else
                {
                    lblRun.BackColor = Color.FromArgb(0, 64, 64);
                    lblRun.Text = string.Empty;
                }
                
                // PAUSE
                if (lblPause.InvokeRequired)
                {
                    SetCallBackColor d = SetBackgourdIsStop;
                    Invoke(d, new object[] { lblRun, lblPause, lblStop, StatusLine });

                    lblPause.BackColor = Color.Yellow;
                    lblPause.Text = "P";
                }
                else
                {
                    lblPause.BackColor = Color.Yellow;
                    lblPause.Text = "P";
                }

                // STOP
                if (lblStop.InvokeRequired)
                {
                    SetCallBackColor d = SetBackgourdIsStop;
                    Invoke(d, new object[] { lblRun, lblPause, lblStop, StatusLine });

                    lblStop.BackColor = Color.Maroon;
                    lblStop.Text = string.Empty;
                }
                else
                {
                    lblStop.BackColor = Color.Maroon;
                    lblStop.Text = string.Empty;
                }
            }
        }

        /// <summary>
        /// STOP BACKGOURD
        /// </summary>
        /// <param name="lblRun"></param>
        /// <param name="lblPause"></param>
        /// <param name="lblStop"></param>
        /// <param name="StatusLine"></param>
        private void SetBackgourdIsStop(LabelControl lblRun, LabelControl lblPause, LabelControl lblStop, int StatusLine)
        {
            if (StatusLine == 3)
            {
                // RUN
                if (lblRun.InvokeRequired)
                {
                    SetCallBackColor d = SetBackgourdIsStop;
                    Invoke(d, new object[] { lblRun, lblPause, lblStop, StatusLine });

                    lblRun.BackColor = Color.FromArgb(0, 64, 64);
                    lblRun.Text = string.Empty;
                }
                else
                {
                    lblRun.BackColor = Color.FromArgb(0, 64, 64);
                    lblRun.Text = string.Empty;
                }
                // PAUSE
                if (lblPause.InvokeRequired)
                {
                    SetCallBackColor d = SetBackgourdIsRun;
                    Invoke(d, new object[] { lblRun, lblPause, lblStop, StatusLine });

                    lblPause.BackColor = Color.FromArgb(255, 224, 192);
                    lblPause.Text = string.Empty;
                }
                else
                {
                    lblPause.BackColor = Color.FromArgb(255, 224, 192);
                    lblPause.Text = string.Empty;
                }
                // STOP
                if (lblStop.InvokeRequired)
                {
                SetCallBackColor d = SetBackgourdIsStop;
                    Invoke(d, new object[] { lblRun, lblPause, lblStop, StatusLine });

                    lblStop.BackColor = Color.Red;
                    lblStop.Text = "S";
                }
                else
                {
                    lblStop.BackColor = Color.Red;
                    lblStop.Text = "S";
                }
            }

        }

        private void timerPause_Tick(object sender, EventArgs e)
        {
            if (lineUserControl1.lblPause.Appearance.BackColor == Color.Yellow)
            {
                ChangeControlColor(Color.FromArgb(255, 224, 192), lineUserControl1.lblPause);
                SetText(lineUserControl1.lblPause, string.Empty);
            }
            else
            {
                ChangeControlColor(Color.Yellow, lineUserControl1.lblPause);
                SetText(lineUserControl1.lblPause, "P");
            }
        }

        private void IsRunCallBackColorPause(bool isRun)
        {
            while (isRun)
            {
                ChangeControlColor(Color.FromArgb(255, 224, 192), lineUserControl1.lblPause);
                SetText(lineUserControl1.lblPause, string.Empty);
                Thread.Sleep(500);
                ChangeControlColor(Color.Yellow, lineUserControl1.lblPause);
                SetText(lineUserControl1.lblPause, "P");
                Thread.Sleep(500);
            }
        }
    }
}
