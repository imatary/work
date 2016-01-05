using System.ComponentModel.DataAnnotations;

namespace MeetingRoom.Web.Models
{
    public class Status
    {
        public int id { get; set; }

        [StringLength(50)]
        public string title { get; set; }

        [StringLength(10)]
        public string color { get; set; }
    }
}