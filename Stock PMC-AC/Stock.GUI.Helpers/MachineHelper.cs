using System.Net.NetworkInformation;
using System.Net.Sockets;

namespace Stock.GUI.Helpers
{
    public static class MachineHelper
    {
        /// <summary>
        /// Get Machine Info
        /// </summary>
        /// <returns>Machine Info String</returns>
        public static string GetMachineInfo()
        {
            string info = System.Net.Dns.GetHostName();

            foreach (NetworkInterface networkInterface in NetworkInterface.GetAllNetworkInterfaces())
            {
                if (networkInterface.OperationalStatus == OperationalStatus.Up)
                {
                    foreach (var ip in networkInterface.GetIPProperties().UnicastAddresses)
                    {
                        if (ip.Address.AddressFamily == AddressFamily.InterNetwork)
                        {
                            info += "|" + networkInterface.GetPhysicalAddress() + "|" + ip.Address;

                            return info;
                        }
                    }
                }
            }

            return info;
        }
    }
}
