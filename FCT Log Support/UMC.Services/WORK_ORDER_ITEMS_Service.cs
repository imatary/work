using Dapper;
using System.Linq;
using UMC.Entities;

namespace UMC.Services
{
    public class WORK_ORDER_ITEMS_Service : PVS_BaseService
    {
        public WORK_ORDER_ITEMS GetSingle(string boardNo)
        {
            using (var connection = GetOpenConnection())
            {
                return connection.GetList<WORK_ORDER_ITEMS>("WHERE (BOARD_NO = @boardNo)", new { boardNo = boardNo }).SingleOrDefault();
            }
        } 
    }
}
