using System;
using System.ComponentModel;

namespace UMC.PVS.RULES
{
    [Serializable]
    public class BARCODE_RULE_ITEMS
    {
        /// <summary>
        /// CONTENT
        /// </summary>
        [DisplayName("CONTENT")]
        public string CONTENT { get; set; }

        /// <summary>
        /// CONTENT_LENGTH
        /// </summary>
        [DisplayName("CONTENT_LENGTH")]
        public int CONTENT_LENGTH { get; set; }

        /// <summary>
        /// RANGE_CONTENT1
        /// </summary>
        [DisplayName("RANGE_CONTENT1")]
        public string RANGE_CONTENT1 { get; set; }

        /// <summary>
        /// RANGE_CONTENT2
        /// </summary>
        [DisplayName("RANGE_CONTENT2")]
        public string RANGE_CONTENT2 { get; set; }

        /// <summary>
        /// CUSTOM_CONTENT_LENGTH
        /// </summary>
        [DisplayName("CUSTOM_CONTENT_LENGTH")]
        public int CUSTOM_CONTENT_LENGTH { get; set; }

        /// <summary>
        /// CUSTOM_CONTENT_LOCATION
        /// </summary>
        [DisplayName("CUSTOM_CONTENT_LOCATION")]
        public int CUSTOM_CONTENT_LOCATION { get; set; }

        /// <summary>
        /// DESCRIPTION
        /// </summary>
        [DisplayName("DESCRIPTION")]
        public string DESCRIPTION { get; set; }

        /// <summary>
        /// ID
        /// </summary>
        [DisplayName("ID")]
        public Guid ID { get; set; }

        /// <summary>
        /// INDEX
        /// </summary>
        [DisplayName("INDEX")]
        public int INDEX { get; set; }

        /// <summary>
        /// IS_CONVERSION_ENTRY
        /// </summary>
        [DisplayName("IS_CONVERSION_ENTRY")]
        public bool IS_CONVERSION_ENTRY { get; set; }

        /// <summary>
        /// IS_FROM_RIGHT_TO_LEFT
        /// </summary>
        [DisplayName("IS_FROM_RIGHT_TO_LEFT")]
        public bool IS_FROM_RIGHT_TO_LEFT { get; set; }

        /// <summary>
        /// IS_USING_CASE_IGNORING
        /// </summary>
        [DisplayName("IS_USING_CASE_IGNORING")]
        public bool IS_USING_CASE_IGNORING { get; set; }

        /// <summary>
        /// IS_USING_CONTENT_CHECKING
        /// </summary>
        [DisplayName("IS_USING_CONTENT_CHECKING")]
        public bool IS_USING_CONTENT_CHECKING { get; set; }

        /// <summary>
        /// IS_USING_CUSTOM_CONTENT
        /// </summary>
        [DisplayName("IS_USING_CUSTOM_CONTENT")]
        public bool IS_USING_CUSTOM_CONTENT { get; set; }

        /// <summary>
        /// IS_USING_LENGTH_CHECKING
        /// </summary>
        [DisplayName("IS_USING_LENGTH_CHECKING")]
        public bool IS_USING_LENGTH_CHECKING { get; set; }

        /// <summary>
        /// IS_USING_MULTIPLE_CONTENT
        /// </summary>
        [DisplayName("IS_USING_MULTIPLE_CONTENT")]
        public bool IS_USING_MULTIPLE_CONTENT { get; set; }

        /// <summary>
        /// IS_USING_MULTIPLE_RANGE_CONTENT
        /// </summary>
        [DisplayName("IS_USING_MULTIPLE_RANGE_CONTENT")]
        public bool IS_USING_MULTIPLE_RANGE_CONTENT { get; set; }

        /// <summary>
        /// IS_USING_RANGE_CONTENT
        /// </summary>
        [DisplayName("IS_USING_RANGE_CONTENT")]
        public bool IS_USING_RANGE_CONTENT { get; set; }

        /// <summary>
        /// LENGTH
        /// </summary>
        [DisplayName("LENGTH")]
        public int LENGTH { get; set; }

        /// <summary>
        /// LOCATION
        /// </summary>
        [DisplayName("LOCATION")]
        public int LOCATION { get; set; }

        /// <summary>
        /// RULE_ID
        /// </summary>
        [DisplayName("RULE_ID")]
        public Guid RULE_ID { get; set; }

        /// <summary>
        /// RULE_NAME
        /// </summary>
        [DisplayName("RULE_NAME")]
        public string RULE_NAME { get; set; }

        /// <summary>
        /// RULE_NO
        /// </summary>
        [DisplayName("RULE_NO")]
        public string RULE_NO { get; set; }

        /// <summary>
        /// UPDATE_TIME
        /// </summary>
        [DisplayName("UPDATE_TIME")]
        public DateTime UPDATE_TIME { get; set; }

        /// <summary>
        /// UPDATER_NAME
        /// </summary>
        [DisplayName("UPDATER_NAME")]
        public string UPDATER_NAME { get; set; }

    }
}
