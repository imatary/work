using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace NichiconSystem
{
    public class Model
    {
        public Model()
        {
            ModelID = Guid.NewGuid().ToString();
            DateCreated = DateTime.Now;
        }
        [Key]
        public string ModelID { get; set; }

        public string ModelName { get; set; }

        public int Quantity { get; set; }

        public string SerialNo { get; set; }

        public string By { get; set; }

        public DateTime DateCreated { get; set; }
    }
}
