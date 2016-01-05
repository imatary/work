using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using MeetingRoom.Web.Models;

namespace MeetingRoom.Web.ViewModels
{
    public class EventViewModel
    {
        public int id { get; set; }

        public string title { get; set; }

        public DateTime start_date { get; set; }

        public DateTime end_date { get; set; }

        public string room_name { get; set; }

        public int? user_id { get; set; }

        public string user_name { get; set; }

        public string other_devices { get; set; }

        public bool is_charging { get; set; }

        public string laptop_name { get; set; }

        public string projector_name { get; set; }

        public string phone_name { get; set; }

    }
}