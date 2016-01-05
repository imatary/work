using System;
using System.Collections.Generic;
using System.Linq;
using IndicateReport.Data;

namespace IndicateReport.Services
{
    public class ReportMasterService
    {
        // private readonly IndicateReportMasterEntities _context;

        // public ReportMasterService()
        //{
        //    _context = new IndicateReportMasterEntities();
        //}

        ///// <summary>
        ///// Get List
        ///// </summary>
        ///// <returns></returns>
        //public List<ReportMaster> GetReportMasters()
        //{
        //    using (var context = new IndicateReportMasterEntities())
        //    {
        //        return context.ReportMasters.ToList();
        //    }
        //}

        

        //public bool CheckReportIdExit(string reportId)
        //{
        //    ReportMaster report = GetReportMasterById(reportId);
        //    if (report != null)
        //    {
        //        return false;
        //    }
        //    return true;
        //}

        ///// <summary>
        ///// Insert Report
        ///// </summary>
        // /// <param name="reportMaster"></param>
        //public void Insert(ReportMaster reportMaster)
        //{
        //    //if (reportMaster != null)
        //    //{
        //        _context.ReportMasters.AddObject(reportMaster);
        //        SaveChanges();
        //    //}
        //}
        ///// <summary>
        ///// Update
        ///// </summary>
        ///// <param name="report"></param>
        //public void Update(ReportMaster report)
        //{
        //    //_context.ReportMasters.Attach(report);
        //    //_context.Entry(report).State = EntityState.Modified;
        //    SaveChanges();
        //}

        ///// <summary>
        ///// Insert Details
        ///// </summary>
        ///// <param name="reportDetail"></param>
        //private void InsertReportDetail(ReportDetail reportDetail)
        //{
        //    _context.ReportDetails.AddObject(reportDetail);
        //    SaveChanges();
        //}

        //public void InsertReportDetails(string reportId, int total, int pass, DateTime dateReport)
        //{
        //    var report = new ReportDetail()
        //    {
        //        ReportDetailID = Guid.NewGuid(),
        //        ReportID = reportId,
        //        Total = total,
        //        Pass = pass,
        //        DateReport = dateReport,
        //    };
        //    try
        //    {
        //        InsertReportDetail(report);
        //    }
        //    catch (Exception)
        //    {
        //        throw;
        //    }
        //}

        public Data.IndicateReport GetIndicateReportById(string reportId)
        {
            using (var context = new IndicateReportEntities())
            {
                return context.IndicateReports.FirstOrDefault(c => c.ReportID == reportId);
            }

        }


        public DateTime GetReport_detailById(string reportId)
        {
            using (var context = new IndicateReportEntities())
            {
                var detail = context.Report_detail.FirstOrDefault(c => c.ReportID == reportId);
                if (detail != null)
                    return detail.Date_check;
                return DateTime.Now;
            }
        }

        public List<Report_detail> GetReportDetails()
        {
            using (var context = new IndicateReportEntities())
            {
                return context.Report_detail.ToList();
            }
        }

        public int SumPassByTime(string reportId, int startHour, int startMinute, int endHour, int endMinute)
        {
            var start = new TimeSpan(startHour, startMinute, 0);
            var end = new TimeSpan(endHour, endMinute, 0);
            var reportDetail = GetReportDetails()
                .Where(c => c.ReportID == reportId)
                .Where(c => c.Date_check.ToShortDateString() == DateTime.Now.ToShortDateString())
                .Where(c => c.Time_check >= start && c.Time_check <= end)
                .Sum(c => c.count_actual_pcb);
            if (reportDetail != null)
                return (int) reportDetail;

            return 0;
        }


        public int ActualByTime(string reportId, int startHour, int startSecond, int startMinute, int endHour, int endMinute, int endSecond)
        {
            var start = new TimeSpan(startHour, startMinute, startSecond);
            var end = new TimeSpan(endHour, endMinute, endSecond);
            using (var context=new IndicateReportEntities())
            {
                var report = context.IndicateReports
                    .Where(c => c.ReportID == reportId)
                    .Where(c => c.DateRerport.ToShortDateString() == DateTime.Now.ToShortDateString()).FirstOrDefault(c => c.DateRerport.TimeOfDay >= start && c.DateRerport.TimeOfDay <= end);
                if (report != null)
                {
                    int pass = report.Pass;
                    return pass;
                }

                return 0;
            }
            
        }

        //private void SaveChanges()
        //{
        //    _context.SaveChanges();
        //} 
    }
    //public static class TimeExtensions
    //{
    //    public static bool IsBetween(this DateTime time, DateTime startTime, DateTime endTime)
    //    {
    //        if (time.TimeOfDay == startTime.TimeOfDay) return true;
    //        if (time.TimeOfDay == endTime.TimeOfDay) return true;

    //        if (startTime.TimeOfDay <= endTime.TimeOfDay)
    //            return (time.TimeOfDay >= startTime.TimeOfDay && time.TimeOfDay <= endTime.TimeOfDay);
    //        else
    //            return !(time.TimeOfDay >= endTime.TimeOfDay && time.TimeOfDay <= startTime.TimeOfDay);
    //    }
    //}
}