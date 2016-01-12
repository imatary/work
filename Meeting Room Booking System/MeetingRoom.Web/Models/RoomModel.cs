using System.ComponentModel.DataAnnotations.Schema;

namespace MeetingRoom.Web.Models
{
    using System.ComponentModel.DataAnnotations;

    public class Room
    {
        [Key]
        [Column("room_id")]
        public int key { get; set; }

        [StringLength(128)]
        [Column("title")]
        public string label { get; set; }

        [Display(Name = "Projector")]
        public bool is_projector { get; set; }

        [Display(Name = "Phone")]
        [StringLength(15)]
        public string phone { get; set; }

        public int? position { get; set; }

        [Display(Name = "For Dept")]
        [StringLength(20)]
        public string for_dept { get; set; }
    }
}
