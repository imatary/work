using System;
using System.Collections.Generic;
using System.Linq;
using Indicate.Data;

namespace IndicateReort.Service
{
    public class ShowResultService
    {
        private readonly QUANLYSANXUATEntities _context;
        public ShowResultService()
        {
            _context = new QUANLYSANXUATEntities();
        }

        /// <summary>
        /// Get all
        /// </summary>
        /// <returns></returns>
        public List<Show_Result> GetShowResults()
        {
            var context = new QUANLYSANXUATEntities();

            return context.Show_Result.OrderBy(c => c.Id_process).ToList();

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Show_Result GetShowResultById(string id)
        {
            return GetShowResults().FirstOrDefault(c => c.ID == id);
        }

        //public int SumPassByTime(string reportId, int startHour, int startMinute, int endHour, int endMinute)
        //{
        //    var start = new TimeSpan(startHour, startMinute, 0);
        //    var end = new TimeSpan(endHour, endMinute, 0);
        //    var reportDetail = GetShowResults()
        //        .Where(c => c.ReportID == reportId)
        //        .Where(c => c.Date_check.ToShortDateString() == DateTime.Now.ToShortDateString())
        //        .Where(c => c.Time_check >= start && c.Time_check <= end)
        //        .Sum(c => c.count_actual_pcb);
        //    if (reportDetail != null)
        //        return (int)reportDetail;

        //    return 0;
        //}


        public int ActualByTime(string reportId, int startHour, int startSecond, int startMinute, int endHour, int endMinute, int endSecond)
        {
            var start = new TimeSpan(startHour, startMinute, startSecond);
            var end = new TimeSpan(endHour, endMinute, endSecond);
            using (var context = new QUANLYSANXUATEntities())
            {


                //var report = context.IndicateReports
                //    .Where(c => c.ReportID == reportId)
                //    .Where(c => c.DateRerport.ToShortDateString() == DateTime.Now.ToShortDateString()).FirstOrDefault(c => c.DateRerport.TimeOfDay >= start && c.DateRerport.TimeOfDay <= end);
                //if (report != null)
                //{
                //    int pass = report.Pass;
                //    return pass;
                //}

                return 0;
            }

        }
    }
}