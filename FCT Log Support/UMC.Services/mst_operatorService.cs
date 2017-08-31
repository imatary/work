using Dapper;
using System.Linq;
using UMC.Entities;

namespace UMC.Services
{
    public class mst_operatorService : QA_BaseService
    {

        /// <summary>
        /// 
        /// </summary>
        /// <param name="operatorId"></param>
        /// <returns></returns>
        public mst_operator GetSingle(string operatorId)
        {
            using (var connection=GetOpenConnection())
            {
                return connection.Get<mst_operator>(operatorId);
            }
        } 
    }
}
