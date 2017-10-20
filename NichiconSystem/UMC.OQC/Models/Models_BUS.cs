using System.Collections.Generic;

namespace UMC.OQC.Models
{
    public class Models_BUS
    {
        private Models_DAO dataModels;
        public Models_BUS()
        {
            this.dataModels = new Models_DAO();
        }
        /// <summary>
        /// Thêm mới
        /// </summary>
        public int Add(Models model)
        {
            return dataModels.Add(model);
        }
        /// <summary>
        /// Cập nhật
        /// </summary>
        public int Update(Models model)
        {
            return dataModels.Update(model);
        }
        /// <summary>
        /// Lấy về tất cả bản ghi
        /// </summary>
        public List<Models> GetAll(string cusName)
        {
            return dataModels.GetAll(cusName);
        }
        /// <summary>
        /// Query a single record
        /// </summary>
        public Models Get(string modelid)
        {
            return dataModels.Get(modelid);
        }
        /// <summary>
        /// Xóa
        /// </summary>
        public int Delete(string modelid)
        {
            return dataModels.Delete(modelid);
        }
    }
}
