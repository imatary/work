namespace IndicateReort.Service
{
    public class ScheduleView
    {
        /// <summary>
        /// Thời gian bắt đầu
        /// </summary>
        public string StartTime { get; set; }

        /// <summary>
        /// Thời gian kết thúc
        /// </summary>
        public string EndTime { get; set; }
        
        /// <summary>
        /// 
        /// </summary>
        public string TimeName
        {
            get { return StartTime.Remove(5) + " ~ " + EndTime.Remove(5); }
        }

        /// <summary>
        /// Kế hoạch
        /// </summary>
        public int Plan { get; set; }

        /// <summary>
        /// Số lượng thực tế đang chạy
        /// </summary>
        public int QuantityCurrent { get; set; }

        /// <summary>
        /// Số lượng Chênh Lệch
        /// </summary>
        public int ChenhLech
        {
            get
            {
                if (QuantityCurrent > 0)
                {
                    return QuantityCurrent - Plan;
                }
                return 0;
            }
        }


    }
}