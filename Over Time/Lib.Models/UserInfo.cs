using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization.Formatters.Binary;

namespace Lib.Models
{
    public class UserInfo
    {
        public int nUserIdn { get; set; }

        public string sUserName { get; set; }

        [Column(TypeName = "image")]
        public byte[] Picture { get; set; } 
    }
}