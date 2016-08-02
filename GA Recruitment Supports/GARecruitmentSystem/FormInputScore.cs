using Lib.Forms.Helpers;
using Lib.Services;
using System;
using System.Windows.Forms;

namespace GARecruitmentSystem
{
    public partial class FormInputScore : Form
    {
        private ScoreService _scoreService;

        public FormInputScore()
        {
            InitializeComponent();
            _scoreService = new ScoreService();
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
            CheckTextBoxNullValue.SetColorDefaultTextControl(txtFullName);
            dxErrorProvider1.ClearErrors();
        }

        private void txtBrithDay_EditValueChanged(object sender, EventArgs e)
        {
            CheckTextBoxNullValue.SetColorDefaultTextControl(txtBrithDay);
            dxErrorProvider1.ClearErrors();
        }

        private void txtPartOne_Pear1_EditValueChanged(object sender, EventArgs e)
        {
            CheckTextBoxNullValue.SetColorDefaultTextControl(txtPartOne_Pear1);
            dxErrorProvider1.ClearErrors();
        }

        private void txtPartOne_Even1_EditValueChanged(object sender, EventArgs e)
        {
            CheckTextBoxNullValue.SetColorDefaultTextControl(txtPartOne_Even1);
            dxErrorProvider1.ClearErrors();
        }

        private void txtPartOne_Pear2_EditValueChanged(object sender, EventArgs e)
        {
            CheckTextBoxNullValue.SetColorDefaultTextControl(txtPartOne_Pear2);
            dxErrorProvider1.ClearErrors();
        }

        private void txtPartOne_Even2_EditValueChanged(object sender, EventArgs e)
        {
            CheckTextBoxNullValue.SetColorDefaultTextControl(txtPartOne_Even2);
            dxErrorProvider1.ClearErrors();
        }

        private void txtPartOne_Pear3_EditValueChanged(object sender, EventArgs e)
        {
            CheckTextBoxNullValue.SetColorDefaultTextControl(txtPartOne_Pear3);
            dxErrorProvider1.ClearErrors();
        }

        private void txtPartOne_Even3_EditValueChanged(object sender, EventArgs e)
        {
            CheckTextBoxNullValue.SetColorDefaultTextControl(txtPartOne_Even3);
            dxErrorProvider1.ClearErrors();
        }

        private void txtPartOne_Pear4_EditValueChanged(object sender, EventArgs e)
        {
            CheckTextBoxNullValue.SetColorDefaultTextControl(txtPartOne_Pear4);
            dxErrorProvider1.ClearErrors();
        }

        private void txtPartOne_Even4_EditValueChanged(object sender, EventArgs e)
        {
            CheckTextBoxNullValue.SetColorDefaultTextControl(txtPartOne_Even4);
            dxErrorProvider1.ClearErrors();
        }

        private void txtPartOne_Pear5_EditValueChanged(object sender, EventArgs e)
        {
            CheckTextBoxNullValue.SetColorDefaultTextControl(txtPartOne_Pear5);
            dxErrorProvider1.ClearErrors();
        }

        private void txtPartOne_Even5_EditValueChanged(object sender, EventArgs e)
        {
            CheckTextBoxNullValue.SetColorDefaultTextControl(txtPartOne_Even5);
            dxErrorProvider1.ClearErrors();
        }

        private void txtPartOne_Pear6_EditValueChanged(object sender, EventArgs e)
        {
            CheckTextBoxNullValue.SetColorDefaultTextControl(txtPartOne_Pear6);
            dxErrorProvider1.ClearErrors();
        }

        private void txtPartOne_Even6_EditValueChanged(object sender, EventArgs e)
        {
            CheckTextBoxNullValue.SetColorDefaultTextControl(txtPartOne_Even6);
            dxErrorProvider1.ClearErrors();
        }

        private void txtPartOne_Pear7_EditValueChanged(object sender, EventArgs e)
        {
            CheckTextBoxNullValue.SetColorDefaultTextControl(txtPartOne_Pear7);
            dxErrorProvider1.ClearErrors();
        }

        private void txtPartOne_Even7_EditValueChanged(object sender, EventArgs e)
        {
            CheckTextBoxNullValue.SetColorDefaultTextControl(txtPartOne_Even7);
            dxErrorProvider1.ClearErrors();
        }

        private void txtPartOne_Pear8_EditValueChanged(object sender, EventArgs e)
        {
            CheckTextBoxNullValue.SetColorDefaultTextControl(txtPartOne_Pear8);
            dxErrorProvider1.ClearErrors();
        }

        private void txtPartOne_Even8_EditValueChanged(object sender, EventArgs e)
        {
            CheckTextBoxNullValue.SetColorDefaultTextControl(txtPartOne_Even8);
            dxErrorProvider1.ClearErrors();
        }

        private void txtPartOne_Pear9_EditValueChanged(object sender, EventArgs e)
        {
            CheckTextBoxNullValue.SetColorDefaultTextControl(txtPartOne_Pear9);
            dxErrorProvider1.ClearErrors();
        }

        private void txtPartOne_Even9_EditValueChanged(object sender, EventArgs e)
        {
            CheckTextBoxNullValue.SetColorDefaultTextControl(txtPartOne_Even9);
            dxErrorProvider1.ClearErrors();
        }

        private void txtPartOne_Pear10_EditValueChanged(object sender, EventArgs e)
        {
            CheckTextBoxNullValue.SetColorDefaultTextControl(txtPartOne_Pear10);
            dxErrorProvider1.ClearErrors();
        }

        private void txtPartOne_Even10_EditValueChanged(object sender, EventArgs e)
        {
            CheckTextBoxNullValue.SetColorDefaultTextControl(txtPartOne_Even10);
            dxErrorProvider1.ClearErrors();
        }

        private void txtPartOne_Pear11_EditValueChanged(object sender, EventArgs e)
        {
            CheckTextBoxNullValue.SetColorDefaultTextControl(txtPartOne_Pear11);
            dxErrorProvider1.ClearErrors();
        }

        private void txtPartOne_Even11_EditValueChanged(object sender, EventArgs e)
        {
            CheckTextBoxNullValue.SetColorDefaultTextControl(txtPartOne_Even11);
            dxErrorProvider1.ClearErrors();
        }

        private void txtPartOne_Pear12_EditValueChanged(object sender, EventArgs e)
        {
            CheckTextBoxNullValue.SetColorDefaultTextControl(txtPartOne_Pear2);
            dxErrorProvider1.ClearErrors();
        }

        private void txtPartOne_Even12_EditValueChanged(object sender, EventArgs e)
        {
            CheckTextBoxNullValue.SetColorDefaultTextControl(txtPartOne_Even12);
            dxErrorProvider1.ClearErrors();
        }

        private void txtPartOne_Pear13_EditValueChanged(object sender, EventArgs e)
        {
            CheckTextBoxNullValue.SetColorDefaultTextControl(txtPartOne_Pear13);
            dxErrorProvider1.ClearErrors();
        }

        private void txtPartOne_Even13_EditValueChanged(object sender, EventArgs e)
        {
            CheckTextBoxNullValue.SetColorDefaultTextControl(txtPartOne_Even13);
            dxErrorProvider1.ClearErrors();
        }

        private void txtPartTwo_Pear1_EditValueChanged(object sender, EventArgs e)
        {
            CheckTextBoxNullValue.SetColorDefaultTextControl(txtPartTwo_Pear1);
            dxErrorProvider1.ClearErrors();
        }

        private void txtPartTwo_Pear2_EditValueChanged(object sender, EventArgs e)
        {
            CheckTextBoxNullValue.SetColorDefaultTextControl(txtPartTwo_Pear2);
            dxErrorProvider1.ClearErrors();
        }

        private void txtPartTwo_Even1_EditValueChanged(object sender, EventArgs e)
        {
            CheckTextBoxNullValue.SetColorDefaultTextControl(txtPartTwo_Even1);
            dxErrorProvider1.ClearErrors();
        }

        private void txtPartTwo_Even2_EditValueChanged(object sender, EventArgs e)
        {
            CheckTextBoxNullValue.SetColorDefaultTextControl(txtPartTwo_Even2);
            dxErrorProvider1.ClearErrors();
        }

        private void txtPartTwo_Pear3_EditValueChanged(object sender, EventArgs e)
        {
            CheckTextBoxNullValue.SetColorDefaultTextControl(txtPartTwo_Pear3);
            dxErrorProvider1.ClearErrors();
        }

        private void txtPartTwo_Even3_EditValueChanged(object sender, EventArgs e)
        {
            CheckTextBoxNullValue.SetColorDefaultTextControl(txtPartTwo_Even3);
            dxErrorProvider1.ClearErrors();
        }

        private void txtPartTwo_Pear4_EditValueChanged(object sender, EventArgs e)
        {
            CheckTextBoxNullValue.SetColorDefaultTextControl(txtPartTwo_Pear4);
            dxErrorProvider1.ClearErrors();
        }

        private void txtPartTwo_Even4_EditValueChanged(object sender, EventArgs e)
        {
            CheckTextBoxNullValue.SetColorDefaultTextControl(txtPartTwo_Even4);
            dxErrorProvider1.ClearErrors();
        }

        private void txtPartTwo_Pear5_EditValueChanged(object sender, EventArgs e)
        {
            CheckTextBoxNullValue.SetColorDefaultTextControl(txtPartTwo_Pear5);
            dxErrorProvider1.ClearErrors();
        }

        private void txtPartTwo_Even5_EditValueChanged(object sender, EventArgs e)
        {
            CheckTextBoxNullValue.SetColorDefaultTextControl(txtPartTwo_Even5);
            dxErrorProvider1.ClearErrors();
        }

        private void txtPartTwo_Pear6_EditValueChanged(object sender, EventArgs e)
        {
            CheckTextBoxNullValue.SetColorDefaultTextControl(txtPartTwo_Pear6);
            dxErrorProvider1.ClearErrors();
        }

        private void txtPartTwo_Even6_EditValueChanged(object sender, EventArgs e)
        {
            CheckTextBoxNullValue.SetColorDefaultTextControl(txtPartTwo_Even6);
            dxErrorProvider1.ClearErrors();
        }

        private void txtPartTwo_Pear7_EditValueChanged(object sender, EventArgs e)
        {
            CheckTextBoxNullValue.SetColorDefaultTextControl(txtPartTwo_Pear7);
            dxErrorProvider1.ClearErrors();
        }

        private void txtPartTwo_Even7_EditValueChanged(object sender, EventArgs e)
        {
            CheckTextBoxNullValue.SetColorDefaultTextControl(txtPartTwo_Even7);
            dxErrorProvider1.ClearErrors();
        }

        private void txtPartTwo_Pear8_EditValueChanged(object sender, EventArgs e)
        {
            CheckTextBoxNullValue.SetColorDefaultTextControl(txtPartTwo_Pear8);
            dxErrorProvider1.ClearErrors();
        }

        private void txtPartTwo_Even8_EditValueChanged(object sender, EventArgs e)
        {
            CheckTextBoxNullValue.SetColorDefaultTextControl(txtPartTwo_Even8);
            dxErrorProvider1.ClearErrors();
        }

        private void txtPartTwo_Pear9_EditValueChanged(object sender, EventArgs e)
        {
            CheckTextBoxNullValue.SetColorDefaultTextControl(txtPartTwo_Pear9);
            dxErrorProvider1.ClearErrors();
        }

        private void txtPartTwo_Even9_EditValueChanged(object sender, EventArgs e)
        {
            CheckTextBoxNullValue.SetColorDefaultTextControl(txtPartTwo_Even9);
            dxErrorProvider1.ClearErrors();
        }

        private void txtPartTwo_Pear10_EditValueChanged(object sender, EventArgs e)
        {
            CheckTextBoxNullValue.SetColorDefaultTextControl(txtPartTwo_Pear10);
            dxErrorProvider1.ClearErrors();
        }

        private void textEdit20txtPartTwo_Even10_EditValueChanged(object sender, EventArgs e)
        {
            CheckTextBoxNullValue.SetColorDefaultTextControl(textEdit20txtPartTwo_Even10);
            dxErrorProvider1.ClearErrors();
        }

        private void txtPartTwo_Pear11_EditValueChanged(object sender, EventArgs e)
        {
            CheckTextBoxNullValue.SetColorDefaultTextControl(txtPartTwo_Pear11);
            dxErrorProvider1.ClearErrors();
        }

        private void txtPartTwo_Even11_EditValueChanged(object sender, EventArgs e)
        {
            CheckTextBoxNullValue.SetColorDefaultTextControl(txtPartTwo_Even11);
            dxErrorProvider1.ClearErrors();
        }

        private void txtPartTwo_Pear12_EditValueChanged(object sender, EventArgs e)
        {
            CheckTextBoxNullValue.SetColorDefaultTextControl(txtPartTwo_Pear12);
            dxErrorProvider1.ClearErrors();
        }

        private void txtPartTwo_Even12_EditValueChanged(object sender, EventArgs e)
        {
            CheckTextBoxNullValue.SetColorDefaultTextControl(txtPartTwo_Even12);
            dxErrorProvider1.ClearErrors();
        }

        private void txtPartTwo_Pear13_EditValueChanged(object sender, EventArgs e)
        {
            CheckTextBoxNullValue.SetColorDefaultTextControl(txtPartTwo_Pear13);
            dxErrorProvider1.ClearErrors();
        }

        private void txtPartTwo_Even13_EditValueChanged(object sender, EventArgs e)
        {
            CheckTextBoxNullValue.SetColorDefaultTextControl(txtPartTwo_Even13);
            dxErrorProvider1.ClearErrors();
        }

        private void txtScorePicture_EditValueChanged(object sender, EventArgs e)
        {
            CheckTextBoxNullValue.SetColorDefaultTextControl(txtScorePicture);
            dxErrorProvider1.ClearErrors();
        }

        private void txtScoreEye_EditValueChanged(object sender, EventArgs e)
        {
            CheckTextBoxNullValue.SetColorDefaultTextControl(txtScoreEye);
            dxErrorProvider1.ClearErrors();
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


            }
        }
        private void btnReset_Click(object sender, EventArgs e)
        {

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
                lblKetQua.Text = "OK";
            }
            else
            {
                lblKetQua.Text = "NG";
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
            else
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
                else
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
    }
}
