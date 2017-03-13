using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Umc.Web.Models
{
    public class Olympic
    {
        public Olympic()
        {
            Id = Guid.NewGuid();
        }
        [Key]
        public Guid Id { get; set; }

        public string StaffCode { get; set; }

        public string FullName { get; set; }

        public byte[] StaffPicture { get; set; }

        public string Content { get; set; }

        public DateTime TestDate { get; set; }

        public string Certificate { get; set; }

        public string CreateBy { get; set; }

        public DateTime CreateDate { get; set; }

    }
}