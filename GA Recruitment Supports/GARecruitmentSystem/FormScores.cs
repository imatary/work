using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace GARecruitmentSystem
{
    public partial class FormScores : DevExpress.XtraEditors.XtraForm
    {
        public FormScores()
        {
            InitializeComponent();
        }

        private void barButtonItemAddScores_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var inputScore = new FormInputScore();
            inputScore.ShowDialog();
        }
    }
}