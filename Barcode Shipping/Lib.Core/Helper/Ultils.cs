using System.Windows.Forms;
using DevExpress.XtraEditors;
using System;
using System.Net;
using System.Net.Sockets;
using Microsoft.Win32;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
namespace Lib.Core.Helper
{
    public class Ultils
    {
        public static void TextControlNotNull(TextEdit textEdit, string title)
        {
            textEdit.Properties.Appearance.BorderColor = System.Drawing.Color.Red; 
            MessageBox.Show(string.Format("{0} không được để trống!", title), Resource.MessageBoxErrorMessageTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
            textEdit.Focus();
            textEdit.SelectAll();
        }

        public static void EditTextErrorMessage(TextEdit textEdit, string title)
        {
            textEdit.Properties.Appearance.BorderColor = System.Drawing.Color.Red;
            MessageBox.Show(string.Format("Error!\n{0}", title), Resource.MessageBoxErrorMessageTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
            textEdit.Focus();
            textEdit.SelectAll();
        }

        public static void GridLookUpEditControlNotNull(GridLookUpEdit gridLookUpEdit, string title)
        {
            gridLookUpEdit.Properties.Appearance.BorderColor = System.Drawing.Color.Red;
            gridLookUpEdit.Focus();
            gridLookUpEdit.SelectAll();
            MessageBox.Show(string.Format("Vui lòng chọn {0}!", title), Resource.MessageBoxErrorMessageTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }


        public static void GridLookUpEditControlNoExits(GridLookUpEdit gridLookUpEdit, string title)
        {
            gridLookUpEdit.Properties.Appearance.BorderColor = System.Drawing.Color.Red;
            gridLookUpEdit.Focus();
            MessageBox.Show(string.Format("Error!\n{0}!", title), Resource.MessageBoxErrorMessageTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        public static void GridLookUpEditNoMessage(GridLookUpEdit gridLookUpEdit)
        {
            gridLookUpEdit.Properties.Appearance.BorderColor = System.Drawing.Color.Red;
            gridLookUpEdit.Focus();
        }
        public static void EditTextErrorNoMessage(TextEdit textEdit)
        {
            textEdit.Properties.Appearance.BorderColor = System.Drawing.Color.Red;
            textEdit.Focus();
            textEdit.SelectAll();
        }

        public static void SetColorErrorTextControl(TextEdit textEdit, string title)
        {
            textEdit.Properties.Appearance.BorderColor = System.Drawing.Color.Red;
            textEdit.Focus();
            textEdit.SelectAll();
            MessageBox.Show(title, Resource.MessageBoxErrorMessageTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public static void SetColorDefaultTextControl(TextEdit textEdit)
        {
            textEdit.Properties.Appearance.BorderColor = System.Drawing.Color.LightGray;
        }
        public static void SetColorDefaultGridLookUpEdit(GridLookUpEdit gridLookUp)
        {
            gridLookUp.Properties.Appearance.BorderColor = System.Drawing.Color.LightGray;
        }


        /// <summary>
        /// Lấy thông tin ngày giờ từ server
        /// </summary>
        /// <returns></returns>
        public static DateTime GetNetworkDateTime()
        {
            //default Windows time server
            //const string ntpServer = "time.windows.com"; //Internet
            const string ntpServer = "172.28.64.8";

            // NTP message size - 16 bytes of the digest (RFC 2030)
            var ntpData = new byte[48];

            //Setting the Leap Indicator, Version Number and Mode values
            ntpData[0] = 0x1B; //LI = 0 (no warning), VN = 3 (IPv4 only), Mode = 3 (Client Mode)

            var addresses = Dns.GetHostEntry(ntpServer).AddressList;

            //The UDP port number assigned to NTP is 123
            var ipEndPoint = new IPEndPoint(addresses[0], 123);
            //NTP uses UDP
            var socket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);

            socket.Connect(ipEndPoint);

            //Stops code hang if NTP is blocked
            socket.ReceiveTimeout = 3000;

            socket.Send(ntpData);
            socket.Receive(ntpData);
            socket.Close();

            //Offset to get to the "Transmit Timestamp" field (time at which the reply 
            //departed the server for the client, in 64-bit timestamp format."
            const byte serverReplyTime = 40;

            //Get the seconds part
            ulong intPart = BitConverter.ToUInt32(ntpData, serverReplyTime);

            //Get the seconds fraction
            ulong fractPart = BitConverter.ToUInt32(ntpData, serverReplyTime + 4);

            //Convert From big-endian to little-endian
            intPart = SwapEndianness(intPart);
            fractPart = SwapEndianness(fractPart);

            var milliseconds = (intPart * 1000) + ((fractPart * 1000) / 0x100000000L);

            //**UTC** time
            var networkDateTime = (new DateTime(1900, 1, 1, 0, 0, 0, DateTimeKind.Utc)).AddMilliseconds((long)milliseconds);

            return networkDateTime.ToLocalTime();
        }

        // stackoverflow.com/a/3294698/162671
        static uint SwapEndianness(ulong x)
        {
            return (uint)(((x & 0x000000ff) << 24) +
                           ((x & 0x0000ff00) << 8) +
                           ((x & 0x00ff0000) >> 8) +
                           ((x & 0xff000000) >> 24));
        }

        public static void CreateFileLogDirModelName(string modelId, string productionId, string status, string process, DateTime dateCheck)
        {
            string dateTime = dateCheck.ToString("yyMMddHHmmss");
            string fileName = $"{dateTime}_{productionId}.txt";
            string folderRoot = $@"C:\LOGPROCESS\{modelId}\";

            bool exists = Directory.Exists(folderRoot);
            if (!exists)
                Directory.CreateDirectory(folderRoot);

            string path = folderRoot + fileName;

            if (!File.Exists(path))
            {
                File.Create(path).Dispose();
                using (TextWriter tw = new StreamWriter(path))
                {
                    tw.WriteLine($"{modelId}|{productionId}|{dateTime}|{status}|{process}");
                    tw.Close();
                }
            }
            else if (File.Exists(path))
            {
                using (TextWriter tw = new StreamWriter(path))
                {
                    tw.WriteLine($"{modelId}|{productionId}|{dateTime}|{status}|{process}");
                    tw.Close();
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="modelId"></param>
        /// <param name="productionId"></param>
        /// <param name="status"></param>
        /// <param name="process"></param>
        /// <param name="dateCheck"></param>
        public static void CreateFileLog(string modelId, string productionId, string status, string process, DateTime dateCheck)
        {
            string dateTime = dateCheck.ToString("yyMMddHHmmss");
            string fileName = $"{dateTime}_{productionId}.txt";
            string folderRoot = $@"C:\LOGPROCESS\";

            bool exists = Directory.Exists(folderRoot);
            if (!exists)
                Directory.CreateDirectory(folderRoot);

            string path = folderRoot + fileName;

            if (!File.Exists(path))
            {
                File.Create(path).Dispose();
                using (TextWriter tw = new StreamWriter(path))
                {
                    tw.WriteLine($"{modelId}|{productionId}|{dateTime}|{status}|{process}");
                    tw.Close();
                }
            }
            else if (File.Exists(path))
            {
                using (TextWriter tw = new StreamWriter(path))
                {
                    tw.WriteLine($"{modelId}|{productionId}|{dateTime}|{status}|{process}");
                    tw.Close();
                }
            }
        }
    }
}