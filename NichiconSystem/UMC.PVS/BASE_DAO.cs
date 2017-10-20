using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;

namespace UMC.PVS
{
    public class BASE_DAO
    {
        public string connectionString = ConfigurationSettings.AppSettings["PVS"].ToString();
    }
}
