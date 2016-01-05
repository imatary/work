using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Validation;
using System.Linq;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using Stock.Data;

namespace Stock.Services
{
    public class LogService
    {
        private readonly StockDataEntities _context;
        public LogService()
        {
            _context = new StockDataEntities();
        }

        /// <summary>
        /// Danh sách Log
        /// </summary>
        /// <returns></returns>
        public List<Log> GetLogs()
        {
            var context = new StockDataEntities();

            return context.Logs.OrderByDescending(log => log.LogDate).ToList();

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Log GetLogById(Guid id)
        {
            return _context.Logs.FirstOrDefault(l => l.ID == id);
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
        /// <param name="action"></param>
        /// <param name="currentForm"></param>
        public void InsertLog(string userName,  string action, string currentForm)
        {
            var log = new Log()
            {
                ID = Guid.NewGuid(),
                Username = userName,
                FullName = userName,
                Form = currentForm,
                Action = action,
                ComputerName = System.Net.Dns.GetHostName(),
                LogDate = DateTime.Now,
            };

            foreach (NetworkInterface networkInterface in NetworkInterface.GetAllNetworkInterfaces())
            {
                if (networkInterface.OperationalStatus == OperationalStatus.Up)
                {
                    foreach (var ip in networkInterface.GetIPProperties().UnicastAddresses)
                    {
                        if (ip.Address.AddressFamily == AddressFamily.InterNetwork)
                        {
                            log.MacAddress = networkInterface.GetPhysicalAddress().ToString();
                            log.IP = ip.Address.ToString();
                        }
                    }
                }
            }

            try
            {
                Add(log);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            
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