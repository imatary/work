using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using InvoicePurchase.Data;

namespace InvoicePurchase.Service
{
    public class CustomerService
    {
        private readonly InvoicePurchaseEntities _context; 
        public CustomerService()
        {
            _context = new InvoicePurchaseEntities();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<Customer> GetCustomers()
        {
            using (var context=new InvoicePurchaseEntities())
            {
                return context.Customers.ToList();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="custCode"></param>
        /// <returns></returns>
        public Customer GetCustomerByCustCode(string custCode)
        {
            return _context.Customers.FirstOrDefault(c => c.CUST_CODE == custCode);
        }

        private void Add(Customer customer)
        {
            _context.Customers.Add(customer);
            SaveChanges();
        }
        private void Update(Customer customer)
        {
            _context.Customers.Attach(customer);
            _context.Entry(customer).State = EntityState.Modified;
            SaveChanges();
        }

        public bool CheckCustCodeExit(string custCode)
        {
            Customer customer = GetCustomerByCustCode(custCode);
            if (customer != null)
            {
                return false;
            }
            return true;
        }
        public void InsertOrUpdate(string custCode,
            string custName,
            string address,
            string taxCode,
            string tel,
            string fax,
            string partName,
            string buyerName,
            string cusName,
            string payType,
            string payTerm,
            string currency,
            string codeTax,
            string delTerm,
            string delPlace,
            string namePart
            )
        {
            //Add(customer);
            if (CheckCustCodeExit(custCode))
            {
                var cusInsert= new Customer()
                {
                    CUST_CODE = custCode,
                    CUST_NAME = custName,
                    ADDRESS = address,
                    TAX_CODE = taxCode,
                    TEL = tel,
                    FAX = fax,
                    NAME_PART = partName,
                    BUYER = buyerName,
                    NAME_CUS = cusName,
                    PAY_TYPE = payType,
                    PAY_TERM = payTerm,
                    CURRENCY = currency,
                    CODE_TAX = codeTax,
                    DEL_TERM = delTerm,
                    DEL_PLACE = delPlace,
                    NAME_PART1 = namePart
                };

                Add(cusInsert);
            }
            else
            {
                Customer cusUpdate = GetCustomerByCustCode(custCode);
                cusUpdate.CUST_NAME = custName;
                cusUpdate.ADDRESS = address;
                cusUpdate.CODE_TAX = taxCode;
                cusUpdate.TEL = tel;
                cusUpdate.FAX = fax;
                cusUpdate.NAME_PART = partName;
                cusUpdate.BUYER = buyerName;
                cusUpdate.NAME_CUS = cusName;
                cusUpdate.PAY_TYPE = payType;
                cusUpdate.PAY_TERM = payTerm;
                cusUpdate.CURRENCY = currency;
                cusUpdate.TAX_CODE = codeTax;
                cusUpdate.DEL_TERM = delTerm;
                cusUpdate.DEL_PLACE = delPlace;
                cusUpdate.NAME_PART1 = namePart;
                Update(cusUpdate);
            }
        }


        

        private void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}