using Lib.Core.Helper;
using NichiconSystem.Data;
using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace NichiconSystem
{
    public partial class FormAddModel : Form
    {
        private readonly NichiconDbContext _context;
        public FormAddModel()
        {
            InitializeComponent();
            _context = new NichiconDbContext();
        }

        private void FormAddModel_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void LoadData()
        {
            gridControl1.DataSource = _context.Models.OrderByDescending(m => m.DateCreated).ToList();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtModelName.Text))
            {
                Ultils.EditTextErrorMessage(txtModelName, "Model Name không được bỏ trống!");
            }
            else if (string.IsNullOrEmpty(txtQuantity.Text))
            {
                Ultils.EditTextErrorMessage(txtQuantity, "Quantity không được bỏ trống!");
            }
            else if (string.IsNullOrEmpty(txtSerialNo.Text))
            {
                Ultils.EditTextErrorMessage(txtSerialNo, "Serial No không được bỏ trống!");
            }
            else
            {
                var model = new Model()
                {
                    ModelName = txtModelName.Text,
                    Quantity = int.Parse(txtQuantity.Text),
                    SerialNo = txtSerialNo.Text,
                };
                try
                {
                    _context.Models.Add(model);
                    _context.SaveChanges();
                    LoadData();
                    ResetTextControls();
                    MessageBox.Show("Insert success!");
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error inresrt!\n {ex.Message}", "Error Insert!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            var model = _context.Models.SingleOrDefault(m => m.ModelName == txtModelName.Text);
            if (model != null)
            {
                try
                {
                    _context.Models.Remove(model);
                    _context.SaveChanges();

                    LoadData();
                    ResetTextControls();

                    MessageBox.Show("Delete success!");
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error Delete!\n {ex.Message}", "Error Delete!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            btnDel.Enabled = false;
        }

        /// <summary>
        /// 
        /// </summary>
        private void ResetTextControls()
        {
            txtModelName.ResetText();
            txtQuantity.ResetText();
            txtSerialNo.ResetText();
        }

        private void gridView1_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            if(e.Clicks >= 1)
            {
                var modelName = (string)gridView1.GetRowCellValue(e.RowHandle, "ModelName");

                var model = _context.Models.SingleOrDefault(m => m.ModelName == modelName);
                txtModelName.Text = model.ModelName;
                txtQuantity.Text = model.Quantity.ToString();
                txtSerialNo.Text = model.SerialNo;

                btnDel.Enabled = true;
            }
        }
    }
}
