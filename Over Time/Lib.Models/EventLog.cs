using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Lib.Models
{
    public class EventLog
    {
        public int nEventLogIdn { get; set; }
        public int nDateTime { get; set; }
        public int nReaderIdn { get; set; }
        public int nEventIdn { get; set; }
        public int nUserID { get; set; }
        public short nIsLog { get; set; }
        public short nTNAEvent { get; set; }
        public short nIsUseTA { get; set; }
        public short nType { get; set; }
        public string sName { get; set; }
        public string sDescription { get; set; }
        public int nUserIdn { get; set; }
        public string sUserName { get; set; }
        public int nDepartmentIdn { get; set; }
        public string sDepartment { get; set; }
        public string DepartmentName { get; set; }
    }
}