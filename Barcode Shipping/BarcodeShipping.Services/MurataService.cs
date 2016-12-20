using BarcodeShipping.Data;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace BarcodeShipping.Services
{
    public class MurataService
    {
        private readonly ShippingFujiXeroxDbContext _context;
        public MurataService()
        {
            _context = new ShippingFujiXeroxDbContext();
        }

        public IEnumerable<Murata> GetAllProductsMurata()
        {
            return null;
        }
        public Murata GetProducts_Murata_by_ModelCustomer(string labelCustumer)
        {
            var param = new SqlParameter()
            {
                ParameterName = "@modelCustomer",
                SqlDbType = SqlDbType.VarChar,
                Value = labelCustumer,
            };
            return _context.Database.SqlQuery<Murata>("EXEC [sp_GetProducts_Murata_by_ModelCustomer] @modelCustomer", param).SingleOrDefault();
        }

        public IEnumerable<Murata> GetProducts_Murata_by_BoxId(string boxId)
        {
            var param = new SqlParameter()
            {
                ParameterName = "@boxId",
                SqlDbType = SqlDbType.VarChar,
                Value = boxId,
            };
            return _context.Database.SqlQuery<Murata>("EXEC [sp_GetProducts_Murata_by_BoxId] @boxId", param).ToList();
        }
    }
}
