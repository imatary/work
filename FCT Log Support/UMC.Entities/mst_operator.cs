using System.ComponentModel.DataAnnotations;

namespace UMC.Entities
{
    public class mst_operator
    {
        [Key]
        public string OperatorID { get; set; }
        public string OperatorName { get; set; }
    }
}
