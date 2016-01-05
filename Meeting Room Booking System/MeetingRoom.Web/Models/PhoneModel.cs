using System.ComponentModel.DataAnnotations;

namespace MeetingRoom.Web.Models
{
    public class Phone
    {
        [Key]
        [StringLength(100)]
        public string phone_id { get; set; }

        [Required]
        [StringLength(150)]
        public string phone_name { get; set; }

        public int position { get; set; }

        public bool is_empty { get; set; }
    }
}