using System.Runtime.InteropServices;
using Microsoft.Win32;

namespace MonitorTurnOff
{
    class Program
    {
        public enum MonitorState
        {
            MonitorStateOn = -1,
            MonitorStateOff = 2,
            MonitorStateStandBy = 1
        }

        [DllImport("user32.dll")]
        private static extern int SendMessage(int hWnd, int hMsg, int wParam, int lParam);

        static void Main(string[] args)
        {
            SystemEvents.SessionSwitch += SystemEvents_SessionSwitch;
            SetMonitorInState(MonitorState.MonitorStateOff);

            System.Environment.Exit(-1);
        }

        static void SystemEvents_SessionSwitch(object sender, SessionSwitchEventArgs e)
        {
            SetMonitorInState(MonitorState.MonitorStateOff);
        }

        static void SetMonitorInState(MonitorState state)
        {
            SendMessage(0xFFFF, 0x112, 0xF170, (int)state);
        }

    }
}
