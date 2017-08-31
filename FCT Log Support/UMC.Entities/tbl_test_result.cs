using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace UMC.Entities
{
    public class tbl_test_result
    {
        [Key]
        public string ProductionID { get; set; }

        [Key]
        public int OperationID { get; set; }
        public bool JudgeResult { get; set; }
        public string OperatorID { get; set; }
        public DateTime OperationDate { get; set; }

    }
}
