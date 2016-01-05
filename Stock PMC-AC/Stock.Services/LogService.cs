using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Validation;
using System.Linq;
using Stock.Data;

namespace Stock.Services
{
    public class LogService
    {
        private readonly StockACEntities _context;
        public LogService()
        {
            _context=new StockACEntities();
        }

        /// <summary>
        /// Danh sách Log
        /// </summary>
        /// <returns></returns>
        public List<Log> GetLogs()
        {
            using (var context=new StockACEntities())
            {
                return context.Logs.OrderByDescending(log=>log.LogDate).ToList();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Log GetLogById(int id)
        {
            return _context.Logs.FirstOrDefault(l => l.Id == id);
        }

        /// <summary>
        /// Thêm
        /// </summary>
        /// <param name="log"></param>
        private void Add(Log log)
        {
            _context.Logs.Add(log);
            SaveChanges();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="employeeName"></param>
        /// <param name="action"></param>
        /// <param name="currentForm"></param>
        /// <param name="clientInfo"></param>
        public void InsertLog(string userName, string employeeName, string action, string currentForm, string clientInfo)
        {
            var log = new Log()
            {
                UserName = userName,
                EmployeeName = employeeName,
                Form = currentForm,
                Action = action,
                ClientInfo = clientInfo,
                LogDate = DateTime.Now,
            };
            Add(log);
        }

        /// <summary>
        /// 
        /// </summary>
        private void SaveChanges()
        {
            try
            {
                _context.SaveChanges();
            }
            catch (DbEntityValidationException)
            {
                throw new DbEntityValidationException();
            }
            catch (DbUpdateException)
            {
                throw new DbUpdateException();
            }
            
        }
    }
}