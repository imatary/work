using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UMC.OQC.Barcode
{
    public class NICHICON_BUS
    {
        private NICHICON_DAO dataNICHICON;
        public NICHICON_BUS()
        {
            this.dataNICHICON = new NICHICON_DAO();
        }
        /// <summary>
        /// Thêm mới
        /// </summary>
        public int Add(NICHICON model)
        {
            return dataNICHICON.Add(model);
        }
        /// <summary>
        /// Cập nhật
        /// </summary>
        public int Update(NICHICON model)
        {
            return dataNICHICON.Update(model);
        }
        /// <summary>
        /// Lấy về tất cả bản ghi
        /// </summary>
        public List<NICHICON> GetAll()
        {
            return dataNICHICON.GetAll();
        }

        /// <summary>
        /// Lấy danh sách board trong thùng
        /// </summary>
        /// <returns></returns>
        public List<NICHICON> GetAll(string boxId)
        {
            return dataNICHICON.GetAll(boxId);
        }

        /// <summary>
        /// Query a single record
        /// </summary>
        public NICHICON Get(string productionid)
        {
            return dataNICHICON.Get(productionid);
        }
        /// <summary>
        /// Kiểm tra sự tồn tịa của BoxID
        /// </summary>
        /// <param name="boxId"></param>
        /// <returns></returns>
        public NICHICON CheckBoxExists(string boxId)
        {
            return dataNICHICON.CheckBoxExists(boxId);
        }

        /// <summary>
        /// Kiểm tra Board No đã có hay chưa?
        /// </summary>
        /// <param name="boxId"></param>
        /// <returns></returns>
        public string CheckBoardNOExists(string boardNo)
        {
            return dataNICHICON.CheckBoardNOExists(boardNo);
        }

        /// <summary>
        /// Xóa
        /// </summary>
        public int Delete(string productionid)
        {
            return dataNICHICON.Delete(productionid);
        }
        /// <summary>
        /// Lấy thời gian trên server
        /// </summary>
        /// <returns></returns>
        public DateTime GetDateTimeFormSqlServer()
        {
            return dataNICHICON.GetDateTimeFormSqlServer();
        }
    }
}
