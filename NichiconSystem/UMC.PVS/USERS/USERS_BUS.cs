using System.Collections.Generic;

namespace UMC.PVS.USERS
{
    public class USERS_BUS
    {
        private USERS_DAO dataUSERS;
        public USERS_BUS()
        {
            this.dataUSERS = new USERS_DAO();
        }
        /// <summary>
        /// Lấy về tất cả bản ghi
        /// </summary>
        public List<USERS> GetAll()
        {
            return dataUSERS.GetAll();
        }
        /// <summary>
        /// Query a single record
        /// </summary>
        public USERS Get(string id)
        {
            return dataUSERS.Get(id);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public USERS Get(string username, string password)
        {
            return dataUSERS.Get(username, password);
        }
    }
}
