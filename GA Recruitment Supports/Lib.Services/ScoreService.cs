using Lib.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace Lib.Services
{
    public interface IScoreService
    {
        int SumArray(string[] pear);
        int DifferenceArray(string[] pears);
        int MinRowPearArray(string[] pears);
        int MaxRowPearArray(string[] pears);
        int PercentParts(string totalPear, string totalEven);
        
        List<ScoreList> GetScores();
        Score GetScoreById(Guid id, DateTime dateCreated);
        Score GetScoreById(Guid id);
    }
    public class ScoreService : IScoreService
    {
        private readonly GARecruitmentEntities _context;
        public ScoreService()
        {
            _context = new GARecruitmentEntities();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="pears"></param>
        /// <returns></returns>
        public int SumArray(string[] pears)
        {
            int total = 0;
            int value = 0;
            bool isError = false;
            foreach (var item in pears)
            {
                if (!int.TryParse(item, out value))
                {
                    //isError = true;
                    //break;
                    value = 0;
                }
                total += value;
            }
            if (isError)
            {
                return value;
            }
            return total;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="pears"></param>
        /// <returns></returns>
        public int DifferenceArray(string[] pears)
        {
            int difference = 0;
            int value = 0;
            int iMax = int.MinValue;
            int iMin = int.MaxValue;
            int[] array = new int[100];
            List<int> list = new List<int>();

            foreach (var item in pears)
            {
                if (!int.TryParse(item, out value))
                {
                    value = 0;
                }
                list.Add(value);
            }

            iMax = list.Max();
            iMin = list.Min();

            return difference = iMax - iMin;
        }

        public int MinRowPearArray(string[] pears)
        {
            int value = 0;
            int iMin = int.MaxValue;
            int[] array = new int[100];
            List<int> list = new List<int>();

            foreach (var item in pears)
            {
                if (!int.TryParse(item, out value))
                {
                    value = 0;
                }
                list.Add(value);
            }
            iMin = list.Min();

            return iMin;
        }

        public int MaxRowPearArray(string[] pears)
        {
            int value = 0;
            int iMax = int.MinValue;
            int[] array = new int[100];
            List<int> list = new List<int>();

            foreach (var item in pears)
            {
                if (!int.TryParse(item, out value))
                {
                    value = 0;
                }
                list.Add(value);
            }
            iMax = list.Max();

            return iMax;
        }

        public int PercentParts(string totalPear, string totalEven)
        {
            float pear;
            float even;
            if(!float.TryParse(totalPear, out pear))
            {
                pear = 0;
            }
            if(!float.TryParse(totalEven, out even))
            {
                even = 0;
            }

            float percent = (even / pear) * 100;
            if (percent > 100)
                percent = 100;
            return (int)Math.Round(percent, 3);
        }

        public List<ScoreList> GetScores()
        {
            try
            {
                return _context.Database.SqlQuery<ScoreList>("EXEC [dbo].[sp_GetScores]").ToList();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
        public List<ScoreList> GetScoresIsOk()
        {
            try
            {
                return _context.Database.SqlQuery<ScoreList>("EXEC [dbo].[sp_GetScoresIsOK]").ToList();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="FullName"></param>
        /// <param name="Birthday"></param>
        /// <param name="PI_P1"></param>
        /// <param name="PI_P2"></param>
        /// <param name="PI_P3"></param>
        /// <param name="PI_P4"></param>
        /// <param name="PI_P5"></param>
        /// <param name="PI_P6"></param>
        /// <param name="PI_P7"></param>
        /// <param name="PI_P8"></param>
        /// <param name="PI_P9"></param>
        /// <param name="PI_P10"></param>
        /// <param name="PI_P11"></param>
        /// <param name="PI_P12"></param>
        /// <param name="PI_P13"></param>
        /// <param name="PI_E1"></param>
        /// <param name="PI_E2"></param>
        /// <param name="PI_E3"></param>
        /// <param name="PI_E4"></param>
        /// <param name="PI_E5"></param>
        /// <param name="PI_E6"></param>
        /// <param name="PI_E7"></param>
        /// <param name="PI_E8"></param>
        /// <param name="PI_E9"></param>
        /// <param name="PI_E10"></param>
        /// <param name="PI_E11"></param>
        /// <param name="PI_E12"></param>
        /// <param name="PI_E13"></param>
        /// <param name="PII_P1"></param>
        /// <param name="PII_P2"></param>
        /// <param name="PII_P3"></param>
        /// <param name="PII_P4"></param>
        /// <param name="PII_P5"></param>
        /// <param name="PII_P6"></param>
        /// <param name="PII_P7"></param>
        /// <param name="PII_P8"></param>
        /// <param name="PII_P9"></param>
        /// <param name="PII_P10"></param>
        /// <param name="PII_P11"></param>
        /// <param name="PII_P12"></param>
        /// <param name="PII_P13"></param>
        /// <param name="PII_E1"></param>
        /// <param name="PII_E2"></param>
        /// <param name="PII_E3"></param>
        /// <param name="PII_E4"></param>
        /// <param name="PII_E5"></param>
        /// <param name="PII_E6"></param>
        /// <param name="PII_E7"></param>
        /// <param name="PII_E8"></param>
        /// <param name="PII_E9"></param>
        /// <param name="PII_E10"></param>
        /// <param name="PII_E11"></param>
        /// <param name="PII_E12"></param>
        /// <param name="PII_E13"></param>
        /// <param name="PI_SumPear"></param>
        /// <param name="PI_SumEven"></param>
        /// <param name="PII_SumPear"></param>
        /// <param name="PII_SumEven"></param>
        /// <param name="TotalPear"></param>
        /// <param name="TotalEven"></param>
        /// <param name="Percent"></param>
        /// <param name="Difference"></param>
        /// <param name="KetQua"></param>
        /// <param name="ScorePicture"></param>
        /// <param name="PercentPicture"></param>
        /// <param name="KetQuaPicture"></param>
        /// <param name="ScoreEye"></param>
        /// <param name="KetQuaEye"></param>
        public void Insert(
            string FullName,
            string Birthday,
            int PI_P1, int PI_P2, int PI_P3, int PI_P4, int PI_P5, int PI_P6, int PI_P7, int PI_P8, int PI_P9, int PI_P10, int PI_P11, int PI_P12, int PI_P13,
            int PI_E1, int PI_E2, int PI_E3, int PI_E4, int PI_E5, int PI_E6, int PI_E7, int PI_E8, int PI_E9, int PI_E10, int PI_E11, int PI_E12, int PI_E13,
            int PII_P1, int PII_P2, int PII_P3, int PII_P4, int PII_P5, int PII_P6, int PII_P7, int PII_P8, int PII_P9, int PII_P10, int PII_P11, int PII_P12, int PII_P13,
            int PII_E1, int PII_E2, int PII_E3, int PII_E4, int PII_E5, int PII_E6, int PII_E7, int PII_E8, int PII_E9, int PII_E10, int PII_E11, int PII_E12, int PII_E13,
            int PI_SumPear, int PI_SumEven,
            int PII_SumPear, int PII_SumEven,
            int TotalPear, int TotalEven,
            int Percent, int Difference, string KetQua,
            int ScorePicture, int PercentPicture, string KetQuaPicture,
            int ScoreEye, string KetQuaEye, bool isOk)
        {
            object[] param =
            {
                new SqlParameter() { ParameterName = "@Id", Value = Guid.NewGuid(), SqlDbType = SqlDbType.UniqueIdentifier},
                new SqlParameter() { ParameterName = "@DateCreated", Value = DateTime.Now.Date, SqlDbType = SqlDbType.Date},
                new SqlParameter() { ParameterName = "@FullName", Value = FullName, SqlDbType=SqlDbType.NVarChar },
                new SqlParameter() { ParameterName = "@Birthday", Value = Birthday, SqlDbType=SqlDbType.VarChar },
                new SqlParameter() { ParameterName = "@PI_P1", Value = PI_P1, SqlDbType=SqlDbType.Int },
                new SqlParameter() { ParameterName = "@PI_P2", Value = PI_P2, SqlDbType=SqlDbType.Int },
                new SqlParameter() { ParameterName = "@PI_P3", Value = PI_P3, SqlDbType=SqlDbType.Int },
                new SqlParameter() { ParameterName = "@PI_P4", Value = PI_P4, SqlDbType=SqlDbType.Int },
                new SqlParameter() { ParameterName = "@PI_P5", Value = PI_P5, SqlDbType=SqlDbType.Int },
                new SqlParameter() { ParameterName = "@PI_P6", Value = PI_P6, SqlDbType=SqlDbType.Int },
                new SqlParameter() { ParameterName = "@PI_P7", Value = PI_P7, SqlDbType=SqlDbType.Int },
                new SqlParameter() { ParameterName = "@PI_P8", Value = PI_P8, SqlDbType=SqlDbType.Int },
                new SqlParameter() { ParameterName = "@PI_P9", Value = PI_P9, SqlDbType=SqlDbType.Int },
                new SqlParameter() { ParameterName = "@PI_P10", Value = PI_P10, SqlDbType=SqlDbType.Int },
                new SqlParameter() { ParameterName = "@PI_P11", Value = PI_P11, SqlDbType=SqlDbType.Int },
                new SqlParameter() { ParameterName = "@PI_P12", Value = PI_P12, SqlDbType=SqlDbType.Int },
                new SqlParameter() { ParameterName = "@PI_P13", Value = PI_P13, SqlDbType=SqlDbType.Int },

                new SqlParameter() { ParameterName = "@PI_E1", Value = PI_E1, SqlDbType=SqlDbType.Int },
                new SqlParameter() { ParameterName = "@PI_E2", Value = PI_E2, SqlDbType=SqlDbType.Int },
                new SqlParameter() { ParameterName = "@PI_E3", Value = PI_E3, SqlDbType=SqlDbType.Int },
                new SqlParameter() { ParameterName = "@PI_E4", Value = PI_E4, SqlDbType=SqlDbType.Int },
                new SqlParameter() { ParameterName = "@PI_E5", Value = PI_E5, SqlDbType=SqlDbType.Int },
                new SqlParameter() { ParameterName = "@PI_E6", Value = PI_E6, SqlDbType=SqlDbType.Int },
                new SqlParameter() { ParameterName = "@PI_E7", Value = PI_E7, SqlDbType=SqlDbType.Int },
                new SqlParameter() { ParameterName = "@PI_E8", Value = PI_E8, SqlDbType=SqlDbType.Int },
                new SqlParameter() { ParameterName = "@PI_E9", Value = PI_E9, SqlDbType=SqlDbType.Int },
                new SqlParameter() { ParameterName = "@PI_E10", Value = PI_E10, SqlDbType=SqlDbType.Int },
                new SqlParameter() { ParameterName = "@PI_E11", Value = PI_E11, SqlDbType=SqlDbType.Int },
                new SqlParameter() { ParameterName = "@PI_E12", Value = PI_E12, SqlDbType=SqlDbType.Int },
                new SqlParameter() { ParameterName = "@PI_E13", Value = PI_E13, SqlDbType=SqlDbType.Int },


                new SqlParameter() { ParameterName = "@PII_P1", Value = PII_P1, SqlDbType=SqlDbType.Int },
                new SqlParameter() { ParameterName = "@PII_P2", Value = PII_P2, SqlDbType=SqlDbType.Int },
                new SqlParameter() { ParameterName = "@PII_P3", Value = PII_P3, SqlDbType=SqlDbType.Int },
                new SqlParameter() { ParameterName = "@PII_P4", Value = PII_P4, SqlDbType=SqlDbType.Int },
                new SqlParameter() { ParameterName = "@PII_P5", Value = PII_P5, SqlDbType=SqlDbType.Int },
                new SqlParameter() { ParameterName = "@PII_P6", Value = PII_P6, SqlDbType=SqlDbType.Int },
                new SqlParameter() { ParameterName = "@PII_P7", Value = PII_P7, SqlDbType=SqlDbType.Int },
                new SqlParameter() { ParameterName = "@PII_P8", Value = PII_P8, SqlDbType=SqlDbType.Int },
                new SqlParameter() { ParameterName = "@PII_P9", Value = PII_P9, SqlDbType=SqlDbType.Int },
                new SqlParameter() { ParameterName = "@PII_P10", Value = PII_P10, SqlDbType=SqlDbType.Int },
                new SqlParameter() { ParameterName = "@PII_P11", Value = PII_P11, SqlDbType=SqlDbType.Int },
                new SqlParameter() { ParameterName = "@PII_P12", Value = PII_P12, SqlDbType=SqlDbType.Int },
                new SqlParameter() { ParameterName = "@PII_P13", Value = PII_P13, SqlDbType=SqlDbType.Int },

                new SqlParameter() { ParameterName = "@PII_E1", Value = PII_E1, SqlDbType=SqlDbType.Int },
                new SqlParameter() { ParameterName = "@PII_E2", Value = PII_E2, SqlDbType=SqlDbType.Int },
                new SqlParameter() { ParameterName = "@PII_E3", Value = PII_E3, SqlDbType=SqlDbType.Int },
                new SqlParameter() { ParameterName = "@PII_E4", Value = PII_E4, SqlDbType=SqlDbType.Int },
                new SqlParameter() { ParameterName = "@PII_E5", Value = PII_E5, SqlDbType=SqlDbType.Int },
                new SqlParameter() { ParameterName = "@PII_E6", Value = PII_E6, SqlDbType=SqlDbType.Int },
                new SqlParameter() { ParameterName = "@PII_E7", Value = PII_E7, SqlDbType=SqlDbType.Int },
                new SqlParameter() { ParameterName = "@PII_E8", Value = PII_E8, SqlDbType=SqlDbType.Int },
                new SqlParameter() { ParameterName = "@PII_E9", Value = PII_E9, SqlDbType=SqlDbType.Int },
                new SqlParameter() { ParameterName = "@PII_E10", Value = PII_E10, SqlDbType=SqlDbType.Int },
                new SqlParameter() { ParameterName = "@PII_E11", Value = PII_E11, SqlDbType=SqlDbType.Int },
                new SqlParameter() { ParameterName = "@PII_E12", Value = PII_E12, SqlDbType=SqlDbType.Int },
                new SqlParameter() { ParameterName = "@PII_E13", Value = PII_E13, SqlDbType=SqlDbType.Int },

                new SqlParameter() { ParameterName = "@PI_SumPear", Value = PI_SumPear, SqlDbType=SqlDbType.Int },
                new SqlParameter() { ParameterName = "@PI_SumEven", Value = PI_SumEven, SqlDbType=SqlDbType.Int },
                new SqlParameter() { ParameterName = "@PII_SumPear", Value = PII_SumPear, SqlDbType=SqlDbType.Int },
                new SqlParameter() { ParameterName = "@PII_SumEven", Value = PII_SumEven, SqlDbType=SqlDbType.Int },
                new SqlParameter() { ParameterName = "@TotalPear", Value = TotalPear, SqlDbType=SqlDbType.Int },
                new SqlParameter() { ParameterName = "@TotalEven", Value = TotalEven, SqlDbType=SqlDbType.Int },
                new SqlParameter() { ParameterName = "@Percent", Value = Percent, SqlDbType=SqlDbType.Int },
                new SqlParameter() { ParameterName = "@Difference", Value = Difference, SqlDbType=SqlDbType.Int },
                new SqlParameter() { ParameterName = "@KetQua", Value = KetQua, SqlDbType=SqlDbType.VarChar },
                new SqlParameter() { ParameterName = "@ScorePicture", Value = ScorePicture, SqlDbType=SqlDbType.Int },
                new SqlParameter() { ParameterName = "@PercentPicture", Value = PercentPicture, SqlDbType=SqlDbType.Int },
                new SqlParameter() { ParameterName = "@KetQuaPicture", Value = KetQuaPicture, SqlDbType=SqlDbType.VarChar },
                new SqlParameter() { ParameterName = "@ScoreEye", Value = ScoreEye, SqlDbType=SqlDbType.Int },
                new SqlParameter() { ParameterName = "@KetQuaEye", Value = KetQuaEye, SqlDbType=SqlDbType.VarChar },
                new SqlParameter() { ParameterName = "@IsOK", Value = isOk, SqlDbType=SqlDbType.Bit },
                new SqlParameter("@Out_Parameter", SqlDbType.Int)
                {
                    Direction = ParameterDirection.Output
                }
            };

            try
            {
                _context.Database.ExecuteSqlCommand("EXEC [dbo].[sp_InsertScores] @Id,@DateCreated,@FullName,@Birthday,@PI_P1,@PI_P2,@PI_P3,@PI_P4,@PI_P5,@PI_P6,@PI_P7,@PI_P8,@PI_P9,@PI_P10,@PI_P11,@PI_P12,@PI_P13,@PI_E1,@PI_E2,@PI_E3,@PI_E4,@PI_E5,@PI_E6,@PI_E7,@PI_E8,@PI_E9,@PI_E10,@PI_E11,@PI_E12,@PI_E13,@PII_P1,@PII_P2,@PII_P3,@PII_P4,@PII_P5,@PII_P6,@PII_P7,@PII_P8,@PII_P9,@PII_P10,@PII_P11,@PII_P12,@PII_P13,@PII_E1,@PII_E2,@PII_E3,@PII_E4,@PII_E5,@PII_E6,@PII_E7,@PII_E8,@PII_E9,@PII_E10,@PII_E11,@PII_E12,@PII_E13,@PI_SumPear,@PI_SumEven,@PII_SumPear,@PII_SumEven,@TotalPear,@TotalEven,@Percent,@Difference,@KetQua,@ScorePicture,@PercentPicture,@KetQuaPicture,@ScoreEye,@KetQuaEye,@IsOK", param);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void Update(
            Guid Id,
            DateTime DateCreated,
            string FullName,
            string Birthday,
            int PI_P1, int PI_P2, int PI_P3, int PI_P4, int PI_P5, int PI_P6, int PI_P7, int PI_P8, int PI_P9, int PI_P10, int PI_P11, int PI_P12, int PI_P13,
            int PI_E1, int PI_E2, int PI_E3, int PI_E4, int PI_E5, int PI_E6, int PI_E7, int PI_E8, int PI_E9, int PI_E10, int PI_E11, int PI_E12, int PI_E13,
            int PII_P1, int PII_P2, int PII_P3, int PII_P4, int PII_P5, int PII_P6, int PII_P7, int PII_P8, int PII_P9, int PII_P10, int PII_P11, int PII_P12, int PII_P13,
            int PII_E1, int PII_E2, int PII_E3, int PII_E4, int PII_E5, int PII_E6, int PII_E7, int PII_E8, int PII_E9, int PII_E10, int PII_E11, int PII_E12, int PII_E13,
            int PI_SumPear, int PI_SumEven,
            int PII_SumPear, int PII_SumEven,
            int TotalPear, int TotalEven,
            int Percent, int Difference, string KetQua,
            int ScorePicture, int PercentPicture, string KetQuaPicture,
            int ScoreEye, string KetQuaEye)
        {
            object[] param =
            {
                new SqlParameter() { ParameterName = "@Id", Value = Id, SqlDbType = SqlDbType.UniqueIdentifier},
                new SqlParameter() { ParameterName = "@DateCreated", Value = DateCreated, SqlDbType = SqlDbType.Date},
                new SqlParameter() { ParameterName = "@FullName", Value = FullName, SqlDbType=SqlDbType.NVarChar },
                new SqlParameter() { ParameterName = "@Birthday", Value = Birthday, SqlDbType=SqlDbType.VarChar },
                new SqlParameter() { ParameterName = "@PI_P1", Value = PI_P1, SqlDbType=SqlDbType.Int },
                new SqlParameter() { ParameterName = "@PI_P2", Value = PI_P2, SqlDbType=SqlDbType.Int },
                new SqlParameter() { ParameterName = "@PI_P3", Value = PI_P3, SqlDbType=SqlDbType.Int },
                new SqlParameter() { ParameterName = "@PI_P4", Value = PI_P4, SqlDbType=SqlDbType.Int },
                new SqlParameter() { ParameterName = "@PI_P5", Value = PI_P5, SqlDbType=SqlDbType.Int },
                new SqlParameter() { ParameterName = "@PI_P6", Value = PI_P6, SqlDbType=SqlDbType.Int },
                new SqlParameter() { ParameterName = "@PI_P7", Value = PI_P7, SqlDbType=SqlDbType.Int },
                new SqlParameter() { ParameterName = "@PI_P8", Value = PI_P8, SqlDbType=SqlDbType.Int },
                new SqlParameter() { ParameterName = "@PI_P9", Value = PI_P9, SqlDbType=SqlDbType.Int },
                new SqlParameter() { ParameterName = "@PI_P10", Value = PI_P10, SqlDbType=SqlDbType.Int },
                new SqlParameter() { ParameterName = "@PI_P11", Value = PI_P11, SqlDbType=SqlDbType.Int },
                new SqlParameter() { ParameterName = "@PI_P12", Value = PI_P12, SqlDbType=SqlDbType.Int },
                new SqlParameter() { ParameterName = "@PI_P13", Value = PI_P13, SqlDbType=SqlDbType.Int },

                new SqlParameter() { ParameterName = "@PI_E1", Value = PI_E1, SqlDbType=SqlDbType.Int },
                new SqlParameter() { ParameterName = "@PI_E2", Value = PI_E2, SqlDbType=SqlDbType.Int },
                new SqlParameter() { ParameterName = "@PI_E3", Value = PI_E3, SqlDbType=SqlDbType.Int },
                new SqlParameter() { ParameterName = "@PI_E4", Value = PI_E4, SqlDbType=SqlDbType.Int },
                new SqlParameter() { ParameterName = "@PI_E5", Value = PI_E5, SqlDbType=SqlDbType.Int },
                new SqlParameter() { ParameterName = "@PI_E6", Value = PI_E6, SqlDbType=SqlDbType.Int },
                new SqlParameter() { ParameterName = "@PI_E7", Value = PI_E7, SqlDbType=SqlDbType.Int },
                new SqlParameter() { ParameterName = "@PI_E8", Value = PI_E8, SqlDbType=SqlDbType.Int },
                new SqlParameter() { ParameterName = "@PI_E9", Value = PI_E9, SqlDbType=SqlDbType.Int },
                new SqlParameter() { ParameterName = "@PI_E10", Value = PI_E10, SqlDbType=SqlDbType.Int },
                new SqlParameter() { ParameterName = "@PI_E11", Value = PI_E11, SqlDbType=SqlDbType.Int },
                new SqlParameter() { ParameterName = "@PI_E12", Value = PI_E12, SqlDbType=SqlDbType.Int },
                new SqlParameter() { ParameterName = "@PI_E13", Value = PI_E13, SqlDbType=SqlDbType.Int },


                new SqlParameter() { ParameterName = "@PII_P1", Value = PII_P1, SqlDbType=SqlDbType.Int },
                new SqlParameter() { ParameterName = "@PII_P2", Value = PII_P2, SqlDbType=SqlDbType.Int },
                new SqlParameter() { ParameterName = "@PII_P3", Value = PII_P3, SqlDbType=SqlDbType.Int },
                new SqlParameter() { ParameterName = "@PII_P4", Value = PII_P4, SqlDbType=SqlDbType.Int },
                new SqlParameter() { ParameterName = "@PII_P5", Value = PII_P5, SqlDbType=SqlDbType.Int },
                new SqlParameter() { ParameterName = "@PII_P6", Value = PII_P6, SqlDbType=SqlDbType.Int },
                new SqlParameter() { ParameterName = "@PII_P7", Value = PII_P7, SqlDbType=SqlDbType.Int },
                new SqlParameter() { ParameterName = "@PII_P8", Value = PII_P8, SqlDbType=SqlDbType.Int },
                new SqlParameter() { ParameterName = "@PII_P9", Value = PII_P9, SqlDbType=SqlDbType.Int },
                new SqlParameter() { ParameterName = "@PII_P10", Value = PII_P10, SqlDbType=SqlDbType.Int },
                new SqlParameter() { ParameterName = "@PII_P11", Value = PII_P11, SqlDbType=SqlDbType.Int },
                new SqlParameter() { ParameterName = "@PII_P12", Value = PII_P12, SqlDbType=SqlDbType.Int },
                new SqlParameter() { ParameterName = "@PII_P13", Value = PII_P13, SqlDbType=SqlDbType.Int },

                new SqlParameter() { ParameterName = "@PII_E1", Value = PII_E1, SqlDbType=SqlDbType.Int },
                new SqlParameter() { ParameterName = "@PII_E2", Value = PII_E2, SqlDbType=SqlDbType.Int },
                new SqlParameter() { ParameterName = "@PII_E3", Value = PII_E3, SqlDbType=SqlDbType.Int },
                new SqlParameter() { ParameterName = "@PII_E4", Value = PII_E4, SqlDbType=SqlDbType.Int },
                new SqlParameter() { ParameterName = "@PII_E5", Value = PII_E5, SqlDbType=SqlDbType.Int },
                new SqlParameter() { ParameterName = "@PII_E6", Value = PII_E6, SqlDbType=SqlDbType.Int },
                new SqlParameter() { ParameterName = "@PII_E7", Value = PII_E7, SqlDbType=SqlDbType.Int },
                new SqlParameter() { ParameterName = "@PII_E8", Value = PII_E8, SqlDbType=SqlDbType.Int },
                new SqlParameter() { ParameterName = "@PII_E9", Value = PII_E9, SqlDbType=SqlDbType.Int },
                new SqlParameter() { ParameterName = "@PII_E10", Value = PII_E10, SqlDbType=SqlDbType.Int },
                new SqlParameter() { ParameterName = "@PII_E11", Value = PII_E11, SqlDbType=SqlDbType.Int },
                new SqlParameter() { ParameterName = "@PII_E12", Value = PII_E12, SqlDbType=SqlDbType.Int },
                new SqlParameter() { ParameterName = "@PII_E13", Value = PII_E13, SqlDbType=SqlDbType.Int },

                new SqlParameter() { ParameterName = "@PI_SumPear", Value = PI_SumPear, SqlDbType=SqlDbType.Int },
                new SqlParameter() { ParameterName = "@PI_SumEven", Value = PI_SumEven, SqlDbType=SqlDbType.Int },
                new SqlParameter() { ParameterName = "@PII_SumPear", Value = PII_SumPear, SqlDbType=SqlDbType.Int },
                new SqlParameter() { ParameterName = "@PII_SumEven", Value = PII_SumEven, SqlDbType=SqlDbType.Int },
                new SqlParameter() { ParameterName = "@TotalPear", Value = TotalPear, SqlDbType=SqlDbType.Int },
                new SqlParameter() { ParameterName = "@TotalEven", Value = TotalEven, SqlDbType=SqlDbType.Int },
                new SqlParameter() { ParameterName = "@Percent", Value = Percent, SqlDbType=SqlDbType.Int },
                new SqlParameter() { ParameterName = "@Difference", Value = Difference, SqlDbType=SqlDbType.Int },
                new SqlParameter() { ParameterName = "@KetQua", Value = KetQua, SqlDbType=SqlDbType.VarChar },
                new SqlParameter() { ParameterName = "@ScorePicture", Value = ScorePicture, SqlDbType=SqlDbType.Int },
                new SqlParameter() { ParameterName = "@PercentPicture", Value = PercentPicture, SqlDbType=SqlDbType.Int },
                new SqlParameter() { ParameterName = "@KetQuaPicture", Value = KetQuaPicture, SqlDbType=SqlDbType.VarChar },
                new SqlParameter() { ParameterName = "@ScoreEye", Value = ScoreEye, SqlDbType=SqlDbType.Int },
                new SqlParameter() { ParameterName = "@KetQuaEye", Value = KetQuaEye, SqlDbType=SqlDbType.VarChar },

                new SqlParameter("@Out_Parameter", SqlDbType.Int)
                {
                    Direction = ParameterDirection.Output
                }
            };

            try
            {
                _context.Database.ExecuteSqlCommand("EXEC [dbo].[sp_UpdateScores] @Id,@DateCreated,@FullName,@Birthday,@PI_P1,@PI_P2,@PI_P3,@PI_P4,@PI_P5,@PI_P6,@PI_P7,@PI_P8,@PI_P9,@PI_P10,@PI_P11,@PI_P12,@PI_P13,@PI_E1,@PI_E2,@PI_E3,@PI_E4,@PI_E5,@PI_E6,@PI_E7,@PI_E8,@PI_E9,@PI_E10,@PI_E11,@PI_E12,@PI_E13,@PII_P1,@PII_P2,@PII_P3,@PII_P4,@PII_P5,@PII_P6,@PII_P7,@PII_P8,@PII_P9,@PII_P10,@PII_P11,@PII_P12,@PII_P13,@PII_E1,@PII_E2,@PII_E3,@PII_E4,@PII_E5,@PII_E6,@PII_E7,@PII_E8,@PII_E9,@PII_E10,@PII_E11,@PII_E12,@PII_E13,@PI_SumPear,@PI_SumEven,@PII_SumPear,@PII_SumEven,@TotalPear,@TotalEven,@Percent,@Difference,@KetQua,@ScorePicture,@PercentPicture,@KetQuaPicture,@ScoreEye,@KetQuaEye", param);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void Update(Guid id, bool isOk)
        {
            object[] param =
            {
                new SqlParameter() { ParameterName = "@Id", Value = id, SqlDbType = SqlDbType.UniqueIdentifier },
                new SqlParameter() { ParameterName = "@IsOK", Value = isOk, SqlDbType = SqlDbType.Bit },
                new SqlParameter("@Out_Parameter", SqlDbType.Int)
                {
                    Direction = ParameterDirection.Output
                }
            };

            try
            {
                _context.Database.ExecuteSqlCommand("EXEC [dbo].[sp_UpdateScoresIsOK] @Id,@IsOK", param);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }
        public void Delete(Guid Id, DateTime DateCreated)
        {
            object[] param =
            {
                new SqlParameter() { ParameterName = "@Id", Value = Id, SqlDbType = SqlDbType.UniqueIdentifier},
                new SqlParameter() { ParameterName = "@DateCreated", Value = DateCreated, SqlDbType = SqlDbType.Date},
                new SqlParameter("@Out_Parameter", SqlDbType.Int)
                {
                    Direction = ParameterDirection.Output
                }
            };

            try
            {
                _context.Database.ExecuteSqlCommand("EXEC [dbo].[sp_DeleteScores] @Id,@DateCreated", param);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="dateCreated"></param>
        /// <returns></returns>
        public Score GetScoreById(Guid id, DateTime dateCreated)
        {
            object[] param =
            {
                new SqlParameter() { ParameterName="@Id", Value=id, SqlDbType=SqlDbType.UniqueIdentifier },
                new SqlParameter() { ParameterName="@DateCreated", Value=dateCreated, SqlDbType=SqlDbType.Date },
                new SqlParameter("@Out_Parameter", SqlDbType.Int)
                {
                    Direction = ParameterDirection.Output
                }
            };
            try
            {
                return _context.Database.SqlQuery<Score>("EXEC [dbo].[sp_GetScoresById] @Id, @DateCreated", param).FirstOrDefault();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public Score GetScoreById(Guid id)
        {
            object[] param =
            {
                new SqlParameter() { ParameterName="@Id", Value=id, SqlDbType=SqlDbType.UniqueIdentifier },
                new SqlParameter("@Out_Parameter", SqlDbType.Int)
                {
                    Direction = ParameterDirection.Output
                }
            };
            try
            {
                return _context.Database.SqlQuery<Score>("EXEC [dbo].[sp_GetScoreById] @Id", param).FirstOrDefault();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
    }
}
