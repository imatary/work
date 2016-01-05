using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Indicate.Data;

namespace IndicateReort.Service
{
    public class TimingService
    {

        public TimingService()
        {
            
        }

        /// <summary>
        /// Danh sách time
        /// </summary>
        /// <param name="shift"></param>
        /// <returns></returns>
        public List<Timing> GetTimings(int shift)
        {
            var context = new QUANLYSANXUATEntities();
            return context.Timings.Where(t => t.Id_sheet_production == shift).ToList();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<ScheduleView> GetScheduleViews(int shift)
        {
            var context = new QUANLYSANXUATEntities();
            var schedules = (from timing in context.Timings
                where timing.Id_sheet_production == shift
                select new ScheduleView()
                {
                    StartTime = timing.StartTime.ToString(),
                    EndTime = timing.EndTime.ToString(),
                    Plan = (int) timing.SetPlan,
                    QuantityCurrent = (int) timing.Products_current_hour,
                }).ToList();

            return schedules;
        } 

        public Timing GetTimeByID(int id)
        {
            var context = new QUANLYSANXUATEntities();
            return context.Timings.FirstOrDefault(u => u.Id_time_test == id);
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="timing"></param>
        public void Update(Timing timing)
        {
            var context = new QUANLYSANXUATEntities();
            context.Timings.Attach(timing);
            context.Entry(timing).State = EntityState.Modified;
            context.SaveChanges();
        }
    }
}