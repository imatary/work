using Lib.Forms;
using Lib.Forms.Helpers;
using Lib.Services;
using System;
using System.Windows.Forms;

namespace GARecruitmentSystem
{
    public partial class FormEditScore : Form
    {
        private ScoreService _scoreService;
        private readonly ResultsService _resultService;
        private Guid _id;
        private DateTime _dateCreated;
        public FormEditScore(Guid Id, DateTime DateCreated)
        {
            InitializeComponent();
            _scoreService = new ScoreService();
            _resultService = new ResultsService();
            _id = Id;
            _dateCreated = DateCreated;
            LoadDataToControls(Id, DateCreated);
        }

        private void LoadDataToControls(Guid id, DateTime DateCreated)
        {
            var score = _scoreService.GetScoreById(id, DateCreated);
            if(score != null)
            {
                txtFullName.Text = score.FullName;
                txtBrithDay.Text = score.Birthday;
                txtPartOne_Pear1.Text = score.PI_P1.ToString();
                txtPartOne_Pear2.Text = score.PI_P2.ToString();
                txtPartOne_Pear3.Text = score.PI_P3.ToString();
                txtPartOne_Pear4.Text = score.PI_P4.ToString();
                txtPartOne_Pear5.Text = score.PI_P5.ToString();
                txtPartOne_Pear6.Text = score.PI_P6.ToString();
                txtPartOne_Pear7.Text = score.PI_P7.ToString();
                txtPartOne_Pear8.Text = score.PI_P8.ToString();
                txtPartOne_Pear9.Text = score.PI_P9.ToString();
                txtPartOne_Pear10.Text = score.PI_P10.ToString();
                txtPartOne_Pear11.Text = score.PI_P11.ToString();
                txtPartOne_Pear12.Text = score.PI_P12.ToString();
                txtPartOne_Pear13.Text = score.PI_P13.ToString();
                //Part Two
                txtPartTwo_Pear1.Text = score.PII_P1.ToString();
                txtPartTwo_Pear2.Text = score.PII_P2.ToString();
                txtPartTwo_Pear3.Text = score.PII_P3.ToString();
                txtPartTwo_Pear4.Text = score.PII_P4.ToString();
                txtPartTwo_Pear5.Text = score.PII_P5.ToString();
                txtPartTwo_Pear6.Text = score.PII_P6.ToString();
                txtPartTwo_Pear7.Text = score.PII_P7.ToString();
                txtPartTwo_Pear8.Text = score.PII_P8.ToString();
                txtPartTwo_Pear9.Text = score.PII_P9.ToString();
                txtPartTwo_Pear10.Text = score.PII_P10.ToString();
                txtPartTwo_Pear11.Text = score.PII_P11.ToString();
                txtPartTwo_Pear12.Text = score.PII_P12.ToString();
                txtPartTwo_Pear13.Text = score.PII_P13.ToString();

                txtPartOne_Even1.Text = score.PI_E1.ToString();
                txtPartOne_Even2.Text = score.PI_E2.ToString();
                txtPartOne_Even3.Text = score.PI_E3.ToString();
                txtPartOne_Even4.Text = score.PI_E4.ToString();
                txtPartOne_Even5.Text = score.PI_E5.ToString();
                txtPartOne_Even6.Text = score.PI_E6.ToString();
                txtPartOne_Even7.Text = score.PI_E7.ToString();
                txtPartOne_Even8.Text = score.PI_E8.ToString();
                txtPartOne_Even9.Text = score.PI_E9.ToString();
                txtPartOne_Even10.Text = score.PI_E10.ToString();
                txtPartOne_Even11.Text = score.PI_E11.ToString();
                txtPartOne_Even12.Text = score.PI_E12.ToString();
                txtPartOne_Even13.Text = score.PI_E13.ToString();

                //Part Two
                txtPartTwo_Even1.Text = score.PII_E1.ToString();
                txtPartTwo_Even2.Text = score.PII_E2.ToString();
                txtPartTwo_Even3.Text = score.PII_E3.ToString();
                txtPartTwo_Even4.Text = score.PII_E4.ToString();
                txtPartTwo_Even5.Text = score.PII_E5.ToString();
                txtPartTwo_Even6.Text = score.PII_E6.ToString();
                txtPartTwo_Even7.Text = score.PII_E7.ToString();
                txtPartTwo_Even8.Text = score.PII_E8.ToString();
                txtPartTwo_Even9.Text = score.PII_E9.ToString();
                textEdit20txtPartTwo_Even10.Text = score.PII_E10.ToString();
                txtPartTwo_Even11.Text = score.PII_E11.ToString();
                txtPartTwo_Even12.Text = score.PII_E12.ToString();
                txtPartTwo_Even13.Text = score.PII_E13.ToString();

                txtPartOne_SumPear.Text = score.PI_SumPear.ToString();
                txtPartOne_SumEven.Text = score.PI_SumEven.ToString();
                txtPartTwo_SumPear.Text = score.PII_SumPear.ToString();
                txtPartTwo_SumEven.Text = score.PII_SumEven.ToString();

                txtTotalScorePear.Text = score.TotalPear.ToString();
                txtTotalEven.Text = score.TotalEven.ToString();

                txtScorePicture.Text = score.ScorePicture.ToString();
                txtScoreEye.Text = score.ScoreEye.ToString();

                lblPercent.Text = $"{ score.Percent }%";
                lblDifference.Text = score.Difference.ToString();
                lblKetQua.Text = score.KetQua;

                lblPercentPicture.Text = $"{score.PercentPicture}%";
                lblKetQuaPicture.Text = score.KetQuaPicture;

                lblScorEye.Text = score.KetQuaEye;
            }
        }


        /// <summary>
        /// Array pear
        /// </summary>
        /// <returns></returns>
        private string[] GetArrayPartOnePears()
        {
            string[] pears =
            {
                txtPartOne_Pear1.Text,
                txtPartOne_Pear2.Text,
                txtPartOne_Pear3.Text,
                txtPartOne_Pear4.Text,
                txtPartOne_Pear5.Text,
                txtPartOne_Pear6.Text,
                txtPartOne_Pear7.Text,
                txtPartOne_Pear8.Text,
                txtPartOne_Pear9.Text,
                txtPartOne_Pear10.Text,
                txtPartOne_Pear11.Text,
                txtPartOne_Pear11.Text,
                txtPartOne_Pear13.Text,
            };

            return pears;
        }

        /// <summary>
        /// Array pear
        /// </summary>
        /// <returns></returns>
        private string[] GetArrayPartOneEvens()
        {
            string[] evens =
            {
                txtPartOne_Even1.Text,
                txtPartOne_Even2.Text,
                txtPartOne_Even3.Text,
                txtPartOne_Even4.Text,
                txtPartOne_Even5.Text,
                txtPartOne_Even6.Text,
                txtPartOne_Even7.Text,
                txtPartOne_Even8.Text,
                txtPartOne_Even9.Text,
                txtPartOne_Even10.Text,
                txtPartOne_Even11.Text,
                txtPartOne_Even12.Text,
                txtPartOne_Even13.Text,
            };

            return evens;
        }

        /// <summary>
        /// Array Pear PartTwo
        /// </summary>
        /// <returns></returns>
        private string[] GetArrayPartTwoPears()
        {
            string[] pears =
            {
                txtPartTwo_Pear1.Text,
                txtPartTwo_Pear2.Text,
                txtPartTwo_Pear3.Text,
                txtPartTwo_Pear4.Text,
                txtPartTwo_Pear5.Text,
                txtPartTwo_Pear6.Text,
                txtPartTwo_Pear7.Text,
                txtPartTwo_Pear8.Text,
                txtPartTwo_Pear9.Text,
                txtPartTwo_Pear10.Text,
                txtPartTwo_Pear11.Text,
                txtPartTwo_Pear12.Text,
                txtPartTwo_Pear13.Text,
            };

            return pears;
        }
        /// <summary>
        /// Array Even PartTwo
        /// </summary>
        /// <returns></returns>
        private string[] GetArrayPartTwoEvens()
        {
            string[] evens =
            {
                txtPartTwo_Even1.Text,
                txtPartTwo_Even2.Text,
                txtPartTwo_Even3.Text,
                txtPartTwo_Even4.Text,
                txtPartTwo_Even5.Text,
                txtPartTwo_Even6.Text,
                txtPartTwo_Even7.Text,
                txtPartTwo_Even8.Text,
                txtPartTwo_Even9.Text,
                textEdit20txtPartTwo_Even10.Text,
                txtPartTwo_Even11.Text,
                txtPartTwo_Even12.Text,
                txtPartTwo_Even13.Text,
            };

            return evens;
        }

        /// <summary>
        /// Array Sum pear 
        /// </summary>
        /// <returns></returns>
        private string[] GetArraySumPears()
        {
            string[] sumPears =
            {
                txtPartOne_SumPear.Text,
                txtPartTwo_SumPear.Text,
            };

            return sumPears;
        }

        private string[] GetArrayPearAllParts()
        {
            string[] pears =
            {
                txtPartOne_Pear1.Text,
                txtPartOne_Pear2.Text,
                txtPartOne_Pear3.Text,
                txtPartOne_Pear4.Text,
                txtPartOne_Pear5.Text,
                txtPartOne_Pear6.Text,
                txtPartOne_Pear7.Text,
                txtPartOne_Pear8.Text,
                txtPartOne_Pear9.Text,
                txtPartOne_Pear10.Text,
                txtPartOne_Pear11.Text,
                txtPartOne_Pear11.Text,
                txtPartOne_Pear13.Text,
                //Part Two
                txtPartTwo_Pear1.Text,
                txtPartTwo_Pear2.Text,
                txtPartTwo_Pear3.Text,
                txtPartTwo_Pear4.Text,
                txtPartTwo_Pear5.Text,
                txtPartTwo_Pear6.Text,
                txtPartTwo_Pear7.Text,
                txtPartTwo_Pear8.Text,
                txtPartTwo_Pear9.Text,
                txtPartTwo_Pear10.Text,
                txtPartTwo_Pear11.Text,
                txtPartTwo_Pear12.Text,
                txtPartTwo_Pear13.Text,
            };

            return pears;
        }

        private string[] GetArrayEvenAllParts()
        {
            string[] pears =
            {
                txtPartOne_Even1.Text,
                txtPartOne_Even2.Text,
                txtPartOne_Even3.Text,
                txtPartOne_Even4.Text,
                txtPartOne_Even5.Text,
                txtPartOne_Even6.Text,
                txtPartOne_Even7.Text,
                txtPartOne_Even8.Text,
                txtPartOne_Even9.Text,
                txtPartOne_Even10.Text,
                txtPartOne_Even11.Text,
                txtPartOne_Even12.Text,
                txtPartOne_Even13.Text,

                //Part Two
                txtPartTwo_Even1.Text,
                txtPartTwo_Even2.Text,
                txtPartTwo_Even3.Text,
                txtPartTwo_Even4.Text,
                txtPartTwo_Even5.Text,
                txtPartTwo_Even6.Text,
                txtPartTwo_Even7.Text,
                txtPartTwo_Even8.Text,
                txtPartTwo_Even9.Text,
                textEdit20txtPartTwo_Even10.Text,
                txtPartTwo_Even11.Text,
                txtPartTwo_Even12.Text,
                txtPartTwo_Even13.Text,

            };

            return pears;
        }

        /// <summary>
        /// Array Sum Even 
        /// </summary>
        /// <returns></returns>
        private string[] GetArraySumEven()
        {
            string[] sumPears =
            {
                txtPartOne_SumEven.Text,
                txtPartTwo_SumEven.Text,
            };

            return sumPears;
        }
        private void txtFullName_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (!CheckTextBoxNullValue.ValidationTextEditNullValue(txtFullName))
                {
                    dxErrorProvider1.SetError(txtFullName, "Vui lòng nhập vào 'Họ và Tên' của ứng viên");
                }
                else
                {
                    txtBrithDay.Focus();
                }
            }
        }

        private void txtBrithDay_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (!CheckTextBoxNullValue.ValidationTextEditNullValue(txtBrithDay))
                {
                    dxErrorProvider1.SetError(txtBrithDay, "Vui lòng nhập vào 'Ngày sinh' của ứng viên");
                }
                else
                {
                    txtBrithDay.Focus();
                }
            }
        }


        #region Event EditValueChanged
        private void txtFullName_EditValueChanged(object sender, EventArgs e)
        {
            CheckTextBoxNullValue.SetColorDefaultTextControl(dxErrorProvider1, txtFullName);
        }

        private void txtBrithDay_EditValueChanged(object sender, EventArgs e)
        {
            CheckTextBoxNullValue.SetColorDefaultTextControl(dxErrorProvider1, txtBrithDay);
        }

        private void txtPartOne_Pear1_EditValueChanged(object sender, EventArgs e)
        {
            CheckTextBoxNullValue.SetColorDefaultTextControl(dxErrorProvider1, txtPartOne_Pear1);
        }

        private void txtPartOne_Even1_EditValueChanged(object sender, EventArgs e)
        {
            CheckTextBoxNullValue.SetColorDefaultTextControl(dxErrorProvider1, txtPartOne_Even1);
        }

        private void txtPartOne_Pear2_EditValueChanged(object sender, EventArgs e)
        {
            CheckTextBoxNullValue.SetColorDefaultTextControl(dxErrorProvider1, txtPartOne_Pear2);
        }

        private void txtPartOne_Even2_EditValueChanged(object sender, EventArgs e)
        {
            CheckTextBoxNullValue.SetColorDefaultTextControl(dxErrorProvider1, txtPartOne_Even2);
        }

        private void txtPartOne_Pear3_EditValueChanged(object sender, EventArgs e)
        {
            CheckTextBoxNullValue.SetColorDefaultTextControl(dxErrorProvider1, txtPartOne_Pear3);
        }

        private void txtPartOne_Even3_EditValueChanged(object sender, EventArgs e)
        {
            CheckTextBoxNullValue.SetColorDefaultTextControl(dxErrorProvider1, txtPartOne_Even3);
        }

        private void txtPartOne_Pear4_EditValueChanged(object sender, EventArgs e)
        {
            CheckTextBoxNullValue.SetColorDefaultTextControl(dxErrorProvider1, txtPartOne_Pear4);
        }

        private void txtPartOne_Even4_EditValueChanged(object sender, EventArgs e)
        {
            CheckTextBoxNullValue.SetColorDefaultTextControl(dxErrorProvider1, txtPartOne_Even4);
        }

        private void txtPartOne_Pear5_EditValueChanged(object sender, EventArgs e)
        {
            CheckTextBoxNullValue.SetColorDefaultTextControl(dxErrorProvider1, txtPartOne_Pear5);
        }

        private void txtPartOne_Even5_EditValueChanged(object sender, EventArgs e)
        {
            CheckTextBoxNullValue.SetColorDefaultTextControl(dxErrorProvider1,txtPartOne_Even5);
        }

        private void txtPartOne_Pear6_EditValueChanged(object sender, EventArgs e)
        {
            CheckTextBoxNullValue.SetColorDefaultTextControl(dxErrorProvider1,txtPartOne_Pear6);
        }

        private void txtPartOne_Even6_EditValueChanged(object sender, EventArgs e)
        {
            CheckTextBoxNullValue.SetColorDefaultTextControl(dxErrorProvider1,txtPartOne_Even6);
        }

        private void txtPartOne_Pear7_EditValueChanged(object sender, EventArgs e)
        {
            CheckTextBoxNullValue.SetColorDefaultTextControl(dxErrorProvider1,txtPartOne_Pear7);
        }

        private void txtPartOne_Even7_EditValueChanged(object sender, EventArgs e)
        {
            CheckTextBoxNullValue.SetColorDefaultTextControl(dxErrorProvider1,txtPartOne_Even7);
        }

        private void txtPartOne_Pear8_EditValueChanged(object sender, EventArgs e)
        {
            CheckTextBoxNullValue.SetColorDefaultTextControl(dxErrorProvider1,txtPartOne_Pear8);
        }

        private void txtPartOne_Even8_EditValueChanged(object sender, EventArgs e)
        {
            CheckTextBoxNullValue.SetColorDefaultTextControl(dxErrorProvider1,txtPartOne_Even8);
        }

        private void txtPartOne_Pear9_EditValueChanged(object sender, EventArgs e)
        {
            CheckTextBoxNullValue.SetColorDefaultTextControl(dxErrorProvider1,txtPartOne_Pear9);
        }

        private void txtPartOne_Even9_EditValueChanged(object sender, EventArgs e)
        {
            CheckTextBoxNullValue.SetColorDefaultTextControl(dxErrorProvider1,txtPartOne_Even9);
        }

        private void txtPartOne_Pear10_EditValueChanged(object sender, EventArgs e)
        {
            CheckTextBoxNullValue.SetColorDefaultTextControl(dxErrorProvider1,txtPartOne_Pear10);
        }

        private void txtPartOne_Even10_EditValueChanged(object sender, EventArgs e)
        {
            CheckTextBoxNullValue.SetColorDefaultTextControl(dxErrorProvider1,txtPartOne_Even10);
        }

        private void txtPartOne_Pear11_EditValueChanged(object sender, EventArgs e)
        {
            CheckTextBoxNullValue.SetColorDefaultTextControl(dxErrorProvider1,txtPartOne_Pear11);
        }

        private void txtPartOne_Even11_EditValueChanged(object sender, EventArgs e)
        {
            CheckTextBoxNullValue.SetColorDefaultTextControl(dxErrorProvider1,txtPartOne_Even11);
        }

        private void txtPartOne_Pear12_EditValueChanged(object sender, EventArgs e)
        {
            CheckTextBoxNullValue.SetColorDefaultTextControl(dxErrorProvider1,txtPartOne_Pear2);
        }

        private void txtPartOne_Even12_EditValueChanged(object sender, EventArgs e)
        {
            CheckTextBoxNullValue.SetColorDefaultTextControl(dxErrorProvider1,txtPartOne_Even12);
        }

        private void txtPartOne_Pear13_EditValueChanged(object sender, EventArgs e)
        {
            CheckTextBoxNullValue.SetColorDefaultTextControl(dxErrorProvider1,txtPartOne_Pear13);
        }

        private void txtPartOne_Even13_EditValueChanged(object sender, EventArgs e)
        {
            CheckTextBoxNullValue.SetColorDefaultTextControl(dxErrorProvider1,txtPartOne_Even13);
        }

        private void txtPartTwo_Pear1_EditValueChanged(object sender, EventArgs e)
        {
            CheckTextBoxNullValue.SetColorDefaultTextControl(dxErrorProvider1,txtPartTwo_Pear1);
        }

        private void txtPartTwo_Pear2_EditValueChanged(object sender, EventArgs e)
        {
            CheckTextBoxNullValue.SetColorDefaultTextControl(dxErrorProvider1,txtPartTwo_Pear2);
        }

        private void txtPartTwo_Even1_EditValueChanged(object sender, EventArgs e)
        {
            CheckTextBoxNullValue.SetColorDefaultTextControl(dxErrorProvider1,txtPartTwo_Even1);
        }

        private void txtPartTwo_Even2_EditValueChanged(object sender, EventArgs e)
        {
            CheckTextBoxNullValue.SetColorDefaultTextControl(dxErrorProvider1,txtPartTwo_Even2);
        }

        private void txtPartTwo_Pear3_EditValueChanged(object sender, EventArgs e)
        {
            CheckTextBoxNullValue.SetColorDefaultTextControl(dxErrorProvider1,txtPartTwo_Pear3);
        }

        private void txtPartTwo_Even3_EditValueChanged(object sender, EventArgs e)
        {
            CheckTextBoxNullValue.SetColorDefaultTextControl(dxErrorProvider1,txtPartTwo_Even3);
        }

        private void txtPartTwo_Pear4_EditValueChanged(object sender, EventArgs e)
        {
            CheckTextBoxNullValue.SetColorDefaultTextControl(dxErrorProvider1,txtPartTwo_Pear4);
        }

        private void txtPartTwo_Even4_EditValueChanged(object sender, EventArgs e)
        {
            CheckTextBoxNullValue.SetColorDefaultTextControl(dxErrorProvider1,txtPartTwo_Even4);
        }

        private void txtPartTwo_Pear5_EditValueChanged(object sender, EventArgs e)
        {
            CheckTextBoxNullValue.SetColorDefaultTextControl(dxErrorProvider1,txtPartTwo_Pear5);
        }

        private void txtPartTwo_Even5_EditValueChanged(object sender, EventArgs e)
        {
            CheckTextBoxNullValue.SetColorDefaultTextControl(dxErrorProvider1,txtPartTwo_Even5);
        }

        private void txtPartTwo_Pear6_EditValueChanged(object sender, EventArgs e)
        {
            CheckTextBoxNullValue.SetColorDefaultTextControl(dxErrorProvider1,txtPartTwo_Pear6);
        }

        private void txtPartTwo_Even6_EditValueChanged(object sender, EventArgs e)
        {
            CheckTextBoxNullValue.SetColorDefaultTextControl(dxErrorProvider1,txtPartTwo_Even6);
        }

        private void txtPartTwo_Pear7_EditValueChanged(object sender, EventArgs e)
        {
            CheckTextBoxNullValue.SetColorDefaultTextControl(dxErrorProvider1,txtPartTwo_Pear7);
        }

        private void txtPartTwo_Even7_EditValueChanged(object sender, EventArgs e)
        {
            CheckTextBoxNullValue.SetColorDefaultTextControl(dxErrorProvider1,txtPartTwo_Even7);
        }

        private void txtPartTwo_Pear8_EditValueChanged(object sender, EventArgs e)
        {
            CheckTextBoxNullValue.SetColorDefaultTextControl(dxErrorProvider1,txtPartTwo_Pear8);
        }

        private void txtPartTwo_Even8_EditValueChanged(object sender, EventArgs e)
        {
            CheckTextBoxNullValue.SetColorDefaultTextControl(dxErrorProvider1,txtPartTwo_Even8);
        }

        private void txtPartTwo_Pear9_EditValueChanged(object sender, EventArgs e)
        {
            CheckTextBoxNullValue.SetColorDefaultTextControl(dxErrorProvider1,txtPartTwo_Pear9);
        }

        private void txtPartTwo_Even9_EditValueChanged(object sender, EventArgs e)
        {
            CheckTextBoxNullValue.SetColorDefaultTextControl(dxErrorProvider1,txtPartTwo_Even9);
        }

        private void txtPartTwo_Pear10_EditValueChanged(object sender, EventArgs e)
        {
            CheckTextBoxNullValue.SetColorDefaultTextControl(dxErrorProvider1,txtPartTwo_Pear10);
        }

        private void textEdit20txtPartTwo_Even10_EditValueChanged(object sender, EventArgs e)
        {
            CheckTextBoxNullValue.SetColorDefaultTextControl(dxErrorProvider1,textEdit20txtPartTwo_Even10);
        }

        private void txtPartTwo_Pear11_EditValueChanged(object sender, EventArgs e)
        {
            CheckTextBoxNullValue.SetColorDefaultTextControl(dxErrorProvider1,txtPartTwo_Pear11);
        }

        private void txtPartTwo_Even11_EditValueChanged(object sender, EventArgs e)
        {
            CheckTextBoxNullValue.SetColorDefaultTextControl(dxErrorProvider1,txtPartTwo_Even11);
        }

        private void txtPartTwo_Pear12_EditValueChanged(object sender, EventArgs e)
        {
            CheckTextBoxNullValue.SetColorDefaultTextControl(dxErrorProvider1,txtPartTwo_Pear12);
        }

        private void txtPartTwo_Even12_EditValueChanged(object sender, EventArgs e)
        {
            CheckTextBoxNullValue.SetColorDefaultTextControl(dxErrorProvider1,txtPartTwo_Even12);
        }

        private void txtPartTwo_Pear13_EditValueChanged(object sender, EventArgs e)
        {
            CheckTextBoxNullValue.SetColorDefaultTextControl(dxErrorProvider1,txtPartTwo_Pear13);
        }

        private void txtPartTwo_Even13_EditValueChanged(object sender, EventArgs e)
        {
            CheckTextBoxNullValue.SetColorDefaultTextControl(dxErrorProvider1,txtPartTwo_Even13);
        }

        private void txtScorePicture_EditValueChanged(object sender, EventArgs e)
        {
            CheckTextBoxNullValue.SetColorDefaultTextControl(dxErrorProvider1,txtScorePicture);

        }

        private void txtScoreEye_EditValueChanged(object sender, EventArgs e)
        {
            CheckTextBoxNullValue.SetColorDefaultTextControl(dxErrorProvider1,txtScoreEye);
        }
        #endregion

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!CheckTextBoxNullValue.ValidationTextEditNullValue(txtFullName))
            {
                dxErrorProvider1.SetError(txtFullName, "Vui lòng nhập vào 'Họ và Tên' của ứng viên!");
            }
            else if (!CheckTextBoxNullValue.ValidationTextEditNullValue(txtBrithDay))
            {
                dxErrorProvider1.SetError(txtBrithDay, "Vui lòng nhập vào 'Ngày sinh' của ứng viên!");
            }
            // Điểm 1
            else if (!CheckTextBoxNullValue.ValidationTextEditNullValue(txtPartOne_Pear1))
            {
                dxErrorProvider1.SetError(txtPartOne_Pear1, "Vui lòng nhập vào điểm!");
            }
            else if (!CheckTextBoxNullValue.ValidationTextEditNullValue(txtPartOne_Even1))
            {
                dxErrorProvider1.SetError(txtPartOne_Even1, "Vui lòng nhập vào điểm!");
            }
            // Điểm 2
            else if (!CheckTextBoxNullValue.ValidationTextEditNullValue(txtPartOne_Pear2))
            {
                dxErrorProvider1.SetError(txtPartOne_Pear2, "Vui lòng nhập vào điểm!");
            }
            else if (!CheckTextBoxNullValue.ValidationTextEditNullValue(txtPartOne_Even2))
            {
                dxErrorProvider1.SetError(txtPartOne_Even2, "Vui lòng nhập vào điểm!");
            }
            // Điểm 3
            else if (!CheckTextBoxNullValue.ValidationTextEditNullValue(txtPartOne_Pear3))
            {
                dxErrorProvider1.SetError(txtPartOne_Pear3, "Vui lòng nhập vào điểm!");
            }
            else if (!CheckTextBoxNullValue.ValidationTextEditNullValue(txtPartOne_Even3))
            {
                dxErrorProvider1.SetError(txtPartOne_Even3, "Vui lòng nhập vào điểm!");
            }
            // Điểm 4
            else if (!CheckTextBoxNullValue.ValidationTextEditNullValue(txtPartOne_Pear4))
            {
                dxErrorProvider1.SetError(txtPartOne_Pear4, "Vui lòng nhập vào điểm!");
            }
            else if (!CheckTextBoxNullValue.ValidationTextEditNullValue(txtPartOne_Even4))
            {
                dxErrorProvider1.SetError(txtPartOne_Even4, "Vui lòng nhập vào điểm!");
            }
            // Điểm 5
            else if (!CheckTextBoxNullValue.ValidationTextEditNullValue(txtPartOne_Pear5))
            {
                dxErrorProvider1.SetError(txtPartOne_Pear5, "Vui lòng nhập vào điểm!");
            }
            else if (!CheckTextBoxNullValue.ValidationTextEditNullValue(txtPartOne_Even5))
            {
                dxErrorProvider1.SetError(txtPartOne_Even5, "Vui lòng nhập vào điểm!");
            }
            // Điểm 6
            else if (!CheckTextBoxNullValue.ValidationTextEditNullValue(txtPartOne_Pear6))
            {
                dxErrorProvider1.SetError(txtPartOne_Pear6, "Vui lòng nhập vào điểm!");
            }
            else if (!CheckTextBoxNullValue.ValidationTextEditNullValue(txtPartOne_Even6))
            {
                dxErrorProvider1.SetError(txtPartOne_Even6, "Vui lòng nhập vào điểm!");
            }
            // Điểm 7
            else if (!CheckTextBoxNullValue.ValidationTextEditNullValue(txtPartOne_Pear7))
            {
                dxErrorProvider1.SetError(txtPartOne_Pear7, "Vui lòng nhập vào điểm!");
            }
            else if (!CheckTextBoxNullValue.ValidationTextEditNullValue(txtPartOne_Even7))
            {
                dxErrorProvider1.SetError(txtPartOne_Even7, "Vui lòng nhập vào điểm!");
            }
            // Điểm 8
            else if (!CheckTextBoxNullValue.ValidationTextEditNullValue(txtPartOne_Pear8))
            {
                dxErrorProvider1.SetError(txtPartOne_Pear8, "Vui lòng nhập vào điểm!");
            }
            else if (!CheckTextBoxNullValue.ValidationTextEditNullValue(txtPartOne_Even8))
            {
                dxErrorProvider1.SetError(txtPartOne_Even8, "Vui lòng nhập vào điểm!");
            }
            // Điểm 9
            else if (!CheckTextBoxNullValue.ValidationTextEditNullValue(txtPartOne_Pear9))
            {
                dxErrorProvider1.SetError(txtPartOne_Pear9, "Vui lòng nhập vào điểm!");
            }
            else if (!CheckTextBoxNullValue.ValidationTextEditNullValue(txtPartOne_Even9))
            {
                dxErrorProvider1.SetError(txtPartOne_Even9, "Vui lòng nhập vào điểm!");
            }
            // Điểm 10
            else if (!CheckTextBoxNullValue.ValidationTextEditNullValue(txtPartOne_Pear10))
            {
                dxErrorProvider1.SetError(txtPartOne_Pear10, "Vui lòng nhập vào điểm!");
            }
            else if (!CheckTextBoxNullValue.ValidationTextEditNullValue(txtPartOne_Even10))
            {
                dxErrorProvider1.SetError(txtPartOne_Even10, "Vui lòng nhập vào điểm!");
            }
            // Điểm 11
            else if (!CheckTextBoxNullValue.ValidationTextEditNullValue(txtPartOne_Pear11))
            {
                dxErrorProvider1.SetError(txtPartOne_Pear11, "Vui lòng nhập vào điểm!");
            }
            else if (!CheckTextBoxNullValue.ValidationTextEditNullValue(txtPartOne_Even11))
            {
                dxErrorProvider1.SetError(txtPartOne_Even11, "Vui lòng nhập vào điểm!");
            }
            // Điểm 12
            else if (!CheckTextBoxNullValue.ValidationTextEditNullValue(txtPartOne_Pear12))
            {
                dxErrorProvider1.SetError(txtPartOne_Pear12, "Vui lòng nhập vào điểm!");
            }
            else if (!CheckTextBoxNullValue.ValidationTextEditNullValue(txtPartOne_Even12))
            {
                dxErrorProvider1.SetError(txtPartOne_Even12, "Vui lòng nhập vào điểm!");
            }
            // Điểm 13
            else if (!CheckTextBoxNullValue.ValidationTextEditNullValue(txtPartOne_Pear13))
            {
                dxErrorProvider1.SetError(txtPartOne_Pear13, "Vui lòng nhập vào điểm!");
            }
            else if (!CheckTextBoxNullValue.ValidationTextEditNullValue(txtPartOne_Even13))
            {
                dxErrorProvider1.SetError(txtPartOne_Even13, "Vui lòng nhập vào điểm!");
            }
            else if (!CheckTextBoxNullValue.ValidationTextEditNullValue(txtScorePicture))
            {
                dxErrorProvider1.SetError(txtScorePicture, "Vui lòng nhập vào điểm kiểm tra hình!");
            }
            else if (!CheckTextBoxNullValue.ValidationTextEditNullValue(txtScoreEye))
            {
                dxErrorProvider1.SetError(txtScoreEye, "Vui lòng nhập vào điểm kiểm tra mắt!");
            }
            else
            {
                try
                {
                    _scoreService.Update(
                        _id,
                        _dateCreated,
                        txtFullName.Text,
                        txtBrithDay.Text.Trim(),
                        Ultils.ConvertStringToInt(txtPartOne_Pear1),
                        Ultils.ConvertStringToInt(txtPartOne_Pear2),
                        Ultils.ConvertStringToInt(txtPartOne_Pear3),
                        Ultils.ConvertStringToInt(txtPartOne_Pear4),
                        Ultils.ConvertStringToInt(txtPartOne_Pear5),
                        Ultils.ConvertStringToInt(txtPartOne_Pear6),
                        Ultils.ConvertStringToInt(txtPartOne_Pear7),
                        Ultils.ConvertStringToInt(txtPartOne_Pear8),
                        Ultils.ConvertStringToInt(txtPartOne_Pear9),
                        Ultils.ConvertStringToInt(txtPartOne_Pear10),
                        Ultils.ConvertStringToInt(txtPartOne_Pear11),
                        Ultils.ConvertStringToInt(txtPartOne_Pear12),
                        Ultils.ConvertStringToInt(txtPartOne_Pear13),

                        Ultils.ConvertStringToInt(txtPartOne_Even1),
                        Ultils.ConvertStringToInt(txtPartOne_Even2),
                        Ultils.ConvertStringToInt(txtPartOne_Even3),
                        Ultils.ConvertStringToInt(txtPartOne_Even4),
                        Ultils.ConvertStringToInt(txtPartOne_Even5),
                        Ultils.ConvertStringToInt(txtPartOne_Even6),
                        Ultils.ConvertStringToInt(txtPartOne_Even7),
                        Ultils.ConvertStringToInt(txtPartOne_Even8),
                        Ultils.ConvertStringToInt(txtPartOne_Even9),
                        Ultils.ConvertStringToInt(txtPartOne_Even10),
                        Ultils.ConvertStringToInt(txtPartOne_Even11),
                        Ultils.ConvertStringToInt(txtPartOne_Even12),
                        Ultils.ConvertStringToInt(txtPartOne_Even13),

                        Ultils.ConvertStringToInt(txtPartTwo_Pear1),
                        Ultils.ConvertStringToInt(txtPartTwo_Pear2),
                        Ultils.ConvertStringToInt(txtPartTwo_Pear3),
                        Ultils.ConvertStringToInt(txtPartTwo_Pear4),
                        Ultils.ConvertStringToInt(txtPartTwo_Pear5),
                        Ultils.ConvertStringToInt(txtPartTwo_Pear6),
                        Ultils.ConvertStringToInt(txtPartTwo_Pear7),
                        Ultils.ConvertStringToInt(txtPartTwo_Pear8),
                        Ultils.ConvertStringToInt(txtPartTwo_Pear9),
                        Ultils.ConvertStringToInt(txtPartTwo_Pear10),
                        Ultils.ConvertStringToInt(txtPartTwo_Pear11),
                        Ultils.ConvertStringToInt(txtPartTwo_Pear12),
                        Ultils.ConvertStringToInt(txtPartTwo_Pear13),

                        Ultils.ConvertStringToInt(txtPartTwo_Even1),
                        Ultils.ConvertStringToInt(txtPartTwo_Even2),
                        Ultils.ConvertStringToInt(txtPartTwo_Even3),
                        Ultils.ConvertStringToInt(txtPartTwo_Even4),
                        Ultils.ConvertStringToInt(txtPartTwo_Even5),
                        Ultils.ConvertStringToInt(txtPartTwo_Even6),
                        Ultils.ConvertStringToInt(txtPartTwo_Even7),
                        Ultils.ConvertStringToInt(txtPartTwo_Even8),
                        Ultils.ConvertStringToInt(txtPartTwo_Even9),
                        Ultils.ConvertStringToInt(textEdit20txtPartTwo_Even10),
                        Ultils.ConvertStringToInt(txtPartTwo_Even11),
                        Ultils.ConvertStringToInt(txtPartTwo_Even12),
                        Ultils.ConvertStringToInt(txtPartTwo_Even13),

                        Ultils.ConvertStringToInt(txtPartOne_SumPear),
                        Ultils.ConvertStringToInt(txtPartOne_SumEven),
                        Ultils.ConvertStringToInt(txtPartTwo_SumPear),
                        Ultils.ConvertStringToInt(txtPartTwo_SumEven),
                        Ultils.ConvertStringToInt(txtTotalScorePear),
                        Ultils.ConvertStringToInt(txtTotalEven),
                        int.Parse(lblPercent.Text.Replace("%", "")),
                        int.Parse(lblDifference.Text),
                        lblKetQua.Text.Trim(),
                        Ultils.ConvertStringToInt(txtScorePicture),
                        int.Parse(lblPercentPicture.Text.Replace("%", "")),
                        lblKetQuaPicture.Text.Trim(),
                        Ultils.ConvertStringToInt(txtScoreEye),
                        lblScorEye.Text.Trim()
                        );
                    btnReset.PerformClick();
                    MessageBox.Show("Cập nhật thành công!", "THÔNG BÁO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

            }
        }
        private void btnReset_Click(object sender, EventArgs e)
        {
            txtFullName.ResetText();
            txtBrithDay.ResetText();
            txtPartOne_Pear1.ResetText();
            txtPartOne_Pear2.ResetText();
            txtPartOne_Pear3.ResetText();
            txtPartOne_Pear4.ResetText();
            txtPartOne_Pear5.ResetText();
            txtPartOne_Pear6.ResetText();
            txtPartOne_Pear7.ResetText();
            txtPartOne_Pear8.ResetText();
            txtPartOne_Pear9.ResetText();
            txtPartOne_Pear10.ResetText();
            txtPartOne_Pear11.ResetText();
            txtPartOne_Pear12.ResetText();
            txtPartOne_Pear13.ResetText();
            //Part Two
            txtPartTwo_Pear1.ResetText();
            txtPartTwo_Pear2.ResetText();
            txtPartTwo_Pear3.ResetText();
            txtPartTwo_Pear4.ResetText();
            txtPartTwo_Pear5.ResetText();
            txtPartTwo_Pear6.ResetText();
            txtPartTwo_Pear7.ResetText();
            txtPartTwo_Pear8.ResetText();
            txtPartTwo_Pear9.ResetText();
            txtPartTwo_Pear10.ResetText();
            txtPartTwo_Pear11.ResetText();
            txtPartTwo_Pear12.ResetText();
            txtPartTwo_Pear13.ResetText();

            txtPartOne_Even1.ResetText();
            txtPartOne_Even2.ResetText();
            txtPartOne_Even3.ResetText();
            txtPartOne_Even4.ResetText();
            txtPartOne_Even5.ResetText();
            txtPartOne_Even6.ResetText();
            txtPartOne_Even7.ResetText();
            txtPartOne_Even8.ResetText();
            txtPartOne_Even9.ResetText();
            txtPartOne_Even10.ResetText();
            txtPartOne_Even11.ResetText();
            txtPartOne_Even12.ResetText();
            txtPartOne_Even13.ResetText();

            //Part Two
            txtPartTwo_Even1.ResetText();
            txtPartTwo_Even2.ResetText();
            txtPartTwo_Even3.ResetText();
            txtPartTwo_Even4.ResetText();
            txtPartTwo_Even5.ResetText();
            txtPartTwo_Even6.ResetText();
            txtPartTwo_Even7.ResetText();
            txtPartTwo_Even8.ResetText();
            txtPartTwo_Even9.ResetText();
            textEdit20txtPartTwo_Even10.ResetText();
            txtPartTwo_Even11.ResetText();
            txtPartTwo_Even12.ResetText();
            txtPartTwo_Even13.ResetText();

            txtPartOne_SumPear.Text = "0";
            txtPartOne_SumEven.Text = "0";
            txtPartTwo_SumPear.Text = "0";
            txtPartTwo_SumEven.Text = "0";

            txtTotalScorePear.Text = "0";
            txtTotalEven.Text = "0";

            txtScorePicture.ResetText(); 
            txtScoreEye.ResetText();

            lblPercent.Text = $"0%";
            lblDifference.ResetText();
            lblKetQua.ResetText();

            lblPercentPicture.Text = $"0%";
            lblKetQuaPicture.ResetText();

            lblScorEye.ResetText();
        }
        #region TextBox Validating PartOne_Pear1
        private void txtPartOne_Pear1_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (CheckTextBoxNullValue.ValidationTextEditNullValue(txtPartOne_Pear1))
            {
                int pear = int.Parse(txtPartOne_Pear1.Text);
                if(pear > 100 || pear < 1)
                {
                    CheckTextBoxNullValue.SetColorErrorTextControl(txtPartOne_Pear1);
                    dxErrorProvider1.SetError(txtPartOne_Pear1, "Điểm phải lớn hoặc nhỏ hơn 100!");
                }
                else
                {
                    txtPartOne_SumPear.Text = _scoreService.SumArray(GetArrayPartOnePears()).ToString();
                    dxErrorProvider1.ClearErrors();
                }
            }
        }

        private void txtPartOne_Pear2_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (CheckTextBoxNullValue.ValidationTextEditNullValue(txtPartOne_Pear2))
            {
                int pear = int.Parse(txtPartOne_Pear2.Text);
                if (pear > 100 || pear < 1)
                {
                    CheckTextBoxNullValue.SetColorErrorTextControl(txtPartOne_Pear2);
                    dxErrorProvider1.SetError(txtPartOne_Pear2, "Điểm phải lớn hoặc nhỏ hơn 100!");
                }
                else
                {
                    txtPartOne_SumPear.Text = _scoreService.SumArray(GetArrayPartOnePears()).ToString();
                    dxErrorProvider1.ClearErrors();
                }
            }
            txtPartOne_SumPear.Text = _scoreService.SumArray(GetArrayPartOnePears()).ToString();
        }

        private void txtPartOne_Pear3_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            txtPartOne_SumPear.Text = _scoreService.SumArray(GetArrayPartOnePears()).ToString();
        }

        private void txtPartOne_Pear4_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            txtPartOne_SumPear.Text = _scoreService.SumArray(GetArrayPartOnePears()).ToString();
        }

        private void txtPartOne_Pear5_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            txtPartOne_SumPear.Text = _scoreService.SumArray(GetArrayPartOnePears()).ToString();
        }

        private void txtPartOne_Pear6_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            txtPartOne_SumPear.Text = _scoreService.SumArray(GetArrayPartOnePears()).ToString();
        }

        private void txtPartOne_Pear7_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            txtPartOne_SumPear.Text = _scoreService.SumArray(GetArrayPartOnePears()).ToString();
        }

        private void txtPartOne_Pear8_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            txtPartOne_SumPear.Text = _scoreService.SumArray(GetArrayPartOnePears()).ToString();
        }

        private void txtPartOne_Pear9_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            txtPartOne_SumPear.Text = _scoreService.SumArray(GetArrayPartOnePears()).ToString();
        }

        private void txtPartOne_Pear10_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            txtPartOne_SumPear.Text = _scoreService.SumArray(GetArrayPartOnePears()).ToString();
        }

        private void txtPartOne_Pear11_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            txtPartOne_SumPear.Text = _scoreService.SumArray(GetArrayPartOnePears()).ToString();
        }

        private void txtPartOne_Pear12_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            txtPartOne_SumPear.Text = _scoreService.SumArray(GetArrayPartOnePears()).ToString();
        }

        private void txtPartOne_Pear13_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            txtPartOne_SumPear.Text = _scoreService.SumArray(GetArrayPartOnePears()).ToString();
        }

        #endregion

        #region TextBox Validating PartOne_Even1
        private void txtPartOne_Even1_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            txtPartOne_SumEven.Text = _scoreService.SumArray(GetArrayPartOneEvens()).ToString();
        }

        private void txtPartOne_Even2_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            txtPartOne_SumEven.Text = _scoreService.SumArray(GetArrayPartOneEvens()).ToString();
        }

        private void txtPartOne_Even3_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            txtPartOne_SumEven.Text = _scoreService.SumArray(GetArrayPartOneEvens()).ToString();
        }

        private void txtPartOne_Even4_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            txtPartOne_SumEven.Text = _scoreService.SumArray(GetArrayPartOneEvens()).ToString();
        }

        private void txtPartOne_Even5_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            txtPartOne_SumEven.Text = _scoreService.SumArray(GetArrayPartOneEvens()).ToString();
        }

        private void txtPartOne_Even6_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            txtPartOne_SumEven.Text = _scoreService.SumArray(GetArrayPartOneEvens()).ToString();
        }

        private void txtPartOne_Even7_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            txtPartOne_SumEven.Text = _scoreService.SumArray(GetArrayPartOneEvens()).ToString();
        }

        private void txtPartOne_Even8_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            txtPartOne_SumEven.Text = _scoreService.SumArray(GetArrayPartOneEvens()).ToString();
        }

        private void txtPartOne_Even9_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            txtPartOne_SumEven.Text = _scoreService.SumArray(GetArrayPartOneEvens()).ToString();
        }

        private void txtPartOne_Even10_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            txtPartOne_SumEven.Text = _scoreService.SumArray(GetArrayPartOneEvens()).ToString();
        }

        private void txtPartOne_Even11_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            txtPartOne_SumEven.Text = _scoreService.SumArray(GetArrayPartOneEvens()).ToString();
        }

        private void txtPartOne_Even12_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            txtPartOne_SumEven.Text = _scoreService.SumArray(GetArrayPartOneEvens()).ToString();
        }

        private void txtPartOne_Even13_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            txtPartOne_SumEven.Text = _scoreService.SumArray(GetArrayPartOneEvens()).ToString();
        }
        #endregion

        #region TextBox Validating PartTwo_Pear
        private void txtPartTwo_Pear1_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            txtPartTwo_SumPear.Text = _scoreService.SumArray(GetArrayPartTwoPears()).ToString();
        }

        private void txtPartTwo_Pear2_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            txtPartTwo_SumPear.Text = _scoreService.SumArray(GetArrayPartTwoPears()).ToString();
        }

        private void txtPartTwo_Pear3_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            txtPartTwo_SumPear.Text = _scoreService.SumArray(GetArrayPartTwoPears()).ToString();
        }

        private void txtPartTwo_Pear4_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            txtPartTwo_SumPear.Text = _scoreService.SumArray(GetArrayPartTwoPears()).ToString();
        }

        private void txtPartTwo_Pear5_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            txtPartTwo_SumPear.Text = _scoreService.SumArray(GetArrayPartTwoPears()).ToString();
        }

        private void txtPartTwo_Pear6_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            txtPartTwo_SumPear.Text = _scoreService.SumArray(GetArrayPartTwoPears()).ToString();
        }

        private void txtPartTwo_Pear7_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            txtPartTwo_SumPear.Text = _scoreService.SumArray(GetArrayPartTwoPears()).ToString();
        }

        private void txtPartTwo_Pear8_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            txtPartTwo_SumPear.Text = _scoreService.SumArray(GetArrayPartTwoPears()).ToString();
        }

        private void txtPartTwo_Pear9_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            txtPartTwo_SumPear.Text = _scoreService.SumArray(GetArrayPartTwoPears()).ToString();
        }

        private void txtPartTwo_Pear10_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            txtPartTwo_SumPear.Text = _scoreService.SumArray(GetArrayPartTwoPears()).ToString();
        }

        private void txtPartTwo_Pear11_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            txtPartTwo_SumPear.Text = _scoreService.SumArray(GetArrayPartTwoPears()).ToString();
        }

        private void txtPartTwo_Pear12_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            txtPartTwo_SumPear.Text = _scoreService.SumArray(GetArrayPartTwoPears()).ToString();
        }

        private void txtPartTwo_Pear13_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            txtPartTwo_SumPear.Text = _scoreService.SumArray(GetArrayPartTwoPears()).ToString();
        }
        #endregion

        #region TextBox Validating PartTwo_Even
        private void txtPartTwo_Even1_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            txtPartTwo_SumEven.Text = _scoreService.SumArray(GetArrayPartTwoEvens()).ToString();
        }

        private void txtPartTwo_Even2_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            txtPartTwo_SumEven.Text = _scoreService.SumArray(GetArrayPartTwoEvens()).ToString();
        }

        private void txtPartTwo_Even3_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            txtPartTwo_SumEven.Text = _scoreService.SumArray(GetArrayPartTwoEvens()).ToString();
        }

        private void txtPartTwo_Even4_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            txtPartTwo_SumEven.Text = _scoreService.SumArray(GetArrayPartTwoEvens()).ToString();
        }

        private void txtPartTwo_Even5_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            txtPartTwo_SumEven.Text = _scoreService.SumArray(GetArrayPartTwoEvens()).ToString();
        }

        private void txtPartTwo_Even6_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            txtPartTwo_SumEven.Text = _scoreService.SumArray(GetArrayPartTwoEvens()).ToString();
        }

        private void txtPartTwo_Even7_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            txtPartTwo_SumEven.Text = _scoreService.SumArray(GetArrayPartTwoEvens()).ToString();
        }

        private void txtPartTwo_Even8_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            txtPartTwo_SumEven.Text = _scoreService.SumArray(GetArrayPartTwoEvens()).ToString();
        }

        private void txtPartTwo_Even9_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            txtPartTwo_SumEven.Text = _scoreService.SumArray(GetArrayPartTwoEvens()).ToString();
        }

        private void textEdit20txtPartTwo_Even10_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            txtPartTwo_SumEven.Text = _scoreService.SumArray(GetArrayPartTwoEvens()).ToString();
        }

        private void txtPartTwo_Even11_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            txtPartTwo_SumEven.Text = _scoreService.SumArray(GetArrayPartTwoEvens()).ToString();
        }

        private void txtPartTwo_Even12_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            txtPartTwo_SumEven.Text = _scoreService.SumArray(GetArrayPartTwoEvens()).ToString();
        }

        private void txtPartTwo_Even13_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            txtPartTwo_SumEven.Text = _scoreService.SumArray(GetArrayPartTwoEvens()).ToString();
        }

        #endregion

        #region Total
        private void txtPartOne_SumPear_EditValueChanged(object sender, EventArgs e)
        {
            txtTotalScorePear.Text = _scoreService.SumArray(GetArraySumPears()).ToString();
        }

        private void txtPartTwo_SumPear_EditValueChanged(object sender, EventArgs e)
        {
            txtTotalScorePear.Text = _scoreService.SumArray(GetArraySumPears()).ToString();
        }

        private void txtPartOne_SumEven_EditValueChanged(object sender, EventArgs e)
        {
            txtTotalEven.Text = _scoreService.SumArray(GetArraySumEven()).ToString();
        }

        private void txtPartTwo_SumEven_EditValueChanged(object sender, EventArgs e)
        {
            txtTotalEven.Text = _scoreService.SumArray(GetArraySumEven()).ToString();
        }
        #endregion

        private void txtTotalScorePear_EditValueChanged(object sender, EventArgs e)
        {
            float percent = _scoreService.PercentParts(txtTotalScorePear.Text, txtTotalEven.Text);
            lblPercent.Text = $"{percent}%";
            if (percent >= 97)
            {
                CheckTextBoxNullValue.SetBackColorSuccessMessage(lblKetQua, "OK");
            }
            else if (percent < 97)
            {
                CheckTextBoxNullValue.SetBackColorErrorMessage(lblKetQua, "NG");
            }

            lblDifference.Text = _scoreService.DifferenceArray(GetArrayEvenAllParts()).ToString();
        }

        private void txtTotalEven_EditValueChanged(object sender, EventArgs e)
        {
            float percent = _scoreService.PercentParts(txtTotalScorePear.Text, txtTotalEven.Text);
            lblPercent.Text = $"{percent}%";
            if (percent >= 97)
            {
                CheckTextBoxNullValue.SetBackColorSuccessMessage(lblKetQua, "OK");
            }
            else if(percent < 97)
            {
                CheckTextBoxNullValue.SetBackColorErrorMessage(lblKetQua, "NG");
            }

            lblDifference.Text = _scoreService.DifferenceArray(GetArrayEvenAllParts()).ToString();
        }

        private void txtScorePicture_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            int value = 0;
            if(!int.TryParse(txtScorePicture.Text, out value))
            {
                value = 0;
            }
            if(value > 7 || value < 1)
            {
                dxErrorProvider1.SetError(txtScorePicture, "Điểm bài hình không được lớn hơn 7 hoặc nhỏ hơn 1!");
                CheckTextBoxNullValue.SetColorErrorTextControl(txtScorePicture);
            }
            else
            {
                float percent = _scoreService.PercentParts(lblScoreMaxPicture.Text.Substring(1), txtScorePicture.Text);
                lblPercentPicture.Text = $"{percent}%";
                if (percent >= 40)
                {
                    CheckTextBoxNullValue.SetBackColorSuccessMessage(lblKetQuaPicture, "OK");
                }
                else if(percent < 40)
                {
                    CheckTextBoxNullValue.SetBackColorErrorMessage(lblKetQuaPicture, "NG");
                }
            }
        }

        private void txtScoreEye_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            double value = 0;
            if(!double.TryParse(txtScoreEye.Text, out value))
            {
                value = 0;
            }
            if(value > 2 || value < 0.1)
            {
                dxErrorProvider1.SetError(txtScoreEye, "Không được lớn hơn 2, hoặc nhỏ hơn 0.1");
                CheckTextBoxNullValue.SetColorErrorTextControl(txtScoreEye);
            }
            else
            {
                if(value == 0.9)
                {
                    lblScorEye.Text = "0.33";
                }
                else if(value == 1)
                {
                    lblScorEye.Text = "0.30";
                }
                else if (value == 1.5)
                {
                    lblScorEye.Text = "0.20";
                }
                else if (value == 1.2)
                {
                    lblScorEye.Text = "0.25";
                }
                else if( value > 3)
                {
                    CheckTextBoxNullValue.SetBackColorErrorMessage(lblScorEye, "NG");
                }
                else
                {
                    dxErrorProvider1.SetError(txtScoreEye, "Không được lớn hơn 2, hoặc nhỏ hơn 0.1");
                    CheckTextBoxNullValue.SetColorErrorTextControl(txtScoreEye);
                }
            }
        }

        private void FormEditScore_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{TAB}");
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
        }

        private void txtBrithDay_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (!CheckTextBoxNullValue.ValidationTextEditNullValue(txtBrithDay))
            {
                CheckTextBoxNullValue.ShowError(dxErrorProvider1, txtBrithDay, toolTipController1, "Vui lòng nhập vào 'Ngày sinh' cho ứng viên!");
            }
            else
            {
                string age = _resultService.GetAge(txtBrithDay.Text);
                if (int.Parse(age) <= 0 || int.Parse(age) > 150)
                {
                    CheckTextBoxNullValue.ShowError(dxErrorProvider1, txtBrithDay, toolTipController1, $"'Ngày sinh' không hợp lệ. Vui lòng kiểm tra lại!");
                }
                else if (int.Parse(age) < 18)
                {
                    CheckTextBoxNullValue.ShowError(dxErrorProvider1, txtBrithDay, toolTipController1, $"Ứng viên '{txtFullName.Text}' tuổi: '{age}' chưa đủ độ tuổi lao động. Vui lòng kiểm tra lại!");
                }
                else if (int.Parse(age) > 60)
                {
                    CheckTextBoxNullValue.ShowError(dxErrorProvider1, txtBrithDay, toolTipController1, $"Ứng viên '{txtFullName.Text}' tuổi: '{age}' đã quá độ tuổi lao động. Vui lòng kiểm tra lại!");
                }
            }
        }

        private void txtFullName_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (!CheckTextBoxNullValue.ValidationTextEditNullValue(txtFullName))
            {
                CheckTextBoxNullValue.ShowError(dxErrorProvider1, txtFullName, toolTipController1, "Vui lòng nhập vào 'Họ và Tên' cho ứng viên!");
            }
            else
            {
                txtFullName.Text = Ultils.ConvertToTitleCase(txtFullName.Text);
            }
        }
    }
}
