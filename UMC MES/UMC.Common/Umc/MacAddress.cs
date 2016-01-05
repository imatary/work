using System;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using Umc;

public static class MacAddress
{
    // Methods
    public static string GetAddress(string url)
    {
        if (string.IsNullOrEmpty(url))
        {
            throw Error.Argument("invalid url!");
        }
        try
        {
            using (TcpClient client = new TcpClient())
            {
                Uri uri = new Uri(url);
                client.Connect(uri.Host, uri.Port);
                if (client.Connected)
                {
                    Predicate<UnicastIPAddressInformation> match = null;
                    IPEndPoint localEndPoint = (IPEndPoint)client.Client.LocalEndPoint;
                    string ip = localEndPoint.Address.ToString();
                    foreach (NetworkInterface interface2 in NetworkInterface.GetAllNetworkInterfaces())
                    {
                        if (match == null)
                        {
                            match = t => t.IsDnsEligible && (t.Address.ToString() == ip);
                        }
                        if (interface2.GetIPProperties().UnicastAddresses.MakeList<UnicastIPAddressInformation>().Find(match) != null)
                        {
                            return interface2.GetPhysicalAddress().ToString();
                        }
                    }
                    client.Close();
                }
            }
        }
        catch
        {
        }
        return null;
    }
}

