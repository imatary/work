using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Stock.Data;

namespace Stock.Services
{
    public class WeekReportService
    {
        private readonly StockDataEntities _context;

        public WeekReportService()
        {
            _context = new StockDataEntities();
        }

        /// <summary>
        /// Trả về danh sách
        /// </summary>
        /// <returns></returns>
        public List<WeekReport> GetWeekReports(string reportDate)
        {
            var context = new StockDataEntities();

            if (string.IsNullOrEmpty(reportDate))
            {
                return context.WeekReports.ToList();
            }
            return context.WeekReports.Where(w => w.ReportDate == reportDate).ToList();
        }

        /// <summary>
        /// Trả về theo ID
        /// </summary>
        /// <param name="departmentId">ID</param>
        /// <param name="reportDate"></param>
        /// <returns></returns>
        public WeekReport GetWeekReportById(string departmentId, string reportDate)
        {
            return _context.WeekReports.FirstOrDefault(u => u.DepartmentID == departmentId && u.ReportDate == reportDate);
        }


        /// <summary>
        /// Kiểm tra sự tồn tại của ID
        /// </summary>
        /// <param name="departmentId"></param>
        /// <param name="reportDate"></param>
        public bool CheckWeekReportIdExit(string departmentId, string reportDate)
        {
            WeekReport weekReport = GetWeekReportById(departmentId, reportDate);
            if (weekReport != null)
            {
                return false;
            }
            return true;
        }

        /// <summary>
        /// Thêm mới
        /// </summary>
        /// <param name="weekReport"></param>
        /// <returns></returns>
        public void Add(WeekReport weekReport)
        {
            _context.WeekReports.Add(weekReport);
            SaveChanges();
        }




        /// <summary>
        /// Cập nhật thông tin
        /// </summary>
        /// <param name="weekReport"></param>
        public void Update(WeekReport weekReport)
        {
            _context.WeekReports.Attach(weekReport);
            _context.Entry(weekReport).State = EntityState.Modified;
            SaveChanges();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="departmentId"></param>
        /// <param name="departmentName"></param>
        /// <param name="createdDate"></param>
        /// <param name="quantity"></param>
        public void InsertOrUpdateWeekReport(
            string departmentId,
            string departmentName,
            DateTime createdDate,
            int quantity)
        {
            string reportDate = createdDate.Date.ToString("MM-yyyy");
            WeekReport weekReport;

            // Nếu chưa tồn tại thì tạo mới
            if (CheckWeekReportIdExit(departmentId, reportDate))
            {
                weekReport = new WeekReport()
                {
                    DepartmentID = departmentId,
                    ReportDate = reportDate,
                    DepartmentName = departmentName,
                };
                const int defaultNull = 0;
                if (GetWeekNumberOfMonth(createdDate) == 1)
                {
                    weekReport.Week_1 = quantity > 0 ? quantity : defaultNull;
                    
                }
                else if (GetWeekNumberOfMonth(createdDate) == 2)
                {
                    weekReport.Week_2 = quantity > 0 ? quantity : defaultNull;
                }
                else if (GetWeekNumberOfMonth(createdDate) == 3)
                {
                    weekReport.Week_3 = quantity > 0 ? quantity : defaultNull;
                }
                else if (GetWeekNumberOfMonth(createdDate) == 4)
                {
                    weekReport.Week_4 = quantity > 0 ? quantity : defaultNull;
                }
                else if (GetWeekNumberOfMonth(createdDate) == 5)
                {
                    weekReport.Week_5 = quantity > 0 ? quantity : defaultNull;
                }

                try
                {
                    Add(weekReport);
                }
                catch (Exception)
                {
                    throw new Exception();
                }
            }
            // Nếu tồn tại rồi thì cập nhật thông tin
            else
            {
                weekReport = GetWeekReportById(departmentId, reportDate);
                if (GetWeekNumberOfMonth(createdDate) == 1)
                {
                    weekReport.Week_1 += quantity;
                }
                else if (GetWeekNumberOfMonth(createdDate) == 2)
                {
                    weekReport.Week_2 += quantity;
                }
                else if (GetWeekNumberOfMonth(createdDate) == 3)
                {
                    weekReport.Week_3 += quantity;
                }
                else if (GetWeekNumberOfMonth(createdDate) == 4)
                {
                    weekReport.Week_4 += quantity;
                }
                else if (GetWeekNumberOfMonth(createdDate) == 5)
                {
                    weekReport.Week_5 += quantity;
                }
                try
                {
                    Update(weekReport);
                }
                catch (Exception)
                {
                    throw new Exception();
                }
            }

        }

        /// <summary>
        /// Get week number
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        static int GetWeekNumberOfMonth(DateTime date)
        {
            date = date.Date;
            var firstMonthDay = new DateTime(date.Year, date.Month, 1);
            DateTime firstMonthMonday = firstMonthDay.AddDays((DayOfWeek.Monday + 7 - firstMonthDay.DayOfWeek) % 7);
            if (firstMonthMonday > date)
            {
                firstMonthDay = firstMonthDay.AddMonths(-1);
                firstMonthMonday = firstMonthDay.AddDays((DayOfWeek.Monday + 7 - firstMonthDay.DayOfWeek) % 7);
            }
            return (date - firstMonthMonday).Days / 7 + 1;
        }

        private void SaveChanges()
        {
            _context.SaveChanges();
        } 
    }
}