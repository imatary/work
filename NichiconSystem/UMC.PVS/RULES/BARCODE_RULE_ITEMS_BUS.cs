using System;
using System.Collections.Generic;

namespace UMC.PVS.RULES
{
    public class BARCODE_RULE_ITEMS_BUS
    {
        private BARCODE_RULE_ITEMS_DAO dataBARCODE_RULE_ITEMS;
        public BARCODE_RULE_ITEMS_BUS()
        {
            this.dataBARCODE_RULE_ITEMS = new BARCODE_RULE_ITEMS_DAO();
        }
        /// <summary>
        /// Lấy về tất cả bản ghi
        /// </summary>
        public List<BARCODE_RULE_ITEMS> GetAll()
        {
            return dataBARCODE_RULE_ITEMS.GetAll();
        }
        /// <summary>
        /// Query a single record
        /// </summary>
        public BARCODE_RULE_ITEMS Get(Guid id)
        {
            return dataBARCODE_RULE_ITEMS.Get(id);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public BARCODE_RULE_ITEMS Get(string name)
        {
            return dataBARCODE_RULE_ITEMS.Get(name);
        }
    }
}
