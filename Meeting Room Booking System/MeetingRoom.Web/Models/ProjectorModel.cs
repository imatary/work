using System.ComponentModel.DataAnnotations;

namespace MeetingRoom.Web.Models
{
    public class Projector
    {
        [Key]
        [Required]
        [StringLength(20)]
        public string projector_id { get; set; }

        [Required]
        [StringLength(150)]
        public string projector_name { get; set; }

        public bool is_empty { get; set; }

        public int position { get; set; }
    }
}