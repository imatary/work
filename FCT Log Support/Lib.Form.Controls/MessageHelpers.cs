using DevExpress.XtraEditors;
using System.Drawing;
using System;

namespace Lib.Form.Controls
{
    public static class MessageHelpers
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="visible"></param>
        /// <param name="status"></param>
        /// <param name="messageInfo"></param>
        /// <param name="lblStatus"></param>
        /// <param name="lblMessage"></param>
        public static void SetDefaultStatus(bool visible, string status, string messageInfo, LabelControl lblStatus, LabelControl lblMessage)
        {
            lblStatus.Visible = visible;
            lblMessage.Visible = visible;

            lblStatus.Appearance.ForeColor = Color.DarkOrange;
            lblStatus.Appearance.BackColor = Color.DarkGray;

            lblMessage.Appearance.ForeColor = Color.DarkOrange;
            lblMessage.Appearance.BackColor = Color.DarkGray;

            lblStatus.Text = status;
            lblMessage.Text = messageInfo;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="visible"></param>
        /// <param name="status"></param>
        /// <param name="messageInfo"></param>
        /// <param name="lblStatus"></param>
        /// <param name="lblMessage"></param>
        public static void SetErrorStatus(bool visible, string status, string messageInfo, LabelControl lblStatus, LabelControl lblMessage)
        {
            lblStatus.Visible = visible;
            lblMessage.Visible = visible;

            lblStatus.Appearance.ForeColor = Color.Yellow;
            lblStatus.Appearance.BackColor = Color.DarkRed;

            lblMessage.Appearance.ForeColor = Color.White;
            lblMessage.Appearance.BackColor = Color.DarkRed;

            lblStatus.Text = status;
            lblMessage.Text = messageInfo;
        }

        /// <summary>
        /// Success
        /// </summary>
        /// <param name="visible"></param>
        /// <param name="status"></param>
        /// <param name="messageInfo"></param>
        public static void SetSuccessStatus(bool visible, string status, string messageInfo, LabelControl lblStatus, LabelControl lblMessage)
        {
            lblStatus.Visible = visible;
            lblMessage.Visible = visible;

            lblStatus.Appearance.ForeColor = Color.Yellow;
            lblStatus.Appearance.BackColor = Color.DarkGreen;

            lblMessage.Appearance.ForeColor = Color.DarkOrange;
            lblMessage.Appearance.BackColor = Color.DarkGreen;

            lblStatus.Text = status;
            lblMessage.Text = messageInfo;
        }
    }
}
