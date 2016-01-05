using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Diagnostics;
using System.Linq;
using CartonLabel.Data;

namespace CartonLabel.Services
{
    public class PartNoService
    {
        private readonly CartonLabelEntities _context;
        public PartNoService()
        {
            _context = new CartonLabelEntities();
        }

        public List<Part> GetPartNoes()
        {
            using (var context=new CartonLabelEntities())
            {
                return context.Parts.ToList();
            }
        }

        /// <summary>
        /// Trả về thông tin
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public Part GetPartNoByValue(string value)
        {
            return _context.Parts.FirstOrDefault(p => p.PartNoValue == value);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="partNo"></param>
        /// <returns></returns>
        public bool CheckPartNoExits(string partNo)
        {
            Part part = GetPartNoByValue(partNo);
            if (part != null)
            {
                return false;
            }
            return true;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="partNoValue"></param>
        /// <returns></returns>
        public int GetQuantityByValue(string partNoValue)
        {
            if (!string.IsNullOrEmpty(partNoValue))
            {
                var part = GetPartNoByValue(partNoValue);
                if(part !=null)
                {
                    if (part.Quantity != null)
                    {
                        var quantity = (int) part.Quantity;
                        return quantity;
                    }
                }
            }
            return 0;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="partNoValue"></param>
        /// <returns></returns>
        public float GetWeightByValue(string partNoValue)
        {
            if (!string.IsNullOrEmpty(partNoValue))
            {
                var part = GetPartNoByValue(partNoValue);
                if (part != null)
                {
                    if (part.Weight != null)
                    {
                        var weight = (float)part.Weight;
                        return weight;
                    }
                }
            }
            return 0;
        }

        private void Insert(Part part)
        {
            _context.Parts.Add(part);
            SaveChanges();
        }

        public void InsertPartToDatabase(string partNoValue, int quantity, long price, string description, double weight)
        {
            var partNo = GetPartNoByValue(partNoValue);
            if (partNo != null)
            {
                partNo.Quantity = quantity;
                partNo.Price = price;
                partNo.Description = description;
                partNo.Weight = weight;
                try
                {
                    SaveChanges();
                }
                catch (DbEntityValidationException dbEx)
                {
                    foreach (var validationErrors in dbEx.EntityValidationErrors)
                    {
                        foreach (var validationError in validationErrors.ValidationErrors)
                        {
                            Trace.TraceInformation("Property: {0} Error: {1}",
                                                    validationError.PropertyName,
                                                    validationError.ErrorMessage);
                        }
                    }
                }
            }
            else
            {
                var part = new Part()
                {
                    PartNoID = partNoValue,
                    PartNoValue = partNoValue,
                    Quantity = quantity,
                    Price = price,
                    Description = description,
                    Weight = weight
                };
                try
                {
                    Insert(part);
                }
                catch (DbEntityValidationException dbEx)
                {
                    foreach (var validationErrors in dbEx.EntityValidationErrors)
                    {
                        foreach (var validationError in validationErrors.ValidationErrors)
                        {
                            Trace.TraceInformation("Property: {0} Error: {1}",
                                                    validationError.PropertyName,
                                                    validationError.ErrorMessage);
                        }
                    }
                }
            }
            

        }

        /// <summary>
        /// Save
        /// </summary>
        private void SaveChanges()
        {
            try
            {
                _context.SaveChanges();
            }
            catch (DbEntityValidationException dbEx)
            {
                foreach (var validationErrors in dbEx.EntityValidationErrors)
                {
                    foreach (var validationError in validationErrors.ValidationErrors)
                    {
                        Trace.TraceInformation("Property: {0} Error: {1}",
                                                validationError.PropertyName,
                                                validationError.ErrorMessage);
                    }
                }
            }
        }
    }
}