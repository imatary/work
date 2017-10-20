using System;
using System.ComponentModel;

namespace UMC.PVS.USERS
{
    [Serializable]
    public class USERS
    {
        /// <summary>
        /// DESCRIPTION
        /// </summary>
        [DisplayName("DESCRIPTION")]
        public string DESCRIPTION { get; set; }

        /// <summary>
        /// ID
        /// </summary>
        [DisplayName("ID")]
        public string ID { get; set; }

        /// <summary>
        /// NAME
        /// </summary>
        [DisplayName("NAME")]
        public string NAME { get; set; }

        /// <summary>
        /// PASSWORD
        /// </summary>
        [DisplayName("PASSWORD")]
        public string PASSWORD { get; set; }

    }
}
