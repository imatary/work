using System;
using System.Collections.Generic;
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

    }
    public class ScoreService : IScoreService
    {
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
    }
}
