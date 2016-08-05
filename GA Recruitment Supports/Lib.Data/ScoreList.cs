using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lib.Data
{
    public class ScoreList
    {
        public Guid Id { get; set; }
        public DateTime DateCreated { get; set; }
        public string FullName { get; set; }
        public string Birthday { get; set; }
        public int PI_SumPear { get; set; }
        public int PI_SumEven { get; set; }
        public int PII_SumPear { get; set; }
        public int PII_SumEven { get; set; }
        public int TotalPear { get; set; }
        public int TotalEven { get; set; }
        public int Percent { get; set; }
        public int Difference { get; set; }
        public string KetQua { get; set; }
        public int ScorePicture { get; set; }
        public int PercentPicture { get; set; }
        public string KetQuaPicture { get; set; }
        public string ScoreDisplay {
            get { return $"{ScorePicture}/7"; }
        }
        public int ScoreEye { get; set; }
        public string KetQuaEye { get; set; }
        public bool IsOK { get; set; }
    }
}
