using System;
using System.ComponentModel.DataAnnotations;

namespace MeetingRoom.Web.Models
{
    public class ValidEvent
    {
        public long id { get; set; }

        [StringLength(250)]
        public string text { get; set; }

        public DateTime? start_date { get; set; }

        public DateTime? end_date { get; set; }

        [StringLength(50)]
        public string email { get; set; }
    }
}