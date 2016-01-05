using System.Collections.Generic;
using System.Linq;
using VAT.Data;

namespace VAT.Services
{
    public class CustomerService
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<Customer> GetCustomers()
        {
            using (var context = new PURCHASEEntities())
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
            using (var context = new PURCHASEEntities())
            {
                return context.Customers.FirstOrDefault(c => c.CUST_CODE == custCode);
            }
            
        }

        private void Add(Customer customer)
        {
            using (var context=new PURCHASEEntities())
            {
                context.AddToCustomers(customer);
                context.SaveChanges();
            }
            
        }

        public void Delete(string custCode)
        {
            using (var context = new PURCHASEEntities())
            {
                Customer customer = context.Customers.FirstOrDefault(c => c.CUST_CODE == custCode);
                if (customer != null)
                {
                    context.DeleteObject(customer);
                    context.SaveChanges();
                }
                
            }
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
                var cusInsert = new Customer()
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
                using (var context = new PURCHASEEntities())
                {
                    Customer cusUpdate = context.Customers.FirstOrDefault(c => c.CUST_CODE == custCode);
                    if (cusUpdate != null)
                    {
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

                        context.SaveChanges();
                    }

                }
            }
        }




        private void SaveChanges()
        {
            using (var context=new PURCHASEEntities())
            {
                context.SaveChanges();
            }
        } 
    }
}