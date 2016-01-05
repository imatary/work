using System.Collections.Generic;
using System.Linq;
using Indicate.Data;

namespace IndicateReort.Service
{
    public class CustomerService
    {
        private readonly QUANLYSANXUATEntities _context;

        public CustomerService()
        {
            _context = new QUANLYSANXUATEntities();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<Customer> GetCustomers()
        {
            var context = new QUANLYSANXUATEntities();

            return context.Customers.ToList();

        }

        /// <summary>
        /// Trả về thông tin Line theo tên
        /// </summary>
        /// <param name="customerId"></param>
        /// <returns></returns>
        public Customer GetCustomerById(string customerId)
        {
            return GetCustomers().FirstOrDefault(c => c.Id_customer == customerId);
        }
     
    }
}