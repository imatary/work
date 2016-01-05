using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MeetingRoom.Web.Models
{
    public class CalendarEvent
    {
        //id, text, start_date and end_date properties are mandatory
        public int id { get; set; }

        public string text { get; set; }

        public DateTime start_date { get; set; }

        public DateTime end_date { get; set; }


        public int room_id { get; set; }
        [ForeignKey("room_id")]
        public Room Room { get; set; }

        public int? user_id { get; set; }

        [Required]
        public string user_name { get; set; }

        public string details { get; set; }

        public string other_devices { get; set; }

        public bool is_charging { get; set; }

        public Guid? owner_id { get; set; }

        [Required]
        public Guid creator_id { get; set; }

        public string laptop_id { get; set; }
        [ForeignKey("laptop_id")]
        public Laptop Laptop { get; set; }

        public string projector_id { get; set; }
        [ForeignKey("projector_id")]
        public Projector Projector { get; set; }
        public int? status_id { get; set; }
        [ForeignKey("status_id")]
        public Status Status { get; set; }

        public string phone_id { get; set; }
        [ForeignKey("phone_id")]
        public Phone Phone { get; set; }
    }
}