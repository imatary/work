﻿using BarcodeShipping.Data;
using System.Collections.Generic;
using System.Linq;

namespace BarcodeShipping.Services
{
    public interface IOperatorService
    {
        IEnumerable<mst_operator> GetOperators();
        
    }
    public class OperatorService : IOperatorService
    {
        private readonly IQCDataEntities _context = new IQCDataEntities();

        public IEnumerable<mst_operator> GetOperators()
        {
            return _context.Database.SqlQuery<mst_operator>("EXEC [sp_GetOperators]").OrderByDescending(item => item.OperatorName).ToList();
        }
    }
}