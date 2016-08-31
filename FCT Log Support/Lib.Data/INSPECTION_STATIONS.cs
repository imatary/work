namespace Lib.Data
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public partial class INSPECTION_STATIONS
    {
        public string DESCRIPTION { get; set; }

        public Guid ID { get; set; }

        public string NAME { get; set; }
        public string STATION_NO { get; set; }
    }
}
