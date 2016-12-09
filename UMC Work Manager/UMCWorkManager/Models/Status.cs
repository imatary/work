using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace UMCWorkManager.Models
{
    public class Status
    {
        public int Id { get; set; }
        [Required]
        [StringLength(50)]
        public string Title { get; set; }

        [StringLength(50)]
        public string Color { get; set; }
    }
}