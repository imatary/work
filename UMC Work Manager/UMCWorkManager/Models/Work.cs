using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace UMCWorkManager.Models
{
    public class Work
    {
        [Key]
        public int WorkId { get; set; }

        [Required]
        [Display(Name ="Name"), StringLength(250), MinLength(2)]
        public string WorkName { get; set; } 
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime MidifyDate { get; set; }

        [Required]
        [StringLength(300)]
        public string CreatedBy { get; set; }

        [DataType(DataType.MultilineText)]
        public string Description { get; set; }

        public string Path { get; set; }

        public int StatusId { get; set; }
        [ForeignKey("StatusId")]
        public Status Status { get; set; }
    }
}