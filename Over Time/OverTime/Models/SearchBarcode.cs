using System.ComponentModel.DataAnnotations;

namespace OverTime.Models
{
    public class SearchBarcode
    {
        [Required]
        public string SearchKey { get; set; }
    }
}