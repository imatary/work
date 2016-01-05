using System.Collections.Generic;
using System.Linq;
using IndicateReport.Data;

namespace IndicateReport.Services
{
    public class CustomerService
    {
        private readonly IndicateReportMasterEntities _context;

        public CustomerService()
        {
            _context = new IndicateReportMasterEntities();
        }

        /// <summary>
        /// Get List
        /// </summary>
        /// <returns></returns>
        public List<Customer> GetCustomers()
        {
            using (var context=new IndicateReportMasterEntities())
            {
                return context.Customers.ToList();
            }
        }


        /// <summary>
        /// Insert Line
        /// </summary>
        /// <param name="customer"></param>
        public void Insert(Customer customer)
        {
            if (customer != null)
            {
                _context.Customers.AddObject(customer);
                SaveChanges();
            }
        }


        private void SaveChanges()
        {
            _context.SaveChanges();
        } 
    }
}